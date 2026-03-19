using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NDPSo.Chatbot
{
    /// <summary>
    /// STEP 5 — Response Generation
    /// Tích hợp toàn bộ pipeline:
    ///   Intent Detection → Template/AI SQL → DB Query → Natural Language Response
    /// </summary>
    public class ChatbotOrchestrator
    {
        private readonly OpenAIApiService _ai;
        private readonly DatabaseService _db;

        private readonly List<ConversationTurn> _history = new List<ConversationTurn>();
        private const int MAX_HISTORY = 6;

        public event Action<string> OnStatusChanged;

        public ChatbotOrchestrator(string apiKey, string sqlConnectionString)
        {
            _ai = new OpenAIApiService(apiKey);
            _db = new DatabaseService(sqlConnectionString);
        }

        public void ClearHistory() => _history.Clear();

        // ══════════════════════════════════════════════════════
        //  MAIN PIPELINE
        // ══════════════════════════════════════════════════════
        public async Task<ChatbotResult> ProcessQuestionAsync(string question)
        {
            var result = new ChatbotResult { Question = question };

            try
            {
                // ── STEP 4: Detect Intent ─────────────────────
                var intent = IntentDetector.Detect(question);
                OnStatusChanged?.Invoke($"🎯 Intent: {intent}");

                // ── Non-DB intents (chitchat, help) ───────────
                if (IntentDetector.IsNonDbIntent(intent))
                {
                    result.Answer = IntentDetector.GetDirectAnswer(intent);
                    result.IsSuccess = true;
                    AddToHistory(question, result.Answer, null, null);
                    return result;
                }

                // ── STEP 3: Lấy SQL (template hoặc AI sinh) ──
                string sql = null;

                if (IntentDetector.HasTemplate(intent))
                {
                    // Có template sẵn → dùng ngay, không cần gọi AI
                    sql = QueryFunctions.GetTemplate(IntentDetector.GetTemplateName(intent));
                    OnStatusChanged?.Invoke("⚡ Dùng template SQL...");
                }
                else
                {
                    // Không có template → AI sinh SQL từ schema + semantic layer
                    OnStatusChanged?.Invoke("🤔 Đang phân tích câu hỏi...");
                    sql = await GenerateSqlWithAI(question);
                }

                if (string.IsNullOrEmpty(sql))
                {
                    result.Answer = "Mình chưa hiểu câu hỏi này. Bạn thử hỏi lại rõ hơn nhé?";
                    result.IsSuccess = true;
                    return result;
                }

                result.SqlUsed = sql;

                // ── Chạy SQL với retry tự động ────────────────
                OnStatusChanged?.Invoke("🔍 Đang truy vấn dữ liệu...");
                string dbData = await TryExecuteWithRetry(sql, question);

                // ── STEP 5: Response Generation ───────────────
                OnStatusChanged?.Invoke("💬 Đang tổng hợp kết quả...");

                if (dbData.Length > 2000)
                    dbData = dbData.Substring(0, 2000) + "\n...(đã rút gọn)";

                string answer = await GenerateNaturalResponse(question, dbData, intent);

                result.Answer = answer;
                result.RawData = dbData;
                result.IsSuccess = true;
                AddToHistory(question, answer, sql, dbData);
            }
            catch (Exception ex)
            {
                result.Answer = $"Xin lỗi, có lỗi xảy ra: {ex.Message}";
                result.IsSuccess = false;
            }

            return result;
        }

        // ══════════════════════════════════════════════════════
        //  STEP 3: AI SQL GENERATION (khi không có template)
        // ══════════════════════════════════════════════════════
        private async Task<string> GenerateSqlWithAI(string question)
        {
            string context = BuildContextPrompt();
            string schema = SchemaSelector.GetSchema(question);

            // Kết hợp schema + semantic layer + business rules + FK map
            string fullPrompt = schema
                + "\n" + SemanticLayer.NATURAL_TO_TECHNICAL
                + "\n" + DatabaseSchema.BUSINESS_RULES
                + "\n" + DatabaseSchema.FK_MAP
                + "\n" + DatabaseSchema.COLUMN_UNITS;

            string userMsg =
                (string.IsNullOrEmpty(context) ? "" : context + "\n") +
                $"Câu hỏi: {question}\n" +
                $"KHÔNG dùng @tham số. Dùng giá trị cụ thể hoặc GETDATE().\n" +
                $"Trả về: SQL: <câu sql>";

            string response = await _ai.ChatAsync(fullPrompt, userMsg);
            return ExtractSql(response);
        }

        // ══════════════════════════════════════════════════════
        //  STEP 5: NATURAL LANGUAGE RESPONSE
        // ══════════════════════════════════════════════════════
        private async Task<string> GenerateNaturalResponse(
            string question, string dbData, IntentDetector.Intent intent)
        {
            // Chọn format phù hợp theo loại intent
            string formatGuide = GetFormatGuide(intent);

            string systemPrompt = SchemaContext.INTERPRET_PROMPT + "\n\n" + formatGuide;

            string context = BuildContextPrompt();
            string userMsg =
                (string.IsNullOrEmpty(context) ? "" : context + "\n") +
                $"Câu hỏi: {question}\n" +
                $"Dữ liệu từ DB:\n{dbData}";

            return await _ai.ChatAsync(systemPrompt, userMsg);
        }

        private string GetFormatGuide(IntentDetector.Intent intent)
        {
            // Tổng hợp số → 1-2 câu ngắn
            if (intent == IntentDetector.Intent.SAN_LUONG_HOM_NAY ||
                intent == IntentDetector.Intent.SAN_LUONG_TUAN_NAY ||
                intent == IntentDetector.Intent.SAN_LUONG_THANG_NAY)
                return "Trả lời trong 1-2 câu. Nêu rõ số mẻ và tổng m³.";

            // So sánh → nêu xu hướng tăng/giảm
            if (intent == IntentDetector.Intent.SO_SANH_THANG)
                return "Trả lời trong 2-3 câu. So sánh số liệu và nêu xu hướng tăng/giảm bao nhiêu %.";

            // Danh sách → tóm tắt tổng + chi tiết nổi bật
            if (intent == IntentDetector.Intent.DANH_SACH_ME_HOM_NAY ||
                intent == IntentDetector.Intent.PHIEU_HOM_NAY ||
                intent == IntentDetector.Intent.PHIEU_THANG_NAY)
                return "Tóm tắt tổng số trước, sau đó nêu vài mục nổi bật. Không liệt kê quá 5 mục.";

            // Top / ranking → nêu top 3-5
            if (intent == IntentDetector.Intent.TOP_KHACH_HANG ||
                intent == IntentDetector.Intent.TOP_CONG_TRUONG ||
                intent == IntentDetector.Intent.XE_NHIEU_NHAT ||
                intent == IntentDetector.Intent.TAI_XE_NHIEU_NHAT)
                return "Nêu top 3-5 theo thứ tự, mỗi mục 1 câu ngắn với số liệu cụ thể.";

            // Tồn kho → nêu từng silo
            if (intent == IntentDetector.Intent.TON_KHO_SILO)
                return "Liệt kê từng silo với tên vật liệu và khối lượng hiện tại (kg).";

            return "Trả lời ngắn gọn, dùng số liệu cụ thể.";
        }

        // ══════════════════════════════════════════════════════
        //  EXECUTE WITH RETRY
        // ══════════════════════════════════════════════════════
        private async Task<string> TryExecuteWithRetry(string sql, string question)
        {
            try
            {
                return _db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                if (msg.StartsWith("SQL_PARAM_ERROR") || msg.Contains("Must declare"))
                {
                    OnStatusChanged?.Invoke("🔄 Đang sửa SQL...");
                    string fixedSql = await RegenerateSqlWithoutParams(sql, question, msg);
                    return _db.ExecuteQuery(fixedSql);
                }

                if (msg.Contains("Invalid column name") || msg.Contains("Invalid object name"))
                {
                    OnStatusChanged?.Invoke("⚠️ Thử dùng view...");
                    string fallback = BuildFallbackSql(sql, question);
                    if (!string.IsNullOrEmpty(fallback))
                        return _db.ExecuteQuery(fallback);
                }

                throw;
            }
        }

        private async Task<string> RegenerateSqlWithoutParams(
            string badSql, string question, string errorMsg)
        {
            string schema = SchemaSelector.GetSchema(question);
            string context = BuildContextPrompt();
            string prompt =
                $"{context}\nSQL bị lỗi:\n{badSql}\n\n" +
                $"Viết lại SQL:\n- KHÔNG dùng @tham số\n" +
                $"- Dùng LIKE N'%từkhóa%' nếu tìm theo tên\n" +
                $"- Dùng giá trị từ context nếu có\n" +
                $"Câu hỏi: {question}\nTrả về: SQL: <câu sql>";

            string response = await _ai.ChatAsync(
                schema + "\n" + DatabaseSchema.BUSINESS_RULES, prompt);
            string newSql = ExtractSql(response);

            if (string.IsNullOrEmpty(newSql))
                throw new Exception("Không thể sinh lại SQL hợp lệ.");
            return newSql;
        }

        private string BuildFallbackSql(string originalSql, string question)
        {
            var sqlUp = originalSql.ToUpper();
            var q = RemoveDiacritics(question.ToLower());

            if (Contains(sqlUp, "XE") || Contains(q, "xe", "bien so"))
                return q.Contains("hom nay")
                    ? "SELECT TOP 50 XeID,BienSo,Total_Tranfer,Total_KL,NgayMeTron FROM dbo.vw_PvTranferDetailDay WHERE NgayMeTron=CAST(GETDATE() AS DATE) ORDER BY Total_KL DESC"
                    : "SELECT TOP 20 XeID,BienSo,Total_Tranfer,Total_KL FROM dbo.vw_PvTotalTranfer ORDER BY Total_KL DESC";

            if (Contains(sqlUp, "TAIXE") || Contains(q, "tai xe", "lai xe"))
                return q.Contains("hom nay")
                    ? "SELECT TOP 20 TaiXeID,TenTaiXe,Total_Tranfer,Total_KL FROM dbo.vw_PvDriverDetailDay WHERE NgayMeTron=CAST(GETDATE() AS DATE) ORDER BY Total_KL DESC"
                    : "SELECT TOP 20 TaiXeID,MaTaiXe,TenTaiXe,Total_Tranfer,Total_KL FROM dbo.vw_PvTotalDriver ORDER BY Total_KL DESC";

            if (Contains(sqlUp, "MATERIAL") || Contains(q, "vat lieu", "xi mang", "cat ", "da "))
                return q.Contains("hom nay")
                    ? "SELECT TOP 20 MaterialCode,MaterialName,Sum_ValueCP,Sum_ValueBat,SaiSo,NgayMeTron FROM dbo.vw_PvMaterialDetailDay WHERE CAST(NgayMeTron AS DATE)=CAST(GETDATE() AS DATE) ORDER BY Sum_ValueCP DESC"
                    : "SELECT TOP 20 MaterialCode,MaterialName,Sum_ValueCP,Sum_ValueBat,SaiSo FROM dbo.vw_PvTotalMaterial ORDER BY Sum_ValueCP DESC";

            if (Contains(sqlUp, "METRON") || Contains(q, "me tron", "san luong", "me "))
                return "SELECT TOP 50 MeTronID,MaPhieuTron,NgayMeTron,KH,CT,Plate,KLMe,TenNV FROM dbo.vw_Infos WHERE CAST(NgayMeTron AS DATE)=CAST(GETDATE() AS DATE) ORDER BY NgayMeTron DESC";

            if (Contains(q, "phieu", "giao hang"))
                return "SELECT TOP 50 MaPhieuTron,NgayPhieuTron,KH,CT,KLDuTinh,KLThuc,BS,TX FROM dbo.vw_InfoPT WHERE CAST(NgayPhieuTron AS DATE)=CAST(GETDATE() AS DATE) ORDER BY NgayPhieuTron DESC";

            return null;
        }

        // ══════════════════════════════════════════════════════
        //  CONVERSATION HISTORY (context)
        // ══════════════════════════════════════════════════════
        private string BuildContextPrompt()
        {
            if (_history.Count == 0) return "";
            var sb = new StringBuilder();
            sb.AppendLine("=== NGỮ CẢNH HỘI THOẠI ===");
            int start = Math.Max(0, _history.Count - 3);
            for (int i = start; i < _history.Count; i++)
            {
                var t = _history[i];
                sb.AppendLine($"User: {t.Question}");
                sb.AppendLine($"AI: {t.Answer}");
                if (!string.IsNullOrEmpty(t.KeyData))
                    sb.AppendLine($"[Data: {t.KeyData}]");
                sb.AppendLine("---");
            }
            return sb.ToString();
        }

        private void AddToHistory(string q, string a, string sql, string data)
        {
            _history.Add(new ConversationTurn
            {
                Question = q,
                Answer = a,
                SqlUsed = sql,
                KeyData = ExtractKeyData(a)
            });
            while (_history.Count > MAX_HISTORY)
                _history.RemoveAt(0);
        }

        private string ExtractKeyData(string answer)
        {
            if (string.IsNullOrEmpty(answer)) return null;
            var sb = new StringBuilder();
            var dates = Regex.Matches(answer, @"\b(\d{1,2}/\d{1,2}/\d{4}|\d{4}-\d{2}-\d{2})\b");
            foreach (Match m in dates) sb.Append($"Ngày:{m.Value} ");
            var nums = Regex.Matches(answer, @"\b(\d+(?:[.,]\d+)?)\s*(m³|m3|kg|tấn|chuyến|mẻ|phiếu)\b", RegexOptions.IgnoreCase);
            foreach (Match m in nums) sb.Append($"{m.Value} ");
            return sb.Length > 0 ? sb.ToString().Trim() : null;
        }

        // ══════════════════════════════════════════════════════
        //  HELPERS
        // ══════════════════════════════════════════════════════
        private string ExtractSql(string response)
        {
            if (string.IsNullOrWhiteSpace(response)) return null;
            var m = Regex.Match(response, @"SQL:\s*(SELECT[\s\S]+?)(?:\n\n|;\s*\n|\z)", RegexOptions.IgnoreCase);
            if (m.Success) return m.Groups[1].Value.Trim();
            var cb = Regex.Match(response, @"```(?:sql)?\s*(SELECT[\s\S]+?)```", RegexOptions.IgnoreCase);
            if (cb.Success) return cb.Groups[1].Value.Trim();
            var d = Regex.Match(response, @"(SELECT\s+[\s\S]+?)(?:;|\n\n|\z)", RegexOptions.IgnoreCase);
            if (d.Success) return d.Groups[1].Value.Trim();
            return null;
        }

        private bool Contains(string text, params string[] kws)
        {
            foreach (var kw in kws) if (text.Contains(kw)) return true;
            return false;
        }

        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;
            return text
                .Replace("à", "a").Replace("á", "a").Replace("ả", "a").Replace("ã", "a").Replace("ạ", "a")
                .Replace("ă", "a").Replace("ắ", "a").Replace("ằ", "a").Replace("ẳ", "a").Replace("ẵ", "a").Replace("ặ", "a")
                .Replace("â", "a").Replace("ấ", "a").Replace("ầ", "a").Replace("ẩ", "a").Replace("ẫ", "a").Replace("ậ", "a")
                .Replace("è", "e").Replace("é", "e").Replace("ẻ", "e").Replace("ẽ", "e").Replace("ẹ", "e")
                .Replace("ê", "e").Replace("ế", "e").Replace("ề", "e").Replace("ể", "e").Replace("ễ", "e").Replace("ệ", "e")
                .Replace("ì", "i").Replace("í", "i").Replace("ỉ", "i").Replace("ĩ", "i").Replace("ị", "i")
                .Replace("ò", "o").Replace("ó", "o").Replace("ỏ", "o").Replace("õ", "o").Replace("ọ", "o")
                .Replace("ô", "o").Replace("ố", "o").Replace("ồ", "o").Replace("ổ", "o").Replace("ỗ", "o").Replace("ộ", "o")
                .Replace("ơ", "o").Replace("ớ", "o").Replace("ờ", "o").Replace("ở", "o").Replace("ỡ", "o").Replace("ợ", "o")
                .Replace("ù", "u").Replace("ú", "u").Replace("ủ", "u").Replace("ũ", "u").Replace("ụ", "u")
                .Replace("ư", "u").Replace("ứ", "u").Replace("ừ", "u").Replace("ử", "u").Replace("ữ", "u").Replace("ự", "u")
                .Replace("ỳ", "y").Replace("ý", "y").Replace("ỷ", "y").Replace("ỹ", "y").Replace("ỵ", "y")
                .Replace("đ", "d");
        }

        public bool TestDatabaseConnection() => _db.TestConnection();
    }

    public class ChatbotResult
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string SqlUsed { get; set; }
        public string RawData { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }

    public class ConversationTurn
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string SqlUsed { get; set; }
        public string KeyData { get; set; }
    }
}
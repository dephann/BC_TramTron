using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NDPSo.Chatbot
{
    /// <summary>
    /// STEP 5 — Response Generation
    /// Pipeline: Intent Detection → Template/AI SQL → SmartRetryEngine → Natural Language Response
    /// </summary>
    public class ChatbotOrchestrator
    {
        private readonly OpenAIApiService _ai;
        private readonly DatabaseService _db;
        private readonly SmartRetryEngine _retry; // ← Tự động thử bảng liên quan khi rỗng

        private readonly List<ConversationTurn> _history = new List<ConversationTurn>();
        private const int MAX_HISTORY = 6;

        public event Action<string> OnStatusChanged;

        public ChatbotOrchestrator(string apiKey, string sqlConnectionString)
        {
            _ai = new OpenAIApiService(apiKey);
            _db = new DatabaseService(sqlConnectionString);
            _retry = new SmartRetryEngine(_ai, _db);
            _retry.OnStatusChanged += s => OnStatusChanged?.Invoke(s);
        }

        public void ClearHistory() => _history.Clear();

        // ══════════════════════════════════════════════════════
        //  CLARIFICATION — câu hỏi mơ hồ cần hỏi lại
        // ══════════════════════════════════════════════════════
        private static readonly (string[] Keywords, string ClarifyQuestion)[] AMBIGUOUS_PATTERNS =
        {
            (
                new[] { "tổng khối lượng", "tong khoi luong",
                        "khối lượng tổng", "tổng kl", "tong kl",
                        "kiểm tra khối lượng", "kiem tra khoi luong",
                        "xem khối lượng", "khối lượng là bao nhiêu",
                        "tìm khối lượng", "tim khoi luong" },
                "Bạn muốn xem tổng khối lượng của:\n" +
                "① Mẻ trộn thực tế (hôm nay / tuần / tháng)\n" +
                "② Phiếu trộn dự tính vs thực tế\n" +
                "③ Vật liệu tiêu thụ trong silo\n" +
                "④ Hợp đồng (đã giao / còn lại)\n" +
                "⑤ Theo xe hoặc tài xế\n\n" +
                "Bạn chọn số mấy, hoặc nói rõ hơn nhé!"
            ),
            (
                new[] { "tìm tổng", "tim tong", "xem tổng", "tính tổng", "tinh tong" },
                "Bạn muốn tính tổng của:\n" +
                "① Sản lượng (m³) theo ngày / tuần / tháng\n" +
                "② Số mẻ trộn\n③ Số phiếu giao hàng\n" +
                "④ Khối lượng theo khách hàng\n⑤ Vật liệu tiêu thụ (kg)\n\n" +
                "Bạn muốn tính tổng của cái nào?"
            ),
            (
                new[] { "kiểm tra vật liệu", "kiem tra vat lieu",
                        "xem vật liệu", "thông tin vật liệu", "tìm vật liệu" },
                "Bạn muốn xem thông tin vật liệu theo hướng nào?\n" +
                "① Tiêu thụ hôm nay / tuần / tháng\n" +
                "② Tồn kho silo hiện tại\n" +
                "③ Sai số thiết kế vs thực tế\n" +
                "④ Độ hút nước cốt liệu\n\nBạn muốn xem cái nào?"
            ),
            (
                new[] { "kiểm tra phiếu", "kiem tra phieu",
                        "xem phiếu", "thông tin phiếu", "tìm phiếu" },
                "Bạn muốn xem phiếu nào?\n" +
                "① Phiếu trộn hôm nay\n② Phiếu đang chờ xử lý\n" +
                "③ Phiếu của khách hàng cụ thể\n④ Phiếu theo mã số\n\nBạn muốn xem cái nào?"
            ),
            (
                new[] { "kiểm tra xe", "kiem tra xe", "xem xe", "thông tin xe", "tìm xe" },
                "Bạn muốn kiểm tra xe theo hướng nào?\n" +
                "① Xe chạy nhiều nhất hôm nay / tháng\n" +
                "② Danh sách xe đang hoạt động\n" +
                "③ Thông tin xe theo biển số cụ thể\n\nBạn muốn xem cái nào?"
            ),
            (
                new[] { "kiểm tra tài xế", "kiem tra tai xe",
                        "xem tài xế", "thông tin tài xế", "tìm tài xế" },
                "Bạn muốn xem thông tin tài xế theo hướng nào?\n" +
                "① Tài xế chạy nhiều nhất hôm nay\n" +
                "② Danh sách tài xế đang hoạt động\n" +
                "③ Thông tin theo tên cụ thể\n\nBạn muốn xem cái nào?"
            ),
            (
                new[] { "kiểm tra hợp đồng", "kiem tra hop dong",
                        "xem hợp đồng", "thông tin hợp đồng", "tìm hợp đồng" },
                "Bạn muốn xem hợp đồng theo hướng nào?\n" +
                "① Hợp đồng còn khối lượng chưa giao\n" +
                "② Hợp đồng của khách hàng cụ thể\n" +
                "③ Hợp đồng theo mã số\n\nBạn muốn xem cái nào?"
            ),
            (
                new[] { "kiểm tra sản lượng", "kiem tra san luong",
                        "xem sản lượng", "tìm sản lượng" },
                "Bạn muốn xem sản lượng trong khoảng thời gian nào?\n" +
                "① Hôm nay\n② Tuần này\n③ Tháng này\n" +
                "④ So sánh tháng này vs tháng trước\n⑤ 7 ngày gần nhất\n\nBạn chọn?"
            ),
            (
                new[] { "thông tin", "thong tin", "xem thông tin",
                        "cho tôi biết", "cho toi biet",
                        "kiểm tra", "kiem tra", "tìm kiếm", "tra cứu" },
                "Bạn muốn xem thông tin về:\n" +
                "① Sản lượng / mẻ trộn\n② Phiếu trộn / giao hàng\n" +
                "③ Khách hàng / hợp đồng\n④ Vật liệu / tồn kho silo\n" +
                "⑤ Xe / tài xế\n⑥ Cảnh báo / sự kiện\n\nBạn muốn xem mục nào?"
            ),
        };

        private string GetClarificationQuestion(string question)
        {
            var q = question.ToLower().Trim();
            var qNorm = RemoveDiacritics(q);

            int wordCount = q.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            if (wordCount > 8) return null;

            if (ContainsAny(qNorm, "hom nay", "tuan nay", "thang nay", "hom qua",
                                   "7 ngay", "30 ngay", "gan nhat", "moi nhat"))
                return null;

            if (Regex.IsMatch(question, @"\b[A-Z]{2,}\d+\b") ||
                Regex.IsMatch(question, @"\b\d{4,}\b"))
                return null;

            foreach (var (keywords, clarifyQ) in AMBIGUOUS_PATTERNS)
                foreach (var kw in keywords)
                    if (q.Contains(kw) || qNorm.Contains(RemoveDiacritics(kw)))
                        return clarifyQ;

            return null;
        }

        private bool ContainsAny(string text, params string[] keywords)
        {
            foreach (var kw in keywords)
                if (text.Contains(kw)) return true;
            return false;
        }

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

                // ── CLARIFICATION ─────────────────────────────
                if (intent == IntentDetector.Intent.CUSTOM_QUERY)
                {
                    string clarifyQ = GetClarificationQuestion(question);
                    if (clarifyQ != null)
                    {
                        result.Answer = clarifyQ;
                        result.IsSuccess = true;
                        result.NeedsClarification = true;
                        AddToHistory(question, clarifyQ, null, null);
                        return result;
                    }
                }

                // ── STEP 3: Lấy SQL ───────────────────────────
                string sql = null;

                if (IntentDetector.HasTemplate(intent))
                {
                    sql = QueryFunctions.GetTemplate(IntentDetector.GetTemplateName(intent));
                    OnStatusChanged?.Invoke("⚡ Dùng template SQL...");
                }
                else
                {
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

                // ── SmartRetryEngine: tự động thử bảng liên quan nếu rỗng ──
                OnStatusChanged?.Invoke("🔍 Đang truy vấn dữ liệu...");
                var smartResult = await _retry.ExecuteWithRetry(sql, question);

                result.SqlUsed = smartResult.SqlUsed ?? sql;
                string dbData = smartResult.Data;

                if (smartResult.UsedFallback)
                    OnStatusChanged?.Invoke($"✅ Tìm thấy sau {smartResult.Attempts} lần thử");

                // ── STEP 5: Response Generation ───────────────
                OnStatusChanged?.Invoke("💬 Đang tổng hợp kết quả...");

                if (!string.IsNullOrEmpty(dbData) && dbData.Length > 2000)
                    dbData = dbData.Substring(0, 2000) + "\n...(đã rút gọn)";

                string answer = await GenerateNaturalResponse(question, dbData, intent);

                result.Answer = answer;
                result.RawData = dbData;
                result.IsSuccess = true;
                AddToHistory(question, answer, result.SqlUsed, dbData);
            }
            catch (Exception ex)
            {
                result.Answer = $"Xin lỗi, có lỗi xảy ra: {ex.Message}";
                result.IsSuccess = false;
            }

            return result;
        }

        // ══════════════════════════════════════════════════════
        //  STEP 3: AI SQL GENERATION — dùng schema 100% từ script.sql
        // ══════════════════════════════════════════════════════
        private async Task<string> GenerateSqlWithAI(string question)
        {
            string context = BuildContextPrompt();

            string fullPrompt =
                SchemaContext.ALL_TABLES + "\n" +
                SchemaContext.FK_COMPLETE + "\n" +
                SchemaContext.ALL_VIEWS + "\n" +
                SchemaContext.JOIN_PATHS + "\n" +
                SemanticLayer.NATURAL_TO_TECHNICAL + "\n" +
                DatabaseSchema.BUSINESS_RULES;

            string userMsg =
                (string.IsNullOrEmpty(context) ? "" : context + "\n") +
                $"Câu hỏi: {question}\n" +
                $"KHÔNG dùng @tham số. KHÔNG thêm IsDeleted=0.\n" +
                $"LUÔN dùng JOIN...ON theo FK, KHÔNG dùng IN(subquery).\n" +
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
            if (intent == IntentDetector.Intent.SAN_LUONG_HOM_NAY ||
                intent == IntentDetector.Intent.SAN_LUONG_TUAN_NAY ||
                intent == IntentDetector.Intent.SAN_LUONG_THANG_NAY)
                return "Trả lời trong 1-2 câu. Nêu rõ số mẻ và tổng m³.";

            if (intent == IntentDetector.Intent.SO_SANH_THANG)
                return "Trả lời trong 2-3 câu. So sánh và nêu xu hướng tăng/giảm bao nhiêu %.";

            if (intent == IntentDetector.Intent.DANH_SACH_ME_HOM_NAY ||
                intent == IntentDetector.Intent.PHIEU_HOM_NAY ||
                intent == IntentDetector.Intent.PHIEU_THANG_NAY)
                return "Tóm tắt tổng số trước, sau đó nêu vài mục nổi bật. Không liệt kê quá 5 mục.";

            if (intent == IntentDetector.Intent.TOP_KHACH_HANG ||
                intent == IntentDetector.Intent.TOP_CONG_TRUONG ||
                intent == IntentDetector.Intent.XE_NHIEU_NHAT ||
                intent == IntentDetector.Intent.TAI_XE_NHIEU_NHAT)
                return "Nêu top 3-5 theo thứ tự, mỗi mục 1 câu ngắn với số liệu cụ thể.";

            if (intent == IntentDetector.Intent.TON_KHO_SILO)
                return "Liệt kê từng silo với tên vật liệu và khối lượng hiện tại (kg).";

            return "Trả lời ngắn gọn, dùng số liệu cụ thể.";
        }

        // ══════════════════════════════════════════════════════
        //  CONVERSATION HISTORY
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
            var nums = Regex.Matches(answer,
                @"\b(\d+(?:[.,]\d+)?)\s*(m³|m3|kg|tấn|chuyến|mẻ|phiếu)\b",
                RegexOptions.IgnoreCase);
            foreach (Match m in nums) sb.Append($"{m.Value} ");
            return sb.Length > 0 ? sb.ToString().Trim() : null;
        }

        // ── Helpers ──────────────────────────────────────────
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
        public bool NeedsClarification { get; set; }
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
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NDPSo.Chatbot
{
    /// <summary>
    /// SMART RETRY ENGINE
    /// Khi query trả về không có dữ liệu → tự động thử các bảng/view liên quan
    /// Không vội kết luận "không có dữ liệu" sau 1 lần thử
    /// </summary>
    public class SmartRetryEngine
    {
        private readonly OpenAIApiService _ai;
        private readonly DatabaseService _db;

        public event Action<string> OnStatusChanged;

        public SmartRetryEngine(OpenAIApiService ai, DatabaseService db)
        {
            _ai = ai;
            _db = db;
        }

        // ══════════════════════════════════════════════════════
        //  FALLBACK CHAINS — bảng thay thế khi không có kết quả
        // ══════════════════════════════════════════════════════

        /// <summary>
        /// Map: từ khóa trong câu hỏi → danh sách SQL fallback theo thứ tự ưu tiên
        /// Khi SQL gốc trả về rỗng → thử lần lượt các fallback
        /// </summary>
        private static readonly Dictionary<string[], List<string>> FALLBACK_CHAINS
            = new Dictionary<string[], List<string>>
        {
            // MAC / máy trộn
            {
                new[] { "mac", "máy trộn", "may tron", "mamin", "maytron" },
                new List<string> {
                    // Thử 1: dùng vw_Infos (đã JOIN sẵn)
                    @"SELECT MAC, NoteMAC AS TenMAC, MAC_int AS MACID,
                        COUNT(MeTronID) AS SoMe, SUM(KLMe) AS TongKL_m3
                      FROM dbo.vw_Infos
                      WHERE {TIME_FILTER_INFOS}
                      GROUP BY MAC, NoteMAC, MAC_int
                      ORDER BY SoMe DESC",
                    // Thử 2: PhieuTron → MAC trực tiếp
                    @"SELECT m.MACID, m.MaMAC, m.TenMAC,
                        COUNT(pt.PhieuTronID) AS SoPhieu,
                        SUM(pt.KLDuTinh) AS TongKLDuTinh_m3
                      FROM dbo.PhieuTron pt
                      JOIN dbo.MAC m ON pt.MACID = m.MACID
                      WHERE {TIME_FILTER_PT}
                      GROUP BY m.MACID, m.MaMAC, m.TenMAC
                      ORDER BY SoPhieu DESC",
                    // Thử 3: HopDong → MAC
                    @"SELECT m.MACID, m.MaMAC, m.TenMAC,
                        COUNT(hd.HopDongID) AS SoHopDong,
                        SUM(hd.KLDaGiao) AS TongKLDaGiao_m3
                      FROM dbo.HopDong hd
                      JOIN dbo.MAC m ON hd.MACID = m.MACID
                      WHERE hd.Status = 1
                      GROUP BY m.MACID, m.MaMAC, m.TenMAC
                      ORDER BY TongKLDaGiao_m3 DESC"
                }
            },
            // Sản lượng / mẻ trộn
            {
                new[] { "sản lượng", "san luong", "mẻ trộn", "me tron", "khối lượng", "khoi luong" },
                new List<string> {
                    // Thử 1: vw_Infos
                    @"SELECT COUNT(MeTronID) AS SoMe, SUM(KLMe) AS TongKL_m3
                      FROM dbo.vw_Infos
                      WHERE {TIME_FILTER_INFOS}",
                    // Thử 2: MeTron trực tiếp
                    @"SELECT COUNT(*) AS SoMe, SUM(KhoiLuong) AS TongKL_m3
                      FROM dbo.MeTron
                      WHERE {TIME_FILTER_MT}",
                    // Thử 3: theo ngày gần nhất có dữ liệu
                    @"SELECT CAST(NgayMeTron AS DATE) AS Ngay,
                        COUNT(*) AS SoMe, SUM(KhoiLuong) AS TongKL_m3
                      FROM dbo.MeTron
                      GROUP BY CAST(NgayMeTron AS DATE)
                      ORDER BY Ngay DESC"
                }
            },
            // Vật liệu / nguyên liệu
            {
                new[] { "vật liệu", "vat lieu", "xi măng", "xi mang", "cát", "cat ", "đá ", "nước", "nuoc", "phu gia" },
                new List<string> {
                    // Thử 1: vw_PvMaterialDetailDay hôm nay
                    @"SELECT MaterialCode, MaterialName,
                        SUM(Sum_ValueCP) AS TongKL_ThietKe_kg,
                        SUM(Sum_ValueBat) AS TongKL_ThucTe_kg
                      FROM dbo.vw_PvMaterialDetailDay
                      WHERE {TIME_FILTER_MAT}
                      GROUP BY MaterialCode, MaterialName
                      ORDER BY TongKL_ThucTe_kg DESC",
                    // Thử 2: vw_PvTotalMaterial (tất cả thời gian)
                    @"SELECT TOP 20 MaterialCode, MaterialName,
                        Sum_ValueCP AS TongThietKe_kg, Sum_ValueBat AS TongThucTe_kg,
                        SaiSo, PerSaiSo
                      FROM dbo.vw_PvTotalMaterial
                      ORDER BY Sum_ValueBat DESC",
                    // Thử 3: MeTronChiTiet trực tiếp
                    @"SELECT TOP 20 MaterialCode, MaterialName, MaSilo,
                        SUM(Value) AS TongThietKe_kg, SUM(ValueBat) AS TongThucTe_kg
                      FROM dbo.MeTronChiTiet
                      WHERE {TIME_FILTER_MCT}
                      GROUP BY MaterialCode, MaterialName, MaSilo
                      ORDER BY TongThucTe_kg DESC"
                }
            },
            // Khách hàng
            {
                new[] { "khách hàng", "khach hang", "khachhang" },
                new List<string> {
                    // Thử 1: từ vw_Infos
                    @"SELECT KH AS TenKhachHang, KH_int AS KhachHangID,
                        COUNT(MeTronID) AS SoMe, SUM(KLMe) AS TongKL_m3
                      FROM dbo.vw_Infos
                      WHERE {TIME_FILTER_INFOS}
                      GROUP BY KH, KH_int ORDER BY TongKL_m3 DESC",
                    // Thử 2: từ PhieuTron
                    @"SELECT kh.TenKhachHang, COUNT(pt.PhieuTronID) AS SoPhieu,
                        SUM(pt.KLThuc) AS TongKLThuc_m3
                      FROM dbo.PhieuTron pt
                      JOIN dbo.KhachHang kh ON pt.KhachHangID=kh.KhachHangID
                      WHERE {TIME_FILTER_PT}
                      GROUP BY kh.KhachHangID, kh.TenKhachHang
                      ORDER BY TongKLThuc_m3 DESC",
                    // Thử 3: danh sách khách hàng đang hoạt động
                    @"SELECT TOP 20 KhachHangID, MaKhachHang, TenKhachHang, Phone, DiaChi
                      FROM dbo.KhachHang WHERE Activated=1
                      ORDER BY TenKhachHang"
                }
            },
            // Phiếu / giao hàng
            {
                new[] { "phiếu", "phieu", "giao hàng", "giao hang" },
                new List<string> {
                    // Thử 1: vw_InfoPT hôm nay
                    @"SELECT TOP 50 MaPhieuTron, NgayPhieuTron, KH, CT, MAC,
                        KLDuTinh, KLThuc, BS, TX
                      FROM dbo.vw_InfoPT
                      WHERE {TIME_FILTER_INFOPT}
                      ORDER BY NgayPhieuTron DESC",
                    // Thử 2: PhieuGiaoHang (có nhiều thông tin hơn)
                    @"SELECT TOP 50 MaPhieuTron, NgayPhieuTron,
                        TenKhachHang, TenCongTruong, TenMAC,
                        KLDuTinh, KLThuc, BienSo, TenTaiXe,
                        GioBD, GioKT
                      FROM dbo.PhieuGiaoHang
                      WHERE {TIME_FILTER_PGH}
                        AND Activated=1
                      ORDER BY NgayPhieuTron DESC",
                    // Thử 3: PhieuTron
                    @"SELECT TOP 50 pt.MaPhieuTron, pt.NgayPhieuTron,
                        kh.TenKhachHang, ct.TenCongTruong, m.TenMAC,
                        pt.KLDuTinh, pt.KLThuc, xe.BienSo
                      FROM dbo.PhieuTron pt
                      LEFT JOIN dbo.KhachHang kh ON pt.KhachHangID=kh.KhachHangID
                      LEFT JOIN dbo.CongTruong ct ON pt.CongTruongID=ct.CongTruongID
                      LEFT JOIN dbo.MAC m ON pt.MACID=m.MACID
                      LEFT JOIN dbo.Xe xe ON pt.XeID=xe.XeID
                      WHERE {TIME_FILTER_PT}
                      ORDER BY pt.NgayPhieuTron DESC"
                }
            },
            // Xe / tài xế
            {
                new[] { "xe ", "biển số", "bien so", "tài xế", "tai xe", "lái xe", "lai xe" },
                new List<string> {
                    @"SELECT BienSo, Total_Tranfer, Total_KL, NgayMeTron
                      FROM dbo.vw_PvTranferDetailDay
                      WHERE NgayMeTron = CAST(GETDATE() AS DATE)
                      ORDER BY Total_KL DESC",
                    @"SELECT XeID, BienSo, Total_Tranfer, Total_KL
                      FROM dbo.vw_PvTotalTranfer
                      ORDER BY Total_KL DESC",
                    @"SELECT TenTaiXe, Total_Tranfer, Total_KL
                      FROM dbo.vw_PvDriverDetailDay
                      WHERE NgayMeTron = CAST(GETDATE() AS DATE)
                      ORDER BY Total_KL DESC"
                }
            },
        };

        // ══════════════════════════════════════════════════════
        //  TIME FILTER TEMPLATES
        // ══════════════════════════════════════════════════════
        private static string ApplyTimeFilter(string sql, string question)
        {
            var q = RemoveDiacritics(question.ToLower());

            string filterMt, filterPt, filterMat, filterMct, filterInfos, filterInfoPt, filterPgh;

            if (q.Contains("hom nay") || q.Contains("today"))
            {
                filterMt = "CAST(mt.NgayMeTron AS DATE)=CAST(GETDATE() AS DATE)";
                filterPt = "CAST(pt.NgayPhieuTron AS DATE)=CAST(GETDATE() AS DATE)";
                filterMat = "CAST(NgayMeTron AS DATE)=CAST(GETDATE() AS DATE)";
                filterMct = "CAST(mct.NgayMTCT AS DATE)=CAST(GETDATE() AS DATE)";
                filterInfos = "CAST(NgayMeTron AS DATE)=CAST(GETDATE() AS DATE)";
                filterInfoPt = "CAST(NgayPhieuTron AS DATE)=CAST(GETDATE() AS DATE)";
                filterPgh = "CAST(NgayPhieuTron AS DATE)=CAST(GETDATE() AS DATE)";
            }
            else if (q.Contains("thang nay") || q.Contains("month"))
            {
                filterMt = "MONTH(mt.NgayMeTron)=MONTH(GETDATE()) AND YEAR(mt.NgayMeTron)=YEAR(GETDATE())";
                filterPt = "MONTH(pt.NgayPhieuTron)=MONTH(GETDATE()) AND YEAR(pt.NgayPhieuTron)=YEAR(GETDATE())";
                filterMat = "MONTH(NgayMeTron)=MONTH(GETDATE()) AND YEAR(NgayMeTron)=YEAR(GETDATE())";
                filterMct = "MONTH(mct.NgayMTCT)=MONTH(GETDATE()) AND YEAR(mct.NgayMTCT)=YEAR(GETDATE())";
                filterInfos = "MONTH(NgayMeTron)=MONTH(GETDATE()) AND YEAR(NgayMeTron)=YEAR(GETDATE())";
                filterInfoPt = "MONTH(NgayPhieuTron)=MONTH(GETDATE()) AND YEAR(NgayPhieuTron)=YEAR(GETDATE())";
                filterPgh = "MONTH(NgayPhieuTron)=MONTH(GETDATE()) AND YEAR(NgayPhieuTron)=YEAR(GETDATE())";
            }
            else if (q.Contains("tuan nay") || q.Contains("week"))
            {
                filterMt = "DATEPART(week,mt.NgayMeTron)=DATEPART(week,GETDATE()) AND YEAR(mt.NgayMeTron)=YEAR(GETDATE())";
                filterPt = "DATEPART(week,pt.NgayPhieuTron)=DATEPART(week,GETDATE()) AND YEAR(pt.NgayPhieuTron)=YEAR(GETDATE())";
                filterMat = "DATEPART(week,NgayMeTron)=DATEPART(week,GETDATE()) AND YEAR(NgayMeTron)=YEAR(GETDATE())";
                filterMct = "DATEPART(week,mct.NgayMTCT)=DATEPART(week,GETDATE()) AND YEAR(mct.NgayMTCT)=YEAR(GETDATE())";
                filterInfos = "DATEPART(week,NgayMeTron)=DATEPART(week,GETDATE()) AND YEAR(NgayMeTron)=YEAR(GETDATE())";
                filterInfoPt = "DATEPART(week,NgayPhieuTron)=DATEPART(week,GETDATE()) AND YEAR(NgayPhieuTron)=YEAR(GETDATE())";
                filterPgh = "DATEPART(week,NgayPhieuTron)=DATEPART(week,GETDATE()) AND YEAR(NgayPhieuTron)=YEAR(GETDATE())";
            }
            else
            {
                // Không có filter thời gian → lấy 30 ngày gần nhất
                filterMt = "mt.NgayMeTron >= DATEADD(day,-30,GETDATE())";
                filterPt = "pt.NgayPhieuTron >= DATEADD(day,-30,GETDATE())";
                filterMat = "NgayMeTron >= DATEADD(day,-30,GETDATE())";
                filterMct = "mct.NgayMTCT >= DATEADD(day,-30,GETDATE())";
                filterInfos = "NgayMeTron >= DATEADD(day,-30,GETDATE())";
                filterInfoPt = "NgayPhieuTron >= DATEADD(day,-30,GETDATE())";
                filterPgh = "NgayPhieuTron >= DATEADD(day,-30,GETDATE())";
            }

            return sql
                .Replace("{TIME_FILTER_MT}", filterMt)
                .Replace("{TIME_FILTER_PT}", filterPt)
                .Replace("{TIME_FILTER_MAT}", filterMat)
                .Replace("{TIME_FILTER_MCT}", filterMct)
                .Replace("{TIME_FILTER_INFOS}", filterInfos)
                .Replace("{TIME_FILTER_INFOPT}", filterInfoPt)
                .Replace("{TIME_FILTER_PGH}", filterPgh);
        }

        // ══════════════════════════════════════════════════════
        //  MAIN: EXECUTE WITH SMART RETRY
        // ══════════════════════════════════════════════════════

        /// <summary>
        /// Thực thi SQL. Nếu kết quả rỗng → tự động thử các bảng liên quan.
        /// Không kết luận "không có dữ liệu" cho đến khi thử hết fallback.
        /// </summary>
        public async Task<SmartResult> ExecuteWithRetry(
            string originalSql, string question, int maxFallbacks = 3)
        {
            var result = new SmartResult();

            // ── Thử 1: SQL gốc ──────────────────────────────
            try
            {
                OnStatusChanged?.Invoke("🔍 Truy vấn lần 1...");
                string data = _db.ExecuteQuery(originalSql);

                if (!IsEmpty(data))
                {
                    result.Data = data;
                    result.SqlUsed = originalSql;
                    result.Attempts = 1;
                    result.IsSuccess = true;
                    return result;
                }

                OnStatusChanged?.Invoke("⚠️ Lần 1 rỗng, thử bảng liên quan...");
            }
            catch (Exception ex)
            {
                // Lỗi SQL → thử fallback
                OnStatusChanged?.Invoke($"⚠️ Lỗi SQL: {ex.Message.Substring(0, Math.Min(50, ex.Message.Length))}...");
            }

            // ── Thử 2+: Fallback chains ──────────────────────
            var chains = GetFallbackChains(question);
            int attempt = 2;

            foreach (var fallbackSql in chains)
            {
                if (attempt > maxFallbacks + 1) break;

                try
                {
                    string sql = ApplyTimeFilter(fallbackSql, question);
                    OnStatusChanged?.Invoke($"🔄 Thử bảng liên quan (lần {attempt})...");

                    string data = _db.ExecuteQuery(sql);

                    if (!IsEmpty(data))
                    {
                        result.Data = data;
                        result.SqlUsed = sql;
                        result.Attempts = attempt;
                        result.IsSuccess = true;
                        result.UsedFallback = true;
                        return result;
                    }
                }
                catch { /* tiếp tục thử */ }

                attempt++;
            }

            // ── Thử cuối: AI sinh SQL mới với gợi ý bảng rõ hơn ──
            if (attempt <= maxFallbacks + 2)
            {
                try
                {
                    OnStatusChanged?.Invoke("🤖 AI thử cách truy vấn khác...");
                    string aiSql = await RegenerateWithHint(question, originalSql);
                    if (!string.IsNullOrEmpty(aiSql))
                    {
                        string data = _db.ExecuteQuery(aiSql);
                        if (!IsEmpty(data))
                        {
                            result.Data = data;
                            result.SqlUsed = aiSql;
                            result.Attempts = attempt;
                            result.IsSuccess = true;
                            result.UsedFallback = true;
                            return result;
                        }
                    }
                }
                catch { }
            }

            // Thật sự không có dữ liệu
            result.IsSuccess = false;
            result.Attempts = attempt;
            result.Data = "Không có dữ liệu";
            return result;
        }

        // ── Tìm fallback chain phù hợp với câu hỏi ──────────
        private List<string> GetFallbackChains(string question)
        {
            var q = question.ToLower();
            var qNorm = RemoveDiacritics(q);
            var result = new List<string>();

            foreach (var kvp in FALLBACK_CHAINS)
            {
                foreach (var kw in kvp.Key)
                {
                    if (q.Contains(kw) || qNorm.Contains(RemoveDiacritics(kw)))
                    {
                        result.AddRange(kvp.Value);
                        break;
                    }
                }
            }

            return result;
        }

        // ── AI sinh lại SQL với gợi ý rõ hơn ────────────────
        private async Task<string> RegenerateWithHint(string question, string failedSql)
        {
            string hint =
                $"SQL này trả về rỗng:\n{failedSql}\n\n" +
                $"Hãy thử cách khác. Gợi ý:\n" +
                $"- MeTron không có MACID — phải qua PhieuTron\n" +
                $"- Dùng vw_Infos nếu cần thông tin mẻ trộn đầy đủ\n" +
                $"- Dùng vw_InfoPT nếu cần thông tin phiếu trộn\n" +
                $"- Bỏ filter thời gian nếu không chắc có dữ liệu\n" +
                $"- Thử JOIN thêm bảng liên quan\n\n" +
                $"Câu hỏi: {question}\n" +
                $"Trả về SQL mới: SQL: <câu sql>";

            string schema = SchemaContext.ALL_TABLES + "\n" + SchemaContext.JOIN_PATHS;
            string response = await _ai.ChatAsync(schema, hint);

            var m = Regex.Match(response, @"SQL:\s*(SELECT[\s\S]+?)(?:\n\n|;\s*\n|\z)", RegexOptions.IgnoreCase);
            if (m.Success) return m.Groups[1].Value.Trim();

            var cb = Regex.Match(response, @"```(?:sql)?\s*(SELECT[\s\S]+?)```", RegexOptions.IgnoreCase);
            if (cb.Success) return cb.Groups[1].Value.Trim();

            return null;
        }

        // ── Helpers ──────────────────────────────────────────
        private bool IsEmpty(string data)
        {
            if (string.IsNullOrWhiteSpace(data)) return true;
            if (data == "Không có dữ liệu") return true;
            // Check nếu chỉ có header mà không có dòng data
            if (data.Contains("-- Tổng: 0 dòng")) return true;
            return false;
        }

        private static string RemoveDiacritics(string text)
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
    }

    public class SmartResult
    {
        public string Data { get; set; }
        public string SqlUsed { get; set; }
        public int Attempts { get; set; }
        public bool IsSuccess { get; set; }
        public bool UsedFallback { get; set; }
    }
}
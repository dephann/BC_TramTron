using System.Collections.Generic;

namespace NDPSo.Chatbot
{
    /// <summary>
    /// STEP 4 — Intent Detection
    /// Phân loại câu hỏi → intent cụ thể → chọn SQL template hoặc schema phù hợp
    /// Ưu tiên: Template cố định > SchemaSelector > AI tự sinh
    /// </summary>
    public static class IntentDetector
    {
        // ═══════════════════════════════════════════════════════
        //  INTENT CATEGORIES
        // ═══════════════════════════════════════════════════════
        public enum Intent
        {
            // Sản lượng / mẻ trộn
            SAN_LUONG_HOM_NAY,
            SAN_LUONG_TUAN_NAY,
            SAN_LUONG_THANG_NAY,
            SAN_LUONG_7_NGAY,
            DANH_SACH_ME_HOM_NAY,
            ME_GAN_NHAT,
            SO_SANH_THANG,

            // Phiếu trộn
            PHIEU_HOM_NAY,
            PHIEU_THANG_NAY,
            PHIEU_DANG_CHO,

            // Khách hàng / hợp đồng
            TOP_KHACH_HANG,
            HOP_DONG_CON_LAI,
            TOP_CONG_TRUONG,

            // Vật liệu / silo
            TON_KHO_SILO,
            TIEU_THU_VAT_LIEU_HOM_NAY,
            TIEU_THU_VAT_LIEU_TONG,
            DO_HUT_NUOC,

            // Xe / tài xế
            XE_HOM_NAY,
            XE_NHIEU_NHAT,
            TAI_XE_HOM_NAY,
            TAI_XE_NHIEU_NHAT,

            // Sự kiện / log
            CANH_BAO_HOM_NAY,
            DANG_NHAP_HOM_NAY,

            // Không cần DB
            CHITCHAT,
            HELP,

            // Cần AI sinh SQL tự do
            CUSTOM_QUERY
        }

        // ═══════════════════════════════════════════════════════
        //  DETECT INTENT
        // ═══════════════════════════════════════════════════════
        public static Intent Detect(string question)
        {
            var q = question.ToLower().Trim();
            var qNorm = RemoveDiacritics(q);

            // ── CHITCHAT / HELP (không cần DB) ───────────────
            if (IsChitchat(qNorm)) return Intent.CHITCHAT;
            if (IsHelp(qNorm)) return Intent.HELP;

            // ── SẢN LƯỢNG / MẺ TRỘN ──────────────────────────
            if (Match(qNorm, "san luong hom nay", "tron hom nay", "bao nhieu m3 hom nay",
                             "may me hom nay", "so me hom nay", "tong kl hom nay"))
                return Intent.SAN_LUONG_HOM_NAY;

            if (Match(qNorm, "san luong tuan nay", "tuan nay tron", "tuan nay san luong"))
                return Intent.SAN_LUONG_TUAN_NAY;

            if (Match(qNorm, "san luong thang nay", "thang nay tron", "thang nay san luong",
                             "san luong thang", "tong thang nay"))
                return Intent.SAN_LUONG_THANG_NAY;

            if (Match(qNorm, "7 ngay", "bay ngay", "tuan qua", "gan day"))
                return Intent.SAN_LUONG_7_NGAY;

            if (Match(qNorm, "danh sach me hom nay", "me tron hom nay", "cac me hom nay",
                             "liet ke me hom nay", "me tron ngay hom nay"))
                return Intent.DANH_SACH_ME_HOM_NAY;

            if (Match(qNorm, "me gan nhat", "lan tron cuoi", "tron cuoi cung",
                             "me tron moi nhat", "me moi nhat", "lan cuoi"))
                return Intent.ME_GAN_NHAT;

            if (Match(qNorm, "so sanh thang", "thang nay voi thang truoc", "tang hay giam",
                             "thang truoc", "bien dong san luong"))
                return Intent.SO_SANH_THANG;

            // ── PHIẾU TRỘN ───────────────────────────────────
            if (Match(qNorm, "phieu hom nay", "phieu tron hom nay", "giao hang hom nay",
                             "phieu giao hom nay", "xuat hang hom nay"))
                return Intent.PHIEU_HOM_NAY;

            if (Match(qNorm, "phieu thang nay", "phieu tron thang", "giao hang thang nay"))
                return Intent.PHIEU_THANG_NAY;

            if (Match(qNorm, "phieu dang cho", "hang cho", "chua tron", "phieu chua xong",
                             "dang cho tron", "isqueued"))
                return Intent.PHIEU_DANG_CHO;

            // ── KHÁCH HÀNG / HỢP ĐỒNG ───────────────────────
            if (Match(qNorm, "top khach hang", "khach hang nhieu nhat", "khach hang dat nhieu",
                             "khach hang lon nhat", "khach hang thu nhat"))
                return Intent.TOP_KHACH_HANG;

            if (Match(qNorm, "hop dong con lai", "kl con lai", "con bao nhieu de giao",
                             "chua giao het", "du con lai", "con lai hop dong"))
                return Intent.HOP_DONG_CON_LAI;

            if (Match(qNorm, "top cong truong", "cong truong nhieu nhat", "cong trinh lon nhat",
                             "cong truong nhan nhieu"))
                return Intent.TOP_CONG_TRUONG;

            // ── VẬT LIỆU / SILO ──────────────────────────────
            if (Match(qNorm, "ton kho silo", "ton kho hien tai", "silo hien tai",
                             "luong trong silo", "con bao nhieu trong silo", "muc silo"))
                return Intent.TON_KHO_SILO;

            if (Match(qNorm, "tieu thu vat lieu hom nay", "vat lieu hom nay",
                             "xi mang hom nay", "cat hom nay", "da hom nay",
                             "nuoc hom nay", "phu gia hom nay"))
                return Intent.TIEU_THU_VAT_LIEU_HOM_NAY;

            if (Match(qNorm, "tong tieu thu vat lieu", "vat lieu nhieu nhat",
                             "sai so vat lieu", "tieu thu tong cong"))
                return Intent.TIEU_THU_VAT_LIEU_TONG;

            if (Match(qNorm, "do hut nuoc", "ham luong nuoc", "moisture", "do am cot lieu"))
                return Intent.DO_HUT_NUOC;

            // ── XE / TÀI XẾ ──────────────────────────────────
            if (Match(qNorm, "xe hom nay", "xe nao chay hom nay", "bien so hom nay",
                             "chuyen xe hom nay"))
                return Intent.XE_HOM_NAY;

            if (Match(qNorm, "xe chay nhieu nhat", "xe cho nhieu nhat", "bien so nhieu nhat",
                             "xe lon nhat", "top xe"))
                return Intent.XE_NHIEU_NHAT;

            if (Match(qNorm, "tai xe hom nay", "lai xe hom nay", "nguoi lai hom nay",
                             "chuyen tai xe hom nay"))
                return Intent.TAI_XE_HOM_NAY;

            if (Match(qNorm, "tai xe nhieu nhat", "tai xe gioi nhat", "lai xe nhieu chuyen",
                             "top tai xe", "tai xe chay nhieu"))
                return Intent.TAI_XE_NHIEU_NHAT;

            // ── SỰ KIỆN / LOG ────────────────────────────────
            if (Match(qNorm, "canh bao hom nay", "loi hom nay", "su kien hom nay",
                             "event hom nay", "alarm hom nay", "co gi bat thuong"))
                return Intent.CANH_BAO_HOM_NAY;

            if (Match(qNorm, "ai dang nhap", "dang nhap hom nay", "lich su dang nhap",
                             "nguoi dung hom nay", "log in hom nay"))
                return Intent.DANG_NHAP_HOM_NAY;

            // ── Không match → AI tự sinh SQL ─────────────────
            return Intent.CUSTOM_QUERY;
        }

        // ═══════════════════════════════════════════════════════
        //  INTENT METADATA
        // ═══════════════════════════════════════════════════════

        /// <summary>Intent có template SQL sẵn → chạy thẳng, không cần gọi AI sinh SQL</summary>
        public static bool HasTemplate(Intent intent)
        {
            return intent != Intent.CHITCHAT
                && intent != Intent.HELP
                && intent != Intent.CUSTOM_QUERY;
        }

        /// <summary>Không cần truy vấn DB</summary>
        public static bool IsNonDbIntent(Intent intent)
        {
            return intent == Intent.CHITCHAT || intent == Intent.HELP;
        }

        /// <summary>Câu trả lời sẵn cho CHITCHAT và HELP</summary>
        public static string GetDirectAnswer(Intent intent)
        {
            if (intent == Intent.CHITCHAT)
                return "Xin chào! Mình là trợ lý AI của trạm trộn. Bạn có thể hỏi mình về sản lượng, phiếu trộn, tồn kho, xe, tài xế, hay bất cứ thông tin nào trong hệ thống nhé!";

            if (intent == Intent.HELP)
                return "Mình có thể giúp bạn:\n" +
                       "• Sản lượng hôm nay / tuần / tháng\n" +
                       "• Danh sách mẻ trộn, phiếu giao hàng\n" +
                       "• Tồn kho silo, tiêu thụ vật liệu\n" +
                       "• Thống kê xe, tài xế\n" +
                       "• Khách hàng, hợp đồng còn lại\n" +
                       "• Cảnh báo, sự kiện hệ thống\n\n" +
                       "Cứ hỏi tự nhiên, mình hiểu tiếng Việt nhé!";

            return null;
        }

        /// <summary>Map intent → tên template trong QueryFunctions</summary>
        public static string GetTemplateName(Intent intent) => intent.ToString();

        // ═══════════════════════════════════════════════════════
        //  HELPERS
        // ═══════════════════════════════════════════════════════
        private static bool Match(string text, params string[] keywords)
        {
            foreach (var kw in keywords)
                if (text.Contains(kw)) return true;
            return false;
        }

        private static bool IsChitchat(string q)
        {
            return Match(q,
                "xin chao", "chao ban", "hello", "hi ", "hey",
                "ban la ai", "ban ten gi", "ban co the lam gi khong",
                "cam on", "thank", "ok ban", "duoc roi",
                "ban gioi qua", "hay qua", "tuyet voi");
        }

        private static bool IsHelp(string q)
        {
            return Match(q,
                "ban co the lam gi", "lam duoc gi", "ho tro gi",
                "tinh nang gi", "giup gi duoc", "menu", "huong dan",
                "co the hoi gi", "hoi gi vay", "help");
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
}
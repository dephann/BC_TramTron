using System.Drawing;

namespace NDPSo.Utils
{
    /// <summary>
    /// Quy tắc tô màu dùng chung cho cả màn hình VanHanh và OptimizeSchedule.
    /// CR (Critical Ratio) = (giờ giao - hiện tại) / thời gian sản xuất ước tính.
    ///   CR &lt; 1.0  → TRỄ      (đỏ)
    ///   1.0–1.5   → SẮP TRỄ  (vàng)
    ///   &gt; 1.5    → ĐÚNG HẠN (xanh nhạt)
    /// </summary>
    public static class ScheduleColorHelper
    {
        // ── Màu nền ───────────────────────────────────────────────────
        public static readonly Color ColorRunning    = Color.FromArgb(180, 255, 180); // xanh lá: đang chạy
        public static readonly Color ColorDone       = Color.FromArgb(210, 210, 210); // xám: đã xong
        public static readonly Color ColorLate       = Color.FromArgb(255, 100, 100); // đỏ: TRỄ
        public static readonly Color ColorSoonLate   = Color.FromArgb(255, 230, 80);  // vàng: SẮP TRỄ
        public static readonly Color ColorOnTime     = Color.FromArgb(200, 240, 200); // xanh nhạt: ĐÚNG HẠN
        public static readonly Color ColorSwitch     = Color.FromArgb(255, 230, 180); // cam nhạt: vệ sinh máy
        public static readonly Color ColorCancelled  = Color.FromArgb(255, 180, 180); // hồng nhạt: đã hủy

        // ── Màu chữ ───────────────────────────────────────────────────
        public static readonly Color ForeRunning     = Color.FromArgb(0, 110, 0);
        public static readonly Color ForeDone        = Color.FromArgb(120, 120, 120);
        public static readonly Color ForeCancelled   = Color.FromArgb(140, 0, 0);
        public static readonly Color ForeLate        = Color.White;
        public static readonly Color ForeSoonLate    = Color.FromArgb(80, 60, 0);
        public static readonly Color ForeOnTime      = Color.FromArgb(0, 80, 0);

        /// <summary>Màu nền theo CR value (dùng khi không có thông tin chạy thực tế).</summary>
        public static Color BackColorByCR(double? cr)
        {
            if (cr == null) return Color.Empty;
            if (cr < 1.0)  return ColorLate;
            if (cr < 1.5)  return ColorSoonLate;
            return ColorOnTime;
        }

        /// <summary>Màu chữ theo CR value.</summary>
        public static Color ForeColorByCR(double? cr)
        {
            if (cr == null) return Color.Empty;
            if (cr < 1.0)  return ForeLate;
            if (cr < 1.5)  return ForeSoonLate;
            return ForeOnTime;
        }
    }
}

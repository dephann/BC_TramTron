using System;

namespace NDPSo.Data
{
    public class ObjScheduleItem
    {
        public ObjDuLieuTron DuLieuTron { get; set; }
        public int ScheduleOrder { get; set; }
        public DateTime EstimatedStartTime { get; set; }
        public DateTime EstimatedEndTime { get; set; }
        public int EstimatedDurationMinutes { get; set; }
        public bool HasSwitchBefore { get; set; }
        public int SwitchCostMinutes { get; set; }

        // Shortcut display properties
        public string MaHopDong => DuLieuTron?.MaHopDong;
        public string TenKhachHang => DuLieuTron?.NPKhachHangTenKhachHang;
        public string TenHangMuc => DuLieuTron?.DoSut;
        public string TenMAC => DuLieuTron?.NPMACTenMAC;
        public decimal? SLMeDuTinh => DuLieuTron?.DLT_SLMeDuTinh;
        public decimal? KLDuTinh => DuLieuTron?.DLT_KLDuTinh;
        public DateTime? ThoiGianGiaoHang => DuLieuTron?.ThoiGianGiaoHang;

        /// <summary>
        /// Critical Ratio = (giờ giao - giờ hiện tại) / thời gian trộn còn lại (phút).
        /// CR &lt; 1.0 → đang trễ, CR 1.0–1.5 → sắp trễ, CR &gt; 1.5 → an toàn.
        /// Trả về null nếu không có deadline hoặc thời gian trộn = 0.
        /// </summary>
        public double? CriticalRatio
        {
            get
            {
                if (DuLieuTron?.ThoiGianGiaoHang == null) return null;
                if (EstimatedDurationMinutes <= 0) return null;
                double remainingMins = (DuLieuTron.ThoiGianGiaoHang.Value - DateTime.Now).TotalMinutes;
                return remainingMins / EstimatedDurationMinutes;
            }
        }

        /// <summary>Đơn này sẽ giao trễ so với deadline không?</summary>
        public bool IsLate =>
            DuLieuTron?.ThoiGianGiaoHang.HasValue == true &&
            EstimatedEndTime > DuLieuTron.ThoiGianGiaoHang.Value;

        /// <summary>Số phút trễ so với deadline (0 nếu đúng/sớm hạn).</summary>
        public int TardinessMinutes =>
            IsLate ? (int)(EstimatedEndTime - DuLieuTron.ThoiGianGiaoHang.Value).TotalMinutes : 0;

        /// <summary>Nhãn trạng thái thời gian giao hàng (so với deadline).</summary>
        public string TrangThaiThoiGian
        {
            get
            {
                if (DuLieuTron?.ThoiGianGiaoHang == null) return string.Empty;
                var cr = CriticalRatio;
                if (cr == null) return string.Empty;
                if (cr < 1.0) return "TRỄ";
                if (cr < 1.5) return "SẮP TRỄ";
                return "ĐÚNG HẠN";
            }
        }

        // ── Trạng thái thời gian thực ────────────────────────────────

        /// <summary>Đơn này đang trong khoảng giờ sản xuất ước tính.</summary>
        public bool IsRunning
        {
            get
            {
                var now = DateTime.Now;
                return now >= EstimatedStartTime && now <= EstimatedEndTime;
            }
        }

        /// <summary>Đã qua giờ kết thúc ước tính.</summary>
        public bool IsDone => DateTime.Now > EstimatedEndTime;

        /// <summary>Tiến độ thực tế: CHỜ / ĐANG CHẠY / ĐÃ XONG.</summary>
        public string TienDo
        {
            get
            {
                var now = DateTime.Now;
                if (now < EstimatedStartTime) return "CHỜ";
                if (now <= EstimatedEndTime) return "ĐANG CHẠY";
                return "ĐÃ XONG";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace NDPSo.MasterData.TonKho.Monitor
{
    public enum NVLAlertLevel
    {
        OK       = 0,
        Warning  = 1,
        Critical = 2,
        StockOut = 3
    }

    public class NVLShortage
    {
        public int     SiloID       { get; set; }
        public string  MaSilo       { get; set; }
        public string  MaterialName { get; set; }
        public decimal CanDung      { get; set; }  // kg cần dùng
        public decimal HienCon      { get; set; }  // kg còn trong tồn ảo
        public decimal ThieuHut     => CanDung - HienCon;
    }

    public class NVLOrderFeasibility
    {
        public int               DuLieuTronID     { get; set; }
        public string            MaHopDong        { get; set; }
        public string            KhachHang        { get; set; }
        public decimal?          SoMeDuTinh       { get; set; }
        public DateTime?         ThoiGianGiaoHang { get; set; }
        public double?           CriticalRatio    { get; set; }

        public bool              CoThe    { get; set; }
        public List<NVLShortage> Shortages { get; set; } = new List<NVLShortage>();

        // Đơn gấp (CR < 1.5) mà vẫn thiếu NVL → cần cảnh báo ngay
        public bool IsUrgent => !CoThe && CriticalRatio.HasValue && CriticalRatio.Value < 1.5;

        public string TomTat => CoThe
            ? "✓ Đủ NVL"
            : "⚠ Thiếu " + string.Join(", ",
                Shortages.Select(s => $"{s.MaterialName} {s.ThieuHut:N0}kg"));
    }

    public class NVLMonitorResult
    {
        public DateTime                  CheckTime          { get; set; }
        public List<NVLOrderFeasibility> Feasibilities      { get; set; } = new List<NVLOrderFeasibility>();
        public NVLAlertLevel             AlertLevel         { get; set; }
        public Dictionary<int, decimal>  ProjectedInventory { get; set; } = new Dictionary<int, decimal>();

        // Đơn gấp nhất đang thiếu NVL (dùng cho thông báo nhanh)
        public NVLOrderFeasibility MostUrgentShortage =>
            Feasibilities?.Where(f => !f.CoThe)
                          .OrderBy(f => f.CriticalRatio ?? double.MaxValue)
                          .FirstOrDefault();

        public string StatusBarText
        {
            get
            {
                int shortCount  = Feasibilities?.Count(f => !f.CoThe)   ?? 0;
                int urgentCount = Feasibilities?.Count(f => f.IsUrgent) ?? 0;
                if (AlertLevel == NVLAlertLevel.OK)
                    return $"NVL ✓  Đủ {Feasibilities?.Count ?? 0} đơn tới";
                if (urgentCount > 0)
                    return $"NVL ⚠  {urgentCount} đơn gấp thiếu NVL!";
                return $"NVL ⚠  {shortCount} đơn thiếu NVL";
            }
        }
    }
}

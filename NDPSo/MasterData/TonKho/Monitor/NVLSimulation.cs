using System;
using System.Collections.Generic;
using System.Linq;

namespace NDPSo.MasterData.TonKho.Monitor
{
    // ── Internal DTOs dùng trong engine (không expose ra ngoài) ───────────

    internal class PendingOrder
    {
        public int       DuLieuTronID     { get; set; }
        public string    MaHopDong        { get; set; }
        public string    KhachHang        { get; set; }
        public int       MACID            { get; set; }
        public decimal   SoMeDuTinh       { get; set; }
        public DateTime? ThoiGianGiaoHang { get; set; }
        public double?   CriticalRatio    { get; set; }
    }

    internal class MacSiloInfo
    {
        public int     MACID        { get; set; }
        public int     SiloID       { get; set; }
        public string  MaSilo       { get; set; }
        public string  MaterialName { get; set; }
        public decimal SiloValue    { get; set; }  // kg/mẻ
    }

    // ── Thuật toán giả lập tuần tự (greedy sequential simulation) ─────────

    public class NVLSimulation
    {
        /// <summary>Tồn kho ảo sau khi chạy xong toàn bộ đơn có thể thực hiện.</summary>
        public Dictionary<int, decimal> LastProjectedInventory { get; private set; }

        internal List<NVLOrderFeasibility> Simulate(
            List<PendingOrder>       orders,
            Dictionary<int, decimal> inventory,
            List<MacSiloInfo>        macSilos,
            int                      maxOrders = 10)
        {
            var results  = new List<NVLOrderFeasibility>();
            // Bản sao tồn ảo — không thay đổi tồn thật
            var virtualInv = new Dictionary<int, decimal>(inventory);

            foreach (var order in orders.Take(maxOrders))
            {
                var needs     = GetOrderNeeds(order, macSilos);
                var shortages = new List<NVLShortage>();

                foreach (var kv in needs)
                {
                    decimal available = virtualInv.ContainsKey(kv.Key) ? virtualInv[kv.Key] : 0m;
                    if (available < kv.Value.KgNeeded)
                    {
                        shortages.Add(new NVLShortage
                        {
                            SiloID       = kv.Key,
                            MaSilo       = kv.Value.MaSilo,
                            MaterialName = kv.Value.MaterialName,
                            CanDung      = kv.Value.KgNeeded,
                            HienCon      = available
                        });
                    }
                }

                bool coThe = shortages.Count == 0;

                if (coThe)
                {
                    // Trừ tồn ảo để đơn tiếp theo biết còn lại bao nhiêu
                    foreach (var kv in needs)
                    {
                        if (!virtualInv.ContainsKey(kv.Key))
                            virtualInv[kv.Key] = 0m;
                        virtualInv[kv.Key] -= kv.Value.KgNeeded;
                        if (virtualInv[kv.Key] < 0m)
                            virtualInv[kv.Key] = 0m;
                    }
                }

                results.Add(new NVLOrderFeasibility
                {
                    DuLieuTronID     = order.DuLieuTronID,
                    MaHopDong        = order.MaHopDong,
                    KhachHang        = order.KhachHang,
                    SoMeDuTinh       = order.SoMeDuTinh,
                    ThoiGianGiaoHang = order.ThoiGianGiaoHang,
                    CriticalRatio    = order.CriticalRatio,
                    CoThe            = coThe,
                    Shortages        = shortages
                });
            }

            LastProjectedInventory = virtualInv;
            return results;
        }

        private struct NeedEntry
        {
            public decimal KgNeeded;
            public string  MaSilo;
            public string  MaterialName;
        }

        private Dictionary<int, NeedEntry> GetOrderNeeds(PendingOrder order, List<MacSiloInfo> macSilos)
        {
            var needs = new Dictionary<int, NeedEntry>();
            foreach (var ms in macSilos.Where(m => m.MACID == order.MACID))
            {
                decimal kg = order.SoMeDuTinh * ms.SiloValue;
                if (kg <= 0m) continue;

                if (needs.ContainsKey(ms.SiloID))
                    needs[ms.SiloID] = new NeedEntry
                    {
                        KgNeeded     = needs[ms.SiloID].KgNeeded + kg,
                        MaSilo       = ms.MaSilo,
                        MaterialName = ms.MaterialName
                    };
                else
                    needs[ms.SiloID] = new NeedEntry
                    {
                        KgNeeded     = kg,
                        MaSilo       = ms.MaSilo,
                        MaterialName = ms.MaterialName
                    };
            }
            return needs;
        }
    }
}

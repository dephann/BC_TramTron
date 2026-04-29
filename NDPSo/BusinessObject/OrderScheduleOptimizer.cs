using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDPSo.BusinessObject
{
    /// <summary>
    /// Tối ưu hóa thứ tự sản xuất cho các phiếu trộn đang chờ.
    /// Có 2 chế độ:
    ///   - Greedy (mặc định): nhóm theo MAC → HangMuc, giảm số lần vệ sinh máy.
    ///   - Priority CR: sắp xếp theo Critical Ratio tăng dần (đơn sắp trễ lên trước).
    /// </summary>
    public class OrderScheduleOptimizer
    {
        /// <summary>Thời gian trộn trung bình mỗi mẻ (phút)</summary>
        public int MinutesPerBatch { get; set; } = 5;

        /// <summary>Thời gian vệ sinh máy khi chuyển đổi loại bê tông (phút)</summary>
        public int SwitchCostMinutes { get; set; } = 15;

        /// <summary>
        /// Khi true → sắp xếp theo Critical Ratio (đơn gấp lên đầu).
        /// Khi false → chế độ Greedy bình thường.
        /// </summary>
        public bool UsePriorityMode { get; set; } = false;

        // ─────────────────────────────────────────────────────────────
        // Public entry point
        // ─────────────────────────────────────────────────────────────

        public List<ObjScheduleItem> Optimize(List<ObjDuLieuTron> pendingOrders, DateTime startTime)
        {
            var result = new List<ObjScheduleItem>();
            if (pendingOrders == null || pendingOrders.Count == 0)
                return result;

            if (UsePriorityMode)
                result = OptimizeByPriority(pendingOrders, startTime);
            else
                result = OptimizeByGreedy(pendingOrders, startTime);

            for (int i = 0; i < result.Count; i++)
                result[i].ScheduleOrder = i + 1;

            return result;
        }

        // ─────────────────────────────────────────────────────────────
        // Chế độ 1: Greedy (giảm switch cost)
        // ─────────────────────────────────────────────────────────────

        private List<ObjScheduleItem> OptimizeByGreedy(List<ObjDuLieuTron> pendingOrders, DateTime startTime)
        {
            var result = new List<ObjScheduleItem>();

            var byMac = pendingOrders
                .GroupBy(pt => pt.MACID ?? 0)
                .OrderByDescending(g => g.Count());

            foreach (var macGroup in byMac)
            {
                var macItems = GreedyForOneMachine(macGroup.ToList(), startTime);
                result.AddRange(macItems);
                if (macItems.Count > 0)
                    startTime = macItems.Last().EstimatedEndTime;
            }

            return result;
        }

        private List<ObjScheduleItem> GreedyForOneMachine(List<ObjDuLieuTron> orders, DateTime startTime)
        {
            var result = new List<ObjScheduleItem>();
            var byHangMuc = orders
                .GroupBy(pt => pt.HangMucID ?? 0)
                .ToDictionary(g => g.Key, g => g.OrderBy(pt => pt.ThoiGianGiaoHang ?? DateTime.MaxValue).ToList());

            var remainingGroups = new Dictionary<int, List<ObjDuLieuTron>>(byHangMuc);
            int? currentHangMucID = null;
            DateTime currentTime = startTime;

            while (remainingGroups.Count > 0)
            {
                int nextHangMucID = PickNextGroup(remainingGroups, currentHangMucID);
                var groupOrders = remainingGroups[nextHangMucID];

                foreach (var pt in groupOrders)
                {
                    bool isSwitch = currentHangMucID.HasValue && currentHangMucID.Value != nextHangMucID;
                    int switchCost = isSwitch ? SwitchCostMinutes : 0;
                    int duration = CalculateDuration(pt);

                    var item = new ObjScheduleItem
                    {
                        DuLieuTron = pt,
                        HasSwitchBefore = isSwitch,
                        SwitchCostMinutes = switchCost,
                        EstimatedStartTime = currentTime.AddMinutes(switchCost),
                        EstimatedDurationMinutes = duration
                    };
                    item.EstimatedEndTime = item.EstimatedStartTime.AddMinutes(duration);
                    result.Add(item);

                    currentTime = item.EstimatedEndTime;
                    isSwitch = false;
                    switchCost = 0;
                }

                currentHangMucID = nextHangMucID;
                remainingGroups.Remove(nextHangMucID);
            }

            return result;
        }

        private int PickNextGroup(Dictionary<int, List<ObjDuLieuTron>> remaining, int? currentHangMucID)
        {
            if (currentHangMucID.HasValue && remaining.ContainsKey(currentHangMucID.Value))
                return currentHangMucID.Value;

            return remaining
                .OrderByDescending(kv => kv.Value.Count)
                .ThenBy(kv => kv.Key)
                .First().Key;
        }

        // ─────────────────────────────────────────────────────────────
        // Chế độ 2: Priority CR (đơn gấp/trễ hạn lên đầu)
        // ─────────────────────────────────────────────────────────────

        private List<ObjScheduleItem> OptimizeByPriority(List<ObjDuLieuTron> pendingOrders, DateTime startTime)
        {
            // Sắp xếp: CR tăng dần (CR nhỏ = nguy hiểm hơn = lên trước).
            // Đơn không có deadline xếp cuối, sort phụ theo ThoiGianGiaoHang.
            var sorted = pendingOrders
                .OrderBy(pt => pt.ThoiGianGiaoHang.HasValue ? 0 : 1)
                .ThenBy(pt =>
                {
                    if (!pt.ThoiGianGiaoHang.HasValue) return double.MaxValue;
                    double duration = CalculateDuration(pt);
                    if (duration <= 0) return double.MaxValue;
                    return (pt.ThoiGianGiaoHang.Value - DateTime.Now).TotalMinutes / duration;
                })
                .ThenBy(pt => pt.ThoiGianGiaoHang ?? DateTime.MaxValue)
                .ToList();

            var result = new List<ObjScheduleItem>();
            DateTime currentTime = startTime;
            int? currentHangMucID = null;

            foreach (var pt in sorted)
            {
                bool isSwitch = currentHangMucID.HasValue && currentHangMucID.Value != (pt.HangMucID ?? 0);
                int switchCost = isSwitch ? SwitchCostMinutes : 0;
                int duration = CalculateDuration(pt);

                var item = new ObjScheduleItem
                {
                    DuLieuTron = pt,
                    HasSwitchBefore = isSwitch,
                    SwitchCostMinutes = switchCost,
                    EstimatedStartTime = currentTime.AddMinutes(switchCost),
                    EstimatedDurationMinutes = duration
                };
                item.EstimatedEndTime = item.EstimatedStartTime.AddMinutes(duration);
                result.Add(item);

                currentTime = item.EstimatedEndTime;
                currentHangMucID = pt.HangMucID ?? 0;
            }

            return result;
        }

        // ─────────────────────────────────────────────────────────────
        // Helpers
        // ─────────────────────────────────────────────────────────────

        private int CalculateDuration(ObjDuLieuTron pt)
        {
            double batches = (double)(pt.DLT_SLMeDuTinh ?? 1m);
            return (int)Math.Ceiling(batches * MinutesPerBatch);
        }

        public static int CountSwitches(List<ObjScheduleItem> schedule)
            => schedule.Count(s => s.HasSwitchBefore);

        public static int TotalMinutes(List<ObjScheduleItem> schedule)
        {
            if (schedule == null || schedule.Count == 0) return 0;
            return (int)(schedule.Last().EstimatedEndTime - schedule.First().EstimatedStartTime).TotalMinutes;
        }

        /// <summary>Đếm số phiếu sẽ giao trễ trong lịch trình hiện tại.</summary>
        public static int CountLateOrders(List<ObjScheduleItem> schedule)
            => schedule.Count(s => s.IsLate);
    }
}

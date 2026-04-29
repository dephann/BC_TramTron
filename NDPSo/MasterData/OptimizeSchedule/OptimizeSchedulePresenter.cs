using NDPSo.BusinessObject;
using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NDPSo.MasterData
{
    public class OptimizeSchedulePresenter : MasterDataPresenter<IOptimizeScheduleView>
    {
        // Trạng thái DuLieuTron cần lên lịch: Mới (0), Tạm dừng (2)
        private static readonly int[] PendingStatuses = { 0, 2 };

        private List<ObjDuLieuTron> _pendingOrders = new List<ObjDuLieuTron>();

        public OptimizeSchedulePresenter(IOptimizeScheduleView view) : base(view)
        {
        }

        public void LoadMAC()
        {
            var lstMac = MasterDataPresenter<IOptimizeScheduleView>._iMasterDataModel.ListMAC();
            this._iView.LstMAC = lstMac?.ToList() ?? new List<ObjMAC>();
        }

        public void LoadPendingOrders(DateTime fromDate, DateTime toDate, int? macID)
        {
            var all = MasterDataPresenter<IOptimizeScheduleView>._iMasterDataModel
                .ListDuLieuTron(true);

            _pendingOrders = (all ?? new System.ComponentModel.BindingList<ObjDuLieuTron>())
                .Where(dlt => dlt.Status.HasValue && PendingStatuses.Contains(dlt.Status.Value))
                .Where(dlt => !macID.HasValue || dlt.MACID == macID.Value)
                .Where(dlt => !dlt.ThoiGianGiaoHang.HasValue ||
                              (dlt.ThoiGianGiaoHang.Value.Date >= fromDate.Date &&
                               dlt.ThoiGianGiaoHang.Value.Date <= toDate.Date))
                .ToList();

            this._iView.LstPendingDuLieuTron = _pendingOrders;
        }

        public void RunOptimization(DateTime startTime, int minutesPerBatch, int switchCostMinutes, bool usePriority = false)
        {
            var optimizer = new OrderScheduleOptimizer
            {
                MinutesPerBatch = minutesPerBatch,
                SwitchCostMinutes = switchCostMinutes,
                UsePriorityMode = usePriority
            };

            var schedule = optimizer.Optimize(_pendingOrders, startTime);
            this._iView.LstScheduleItems = schedule;
        }
    }
}

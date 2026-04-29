using NDPSo.MasterData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Reports
{
    public class ReportChiTietMeTronDataPresenter : MasterDataPresenter<IReportChiTietMeTron>
    {
        public ReportChiTietMeTronDataPresenter(IReportChiTietMeTron view) : base(view) { }

        public void ListReportChiTietMeTron() => this._iView.BLstRptDBChiTiet = MasterDataPresenter<IReportChiTietMeTron>._iMasterDataModel.ListDataMix();
        public void ListReportChiTietMeTron_ByCondition(
            DateTime? fromDate,
            TimeSpan? fromTime,
            DateTime? toDate,
            TimeSpan? toTime,
            string maPhieuTron,
            int? khachHang,
            int? congTruong,
            int? mac,
            int? bienSo,
            int? taiXe,
            bool? moPhong)
        {
            this._iView.BLstRptDBChiTiet = MasterDataPresenter<IReportChiTietMeTron>
                ._iMasterDataModel.ListDataMix_ByCondition(
                    fromDate, fromTime, toDate, toTime,
                    maPhieuTron, khachHang, congTruong,
                    null, mac, bienSo, taiXe, null, moPhong);
        }


    }
}

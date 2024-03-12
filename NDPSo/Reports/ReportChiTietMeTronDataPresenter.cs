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
        public void ListReportChiTietMeTron_ByCondition()
        {

        }


    }
}

using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class TaiXeMngDataPresenter : MasterDataPresenter<ITaiXeMngView>
    {
        public TaiXeMngDataPresenter(ITaiXeMngView view)
          : base(view)
        {
        }

        public void ListTaiXe() => this._iView.BLstTaiXe = MasterDataPresenter<ITaiXeMngView>._iMasterDataModel.ListTaiXe();

        public void ListTaiXe_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string phone,
          bool? active)
        {
            this._iView.BLstTaiXe = MasterDataPresenter<ITaiXeMngView>._iMasterDataModel.ListTaiXe_ByCondition(fromDate, toDate, maKH, tenKH, phone, active);
        }

        public void SaveTaiXe(BindingList<ObjTaiXe> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<ITaiXeMngView>._iMasterDataModel.SaveTaiXe(blstCT);
    }
}

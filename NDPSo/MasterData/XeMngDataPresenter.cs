using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class XeMngDataPresenter : MasterDataPresenter<IXeMngView>
    {
        public XeMngDataPresenter(IXeMngView view)
          : base(view)
        {
        }

        public void ListXe() => this._iView.BLstXe = MasterDataPresenter<IXeMngView>._iMasterDataModel.ListXe();

        public void ListXe_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string bienSo,
          bool? active)
        {
            this._iView.BLstXe = MasterDataPresenter<IXeMngView>._iMasterDataModel.ListXe_ByCondition(fromDate, toDate, bienSo, active);
        }

        public void SaveXe(BindingList<ObjXe> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<IXeMngView>._iMasterDataModel.SaveXe(blstCT);
    }
}


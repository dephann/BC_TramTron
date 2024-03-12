using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class TinhDoHutNuocMngDataPresenter : MasterDataPresenter<ITinhDoHutNuocMngView>
    {
        public TinhDoHutNuocMngDataPresenter(ITinhDoHutNuocMngView view)
          : base(view)
        {
        }

        public void ListTinhDoHutNuoc() => this._iView.BLstTinhDoHutNuoc = MasterDataPresenter<ITinhDoHutNuocMngView>._iMasterDataModel.ListTinhDoHutNuoc();

        public void SaveTinhDoHutNuoc(BindingList<ObjTinhDoHutNuoc> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<ITinhDoHutNuocMngView>._iMasterDataModel.SaveTinhDoHutNuoc(blstCT);

        public void ListNhomSilo() => this._iView.BLstNhomSilo = MasterDataPresenter<ITinhDoHutNuocMngView>._iMasterDataModel.ListNhomSilo();
    }
}

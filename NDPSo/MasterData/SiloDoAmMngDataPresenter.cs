using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class SiloDoAmMngDataPresenter : MasterDataPresenter<ISiloDoAmMngView>
    {
        public SiloDoAmMngDataPresenter(ISiloDoAmMngView view)
          : base(view)
        {
        }

        public void ListSiloDoAm() => this._iView.BLstSiloDoAm = MasterDataPresenter<ISiloDoAmMngView>._iMasterDataModel.ListSilo_ByActivated_ByMaNhomSilo(true, "Agg");

        public void SaveSiloDoAm(BindingList<ObjSilo> blstSilo) => this._iView.IsSuccessfulSaved = MasterDataPresenter<ISiloDoAmMngView>._iMasterDataModel.SaveSilo(blstSilo);
    }
}


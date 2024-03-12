using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class SiloMngDataPresenter : MasterDataPresenter<ISiloMngView>
    {
        public SiloMngDataPresenter(ISiloMngView view)
          : base(view)
        {
        }

        public void ListSilo() => this._iView.BLstSilo = MasterDataPresenter<ISiloMngView>._iMasterDataModel.ListSilo_ByActivated(true);

        public void ListNhomSilo() => this._iView.BLstNhomSilo = MasterDataPresenter<ISiloMngView>._iMasterDataModel.ListNhomSilo();

        public void SaveSilo(BindingList<ObjSilo> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<ISiloMngView>._iMasterDataModel.SaveSilo(blstCT);
    }
}

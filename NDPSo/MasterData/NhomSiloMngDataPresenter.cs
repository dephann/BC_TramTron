using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class NhomSiloMngDataPresenter : MasterDataPresenter<INhomSiloMngView>
    {
        public NhomSiloMngDataPresenter(INhomSiloMngView view)
          : base(view)
        {
        }

        public void ListNhomSilo() => this._iView.BLstNhomSilo = MasterDataPresenter<INhomSiloMngView>._iMasterDataModel.ListNhomSilo();

        public void SaveNhomSilo(BindingList<ObjNhomSilo> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INhomSiloMngView>._iMasterDataModel.SaveNhomSilo(blstCT);
    }
}

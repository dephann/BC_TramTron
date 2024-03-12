using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class MACMngDataPresenter : MasterDataPresenter<IMACMngView>
    {
        public MACMngDataPresenter(IMACMngView view)
          : base(view)
        {
        }

        public void ListMAC() => this._iView.BLstMAC = MasterDataPresenter<IMACMngView>._iMasterDataModel.ListMAC();

        public void ListMAC_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maMAC,
          string tenMAC,
          bool? active)
        {
            this._iView.BLstMAC = MasterDataPresenter<IMACMngView>._iMasterDataModel.ListMAC_ByCondition(fromDate, toDate, maMAC, tenMAC, active);
        }

        public void SaveMAC(BindingList<ObjMAC> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<IMACMngView>._iMasterDataModel.SaveMAC(blstCT);
    }
}


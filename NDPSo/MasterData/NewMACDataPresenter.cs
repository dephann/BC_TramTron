using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class NewMACDataPresenter : MasterDataPresenter<INewMACView>
    {
        public NewMACDataPresenter(INewMACView view)
          : base(view)
        {
        }

        public void BuildNewMAC() => this._iView.MAC = new ObjMAC()
        {
            MaMAC = MasterDataPresenter<INewMACView>._iMasterDataModel.GetNextCode("MAC"),
            //MaMAC = string.Empty,
            TenMAC = string.Empty,
            Activated = true
        };

        public void GetMACByKey(int soID) => this._iView.MAC = MasterDataPresenter<INewMACView>._iMasterDataModel.GetMACByKey(soID);

        public void SaveMAC(BindingList<ObjMAC> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INewMACView>._iMasterDataModel.SaveMAC(blstCT);

        public void ListSilo_ByActivated(bool activated) => this._iView.BLstSilo = MasterDataPresenter<INewMACView>._iMasterDataModel.ListSilo_ByActivated(activated);

        public void ListMACSilo_ByMACID(int macID) => this._iView.BLstMACSilo = MasterDataPresenter<INewMACView>._iMasterDataModel.ListMACSilo_ByMACID(macID);
    }
}


using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    class ConfigUIMngDataPresenter : MasterDataPresenter<IConfigUIMngView>
    {
        public ConfigUIMngDataPresenter(IConfigUIMngView view)
          : base(view)
        {
        }
        //public void ListSilo() => this._iView.BLstSilo = MasterDataPresenter<IConfigUIMngView>._iMasterDataModel.ListSilo();

        public void ListSilo_ByActivated_Agg(bool? isActived) => this._iView.BLstSilo_Agg = MasterDataPresenter<IConfigUIMngView>._iMasterDataModel.ListSilo_ByActivated_ByMaNhomSilo(isActived, "Agg");
        public void ListSilo_ByActivated_Ce(bool? isActived) => this._iView.BLstSilo_Ce = MasterDataPresenter<IConfigUIMngView>._iMasterDataModel.ListSilo_ByActivated_ByMaNhomSilo(isActived, "Ce");
        public void ListSilo_ByActivated_Wa(bool? isActived) => this._iView.BLstSilo_Wa = MasterDataPresenter<IConfigUIMngView>._iMasterDataModel.ListSilo_ByActivated_ByMaNhomSilo(isActived, "Wa");
        public void ListSilo_ByActivated_Add(bool? isActived) => this._iView.BLstSilo_Add = MasterDataPresenter<IConfigUIMngView>._iMasterDataModel.ListSilo_ByActivated_ByMaNhomSilo(isActived, "Add");

        //public void ListSilo_ByActivated(bool isActived) => this._iView.BLstSilo = MasterDataPresenter<IConfigUIMngView>._iMasterDataModel.ListSilo_ByActivated(isActived);

        public void SaveSilo(BindingList<ObjSilo> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<ISiloMngView>._iMasterDataModel.SaveSilo(blstCT);
    }
}
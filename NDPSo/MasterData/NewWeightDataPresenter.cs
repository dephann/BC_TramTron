using System;
using System.ComponentModel;
using NDPSo.Data;


namespace NDPSo.MasterData
{
    class NewWeightDataPresenter : MasterDataPresenter<INewWeightView>
    {
        public NewWeightDataPresenter(INewWeightView view) : base(view)
        {

        }
       public void GetWeiByKey(int soID)
       {
            ObjWeigh weiByKey = MasterDataPresenter<INewWeightView>._iMasterDataModel.GetWeighByKey(soID);
            base._iView.Weight = weiByKey;
       }
        public void SaveWei(BindingList<ObjWeigh> btstWei)
        {
            base._iView.IsSuccessfulSaved = MasterDataPresenter<INewWeightView>._iMasterDataModel.SaveWeigh(btstWei);
        }
    }
}

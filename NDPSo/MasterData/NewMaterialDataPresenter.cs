using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class NewMaterialDataPresenter : MasterDataPresenter<INewMaterialView>
    {
        public NewMaterialDataPresenter(INewMaterialView view)
          : base(view)
        {
        }

        public void BuildNewMaterial() => this._iView.Material = new ObjMaterial()
        {
            MaterialCode = MasterDataPresenter<INewMaterialView>._iMasterDataModel.GetNextCode("Material"),
            MaterialName = string.Empty,
            Activated = true
        };

        public void GetMaterialByKey(int soID) => this._iView.Material = MasterDataPresenter<INewMaterialView>._iMasterDataModel.GetMaterialByKey(soID);

        public void SaveMaterial(BindingList<ObjMaterial> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INewMaterialView>._iMasterDataModel.SaveMaterial(blstCT);
    }
}

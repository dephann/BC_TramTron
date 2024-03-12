using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class MaterialMngDataPresenter : MasterDataPresenter<IMaterialMngView>
    {
        public MaterialMngDataPresenter(IMaterialMngView view)
          : base(view)
        {
        }

        public void ListMaterial() => this._iView.BLstMaterial = MasterDataPresenter<IMaterialMngView>._iMasterDataModel.ListMaterial();

        public void ListMaterial_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maVT,
          string tenVT,
          bool? active)
        {
            this._iView.BLstMaterial = MasterDataPresenter<IMaterialMngView>._iMasterDataModel.ListMaterial_ByCondition(fromDate, toDate, maVT, tenVT, active);
        }

        public void SaveMaterial(BindingList<ObjMaterial> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<IMaterialMngView>._iMasterDataModel.SaveMaterial(blstCT);
    }
}

using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class NewNhomSiloDataPresenter : MasterDataPresenter<INewNhomSiloView>
    {
        public NewNhomSiloDataPresenter(INewNhomSiloView view)
          : base(view)
        {
        }

        public void BuildNewNhomSilo() => this._iView.NhomSilo = new ObjNhomSilo()
        {
            MaNhomSilo = string.Empty,
            TenNhomSilo = string.Empty
        };

        public void GetNhomSiloByKey(int soID) => this._iView.NhomSilo = MasterDataPresenter<INewNhomSiloView>._iMasterDataModel.GetNhomSiloByKey(soID);

        public void SaveNhomSilo(BindingList<ObjNhomSilo> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INewNhomSiloView>._iMasterDataModel.SaveNhomSilo(blstCT);
    }
}

using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    class NewNhanVienDataPresenter : MasterDataPresenter<INewNhanVienView>
    {
        public NewNhanVienDataPresenter(INewNhanVienView view)
          : base(view)
        {
        }

        public void BuildNewNhanVien() => this._iView.NhanVien = new ObjNhanVien()
        {
            MaNhanVien = MasterDataPresenter<INewNhanVienView>._iMasterDataModel.GetNextCode("NhanVien"),
            GioiTinh = "M",
            Activated = true
        };

        public void GetNhanVienByKey(int soID) => this._iView.NhanVien = MasterDataPresenter<INewNhanVienView>._iMasterDataModel.GetNhanVienByKey(soID);

        public void SaveNhanVien(BindingList<ObjNhanVien> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INewNhanVienView>._iMasterDataModel.SaveNhanVien(blstCT);
    }
}


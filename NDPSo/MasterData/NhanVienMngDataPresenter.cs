using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    class NhanVienMngDataPresenter : MasterDataPresenter<INhanVienMngView>
    {
        public NhanVienMngDataPresenter(INhanVienMngView view)
          : base(view)
        {
        }

        public void ListNhanVien() => this._iView.BLstNhanVien = MasterDataPresenter<INhanVienMngView>._iMasterDataModel.ListNhanVien();

        public void ListNhanVien_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string phone,
          bool? active)
        {
            this._iView.BLstNhanVien = MasterDataPresenter<INhanVienMngView>._iMasterDataModel.ListNhanVien_ByCondition(fromDate, toDate, maKH, tenKH, phone, active);
        }

        public void SaveNhanVien(BindingList<ObjNhanVien> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<INhanVienMngView>._iMasterDataModel.SaveNhanVien(blstCT);
    }
}

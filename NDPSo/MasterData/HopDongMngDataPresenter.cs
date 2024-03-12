using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class HopDongMngDataPresenter : MasterDataPresenter<IHopDongMngView>
    {
        public HopDongMngDataPresenter(IHopDongMngView view)
          : base(view)
        {
        }

        public void ListHopDong() => this._iView.BLstHopDong = MasterDataPresenter<IHopDongMngView>._iMasterDataModel.ListHopDong();

        public void ListHopDong(
          string maHopDong,
          DateTime fromDate,
          DateTime toDate,
          int? status,
          int? khachHangID,
          int? congTruongID,
          int? macID)
        {
            this._iView.BLstHopDong = MasterDataPresenter<IHopDongMngView>._iMasterDataModel.ListHopDong_ByCondition(maHopDong, fromDate, toDate, status, khachHangID, congTruongID, macID);
        }

        public void SaveHopDong(BindingList<ObjHopDong> blstCT) => this._iView.IsSuccessfulSaved = MasterDataPresenter<IHopDongMngView>._iMasterDataModel.SaveHopDong(blstCT);

        public void ListHopDongStatus() => this._iView.LstHopDongStatus = Converter.EnumToListFieldCode<Enums.HopDongStatus>(true);

        public void ListKhachHang() => this._iView.BLstKhachHang = MasterDataPresenter<IHopDongMngView>._iMasterDataModel.ListKhachHang();

        public void ListKhachHang_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string diaChi,
          string phone,
          bool? active)
        {
            this._iView.BLstKhachHang = MasterDataPresenter<IHopDongMngView>._iMasterDataModel.ListKhachHang_ByCondition(fromDate, toDate, maKH, tenKH, diaChi, phone, active);
        }

        public void ListCongTruong() => this._iView.BLstCongTruong = MasterDataPresenter<IHopDongMngView>._iMasterDataModel.ListCongTruong();

        public void ListCongTruong_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string diaChi,
          string phone,
          bool? active)
        {
            this._iView.BLstCongTruong = MasterDataPresenter<IHopDongMngView>._iMasterDataModel.ListCongTruong_ByCondition(fromDate, toDate, maKH, tenKH, diaChi, phone, active);
        }

        public void ListMAC() => this._iView.BLstMAC = MasterDataPresenter<IHopDongMngView>._iMasterDataModel.ListMAC();
    }
}

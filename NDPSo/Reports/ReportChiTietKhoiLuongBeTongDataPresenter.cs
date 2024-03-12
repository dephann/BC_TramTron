using NDPSo.Data;
using NDPSo.MasterData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Reports
{
    class ReportChiTietKhoiLuongBeTongDataPresenter : MasterDataPresenter<ISumWeightMngView>
    {
        public ReportChiTietKhoiLuongBeTongDataPresenter(ISumWeightMngView view) : base(view)
        {
        }

		public void ListKhachHang()
		{
			base._iView.BLstKhachHang = MasterDataPresenter<ISumWeightMngView>._iMasterDataModel.ListKhachHang();

		}
		public void ListCongTruong()
		{
			base._iView.BLstCongTruong = MasterDataPresenter<ISumWeightMngView>._iMasterDataModel.ListCongTruong();

		}
		public void ListHangMuc()
		{
			base._iView.BLstHangMuc = MasterDataPresenter<ISumWeightMngView>._iMasterDataModel.ListHangMuc();

		}
		public void ListMAC()
		{
			base._iView.BLstMAC = MasterDataPresenter<ISumWeightMngView>._iMasterDataModel.ListMAC();

		}
		public void ListXe()
		{
			base._iView.BLstXe = MasterDataPresenter<ISumWeightMngView>._iMasterDataModel.ListXe();

		}
		public void ListTaiXe()
		{
			base._iView.BLstTaiXe = MasterDataPresenter<ISumWeightMngView>._iMasterDataModel.ListTaiXe();

		}
		public void ListNhanVien()
		{
			base._iView.BLstNhanVien = MasterDataPresenter<ISumWeightMngView>._iMasterDataModel.ListNhanVien();

		}

		public void ListSumWeight_ByCondition(
			DateTime? fromDate,
			DateTime? toDate,
			string maPhieuTron,
			int? khachHang,
			int? congTruong,
			int? hangMuc,
			int? mac,
			int? bienSo,
			int? taiXe,
			int? nhanVien,
			bool? moPhong)
		{
			base._iView.BLstSumWeight = MasterDataPresenter<ISumWeightMngView>._iMasterDataModel.ListSumWeight_ByCondition(fromDate, toDate, maPhieuTron, khachHang, congTruong, hangMuc, mac, bienSo, taiXe, nhanVien, moPhong);
		}
		public BindingList<Objvw_SumWeight> ListSumWeight_ByCondition_re(
			DateTime? fromDate,
			DateTime? toDate,
			string maPhieuTron,
			int? khachHang,
			int? congTruong,
			int? hangMuc,
			int? mac,
			int? bienSo,
			int? taiXe,
			int? nhanVien,
			bool? moPhong)
		{
			return MasterDataPresenter<ISumWeightMngView>._iMasterDataModel.ListSumWeight_ByCondition(fromDate, toDate, maPhieuTron, khachHang, congTruong, hangMuc, mac, bienSo, taiXe, nhanVien, moPhong);
		}
	}
}
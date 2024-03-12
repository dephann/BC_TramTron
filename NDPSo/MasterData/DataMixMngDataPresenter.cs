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
    public class DataMixMngDataPresenter : MasterDataPresenter<IDataMixMngView>
    {
        public DataMixMngDataPresenter(IDataMixMngView view) : base(view)
        {
        }

		public void ListDataMixStatus() => this._iView.LstDataMixStatus = Converter.EnumToListFieldCode<Enums.DuLieuTronStatus>(true);

		public void ListKhachHang()
        {
			base._iView.BLstKhachHang = MasterDataPresenter<IDataMixMngView>._iMasterDataModel.ListKhachHang();

		}
		public void ListCongTruong()
		{
			base._iView.BLstCongTruong = MasterDataPresenter<IDataMixMngView>._iMasterDataModel.ListCongTruong();

		}
		public void ListHangMuc()
		{
			base._iView.BLstHangMuc = MasterDataPresenter<IDataMixMngView>._iMasterDataModel.ListHangMuc();

		}
		public void ListMAC()
		{
			base._iView.BLstMAC = MasterDataPresenter<IDataMixMngView>._iMasterDataModel.ListMAC();
		}
		public void ListSilo()
		{
			base._iView.BLstSilo = MasterDataPresenter<IDataMixMngView>._iMasterDataModel.ListSilo();

		}
		public void ListXe()
		{
			base._iView.BLstXe = MasterDataPresenter<IDataMixMngView>._iMasterDataModel.ListXe();

		}
		public void ListTaiXe()
		{
			base._iView.BLstTaiXe = MasterDataPresenter<IDataMixMngView>._iMasterDataModel.ListTaiXe();

		}
		public void ListNhanVien()
		{
			base._iView.BLstNhanVien = MasterDataPresenter<IDataMixMngView>._iMasterDataModel.ListNhanVien();

		}
		public void ListDataMix()
		{
			base._iView.BLstDataMix = MasterDataPresenter<IDataMixMngView>._iMasterDataModel.ListDataMix();
		}

		public void ListDataMix_ByCondition(DateTime? fromDate, DateTime? toDate, string maPT, string khachHang, string congTruong, string hangMuc, string taiXe, string bienXe, string mac, string nhanVIen)
		{
			base._iView.BLstDataMix = MasterDataPresenter<IDataMixMngView>._iMasterDataModel.ListDataMix_ByCondition(fromDate, toDate, maPT, khachHang, congTruong, hangMuc, taiXe, bienXe, mac, nhanVIen);
		}

		public void ListDataMix_ByCondition(
			DateTime? fromDate,
			TimeSpan? fromTime,
			DateTime? toDate,
			TimeSpan? toTime,
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
			base._iView.BLstDataMix = MasterDataPresenter<IDataMixMngView>._iMasterDataModel.ListDataMix_ByCondition(fromDate, fromTime, toDate, toTime, maPhieuTron, khachHang, congTruong, hangMuc, mac, bienSo, taiXe, nhanVien, moPhong);
		}
		public BindingList<Objvw_DataMix> ListDataMix_ByCondition_re(
			DateTime? fromDate,
			TimeSpan? fromTime,
			DateTime? toDate,
			TimeSpan? toTime,
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
			 return MasterDataPresenter<IDataMixMngView>._iMasterDataModel.ListDataMix_ByCondition(fromDate, fromTime, toDate, toTime, maPhieuTron, khachHang, congTruong, hangMuc, mac, bienSo, taiXe, nhanVien, moPhong);
		}
	}
}

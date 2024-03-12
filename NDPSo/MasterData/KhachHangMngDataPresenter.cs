using System;
using System.ComponentModel;
using NDPSo.Data;

namespace NDPSo.MasterData
{
	public class KhachHangMngDataPresenter : MasterDataPresenter<IKhachHangMngView>
	{
		public KhachHangMngDataPresenter(IKhachHangMngView view) : base(view)
		{
		}

		public void ListKhachHang()
		{
			base._iView.BLstKhachHang = MasterDataPresenter<IKhachHangMngView>._iMasterDataModel.ListKhachHang();
		}

		public void ListKhachHang_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string diaChi, string phone, bool? active)
		{
			base._iView.BLstKhachHang = MasterDataPresenter<IKhachHangMngView>._iMasterDataModel.ListKhachHang_ByCondition(fromDate, toDate, maKH, tenKH, diaChi, phone, active);
		}

		public void SaveKhachHang(BindingList<ObjKhachHang> blstCT)
		{
			base._iView.IsSuccessfulSaved = MasterDataPresenter<IKhachHangMngView>._iMasterDataModel.SaveKhachHang(blstCT);
		}
	}
}

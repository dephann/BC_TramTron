using System;
using System.ComponentModel;
using NDPSo.Data;

namespace NDPSo.MasterData
{
	public class NewKhachHangDataPresenter : MasterDataPresenter<INewKhachHangView>
	{
		public NewKhachHangDataPresenter(INewKhachHangView view) : base(view)
		{
		}

		public void BuildNewKhachHang()
		{
			ObjKhachHang khachHang = new ObjKhachHang
			{
				MaKhachHang = MasterDataPresenter<INewKhachHangView>._iMasterDataModel.GetNextCode("KhachHang"),
				TenKhachHang = string.Empty,
				Activated = true
			};
			base._iView.KhachHang = khachHang;
		}

		public void GetKhachHangByKey(int soID)
		{
			ObjKhachHang khachHangByKey = MasterDataPresenter<INewKhachHangView>._iMasterDataModel.GetKhachHangByKey(soID);
			base._iView.KhachHang = khachHangByKey;
		}

		public void SaveKhachHang(BindingList<ObjKhachHang> blstCT)
		{
			base._iView.IsSuccessfulSaved = MasterDataPresenter<INewKhachHangView>._iMasterDataModel.SaveKhachHang(blstCT);
		}
	}
}

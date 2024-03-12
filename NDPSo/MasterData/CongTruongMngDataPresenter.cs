using System;
using System.ComponentModel;
using NDPSo.Data;

namespace NDPSo.MasterData
{
	public class CongTruongMngDataPresenter : MasterDataPresenter<ICongTruongMngView>
	{
		public CongTruongMngDataPresenter(ICongTruongMngView view) : base(view)
		{
		}

		public void ListCongTruong()
		{
			base._iView.BLstCongTruong = MasterDataPresenter<ICongTruongMngView>._iMasterDataModel.ListCongTruong();
		}

		public void ListCongTruong_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string diaChi, string phone, bool? active)
		{
			base._iView.BLstCongTruong = MasterDataPresenter<ICongTruongMngView>._iMasterDataModel.ListCongTruong_ByCondition(fromDate, toDate, maKH, tenKH, diaChi, phone, active);
		}

		public void SaveCongTruong(BindingList<ObjCongTruong> blstCT)
		{
			base._iView.IsSuccessfulSaved = MasterDataPresenter<ICongTruongMngView>._iMasterDataModel.SaveCongTruong(blstCT);
		}
	}
}

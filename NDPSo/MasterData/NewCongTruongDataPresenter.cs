using System;
using System.ComponentModel;
using NDPSo.Data;

namespace NDPSo.MasterData
{
	public class NewCongTruongDataPresenter : MasterDataPresenter<INewCongTruongView>
	{
		public NewCongTruongDataPresenter(INewCongTruongView view) : base(view)
		{
		}

		public void BuildNewCongTruong()
		{
			ObjCongTruong congTruong = new ObjCongTruong
			{
				MaCongTruong = MasterDataPresenter<INewCongTruongView>._iMasterDataModel.GetNextCode("CongTruong"),
				TenCongTruong = string.Empty,
				DiaChi = string.Empty,
				Phone = string.Empty,
				GhiChu = string.Empty,
				Activated = true
			};
			base._iView.CongTruong = congTruong;
		}

		public void GetCongTruongByKey(int soID)
		{
			ObjCongTruong congTruongByKey = MasterDataPresenter<INewCongTruongView>._iMasterDataModel.GetCongTruongByKey(soID);
			base._iView.CongTruong = congTruongByKey;
		}

		public void SaveCongTruong(BindingList<ObjCongTruong> blstCT)
		{
			base._iView.IsSuccessfulSaved = MasterDataPresenter<INewCongTruongView>._iMasterDataModel.SaveCongTruong(blstCT);
		}
	}
}

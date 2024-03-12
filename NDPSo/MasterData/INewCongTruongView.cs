using System;
using NDPSo.Data;

namespace NDPSo.MasterData
{
	public interface INewCongTruongView : IBase
	{
		ObjCongTruong CongTruong { set; }

		bool IsSuccessfulSaved { set; }
	}
}

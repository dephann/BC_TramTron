using System;
using NDPSo.Data;

namespace NDPSo.MasterData
{
	public interface INewKhachHangView : IBase
	{
		ObjKhachHang KhachHang { set; }

		bool IsSuccessfulSaved { set; }
	}
}

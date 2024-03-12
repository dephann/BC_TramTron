using System;
using System.Collections.Generic;
using System.ComponentModel;
using NDPSo.Data;

namespace NDPSo.MasterData
{
	public interface IKhachHangMngView : IBase, IPermission
	{
		BindingList<ObjKhachHang> BLstKhachHang { set; }

		//List<ObjSEC_Function> LstFunction { set; }

		bool IsSuccessfulSaved { set; }
	}
}

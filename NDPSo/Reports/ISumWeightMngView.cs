using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Reports
{
    interface ISumWeightMngView : IBase, IPermission
	{
		BindingList<Objvw_SumWeight> BLstSumWeight { set; }
		BindingList<ObjKhachHang> BLstKhachHang { set; }
		BindingList<ObjCongTruong> BLstCongTruong { set; }
		BindingList<ObjHangMuc> BLstHangMuc { set; }
		BindingList<ObjMAC> BLstMAC { set; }
		BindingList<ObjXe> BLstXe { set; }
		BindingList<ObjTaiXe> BLstTaiXe { set; }
		BindingList<ObjNhanVien> BLstNhanVien { set; }



	}
}
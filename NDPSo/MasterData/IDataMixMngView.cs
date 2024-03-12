using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDPSo.Data;
using NDPSo.Utils;

namespace NDPSo.MasterData
{
    public interface IDataMixMngView : IBase, IPermission
	{
		BindingList<Objvw_DataMix> BLstDataMix { set; }
		BindingList<ObjKhachHang> BLstKhachHang { set; }
		BindingList<ObjCongTruong> BLstCongTruong { set; }
		BindingList<ObjHangMuc> BLstHangMuc { set; }
		BindingList<ObjMAC> BLstMAC { set; }
		BindingList<ObjSilo> BLstSilo { set; }
		BindingList<ObjXe> BLstXe { set; }
		BindingList<ObjTaiXe> BLstTaiXe { set; }
		BindingList<ObjNhanVien> BLstNhanVien { set; }
		List<FieldCode> LstDataMixStatus { set; }

	}
}


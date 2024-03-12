using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Reports
{
    public interface IReportChiTietMeTron : IBase, IPermission
    {
        BindingList<Objvw_DataMix> BLstRptDBChiTiet { set; }
        BindingList<ObjKhachHang> BLstKhachHang { set; }
        BindingList<ObjCongTruong> BLstCongTruong { set; }
        BindingList<ObjTaiXe> BLstTaiXe { set; }
        BindingList<ObjXe> BLstXe { set; }
        BindingList<ObjMAC> BLstMAC { set; }
        List<FieldCode> LstGroupBy { set; }
    }
}

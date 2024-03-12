using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface INewHopDongView : IBase
    {
        ObjHopDong HopDong { set; }

        BindingList<ObjKhachHang> BLstKhachHang { set; }

        BindingList<ObjCongTruong> BLstCongTruong { set; }

        BindingList<ObjMAC> BLstMAC { set; }

        BindingList<ObjHangMuc> BLstHangMuc { set; }

        bool IsSuccessfulSaved { set; }

        int SLMeDuTinh { set; }

        Decimal KLDuTinhMeTron { set; }
    }
}
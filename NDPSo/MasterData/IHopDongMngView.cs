using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface IHopDongMngView : IBase, IPermission
    {
        BindingList<ObjHopDong> BLstHopDong { set; }

        BindingList<ObjKhachHang> BLstKhachHang { set; }

        BindingList<ObjCongTruong> BLstCongTruong { set; }

        BindingList<ObjMAC> BLstMAC { set; }

        bool IsSuccessfulSaved { set; }

        List<FieldCode> LstHopDongStatus { set; }
    }
}

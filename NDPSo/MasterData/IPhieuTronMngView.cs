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
    public interface IPhieuTronMngView : IBase, IPermission
    {
        BindingList<ObjPhieuTron> BLstPhieuTron { set; }
        BindingList<ObjHopDong> BLstHopDong { set; }
        BindingList<ObjMeTron> BLstMeTron { set; }
        BindingList<ObjMeTronChiTiet> BLstMeTronChiTiet { set; }
        bool IsSuccessfulSaved { set; }
        List<FieldCode> LstPhieuTronStatus { set; }
    }
}

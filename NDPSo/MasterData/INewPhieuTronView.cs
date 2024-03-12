using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface INewPhieuTronView : IBase
    {
        ObjPhieuTron PhieuTron { set; }

        ObjHopDong HopDong { set; }

        BindingList<ObjMeTron> BLstMeTron { set; }

        BindingList<ObjMeTronChiTiet> BLstMeTronChiTiet { set; }

        BindingList<ObjTaiXe> BLstTaiXe { set; }

        BindingList<ObjXe> BLstXe { set; }

        int SLMeDuTinh { set; }

        Decimal KLDuTinhMeTron { set; }

        bool IsSuccessfulSaved { set; }
    }
}

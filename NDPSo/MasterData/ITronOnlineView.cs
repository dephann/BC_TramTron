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
    public interface ITronOnlineView : IBase, IPermission
    {
        BindingList<ObjNhanVien> BLstNhanVien { set; }

        BindingList<ObjTaiXe> BLstTaiXe { set; }

        BindingList<ObjXe> BLstXe { set; }

        BindingList<ObjPhieuTron> BLstPhieuTron { set; }

        BindingList<ObjMAC> BLstMAC { set; }

        BindingList<ObjMACSilo> BLstMACSilo { set; }

        BindingList<ObjSilo> BLstSilo { set; }

        BindingList<ObjSilo> BLstSiloLogicAG { set; }

        BindingList<ObjSilo> BLstSiloLogicAD { set; }

        BindingList<ObjSilo> BLstSiloLogicCE { set; }

        BindingList<ObjWeigh> BLstWeigh { set; }

        BindingList<ObjWeiSiloSaving> BLstWeiSiloSaving { set; }

        BindingList<ObjWeiSiloVisible> BLstWeiSiloVisible { set; }

        BindingList<ObjTimerPara> BLstTimerPara { set; }

        BindingList<ObjDuLieuTron> BLstDuLieuTron { set; }

        BindingList<ObjSilo> BLstSilo_DoAmHutAgg { set; }

        List<FieldCode> LstPhieuTronStatus { set; }

        List<FieldCode> LstDuLieuTronStatus { set; }

        ObjMeTron CurMeTron { set; }

        ObjMeTronChiTiet CurMeTronChiTiet { set; }
        ObjMeTronChiTietGiaoHang CurMeTronChiTietGiaoHang { set; }

        InitOnline IO { set; }

        SetPoint SP { set; }
        SetPoint SP_NotHD { set; }

        SendingToPLC SO { set; }

        //ReceivingOnline RO { set; }

        bool IsSuccessfulUpdatePT { set; }

        bool IsSuccessfulSaveTronOnline { set; }

        ObjPhieuTron SavingPhieuTron { set; }
    }
}


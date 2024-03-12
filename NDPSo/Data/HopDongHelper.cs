using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    public class HopDongHelper
    {
        public static string GenMemberValues(ObjHopDong obj) => string.Empty + "#1@#HopDongID#2@#" + (object)obj.HopDongID + "#1@#MaHopDong#2@#" + obj.MaHopDong + "#1@#TenHopDong#2@#" + obj.TenHopDong + "#1@#NgayHopDong#2@#" + (object)obj.NgayHopDong + "#1@#MoTa#2@#" + obj.MoTa + "#1@#KhachHangID#2@#" + (object)obj.KhachHangID + "#1@#CongTruongID#2@#" + (object)obj.CongTruongID + "#1@#MACID#2@#" + (object)obj.MACID + "#1@#DoSut#2@#" + obj.DoSut + "#1@#KLDatHang#2@#" + (object)obj.KLDatHang + "#1@#KLDaGiao#2@#" + (object)obj.KLDaGiao + "#1@#KLConLai#2@#" + (object)obj.KLConLai + "#1@#KLTaoPhieuTron#2@#" + (object)obj.KLTaoPhieuTron + "#1@#Status#2@#" + (object)obj.Status + "#1@#DLT_KLDuTinh#2@#" + (object)obj.DLT_KLDuTinh + "#1@#DLT_KLTronNhoNhat#2@#" + (object)obj.DLT_KLTronNhoNhat + "#1@#DLT_KLTronLonNhat#2@#" + (object)obj.DLT_KLTronLonNhat + "#1@#DLT_KLDuTinhCuaTungMe#2@#" + (object)obj.DLT_KLDuTinhCuaTungMe + "#1@#DLT_KLDuTinhCuaTungMe_NoiB#2@#" + (object)obj.DLT_KLDuTinhCuaTungMe_NoiB + "#1@#DLT_KLDuTinhCuaTungMe_NoiB_IsUsed#2@#" + obj.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed.ToString() + "#1@#DLT_KLBuTruMeCuoi#2@#" + (object)obj.DLT_KLBuTruMeCuoi + "#1@#DLT_SLMeDuTinh#2@#" + (object)obj.DLT_SLMeDuTinh + "#1@#DLT_KLXeChoLonNhat#2@#" + (object)obj.DLT_KLXeChoLonNhat + "#1@#DLT_MACSUMSiloValueCalc#2@#" + (object)obj.DLT_MACSUMSiloValueCalc + "#1@#DLT_MACSUMSiloValue#2@#" + (object)obj.DLT_MACSUMSiloValue + "#1@#CreationDate#2@#" + (object)obj.CreationDate + "#1@#CreatedBy#2@#" + (object)obj.CreatedBy + "#1@#LatestUpdateDate#2@#" + (object)obj.LatestUpdateDate + "#1@#LatestUpdatedBy#2@#" + (object)obj.LatestUpdatedBy + "#1@#VersionNo#2@#" + (object)obj.VersionNo;

        public static string GenMemberValues(HopDong ent) => string.Empty + "#1@#HopDongID#2@#" + (object)ent.HopDongID + "#1@#MaHopDong#2@#" + ent.MaHopDong + "#1@#TenHopDong#2@#" + ent.TenHopDong + "#1@#NgayHopDong#2@#" + (object)ent.NgayHopDong + "#1@#MoTa#2@#" + ent.MoTa + "#1@#KhachHangID#2@#" + (object)ent.KhachHangID + "#1@#CongTruongID#2@#" + (object)ent.CongTruongID + "#1@#MACID#2@#" + (object)ent.MACID + "#1@#DoSut#2@#" + ent.DoSut + "#1@#KLDatHang#2@#" + (object)ent.KLDatHang + "#1@#KLDaGiao#2@#" + (object)ent.KLDaGiao + "#1@#KLConLai#2@#" + (object)ent.KLConLai + "#1@#KLTaoPhieuTron#2@#" + (object)ent.KLTaoPhieuTron + "#1@#Status#2@#" + (object)ent.Status + "#1@#DLT_KLDuTinh#2@#" + (object)ent.DLT_KLDuTinh + "#1@#DLT_KLTronNhoNhat#2@#" + (object)ent.DLT_KLTronNhoNhat + "#1@#DLT_KLTronLonNhat#2@#" + (object)ent.DLT_KLTronLonNhat + "#1@#DLT_KLDuTinhCuaTungMe#2@#" + (object)ent.DLT_KLDuTinhCuaTungMe + "#1@#DLT_KLDuTinhCuaTungMe_NoiB#2@#" + (object)ent.DLT_KLDuTinhCuaTungMe_NoiB + "#1@#DLT_KLDuTinhCuaTungMe_NoiB_IsUsed#2@#" + ent.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed.ToString() + "#1@#DLT_KLBuTruMeCuoi#2@#" + (object)ent.DLT_KLBuTruMeCuoi + "#1@#DLT_SLMeDuTinh#2@#" + (object)ent.DLT_SLMeDuTinh + "#1@#DLT_KLXeChoLonNhat#2@#" + (object)ent.DLT_KLXeChoLonNhat + "#1@#DLT_MACSUMSiloValueCalc#2@#" + (object)ent.DLT_MACSUMSiloValueCalc + "#1@#DLT_MACSUMSiloValue#2@#" + (object)ent.DLT_MACSUMSiloValue + "#1@#CreationDate#2@#" + (object)ent.CreationDate + "#1@#CreatedBy#2@#" + (object)ent.CreatedBy + "#1@#LatestUpdateDate#2@#" + (object)ent.LatestUpdateDate + "#1@#LatestUpdatedBy#2@#" + (object)ent.LatestUpdatedBy + "#1@#VersionNo#2@#" + (object)ent.VersionNo;

        public static void CopyToObjHopDong(HopDong fromEnt, ObjHopDong toObj)
        {
            toObj.HopDongID = fromEnt.HopDongID;
            toObj.MaHopDong = fromEnt.MaHopDong;
            toObj.TenHopDong = fromEnt.TenHopDong;
            toObj.NgayHopDong = fromEnt.NgayHopDong;
            toObj.MoTa = fromEnt.MoTa;
            toObj.KhachHangID = fromEnt.KhachHangID;
            toObj.CongTruongID = fromEnt.CongTruongID;
            toObj.MACID = fromEnt.MACID;
            toObj.HangMucID = fromEnt.HangMucID;
            toObj.DoSut = fromEnt.DoSut;
            toObj.KLDatHang = fromEnt.KLDatHang;
            toObj.KLDaGiao = fromEnt.KLDaGiao;
            toObj.KLConLai = fromEnt.KLConLai;
            toObj.KLTaoPhieuTron = fromEnt.KLTaoPhieuTron;
            toObj.TongPhieu = fromEnt.TongPhieu;
            toObj.Status = fromEnt.Status;
            toObj.DLT_KLDuTinh = fromEnt.DLT_KLDuTinh;
            toObj.DLT_KLTronNhoNhat = fromEnt.DLT_KLTronNhoNhat;
            toObj.DLT_KLTronLonNhat = fromEnt.DLT_KLTronLonNhat;
            toObj.DLT_KLDuTinhCuaTungMe = fromEnt.DLT_KLDuTinhCuaTungMe;
            toObj.DLT_KLDuTinhCuaTungMe_NoiB = fromEnt.DLT_KLDuTinhCuaTungMe_NoiB;
            toObj.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed = fromEnt.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed;
            toObj.DLT_KLBuTruMeCuoi = fromEnt.DLT_KLBuTruMeCuoi;
            toObj.DLT_SLMeDuTinh = fromEnt.DLT_SLMeDuTinh;
            toObj.DLT_KLXeChoLonNhat = fromEnt.DLT_KLXeChoLonNhat;
            toObj.DLT_MACSUMSiloValueCalc = fromEnt.DLT_MACSUMSiloValueCalc;
            toObj.DLT_MACSUMSiloValue = fromEnt.DLT_MACSUMSiloValue;
            toObj.CreationDate = fromEnt.CreationDate;
            toObj.CreatedBy = fromEnt.CreatedBy;
            toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
            toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
            toObj.VersionNo = fromEnt.VersionNo;
            if (toObj.HopDongID <= 0)
                return;
            toObj.IsNewObject = false;
        }

        public static void CopyToEntHopDong(ObjHopDong fromObj, HopDong toEnt)
        {
            toEnt.HopDongID = fromObj.HopDongID;
            toEnt.MaHopDong = fromObj.MaHopDong;
            toEnt.TenHopDong = fromObj.TenHopDong;
            toEnt.NgayHopDong = fromObj.NgayHopDong;
            toEnt.MoTa = fromObj.MoTa;
            toEnt.KhachHangID = fromObj.KhachHangID;
            toEnt.CongTruongID = fromObj.CongTruongID;
            toEnt.MACID = fromObj.MACID;
            toEnt.HangMucID = fromObj.HangMucID;
            toEnt.DoSut = fromObj.DoSut;
            toEnt.KLDatHang = fromObj.KLDatHang;
            toEnt.KLDaGiao = fromObj.KLDaGiao;
            toEnt.KLConLai = fromObj.KLConLai;
            toEnt.KLTaoPhieuTron = fromObj.KLTaoPhieuTron;
            toEnt.TongPhieu = fromObj.TongPhieu;
            toEnt.Status = fromObj.Status;
            toEnt.DLT_KLDuTinh = fromObj.DLT_KLDuTinh;
            toEnt.DLT_KLTronNhoNhat = fromObj.DLT_KLTronNhoNhat;
            toEnt.DLT_KLTronLonNhat = fromObj.DLT_KLTronLonNhat;
            toEnt.DLT_KLDuTinhCuaTungMe = fromObj.DLT_KLDuTinhCuaTungMe;
            toEnt.DLT_KLDuTinhCuaTungMe_NoiB = fromObj.DLT_KLDuTinhCuaTungMe_NoiB;
            toEnt.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed = fromObj.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed;
            toEnt.DLT_KLBuTruMeCuoi = fromObj.DLT_KLBuTruMeCuoi;
            toEnt.DLT_SLMeDuTinh = fromObj.DLT_SLMeDuTinh;
            toEnt.DLT_KLXeChoLonNhat = fromObj.DLT_KLXeChoLonNhat;
            toEnt.DLT_MACSUMSiloValueCalc = fromObj.DLT_MACSUMSiloValueCalc;
            toEnt.DLT_MACSUMSiloValue = fromObj.DLT_MACSUMSiloValue;
            toEnt.CreationDate = fromObj.CreationDate;
            toEnt.CreatedBy = fromObj.CreatedBy;
            toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
            toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
            toEnt.VersionNo = fromObj.VersionNo;
        }

        public static ObjHopDong BuildNewObjHopDong(HopDong entHopDong)
        {
            ObjHopDong toObj = new ObjHopDong();
            HopDongHelper.CopyToObjHopDong(entHopDong, toObj);
            return toObj;
        }

        public static IList<ObjHopDong> BuildListObjHopDong(IList<HopDong> lstEntHopDong)
        {
            IList<ObjHopDong> objHopDongList = (IList<ObjHopDong>)new List<ObjHopDong>();
            foreach (HopDong entHopDong in (IEnumerable<HopDong>)lstEntHopDong)
                objHopDongList.Add(HopDongHelper.BuildNewObjHopDong(entHopDong));
            return objHopDongList;
        }

        public static HopDong BuildNewEntHopDong(ObjHopDong objHopDong)
        {
            HopDong toEnt = new HopDong();
            HopDongHelper.CopyToEntHopDong(objHopDong, toEnt);
            return toEnt;
        }

        public static IList<HopDong> BuildListEntHopDong(IList<ObjHopDong> lstObjHopDong)
        {
            IList<HopDong> hopDongList = (IList<HopDong>)new List<HopDong>();
            foreach (ObjHopDong objHopDong in (IEnumerable<ObjHopDong>)lstObjHopDong)
                hopDongList.Add(HopDongHelper.BuildNewEntHopDong(objHopDong));
            return hopDongList;
        }

        public static void CopyToDataRowHopDong(ObjHopDong fromObj, DataRow toDataRow)
        {
            toDataRow["HopDongID"] = (object)fromObj.HopDongID;
            toDataRow["MaHopDong"] = (object)fromObj.MaHopDong;
            toDataRow["TenHopDong"] = (object)fromObj.TenHopDong;
            toDataRow["NgayHopDong"] = (object)fromObj.NgayHopDong;
            toDataRow["MoTa"] = (object)fromObj.MoTa;
            toDataRow["KhachHangID"] = (object)fromObj.KhachHangID;
            toDataRow["CongTruongID"] = (object)fromObj.CongTruongID;
            toDataRow["MACID"] = (object)fromObj.MACID;
            toDataRow["DoSut"] = (object)fromObj.DoSut;
            toDataRow["KLDatHang"] = (object)fromObj.KLDatHang;
            toDataRow["KLDaGiao"] = (object)fromObj.KLDaGiao;
            toDataRow["KLConLai"] = (object)fromObj.KLConLai;
            toDataRow["KLTaoPhieuTron"] = (object)fromObj.KLTaoPhieuTron;
            toDataRow["TongPhieu"] = (object)fromObj.TongPhieu;
            toDataRow["Status"] = (object)fromObj.Status;
            toDataRow["DLT_KLDuTinh"] = (object)fromObj.DLT_KLDuTinh;
            toDataRow["DLT_KLTronNhoNhat"] = (object)fromObj.DLT_KLTronNhoNhat;
            toDataRow["DLT_KLTronLonNhat"] = (object)fromObj.DLT_KLTronLonNhat;
            toDataRow["DLT_KLDuTinhCuaTungMe"] = (object)fromObj.DLT_KLDuTinhCuaTungMe;
            toDataRow["DLT_KLDuTinhCuaTungMe_NoiB"] = (object)fromObj.DLT_KLDuTinhCuaTungMe_NoiB;
            toDataRow["DLT_KLDuTinhCuaTungMe_NoiB_IsUsed"] = (object)fromObj.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed;
            toDataRow["DLT_KLBuTruMeCuoi"] = (object)fromObj.DLT_KLBuTruMeCuoi;
            toDataRow["DLT_SLMeDuTinh"] = (object)fromObj.DLT_SLMeDuTinh;
            toDataRow["DLT_KLXeChoLonNhat"] = (object)fromObj.DLT_KLXeChoLonNhat;
            toDataRow["DLT_MACSUMSiloValueCalc"] = (object)fromObj.DLT_MACSUMSiloValueCalc;
            toDataRow["DLT_MACSUMSiloValue"] = (object)fromObj.DLT_MACSUMSiloValue;
            toDataRow["NPKhachHangMaKhachHang"] = (object)fromObj.NPKhachHangMaKhachHang;
            toDataRow["NPKhachHangTenKhachHang"] = (object)fromObj.NPKhachHangTenKhachHang;
            toDataRow["NPCongTruongMaCongTruong"] = (object)fromObj.NPCongTruongMaCongTruong;
            toDataRow["NPCongTruongTenCongTruong"] = (object)fromObj.NPCongTruongTenCongTruong;
            toDataRow["NPMACMaMAC"] = (object)fromObj.NPMACMaMAC;
            toDataRow["NPMACTenMAC"] = (object)fromObj.NPMACTenMAC;
            toDataRow["NPMACThemBotNuoc1"] = (object)fromObj.NPMACThemBotNuoc1;
            toDataRow["NPMACThemBotNuoc2"] = (object)fromObj.NPMACThemBotNuoc2;
        }
    }
}

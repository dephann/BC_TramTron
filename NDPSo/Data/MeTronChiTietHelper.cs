using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    public class MeTronChiTietHelper
    {
        public static string GenMemberValues(ObjMeTronChiTiet obj) => string.Empty + "#1@#MeTronChiTietID#2@#" + (object)obj.MeTronChiTietID + "#1@#MeTronID#2@#" + (object)obj.MeTronID + "#1@#MACSiloID#2@#" + (object)obj.MACSiloID + "#1@#Value#2@#" + (object)obj.Value + "#1@#ValueBat#2@#" + (object)obj.ValueBat + "#1@#SiloValue#2@#" + (object)obj.SiloValue + "#1@#SaiSoDuoi#2@#" + (object)obj.SaiSoDuoi + "#1@#SaiSoTren#2@#" + (object)obj.SaiSoTren + "#1@#KLCanNhoNhat#2@#" + (object)obj.KLCanNhoNhat + "#1@#KLCanLonNhat#2@#" + (object)obj.KLCanLonNhat + "#1@#TGNhapNhaOn#2@#" + (object)obj.TGNhapNhaOn + "#1@#TGNhapNhaOff#2@#" + (object)obj.TGNhapNhaOff + "#1@#TGKiemTraVatLieuRoi#2@#" + (object)obj.TGKiemTraVatLieuRoi + "#1@#KLRoi#2@#" + (object)obj.KLRoi + "#1@#KLDT_Tu1#2@#" + (object)obj.KLDT_Tu1 + "#1@#KLDT_Tu2#2@#" + (object)obj.KLDT_Tu2 + "#1@#KLDT_Tu3#2@#" + (object)obj.KLDT_Tu3 + "#1@#KLDT_Den1#2@#" + (object)obj.KLDT_Den1 + "#1@#KLDT_Den2#2@#" + (object)obj.KLDT_Den2 + "#1@#KLDT_Den3#2@#" + (object)obj.KLDT_Den3 + "#1@#TinhDoHutNuocID#2@#" + (object)obj.TinhDoHutNuocID + "#1@#DoAm_NhomSlioAgg#2@#" + (object)obj.DoAm_NhomSlioAgg + "#1@#DoHutNuoc_NhomSiloAgg#2@#" + (object)obj.DoHutNuoc_NhomSiloAgg + "#1@#SoiTrongCat_SiloId_NhomSiloAgg#2@#" + (object)obj.SoiTrongCat_SiloId_NhomSiloAgg + "#1@#SoiTrongCat_Percent_NhomSiloAgg#2@#" + (object)obj.SoiTrongCat_Percent_NhomSiloAgg + "#1@#MaterialID#2@#" + (object)obj.MaterialID + "#1@#MaterialCode#2@#" + obj.MaterialCode + "#1@#MaterialName#2@#" + obj.MaterialName + "#1@#MaSilo#2@#" + obj.MaSilo + "#1@#STTSiloPLC#2@#" + (object)obj.STTSiloPLC + "#1@#IsManual#2@#" + (object)obj.IsManual + "#1@#NgayMTCT#2@#" + (object)obj.NgayMTCT + "#1@#PLCSaveId#2@#" + (object)obj.PLCSaveId + "#1@#CreationDate#2@#" + (object)obj.CreationDate + "#1@#CreatedBy#2@#" + (object)obj.CreatedBy + "#1@#LatestUpdateDate#2@#" + (object)obj.LatestUpdateDate + "#1@#LatestUpdatedBy#2@#" + (object)obj.LatestUpdatedBy + "#1@#VersionNo#2@#" + (object)obj.VersionNo;

        public static string GenMemberValues(MeTronChiTiet ent) => string.Empty + "#1@#MeTronChiTietID#2@#" + (object)ent.MeTronChiTietID + "#1@#MeTronID#2@#" + (object)ent.MeTronID + "#1@#MACSiloID#2@#" + (object)ent.MACSiloID + "#1@#Value#2@#" + (object)ent.Value + "#1@#ValueBat#2@#" + (object)ent.ValueBat + "#1@#SiloValue#2@#" + (object)ent.SiloValue + "#1@#SaiSoDuoi#2@#" + (object)ent.SaiSoDuoi + "#1@#SaiSoTren#2@#" + (object)ent.SaiSoTren + "#1@#KLCanNhoNhat#2@#" + (object)ent.KLCanNhoNhat + "#1@#KLCanLonNhat#2@#" + (object)ent.KLCanLonNhat + "#1@#TGNhapNhaOn#2@#" + (object)ent.TGNhapNhaOn + "#1@#TGNhapNhaOff#2@#" + (object)ent.TGNhapNhaOff + "#1@#TGKiemTraVatLieuRoi#2@#" + (object)ent.TGKiemTraVatLieuRoi + "#1@#KLRoi#2@#" + (object)ent.KLRoi + "#1@#KLDT_Tu1#2@#" + (object)ent.KLDT_Tu1 + "#1@#KLDT_Tu2#2@#" + (object)ent.KLDT_Tu2 + "#1@#KLDT_Tu3#2@#" + (object)ent.KLDT_Tu3 + "#1@#KLDT_Den1#2@#" + (object)ent.KLDT_Den1 + "#1@#KLDT_Den2#2@#" + (object)ent.KLDT_Den2 + "#1@#KLDT_Den3#2@#" + (object)ent.KLDT_Den3 + "#1@#TinhDoHutNuocID#2@#" + (object)ent.TinhDoHutNuocID + "#1@#DoAm_NhomSlioAgg#2@#" + (object)ent.DoAm_NhomSlioAgg + "#1@#DoHutNuoc_NhomSiloAgg#2@#" + (object)ent.DoHutNuoc_NhomSiloAgg + "#1@#SoiTrongCat_SiloId_NhomSiloAgg#2@#" + (object)ent.SoiTrongCat_SiloId_NhomSiloAgg + "#1@#SoiTrongCat_Percent_NhomSiloAgg#2@#" + (object)ent.SoiTrongCat_Percent_NhomSiloAgg + "#1@#MaterialID#2@#" + (object)ent.MaterialID + "#1@#MaterialCode#2@#" + ent.MaterialCode + "#1@#MaterialName#2@#" + ent.MaterialName + "#1@#MaSilo#2@#" + ent.MaSilo + "#1@#STTSiloPLC#2@#" + (object)ent.STTSiloPLC + "#1@#IsManual#2@#" + (object)ent.IsManual + "#1@#NgayMTCT#2@#" + (object)ent.NgayMTCT + "#1@#PLCSaveId#2@#" + (object)ent.PLCSaveId + "#1@#CreationDate#2@#" + (object)ent.CreationDate + "#1@#CreatedBy#2@#" + (object)ent.CreatedBy + "#1@#LatestUpdateDate#2@#" + (object)ent.LatestUpdateDate + "#1@#LatestUpdatedBy#2@#" + (object)ent.LatestUpdatedBy + "#1@#VersionNo#2@#" + (object)ent.VersionNo;

        public static void CopyToObjMeTronChiTiet(MeTronChiTiet fromEnt, ObjMeTronChiTiet toObj)
        {
            toObj.MeTronChiTietID = fromEnt.MeTronChiTietID;
            toObj.MeTronID = fromEnt.MeTronID;
            toObj.MACSiloID = fromEnt.MACSiloID;
            toObj.Value = fromEnt.Value;
            toObj.ValueBat = fromEnt.ValueBat;
            toObj.ValueBatAuto = fromEnt.ValueBatAuto;
            toObj.ValueBatMan = fromEnt.ValueBatMan;
            toObj.ValueTol = fromEnt.ValueTol;
            toObj.ValuePerTol = fromEnt.ValuePerTol;
            toObj.SiloValue = fromEnt.SiloValue;
            toObj.SaiSoDuoi = fromEnt.SaiSoDuoi;
            toObj.SaiSoTren = fromEnt.SaiSoTren;
            toObj.KLCanNhoNhat = fromEnt.KLCanNhoNhat;
            toObj.KLCanLonNhat = fromEnt.KLCanLonNhat;
            toObj.TGNhapNhaOn = fromEnt.TGNhapNhaOn;
            toObj.TGNhapNhaOff = fromEnt.TGNhapNhaOff;
            toObj.TGKiemTraVatLieuRoi = fromEnt.TGKiemTraVatLieuRoi;
            toObj.KLRoi = fromEnt.KLRoi;
            toObj.KLDT_Tu1 = fromEnt.KLDT_Tu1;
            toObj.KLDT_Tu2 = fromEnt.KLDT_Tu2;
            toObj.KLDT_Tu3 = fromEnt.KLDT_Tu3;
            toObj.KLDT_Den1 = fromEnt.KLDT_Den1;
            toObj.KLDT_Den2 = fromEnt.KLDT_Den2;
            toObj.KLDT_Den3 = fromEnt.KLDT_Den3;
            toObj.TinhDoHutNuocID = fromEnt.TinhDoHutNuocID;
            toObj.DoAm_NhomSlioAgg = fromEnt.DoAm_NhomSlioAgg;
            toObj.DoHutNuoc_NhomSiloAgg = fromEnt.DoHutNuoc_NhomSiloAgg;
            toObj.SoiTrongCat_SiloId_NhomSiloAgg = fromEnt.SoiTrongCat_SiloId_NhomSiloAgg;
            toObj.SoiTrongCat_Percent_NhomSiloAgg = fromEnt.SoiTrongCat_Percent_NhomSiloAgg;
            toObj.MaterialID = fromEnt.MaterialID;
            toObj.MaterialCode = fromEnt.MaterialCode;
            toObj.MaterialName = fromEnt.MaterialName;
            toObj.MaSilo = fromEnt.MaSilo;
            toObj.STTSiloPLC = fromEnt.STTSiloPLC;
            toObj.IsManual = fromEnt.IsManual;
            toObj.NgayMTCT = fromEnt.NgayMTCT;
            toObj.PLCSaveId = fromEnt.PLCSaveId;
            toObj.CreationDate = fromEnt.CreationDate;
            toObj.CreatedBy = fromEnt.CreatedBy;
            toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
            toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
            toObj.VersionNo = fromEnt.VersionNo;
            if (toObj.MeTronChiTietID <= 0)
                return;
            toObj.IsNewObject = false;
        }

        public static void CopyToEntMeTronChiTiet(ObjMeTronChiTiet fromObj, MeTronChiTiet toEnt)
        {
            toEnt.MeTronChiTietID = fromObj.MeTronChiTietID;
            toEnt.MeTronID = fromObj.MeTronID;
            toEnt.MACSiloID = fromObj.MACSiloID;
            toEnt.Value = fromObj.Value;
            toEnt.ValueBat = fromObj.ValueBat;
            toEnt.ValueBatAuto = fromObj.ValueBatAuto;
            toEnt.ValueBatMan = fromObj.ValueBatMan;
            toEnt.ValueTol = fromObj.ValueTol;
            toEnt.ValuePerTol = fromObj.ValuePerTol;
            toEnt.SiloValue = fromObj.SiloValue;
            toEnt.SaiSoDuoi = fromObj.SaiSoDuoi;
            toEnt.SaiSoTren = fromObj.SaiSoTren;
            toEnt.KLCanNhoNhat = fromObj.KLCanNhoNhat;
            toEnt.KLCanLonNhat = fromObj.KLCanLonNhat;
            toEnt.TGNhapNhaOn = fromObj.TGNhapNhaOn;
            toEnt.TGNhapNhaOff = fromObj.TGNhapNhaOff;
            toEnt.TGKiemTraVatLieuRoi = fromObj.TGKiemTraVatLieuRoi;
            toEnt.KLRoi = fromObj.KLRoi;
            toEnt.KLDT_Tu1 = fromObj.KLDT_Tu1;
            toEnt.KLDT_Tu2 = fromObj.KLDT_Tu2;
            toEnt.KLDT_Tu3 = fromObj.KLDT_Tu3;
            toEnt.KLDT_Den1 = fromObj.KLDT_Den1;
            toEnt.KLDT_Den2 = fromObj.KLDT_Den2;
            toEnt.KLDT_Den3 = fromObj.KLDT_Den3;
            toEnt.TinhDoHutNuocID = fromObj.TinhDoHutNuocID;
            toEnt.DoAm_NhomSlioAgg = fromObj.DoAm_NhomSlioAgg;
            toEnt.DoHutNuoc_NhomSiloAgg = fromObj.DoHutNuoc_NhomSiloAgg;
            toEnt.SoiTrongCat_SiloId_NhomSiloAgg = fromObj.SoiTrongCat_SiloId_NhomSiloAgg;
            toEnt.SoiTrongCat_Percent_NhomSiloAgg = fromObj.SoiTrongCat_Percent_NhomSiloAgg;
            toEnt.MaterialID = fromObj.MaterialID;
            toEnt.MaterialCode = fromObj.MaterialCode;
            toEnt.MaterialName = fromObj.MaterialName;
            toEnt.MaSilo = fromObj.MaSilo;
            toEnt.STTSiloPLC = fromObj.STTSiloPLC;
            toEnt.IsManual = fromObj.IsManual;
            toEnt.NgayMTCT = fromObj.NgayMTCT;
            toEnt.PLCSaveId = fromObj.PLCSaveId;
            toEnt.CreationDate = fromObj.CreationDate;
            toEnt.CreatedBy = fromObj.CreatedBy;
            toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
            toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
            toEnt.VersionNo = fromObj.VersionNo;
        }

        public static ObjMeTronChiTiet BuildNewObjMeTronChiTiet(MeTronChiTiet entMeTronChiTiet)
        {
            ObjMeTronChiTiet toObj = new ObjMeTronChiTiet();
            MeTronChiTietHelper.CopyToObjMeTronChiTiet(entMeTronChiTiet, toObj);
            return toObj;
        }

        public static IList<ObjMeTronChiTiet> BuildListObjMeTronChiTiet(
          IList<MeTronChiTiet> lstEntMeTronChiTiet)
        {
            IList<ObjMeTronChiTiet> objMeTronChiTietList = (IList<ObjMeTronChiTiet>)new List<ObjMeTronChiTiet>();
            foreach (MeTronChiTiet entMeTronChiTiet in (IEnumerable<MeTronChiTiet>)lstEntMeTronChiTiet)
                objMeTronChiTietList.Add(MeTronChiTietHelper.BuildNewObjMeTronChiTiet(entMeTronChiTiet));
            return objMeTronChiTietList;
        }

        public static MeTronChiTiet BuildNewEntMeTronChiTiet(ObjMeTronChiTiet objMeTronChiTiet)
        {
            MeTronChiTiet toEnt = new MeTronChiTiet();
            MeTronChiTietHelper.CopyToEntMeTronChiTiet(objMeTronChiTiet, toEnt);
            return toEnt;
        }

        public static IList<MeTronChiTiet> BuildListEntMeTronChiTiet(
          IList<ObjMeTronChiTiet> lstObjMeTronChiTiet)
        {
            IList<MeTronChiTiet> meTronChiTietList = (IList<MeTronChiTiet>)new List<MeTronChiTiet>();
            foreach (ObjMeTronChiTiet objMeTronChiTiet in (IEnumerable<ObjMeTronChiTiet>)lstObjMeTronChiTiet)
                meTronChiTietList.Add(MeTronChiTietHelper.BuildNewEntMeTronChiTiet(objMeTronChiTiet));
            return meTronChiTietList;
        }
    }
}


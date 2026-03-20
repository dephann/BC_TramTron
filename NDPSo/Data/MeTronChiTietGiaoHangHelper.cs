using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    internal class MeTronChiTietGiaoHangHelper
    {
        public static void CopyToObjMeTronChiTiet(MeTronChiTietGiaoHang fromEnt, ObjMeTronChiTietGiaoHang toObj)
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

        public static void CopyToEntMeTronChiTiet(ObjMeTronChiTietGiaoHang fromObj, MeTronChiTietGiaoHang toEnt)
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

        public static ObjMeTronChiTietGiaoHang BuildNewObjMeTronChiTiet(MeTronChiTietGiaoHang entMeTronChiTiet)
        {
            ObjMeTronChiTietGiaoHang toObj = new ObjMeTronChiTietGiaoHang();
            MeTronChiTietGiaoHangHelper.CopyToObjMeTronChiTiet(entMeTronChiTiet, toObj);
            return toObj;
        }

        public static IList<ObjMeTronChiTietGiaoHang> BuildListObjMeTronChiTiet(
          IList<MeTronChiTietGiaoHang> lstEntMeTronChiTiet)
        {
            IList<ObjMeTronChiTietGiaoHang> objMeTronChiTietList = (IList<ObjMeTronChiTietGiaoHang>)new List<ObjMeTronChiTietGiaoHang>();
            foreach (MeTronChiTietGiaoHang entMeTronChiTiet in (IEnumerable<MeTronChiTietGiaoHang>)lstEntMeTronChiTiet)
                objMeTronChiTietList.Add(MeTronChiTietGiaoHangHelper.BuildNewObjMeTronChiTiet(entMeTronChiTiet));
            return objMeTronChiTietList;
        }

        public static MeTronChiTietGiaoHang BuildNewEntMeTronChiTiet(ObjMeTronChiTietGiaoHang objMeTronChiTiet)
        {
            MeTronChiTietGiaoHang toEnt = new MeTronChiTietGiaoHang();
            MeTronChiTietGiaoHangHelper.CopyToEntMeTronChiTiet(objMeTronChiTiet, toEnt);
            return toEnt;
        }

        public static IList<MeTronChiTietGiaoHang> BuildListEntMeTronChiTiet(
          IList<ObjMeTronChiTietGiaoHang> lstObjMeTronChiTiet)
        {
            IList<MeTronChiTietGiaoHang> meTronChiTietList = (IList<MeTronChiTietGiaoHang>)new List<MeTronChiTietGiaoHang>();
            foreach (ObjMeTronChiTietGiaoHang objMeTronChiTiet in (IEnumerable<ObjMeTronChiTietGiaoHang>)lstObjMeTronChiTiet)
                meTronChiTietList.Add(MeTronChiTietGiaoHangHelper.BuildNewEntMeTronChiTiet(objMeTronChiTiet));
            return meTronChiTietList;
        }
    }
}

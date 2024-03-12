using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class SiloHelper
	{
		public static string GenMemberValues(ObjSilo obj)
		{
			string r = string.Empty;
			r = r + "#1@#SiloID#2@#" + obj.SiloID;
			r = r + "#1@#MaSilo#2@#" + obj.MaSilo;
			r = r + "#1@#TenSilo#2@#" + obj.TenSilo;
			r = r + "#1@#NhomSiloID#2@#" + obj.NhomSiloID;
			r = r + "#1@#SoTT#2@#" + obj.SoTT;
			r = r + "#1@#SaiSoDuoi#2@#" + obj.SaiSoDuoi;
			r = r + "#1@#SaiSoTren#2@#" + obj.SaiSoTren;
			r = r + "#1@#KLCanNhoNhat#2@#" + obj.KLCanNhoNhat;
			r = r + "#1@#KLCanLonNhat#2@#" + obj.KLCanLonNhat;
			r = r + "#1@#TGNhapNhaOn#2@#" + obj.TGNhapNhaOn;
			r = r + "#1@#TGNhapNhaOff#2@#" + obj.TGNhapNhaOff;
			r = r + "#1@#TGKiemTraVatLieuRoi#2@#" + obj.TGKiemTraVatLieuRoi;
			r = r + "#1@#KLRoi#2@#" + obj.KLRoi;
			r = r + "#1@#K_Pulse#2@#" + obj.K_Pulse;
			r = r + "#1@#KLDT_Tu1#2@#" + obj.KLDT_Tu1;
			r = r + "#1@#KLDT_Tu2#2@#" + obj.KLDT_Tu2;
			r = r + "#1@#KLDT_Tu3#2@#" + obj.KLDT_Tu3;
			r = r + "#1@#KLDT_Den1#2@#" + obj.KLDT_Den1;
			r = r + "#1@#KLDT_Den2#2@#" + obj.KLDT_Den2;
			r = r + "#1@#KLDT_Den3#2@#" + obj.KLDT_Den3;
			r = r + "#1@#KLDT_DungTruoc1#2@#" + obj.KLDT_DungTruoc1;
			r = r + "#1@#KLDT_DungTruoc2#2@#" + obj.KLDT_DungTruoc2;
			r = r + "#1@#KLDT_DungTruoc3#2@#" + obj.KLDT_DungTruoc3;
			r = r + "#1@#TinhDoHutNuocID#2@#" + obj.TinhDoHutNuocID;
			r = r + "#1@#TinhDoHutNuocName#2@#" + obj.TinhDoHutNuocName;
			r = r + "#1@#DoAm_NhomSlioAgg#2@#" + obj.DoAm_NhomSlioAgg;
			r = r + "#1@#DoHutNuoc_NhomSiloAgg#2@#" + obj.DoHutNuoc_NhomSiloAgg;
			r = r + "#1@#SoiTrongCat_NhomSiloAgg#2@#" + obj.SoiTrongCat_NhomSiloAgg;
			r = r + "#1@#SoiTrongCat_TruVaoSilo_NhomSiloAgg#2@#" + obj.SoiTrongCat_TruVaoSilo_NhomSiloAgg;
			r = r + "#1@#MaterialID#2@#" + obj.MaterialID;
			r = r + "#1@#MaterialCode#2@#" + obj.MaterialCode;
			r = r + "#1@#MaterialName#2@#" + obj.MaterialName;
			r = r + "#1@#Activated#2@#" + obj.Activated;
			r = r + "#1@#CreationDate#2@#" + obj.CreationDate;
			r = r + "#1@#CreatedBy#2@#" + obj.CreatedBy;
			r = r + "#1@#LatestUpdateDate#2@#" + obj.LatestUpdateDate;
			r = r + "#1@#LatestUpdatedBy#2@#" + obj.LatestUpdatedBy;
			return r + "#1@#VersionNo#2@#" + obj.VersionNo;
		}

		public static string GenMemberValues(Silo ent)
		{
			string r = string.Empty;
			r = r + "#1@#SiloID#2@#" + ent.SiloID;
			r = r + "#1@#MaSilo#2@#" + ent.MaSilo;
			r = r + "#1@#TenSilo#2@#" + ent.TenSilo;
			r = r + "#1@#NhomSiloID#2@#" + ent.NhomSiloID;
			r = r + "#1@#SoTT#2@#" + ent.SoTT;
			r = r + "#1@#SaiSoDuoi#2@#" + ent.SaiSoDuoi;
			r = r + "#1@#SaiSoTren#2@#" + ent.SaiSoTren;
			r = r + "#1@#KLCanNhoNhat#2@#" + ent.KLCanNhoNhat;
			r = r + "#1@#KLCanLonNhat#2@#" + ent.KLCanLonNhat;
			r = r + "#1@#TGNhapNhaOn#2@#" + ent.TGNhapNhaOn;
			r = r + "#1@#TGNhapNhaOff#2@#" + ent.TGNhapNhaOff;
			r = r + "#1@#TGKiemTraVatLieuRoi#2@#" + ent.TGKiemTraVatLieuRoi;
			r = r + "#1@#KLRoi#2@#" + ent.KLRoi;
			r = r + "#1@#K_Pulse#2@#" + ent.K_Pulse;
			r = r + "#1@#KLDT_Tu1#2@#" + ent.KLDT_Tu1;
			r = r + "#1@#KLDT_Tu2#2@#" + ent.KLDT_Tu2;
			r = r + "#1@#KLDT_Tu3#2@#" + ent.KLDT_Tu3;
			r = r + "#1@#KLDT_Den1#2@#" + ent.KLDT_Den1;
			r = r + "#1@#KLDT_Den2#2@#" + ent.KLDT_Den2;
			r = r + "#1@#KLDT_Den3#2@#" + ent.KLDT_Den3;
			r = r + "#1@#KLDT_DungTruoc1#2@#" + ent.KLDT_DungTruoc1;
			r = r + "#1@#KLDT_DungTruoc2#2@#" + ent.KLDT_DungTruoc2;
			r = r + "#1@#KLDT_DungTruoc3#2@#" + ent.KLDT_DungTruoc3;
			r = r + "#1@#TinhDoHutNuocID#2@#" + ent.TinhDoHutNuocID;
			r = r + "#1@#TinhDoHutNuocName#2@#" + ent.TinhDoHutNuocName;
			r = r + "#1@#DoAm_NhomSlioAgg#2@#" + ent.DoAm_NhomSlioAgg;
			r = r + "#1@#DoHutNuoc_NhomSiloAgg#2@#" + ent.DoHutNuoc_NhomSiloAgg;
			r = r + "#1@#SoiTrongCat_NhomSiloAgg#2@#" + ent.SoiTrongCat_NhomSiloAgg;
			r = r + "#1@#SoiTrongCat_TruVaoSilo_NhomSiloAgg#2@#" + ent.SoiTrongCat_TruVaoSilo_NhomSiloAgg;
			r = r + "#1@#MaterialID#2@#" + ent.MaterialID;
			r = r + "#1@#MaterialCode#2@#" + ent.MaterialCode;
			r = r + "#1@#MaterialName#2@#" + ent.MaterialName;
			r = r + "#1@#Activated#2@#" + ent.Activated;
			r = r + "#1@#CreationDate#2@#" + ent.CreationDate;
			r = r + "#1@#CreatedBy#2@#" + ent.CreatedBy;
			r = r + "#1@#LatestUpdateDate#2@#" + ent.LatestUpdateDate;
			r = r + "#1@#LatestUpdatedBy#2@#" + ent.LatestUpdatedBy;
			return r + "#1@#VersionNo#2@#" + ent.VersionNo;
		}

		public static void CopyToObjSilo(Silo fromEnt, ObjSilo toObj)
		{
			toObj.SiloID = fromEnt.SiloID;
			toObj.MaSilo = fromEnt.MaSilo;
			toObj.TenSilo = fromEnt.TenSilo;
			toObj.NhomSiloID = fromEnt.NhomSiloID;
			toObj.SoTT = fromEnt.SoTT;
			toObj.SaiSoDuoi = fromEnt.SaiSoDuoi;
			toObj.SaiSoTren = fromEnt.SaiSoTren;
			toObj.KLCanNhoNhat = fromEnt.KLCanNhoNhat;
			toObj.KLCanLonNhat = fromEnt.KLCanLonNhat;
			toObj.TGNhapNhaOn = fromEnt.TGNhapNhaOn;
			toObj.TGNhapNhaOff = fromEnt.TGNhapNhaOff;
			toObj.TGKiemTraVatLieuRoi = fromEnt.TGKiemTraVatLieuRoi;
			toObj.KLRoi = fromEnt.KLRoi;
			toObj.K_Pulse = fromEnt.K_Pulse;
			toObj.KLDT_Tu1 = fromEnt.KLDT_Tu1;
			toObj.KLDT_Tu2 = fromEnt.KLDT_Tu2;
			toObj.KLDT_Tu3 = fromEnt.KLDT_Tu3;
			toObj.KLDT_Den1 = fromEnt.KLDT_Den1;
			toObj.KLDT_Den2 = fromEnt.KLDT_Den2;
			toObj.KLDT_Den3 = fromEnt.KLDT_Den3;
			toObj.KLDT_DungTruoc1 = fromEnt.KLDT_DungTruoc1;
			toObj.KLDT_DungTruoc2 = fromEnt.KLDT_DungTruoc2;
			toObj.KLDT_DungTruoc3 = fromEnt.KLDT_DungTruoc3;
			toObj.TinhDoHutNuocID = fromEnt.TinhDoHutNuocID;
			toObj.TinhDoHutNuocName = fromEnt.TinhDoHutNuocName;
			toObj.DoAm_NhomSlioAgg = fromEnt.DoAm_NhomSlioAgg;
			toObj.DoHutNuoc_NhomSiloAgg = fromEnt.DoHutNuoc_NhomSiloAgg;
			toObj.SoiTrongCat_NhomSiloAgg = fromEnt.SoiTrongCat_NhomSiloAgg;
			toObj.SoiTrongCat_TruVaoSilo_NhomSiloAgg = fromEnt.SoiTrongCat_TruVaoSilo_NhomSiloAgg;
			toObj.MaterialID = fromEnt.MaterialID;
			toObj.MaterialCode = fromEnt.MaterialCode;
			toObj.MaterialName = fromEnt.MaterialName;
			toObj.Activated = fromEnt.Activated;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			toObj.VersionNo = fromEnt.VersionNo;
			if (toObj.SiloID > 0)
			{
				toObj.IsNewObject = false;
			}
			if(fromEnt.Material != null)
            {
				toObj.MaterialID = fromEnt.Material.MaterialID;
				toObj.MaterialCode = fromEnt.Material.MaterialCode;
				toObj.MaterialName = fromEnt.Material.MaterialName;
            }
		}

		public static void CopyToEntSilo(ObjSilo fromObj, Silo toEnt)
		{
			toEnt.SiloID = fromObj.SiloID;
			toEnt.MaSilo = fromObj.MaSilo;
			toEnt.TenSilo = fromObj.TenSilo;
			toEnt.NhomSiloID = fromObj.NhomSiloID;
			toEnt.SoTT = fromObj.SoTT;
			toEnt.SaiSoDuoi = fromObj.SaiSoDuoi;
			toEnt.SaiSoTren = fromObj.SaiSoTren;
			toEnt.KLCanNhoNhat = fromObj.KLCanNhoNhat;
			toEnt.KLCanLonNhat = fromObj.KLCanLonNhat;
			toEnt.TGNhapNhaOn = fromObj.TGNhapNhaOn;
			toEnt.TGNhapNhaOff = fromObj.TGNhapNhaOff;
			toEnt.TGKiemTraVatLieuRoi = fromObj.TGKiemTraVatLieuRoi;
			toEnt.KLRoi = fromObj.KLRoi;
			toEnt.K_Pulse = fromObj.K_Pulse;
			toEnt.KLDT_Tu1 = fromObj.KLDT_Tu1;
			toEnt.KLDT_Tu2 = fromObj.KLDT_Tu2;
			toEnt.KLDT_Tu3 = fromObj.KLDT_Tu3;
			toEnt.KLDT_Den1 = fromObj.KLDT_Den1;
			toEnt.KLDT_Den2 = fromObj.KLDT_Den2;
			toEnt.KLDT_Den3 = fromObj.KLDT_Den3;
			toEnt.KLDT_DungTruoc1 = fromObj.KLDT_DungTruoc1;
			toEnt.KLDT_DungTruoc2 = fromObj.KLDT_DungTruoc2;
			toEnt.KLDT_DungTruoc3 = fromObj.KLDT_DungTruoc3;
			toEnt.TinhDoHutNuocID = fromObj.TinhDoHutNuocID;
			toEnt.TinhDoHutNuocName = fromObj.TinhDoHutNuocName;
			toEnt.DoAm_NhomSlioAgg = fromObj.DoAm_NhomSlioAgg;
			toEnt.DoHutNuoc_NhomSiloAgg = fromObj.DoHutNuoc_NhomSiloAgg;
			toEnt.SoiTrongCat_NhomSiloAgg = fromObj.SoiTrongCat_NhomSiloAgg;
			toEnt.SoiTrongCat_TruVaoSilo_NhomSiloAgg = fromObj.SoiTrongCat_TruVaoSilo_NhomSiloAgg;
			toEnt.MaterialID = fromObj.MaterialID;
			toEnt.MaterialCode = fromObj.MaterialCode;
			toEnt.MaterialName = fromObj.MaterialName;
			toEnt.Activated = fromObj.Activated;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
			toEnt.VersionNo = fromObj.VersionNo;
		}

		public static ObjSilo BuildNewObjSilo(Silo entSilo)
		{
			ObjSilo objSilo = new ObjSilo();
			SiloHelper.CopyToObjSilo(entSilo, objSilo);
			return objSilo;
		}

		public static IList<ObjSilo> BuildListObjSilo(IList<Silo> lstEntSilo)
		{
			IList<ObjSilo> lstObjSilo = new List<ObjSilo>();
			foreach (Silo entSilo in lstEntSilo)
			{
				lstObjSilo.Add(SiloHelper.BuildNewObjSilo(entSilo));
			}
			return lstObjSilo;
		}

		public static Silo BuildNewEntSilo(ObjSilo objSilo)
		{
			Silo entSilo = new Silo();
			SiloHelper.CopyToEntSilo(objSilo, entSilo);
			return entSilo;
		}

		public static IList<Silo> BuildListEntSilo(IList<ObjSilo> lstObjSilo)
		{
			IList<Silo> lstEntSilo = new List<Silo>();
			foreach (ObjSilo objSilo in lstObjSilo)
			{
				lstEntSilo.Add(SiloHelper.BuildNewEntSilo(objSilo));
			}
			return lstEntSilo;
		}
	}
}

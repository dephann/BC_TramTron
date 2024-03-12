using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class NhanVienHelper
	{
		public static void CopyToObjNhanVien(NhanVien fromEnt, ObjNhanVien toObj)
		{
			toObj.NhanVienID = fromEnt.NhanVienID;
			toObj.MaNhanVien = fromEnt.MaNhanVien;
			toObj.TenNhanVien = fromEnt.TenNhanVien;
			toObj.NamSinh = fromEnt.NamSinh;
			toObj.GioiTinh = fromEnt.GioiTinh;
			toObj.Phone = fromEnt.Phone;
			toObj.GhiChu = fromEnt.GhiChu;
			toObj.Activated = fromEnt.Activated;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			toObj.VersionNo = fromEnt.VersionNo;
			if (toObj.NhanVienID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntNhanVien(ObjNhanVien fromObj, NhanVien toEnt)
		{
			toEnt.NhanVienID = fromObj.NhanVienID;
			toEnt.MaNhanVien = fromObj.MaNhanVien;
			toEnt.TenNhanVien = fromObj.TenNhanVien;
			toEnt.NamSinh = fromObj.NamSinh;
			toEnt.GioiTinh = fromObj.GioiTinh;
			toEnt.Phone = fromObj.Phone;
			toEnt.GhiChu = fromObj.GhiChu;
			toEnt.Activated = fromObj.Activated;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
			toEnt.VersionNo = fromObj.VersionNo;
		}

		public static ObjNhanVien BuildNewObjNhanVien(NhanVien entNhanVien)
		{
			ObjNhanVien objNhanVien = new ObjNhanVien();
			NhanVienHelper.CopyToObjNhanVien(entNhanVien, objNhanVien);
			return objNhanVien;
		}

		public static IList<ObjNhanVien> BuildListObjNhanVien(IList<NhanVien> lstEntNhanVien)
		{
			IList<ObjNhanVien> lstObjNhanVien = new List<ObjNhanVien>();
			foreach (NhanVien entNhanVien in lstEntNhanVien)
			{
				lstObjNhanVien.Add(NhanVienHelper.BuildNewObjNhanVien(entNhanVien));
			}
			return lstObjNhanVien;
		}

		public static NhanVien BuildNewEntNhanVien(ObjNhanVien objNhanVien)
		{
			NhanVien entNhanVien = new NhanVien();
			NhanVienHelper.CopyToEntNhanVien(objNhanVien, entNhanVien);
			return entNhanVien;
		}

		public static IList<NhanVien> BuildListEntNhanVien(IList<ObjNhanVien> lstObjNhanVien)
		{
			IList<NhanVien> lstEntNhanVien = new List<NhanVien>();
			foreach (ObjNhanVien objNhanVien in lstObjNhanVien)
			{
				lstEntNhanVien.Add(NhanVienHelper.BuildNewEntNhanVien(objNhanVien));
			}
			return lstEntNhanVien;
		}
	}
}

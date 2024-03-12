using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class CongTruongHelper
	{
		public static void CopyToObjCongTruong(CongTruong fromEnt, ObjCongTruong toObj)
		{
			toObj.CongTruongID = fromEnt.CongTruongID;
			toObj.MaCongTruong = fromEnt.MaCongTruong;
			toObj.TenCongTruong = fromEnt.TenCongTruong;
			toObj.DiaChi = fromEnt.DiaChi;
			toObj.Phone = fromEnt.Phone;
			toObj.GhiChu = fromEnt.GhiChu;
			toObj.Activated = fromEnt.Activated;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			toObj.VersionNo = fromEnt.VersionNo;
			if (toObj.CongTruongID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntCongTruong(ObjCongTruong fromObj, CongTruong toEnt)
		{
			toEnt.CongTruongID = fromObj.CongTruongID;
			toEnt.MaCongTruong = fromObj.MaCongTruong;
			toEnt.TenCongTruong = fromObj.TenCongTruong;
			toEnt.DiaChi = fromObj.DiaChi;
			toEnt.Phone = fromObj.Phone;
			toEnt.GhiChu = fromObj.GhiChu;
			toEnt.Activated = fromObj.Activated;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
			toEnt.VersionNo = fromObj.VersionNo;
		}

		public static ObjCongTruong BuildNewObjCongTruong(CongTruong entCongTruong)
		{
			ObjCongTruong objCongTruong = new ObjCongTruong();
			CongTruongHelper.CopyToObjCongTruong(entCongTruong, objCongTruong);
			return objCongTruong;
		}

		public static IList<ObjCongTruong> BuildListObjCongTruong(IList<CongTruong> lstEntCongTruong)
		{
			IList<ObjCongTruong> lstObjCongTruong = new List<ObjCongTruong>();
			foreach (CongTruong entCongTruong in lstEntCongTruong)
			{
				lstObjCongTruong.Add(CongTruongHelper.BuildNewObjCongTruong(entCongTruong));
			}
			return lstObjCongTruong;
		}

		public static CongTruong BuildNewEntCongTruong(ObjCongTruong objCongTruong)
		{
			CongTruong entCongTruong = new CongTruong();
			CongTruongHelper.CopyToEntCongTruong(objCongTruong, entCongTruong);
			return entCongTruong;
		}

		public static IList<CongTruong> BuildListEntCongTruong(IList<ObjCongTruong> lstObjCongTruong)
		{
			IList<CongTruong> lstEntCongTruong = new List<CongTruong>();
			foreach (ObjCongTruong objCongTruong in lstObjCongTruong)
			{
				lstEntCongTruong.Add(CongTruongHelper.BuildNewEntCongTruong(objCongTruong));
			}
			return lstEntCongTruong;
		}
	}
}

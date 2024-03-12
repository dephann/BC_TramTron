using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class TaiXeHelper
	{
		public static void CopyToObjTaiXe(TaiXe fromEnt, ObjTaiXe toObj)
		{
			toObj.TaiXeID = fromEnt.TaiXeID;
			toObj.MaTaiXe = fromEnt.MaTaiXe;
			toObj.TenTaiXe = fromEnt.TenTaiXe;
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
			if (toObj.TaiXeID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntTaiXe(ObjTaiXe fromObj, TaiXe toEnt)
		{
			toEnt.TaiXeID = fromObj.TaiXeID;
			toEnt.MaTaiXe = fromObj.MaTaiXe;
			toEnt.TenTaiXe = fromObj.TenTaiXe;
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

		public static ObjTaiXe BuildNewObjTaiXe(TaiXe entTaiXe)
		{
			ObjTaiXe objTaiXe = new ObjTaiXe();
			TaiXeHelper.CopyToObjTaiXe(entTaiXe, objTaiXe);
			return objTaiXe;
		}

		public static IList<ObjTaiXe> BuildListObjTaiXe(IList<TaiXe> lstEntTaiXe)
		{
			IList<ObjTaiXe> lstObjTaiXe = new List<ObjTaiXe>();
			foreach (TaiXe entTaiXe in lstEntTaiXe)
			{
				lstObjTaiXe.Add(TaiXeHelper.BuildNewObjTaiXe(entTaiXe));
			}
			return lstObjTaiXe;
		}

		public static TaiXe BuildNewEntTaiXe(ObjTaiXe objTaiXe)
		{
			TaiXe entTaiXe = new TaiXe();
			TaiXeHelper.CopyToEntTaiXe(objTaiXe, entTaiXe);
			return entTaiXe;
		}

		public static IList<TaiXe> BuildListEntTaiXe(IList<ObjTaiXe> lstObjTaiXe)
		{
			IList<TaiXe> lstEntTaiXe = new List<TaiXe>();
			foreach (ObjTaiXe objTaiXe in lstObjTaiXe)
			{
				lstEntTaiXe.Add(TaiXeHelper.BuildNewEntTaiXe(objTaiXe));
			}
			return lstEntTaiXe;
		}
	}
}

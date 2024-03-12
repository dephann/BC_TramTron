using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class XeHelper
	{
		public static void CopyToObjXe(Xe fromEnt, ObjXe toObj)
		{
			toObj.XeID = fromEnt.XeID;
			toObj.BienSo = fromEnt.BienSo;
			toObj.KhoiLuong = fromEnt.KhoiLuong;
			toObj.GhiChu = fromEnt.GhiChu;
			toObj.Activated = fromEnt.Activated;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			toObj.VersionNo = fromEnt.VersionNo;
			if (toObj.XeID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntXe(ObjXe fromObj, Xe toEnt)
		{
			toEnt.XeID = fromObj.XeID;
			toEnt.BienSo = fromObj.BienSo;
			toEnt.KhoiLuong = fromObj.KhoiLuong;
			toEnt.GhiChu = fromObj.GhiChu;
			toEnt.Activated = fromObj.Activated;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
			toEnt.VersionNo = fromObj.VersionNo;
		}

		public static ObjXe BuildNewObjXe(Xe entXe)
		{
			ObjXe objXe = new ObjXe();
			XeHelper.CopyToObjXe(entXe, objXe);
			return objXe;
		}

		public static IList<ObjXe> BuildListObjXe(IList<Xe> lstEntXe)
		{
			IList<ObjXe> lstObjXe = new List<ObjXe>();
			foreach (Xe entXe in lstEntXe)
			{
				lstObjXe.Add(XeHelper.BuildNewObjXe(entXe));
			}
			return lstObjXe;
		}

		public static Xe BuildNewEntXe(ObjXe objXe)
		{
			Xe entXe = new Xe();
			XeHelper.CopyToEntXe(objXe, entXe);
			return entXe;
		}

		public static IList<Xe> BuildListEntXe(IList<ObjXe> lstObjXe)
		{
			IList<Xe> lstEntXe = new List<Xe>();
			foreach (ObjXe objXe in lstObjXe)
			{
				lstEntXe.Add(XeHelper.BuildNewEntXe(objXe));
			}
			return lstEntXe;
		}
	}
}

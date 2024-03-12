using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class WeiSiloSavingHelper
	{
		public static void CopyToObjWeiSiloSaving(WeiSiloSaving fromEnt, ObjWeiSiloSaving toObj)
		{
			toObj.WeiSiloSavingID = fromEnt.WeiSiloSavingID;
			toObj.MaCan = fromEnt.MaCan;
			toObj.MaSilo = fromEnt.MaSilo;
			toObj.GhiChu = fromEnt.GhiChu;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			if (toObj.WeiSiloSavingID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntWeiSiloSaving(ObjWeiSiloSaving fromObj, WeiSiloSaving toEnt)
		{
			toEnt.WeiSiloSavingID = fromObj.WeiSiloSavingID;
			toEnt.MaCan = fromObj.MaCan;
			toEnt.MaSilo = fromObj.MaSilo;
			toEnt.GhiChu = fromObj.GhiChu;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
		}

		public static ObjWeiSiloSaving BuildNewObjWeiSiloSaving(WeiSiloSaving entWeiSiloSaving)
		{
			ObjWeiSiloSaving objWeiSiloSaving = new ObjWeiSiloSaving();
			WeiSiloSavingHelper.CopyToObjWeiSiloSaving(entWeiSiloSaving, objWeiSiloSaving);
			return objWeiSiloSaving;
		}

		public static IList<ObjWeiSiloSaving> BuildListObjWeiSiloSaving(IList<WeiSiloSaving> lstEntWeiSiloSaving)
		{
			IList<ObjWeiSiloSaving> lstObjWeiSiloSaving = new List<ObjWeiSiloSaving>();
			foreach (WeiSiloSaving entWeiSiloSaving in lstEntWeiSiloSaving)
			{
				lstObjWeiSiloSaving.Add(WeiSiloSavingHelper.BuildNewObjWeiSiloSaving(entWeiSiloSaving));
			}
			return lstObjWeiSiloSaving;
		}

		public static WeiSiloSaving BuildNewEntWeiSiloSaving(ObjWeiSiloSaving objWeiSiloSaving)
		{
			WeiSiloSaving entWeiSiloSaving = new WeiSiloSaving();
			WeiSiloSavingHelper.CopyToEntWeiSiloSaving(objWeiSiloSaving, entWeiSiloSaving);
			return entWeiSiloSaving;
		}

		public static IList<WeiSiloSaving> BuildListEntWeiSiloSaving(IList<ObjWeiSiloSaving> lstObjWeiSiloSaving)
		{
			IList<WeiSiloSaving> lstEntWeiSiloSaving = new List<WeiSiloSaving>();
			foreach (ObjWeiSiloSaving objWeiSiloSaving in lstObjWeiSiloSaving)
			{
				lstEntWeiSiloSaving.Add(WeiSiloSavingHelper.BuildNewEntWeiSiloSaving(objWeiSiloSaving));
			}
			return lstEntWeiSiloSaving;
		}
	}
}

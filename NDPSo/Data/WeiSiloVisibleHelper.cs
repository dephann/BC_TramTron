using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class WeiSiloVisibleHelper
	{
		public static void CopyToObjWeiSiloVisible(WeiSiloVisible fromEnt, ObjWeiSiloVisible toObj)
		{
			toObj.WeiSiloVisibleID = fromEnt.WeiSiloVisibleID;
			toObj.Code = fromEnt.Code;
			toObj.Type = fromEnt.Type;
			toObj.Visible = fromEnt.Visible;
			if (toObj.WeiSiloVisibleID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntWeiSiloVisible(ObjWeiSiloVisible fromObj, WeiSiloVisible toEnt)
		{
			toEnt.WeiSiloVisibleID = fromObj.WeiSiloVisibleID;
			toEnt.Code = fromObj.Code;
			toEnt.Type = fromObj.Type;
			toEnt.Visible = fromObj.Visible;
		}

		public static ObjWeiSiloVisible BuildNewObjWeiSiloVisible(WeiSiloVisible entWeiSiloVisible)
		{
			ObjWeiSiloVisible objWeiSiloVisible = new ObjWeiSiloVisible();
			WeiSiloVisibleHelper.CopyToObjWeiSiloVisible(entWeiSiloVisible, objWeiSiloVisible);
			return objWeiSiloVisible;
		}

		public static IList<ObjWeiSiloVisible> BuildListObjWeiSiloVisible(IList<WeiSiloVisible> lstEntWeiSiloVisible)
		{
			IList<ObjWeiSiloVisible> lstObjWeiSiloVisible = new List<ObjWeiSiloVisible>();
			foreach (WeiSiloVisible entWeiSiloVisible in lstEntWeiSiloVisible)
			{
				lstObjWeiSiloVisible.Add(WeiSiloVisibleHelper.BuildNewObjWeiSiloVisible(entWeiSiloVisible));
			}
			return lstObjWeiSiloVisible;
		}

		public static WeiSiloVisible BuildNewEntWeiSiloVisible(ObjWeiSiloVisible objWeiSiloVisible)
		{
			WeiSiloVisible entWeiSiloVisible = new WeiSiloVisible();
			WeiSiloVisibleHelper.CopyToEntWeiSiloVisible(objWeiSiloVisible, entWeiSiloVisible);
			return entWeiSiloVisible;
		}

		public static IList<WeiSiloVisible> BuildListEntWeiSiloVisible(IList<ObjWeiSiloVisible> lstObjWeiSiloVisible)
		{
			IList<WeiSiloVisible> lstEntWeiSiloVisible = new List<WeiSiloVisible>();
			foreach (ObjWeiSiloVisible objWeiSiloVisible in lstObjWeiSiloVisible)
			{
				lstEntWeiSiloVisible.Add(WeiSiloVisibleHelper.BuildNewEntWeiSiloVisible(objWeiSiloVisible));
			}
			return lstEntWeiSiloVisible;
		}
	}
}

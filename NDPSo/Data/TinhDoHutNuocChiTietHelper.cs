using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class TinhDoHutNuocChiTietHelper
	{
		public static void CopyToObjTinhDoHutNuocChiTiet(TinhDoHutNuocChiTiet fromEnt, ObjTinhDoHutNuocChiTiet toObj)
		{
			toObj.TinhDoHutNuocChiTietID = fromEnt.TinhDoHutNuocChiTietID;
			toObj.TinhDoHutNuocID = fromEnt.TinhDoHutNuocID;
			toObj.KichCo = fromEnt.KichCo;
			toObj.Percentage = fromEnt.Percentage;
			toObj.Value = fromEnt.Value;
			toObj.VersionNo = fromEnt.VersionNo;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			if (toObj.TinhDoHutNuocChiTietID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntTinhDoHutNuocChiTiet(ObjTinhDoHutNuocChiTiet fromObj, TinhDoHutNuocChiTiet toEnt)
		{
			toEnt.TinhDoHutNuocChiTietID = fromObj.TinhDoHutNuocChiTietID;
			toEnt.TinhDoHutNuocID = fromObj.TinhDoHutNuocID;
			toEnt.KichCo = fromObj.KichCo;
			toEnt.Percentage = fromObj.Percentage;
			toEnt.Value = fromObj.Value;
			toEnt.VersionNo = fromObj.VersionNo;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
		}

		public static ObjTinhDoHutNuocChiTiet BuildNewObjTinhDoHutNuocChiTiet(TinhDoHutNuocChiTiet entTinhDoHutNuocChiTiet)
		{
			ObjTinhDoHutNuocChiTiet objTinhDoHutNuocChiTiet = new ObjTinhDoHutNuocChiTiet();
			TinhDoHutNuocChiTietHelper.CopyToObjTinhDoHutNuocChiTiet(entTinhDoHutNuocChiTiet, objTinhDoHutNuocChiTiet);
			return objTinhDoHutNuocChiTiet;
		}

		public static IList<ObjTinhDoHutNuocChiTiet> BuildListObjTinhDoHutNuocChiTiet(IList<TinhDoHutNuocChiTiet> lstEntTinhDoHutNuocChiTiet)
		{
			IList<ObjTinhDoHutNuocChiTiet> lstObjTinhDoHutNuocChiTiet = new List<ObjTinhDoHutNuocChiTiet>();
			foreach (TinhDoHutNuocChiTiet entTinhDoHutNuocChiTiet in lstEntTinhDoHutNuocChiTiet)
			{
				lstObjTinhDoHutNuocChiTiet.Add(TinhDoHutNuocChiTietHelper.BuildNewObjTinhDoHutNuocChiTiet(entTinhDoHutNuocChiTiet));
			}
			return lstObjTinhDoHutNuocChiTiet;
		}

		public static TinhDoHutNuocChiTiet BuildNewEntTinhDoHutNuocChiTiet(ObjTinhDoHutNuocChiTiet objTinhDoHutNuocChiTiet)
		{
			TinhDoHutNuocChiTiet entTinhDoHutNuocChiTiet = new TinhDoHutNuocChiTiet();
			TinhDoHutNuocChiTietHelper.CopyToEntTinhDoHutNuocChiTiet(objTinhDoHutNuocChiTiet, entTinhDoHutNuocChiTiet);
			return entTinhDoHutNuocChiTiet;
		}

		public static IList<TinhDoHutNuocChiTiet> BuildListEntTinhDoHutNuocChiTiet(IList<ObjTinhDoHutNuocChiTiet> lstObjTinhDoHutNuocChiTiet)
		{
			IList<TinhDoHutNuocChiTiet> lstEntTinhDoHutNuocChiTiet = new List<TinhDoHutNuocChiTiet>();
			foreach (ObjTinhDoHutNuocChiTiet objTinhDoHutNuocChiTiet in lstObjTinhDoHutNuocChiTiet)
			{
				lstEntTinhDoHutNuocChiTiet.Add(TinhDoHutNuocChiTietHelper.BuildNewEntTinhDoHutNuocChiTiet(objTinhDoHutNuocChiTiet));
			}
			return lstEntTinhDoHutNuocChiTiet;
		}
	}
}

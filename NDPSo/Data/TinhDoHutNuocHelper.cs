using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class TinhDoHutNuocHelper
	{
		public static void CopyToObjTinhDoHutNuoc(TinhDoHutNuoc fromEnt, ObjTinhDoHutNuoc toObj)
		{
			toObj.TinhDoHutNuocID = fromEnt.TinhDoHutNuocID;
			toObj.MaTinhDoHutNuoc = fromEnt.MaTinhDoHutNuoc;
			toObj.NgayTinhDoHut = fromEnt.NgayTinhDoHut;
			toObj.NhomSiloID = fromEnt.NhomSiloID;
			toObj.Name = fromEnt.Name;
			toObj.DoHutNuoc = fromEnt.DoHutNuoc;
			toObj.Description = fromEnt.Description;
			toObj.VersionNo = fromEnt.VersionNo;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			if (toObj.TinhDoHutNuocID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntTinhDoHutNuoc(ObjTinhDoHutNuoc fromObj, TinhDoHutNuoc toEnt)
		{
			toEnt.TinhDoHutNuocID = fromObj.TinhDoHutNuocID;
			toEnt.MaTinhDoHutNuoc = fromObj.MaTinhDoHutNuoc;
			toEnt.NgayTinhDoHut = fromObj.NgayTinhDoHut;
			toEnt.NhomSiloID = fromObj.NhomSiloID;
			toEnt.Name = fromObj.Name;
			toEnt.DoHutNuoc = fromObj.DoHutNuoc;
			toEnt.Description = fromObj.Description;
			toEnt.VersionNo = fromObj.VersionNo;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
		}

		public static ObjTinhDoHutNuoc BuildNewObjTinhDoHutNuoc(TinhDoHutNuoc entTinhDoHutNuoc)
		{
			ObjTinhDoHutNuoc objTinhDoHutNuoc = new ObjTinhDoHutNuoc();
			TinhDoHutNuocHelper.CopyToObjTinhDoHutNuoc(entTinhDoHutNuoc, objTinhDoHutNuoc);
			return objTinhDoHutNuoc;
		}

		public static IList<ObjTinhDoHutNuoc> BuildListObjTinhDoHutNuoc(IList<TinhDoHutNuoc> lstEntTinhDoHutNuoc)
		{
			IList<ObjTinhDoHutNuoc> lstObjTinhDoHutNuoc = new List<ObjTinhDoHutNuoc>();
			foreach (TinhDoHutNuoc entTinhDoHutNuoc in lstEntTinhDoHutNuoc)
			{
				lstObjTinhDoHutNuoc.Add(TinhDoHutNuocHelper.BuildNewObjTinhDoHutNuoc(entTinhDoHutNuoc));
			}
			return lstObjTinhDoHutNuoc;
		}

		public static TinhDoHutNuoc BuildNewEntTinhDoHutNuoc(ObjTinhDoHutNuoc objTinhDoHutNuoc)
		{
			TinhDoHutNuoc entTinhDoHutNuoc = new TinhDoHutNuoc();
			TinhDoHutNuocHelper.CopyToEntTinhDoHutNuoc(objTinhDoHutNuoc, entTinhDoHutNuoc);
			return entTinhDoHutNuoc;
		}

		public static IList<TinhDoHutNuoc> BuildListEntTinhDoHutNuoc(IList<ObjTinhDoHutNuoc> lstObjTinhDoHutNuoc)
		{
			IList<TinhDoHutNuoc> lstEntTinhDoHutNuoc = new List<TinhDoHutNuoc>();
			foreach (ObjTinhDoHutNuoc objTinhDoHutNuoc in lstObjTinhDoHutNuoc)
			{
				lstEntTinhDoHutNuoc.Add(TinhDoHutNuocHelper.BuildNewEntTinhDoHutNuoc(objTinhDoHutNuoc));
			}
			return lstEntTinhDoHutNuoc;
		}
	}
}

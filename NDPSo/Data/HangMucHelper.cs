using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    class HangMucHelper
    {
		public static void CopyToObjHangMuc(HangMuc fromEnt, ObjHangMuc toObj)
		{
			toObj.HangMucID = fromEnt.HangMucID;
			toObj.MaHangMuc = fromEnt.MaHangMuc;
			toObj.TenHangMuc = fromEnt.TenHangMuc;
			toObj.GhiChu = fromEnt.GhiChu;
			toObj.Activated = fromEnt.Activated;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			toObj.VersionNo = fromEnt.VersionNo;
			if (toObj.HangMucID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntHangMuc(ObjHangMuc fromObj, HangMuc toEnt)
		{
			toEnt.HangMucID = fromObj.HangMucID;
			toEnt.MaHangMuc = fromObj.MaHangMuc;
			toEnt.TenHangMuc = fromObj.TenHangMuc;
			toEnt.GhiChu = fromObj.GhiChu;
			toEnt.Activated = fromObj.Activated;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
			toEnt.VersionNo = fromObj.VersionNo;
		}

		public static ObjHangMuc BuildNewObjHangMuc(HangMuc entHangMuc)
		{
			ObjHangMuc objHangMuc = new ObjHangMuc();
			HangMucHelper.CopyToObjHangMuc(entHangMuc, objHangMuc);
			return objHangMuc;
		}

		public static IList<ObjHangMuc> BuildListObjHangMuc(IList<HangMuc> lstEntHangMuc)
		{
			IList<ObjHangMuc> lstObjHangMuc = new List<ObjHangMuc>();
			foreach (HangMuc entHangMuc in lstEntHangMuc)
			{
				lstObjHangMuc.Add(HangMucHelper.BuildNewObjHangMuc(entHangMuc));
			}
			return lstObjHangMuc;
		}

		public static HangMuc BuildNewEntHangMuc(ObjHangMuc objHangMuc)
		{
			HangMuc entHangMuc = new HangMuc();
			HangMucHelper.CopyToEntHangMuc(objHangMuc, entHangMuc);
			return entHangMuc;
		}

		public static IList<HangMuc> BuildListEntHangMuc(IList<ObjHangMuc> lstObjHangMuc)
		{
			IList<HangMuc> lstEntHangMuc = new List<HangMuc>();
			foreach (ObjHangMuc objHangMuc in lstObjHangMuc)
			{
				lstEntHangMuc.Add(HangMucHelper.BuildNewEntHangMuc(objHangMuc));
			}
			return lstEntHangMuc;
		}
	}
}


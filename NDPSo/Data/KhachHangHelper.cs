using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class KhachHangHelper
	{
		public static void CopyToObjKhachHang(KhachHang fromEnt, ObjKhachHang toObj)
		{
			toObj.KhachHangID = fromEnt.KhachHangID;
			toObj.MaKhachHang = fromEnt.MaKhachHang;
			toObj.TenKhachHang = fromEnt.TenKhachHang;
			toObj.GioiTinh = fromEnt.GioiTinh;
			toObj.DiaChi = fromEnt.DiaChi;
			toObj.Email = fromEnt.Email;
			toObj.Phone = fromEnt.Phone;
			toObj.Fax = fromEnt.Fax;
			toObj.GhiChu = fromEnt.GhiChu;
			toObj.Activated = fromEnt.Activated;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			toObj.VersionNo = fromEnt.VersionNo;
			if (toObj.KhachHangID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntKhachHang(ObjKhachHang fromObj, KhachHang toEnt)
		{
			toEnt.KhachHangID = fromObj.KhachHangID;
			toEnt.MaKhachHang = fromObj.MaKhachHang;
			toEnt.TenKhachHang = fromObj.TenKhachHang;
			toEnt.GioiTinh = fromObj.GioiTinh;
			toEnt.DiaChi = fromObj.DiaChi;
			toEnt.Email = fromObj.Email;
			toEnt.Phone = fromObj.Phone;
			toEnt.Fax = fromObj.Fax;
			toEnt.GhiChu = fromObj.GhiChu;
			toEnt.Activated = fromObj.Activated;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
			toEnt.VersionNo = fromObj.VersionNo;
		}

		public static ObjKhachHang BuildNewObjKhachHang(KhachHang entKhachHang)
		{
			ObjKhachHang objKhachHang = new ObjKhachHang();
			KhachHangHelper.CopyToObjKhachHang(entKhachHang, objKhachHang);
			return objKhachHang;
		}

		public static IList<ObjKhachHang> BuildListObjKhachHang(IList<KhachHang> lstEntKhachHang)
		{
			IList<ObjKhachHang> lstObjKhachHang = new List<ObjKhachHang>();
			foreach (KhachHang entKhachHang in lstEntKhachHang)
			{
				lstObjKhachHang.Add(KhachHangHelper.BuildNewObjKhachHang(entKhachHang));
			}
			return lstObjKhachHang;
		}

		public static KhachHang BuildNewEntKhachHang(ObjKhachHang objKhachHang)
		{
			KhachHang entKhachHang = new KhachHang();
			KhachHangHelper.CopyToEntKhachHang(objKhachHang, entKhachHang);
			return entKhachHang;
		}

		public static IList<KhachHang> BuildListEntKhachHang(IList<ObjKhachHang> lstObjKhachHang)
		{
			IList<KhachHang> lstEntKhachHang = new List<KhachHang>();
			foreach (ObjKhachHang objKhachHang in lstObjKhachHang)
			{
				lstEntKhachHang.Add(KhachHangHelper.BuildNewEntKhachHang(objKhachHang));
			}
			return lstEntKhachHang;
		}
	}
}

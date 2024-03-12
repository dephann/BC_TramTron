using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
    public class vw_SumWeightHelper
    {
        public static void CopyToObjvw_SumWeight(vw_SumWeight fromEnt, Objvw_SumWeight toObj)
        {
			toObj.PhieuTronID = fromEnt.PhieuTronID;
			toObj.MaPhieuTron = fromEnt.MaPhieuTron;
			toObj.NgayPhieuTron = fromEnt.NgayPhieuTron;
			toObj.Ngay = fromEnt.Ngay;
			toObj.Gio = fromEnt.Gio;
			toObj.KLDuTinh = fromEnt.KLDuTinh;
			toObj.KLThuc = fromEnt.KLThuc;
			toObj.SLMeDuTinh = fromEnt.SLMeDuTinh;
			toObj.KLDuTinhCuaTungMe = fromEnt.KLDuTinhCuaTungMe;
			toObj.KhachHangID = fromEnt.KhachHangID;
			toObj.TenKhachHang = fromEnt.TenKhachHang;
			toObj.CongTruongID = fromEnt.CongTruongID;
			toObj.TenCongTruong = fromEnt.TenCongTruong;
			toObj.HangMucID = fromEnt.HangMucID;
			toObj.TenHangMuc = fromEnt.TenHangMuc;
			toObj.MACID = fromEnt.MACID;
			toObj.TenMAC = fromEnt.TenMAC;
			toObj.NhanVienID = fromEnt.NhanVienID;
			toObj.TenNhanVien = fromEnt.TenNhanVien;
			toObj.XeID = fromEnt.XeID;
			toObj.BienSo = fromEnt.BienSo;
			toObj.TaiXeID = fromEnt.TaiXeID;
			toObj.TenTaiXe = fromEnt.TenTaiXe;
			toObj.SUM_Total_Value = fromEnt.SUM_Total_Value;
			toObj.SUM_Total_ValueBat = fromEnt.SUM_Total_ValueBat;
			toObj.SUM_Total_ValueBatMan = fromEnt.SUM_Total_ValueBatMan;
			toObj.IsQueued = (bool)fromEnt.IsQueued;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.FullName = fromEnt.FullName;
		}

		public static void CopyToEntvw_SumWeight(Objvw_SumWeight fromObj, vw_SumWeight toEnt)
        {
			toEnt.PhieuTronID = fromObj.PhieuTronID;
			toEnt.MaPhieuTron = fromObj.MaPhieuTron;
			toEnt.NgayPhieuTron = fromObj.NgayPhieuTron;
			toEnt.Ngay = fromObj.Ngay;
			toEnt.Gio = fromObj.Gio;
			toEnt.KLDuTinh = fromObj.KLDuTinh;
			toEnt.KLThuc = fromObj.KLThuc;
			toEnt.SLMeDuTinh = fromObj.SLMeDuTinh;
			toEnt.KLDuTinhCuaTungMe = fromObj.KLDuTinhCuaTungMe;
			toEnt.KhachHangID = (int)fromObj.KhachHangID;
			toEnt.TenKhachHang = fromObj.TenKhachHang;
			toEnt.CongTruongID = (int)fromObj.CongTruongID;
			toEnt.TenCongTruong = fromObj.TenCongTruong;
			toEnt.HangMucID = (int)fromObj.HangMucID;
			toEnt.TenHangMuc = fromObj.TenHangMuc;
			toEnt.MACID = (int)fromObj.MACID;
			toEnt.TenMAC = fromObj.TenMAC;
			toEnt.NhanVienID = (int)fromObj.NhanVienID;
			toEnt.TenNhanVien = fromObj.TenNhanVien;
			toEnt.XeID = (int)fromObj.XeID;
			toEnt.BienSo = fromObj.BienSo;
			toEnt.TaiXeID = (int)fromObj.TaiXeID;
			toEnt.TenTaiXe = fromObj.TenTaiXe;
			toEnt.SUM_Total_Value = fromObj.SUM_Total_Value;
			toEnt.SUM_Total_ValueBat = fromObj.SUM_Total_ValueBat;
			toEnt.SUM_Total_ValueBatMan = fromObj.SUM_Total_ValueBatMan;
			toEnt.IsQueued = (bool)fromObj.IsQueued;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.FullName = fromObj.FullName;
		}
		public static Objvw_SumWeight BuildNewObjvw_SumWeight(vw_SumWeight entvw_SumWeight)
		{
			Objvw_SumWeight objvw_SumWeight = new Objvw_SumWeight();
			vw_SumWeightHelper.CopyToObjvw_SumWeight(entvw_SumWeight, objvw_SumWeight);
			return objvw_SumWeight;
		}
		public static IList<Objvw_SumWeight> BuildListObjvw_SumWeight(IList<vw_SumWeight> lstEntvw_SumWeight)
		{
			IList<Objvw_SumWeight> lstObjvw_SumWeight = new List<Objvw_SumWeight>();
			foreach (vw_SumWeight entvw_SumWeight in lstEntvw_SumWeight)
			{
				lstObjvw_SumWeight.Add(vw_SumWeightHelper.BuildNewObjvw_SumWeight(entvw_SumWeight));
			}
			return lstObjvw_SumWeight;
		}
		public static vw_SumWeight BuildNewEntvw_SumWeight(Objvw_SumWeight objvw_SumWeight)
		{
			vw_SumWeight entvw_SumWeight = new vw_SumWeight();
			vw_SumWeightHelper.CopyToEntvw_SumWeight(objvw_SumWeight, entvw_SumWeight);
			return entvw_SumWeight;
		}
		public static IList<vw_SumWeight> BuildListEntvw_SumWeight(IList<Objvw_SumWeight> lstObjvw_SumWeight)
		{
			IList<vw_SumWeight> lstEntvw_SumWeight = new List<vw_SumWeight>();
			foreach (Objvw_SumWeight objvw_SumWeight in lstObjvw_SumWeight)
			{
				lstEntvw_SumWeight.Add(vw_SumWeightHelper.BuildNewEntvw_SumWeight(objvw_SumWeight));
			}
			return lstEntvw_SumWeight;
		}
	}
}

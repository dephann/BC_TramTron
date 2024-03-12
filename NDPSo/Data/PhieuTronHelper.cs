using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class PhieuTronHelper
	{
		public static void CopyToObjPhieuTron(PhieuTron fromEnt, ObjPhieuTron toObj)
		{
			toObj.PhieuTronID = fromEnt.PhieuTronID;
			toObj.MaPhieuTron = fromEnt.MaPhieuTron;
			toObj.NoPhieu = fromEnt.NoPhieu;
			toObj.NgayPhieuTron = fromEnt.NgayPhieuTron;
			toObj.KLDuTinh = fromEnt.KLDuTinh;
			toObj.KLThuc = fromEnt.KLThuc;
			toObj.KLTronNhoNhat = fromEnt.KLTronNhoNhat;
			toObj.KLTronLonNhat = fromEnt.KLTronLonNhat;
			toObj.KLDuTinhCuaTungMe = fromEnt.KLDuTinhCuaTungMe;
			toObj.KLBuTruMeCuoi = fromEnt.KLBuTruMeCuoi;
			toObj.SLMeDuTinh = fromEnt.SLMeDuTinh;
			toObj.SLMeHieuChinh = fromEnt.SLMeHieuChinh;
			toObj.SLMeDaTron = fromEnt.SLMeDaTron;
			toObj.HopDongID = fromEnt.HopDongID;
			toObj.KhachHangID = fromEnt.KhachHangID;
			toObj.CongTruongID = fromEnt.CongTruongID;
			toObj.MACID = fromEnt.MACID;
			toObj.HangMucID = fromEnt.HangMucID;
			toObj.MoTa = fromEnt.MoTa;
			toObj.Status = fromEnt.Status;
			toObj.NguoiTron = fromEnt.NguoiTron;
			toObj.ThoiGianTron = fromEnt.ThoiGianTron;
			toObj.IsQueued = fromEnt.IsQueued;
			toObj.MinKLTron = fromEnt.MinKLTron;
			toObj.MaxKLTron = fromEnt.MaxKLTron;
			toObj.MaxKLXeCho = fromEnt.MaxKLXeCho;
			toObj.XeID = fromEnt.XeID;
			toObj.TaiXeID = fromEnt.TaiXeID;
			toObj.NhanVienID = fromEnt.NhanVienID;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			//toObj.NPHopDongMaHopDong = fromEnt.HopDong.MaHopDong;
			//toObj.NPHopDongTenHopDong = fromEnt.HopDong.TenHopDong;
			if (fromEnt.HopDong != null)
			{
				toObj.NPHopDongMaHopDong = fromEnt.HopDong.MaHopDong;
				toObj.NPHopDongKLDatHang = fromEnt.HopDong.KLDatHang;
				toObj.NPHopDongKLDaGiao = fromEnt.HopDong.KLDaGiao;
			}
			if (fromEnt.KhachHang != null)
			{
				toObj.NPKhachHangTenKhachHang = fromEnt.KhachHang.TenKhachHang;
			}
			if (fromEnt.CongTruong != null)
			{
				toObj.NPCongTruongTenCongTruong = fromEnt.CongTruong.TenCongTruong;
				toObj.NPCongTruongDiaChi = fromEnt.CongTruong.DiaChi;
			}
			if (fromEnt.TaiXe != null)
			{
				toObj.NPTaiXeMaTaiXe = fromEnt.TaiXe.MaTaiXe;
				toObj.NPTaiXeTenTaiXe = fromEnt.TaiXe.TenTaiXe;
			}
			if (fromEnt.Xe != null)
			{
				toObj.NPXeBienSo = fromEnt.Xe.BienSo;
			}
			if (fromEnt.NhanVien != null)
			{
				toObj.NPNhanVienTenNhanVien = fromEnt.NhanVien.TenNhanVien;
			}
			if (fromEnt.MAC != null)
			{
				toObj.NPMACMaMAC = fromEnt.MAC.MaMAC;
			}
			if (fromEnt.MAC != null)
			{
				toObj.NPMACTenMAC = fromEnt.MAC.TenMAC;
			}
			if (fromEnt.MAC != null)
			{
				toObj.NPMACDoSut = fromEnt.MAC.DoSut;
			}
			if (fromEnt.MAC != null)
			{
				toObj.NPMACCuongDo = fromEnt.MAC.GhiChu;
			}
			if (fromEnt.HangMuc != null)
			{
				toObj.NPHangMucTenHangMuc = fromEnt.HangMuc.TenHangMuc;
			}
			if (toObj.PhieuTronID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntPhieuTron(ObjPhieuTron fromObj, PhieuTron toEnt)
		{
			toEnt.PhieuTronID = fromObj.PhieuTronID;
			toEnt.MaPhieuTron = fromObj.MaPhieuTron;
			toEnt.NoPhieu = fromObj.NoPhieu;
			toEnt.NgayPhieuTron = fromObj.NgayPhieuTron;
			toEnt.KLDuTinh = fromObj.KLDuTinh;
			toEnt.KLThuc = fromObj.KLThuc;
			toEnt.KLTronNhoNhat = fromObj.KLTronNhoNhat;
			toEnt.KLTronLonNhat = fromObj.KLTronLonNhat;
			toEnt.KLDuTinhCuaTungMe = fromObj.KLDuTinhCuaTungMe;
			toEnt.KLBuTruMeCuoi = fromObj.KLBuTruMeCuoi;
			toEnt.SLMeDuTinh = fromObj.SLMeDuTinh;
			toEnt.SLMeHieuChinh = fromObj.SLMeHieuChinh;
			toEnt.SLMeDaTron = fromObj.SLMeDaTron;
			toEnt.HopDongID = fromObj.HopDongID;
			toEnt.KhachHangID = fromObj.KhachHangID;
			toEnt.CongTruongID = fromObj.CongTruongID;
			toEnt.MACID = fromObj.MACID;
			toEnt.HangMucID = fromObj.HangMucID;
			toEnt.MoTa = fromObj.MoTa;
			toEnt.Status = fromObj.Status;
			toEnt.NguoiTron = fromObj.NguoiTron;
			toEnt.ThoiGianTron = fromObj.ThoiGianTron;
			toEnt.IsQueued = fromObj.IsQueued;
			toEnt.MinKLTron = fromObj.MinKLTron;
			toEnt.MaxKLTron = fromObj.MaxKLTron;
			toEnt.MaxKLXeCho = fromObj.MaxKLXeCho;
			toEnt.XeID = fromObj.XeID;
			toEnt.TaiXeID = fromObj.TaiXeID;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
		}

		public static ObjPhieuTron BuildNewObjPhieuTron(PhieuTron entPhieuTron)
		{
			ObjPhieuTron objPhieuTron = new ObjPhieuTron();
			PhieuTronHelper.CopyToObjPhieuTron(entPhieuTron, objPhieuTron);
			return objPhieuTron;
		}

		public static IList<ObjPhieuTron> BuildListObjPhieuTron(IList<PhieuTron> lstEntPhieuTron)
		{
			IList<ObjPhieuTron> lstObjPhieuTron = new List<ObjPhieuTron>();
			foreach (PhieuTron entPhieuTron in lstEntPhieuTron)
			{
				lstObjPhieuTron.Add(PhieuTronHelper.BuildNewObjPhieuTron(entPhieuTron));
			}
			return lstObjPhieuTron;
		}

		public static PhieuTron BuildNewEntPhieuTron(ObjPhieuTron objPhieuTron)
		{
			PhieuTron entPhieuTron = new PhieuTron();
			PhieuTronHelper.CopyToEntPhieuTron(objPhieuTron, entPhieuTron);
			return entPhieuTron;
		}

		public static IList<PhieuTron> BuildListEntPhieuTron(IList<ObjPhieuTron> lstObjPhieuTron)
		{
			IList<PhieuTron> lstEntPhieuTron = new List<PhieuTron>();
			foreach (ObjPhieuTron objPhieuTron in lstObjPhieuTron)
			{
				lstEntPhieuTron.Add(PhieuTronHelper.BuildNewEntPhieuTron(objPhieuTron));
			}
			return lstEntPhieuTron;
		}
	}
}

using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class DuLieuTronHelper
	{
		public static void CopyToDuLieuTron_FromHopDong(ObjHopDong fromHopDong, ObjDuLieuTron toDuLieuTron)
		{
			toDuLieuTron.HopDongID = new int?(fromHopDong.HopDongID);
			toDuLieuTron.MaHopDong = fromHopDong.MaHopDong;
			toDuLieuTron.TenHopDong = fromHopDong.TenHopDong;
			toDuLieuTron.NgayHopDong = fromHopDong.NgayHopDong;
			toDuLieuTron.MoTa = fromHopDong.MoTa;
			toDuLieuTron.KhachHangID = fromHopDong.KhachHangID;
			toDuLieuTron.CongTruongID = fromHopDong.CongTruongID;
			toDuLieuTron.MACID = fromHopDong.MACID;
			toDuLieuTron.HangMucID = fromHopDong.HangMucID;
			toDuLieuTron.DoSut = fromHopDong.DoSut;
			toDuLieuTron.KLDatHang = fromHopDong.KLDatHang;
			toDuLieuTron.KLDaGiao = fromHopDong.KLDaGiao;
			toDuLieuTron.KLConLai = fromHopDong.KLConLai;
			toDuLieuTron.KLTaoPhieuTron = fromHopDong.KLTaoPhieuTron;
			toDuLieuTron.TongPhieu = fromHopDong.TongPhieu;
			toDuLieuTron.Status = fromHopDong.Status;
			toDuLieuTron.DLT_KLDuTinh = fromHopDong.DLT_KLDuTinh;
			toDuLieuTron.DLT_KLTronNhoNhat = fromHopDong.DLT_KLTronNhoNhat;
			toDuLieuTron.DLT_KLTronLonNhat = fromHopDong.DLT_KLTronLonNhat;
			toDuLieuTron.DLT_KLDuTinhCuaTungMe = fromHopDong.DLT_KLDuTinhCuaTungMe;
			toDuLieuTron.DLT_KLDuTinhCuaTungMe_NoiB = fromHopDong.DLT_KLDuTinhCuaTungMe_NoiB;
			toDuLieuTron.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed = fromHopDong.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed;
			toDuLieuTron.DLT_KLBuTruMeCuoi = fromHopDong.DLT_KLBuTruMeCuoi;
			toDuLieuTron.DLT_SLMeDuTinh = fromHopDong.DLT_SLMeDuTinh;
			toDuLieuTron.DLT_KLXeChoLonNhat = fromHopDong.DLT_KLXeChoLonNhat;
			toDuLieuTron.DLT_MACSUMSiloValueCalc = fromHopDong.DLT_MACSUMSiloValueCalc;
			toDuLieuTron.DLT_MACSUMSiloValue = fromHopDong.DLT_MACSUMSiloValue;
			toDuLieuTron.NPKhachHangMaKhachHang = fromHopDong.NPKhachHangMaKhachHang;
			toDuLieuTron.NPKhachHangTenKhachHang = fromHopDong.NPKhachHangTenKhachHang;
			toDuLieuTron.NPCongTruongMaCongTruong = fromHopDong.NPCongTruongMaCongTruong;
			toDuLieuTron.NPCongTruongTenCongTruong = fromHopDong.NPCongTruongTenCongTruong;
			toDuLieuTron.NPMACMaMAC = fromHopDong.NPMACMaMAC;
			toDuLieuTron.NPMACTenMAC = fromHopDong.NPMACTenMAC;
			toDuLieuTron.NPMACThemBotNuoc1 = fromHopDong.NPMACThemBotNuoc1;
			toDuLieuTron.NPMACThemBotNuoc2 = fromHopDong.NPMACThemBotNuoc2;
		}

		public static string GenMemberValues(ObjDuLieuTron obj)
		{
			string r = string.Empty;
			r = r + "#1@#DuLieuTronID#2@#" + obj.DuLieuTronID;
			r = r + "#1@#HopDongID#2@#" + obj.HopDongID;
			r = r + "#1@#MaHopDong#2@#" + obj.MaHopDong;
			r = r + "#1@#TenHopDong#2@#" + obj.TenHopDong;
			r = r + "#1@#NgayHopDong#2@#" + obj.NgayHopDong;
			r = r + "#1@#MoTa#2@#" + obj.MoTa;
			r = r + "#1@#KhachHangID#2@#" + obj.KhachHangID;
			r = r + "#1@#CongTruongID#2@#" + obj.CongTruongID;
			r = r + "#1@#MACID#2@#" + obj.MACID;
			r = r + "#1@#HangMucID#2@#" + obj.HangMucID;
			r = r + "#1@#DoSut#2@#" + obj.DoSut;
			r = r + "#1@#KLDatHang#2@#" + obj.KLDatHang;
			r = r + "#1@#KLDaGiao#2@#" + obj.KLDaGiao;
			r = r + "#1@#KLConLai#2@#" + obj.KLConLai;
			r = r + "#1@#KLTaoPhieuTron#2@#" + obj.KLTaoPhieuTron;
			r = r + "#1@#Status#2@#" + obj.Status;
			r = r + "#1@#LastStatus#2@#" + obj.LastStatus;
			r = r + "#1@#LnNo#2@#" + obj.LnNo;
			r = r + "#1@#NPKhachHangMaKhachHang#2@#" + obj.NPKhachHangMaKhachHang;
			r = r + "#1@#NPKhachHangTenKhachHang#2@#" + obj.NPKhachHangTenKhachHang;
			r = r + "#1@#NPCongTruongMaCongTruong#2@#" + obj.NPCongTruongMaCongTruong;
			r = r + "#1@#NPCongTruongTenCongTruong#2@#" + obj.NPCongTruongTenCongTruong;
			r = r + "#1@#NPMACMaMAC#2@#" + obj.NPMACMaMAC;
			r = r + "#1@#NPMACTenMAC#2@#" + obj.NPMACTenMAC;
			r = r + "#1@#DLT_KLDuTinh#2@#" + obj.DLT_KLDuTinh;
			r = r + "#1@#DLT_KLTronNhoNhat#2@#" + obj.DLT_KLTronNhoNhat;
			r = r + "#1@#DLT_KLTronLonNhat#2@#" + obj.DLT_KLTronLonNhat;
			r = r + "#1@#DLT_KLDuTinhCuaTungMe#2@#" + obj.DLT_KLDuTinhCuaTungMe;
			r = r + "#1@#DLT_KLDuTinhCuaTungMe_NoiB#2@#" + obj.DLT_KLDuTinhCuaTungMe_NoiB;
			r = r + "#1@#DLT_KLDuTinhCuaTungMe_NoiB_IsUsed#2@#" + obj.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed.ToString();
			r = r + "#1@#DLT_KLBuTruMeCuoi#2@#" + obj.DLT_KLBuTruMeCuoi;
			r = r + "#1@#DLT_SLMeDuTinh#2@#" + obj.DLT_SLMeDuTinh;
			r = r + "#1@#DLT_KLXeChoLonNhat#2@#" + obj.DLT_KLXeChoLonNhat;
			r = r + "#1@#DLT_MACSUMSiloValueCalc#2@#" + obj.DLT_MACSUMSiloValueCalc;
			r = r + "#1@#DLT_MACSUMSiloValue#2@#" + obj.DLT_MACSUMSiloValue;
			r = r + "#1@#Activated#2@#" + obj.Activated.ToString();
			r = r + "#1@#CreationDate#2@#" + obj.CreationDate;
			r = r + "#1@#CreatedBy#2@#" + obj.CreatedBy;
			r = r + "#1@#LatestUpdateDate#2@#" + obj.LatestUpdateDate;
			r = r + "#1@#LatestUpdatedBy#2@#" + obj.LatestUpdatedBy;
			return r + "#1@#VersionNo#2@#" + obj.VersionNo;
		}

		public static string GenMemberValues(DuLieuTron ent)
		{
			string r = string.Empty;
			r = r + "#1@#DuLieuTronID#2@#" + ent.DuLieuTronID;
			r = r + "#1@#HopDongID#2@#" + ent.HopDongID;
			r = r + "#1@#MaHopDong#2@#" + ent.MaHopDong;
			r = r + "#1@#TenHopDong#2@#" + ent.TenHopDong;
			r = r + "#1@#NgayHopDong#2@#" + ent.NgayHopDong;
			r = r + "#1@#MoTa#2@#" + ent.MoTa;
			r = r + "#1@#KhachHangID#2@#" + ent.KhachHangID;
			r = r + "#1@#CongTruongID#2@#" + ent.CongTruongID;
			r = r + "#1@#MACID#2@#" + ent.MACID;
			r = r + "#1@#HangMucID#2@#" + ent.HangMucID;
			r = r + "#1@#DoSut#2@#" + ent.DoSut;
			r = r + "#1@#KLDatHang#2@#" + ent.KLDatHang;
			r = r + "#1@#KLDaGiao#2@#" + ent.KLDaGiao;
			r = r + "#1@#KLConLai#2@#" + ent.KLConLai;
			r = r + "#1@#KLTaoPhieuTron#2@#" + ent.KLTaoPhieuTron;
			r = r + "#1@#Status#2@#" + ent.Status;
			r = r + "#1@#LastStatus#2@#" + ent.LastStatus;
			r = r + "#1@#LnNo#2@#" + ent.LnNo;
			r = r + "#1@#NPKhachHangMaKhachHang#2@#" + ent.NPKhachHangMaKhachHang;
			r = r + "#1@#NPKhachHangTenKhachHang#2@#" + ent.NPKhachHangTenKhachHang;
			r = r + "#1@#NPCongTruongMaCongTruong#2@#" + ent.NPCongTruongMaCongTruong;
			r = r + "#1@#NPCongTruongTenCongTruong#2@#" + ent.NPCongTruongTenCongTruong;
			r = r + "#1@#NPMACMaMAC#2@#" + ent.NPMACMaMAC;
			r = r + "#1@#NPMACTenMAC#2@#" + ent.NPMACTenMAC;
			r = r + "#1@#DLT_KLDuTinh#2@#" + ent.DLT_KLDuTinh;
			r = r + "#1@#DLT_KLTronNhoNhat#2@#" + ent.DLT_KLTronNhoNhat;
			r = r + "#1@#DLT_KLTronLonNhat#2@#" + ent.DLT_KLTronLonNhat;
			r = r + "#1@#DLT_KLDuTinhCuaTungMe#2@#" + ent.DLT_KLDuTinhCuaTungMe;
			r = r + "#1@#DLT_KLDuTinhCuaTungMe_NoiB#2@#" + ent.DLT_KLDuTinhCuaTungMe_NoiB;
			r = r + "#1@#DLT_KLDuTinhCuaTungMe_NoiB_IsUsed#2@#" + ent.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed.ToString();
			r = r + "#1@#DLT_KLBuTruMeCuoi#2@#" + ent.DLT_KLBuTruMeCuoi;
			r = r + "#1@#DLT_SLMeDuTinh#2@#" + ent.DLT_SLMeDuTinh;
			r = r + "#1@#DLT_KLXeChoLonNhat#2@#" + ent.DLT_KLXeChoLonNhat;
			r = r + "#1@#DLT_MACSUMSiloValueCalc#2@#" + ent.DLT_MACSUMSiloValueCalc;
			r = r + "#1@#DLT_MACSUMSiloValue#2@#" + ent.DLT_MACSUMSiloValue;
			r = r + "#1@#Activated#2@#" + ent.Activated.ToString();
			r = r + "#1@#CreationDate#2@#" + ent.CreationDate;
			r = r + "#1@#CreatedBy#2@#" + ent.CreatedBy;
			r = r + "#1@#LatestUpdateDate#2@#" + ent.LatestUpdateDate;
			r = r + "#1@#LatestUpdatedBy#2@#" + ent.LatestUpdatedBy;
			return r + "#1@#VersionNo#2@#" + ent.VersionNo;
		}

		public static void CopyToObjDuLieuTron(DuLieuTron fromEnt, ObjDuLieuTron toObj)
		{
			toObj.DuLieuTronID = fromEnt.DuLieuTronID;
			toObj.HopDongID = fromEnt.HopDongID;
			toObj.MaHopDong = fromEnt.MaHopDong;
			toObj.TenHopDong = fromEnt.TenHopDong;
			toObj.NgayHopDong = fromEnt.NgayHopDong;
			toObj.MoTa = fromEnt.MoTa;
			toObj.KhachHangID = fromEnt.KhachHangID;
			toObj.CongTruongID = fromEnt.CongTruongID;
			toObj.MACID = fromEnt.MACID;
			toObj.HangMucID = fromEnt.HangMucID;
			toObj.DoSut = fromEnt.DoSut;
			toObj.KLDatHang = fromEnt.KLDatHang;
			toObj.KLDaGiao = fromEnt.KLDaGiao;
			toObj.KLConLai = fromEnt.KLConLai;
			toObj.KLTaoPhieuTron = fromEnt.KLTaoPhieuTron;
			toObj.Status = fromEnt.Status;
			toObj.LastStatus = fromEnt.LastStatus;
			toObj.LnNo = fromEnt.LnNo;
			toObj.NPKhachHangMaKhachHang = fromEnt.NPKhachHangMaKhachHang;
			toObj.NPKhachHangTenKhachHang = fromEnt.NPKhachHangTenKhachHang;
			toObj.NPCongTruongMaCongTruong = fromEnt.NPCongTruongMaCongTruong;
			toObj.NPCongTruongTenCongTruong = fromEnt.NPCongTruongTenCongTruong;
			toObj.NPMACMaMAC = fromEnt.NPMACMaMAC;
			toObj.NPMACTenMAC = fromEnt.NPMACTenMAC;
			toObj.DLT_KLDuTinh = fromEnt.DLT_KLDuTinh;
			toObj.DLT_KLTronNhoNhat = fromEnt.DLT_KLTronNhoNhat;
			toObj.DLT_KLTronLonNhat = fromEnt.DLT_KLTronLonNhat;
			toObj.DLT_KLDuTinhCuaTungMe = fromEnt.DLT_KLDuTinhCuaTungMe;
			toObj.DLT_KLDuTinhCuaTungMe_NoiB = fromEnt.DLT_KLDuTinhCuaTungMe_NoiB;
			toObj.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed = fromEnt.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed;
			toObj.DLT_KLBuTruMeCuoi = fromEnt.DLT_KLBuTruMeCuoi;
			toObj.DLT_SLMeDuTinh = fromEnt.DLT_SLMeDuTinh;
			toObj.DLT_KLXeChoLonNhat = fromEnt.DLT_KLXeChoLonNhat;
			toObj.DLT_MACSUMSiloValueCalc = fromEnt.DLT_MACSUMSiloValueCalc;
			toObj.DLT_MACSUMSiloValue = fromEnt.DLT_MACSUMSiloValue;
			toObj.Activated = fromEnt.Activated;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			toObj.VersionNo = fromEnt.VersionNo;
			if (toObj.DuLieuTronID > 0)
			{
				toObj.IsNewObject = false;
			}
			if (fromEnt.HopDong != null)
			{
				toObj.NPKhachHangMaKhachHang = fromEnt.HopDong.KhachHang.MaKhachHang;
			}
			if (fromEnt.HopDong != null)
			{
				toObj.NPKhachHangTenKhachHang = fromEnt.HopDong.KhachHang.TenKhachHang;
			}
			if (fromEnt.HopDong != null)
			{
				toObj.NPCongTruongMaCongTruong = fromEnt.HopDong.CongTruong.MaCongTruong;
			}
			if (fromEnt.HopDong != null)
			{
				toObj.NPCongTruongTenCongTruong = fromEnt.HopDong.CongTruong.TenCongTruong;
			}
			if (fromEnt.HopDong != null)
			{
				toObj.NPMACMaMAC = fromEnt.HopDong.MAC.MaMAC;
			}
			if (fromEnt.HopDong != null)
			{
				toObj.NPMACTenMAC = fromEnt.HopDong.MAC.TenMAC;
			}
			if (fromEnt.HopDong != null)
			{
				toObj.TongPhieu = fromEnt.HopDong.TongPhieu;
			}
		}

		public static void CopyToEntDuLieuTron(ObjDuLieuTron fromObj, DuLieuTron toEnt)
		{
			toEnt.DuLieuTronID = fromObj.DuLieuTronID;
			toEnt.HopDongID = fromObj.HopDongID;
			toEnt.MaHopDong = fromObj.MaHopDong;
			toEnt.TenHopDong = fromObj.TenHopDong;
			toEnt.NgayHopDong = fromObj.NgayHopDong;
			toEnt.MoTa = fromObj.MoTa;
			toEnt.KhachHangID = fromObj.KhachHangID;
			toEnt.CongTruongID = fromObj.CongTruongID;
			toEnt.MACID = fromObj.MACID;
			toEnt.HangMucID = fromObj.HangMucID;
			toEnt.DoSut = fromObj.DoSut;
			toEnt.KLDatHang = fromObj.KLDatHang;
			toEnt.KLDaGiao = fromObj.KLDaGiao;
			toEnt.KLConLai = fromObj.KLConLai;
			toEnt.KLTaoPhieuTron = fromObj.KLTaoPhieuTron;
			toEnt.Status = fromObj.Status;
			toEnt.LastStatus = fromObj.LastStatus;
			toEnt.LnNo = fromObj.LnNo;
			toEnt.NPKhachHangMaKhachHang = fromObj.NPKhachHangMaKhachHang;
			toEnt.NPKhachHangTenKhachHang = fromObj.NPKhachHangTenKhachHang;
			toEnt.NPCongTruongMaCongTruong = fromObj.NPCongTruongMaCongTruong;
			toEnt.NPCongTruongTenCongTruong = fromObj.NPCongTruongTenCongTruong;
			toEnt.NPMACMaMAC = fromObj.NPMACMaMAC;
			toEnt.NPMACTenMAC = fromObj.NPMACTenMAC;
			toEnt.DLT_KLDuTinh = fromObj.DLT_KLDuTinh;
			toEnt.DLT_KLTronNhoNhat = fromObj.DLT_KLTronNhoNhat;
			toEnt.DLT_KLTronLonNhat = fromObj.DLT_KLTronLonNhat;
			toEnt.DLT_KLDuTinhCuaTungMe = fromObj.DLT_KLDuTinhCuaTungMe;
			toEnt.DLT_KLDuTinhCuaTungMe_NoiB = fromObj.DLT_KLDuTinhCuaTungMe_NoiB;
			toEnt.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed = fromObj.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed;
			toEnt.DLT_KLBuTruMeCuoi = fromObj.DLT_KLBuTruMeCuoi;
			toEnt.DLT_SLMeDuTinh = fromObj.DLT_SLMeDuTinh;
			toEnt.DLT_KLXeChoLonNhat = fromObj.DLT_KLXeChoLonNhat;
			toEnt.DLT_MACSUMSiloValueCalc = fromObj.DLT_MACSUMSiloValueCalc;
			toEnt.DLT_MACSUMSiloValue = fromObj.DLT_MACSUMSiloValue;
			toEnt.Activated = fromObj.Activated;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
			toEnt.VersionNo = fromObj.VersionNo;
		}

		public static ObjDuLieuTron BuildNewObjDuLieuTron(DuLieuTron entDuLieuTron)
		{
			ObjDuLieuTron objDuLieuTron = new ObjDuLieuTron();
			DuLieuTronHelper.CopyToObjDuLieuTron(entDuLieuTron, objDuLieuTron);
			return objDuLieuTron;
		}

		public static IList<ObjDuLieuTron> BuildListObjDuLieuTron(IList<DuLieuTron> lstEntDuLieuTron)
		{
			IList<ObjDuLieuTron> lstObjDuLieuTron = new List<ObjDuLieuTron>();
			foreach (DuLieuTron entDuLieuTron in lstEntDuLieuTron)
			{
				lstObjDuLieuTron.Add(DuLieuTronHelper.BuildNewObjDuLieuTron(entDuLieuTron));
			}
			return lstObjDuLieuTron;
		}

		public static DuLieuTron BuildNewEntDuLieuTron(ObjDuLieuTron objDuLieuTron)
		{
			DuLieuTron entDuLieuTron = new DuLieuTron();
			DuLieuTronHelper.CopyToEntDuLieuTron(objDuLieuTron, entDuLieuTron);
			return entDuLieuTron;
		}

		public static IList<DuLieuTron> BuildListEntDuLieuTron(IList<ObjDuLieuTron> lstObjDuLieuTron)
		{
			IList<DuLieuTron> lstEntDuLieuTron = new List<DuLieuTron>();
			foreach (ObjDuLieuTron objDuLieuTron in lstObjDuLieuTron)
			{
				lstEntDuLieuTron.Add(DuLieuTronHelper.BuildNewEntDuLieuTron(objDuLieuTron));
			}
			return lstEntDuLieuTron;
		}
	}
}

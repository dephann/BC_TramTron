using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    public class PhieuGiaoHangHelper
    {
        public static void CopyToObjPhieuTron(PhieuGiaoHang fromEnt, ObjPhieuGiaoHang toObj)
        {
            toObj.PhieuTronID = fromEnt.PhieuTronID;
            toObj.MaPhieuTron = fromEnt.MaPhieuTron;
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
            toObj.TenKhachHang = fromEnt.TenKhachHang;
            toObj.CongTruongID = fromEnt.CongTruongID;
            toObj.TenCongTruong = fromEnt.TenCongTruong;
            toObj.HangMucID = fromEnt.HangMucID;
            toObj.TenHangMuc = fromEnt.TenHangMuc;
            toObj.DiaDiem = fromEnt.DiaDiem;
            toObj.MACID = fromEnt.MACID;
            toObj.TenMAC = fromEnt.TenMAC;
            toObj.CuongDo = fromEnt.CuongDo;
            toObj.DoSut = fromEnt.DoSut;
            toObj.TheTich = fromEnt.TheTich;
            toObj.LuyKe = fromEnt.LuyKe;
            toObj.TaiXeID = fromEnt.TaiXeID;
            toObj.TenTaiXe = fromEnt.TenTaiXe;
            toObj.XeID = fromEnt.XeID;
            toObj.BienSo = fromEnt.BienSo;
            toObj.NiemChi = fromEnt.NiemChi;
            toObj.NguoiTron = fromEnt.NguoiTron;
            toObj.Temp1 = fromEnt.Temp1;
            toObj.Temp2 = fromEnt.Temp2;
            toObj.GioBD = fromEnt.GioBD;
            toObj.GioKT = fromEnt.GioKT;
            toObj.Activated = fromEnt.Activated;
            toObj.CreationDate = fromEnt.CreationDate;
            toObj.CreatedBy = fromEnt.CreatedBy;
            toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
            toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
            toObj.MaHopDong = fromEnt.MaHopDong;
            toObj.NoPhieu = fromEnt.NoPhieu;

            if (toObj.PhieuTronID > 0)
            {
                toObj.IsNewObject = false;
            }
        }

        public static void CopyToEntPhieuTron(ObjPhieuGiaoHang fromObj, PhieuGiaoHang toEnt)
        {
            toEnt.PhieuTronID = fromObj.PhieuTronID;
            toEnt.MaPhieuTron = fromObj.MaPhieuTron;
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
            toEnt.TenKhachHang = fromObj.TenKhachHang;
            toEnt.CongTruongID = fromObj.CongTruongID;
            toEnt.TenCongTruong = fromObj.TenCongTruong;
            toEnt.HangMucID = fromObj.HangMucID;
            toEnt.TenHangMuc = fromObj.TenHangMuc;
            toEnt.DiaDiem = fromObj.DiaDiem;
            toEnt.MACID = fromObj.MACID;
            toEnt.TenMAC = fromObj.TenMAC;
            toEnt.CuongDo = fromObj.CuongDo;
            toEnt.DoSut = fromObj.DoSut;
            toEnt.TheTich = fromObj.TheTich;
            toEnt.LuyKe = fromObj.LuyKe;
            toEnt.TaiXeID = fromObj.TaiXeID;
            toEnt.TenTaiXe = fromObj.TenTaiXe;
            toEnt.XeID = fromObj.XeID;
            toEnt.BienSo = fromObj.BienSo;
            toEnt.NiemChi = fromObj.NiemChi;
            toEnt.NguoiTron = fromObj.NguoiTron;
            toEnt.Temp1 = fromObj.Temp1;
            toEnt.Temp2 = fromObj.Temp2;
            toEnt.GioBD = fromObj.GioBD;
            toEnt.GioKT = fromObj.GioKT;
            toEnt.Activated = fromObj.Activated;
            toEnt.CreationDate = fromObj.CreationDate;
            toEnt.CreatedBy = fromObj.CreatedBy;
            toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
            toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
            toEnt.MaHopDong = fromObj.MaHopDong;
            toEnt.NoPhieu = fromObj.NoPhieu;
        }

        public static ObjPhieuGiaoHang BuildNewObjPhieuTron(PhieuGiaoHang entPhieuTron)
        {
            ObjPhieuGiaoHang objPhieuTron = new ObjPhieuGiaoHang();
            PhieuGiaoHangHelper.CopyToObjPhieuTron(entPhieuTron, objPhieuTron);
            return objPhieuTron;
        }

        public static IList<ObjPhieuGiaoHang> BuildListObjPhieuTron(IList<PhieuGiaoHang> lstEntPhieuTron)
        {
            IList<ObjPhieuGiaoHang> lstObjPhieuTron = new List<ObjPhieuGiaoHang>();
            foreach (PhieuGiaoHang entPhieuTron in lstEntPhieuTron)
            {
                lstObjPhieuTron.Add(PhieuGiaoHangHelper.BuildNewObjPhieuTron(entPhieuTron));
            }
            return lstObjPhieuTron;
        }

        public static PhieuGiaoHang BuildNewEntPhieuTron(ObjPhieuGiaoHang objPhieuTron)
        {
            PhieuGiaoHang entPhieuTron = new PhieuGiaoHang();
            PhieuGiaoHangHelper.CopyToEntPhieuTron(objPhieuTron, entPhieuTron);
            return entPhieuTron;
        }

        public static IList<PhieuGiaoHang> BuildListEntPhieuTron(IList<ObjPhieuGiaoHang> lstObjPhieuTron)
        {
            IList<PhieuGiaoHang> lstEntPhieuTron = new List<PhieuGiaoHang>();
            foreach (ObjPhieuGiaoHang objPhieuTron in lstObjPhieuTron)
            {
                lstEntPhieuTron.Add(PhieuGiaoHangHelper.BuildNewEntPhieuTron(objPhieuTron));
            }
            return lstEntPhieuTron;
        }
    }
}

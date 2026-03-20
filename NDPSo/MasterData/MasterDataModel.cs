using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using NDPSo.ClientSetting;
using NDPSo.Data;
using NDPSo.Utils;

namespace NDPSo.MasterData
{
	public class MasterDataModel : IMasterDataModel, IBase
	{
		public BindingList<ObjCongTruong> ListCongTruong()
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjCongTruong> lstT = factory.ListCongTruong() as List<ObjCongTruong>;
			return Converter.ConvertToBindingList<ObjCongTruong>(lstT);
		}

		public BindingList<ObjCongTruong> ListCongTruong_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string diaChi, string phone, bool? active)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjCongTruong> lstT = factory.ListCongTruong_ByCondition(fromDate, toDate, maKH, tenKH, diaChi, phone, active) as List<ObjCongTruong>;
			return Converter.ConvertToBindingList<ObjCongTruong>(lstT);
		}

		public bool SaveCongTruong(BindingList<ObjCongTruong> blstCT)
		{
			List<ObjCongTruong> lstCT = Converter.ConvertToList<ObjCongTruong>(blstCT);
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.SaveCongTruong(lstCT);
		}

		public ObjCongTruong GetCongTruongByKey(int ctID)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.GetCongTruongByKey(ctID);
		}

		public BindingList<ObjDuLieuTron> ListDuLieuTron(bool includeInActivated)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjDuLieuTron> lstT = factory.ListDuLieuTron(includeInActivated) as List<ObjDuLieuTron>;
			return Converter.ConvertToBindingList<ObjDuLieuTron>(lstT);
		}

		public bool SaveDuLieuTron(BindingList<ObjDuLieuTron> blstCT)
		{
			List<ObjDuLieuTron> list = Converter.ConvertToList<ObjDuLieuTron>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveDuLieuTron((IList<ObjDuLieuTron>)list);
		}


		public ObjDuLieuTron GetDuLieuTronByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetDuLieuTronByKey(ctID);

		public ObjDuLieuTron AddDuLieuTron(ObjDuLieuTron objDLT) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).AddDuLieuTron(objDLT);

		public ObjDuLieuTron UpdateDuLieuTron(ObjDuLieuTron objDLT) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).UpdateDuLieuTron(objDLT);

		public bool DeleteDulieuTron(int id) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).DeleteDulieuTron(id);

		public BindingList<ObjHopDong> ListHopDong() => Converter.ConvertToBindingList<ObjHopDong>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListHopDong() as List<ObjHopDong>);

		public BindingList<ObjHopDong> ListHopDong_ByCondition(
		  string maHopDong,
		  DateTime fromDate,
		  DateTime toDate,
		  int? status,
		  int? khachHangID,
		  int? congTruongID,
		  int? macID)
		{
			return Converter.ConvertToBindingList<ObjHopDong>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListHopDong_ByCondition(maHopDong, fromDate, toDate, status, khachHangID, congTruongID, macID) as List<ObjHopDong>);
		}

		public bool SaveHopDong(BindingList<ObjHopDong> blstCT)
		{
			List<ObjHopDong> list = Converter.ConvertToList<ObjHopDong>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveHopDong((IList<ObjHopDong>)list);
		}

		public ObjHopDong SaveHopDong(ObjHopDong objHD) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveHopDong(objHD);

		public ObjHopDong SaveHopDong(ObjHopDong objHD, ObjDuLieuTron objDLT) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveHopDong(objHD, objDLT);

		public ObjHopDong GetHopDongByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetHopDongByKey(ctID);

		public ObjHopDong GetHopDongByMaHD(string maHD) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetHopDongByMaHD(maHD);




		public BindingList<ObjKhachHang> ListKhachHang()
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjKhachHang> lstT = factory.ListKhachHang() as List<ObjKhachHang>;
			return Converter.ConvertToBindingList<ObjKhachHang>(lstT);
		}

		public BindingList<ObjKhachHang> ListKhachHang_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string diaChi, string phone, bool? active)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjKhachHang> lstT = factory.ListKhachHang_ByCondition(fromDate, toDate, maKH, tenKH, diaChi, phone, active) as List<ObjKhachHang>;
			return Converter.ConvertToBindingList<ObjKhachHang>(lstT);
		}

		public bool SaveKhachHang(BindingList<ObjKhachHang> blstCT)
		{
			List<ObjKhachHang> lstCT = Converter.ConvertToList<ObjKhachHang>(blstCT);
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.SaveKhachHang(lstCT);
		}

		public BindingList<ObjMAC> ListMAC() => Converter.ConvertToBindingList<ObjMAC>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMAC() as List<ObjMAC>);

		public BindingList<ObjMAC> ListMAC_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maMAC,
		  string tenMAC,
		  bool? active)
		{
			return Converter.ConvertToBindingList<ObjMAC>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMAC_ByCondition(fromDate, toDate, maMAC, tenMAC, active) as List<ObjMAC>);
		}

		public bool SaveMAC(BindingList<ObjMAC> blstCT)
		{
			List<ObjMAC> list = Converter.ConvertToList<ObjMAC>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveMAC((IList<ObjMAC>)list);
		}

		public ObjMAC GetMACByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetMACByKey(ctID);

		public BindingList<ObjMACSilo> ListMACSilo() => Converter.ConvertToBindingList<ObjMACSilo>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMACSilo() as List<ObjMACSilo>);

		public BindingList<ObjMACSilo> ListMACSilo_ByMACID(int macID) => Converter.ConvertToBindingList<ObjMACSilo>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMACSilo_ByMACID(macID) as List<ObjMACSilo>);

		public BindingList<ObjMACSilo> ListMACSilo_ByPhieuTronID(int ptID) => Converter.ConvertToBindingList<ObjMACSilo>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMACSilo_ByPhieuTronID(ptID) as List<ObjMACSilo>);

		public BindingList<ObjMACSilo> ListMACSilo_ByHopDongID(int hdID) => Converter.ConvertToBindingList<ObjMACSilo>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMACSilo_ByHopDongID(hdID) as List<ObjMACSilo>);

		public bool SaveMACSilo(BindingList<ObjMACSilo> blstCT)
		{
			List<ObjMACSilo> list = Converter.ConvertToList<ObjMACSilo>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveMACSilo((IList<ObjMACSilo>)list);
		}

		public ObjMACSilo GetMACSiloByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetMACSiloByKey(ctID);

		public BindingList<ObjMaterial> ListMaterial() => Converter.ConvertToBindingList<ObjMaterial>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMaterial() as List<ObjMaterial>);

		public BindingList<ObjMaterial> ListMaterial_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maVT,
		  string tenVT,
		  bool? active)
		{
			return Converter.ConvertToBindingList<ObjMaterial>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMaterial_ByCondition(fromDate, toDate, maVT, tenVT, active) as List<ObjMaterial>);
		}

		public bool SaveMaterial(BindingList<ObjMaterial> blstCT)
		{
			List<ObjMaterial> list = Converter.ConvertToList<ObjMaterial>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveMaterial((IList<ObjMaterial>)list);
		}

		public ObjMaterial GetMaterialByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetMaterialByKey(ctID);



		public ObjKhachHang GetKhachHangByKey(int ctID)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.GetKhachHangByKey(ctID);
		}

		public BindingList<ObjMeTron> ListMeTron() => Converter.ConvertToBindingList<ObjMeTron>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMeTron() as List<ObjMeTron>);

		public BindingList<ObjMeTron> ListMeTronByPhieuTronID(int ptID) => Converter.ConvertToBindingList<ObjMeTron>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMeTronByPhieuTronID(ptID) as List<ObjMeTron>);

		public bool SaveMeTron(BindingList<ObjMeTron> blstCT)
		{
			List<ObjMeTron> list = Converter.ConvertToList<ObjMeTron>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveMeTron((IList<ObjMeTron>)list);
		}

		public ObjMeTron GetMeTronByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetMeTronByKey(ctID);

		public BindingList<ObjMeTronChiTiet> ListMeTronChiTiet() => Converter.ConvertToBindingList<ObjMeTronChiTiet>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMeTronChiTiet() as List<ObjMeTronChiTiet>);

		public BindingList<ObjMeTronChiTiet> ListMeTronChiTietByPhieuTronID(int ptID) => Converter.ConvertToBindingList<ObjMeTronChiTiet>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMeTronChiTietByPhieuTronID(ptID) as List<ObjMeTronChiTiet>);
		public BindingList<ObjMeTronChiTietGiaoHang> ListMeTronChiTietGiaoHangByPhieuTronID(int ptID) => Converter.ConvertToBindingList<ObjMeTronChiTietGiaoHang>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMeTronChiTietGiaoHangByPhieuTronID(ptID) as List<ObjMeTronChiTietGiaoHang>);

		public bool SaveMeTronChiTiet(BindingList<ObjMeTronChiTiet> blstCT)
		{
			List<ObjMeTronChiTiet> list = Converter.ConvertToList<ObjMeTronChiTiet>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveMeTronChiTiet((IList<ObjMeTronChiTiet>)list);
		}

		public ObjMeTronChiTiet SaveMeTronChiTiet(ObjMeTronChiTiet objMTCT, int phieuTronID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveMeTronChiTiet(objMTCT, phieuTronID);
		public ObjMeTronChiTietGiaoHang SaveMeTronChiTietGiaoHang(ObjMeTronChiTietGiaoHang objMTCT, int phieuTronID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveMeTronChiTietGiaoHang(objMTCT, phieuTronID);

		public ObjMeTronChiTiet GetMeTronChiTietByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetMeTronChiTietByKey(ctID);


		public BindingList<ObjNhomSilo> ListNhomSilo() => Converter.ConvertToBindingList<ObjNhomSilo>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListNhomSilo() as List<ObjNhomSilo>);

		public bool SaveNhomSilo(BindingList<ObjNhomSilo> blstCT)
		{
			List<ObjNhomSilo> list = Converter.ConvertToList<ObjNhomSilo>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveNhomSilo((IList<ObjNhomSilo>)list);
		}

		public ObjNhomSilo GetNhomSiloByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetNhomSiloByKey(ctID);


		public BindingList<ObjPhieuTron> ListPhieuTron() => new BindingList<ObjPhieuTron>((IList<ObjPhieuTron>)(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListPhieuTron() as List<ObjPhieuTron>));
        public BindingList<ObjPhieuGiaoHang> ListPhieuGiaoHang() => new BindingList<ObjPhieuGiaoHang>((IList<ObjPhieuGiaoHang>)(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListPhieuGiaoHang() as List<ObjPhieuGiaoHang>));

        public BindingList<ObjPhieuTron> ListPhieuTron_ForTronOnline() => new BindingList<ObjPhieuTron>((IList<ObjPhieuTron>)(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListPhieuTron_ForTronOnline() as List<ObjPhieuTron>));

		public BindingList<ObjPhieuTron> ListPhieuTron_ByStatus(int status) => new BindingList<ObjPhieuTron>((IList<ObjPhieuTron>)(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListPhieuTron_ByStatus(status) as List<ObjPhieuTron>));

		public BindingList<ObjPhieuTron> ListPhieuTron_ByIsQueued(bool isQueued) => new BindingList<ObjPhieuTron>((IList<ObjPhieuTron>)(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListPhieuTron_ByIsQueued(isQueued) as List<ObjPhieuTron>));
		public BindingList<ObjPhieuGiaoHang> ListPhieuGiaoHang_ByIsQueued(bool isQueued) => new BindingList<ObjPhieuGiaoHang>((IList<ObjPhieuGiaoHang>)(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListPhieuGiaoHang_ByIsQueued(isQueued) as List<ObjPhieuGiaoHang>));

		public BindingList<ObjPhieuTron> ListPhieuTron_ByCondition(
		  string maPhieuTron,
		  DateTime fromDate,
		  DateTime toDate,
		  int? status,
		  bool? isQueued)
		{
			return new BindingList<ObjPhieuTron>((IList<ObjPhieuTron>)(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListPhieuTron_ByCondition(maPhieuTron, fromDate, toDate, status, isQueued) as List<ObjPhieuTron>));
		}

        public BindingList<ObjPhieuGiaoHang> ListPhieuGiaoHang_ByCondition(
          string maPhieuTron,
          DateTime fromDate,
          DateTime toDate,
          bool? isQueued)
        {
            return new BindingList<ObjPhieuGiaoHang>((IList<ObjPhieuGiaoHang>)(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListPhieuGiaoHang_ByCondition(maPhieuTron, fromDate, toDate, isQueued) as List<ObjPhieuGiaoHang>));
        }

        public bool SavePhieuTron(BindingList<ObjPhieuTron> blstCT)
		{
			List<ObjPhieuTron> list = Converter.ConvertToList<ObjPhieuTron>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SavePhieuTron((IList<ObjPhieuTron>)list);
		}
        public bool SavePhieuGiaoHang(BindingList<ObjPhieuGiaoHang> blstCT)
        {
            List<ObjPhieuGiaoHang> list = Converter.ConvertToList<ObjPhieuGiaoHang>(blstCT);
            return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SavePhieuGiaoHang((IList<ObjPhieuGiaoHang>)list);
        }

        public bool UpdatePhieuTron(ObjPhieuTron objPhieuTron, decimal klThuc)
        {
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).UpdatePhieuTron(objPhieuTron, klThuc);
		}
        public bool UpdatePhieuGiaoHang(ObjPhieuGiaoHang objPhieuTron, string klThuc)
        {
            return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).UpdatePhieuGiaoHang(objPhieuTron, klThuc);
        }
        public bool ResolveUnfinishPhieuTron()
        {
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ResolveUnfinishPhieuTron();

		}
		public ObjPhieuTron GetPhieuTronByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetPhieuTronByKey(ctID);
		public ObjPhieuGiaoHang GetPhieuGiaoHangByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetPhieuGiaoHangByKey(ctID);

		public ObjPhieuTron GetPhieuTronByCode(string code) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetPhieuTronByCode(code);
		public ObjPhieuGiaoHang GetPhieuGiaoHangByCode(string code) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetPhieuGiaoHangByCode(code);

		public Decimal GetKLDTPhieuTron(Decimal klLyThuyet, Decimal klMaxXeCho) => klLyThuyet > klMaxXeCho ? klMaxXeCho : klLyThuyet;

		public int CalcMeTronQty(Decimal kldt, Decimal maxKLT) => kldt == 0M || maxKLT == 0M ? 0 : (int)Math.Ceiling(kldt / maxKLT);

		public Decimal CalcKLDTMeTron(Decimal kldt, int meTronQty) => kldt == 0M || (Decimal)meTronQty == 0M ? 0M : Math.Round(kldt / (Decimal)meTronQty, 2);

		public BindingList<ObjSilo> ListSilo() => Converter.ConvertToBindingList<ObjSilo>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListSilo() as List<ObjSilo>);

		public BindingList<ObjSilo> ListSilo_ByActivated(bool activated) => Converter.ConvertToBindingList<ObjSilo>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListSilo_ByActivated(activated) as List<ObjSilo>);

		public BindingList<ObjSilo> ListSilo_ByActivated_ByMaNhomSilo(bool? activated, string maNhomSL) => Converter.ConvertToBindingList<ObjSilo>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListSilo_ByActivated_MaNhomSilo(activated, maNhomSL) as List<ObjSilo>);

		public bool SaveSilo(BindingList<ObjSilo> blstCT)
		{
			List<ObjSilo> list = Converter.ConvertToList<ObjSilo>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveSilo((IList<ObjSilo>)list);
		}

		public ObjSilo GetSiloByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetSiloByKey(ctID);

		public BindingList<ObjWeigh> ListWeigh() => Converter.ConvertToBindingList<ObjWeigh>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListWeigh() as List<ObjWeigh>);

		public bool SaveWeigh(BindingList<ObjWeigh> blstCT)
		{
			List<ObjWeigh> list = Converter.ConvertToList<ObjWeigh>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveWeigh((IList<ObjWeigh>)list);
		}

		public ObjWeigh GetWeighByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetWeighByKey(ctID);

		public BindingList<ObjWeiSiloSaving> ListWeiSiloSaving() => Converter.ConvertToBindingList<ObjWeiSiloSaving>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListWeiSiloSaving() as List<ObjWeiSiloSaving>);

		public bool SaveWeiSiloSaving(BindingList<ObjWeiSiloSaving> blstCT)
		{
			List<ObjWeiSiloSaving> list = Converter.ConvertToList<ObjWeiSiloSaving>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveWeiSiloSaving((IList<ObjWeiSiloSaving>)list);
		}

		public ObjWeiSiloSaving GetWeiSiloSavingByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetWeiSiloSavingByKey(ctID);

		public BindingList<ObjWeiSiloVisible> ListWeiSiloVisible() => Converter.ConvertToBindingList<ObjWeiSiloVisible>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListWeiSiloVisible() as List<ObjWeiSiloVisible>);

		public bool SaveWeiSiloVisible(BindingList<ObjWeiSiloVisible> blstCT)
		{
			List<ObjWeiSiloVisible> list = Converter.ConvertToList<ObjWeiSiloVisible>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveWeiSiloVisible((IList<ObjWeiSiloVisible>)list);
		}

		public ObjWeiSiloVisible GetWeiSiloVisibleByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetWeiSiloVisibleByKey(ctID);

		public BindingList<ObjHangMuc> ListHangMuc() => Converter.ConvertToBindingList<ObjHangMuc>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListHangMuc() as List<ObjHangMuc>);

		public BindingList<ObjHangMuc> ListHangMuc_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maKH,
		  string tenKH,
		  bool? active)
		{
			return Converter.ConvertToBindingList<ObjHangMuc>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListHangMuc_ByCondition(fromDate, toDate, maKH, tenKH, active) as List<ObjHangMuc>);
		}

		public bool SaveHangMuc(BindingList<ObjHangMuc> blstCT)
		{
			List<ObjHangMuc> list = Converter.ConvertToList<ObjHangMuc>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveHangMuc((IList<ObjHangMuc>)list);
		}

		public ObjHangMuc GetHangMucByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetHangMucByKey(ctID);

		public BindingList<ObjNhanVien> ListNhanVien() => Converter.ConvertToBindingList<ObjNhanVien>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListNhanVien() as List<ObjNhanVien>);

		public BindingList<ObjNhanVien> ListNhanVien_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maKH,
		  string tenKH,
		  string phone,
		  bool? active)
		{
			return Converter.ConvertToBindingList<ObjNhanVien>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListNhanVien_ByCondition(fromDate, toDate, maKH, tenKH, phone, active) as List<ObjNhanVien>);
		}

		public bool SaveNhanVien(BindingList<ObjNhanVien> blstCT)
		{
			List<ObjNhanVien> list = Converter.ConvertToList<ObjNhanVien>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveNhanVien((IList<ObjNhanVien>)list);
		}

		public ObjNhanVien GetNhanVienByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetNhanVienByKey(ctID);


		public BindingList<ObjTaiXe> ListTaiXe() => Converter.ConvertToBindingList<ObjTaiXe>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTaiXe() as List<ObjTaiXe>);

		public BindingList<ObjTaiXe> ListTaiXe_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maKH,
		  string tenKH,
		  string phone,
		  bool? active)
		{
			return Converter.ConvertToBindingList<ObjTaiXe>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTaiXe_ByCondition(fromDate, toDate, maKH, tenKH, phone, active) as List<ObjTaiXe>);
		}

		public bool SaveTaiXe(BindingList<ObjTaiXe> blstCT)
		{
			List<ObjTaiXe> list = Converter.ConvertToList<ObjTaiXe>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveTaiXe((IList<ObjTaiXe>)list);
		}

		public ObjTaiXe GetTaiXeByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetTaiXeByKey(ctID);
		public BindingList<ObjXe> ListXe() => Converter.ConvertToBindingList<ObjXe>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListXe() as List<ObjXe>);

		public BindingList<ObjXe> ListXe_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string bienSo,
		  bool? active)
		{
			return Converter.ConvertToBindingList<ObjXe>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListXe_ByCondition(fromDate, toDate, bienSo, active) as List<ObjXe>);
		}

		public bool SaveXe(BindingList<ObjXe> blstCT)
		{
			List<ObjXe> list = Converter.ConvertToList<ObjXe>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveXe((IList<ObjXe>)list);
		}

		public BindingList<ObjTimerPara> ListTimerPara() => Converter.ConvertToBindingList<ObjTimerPara>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTimerPara() as List<ObjTimerPara>);

		public bool SaveTimerPara(BindingList<ObjTimerPara> blstCT)
		{
			List<ObjTimerPara> list = Converter.ConvertToList<ObjTimerPara>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveTimerPara((IList<ObjTimerPara>)list);
		}

		public ObjTimerPara GetTimerParaByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetTimerParaByKey(ctID);

		public ObjXe GetXeByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetXeByKey(ctID);

		
		public BindingList<ObjTinhDoHutNuoc> ListTinhDoHutNuoc() => Converter.ConvertToBindingList<ObjTinhDoHutNuoc>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTinhDoHutNuoc() as List<ObjTinhDoHutNuoc>);

		public bool SaveTinhDoHutNuoc(BindingList<ObjTinhDoHutNuoc> blstCT)
		{
			List<ObjTinhDoHutNuoc> list = Converter.ConvertToList<ObjTinhDoHutNuoc>(blstCT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveTinhDoHutNuoc((IList<ObjTinhDoHutNuoc>)list);
		}

		public ObjTinhDoHutNuoc GetTinhDoHutNuocByKey(int ctID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetTinhDoHutNuocByKey(ctID);


		public ObjPhieuTron SaveTronOnline(ObjPhieuTron objPT, BindingList<ObjMeTron> blstMT)
		{
			List<ObjMeTron> list = Converter.ConvertToList<ObjMeTron>(blstMT);
			return ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveTronOnline(objPT, list);
		}

		public ObjMAC SaveMacThemBotNuoc1(int macId, Decimal themBotNuoc1) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveMacThemBotNuoc1(macId, themBotNuoc1);

		public ObjMAC SaveMacThemBotNuoc2(int macId, Decimal themBotNuoc2) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).SaveMacThemBotNuoc2(macId, themBotNuoc2);

		
		//=========================================
		public Objvw_DataMix GetDataMixByKey(int dmID) => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).GetDataMixByKey(dmID);
		public BindingList<Objvw_DataMix> ListDataMix() => Converter.ConvertToBindingList<Objvw_DataMix>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListDataMix() as List<Objvw_DataMix>);

		public BindingList<Objvw_DataMix> ListDataMix_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maPT,
		  string khachHang,
		  string congTruong,
		  string hangMuc,
		  string taiXe,
		  string bienSo,
		  string mac,
		  string nhanVien
		  )
		{
			return Converter.ConvertToBindingList<Objvw_DataMix>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListDataMix_ByCondition(fromDate, toDate, maPT, khachHang, congTruong, hangMuc, taiXe, bienSo, mac, nhanVien) as List<Objvw_DataMix>);
		}

		public BindingList<Objvw_DataMix> ListDataMix_ByCondition(
		  DateTime? fromDate,
		  TimeSpan? fromTime,
			DateTime? toDate,
			TimeSpan? toTime,
			string maPhieuTron,
			int? khachHang,
			int? congTruong,
			int? hangMuc,
			int? mac,
			int? bienSo,
			int? taiXe,
			int? nhanVien,
			bool? moPhong)
		{
			return Converter.ConvertToBindingList<Objvw_DataMix>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListDataMix_ByCondition(fromDate, fromTime, toDate, toTime, maPhieuTron, khachHang, congTruong, hangMuc, mac, bienSo, taiXe, nhanVien, moPhong) as List<Objvw_DataMix>);
		}

		public BindingList<Objvw_SumWeight> ListSumWeight_ByCondition(
		  DateTime? fromDate,
			DateTime? toDate,
			string maPhieuTron,
			int? khachHang,
			int? congTruong,
			int? hangMuc,
			int? mac,
			int? bienSo,
			int? taiXe,
			int? nhanVien,
			bool? moPhong)
		{
			return Converter.ConvertToBindingList<Objvw_SumWeight>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListSumWeight_ByCondition(fromDate, toDate, maPhieuTron, khachHang, congTruong, hangMuc, mac, bienSo, taiXe, nhanVien, moPhong) as List<Objvw_SumWeight>);
		}

		public string GetNextCode(string strTblName)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.GetNextCode(strTblName);
		}

		public BindingList<Objvw_MaterialDetailDayWithID> ListTotalMaterial_ByCondition(int? materialID, bool? isManual)
		{
			return Converter.ConvertToBindingList<Objvw_MaterialDetailDayWithID>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTotalMaterial_ByCondition(materialID, isManual) as List<Objvw_MaterialDetailDayWithID>);
		}
		public BindingList<Objvw_MaterialDetailDay> ListMaterialDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? materialID, bool? isManual)
		{
			return Converter.ConvertToBindingList<Objvw_MaterialDetailDay>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMaterialDetailDay_ByCondition(fromDate, toDate, materialID, isManual) as List<Objvw_MaterialDetailDay>);
		}
		public BindingList<Objvw_TranferDetailDayWithID> ListTranferDetailDay_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  int? xeID,
		  bool? isQueued)
		{
			return Converter.ConvertToBindingList<Objvw_TranferDetailDayWithID>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTranferDetailDay_ByCondition(fromDate, toDate, xeID, isQueued) as List<Objvw_TranferDetailDayWithID>);
		}

       
    }
}

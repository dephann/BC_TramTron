using System;
using System.Collections.Generic;
using System.ComponentModel;
using NDPSo.Data;

namespace NDPSo.MasterData
{
	public interface IMasterDataModel : IBase
	{
		ObjCongTruong GetCongTruongByKey(int ctID);

		BindingList<ObjCongTruong> ListCongTruong();

		BindingList<ObjCongTruong> ListCongTruong_ByCondition(DateTime? fromDate, DateTime? toDate, string maCT, string tenCT, string diaChi, string phone, bool? active);

		bool SaveCongTruong(BindingList<ObjCongTruong> blstCT);

		ObjDuLieuTron GetDuLieuTronByKey(int ctID);

		BindingList<ObjDuLieuTron> ListDuLieuTron(bool includeInActivated);

		bool SaveDuLieuTron(BindingList<ObjDuLieuTron> blstCT);

		ObjDuLieuTron AddDuLieuTron(ObjDuLieuTron objDLT);

		ObjDuLieuTron UpdateDuLieuTron(ObjDuLieuTron objDLT);

		bool DeleteDulieuTron(int id);


		ObjHopDong GetHopDongByKey(int ctID);

		ObjHopDong GetHopDongByMaHD(string maHD);

		BindingList<ObjHopDong> ListHopDong();

		BindingList<ObjHopDong> ListHopDong_ByCondition(
		  string maHopDong,
		  DateTime fromDate,
		  DateTime toDate,
		  int? status,
		  int? khachHangID,
		  int? congTruongID,
		  int? macID);

		bool SaveHopDong(BindingList<ObjHopDong> blstCT);

		ObjHopDong SaveHopDong(ObjHopDong objHD);

		ObjHopDong SaveHopDong(ObjHopDong objHD, ObjDuLieuTron objDLT);

		ObjKhachHang GetKhachHangByKey(int ctID);

		BindingList<ObjKhachHang> ListKhachHang();

		BindingList<ObjKhachHang> ListKhachHang_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string diaChi, string phone, bool? active);

		bool SaveKhachHang(BindingList<ObjKhachHang> blstCT);
		ObjMAC GetMACByKey(int ctID);

		BindingList<ObjMAC> ListMAC();

		BindingList<ObjMAC> ListMAC_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maMAC,
		  string tenMAC,
		  bool? active);

		bool SaveMAC(BindingList<ObjMAC> blstCT);


		ObjMeTron GetMeTronByKey(int ctID);

		BindingList<ObjMeTron> ListMeTron();

		BindingList<ObjMeTron> ListMeTronByPhieuTronID(int ptID);

		bool SaveMeTron(BindingList<ObjMeTron> blstCT);

		ObjMeTronChiTiet GetMeTronChiTietByKey(int ctID);

		BindingList<ObjMeTronChiTiet> ListMeTronChiTiet();

		BindingList<ObjMeTronChiTiet> ListMeTronChiTietByPhieuTronID(int ptID);
		BindingList<ObjMeTronChiTietGiaoHang> ListMeTronChiTietGiaoHangByPhieuTronID(int ptID);

		bool SaveMeTronChiTiet(BindingList<ObjMeTronChiTiet> blstMTCT);

		ObjMeTronChiTiet SaveMeTronChiTiet(ObjMeTronChiTiet objMTCT, int phieuTronID);
		ObjMeTronChiTietGiaoHang SaveMeTronChiTietGiaoHang(ObjMeTronChiTietGiaoHang objMTCT, int phieuTronID);

		ObjNhomSilo GetNhomSiloByKey(int ctID);

		BindingList<ObjNhomSilo> ListNhomSilo();

		bool SaveNhomSilo(BindingList<ObjNhomSilo> blstCT);


		ObjMACSilo GetMACSiloByKey(int ctID);

		BindingList<ObjMACSilo> ListMACSilo();

		BindingList<ObjMACSilo> ListMACSilo_ByMACID(int macID);

		BindingList<ObjMACSilo> ListMACSilo_ByPhieuTronID(int ptID);

		BindingList<ObjMACSilo> ListMACSilo_ByHopDongID(int hdID);

		bool SaveMACSilo(BindingList<ObjMACSilo> blstCT);

		ObjMaterial GetMaterialByKey(int ctID);

		BindingList<ObjMaterial> ListMaterial();

		BindingList<ObjMaterial> ListMaterial_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maVT,
		  string tenVT,
		  bool? active);

		bool SaveMaterial(BindingList<ObjMaterial> blstCT);


		ObjPhieuTron GetPhieuTronByKey(int ctID);
		ObjPhieuGiaoHang GetPhieuGiaoHangByKey(int ctID);

		ObjPhieuTron GetPhieuTronByCode(string code);
		ObjPhieuGiaoHang GetPhieuGiaoHangByCode(string code);

		BindingList<ObjPhieuTron> ListPhieuTron();
		BindingList<ObjPhieuGiaoHang> ListPhieuGiaoHang();

		BindingList<ObjPhieuTron> ListPhieuTron_ForTronOnline();

		BindingList<ObjPhieuTron> ListPhieuTron_ByStatus(int status);

		BindingList<ObjPhieuTron> ListPhieuTron_ByIsQueued(bool isQueued);
		BindingList<ObjPhieuGiaoHang> ListPhieuGiaoHang_ByIsQueued(bool isQueued);

		BindingList<ObjPhieuTron> ListPhieuTron_ByCondition(
		  string maPhieuTron,
		  DateTime fromDate,
		  DateTime toDate,
		  int? status,
		  bool? isQueued);
        BindingList<ObjPhieuGiaoHang> ListPhieuGiaoHang_ByCondition(
          string maPhieuTron,
          DateTime fromDate,
          DateTime toDate,
          bool? isQueued);

        bool SavePhieuTron(BindingList<ObjPhieuTron> blstCT);
        bool SavePhieuGiaoHang(BindingList<ObjPhieuGiaoHang> blstCT);
		bool UpdatePhieuTron(ObjPhieuTron objPhieuTron, decimal klThuc);
		bool UpdatePhieuGiaoHang(ObjPhieuGiaoHang objPhieuTron, string klThuc);

		bool ResolveUnfinishPhieuTron();

		Decimal GetKLDTPhieuTron(Decimal klLyThuyet, Decimal klMaxXeCho);

		int CalcMeTronQty(Decimal kldt, Decimal maxKLT);

		Decimal CalcKLDTMeTron(Decimal kldt, int meTronQty);

		ObjSilo GetSiloByKey(int ctID);

		BindingList<ObjSilo> ListSilo();

		BindingList<ObjSilo> ListSilo_ByActivated(bool activated);

		BindingList<ObjSilo> ListSilo_ByActivated_ByMaNhomSilo(bool? activated, string maNhomSL);

		bool SaveSilo(BindingList<ObjSilo> blstCT);


		ObjWeigh GetWeighByKey(int ctID);

		BindingList<ObjWeigh> ListWeigh();

		bool SaveWeigh(BindingList<ObjWeigh> blstCT);

		ObjWeiSiloSaving GetWeiSiloSavingByKey(int ctID);

		BindingList<ObjWeiSiloSaving> ListWeiSiloSaving();

		bool SaveWeiSiloSaving(BindingList<ObjWeiSiloSaving> blstCT);

		ObjWeiSiloVisible GetWeiSiloVisibleByKey(int ctID);

		BindingList<ObjWeiSiloVisible> ListWeiSiloVisible();

		bool SaveWeiSiloVisible(BindingList<ObjWeiSiloVisible> blstCT);

		ObjHangMuc GetHangMucByKey(int ctID);

		BindingList<ObjHangMuc> ListHangMuc();

		BindingList<ObjHangMuc> ListHangMuc_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maTX,
		  string tenTX,
		  bool? active);

		bool SaveHangMuc(BindingList<ObjHangMuc> blstCT);

		ObjNhanVien GetNhanVienByKey(int ctID);

		BindingList<ObjNhanVien> ListNhanVien();

		BindingList<ObjNhanVien> ListNhanVien_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maTX,
		  string tenTX,
		  string phone,
		  bool? active);

		bool SaveNhanVien(BindingList<ObjNhanVien> blstCT);
		ObjTaiXe GetTaiXeByKey(int ctID);

		BindingList<ObjTaiXe> ListTaiXe();

		BindingList<ObjTaiXe> ListTaiXe_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maTX,
		  string tenTX,
		  string phone,
		  bool? active);

		bool SaveTaiXe(BindingList<ObjTaiXe> blstCT);
		ObjXe GetXeByKey(int ctID);

		BindingList<ObjXe> ListXe();

		BindingList<ObjXe> ListXe_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string bienSo,
		  bool? active);

		bool SaveXe(BindingList<ObjXe> blstCT);

		ObjTimerPara GetTimerParaByKey(int ctID);

		BindingList<ObjTimerPara> ListTimerPara();

		bool SaveTimerPara(BindingList<ObjTimerPara> blstCT);

		ObjTinhDoHutNuoc GetTinhDoHutNuocByKey(int ctID);

		BindingList<ObjTinhDoHutNuoc> ListTinhDoHutNuoc();

		bool SaveTinhDoHutNuoc(BindingList<ObjTinhDoHutNuoc> blstCT);

		ObjPhieuTron SaveTronOnline(ObjPhieuTron objPT, BindingList<ObjMeTron> blstMT);

		ObjMAC SaveMacThemBotNuoc1(int macId, Decimal themBotNuoc1);

		ObjMAC SaveMacThemBotNuoc2(int macId, Decimal themBotNuoc2);

		//==============================

		Objvw_DataMix GetDataMixByKey(int dmID);

		BindingList<Objvw_DataMix> ListDataMix();

		BindingList<Objvw_DataMix> ListDataMix_ByCondition(
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
		  );

		BindingList<Objvw_DataMix> ListDataMix_ByCondition(
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
			bool? moPhong);

		BindingList<Objvw_SumWeight> ListSumWeight_ByCondition(
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
			bool? moPhong);

		string GetNextCode(string strTblName);

		BindingList<Objvw_MaterialDetailDayWithID> ListTotalMaterial_ByCondition(int? materialID, bool? isManual);
		BindingList<Objvw_MaterialDetailDay> ListMaterialDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? materialID, bool? isManual);
		BindingList<Objvw_TranferDetailDayWithID> ListTranferDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? materialID, bool? isManual);
	}
}

using System;
using System.Collections.Generic;
using NDPSo.Data;

namespace NDPSo.ClientSetting
{
	public interface IServices
	{
		ObjSEC_Assembly GetSEC_AssemblyByKey(int userID);

		ObjSEC_Function GetSEC_FunctionByKey(int userID);

		ObjSEC_Role GetSEC_RoleByKey(int userID);

		ObjSEC_RoleFunction GetSEC_RoleFunctionByKey(int userID);

		ObjSEC_TypeInfo GetSEC_TypeInfoByKey(int userID);

		ObjSEC_User GetSEC_UserByKey(int userID);

		ObjSEC_UserRole GetSEC_UserRoleByKey(int userID);

		ObjSEC_User GetSEC_User_ByUsername_Pass(string username, string password);
		IList<ObjSEC_Assembly> ListSEC_Assembly();

		IList<ObjSEC_Function> ListSEC_Function();

		IList<ObjSEC_Function> ListSEC_Function_ByFunctionType(int funcType);

		IList<ObjSEC_Function> ListSEC_Function_ByUserID(int userID);

		IList<ObjSEC_Role> ListSEC_Role();

		IList<ObjSEC_RoleFunction> ListSEC_RoleFunction();

		IList<ObjSEC_TypeInfo> ListSEC_TypeInfo();

		IList<ObjSEC_User> ListSEC_User();
		IList<ObjSEC_User> ListSEC_User_ByActive(bool? active);

		IList<ObjSEC_UserRole> ListSEC_UserRole();

		bool SaveSEC_Assembly(IList<ObjSEC_Assembly> lstAssembly);

		bool SaveSEC_Function(IList<ObjSEC_Function> lstFunction);

		bool SaveSEC_Role(IList<ObjSEC_Role> lstRole);

		bool SaveSEC_RoleFunction(IList<ObjSEC_RoleFunction> lstRoleFunction);

		bool SaveSEC_TypeInfo(IList<ObjSEC_TypeInfo> lstTypeInfo);

		bool SaveSEC_User(IList<ObjSEC_User> lstUser);

		bool SaveSEC_UserRole(IList<ObjSEC_UserRole> lstUserRole);
		IList<ObjEventLog> ListEventLog_ByCondition(DateTime? fromDate, DateTime? toDate, int? userID, int? eventActionCodeID);

		ObjCongTruong GetCongTruongByKey(int ctID);
		
		IList<ObjCongTruong> ListCongTruong();

		IList<ObjCongTruong> ListCongTruong_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string diaChi, string phone, bool? active);

		bool SaveCongTruong(IList<ObjCongTruong> lstCT);


		ObjDuLieuTron GetDuLieuTronByKey(int ctID);

		IList<ObjDuLieuTron> ListDuLieuTron(bool includeInActivated);

		bool SaveDuLieuTron(IList<ObjDuLieuTron> lstCT);

		ObjDuLieuTron AddDuLieuTron(ObjDuLieuTron objDLT);

		ObjDuLieuTron UpdateDuLieuTron(ObjDuLieuTron objDLT);

		bool DeleteDulieuTron(int id);

		bool InsertEventLog(ObjEventLog objEventLog);
		bool InsertEventLog(int? userId, string userName, string eventActionCode, string result, string oldValueText, string newValueText);

		ObjHopDong GetHopDongByKey(int ctID);

		ObjHopDong GetHopDongByMaHD(string maHD);

		IList<ObjHopDong> ListHopDong();

		IList<ObjHopDong> ListHopDong_ByCondition(
		  string maHopDong,
		  DateTime fromDate,
		  DateTime toDate,
		  int? status,
		  int? khachHangID,
		  int? congTruongID,
		  int? macID);

		bool SaveHopDong(IList<ObjHopDong> lstCT);

		ObjHopDong SaveHopDong(ObjHopDong objHD);

		ObjHopDong SaveHopDong(ObjHopDong objHD, ObjDuLieuTron objDLT);
		ObjKhachHang GetKhachHangByKey(int ctID);

		IList<ObjKhachHang> ListKhachHang();

		IList<ObjKhachHang> ListKhachHang_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string diaChi, string phone, bool? active);

		bool SaveKhachHang(IList<ObjKhachHang> lstCT);
		ObjMAC GetMACByKey(int ctID);

		IList<ObjMAC> ListMAC();

		IList<ObjMAC> ListMAC_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maMAC,
		  string tenMAC,
		  bool? active);

		bool SaveMAC(IList<ObjMAC> lstCT);

		ObjMACSilo GetMACSiloByKey(int ctID);

		IList<ObjMACSilo> ListMACSilo();

		IList<ObjMACSilo> ListMACSilo_ByMACID(int macID);

		IList<ObjMACSilo> ListMACSilo_ByPhieuTronID(int ptID);

		IList<ObjMACSilo> ListMACSilo_ByHopDongID(int hdID);

		bool SaveMACSilo(IList<ObjMACSilo> lstCT);


		ObjMaterial GetMaterialByKey(int ctID);

		IList<ObjMaterial> ListMaterial();

		IList<ObjMaterial> ListMaterial_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maVT,
		  string tenVT,
		  bool? active);

		bool SaveMaterial(IList<ObjMaterial> lstCT);


		ObjPhieuTron GetPhieuTronByKey(int ctID);
		ObjPhieuGiaoHang GetPhieuGiaoHangByKey(int ctID);

		ObjPhieuTron GetPhieuTronByCode(string code);
		ObjPhieuGiaoHang GetPhieuGiaoHangByCode(string code);
		

		IList<ObjPhieuTron> ListPhieuTron();
		IList<ObjPhieuGiaoHang> ListPhieuGiaoHang();

		IList<ObjPhieuTron> ListPhieuTron_ForTronOnline();

		IList<ObjPhieuTron> ListPhieuTron_ByStatus(int status);

		IList<ObjPhieuTron> ListPhieuTron_ByIsQueued(bool isQueued);
        IList<ObjPhieuGiaoHang> ListPhieuGiaoHang_ByIsQueued(bool isQueued);

        IList<ObjPhieuTron> ListPhieuTron_ByCondition(
		  string maPhieuTron,
		  DateTime fromDate,
		  DateTime toDate,
		  int? status,
		  bool? isQueued);
        IList<ObjPhieuGiaoHang> ListPhieuGiaoHang_ByCondition(
          string maPhieuTron,
          DateTime fromDate,
          DateTime toDate,
          bool? isQueued);

        IList<string> ListMaPhieuTron_AutoComplete(string strInput, int? length);

		IList<ObjPhieuTron> ListPhieuTron_AutoComplete(string strInput, int? length);

		bool SavePhieuTron(IList<ObjPhieuTron> lstPT);
		bool SavePhieuGiaoHang(IList<ObjPhieuGiaoHang> lstPT);

		bool AddOrAttachPhieuTron(ObjPhieuTron objPT);

		bool UpdatePhieuTron(ObjPhieuTron objPT, decimal klThuc);
		bool UpdatePhieuGiaoHang(ObjPhieuGiaoHang objPT, string klThuc);

		bool ResolveUnfinishPhieuTron();


		ObjMeTron GetMeTronByKey(int ctID);

		IList<ObjMeTron> ListMeTron();

		IList<ObjMeTron> ListMeTronByPhieuTronID(int ptID);

		bool SaveMeTron(IList<ObjMeTron> lstCT);

		ObjMeTronChiTiet GetMeTronChiTietByKey(int ctID);

		IList<ObjMeTronChiTiet> ListMeTronChiTiet();

		IList<ObjMeTronChiTiet> ListMeTronChiTietByPhieuTronID(int ptID);
		IList<ObjMeTronChiTietGiaoHang> ListMeTronChiTietGiaoHangByPhieuTronID(int ptID);

		bool SaveMeTronChiTiet(IList<ObjMeTronChiTiet> lstCT);

		ObjMeTronChiTiet SaveMeTronChiTiet(ObjMeTronChiTiet objMTCT, int phieuTronID);
		ObjMeTronChiTietGiaoHang SaveMeTronChiTietGiaoHang(ObjMeTronChiTietGiaoHang objMTCT, int phieuTronID);

		ObjNhomSilo GetNhomSiloByKey(int ctID);

		IList<ObjNhomSilo> ListNhomSilo();

		bool SaveNhomSilo(IList<ObjNhomSilo> lstCT);

		ObjSilo GetSiloByKey(int ctID);

		IList<ObjSilo> ListSilo();

		IList<ObjSilo> ListSilo_ByActivated(bool activated);

		IList<ObjSilo> ListSilo_ByActivated_MaNhomSilo(bool? activated, string maNhomSL);

		bool SaveSilo(IList<ObjSilo> lstCT);


		ObjWeigh GetWeighByKey(int ctID);

		IList<ObjWeigh> ListWeigh();

		bool SaveWeigh(IList<ObjWeigh> lstCT);

		ObjWeiSiloSaving GetWeiSiloSavingByKey(int ctID);

		IList<ObjWeiSiloSaving> ListWeiSiloSaving();

		bool SaveWeiSiloSaving(IList<ObjWeiSiloSaving> lstCT);

		ObjWeiSiloVisible GetWeiSiloVisibleByKey(int ctID);

		IList<ObjWeiSiloVisible> ListWeiSiloVisible();

		bool SaveWeiSiloVisible(IList<ObjWeiSiloVisible> lstCT);

		ObjHangMuc GetHangMucByKey(int ctID);

		IList<ObjHangMuc> ListHangMuc();

		IList<ObjHangMuc> ListHangMuc_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maKH,
		  string tenKH,
		  bool? active);

		bool SaveHangMuc(IList<ObjHangMuc> lstCT);

		ObjNhanVien GetNhanVienByKey(int ctID);

		IList<ObjNhanVien> ListNhanVien();

		IList<ObjNhanVien> ListNhanVien_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maKH,
		  string tenKH,
		  string phone,
		  bool? active);

		bool SaveNhanVien(IList<ObjNhanVien> lstCT);
		ObjTaiXe GetTaiXeByKey(int ctID);

		IList<ObjTaiXe> ListTaiXe();

		IList<ObjTaiXe> ListTaiXe_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maKH,
		  string tenKH,
		  string phone,
		  bool? active);

		bool SaveTaiXe(IList<ObjTaiXe> lstCT);
		ObjXe GetXeByKey(int ctID);

		IList<ObjXe> ListXe();

		IList<ObjXe> ListXe_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string bienSo,
		  bool? active);

		bool SaveXe(IList<ObjXe> lstCT);

		ObjTimerPara GetTimerParaByKey(int ctID);

		IList<ObjTimerPara> ListTimerPara();

		bool SaveTimerPara(IList<ObjTimerPara> lstCT);

		ObjTinhDoHutNuoc GetTinhDoHutNuocByKey(int ctID);

		IList<ObjTinhDoHutNuoc> ListTinhDoHutNuoc();

		bool SaveTinhDoHutNuoc(IList<ObjTinhDoHutNuoc> lstCT);

		ObjPhieuTron SaveTronOnline(ObjPhieuTron objPT, List<ObjMeTron> lstMT);

		ObjMAC SaveMacThemBotNuoc1(int macId, Decimal themBotNuoc1);

		ObjMAC SaveMacThemBotNuoc2(int macId, Decimal themBotNuoc2);

		bool SaveNhanVienTronOnline(int id);

		bool SaveTaiXeTronOnline(int id);
		bool SaveTaiXeTronOnlinePhieuGiaoHang(string id);

		bool SaveXeTronOnline(int id);
		bool SaveXeTronOnlinePhieuGiaoHang(string id);

		bool SaveNiemChiTronOnline(string niemchi);
		bool SaveNiemChiTronOnlinePhieuGiaoHang(string niemchi);
		bool UpdateDoAmSiloOnlineBySiloID(int siloID, Decimal doAm);
		bool UpdateDoHutNuocSiloOnlineBySiloID(int siloID, Decimal doAm);

		//==================================
		Objvw_DataMix GetDataMixByKey(int dmID);

		IList<Objvw_DataMix> ListDataMix();

		IList<Objvw_DataMix> ListDataMix_ByCondition(DateTime? fromDate, DateTime? toDate, string maPT, string khachHang, string congTruong, string hangMuc, string taiXe, string bienSo, string mac, string nhanVien);
		
		IList<Objvw_DataMix> ListDataMix_ByCondition(DateTime? fromDate, TimeSpan? fromTime, DateTime? toDate, TimeSpan? toTime, string maPT, int? khachHang, int? congTruong, int? hangMuc, int? mac, int? bienSo, int? taiXe, int? nhanVien, bool? moPhong);
		
		IList<Objvw_SumWeight> ListSumWeight_ByCondition(DateTime? fromDate, DateTime? toDate, string maPT, int? khachHang, int? congTruong, int? hangMuc, int? mac, int? bienSo, int? taiXe, int? nhanVien, bool? moPhong);

		ObjAggregationResult GetSumForIsQueuedAndTimeRange(DateTime? fromDate, DateTime? toDate, bool? mophong);
		string GetNextCode(string strTblName);
		IList<Objvw_MaterialDetailDayWithID> ListTotalMaterial_ByCondition(int? materialID, bool? isManual);
		IList<Objvw_MaterialDetailDayWithID> ListMaterialDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? materialID, bool? isManual);
		IList<Objvw_TranferDetailDayWithID> ListTranferDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? xeID, bool? isQueued);
		IList<Objvw_TranferDetailDayWithID> ListTotalTranfer_ByCondition(int? xeID, bool? isManual);
		IList<Objvw_DriverDetailDayWithID> ListTotalDriver_ByCondition(int? taixeID, bool? isManual);
		IList<Objvw_DriverDetailDayWithID> ListDriverDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? taixeID, bool? isManual);

	}
}

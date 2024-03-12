using System;
using System.Collections.Generic;
using NDPSo.Data;
using NDPSo.ServiceLibrary;

namespace NDPSo.ClientSetting
{
	public class LocalServicesFactory : IServices
	{
		public LocalServicesFactory()
		{
			this._services = new NDPTramTronServices();
		}


		public ObjSEC_Assembly GetSEC_AssemblyByKey(int assID) => this._services.GetSEC_AssemblyByKey(assID);

		public IList<ObjSEC_Assembly> ListSEC_Assembly() => this._services.ListSEC_Assembly();

		public bool SaveSEC_Assembly(IList<ObjSEC_Assembly> lstAssembly) => this._services.SaveSEC_Assembly(lstAssembly);

		public ObjSEC_Function GetSEC_FunctionByKey(int userID) => this._services.GetSEC_FunctionByKey(userID);

		public IList<ObjSEC_Function> ListSEC_Function() => this._services.ListSEC_Function();

		public IList<ObjSEC_Function> ListSEC_Function_ByFunctionType(int funcType) => this._services.ListSEC_Function_ByFunctionType(funcType);

		public IList<ObjSEC_Function> ListSEC_Function_ByUserID(int userID) => this._services.ListSEC_Function_ByUserID(userID);

		public bool SaveSEC_Function(IList<ObjSEC_Function> lstFunction) => this._services.SaveSEC_Function(lstFunction);

		public ObjSEC_Role GetSEC_RoleByKey(int userID) => this._services.GetSEC_RoleByKey(userID);

		public IList<ObjSEC_Role> ListSEC_Role() => this._services.ListSEC_Role();

		public bool SaveSEC_Role(IList<ObjSEC_Role> lstRole) => this._services.SaveSEC_Role(lstRole);

		public ObjSEC_RoleFunction GetSEC_RoleFunctionByKey(int userID) => this._services.GetSEC_RoleFunctionByKey(userID);

		public IList<ObjSEC_RoleFunction> ListSEC_RoleFunction() => this._services.ListSEC_RoleFunction();

		public bool SaveSEC_RoleFunction(IList<ObjSEC_RoleFunction> lstRoleFunction) => this._services.SaveSEC_RoleFunction(lstRoleFunction);

		public ObjSEC_TypeInfo GetSEC_TypeInfoByKey(int userID) => this._services.GetSEC_TypeInfoByKey(userID);

		public IList<ObjSEC_TypeInfo> ListSEC_TypeInfo() => this._services.ListSEC_TypeInfo();

		public bool SaveSEC_TypeInfo(IList<ObjSEC_TypeInfo> lstTypeInfo) => this._services.SaveSEC_TypeInfo(lstTypeInfo);

		public ObjSEC_User GetSEC_UserByKey(int userID) => this._services.GetSEC_UserByKey(userID);

		public IList<ObjSEC_User> ListSEC_User() => this._services.ListSEC_User();
		public IList<ObjSEC_User> ListSEC_User_ByActive(bool? active) => this._services.ListSEC_User_ByActive(active);

		public ObjSEC_User GetSEC_User_ByUsername_Pass(string username, string password) => this._services.GetSEC_User_ByUsername_Pass(username, password);

		public bool SaveSEC_User(IList<ObjSEC_User> lstUser) => this._services.SaveSEC_User(lstUser);

		public ObjSEC_UserRole GetSEC_UserRoleByKey(int userID) => this._services.GetSEC_UserRoleByKey(userID);

		public IList<ObjSEC_UserRole> ListSEC_UserRole() => this._services.ListSEC_UserRole();

		public bool SaveSEC_UserRole(IList<ObjSEC_UserRole> lstUserRole) => this._services.SaveSEC_UserRole(lstUserRole);

		public ObjCongTruong GetCongTruongByKey(int ctID)
		{
			return this._services.GetCongTruongByKey(ctID);
		}

		public IList<ObjCongTruong> ListCongTruong()
		{
			return this._services.ListCongTruong();
		}

		public IList<ObjCongTruong> ListCongTruong_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string diaChi, string phone, bool? active)
		{
			return this._services.ListCongTruong_ByCondition(fromDate, toDate, maKH, tenKH, diaChi, phone, active);
		}

		public bool SaveCongTruong(IList<ObjCongTruong> lstCT)
		{
			return this._services.SaveCongTruong(lstCT);
		}


		public ObjDuLieuTron GetDuLieuTronByKey(int ctID) => this._services.GetDuLieuTronByKey(ctID);

		public IList<ObjDuLieuTron> ListDuLieuTron(bool includeInActivated) => this._services.ListDuLieuTron(includeInActivated);

		public bool SaveDuLieuTron(IList<ObjDuLieuTron> lstCT) => this._services.SaveDuLieuTron(lstCT);

		public ObjDuLieuTron AddDuLieuTron(ObjDuLieuTron objDLT) => this._services.AddDuLieuTron(objDLT);

		public ObjDuLieuTron UpdateDuLieuTron(ObjDuLieuTron objDLT) => this._services.UpdateDuLieuTron(objDLT);

		public bool DeleteDulieuTron(int id) => this._services.DeleteDulieuTron(id);



		public bool InsertEventLog(ObjEventLog objEventLog)
		{
			return this._services.InsertEventLog(objEventLog);
		}

		public bool InsertEventLog(int? userId, string userName, string eventActionCode, string result, string oldValueText, string newValueText)
		{
			return this._services.InsertEventLog(userId, userName, eventActionCode, result, oldValueText, newValueText);
		}

		public IList<ObjEventLog> ListEventLog_ByCondition( DateTime? fromDate, DateTime? toDate, int? userID, int? eventActionCodeID)
		{
			return this._services.ListEventLog_ByCondition(fromDate, toDate, userID, eventActionCodeID);
		}
		public ObjHopDong GetHopDongByKey(int hdID) => this._services.GetHopDongByKey(hdID);

		public ObjHopDong GetHopDongByMaHD(string maHD) => this._services.GetHopDongByMaHD(maHD);

		public IList<ObjHopDong> ListHopDong() => this._services.ListHopDong();

		public IList<ObjHopDong> ListHopDong_ByCondition(
		  string maHopDong,
		  DateTime fromDate,
		  DateTime toDate,
		  int? status,
		  int? khachHangID,
		  int? congTruongID,
		  int? macID)
		{
			return this._services.ListHopDong_ByCondition(maHopDong, fromDate, toDate, status, khachHangID, congTruongID, macID);
		}

		public bool SaveHopDong(IList<ObjHopDong> lstHD) => this._services.SaveHopDong(lstHD);

		public ObjHopDong SaveHopDong(ObjHopDong objHD) => this._services.SaveHopDong(objHD);

		public ObjHopDong SaveHopDong(ObjHopDong objHD, ObjDuLieuTron objDLT) => this._services.SaveHopDong(objHD, objDLT);

		public ObjKhachHang GetKhachHangByKey(int khID)
		{
			return this._services.GetKhachHangByKey(khID);
		}

		public IList<ObjKhachHang> ListKhachHang()
		{
			return this._services.ListKhachHang();
		}

		public IList<ObjKhachHang> ListKhachHang_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string diaChi, string phone, bool? active)
		{
			return this._services.ListKhachHang_ByCondition(fromDate, toDate, maKH, tenKH, diaChi, phone, active);
		}

		public bool SaveKhachHang(IList<ObjKhachHang> lstKH)
		{
			return this._services.SaveKhachHang(lstKH);
		}
		public ObjMAC GetMACByKey(int macID) => this._services.GetMACByKey(macID);

		public IList<ObjMAC> ListMAC() => this._services.ListMAC();

		public IList<ObjMAC> ListMAC_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maMAC,
		  string tenMAC,
		  bool? active)
		{
			return this._services.ListMAC_ByCondition(fromDate, toDate, maMAC, tenMAC, active);
		}

		public bool SaveMAC(IList<ObjMAC> lstMAC) => this._services.SaveMAC(lstMAC);

		public ObjMACSilo GetMACSiloByKey(int msID) => this._services.GetMACSiloByKey(msID);

		public IList<ObjMACSilo> ListMACSilo() => this._services.ListMACSilo();

		public IList<ObjMACSilo> ListMACSilo_ByMACID(int macID) => this._services.ListMACSilo_ByMACID(macID);

		public IList<ObjMACSilo> ListMACSilo_ByPhieuTronID(int ptID) => this._services.ListMACSilo_ByPhieuTronID(ptID);

		public IList<ObjMACSilo> ListMACSilo_ByHopDongID(int hdID) => this._services.ListMACSilo_ByHopDongID(hdID);

		public bool SaveMACSilo(IList<ObjMACSilo> lstMS) => this._services.SaveMACSilo(lstMS);


		public ObjMaterial GetMaterialByKey(int ctID) => this._services.GetMaterialByKey(ctID);

		public IList<ObjMaterial> ListMaterial() => this._services.ListMaterial();

		public IList<ObjMaterial> ListMaterial_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maVT,
		  string tenVT,
		  bool? active)
		{
			return this._services.ListMaterial_ByCondition(fromDate, toDate, maVT, tenVT, active);
		}

		public bool SaveMaterial(IList<ObjMaterial> lstCT) => this._services.SaveMaterial(lstCT);


		public ObjMeTron GetMeTronByKey(int mtID) => this._services.GetMeTronByKey(mtID);

		public IList<ObjMeTron> ListMeTron() => this._services.ListMeTron();

		public IList<ObjMeTron> ListMeTronByPhieuTronID(int ptID) => this._services.ListMeTronByPhieuTronID(ptID);

		public bool SaveMeTron(IList<ObjMeTron> lstMT) => this._services.SaveMeTron(lstMT);

		public ObjMeTronChiTiet GetMeTronChiTietByKey(int mtctID) => this._services.GetMeTronChiTietByKey(mtctID);

		public IList<ObjMeTronChiTiet> ListMeTronChiTiet() => this._services.ListMeTronChiTiet();

		public IList<ObjMeTronChiTiet> ListMeTronChiTietByPhieuTronID(int ptID) => this._services.ListMeTronChiTietByPhieuTronID(ptID);

		public bool SaveMeTronChiTiet(IList<ObjMeTronChiTiet> lstMTCT) => this._services.SaveMeTronChiTiet(lstMTCT);

		public ObjMeTronChiTiet SaveMeTronChiTiet(ObjMeTronChiTiet objMTCT, int phieuTronID) => this._services.SaveMeTronChiTiet(objMTCT, phieuTronID);

		public ObjNhomSilo GetNhomSiloByKey(int nsID) => this._services.GetNhomSiloByKey(nsID);

		public IList<ObjNhomSilo> ListNhomSilo() => this._services.ListNhomSilo();

		public bool SaveNhomSilo(IList<ObjNhomSilo> lstNS) => this._services.SaveNhomSilo(lstNS);


		public ObjPhieuTron GetPhieuTronByKey(int ptID) => this._services.GetPhieuTronByKey(ptID);

		public ObjPhieuTron GetPhieuTronByCode(string code) => this._services.GetPhieuTronByCode(code);

		

		public IList<ObjPhieuTron> ListPhieuTron() => this._services.ListPhieuTron();

		public IList<ObjPhieuTron> ListPhieuTron_ForTronOnline() => this._services.ListPhieuTron_ForTronOnline();

		public IList<ObjPhieuTron> ListPhieuTron_ByStatus(int status) => this._services.ListPhieuTron_ByStatus(status);

		public IList<ObjPhieuTron> ListPhieuTron_ByIsQueued(bool isQueued) => this._services.ListPhieuTron_ByIsQueued(isQueued);

		public IList<ObjPhieuTron> ListPhieuTron_ByCondition(
		  string maPhieuTron,
		  DateTime fromDate,
		  DateTime toDate,
		  int? status,
		  bool? isQueued)
		{
			return this._services.ListPhieuTron_ByCondition(maPhieuTron, fromDate, toDate, status, isQueued);
		}

		public IList<string> ListMaPhieuTron_AutoComplete(string strInput, int? length) => this._services.ListMaPhieuTron_AutoComplete(strInput, length);

		public IList<ObjPhieuTron> ListPhieuTron_AutoComplete(string strInput, int? length) => this._services.ListPhieuTron_AutoComplete(strInput, length);

		public bool SavePhieuTron(IList<ObjPhieuTron> lstPT) => this._services.SavePhieuTron(lstPT);

		public bool AddOrAttachPhieuTron(ObjPhieuTron objPT) => this._services.AddOrAttachPhieuTron(objPT);

		public bool UpdatePhieuTron(ObjPhieuTron objPT, decimal klThuc) => this._services.UpdatePhieuTron(objPT, klThuc);

		public bool ResolveUnfinishPhieuTron() => this._services.ResolveUnfinishPhieuTron();

		public ObjSilo GetSiloByKey(int siloID) => this._services.GetSiloByKey(siloID);

		public IList<ObjSilo> ListSilo() => this._services.ListSilo();

		public IList<ObjSilo> ListSilo_ByActivated(bool activated) => this._services.ListSilo_ByActivated(activated);

		public IList<ObjSilo> ListSilo_ByActivated_MaNhomSilo(bool? activated, string maNhomSL) => this._services.ListSilo_ByActivated_MaNhomSilo(activated, maNhomSL);

		public bool SaveSilo(IList<ObjSilo> lstSilo) => this._services.SaveSilo(lstSilo);


		public ObjWeigh GetWeighByKey(int weID) => this._services.GetWeighByKey(weID);

		public IList<ObjWeigh> ListWeigh() => this._services.ListWeigh();

		public bool SaveWeigh(IList<ObjWeigh> lstWeigh) => this._services.SaveWeigh(lstWeigh);

		public ObjWeiSiloSaving GetWeiSiloSavingByKey(int ctID) => this._services.GetWeiSiloSavingByKey(ctID);

		public IList<ObjWeiSiloSaving> ListWeiSiloSaving() => this._services.ListWeiSiloSaving();

		public bool SaveWeiSiloSaving(IList<ObjWeiSiloSaving> lstCT) => this._services.SaveWeiSiloSaving(lstCT);

		public ObjWeiSiloVisible GetWeiSiloVisibleByKey(int ctID) => this._services.GetWeiSiloVisibleByKey(ctID);

		public IList<ObjWeiSiloVisible> ListWeiSiloVisible() => this._services.ListWeiSiloVisible();

		public bool SaveWeiSiloVisible(IList<ObjWeiSiloVisible> lstCT) => this._services.SaveWeiSiloVisible(lstCT);


		public ObjHangMuc GetHangMucByKey(int txID) => this._services.GetHangMucByKey(txID);

		public IList<ObjHangMuc> ListHangMuc() => this._services.ListHangMuc();

		public IList<ObjHangMuc> ListHangMuc_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maKH,
		  string tenKH,
		  bool? active)
		{
			return this._services.ListHangMuc_ByCondition(fromDate, toDate, maKH, tenKH, active);
		}

		public bool SaveHangMuc(IList<ObjHangMuc> lstTX) => this._services.SaveHangMuc(lstTX);

		public ObjNhanVien GetNhanVienByKey(int txID) => this._services.GetNhanVienByKey(txID);

		public IList<ObjNhanVien> ListNhanVien() => this._services.ListNhanVien();

		public IList<ObjNhanVien> ListNhanVien_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maKH,
		  string tenKH,
		  string phone,
		  bool? active)
		{
			return this._services.ListNhanVien_ByCondition(fromDate, toDate, maKH, tenKH, phone, active);
		}

		public bool SaveNhanVien(IList<ObjNhanVien> lstTX) => this._services.SaveNhanVien(lstTX);

		public ObjTaiXe GetTaiXeByKey(int txID) => this._services.GetTaiXeByKey(txID);

		public IList<ObjTaiXe> ListTaiXe() => this._services.ListTaiXe();

		public IList<ObjTaiXe> ListTaiXe_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string maKH,
		  string tenKH,
		  string phone,
		  bool? active)
		{
			return this._services.ListTaiXe_ByCondition(fromDate, toDate, maKH, tenKH, phone, active);
		}

		public bool SaveTaiXe(IList<ObjTaiXe> lstTX) => this._services.SaveTaiXe(lstTX);
		public ObjXe GetXeByKey(int xeID) => this._services.GetXeByKey(xeID);

		public IList<ObjXe> ListXe() => this._services.ListXe();

		public IList<ObjXe> ListXe_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  string bienSo,
		  bool? active)
		{
			return this._services.ListXe_ByCondition(fromDate, toDate, bienSo, active);
		}

		public bool SaveXe(IList<ObjXe> lstXe) => this._services.SaveXe(lstXe);


		public ObjTimerPara GetTimerParaByKey(int tiID) => this._services.GetTimerParaByKey(tiID);

		public IList<ObjTimerPara> ListTimerPara() => this._services.ListTimerPara();

		public bool SaveTimerPara(IList<ObjTimerPara> lstTimer) => this._services.SaveTimerPara(lstTimer);

		public ObjTinhDoHutNuoc GetTinhDoHutNuocByKey(int ctID) => this._services.GetTinhDoHutNuocByKey(ctID);

		public IList<ObjTinhDoHutNuoc> ListTinhDoHutNuoc() => this._services.ListTinhDoHutNuoc();

		public bool SaveTinhDoHutNuoc(IList<ObjTinhDoHutNuoc> lstCT) => this._services.SaveTinhDoHutNuoc(lstCT);

		public ObjPhieuTron SaveTronOnline(ObjPhieuTron objPT, List<ObjMeTron> lstMT) => this._services.SaveTronOnline(objPT, lstMT);

		public ObjMAC SaveMacThemBotNuoc1(int macId, Decimal themBotNuoc1) => this._services.SaveMacThemBotNuoc1(macId, themBotNuoc1);

		public ObjMAC SaveMacThemBotNuoc2(int macId, Decimal themBotNuoc2) => this._services.SaveMacThemBotNuoc2(macId, themBotNuoc2);

		public bool SaveNhanVienTronOnline(int id) => this._services.SaveNhanVienTronOnline(id);

		public bool SaveTaiXeTronOnline(int id) => this._services.SaveTaiXeTronOnline(id);

		public bool SaveXeTronOnline(int id) => this._services.SaveXeTronOnline(id);
		public bool SaveNiemChiTronOnline(string niemchi) => this._services.SaveNiemChiTronOnline(niemchi);
		public bool UpdateDoAmSiloOnlineBySiloID(int siloID, Decimal doAm) => this._services.UpdateDoAmSiloOnlineBySiloID(siloID, doAm);
		public bool UpdateDoHutNuocSiloOnlineBySiloID(int siloID, Decimal doAm) => this._services.UpdateHutNuocSiloOnlineBySiloID(siloID, doAm);
		//========================

		public Objvw_DataMix GetDataMixByKey(int dmID)
		{
			return this._services.GetDataMixByKey(dmID);
		}

		public IList<Objvw_DataMix> ListDataMix()
		{
			return this._services.ListDataMix();
		}

		public IList<Objvw_DataMix> ListDataMix_ByCondition(DateTime? fromDate, DateTime? toDate, string maPT, string khachHang, string congTruong, string hangMuc, string taiXe, string bienSo, string mac, string nhanVien)
		{
			return this._services.ListDataMix_ByCondition(fromDate, toDate, maPT, khachHang, congTruong, hangMuc, taiXe, bienSo, mac, nhanVien);
		}
		public IList<Objvw_DataMix> ListDataMix_ByCondition(
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
			return this._services.ListDataMix_ByCondition(fromDate, fromTime, toDate, toTime, maPhieuTron, khachHang, congTruong, hangMuc, mac, bienSo, taiXe, nhanVien, moPhong);
		}
		public IList<Objvw_SumWeight> ListSumWeight_ByCondition(
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
			return this._services.ListSumWeight_ByCondition(fromDate, toDate, maPhieuTron, khachHang, congTruong, hangMuc, mac, bienSo, taiXe, nhanVien, moPhong);
		}
		public ObjAggregationResult GetSumForIsQueuedAndTimeRange(
			DateTime? fromDate,
			DateTime? toDate,
			bool? mophong)
        {
			return this._services.GetSumForIsQueuedAndTimeRange(fromDate, toDate, mophong);

		}
		public string GetNextCode(string strTblName)
		{
			return this._services.GetNextCode(strTblName);
		}

		public IList<Objvw_TotalMaterial> ListTotalMaterial_ByCondition(int? materialID, bool? isManual)
		{
			return this._services.ListTotalMaterial_ByCondition(materialID, isManual);
		}
		public IList<Objvw_MaterialDetailDay> ListMaterialDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? materialID, bool? isManual)
		{
			return this._services.ListMaterialDetailDay_ByCondition(fromDate, toDate, materialID, isManual);
		}

		public IList<Objvw_TranferDetailDay> ListTranferDetailDay_ByCondition(
		  DateTime? fromDate,
		  DateTime? toDate,
		  int? xeID,
		  bool? isQueued)
		{
			return this._services.ListTranferDetailDay_ByCondition(fromDate, toDate, xeID, isQueued);
		}
		public IList<Objvw_TotalTranfer> ListTotalTranfer_ByCondition(
		  int? xeID,
		  bool? isManual)
		{
			return this._services.ListTotalTranfer_ByCondition(xeID, isManual);
		}
		public IList<Objvw_TotalDriver> ListTotalDriver_ByCondition(
		  int? taixeID,
		  bool? isManual)
		{
			return this._services.ListTotalDriver_ByCondition(taixeID, isManual);
		}
		private NDPTramTronServices _services;
	}
}

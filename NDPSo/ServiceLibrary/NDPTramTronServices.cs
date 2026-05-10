using NDPSo.BusinessObject;
using NDPSo.Core;
using NDPSo.DAL;
using NDPSo.Data;
using NDPSo.EntityModel;
using NDPSo.Utils;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ServiceModel;

namespace NDPSo.ServiceLibrary
{
    public class NDPTramTronServices : RepositoryService<DEPTramTronEntities>, INDPTramTronServices
    {
        public NDPTramTronServices()
        {
            this.Initialize(new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
            this.RegisterRepository();
        }

        private void RegisterRepository()
        {
            IoC.Current.Container.RegisterType<IDbContextManager, NDPTramTronServices>();
            
            IoC.Current.Container.RegisterType<ICongTruongRepository, CongTruongRepository>();
            IoC.Current.Container.RegisterType<IDuLieuTronRepository, DuLieuTronRepository>();
            IoC.Current.Container.RegisterType<IHopDongRepository, HopDongRepository>();
            IoC.Current.Container.RegisterType<IKhachHangRepository, KhachHangRepository>();
            IoC.Current.Container.RegisterType<IMACRepository, MACRepository>();
            IoC.Current.Container.RegisterType<IMACSiloRepository, MACSiloRepository>();
            IoC.Current.Container.RegisterType<IMaterialRepository, MaterialRepository>();
            IoC.Current.Container.RegisterType<IMeTronChiTietRepository, MeTronChiTietRepository>();
            IoC.Current.Container.RegisterType<IMeTronChiTietGiaoHangRepository, MeTronChiTietGiaoHangRepository>();
            IoC.Current.Container.RegisterType<IMeTronRepository, MeTronRepository>();
            IoC.Current.Container.RegisterType<INhomSiloRepository, NhomSiloRepository>();
            IoC.Current.Container.RegisterType<IPCInputRepository, PCInputRepository>();
            IoC.Current.Container.RegisterType<IPhieuTronRepository, PhieuTronRepository>();
            IoC.Current.Container.RegisterType<IPhieuGiaoHangRepository, PhieuGiaoHangRepository>();
            IoC.Current.Container.RegisterType<ISEC_AssemblyRepository, SEC_AssemblyRepository>();
            IoC.Current.Container.RegisterType<ISEC_FunctionRepository, SEC_FunctionRepository>();
            IoC.Current.Container.RegisterType<ISEC_RoleFunctionRepository, SEC_RoleFunctionRepository>();
            IoC.Current.Container.RegisterType<ISEC_RoleRepository, SEC_RoleRepository>();
            IoC.Current.Container.RegisterType<ISEC_TypeInfoRepository, SEC_TypeInfoRepository>();
            IoC.Current.Container.RegisterType<ISEC_UserRepository, SEC_UserRepository>();
            IoC.Current.Container.RegisterType<ISEC_UserRoleRepository, SEC_UserRoleRepository>();
            IoC.Current.Container.RegisterType<ISiloRepository, SiloRepository>();
            IoC.Current.Container.RegisterType<ISysCodeGenRepository, SysCodeGenRepository>();
            IoC.Current.Container.RegisterType<ITaiXeRepository, TaiXeRepository>();
            IoC.Current.Container.RegisterType<ITimerParaRepository, TimerParaRepository>();
            IoC.Current.Container.RegisterType<ITinhDoHutNuocChiTietRepository, TinhDoHutNuocChiTietRepository>();
            IoC.Current.Container.RegisterType<ITinhDoHutNuocRepository, TinhDoHutNuocRepository>();
            IoC.Current.Container.RegisterType<IViewDataMixRepository, ViewDataMixRepository>();
            IoC.Current.Container.RegisterType<IViewSumWeightRepository, ViewSumWeightRepository>();
            IoC.Current.Container.RegisterType<IWeighRepository, WeighRepository>();
            IoC.Current.Container.RegisterType<IWeiSiloSavingRepository, WeiSiloSavingRepository>();
            IoC.Current.Container.RegisterType<IWeiSiloVisibleRepository, WeiSiloVisibleRepository>();
            IoC.Current.Container.RegisterType<IXeRepository, XeRepository>();
            IoC.Current.Container.RegisterType<INhanVienRepository, NhanVienRepository>();
            IoC.Current.Container.RegisterType<IHangMucRepository, HangMucRepository>();
            IoC.Current.Container.RegisterType<Ivw_TotalMaterialRepository, vw_TotalMaterialRepository>();
            IoC.Current.Container.RegisterType<Ivw_MaterialDetailDayRepository, vw_MaterialDetailDayRepository>();
            IoC.Current.Container.RegisterType<Ivw_TranferDetailDayRepository, vw_TranferDetailDayRepository>();
            IoC.Current.Container.RegisterType<Ivw_TotalTranferRepository, vw_TotalTranferRepository>();
            IoC.Current.Container.RegisterType<Ivw_TotalDriverRepository, vw_TotalDriverRepository>();
            IoC.Current.Container.RegisterType<Ivw_DriverDetailDayRepository, vw_DriverDetailDayRepository>();
            IoC.Current.Container.RegisterType<ITonKhoRepository, TonKhoRepository>();
            IoC.Current.Container.RegisterType<INhapKhoRepository, NhapKhoRepository>();
            IoC.Current.Container.RegisterType<IXuatKhoRepository, XuatKhoRepository>();


        }


        public ObjSEC_Assembly GetSEC_AssemblyByKey(int assID)
        {
            try
            {
                return new AdministrationBO().GetSEC_AssemblyByKey(assID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjSEC_Assembly> ListSEC_Assembly() => new AdministrationBO().ListSEC_Assembly();

        public bool SaveSEC_Assembly(IList<ObjSEC_Assembly> lstCT) => new AdministrationBO().SaveSEC_Assembly(lstCT);

        public ObjSEC_Function GetSEC_FunctionByKey(int fnID)
        {
            try
            {
                return new AdministrationBO().GetSEC_FunctionByKey(fnID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjSEC_Function> ListSEC_Function() => new AdministrationBO().ListSEC_Function();

        public IList<ObjSEC_Function> ListSEC_Function_ByFunctionType(int funcType) => new AdministrationBO().ListSEC_Function_ByFunctionType(funcType);

        public IList<ObjSEC_Function> ListSEC_Function_ByUserID(int userID) => new AdministrationBO().ListSEC_Function_ByUserID(userID);

        public bool SaveSEC_Function(IList<ObjSEC_Function> lstCT) => new AdministrationBO().SaveSEC_Function(lstCT);

        public ObjSEC_Role GetSEC_RoleByKey(int roleID)
        {
            try
            {
                return new AdministrationBO().GetSEC_RoleByKey(roleID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjSEC_Role> ListSEC_Role() => new AdministrationBO().ListSEC_Role();

        public bool SaveSEC_Role(IList<ObjSEC_Role> lstCT) => new AdministrationBO().SaveSEC_Role(lstCT);

        public ObjSEC_RoleFunction GetSEC_RoleFunctionByKey(int rfID)
        {
            try
            {
                return new AdministrationBO().GetSEC_RoleFunctionByKey(rfID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjSEC_RoleFunction> ListSEC_RoleFunction() => new AdministrationBO().ListSEC_RoleFunction();

        public bool SaveSEC_RoleFunction(IList<ObjSEC_RoleFunction> lstCT) => new AdministrationBO().SaveSEC_RoleFunction(lstCT);

        public ObjSEC_TypeInfo GetSEC_TypeInfoByKey(int tiID)
        {
            try
            {
                return new AdministrationBO().GetSEC_TypeInfoByKey(tiID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjSEC_TypeInfo> ListSEC_TypeInfo() => new AdministrationBO().ListSEC_TypeInfo();

        public bool SaveSEC_TypeInfo(IList<ObjSEC_TypeInfo> lstCT) => new AdministrationBO().SaveSEC_TypeInfo(lstCT);

        public ObjSEC_User GetSEC_UserByKey(int userID)
        {
            try
            {
                return new AdministrationBO().GetSEC_UserByKey(userID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjSEC_User> ListSEC_User() => new AdministrationBO().ListSEC_User();
        public IList<ObjSEC_User> ListSEC_User_ByActive(bool? active) => new AdministrationBO().ListSEC_User_ByActive(active);
        public ObjSEC_User GetSEC_User_ByUsername_Pass(string username, string password) => new AdministrationBO().GetSEC_User_ByUsername_Pass(username, password);

        public bool SaveSEC_User(IList<ObjSEC_User> lstUser) => new AdministrationBO().SaveSEC_User(lstUser);

        public ObjSEC_UserRole GetSEC_UserRoleByKey(int urID)
        {
            try
            {
                return new AdministrationBO().GetSEC_UserRoleByKey(urID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjSEC_UserRole> ListSEC_UserRole() => new AdministrationBO().ListSEC_UserRole();

        public bool SaveSEC_UserRole(IList<ObjSEC_UserRole> lstCT) => new AdministrationBO().SaveSEC_UserRole(lstCT);

        public ObjCongTruong GetCongTruongByKey(int ctID)
        {
            try
            {
                return new NDPTramTronBO().GetCongTruongByKey(ctID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjCongTruong> ListCongTruong() => new NDPTramTronBO().ListCongTruong();

        public IList<ObjCongTruong> ListCongTruong_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string diaChi,
          string phone,
          bool? active)
        {
            return new NDPTramTronBO().ListCongTruong_ByCondition(fromDate, toDate, maKH, tenKH, diaChi, phone, active);
        }

        public bool SaveCongTruong(IList<ObjCongTruong> lstCT) => new NDPTramTronBO().SaveCongTruong(lstCT);


        public ObjDuLieuTron GetDuLieuTronByKey(int ctID)
        {
            try
            {
                return new NDPTramTronBO().GetDuLieuTronByKey(ctID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjDuLieuTron> ListDuLieuTron(bool includeInActivated) => new NDPTramTronBO().ListDuLieuTron(includeInActivated);

        public bool SaveDuLieuTron(IList<ObjDuLieuTron> lstCT) => new NDPTramTronBO().SaveDuLieuTron(lstCT);

        public ObjDuLieuTron AddDuLieuTron(ObjDuLieuTron objDLT) => new NDPTramTronBO().AddDuLieuTron(objDLT);

        public ObjDuLieuTron UpdateDuLieuTron(ObjDuLieuTron objDLT) => new NDPTramTronBO().UpdateDuLieuTron(objDLT);

        public bool DeleteDulieuTron(int id) => new NDPTramTronBO().DeleteDulieuTron(id);
        public bool InsertEventLog(ObjEventLog objEventLog) => new NDPTramTronBO().InsertEventLog(objEventLog);

        public bool InsertEventLog(
          int? userId,
          string userName,
          string eventActionCode,
          string result,
          string oldValueText,
          string newValueText)
        {
            return new NDPTramTronBO().InsertEventLog(userId, userName, eventActionCode, result, oldValueText, newValueText);
        }

        public IList<ObjEventLog> ListEventLog_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          int? userID,
          int? eventActionCodeID)
        {
            return new NDPTramTronBO().ListEventLog_ByCondition(fromDate, toDate, userID, eventActionCodeID);
        }


        public ObjHopDong GetHopDongByKey(int hdID)
        {
            try
            {
                return new NDPTramTronBO().GetHopDongByKey(hdID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public ObjHopDong GetHopDongByMaHD(string maHD)
        {
            try
            {
                return new NDPTramTronBO().GetHopDongByMaHD(maHD);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjHopDong> ListHopDong() => new NDPTramTronBO().ListHopDong();

        public IList<ObjHopDong> ListHopDong_ByCondition(
          string maHopDong,
          DateTime fromDate,
          DateTime toDate,
          int? status,
          int? khachHangID,
          int? congTruongID,
          int? macID)
        {
            return new NDPTramTronBO().ListHopDong_ByCondition(maHopDong, fromDate, toDate, status, khachHangID, congTruongID, macID);
        }

        public bool SaveHopDong(IList<ObjHopDong> lstCT) => new NDPTramTronBO().SaveHopDong(lstCT);

        public ObjHopDong SaveHopDong(ObjHopDong objHD) => new NDPTramTronBO().SaveHopDong(objHD);

        public ObjHopDong SaveHopDong(ObjHopDong objHD, ObjDuLieuTron objDLT) => new NDPTramTronBO().SaveHopDong(objHD, objDLT);

        public ObjKhachHang GetKhachHangByKey(int khID)
        {
            try
            {
                return new NDPTramTronBO().GetKhachHangByKey(khID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjKhachHang> ListKhachHang() => new NDPTramTronBO().ListKhachHang();

        public IList<ObjKhachHang> ListKhachHang_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string diaChi,
          string phone,
          bool? active)
        {
            return new NDPTramTronBO().ListKhachHang_ByCondition(fromDate, toDate, maKH, tenKH, diaChi, phone, active);
        }

        public bool SaveKhachHang(IList<ObjKhachHang> lstCT) => new NDPTramTronBO().SaveKhachHang(lstCT);
        

        public ObjMAC GetMACByKey(int macID)
        {
            try
            {
                return new NDPTramTronBO().GetMACByKey(macID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjMAC> ListMAC() => new NDPTramTronBO().ListMAC();

        public IList<ObjMAC> ListMAC_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maMAC,
          string tenMAC,
          bool? active)
        {
            return new NDPTramTronBO().ListMAC_ByCondition(fromDate, toDate, maMAC, tenMAC, active);
        }

        public bool SaveMAC(IList<ObjMAC> lstCT) => new NDPTramTronBO().SaveMAC(lstCT);

        public ObjMACSilo GetMACSiloByKey(int msID)
        {
            try
            {
                return new NDPTramTronBO().GetMACSiloByKey(msID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjMACSilo> ListMACSilo() => new NDPTramTronBO().ListMACSilo();

        public IList<ObjMACSilo> ListMACSilo_ByMACID(int macID) => new NDPTramTronBO().ListMACSilo_ByMACID(macID);

        public IList<ObjMACSilo> ListMACSilo_ByPhieuTronID(int ptID) => new NDPTramTronBO().ListMACSilo_ByPhieuTronID(ptID);

        public IList<ObjMACSilo> ListMACSilo_ByHopDongID(int hdID) => new NDPTramTronBO().ListMACSilo_ByHopDongID(hdID);
        public bool SaveMACSilo(IList<ObjMACSilo> lstCT) => new NDPTramTronBO().SaveMACSilo(lstCT);


        public ObjMaterial GetMaterialByKey(int ctID)
        {
            try
            {
                return new NDPTramTronBO().GetMaterialByKey(ctID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjMaterial> ListMaterial() => new NDPTramTronBO().ListMaterial();

        public IList<ObjMaterial> ListMaterial_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maVT,
          string tenVT,
          bool? active)
        {
            return new NDPTramTronBO().ListMaterial_ByCondition(fromDate, toDate, maVT, tenVT, active);
        }

        public bool SaveMaterial(IList<ObjMaterial> lstCT) => new NDPTramTronBO().SaveMaterial(lstCT);


        public ObjMeTron GetMeTronByKey(int mtID)
        {
            try
            {
                return new NDPTramTronBO().GetMeTronByKey(mtID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjMeTron> ListMeTron() => new NDPTramTronBO().ListMeTron();

        public IList<ObjMeTron> ListMeTronByPhieuTronID(int ptID) => new NDPTramTronBO().ListMeTronByPhieuTronID(ptID);

        public bool SaveMeTron(IList<ObjMeTron> lstMT) => new NDPTramTronBO().SaveMeTron(lstMT);

        public ObjMeTronChiTiet GetMeTronChiTietByKey(int mtctID)
        {
            try
            {
                return new NDPTramTronBO().GetMeTronChiTietByKey(mtctID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjMeTronChiTiet> ListMeTronChiTiet() => new NDPTramTronBO().ListMeTronChiTiet();

        public IList<ObjMeTronChiTiet> ListMeTronChiTietByPhieuTronID(int ptID) => new NDPTramTronBO().ListMeTronChiTietByPhieuTronID(ptID);
        public IList<ObjMeTronChiTietGiaoHang> ListMeTronChiTietGiaoHangByPhieuTronID(int ptID) => new NDPTramTronBO().ListMeTronChiTietGiaoHangByPhieuTronID(ptID);

        public bool SaveMeTronChiTiet(IList<ObjMeTronChiTiet> lstMTCT) => new NDPTramTronBO().SaveMeTronChiTiet(lstMTCT);

        public ObjMeTronChiTiet SaveMeTronChiTiet(ObjMeTronChiTiet objMTCT, int phieuTronID) => new NDPTramTronBO().SaveMeTronChiTiet(objMTCT, phieuTronID);
        public ObjMeTronChiTietGiaoHang SaveMeTronChiTietGiaoHang(ObjMeTronChiTietGiaoHang objMTCT, int phieuTronID) => new NDPTramTronBO().SaveMeTronChiTietGiaoHang(objMTCT, phieuTronID);


        public ObjNhomSilo GetNhomSiloByKey(int nsID)
        {
            try
            {
                return new NDPTramTronBO().GetNhomSiloByKey(nsID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjNhomSilo> ListNhomSilo() => new NDPTramTronBO().ListNhomSilo();

        public bool SaveNhomSilo(IList<ObjNhomSilo> lstNS) => new NDPTramTronBO().SaveNhomSilo(lstNS);


        public ObjPhieuTron GetPhieuTronByKey(int ptID)
        {
            try
            {
                return new NDPTramTronBO().GetPhieuTronByKey(ptID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }
        public ObjPhieuGiaoHang GetPhieuGiaoHangByKey(int ptID)
        {
            try
            {
                return new NDPTramTronBO().GetPhieuGiaoHangByKey(ptID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }
        
        public ObjPhieuTron GetPhieuTronByCode(string code)
        {
            try
            {
                return new NDPTramTronBO().GetPhieuTronByCode(code);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }
        public ObjPhieuGiaoHang GetPhieuGiaoHangByCode(string code)
        {
            try
            {
                return new NDPTramTronBO().GetPhieuGiaoHangByCode(code);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjPhieuTron> ListPhieuTron() => new NDPTramTronBO().ListPhieuTron();
        public IList<ObjPhieuGiaoHang> ListPhieuGiaoHang() => new NDPTramTronBO().ListPhieuGiaoHang();

        public IList<ObjPhieuTron> ListPhieuTron_ForTronOnline() => new NDPTramTronBO().ListPhieuTron_ForTronOnline();

        public IList<ObjPhieuTron> ListPhieuTron_ByStatus(int status) => new NDPTramTronBO().ListPhieuTron_ByStatus(status);

        public IList<ObjPhieuTron> ListPhieuTron_ByIsQueued(bool isQueued) => new NDPTramTronBO().ListPhieuTron_ByIsQueued(isQueued);
        public IList<ObjPhieuGiaoHang> ListPhieuGiaoHang_ByIsQueued(bool isQueued) => new NDPTramTronBO().ListPhieuGiaoHang_ByIsQueued(isQueued);

        public IList<ObjPhieuTron> ListPhieuTron_ByCondition(
          string maPhieuTron,
          DateTime fromDate,
          DateTime toDate,
          int? status,
          bool? isQueued)
        {
            return new NDPTramTronBO().ListPhieuTron_ByCondition(maPhieuTron, fromDate, toDate, status, isQueued);
        }
        public IList<ObjPhieuGiaoHang> ListPhieuGiaoHang_ByCondition(
         string maPhieuTron,
         DateTime fromDate,
         DateTime toDate,
         bool? isQueued)
        {
            return new NDPTramTronBO().ListPhieuGiaoHang_ByCondition(maPhieuTron, fromDate, toDate, isQueued);
        }

        public IList<string> ListMaPhieuTron_AutoComplete(string strInput, int? length) => new NDPTramTronBO().ListMaPhieuTron_AutoComplete(strInput, length);

        public IList<ObjPhieuTron> ListPhieuTron_AutoComplete(string strInput, int? length) => new NDPTramTronBO().ListPhieuTron_AutoComplete(strInput, length);

        public bool SavePhieuTron(IList<ObjPhieuTron> lstPT) => new NDPTramTronBO().SavePhieuTron(lstPT);
        public bool SavePhieuGiaoHang(IList<ObjPhieuGiaoHang> lstPT) => new NDPTramTronBO().SavePhieuGiaoHang(lstPT);

        public bool AddOrAttachPhieuTron(ObjPhieuTron objPT) => new NDPTramTronBO().AddOrAttachPhieuTron(objPT);

        public bool UpdatePhieuTron(ObjPhieuTron objPT, decimal klThuc) => new NDPTramTronBO().UpdatePhieuTron(objPT, klThuc);
        public bool UpdatePhieuGiaoHang(ObjPhieuGiaoHang objPT, string klThuc) => new NDPTramTronBO().UpdatePhieuGiaoHang(objPT, klThuc);

        public bool ResolveUnfinishPhieuTron() => new NDPTramTronBO().ResolveUnfinishPhieuTron();



        public ObjSilo GetSiloByKey(int siloID)
        {
            try
            {
                return new NDPTramTronBO().GetSiloByKey(siloID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjSilo> ListSilo() => new NDPTramTronBO().ListSilo();

        public IList<ObjSilo> ListSilo_ByActivated(bool activated) => new NDPTramTronBO().ListSilo_ByActivated(activated);

        public IList<ObjSilo> ListSilo_ByActivated_MaNhomSilo(bool? activated, string maNhomSL) => new NDPTramTronBO().ListSilo_ByActivated_MaNhomSilo(activated, maNhomSL);

        public bool SaveSilo(IList<ObjSilo> lstCT) => new NDPTramTronBO().SaveSilo(lstCT);


        public ObjWeigh GetWeighByKey(int weID)
        {
            try
            {
                return new NDPTramTronBO().GetWeighByKey(weID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjWeigh> ListWeigh() => new NDPTramTronBO().ListWeigh();

        public bool SaveWeigh(IList<ObjWeigh> lstWeigh) => new NDPTramTronBO().SaveWeigh(lstWeigh);

        public ObjWeiSiloSaving GetWeiSiloSavingByKey(int ctID)
        {
            try
            {
                return new NDPTramTronBO().GetWeiSiloSavingByKey(ctID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjWeiSiloSaving> ListWeiSiloSaving() => new NDPTramTronBO().ListWeiSiloSaving();

        public bool SaveWeiSiloSaving(IList<ObjWeiSiloSaving> lstCT) => new NDPTramTronBO().SaveWeiSiloSaving(lstCT);

        public ObjWeiSiloVisible GetWeiSiloVisibleByKey(int ctID)
        {
            try
            {
                return new NDPTramTronBO().GetWeiSiloVisibleByKey(ctID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjWeiSiloVisible> ListWeiSiloVisible() => new NDPTramTronBO().ListWeiSiloVisible();

        public bool SaveWeiSiloVisible(IList<ObjWeiSiloVisible> lstCT) => new NDPTramTronBO().SaveWeiSiloVisible(lstCT);

        public ObjHangMuc GetHangMucByKey(int txID)
        {
            try
            {
                return new NDPTramTronBO().GetHangMucByKey(txID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }
        public IList<ObjHangMuc> ListHangMuc() => new NDPTramTronBO().ListHangMuc();

        public IList<ObjHangMuc> ListHangMuc_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          bool? active)
        {
            return new NDPTramTronBO().ListHangMuc_ByCondition(fromDate, toDate, maKH, tenKH, active);
        }

        public bool SaveHangMuc(IList<ObjHangMuc> lstTX) => new NDPTramTronBO().SaveHangMuc(lstTX);

        public ObjNhanVien GetNhanVienByKey(int txID)
        {
            try
            {
                return new NDPTramTronBO().GetNhanVienByKey(txID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }
        public IList<ObjNhanVien> ListNhanVien() => new NDPTramTronBO().ListNhanVien();

        public IList<ObjNhanVien> ListNhanVien_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string phone,
          bool? active)
        {
            return new NDPTramTronBO().ListNhanVien_ByCondition(fromDate, toDate, maKH, tenKH, phone, active);
        }

        public bool SaveNhanVien(IList<ObjNhanVien> lstTX) => new NDPTramTronBO().SaveNhanVien(lstTX);

        public ObjTaiXe GetTaiXeByKey(int txID)
        {
            try
            {
                return new NDPTramTronBO().GetTaiXeByKey(txID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }
        public IList<ObjTaiXe> ListTaiXe() => new NDPTramTronBO().ListTaiXe();

        public IList<ObjTaiXe> ListTaiXe_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maKH,
          string tenKH,
          string phone,
          bool? active)
        {
            return new NDPTramTronBO().ListTaiXe_ByCondition(fromDate, toDate, maKH, tenKH, phone, active);
        }

        public bool SaveTaiXe(IList<ObjTaiXe> lstTX) => new NDPTramTronBO().SaveTaiXe(lstTX);

        public ObjXe GetXeByKey(int xeID)
        {
            try
            {
                return new NDPTramTronBO().GetXeByKey(xeID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjXe> ListXe() => new NDPTramTronBO().ListXe();

        public IList<ObjXe> ListXe_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string bienSo,
          bool? active)
        {
            return new NDPTramTronBO().ListXe_ByCondition(fromDate, toDate, bienSo, active);
        }

        public bool SaveXe(IList<ObjXe> lstXe) => new NDPTramTronBO().SaveXe(lstXe);


        public ObjTimerPara GetTimerParaByKey(int tiID)
        {
            try
            {
                return new NDPTramTronBO().GetTimerParaByKey(tiID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjTimerPara> ListTimerPara() => new NDPTramTronBO().ListTimerPara();

        public bool SaveTimerPara(IList<ObjTimerPara> lstTimer) => new NDPTramTronBO().SaveTimerPara(lstTimer);
        public ObjTinhDoHutNuoc GetTinhDoHutNuocByKey(int ctID)
        {
            try
            {
                return new NDPTramTronBO().GetTinhDoHutNuocByKey(ctID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }

        public IList<ObjTinhDoHutNuoc> ListTinhDoHutNuoc() => new NDPTramTronBO().ListTinhDoHutNuoc();

        public bool SaveTinhDoHutNuoc(IList<ObjTinhDoHutNuoc> lstCT) => new NDPTramTronBO().SaveTinhDoHutNuoc(lstCT);

        public ObjPhieuTron SaveTronOnline(ObjPhieuTron objPT, List<ObjMeTron> lstMT) => new NDPTramTronBO().SaveTronOnline(objPT, lstMT);

        public ObjMAC SaveMacThemBotNuoc1(int macId, Decimal themBotNuoc1) => new NDPTramTronBO().SaveMacThemBotNuoc1(macId, themBotNuoc1);

        public ObjMAC SaveMacThemBotNuoc2(int macId, Decimal themBotNuoc2) => new NDPTramTronBO().SaveMacThemBotNuoc2(macId, themBotNuoc2);

        public bool SaveNhanVienTronOnline(int id) => new NDPTramTronBO().SaveNhanVienTronOnline(id);

        public bool SaveTaiXeTronOnline(int id) => new NDPTramTronBO().SaveTaiXeTronOnline(id);
        public bool SaveTaiXeTronOnlinePhieuGiaoHang(string id) => new NDPTramTronBO().SaveTaiXeTronOnlinePhieuGiaoHang(id);

        public bool SaveXeTronOnline(int id) => new NDPTramTronBO().SaveXeTronOnline(id);
        public bool SaveXeTronOnlinePhieuGiaoHang(string id) => new NDPTramTronBO().SaveXeTronOnlinePhieuGiaoHang(id);
        public bool SaveNiemChiTronOnline(string niemchi) => new NDPTramTronBO().SaveNiemChiTronOnline(niemchi);
        public bool SaveNiemChiTronOnlinePhieuGiaoHang(string niemchi) => new NDPTramTronBO().SaveNiemChiTronOnlinePhieuGiaoHang(niemchi);
        public bool UpdateDoAmSiloOnlineBySiloID(int siloID, Decimal doAm) => new NDPTramTronBO().UpdateDoAmSiloOnlineBySiloID(siloID, doAm);
        public bool UpdateHutNuocSiloOnlineBySiloID(int siloID, Decimal doAm) => new NDPTramTronBO().UpdateHutNuocSiloOnlineBySiloID(siloID, doAm);

        //==========================

        public Objvw_DataMix GetDataMixByKey(int datamixID)
        {
            try
            {
                return new NDPTramTronBO().GetDataMixByKey(datamixID);
            }
            catch (System.Exception ex)
            {
                if (ex.InnerException is SqlException)
                    throw new FaultException("Exception accessing database: " + ex.InnerException.Message, new FaultCode("Connect to database"));
                throw new FaultException("Exception getting data: " + ex.Message, new FaultCode("Iterate through data"));
            }
        }
        public IList<Objvw_DataMix> ListDataMix() => new NDPTramTronBO().ListDataMix();

        public IList<Objvw_DataMix> ListDataMix_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maPhieuTron,
          string khachHang,
          string congTruong,
          string hangMuc,
          string taiXe,
          string bienSo,
          string mac,
          string nhanVien
          )
        {
            return new NDPTramTronBO().ListDataMix_ByCondition(fromDate, toDate, maPhieuTron, khachHang, congTruong, hangMuc, taiXe, bienSo, mac, nhanVien);
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
            return new NDPTramTronBO().ListDataMix_ByCondition(fromDate, fromTime, toDate, toTime, maPhieuTron, khachHang, congTruong, hangMuc, mac, bienSo, taiXe, nhanVien, moPhong);
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
            return new NDPTramTronBO().ListSumWeight_ByCondition(fromDate, toDate, maPhieuTron, khachHang, congTruong, hangMuc, mac, bienSo, taiXe, nhanVien, moPhong);
        }

        public ObjAggregationResult GetSumForIsQueuedAndTimeRange(
            DateTime? fromDate,
            DateTime? toDate,
            bool? mophong)
        {
            return new NDPTramTronBO().GetSumForIsQueuedAndTimeRange(fromDate, toDate, mophong);
        }

        public string GetNextCode(string strTblName) => new NDPSystemBO().GetNextCode(strTblName);

        public IList<Objvw_MaterialDetailDayWithID> ListTotalMaterial_ByCondition(int? materialID, bool? isManual)
        {
            return new NDPTramTronBO().ListTotalMaterial_ByCondition(materialID, isManual);
        }
        public IList<Objvw_MaterialDetailDayWithID> ListMaterialDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? materialID, bool? isManual)
        {
            return new NDPTramTronBO().ListMaterialDetailDay_ByCondition(fromDate, toDate, materialID, isManual);
        }
        public IList<Objvw_TranferDetailDayWithID> ListTranferDetailDay_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          int? xeID,
          bool? isQueued)
        {
            return new NDPTramTronBO().ListTranferDetailDay_ByCondition(fromDate, toDate, xeID, isQueued);
        }
        public IList<Objvw_TranferDetailDayWithID> ListTotalTranfer_ByCondition(
          int? xeID,
          bool? isManual)
        {
            return new NDPTramTronBO().ListTotalTranfer_ByCondition(xeID, isManual);
        }
        public IList<Objvw_DriverDetailDayWithID> ListTotalDriver_ByCondition(
          int? taixeID,
          bool? isManual)
        {
            return new NDPTramTronBO().ListTotalDriver_ByCondition(taixeID, isManual);
        }
        public IList<Objvw_DriverDetailDayWithID> ListDriverDetailDay_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          int? taiXeID,
          bool? isManual)
        {
            return new NDPTramTronBO().ListDriverDetailDay__ByCondition(fromDate, toDate, taiXeID, isManual);
        }
        // ── TonKho ────────────────────────────────────────────────

        public ObjTonKho GetTonKhoByKey(int id) => new NDPTramTronBO().GetTonKhoByKey(id);
        public IList<ObjTonKho> ListTonKho() => new NDPTramTronBO().ListTonKho();
        public (int HetKho, int CanhBao) DemCanhBao() => new NDPTramTronBO().DemCanhBao();
        public bool SaveTonKho(IList<ObjTonKho> lst) => new NDPTramTronBO().SaveTonKho(lst);

        // ── NhapKho ───────────────────────────────────────────────

        public ObjNhapKho GetNhapKhoByKey(int id) => new NDPTramTronBO().GetNhapKhoByKey(id);
        public IList<ObjNhapKho> ListNhapKho() => new NDPTramTronBO().ListNhapKho();
        public IList<ObjNhapKho> ListNhapKho_BySiloID(int siloID) => new NDPTramTronBO().ListNhapKho_BySiloID(siloID);
        public bool SaveNhapKho(IList<ObjNhapKho> lst) => new NDPTramTronBO().SaveNhapKho(lst);

        // ── XuatKho ───────────────────────────────────────────────

        public ObjXuatKho GetXuatKhoByKey(int id) => new NDPTramTronBO().GetXuatKhoByKey(id);
        public IList<ObjXuatKho> ListXuatKho_ByPhieuTron(int phieuTronID) => new NDPTramTronBO().ListXuatKho_ByPhieuTron(phieuTronID);
        public bool SaveXuatKho(IList<ObjXuatKho> lst) => new NDPTramTronBO().SaveXuatKho(lst);
        public void XuatKhoTheoPhieuTron(int phieuTronID, int duLieuTronID, int createdBy)
            => new NDPTramTronBO().XuatKhoTheoPhieuTron(phieuTronID, duLieuTronID);
    }
}

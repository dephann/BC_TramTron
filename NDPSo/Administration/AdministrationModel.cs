using NDPSo.ClientSetting;
using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public class AdministrationModel : IAdministrationModel, IBase
	{
		public AdministrationModel()
		{
		}

		public ObjSEC_Assembly GetSEC_AssemblyByKey(int ctID)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.GetSEC_AssemblyByKey(ctID);
		}

		public ObjSEC_Function GetSEC_FunctionByKey(int ctID)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.GetSEC_FunctionByKey(ctID);
		}

		public ObjSEC_Role GetSEC_RoleByKey(int ctID)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.GetSEC_RoleByKey(ctID);
		}

		public ObjSEC_RoleFunction GetSEC_RoleFunctionByKey(int ctID)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.GetSEC_RoleFunctionByKey(ctID);
		}

		public ObjSEC_TypeInfo GetSEC_TypeInfoByKey(int ctID)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.GetSEC_TypeInfoByKey(ctID);
		}

		public ObjSEC_User GetSEC_UserByKey(int ctID)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.GetSEC_UserByKey(ctID);
		}

		public ObjSEC_UserRole GetSEC_UserRoleByKey(int ctID)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.GetSEC_UserRoleByKey(ctID);
		}

		public ObjSEC_User GetSEC_User_ByUsername_Pass(string username, string password)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.GetSEC_User_ByUsername_Pass(username, password);
		}

		public bool InsertEventLog(ObjEventLog objEventLog)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.InsertEventLog(objEventLog);
		}

		public IList<ObjEventLog> ListEventLog_ByCondition(DateTime? fromDate, DateTime? toDate, int? userID, int? eventActionCodeID)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjEventLog> lstT = factory.ListEventLog_ByCondition(fromDate, toDate, userID, eventActionCodeID) as List<ObjEventLog>;
			return Converter.ConvertToBindingList<ObjEventLog>(lstT);
		}

		public BindingList<ObjSEC_Assembly> ListSEC_Assembly()
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjSEC_Assembly> lstT = factory.ListSEC_Assembly() as List<ObjSEC_Assembly>;
			return Converter.ConvertToBindingList<ObjSEC_Assembly>(lstT);
		}

		public BindingList<ObjSEC_Function> ListSEC_Function()
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjSEC_Function> lstT = factory.ListSEC_Function() as List<ObjSEC_Function>;
			return Converter.ConvertToBindingList<ObjSEC_Function>(lstT);
		}

		public BindingList<ObjSEC_Function> ListSEC_Function_ByFunctionType(int funcType)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjSEC_Function> lstT = factory.ListSEC_Function_ByFunctionType(funcType) as List<ObjSEC_Function>;
			return Converter.ConvertToBindingList<ObjSEC_Function>(lstT);
		}

		public BindingList<ObjSEC_Role> ListSEC_Role()
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjSEC_Role> lstT = factory.ListSEC_Role() as List<ObjSEC_Role>;
			return Converter.ConvertToBindingList<ObjSEC_Role>(lstT);
		}

		public BindingList<ObjSEC_RoleFunction> ListSEC_RoleFunction()
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjSEC_RoleFunction> lstT = factory.ListSEC_RoleFunction() as List<ObjSEC_RoleFunction>;
			return Converter.ConvertToBindingList<ObjSEC_RoleFunction>(lstT);
		}

		public BindingList<ObjSEC_TypeInfo> ListSEC_TypeInfo()
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjSEC_TypeInfo> lstT = factory.ListSEC_TypeInfo() as List<ObjSEC_TypeInfo>;
			return Converter.ConvertToBindingList<ObjSEC_TypeInfo>(lstT);
		}

		public BindingList<ObjSEC_User> ListSEC_User()
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjSEC_User> lstT = factory.ListSEC_User() as List<ObjSEC_User>;
			return Converter.ConvertToBindingList<ObjSEC_User>(lstT);
		}
		public BindingList<ObjSEC_User> ListSEC_User_ByActive(bool? active)
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjSEC_User> lstT = factory.ListSEC_User_ByActive(active) as List<ObjSEC_User>;
			return Converter.ConvertToBindingList<ObjSEC_User>(lstT);
		}

		public BindingList<ObjSEC_UserRole> ListSEC_UserRole()
		{
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			List<ObjSEC_UserRole> lstT = factory.ListSEC_UserRole() as List<ObjSEC_UserRole>;
			return Converter.ConvertToBindingList<ObjSEC_UserRole>(lstT);
		}

		public bool SaveSEC_Assembly(BindingList<ObjSEC_Assembly> blstAssembly)
		{
			List<ObjSEC_Assembly> lstAssembly = Converter.ConvertToList<ObjSEC_Assembly>(blstAssembly);
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.SaveSEC_Assembly(lstAssembly);
		}

		public bool SaveSEC_Function(BindingList<ObjSEC_Function> blstFunction)
		{
			List<ObjSEC_Function> lstFunction = Converter.ConvertToList<ObjSEC_Function>(blstFunction);
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.SaveSEC_Function(lstFunction);
		}

		public bool SaveSEC_Role(BindingList<ObjSEC_Role> blstRole)
		{
			List<ObjSEC_Role> lstRole = Converter.ConvertToList<ObjSEC_Role>(blstRole);
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.SaveSEC_Role(lstRole);
		}

		public bool SaveSEC_RoleFunction(BindingList<ObjSEC_RoleFunction> blstRoleFunction)
		{
			List<ObjSEC_RoleFunction> lstRoleFunction = Converter.ConvertToList<ObjSEC_RoleFunction>(blstRoleFunction);
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.SaveSEC_RoleFunction(lstRoleFunction);
		}

		public bool SaveSEC_TypeInfo(BindingList<ObjSEC_TypeInfo> blstTypeInfo)
		{
			List<ObjSEC_TypeInfo> lstTypeInfo = Converter.ConvertToList<ObjSEC_TypeInfo>(blstTypeInfo);
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.SaveSEC_TypeInfo(lstTypeInfo);
		}

		public bool SaveSEC_User(BindingList<ObjSEC_User> blstUser)
		{
			List<ObjSEC_User> lstUser = Converter.ConvertToList<ObjSEC_User>(blstUser);
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.SaveSEC_User(lstUser);
		}

		public bool SaveSEC_UserRole(BindingList<ObjSEC_UserRole> blstUserRole)
		{
			List<ObjSEC_UserRole> lstUserRole = Converter.ConvertToList<ObjSEC_UserRole>(blstUserRole);
			IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
			return factory.SaveSEC_UserRole(lstUserRole);
		}
	}
}

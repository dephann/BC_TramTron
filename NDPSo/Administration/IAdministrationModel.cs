using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public interface IAdministrationModel : IBase
	{
		ObjSEC_Assembly GetSEC_AssemblyByKey(int userID);

		ObjSEC_Function GetSEC_FunctionByKey(int userID);

		ObjSEC_Role GetSEC_RoleByKey(int userID);

		ObjSEC_RoleFunction GetSEC_RoleFunctionByKey(int userID);

		ObjSEC_TypeInfo GetSEC_TypeInfoByKey(int userID);

		ObjSEC_User GetSEC_UserByKey(int userID);

		ObjSEC_UserRole GetSEC_UserRoleByKey(int userID);

		ObjSEC_User GetSEC_User_ByUsername_Pass(string username, string password);

		bool InsertEventLog(ObjEventLog objEventLog);

		IList<ObjEventLog> ListEventLog_ByCondition(DateTime? fromDate, DateTime? toDate, int? userID, int? eventActionCodeID);

		BindingList<ObjSEC_Assembly> ListSEC_Assembly();

		BindingList<ObjSEC_Function> ListSEC_Function();

		BindingList<ObjSEC_Function> ListSEC_Function_ByFunctionType(int funcType);

		BindingList<ObjSEC_Role> ListSEC_Role();

		BindingList<ObjSEC_RoleFunction> ListSEC_RoleFunction();

		BindingList<ObjSEC_TypeInfo> ListSEC_TypeInfo();

		BindingList<ObjSEC_User> ListSEC_User();
		BindingList<ObjSEC_User> ListSEC_User_ByActive(bool? active);

		BindingList<ObjSEC_UserRole> ListSEC_UserRole();

		bool SaveSEC_Assembly(BindingList<ObjSEC_Assembly> blstAssembly);

		bool SaveSEC_Function(BindingList<ObjSEC_Function> blstFunction);

		bool SaveSEC_Role(BindingList<ObjSEC_Role> blstRole);

		bool SaveSEC_RoleFunction(BindingList<ObjSEC_RoleFunction> blstRoleFunction);

		bool SaveSEC_TypeInfo(BindingList<ObjSEC_TypeInfo> blstTypeInfo);

		bool SaveSEC_User(BindingList<ObjSEC_User> blstUser);

		bool SaveSEC_UserRole(BindingList<ObjSEC_UserRole> blstUserRole);
	}
}

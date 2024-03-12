using System;
using System.Collections.Generic;
using NDPSo.EntityModel;
using NDPSo.Utils;

namespace NDPSo.Data
{
	public class SEC_UserHelper
	{
		public static string GenMemberValues(ObjSEC_User obj)
		{
			string r = string.Empty;
			r = r + "#1@#UserID#2@#" + obj.UserID;
			r = r + "#1@#UserName#2@#" + obj.UserName;
			r = r + "#1@#Password#2@#" + obj.Password;
			r = r + "#1@#FullName#2@#" + obj.FullName;
			r = r + "#1@#Department#2@#" + obj.Department;
			r = r + "#1@#Email#2@#" + obj.Email;
			r = r + "#1@#Phone#2@#" + obj.Phone;
			r = r + "#1@#CellPhone#2@#" + obj.CellPhone;
			r = r + "#1@#IsActived#2@#" + obj.IsActived;
			r = r + "#1@#IsInUse#2@#" + obj.IsInUse;
			r = r + "#1@#CreationDate#2@#" + obj.CreationDate;
			r = r + "#1@#CreatedBy#2@#" + obj.CreatedBy;
			r = r + "#1@#LatestUpdateDate#2@#" + obj.LatestUpdateDate;
			return r + "#1@#LatestUpdatedBy#2@#" + obj.LatestUpdatedBy;
		}

		public static string GenMemberValues(SEC_User ent)
		{
			string r = string.Empty;
			r = r + "#1@#UserID#2@#" + ent.UserID;
			r = r + "#1@#UserName#2@#" + ent.UserName;
			r = r + "#1@#Password#2@#" + ent.Password;
			r = r + "#1@#FullName#2@#" + ent.FullName;
			r = r + "#1@#Department#2@#" + ent.Department;
			r = r + "#1@#Email#2@#" + ent.Email;
			r = r + "#1@#Phone#2@#" + ent.Phone;
			r = r + "#1@#CellPhone#2@#" + ent.CellPhone;
			r = r + "#1@#IsActived#2@#" + ent.IsActived;
			r = r + "#1@#IsInUse#2@#" + ent.IsInUse;
			r = r + "#1@#CreationDate#2@#" + ent.CreationDate;
			r = r + "#1@#CreatedBy#2@#" + ent.CreatedBy;
			r = r + "#1@#LatestUpdateDate#2@#" + ent.LatestUpdateDate;
			return r + "#1@#LatestUpdatedBy#2@#" + ent.LatestUpdatedBy;
		}

		public static void CopyToObjSEC_User(SEC_User fromEnt, ObjSEC_User toObj) // từ SQL đến PM
		{
			toObj.UserID = fromEnt.UserID;
			toObj.UserName = fromEnt.UserName;
			toObj.Password = fromEnt.Password;
			toObj.FullName = fromEnt.FullName;
			toObj.Department = fromEnt.Department;
			toObj.Email = fromEnt.Email;
			toObj.Phone = fromEnt.Phone;
			toObj.CellPhone = fromEnt.CellPhone;
			toObj.IsActived = fromEnt.IsActived;
			toObj.IsInUse = fromEnt.IsInUse;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			if (toObj.UserID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntSEC_User(ObjSEC_User fromObj, SEC_User toEnt) //từ PM đến SQL
		{
			toEnt.UserID = fromObj.UserID;
			toEnt.UserName = fromObj.UserName;
			toEnt.Password = fromObj.Password;
			toEnt.FullName = fromObj.FullName;
			toEnt.Department = fromObj.Department;
			toEnt.Email = fromObj.Email;
			toEnt.Phone = fromObj.Phone;
			toEnt.CellPhone = fromObj.CellPhone;
			toEnt.IsActived = fromObj.IsActived;
			toEnt.IsInUse = fromObj.IsInUse;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
		}

		public static ObjSEC_User BuildNewObjSEC_User(SEC_User entSEC_User)
		{
			ObjSEC_User objSEC_User = new ObjSEC_User();
			SEC_UserHelper.CopyToObjSEC_User(entSEC_User, objSEC_User);
			return objSEC_User;
		}

		public static IList<ObjSEC_User> BuildListObjSEC_User(IList<SEC_User> lstEntSEC_User)
		{
			IList<ObjSEC_User> lstObjSEC_User = new List<ObjSEC_User>();
			foreach (SEC_User entSEC_User in lstEntSEC_User)
			{
				lstObjSEC_User.Add(SEC_UserHelper.BuildNewObjSEC_User(entSEC_User));
			}
			return lstObjSEC_User;
		}

		public static SEC_User BuildNewEntSEC_User(ObjSEC_User objSEC_User)
		{
			SEC_User entSEC_User = new SEC_User();
			SEC_UserHelper.CopyToEntSEC_User(objSEC_User, entSEC_User);
			return entSEC_User;
		}

		public static IList<SEC_User> BuildListEntSEC_User(IList<ObjSEC_User> lstObjSEC_User)
		{
			IList<SEC_User> lstEntSEC_User = new List<SEC_User>();
			foreach (ObjSEC_User objSEC_User in lstObjSEC_User)
			{
				lstEntSEC_User.Add(SEC_UserHelper.BuildNewEntSEC_User(objSEC_User));
			}
			return lstEntSEC_User;
		}
	}
}

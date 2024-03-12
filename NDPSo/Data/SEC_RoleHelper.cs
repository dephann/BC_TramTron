using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class SEC_RoleHelper
	{
		public static string GenMemberValues(ObjSEC_Role obj)
		{
			string r = string.Empty;
			r = r + "#1@#RoleID#2@#" + obj.RoleID;
			r = r + "#1@#RoleName#2@#" + obj.RoleName;
			r = r + "#1@#Description#2@#" + obj.Description;
			r = r + "#1@#CreationDate#2@#" + obj.CreationDate;
			r = r + "#1@#CreatedBy#2@#" + obj.CreatedBy;
			r = r + "#1@#LatestUpdateDate#2@#" + obj.LatestUpdateDate;
			return r + "#1@#LatestUpdatedBy#2@#" + obj.LatestUpdatedBy;
		}

		public static string GenMemberValues(SEC_Role ent)
		{
			string r = string.Empty;
			r = r + "#1@#RoleID#2@#" + ent.RoleID;
			r = r + "#1@#RoleName#2@#" + ent.RoleName;
			r = r + "#1@#Description#2@#" + ent.Description;
			r = r + "#1@#CreationDate#2@#" + ent.CreationDate;
			r = r + "#1@#CreatedBy#2@#" + ent.CreatedBy;
			r = r + "#1@#LatestUpdateDate#2@#" + ent.LatestUpdateDate;
			return r + "#1@#LatestUpdatedBy#2@#" + ent.LatestUpdatedBy;
		}

		public static void CopyToObjSEC_Role(SEC_Role fromEnt, ObjSEC_Role toObj)
		{
			toObj.RoleID = fromEnt.RoleID;
			toObj.RoleName = fromEnt.RoleName;
			toObj.Description = fromEnt.Description;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			if (toObj.RoleID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntSEC_Role(ObjSEC_Role fromObj, SEC_Role toEnt)
		{
			toEnt.RoleID = fromObj.RoleID;
			toEnt.RoleName = fromObj.RoleName;
			toEnt.Description = fromObj.Description;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
		}

		public static ObjSEC_Role BuildNewObjSEC_Role(SEC_Role entSEC_Role)
		{
			ObjSEC_Role objSEC_Role = new ObjSEC_Role();
			SEC_RoleHelper.CopyToObjSEC_Role(entSEC_Role, objSEC_Role);
			return objSEC_Role;
		}

		public static IList<ObjSEC_Role> BuildListObjSEC_Role(IList<SEC_Role> lstEntSEC_Role)
		{
			IList<ObjSEC_Role> lstObjSEC_Role = new List<ObjSEC_Role>();
			foreach (SEC_Role entSEC_Role in lstEntSEC_Role)
			{
				lstObjSEC_Role.Add(SEC_RoleHelper.BuildNewObjSEC_Role(entSEC_Role));
			}
			return lstObjSEC_Role;
		}

		public static SEC_Role BuildNewEntSEC_Role(ObjSEC_Role objSEC_Role)
		{
			SEC_Role entSEC_Role = new SEC_Role();
			SEC_RoleHelper.CopyToEntSEC_Role(objSEC_Role, entSEC_Role);
			return entSEC_Role;
		}

		public static IList<SEC_Role> BuildListEntSEC_Role(IList<ObjSEC_Role> lstObjSEC_Role)
		{
			IList<SEC_Role> lstEntSEC_Role = new List<SEC_Role>();
			foreach (ObjSEC_Role objSEC_Role in lstObjSEC_Role)
			{
				lstEntSEC_Role.Add(SEC_RoleHelper.BuildNewEntSEC_Role(objSEC_Role));
			}
			return lstEntSEC_Role;
		}
	}
}

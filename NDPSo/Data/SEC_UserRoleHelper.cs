using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class SEC_UserRoleHelper
	{
		public static void CopyToObjSEC_UserRole(SEC_UserRole fromEnt, ObjSEC_UserRole toObj)
		{
			toObj.UserRoleID = fromEnt.UserRoleID;
			toObj.UserID = fromEnt.UserID;
			toObj.RoleID = fromEnt.RoleID;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			if (toObj.UserRoleID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntSEC_UserRole(ObjSEC_UserRole fromObj, SEC_UserRole toEnt)
		{
			toEnt.UserRoleID = fromObj.UserRoleID;
			toEnt.UserID = fromObj.UserID;
			toEnt.RoleID = fromObj.RoleID;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
		}

		public static ObjSEC_UserRole BuildNewObjSEC_UserRole(SEC_UserRole entSEC_UserRole)
		{
			ObjSEC_UserRole objSEC_UserRole = new ObjSEC_UserRole();
			SEC_UserRoleHelper.CopyToObjSEC_UserRole(entSEC_UserRole, objSEC_UserRole);
			return objSEC_UserRole;
		}

		public static IList<ObjSEC_UserRole> BuildListObjSEC_UserRole(IList<SEC_UserRole> lstEntSEC_UserRole)
		{
			IList<ObjSEC_UserRole> lstObjSEC_UserRole = new List<ObjSEC_UserRole>();
			foreach (SEC_UserRole entSEC_UserRole in lstEntSEC_UserRole)
			{
				lstObjSEC_UserRole.Add(SEC_UserRoleHelper.BuildNewObjSEC_UserRole(entSEC_UserRole));
			}
			return lstObjSEC_UserRole;
		}

		public static SEC_UserRole BuildNewEntSEC_UserRole(ObjSEC_UserRole objSEC_UserRole)
		{
			SEC_UserRole entSEC_UserRole = new SEC_UserRole();
			SEC_UserRoleHelper.CopyToEntSEC_UserRole(objSEC_UserRole, entSEC_UserRole);
			return entSEC_UserRole;
		}

		public static IList<SEC_UserRole> BuildListEntSEC_UserRole(IList<ObjSEC_UserRole> lstObjSEC_UserRole)
		{
			IList<SEC_UserRole> lstEntSEC_UserRole = new List<SEC_UserRole>();
			foreach (ObjSEC_UserRole objSEC_UserRole in lstObjSEC_UserRole)
			{
				lstEntSEC_UserRole.Add(SEC_UserRoleHelper.BuildNewEntSEC_UserRole(objSEC_UserRole));
			}
			return lstEntSEC_UserRole;
		}
	}
}

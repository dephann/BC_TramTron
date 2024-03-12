using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class SEC_RoleFunctionHelper
	{
		public static void CopyToObjSEC_RoleFunction(SEC_RoleFunction fromEnt, ObjSEC_RoleFunction toObj)
		{
			toObj.RoleFunctionID = fromEnt.RoleFunctionID;
			toObj.RoleID = fromEnt.RoleID;
			toObj.FunctionID = fromEnt.FunctionID;
			toObj.Description = fromEnt.Description;
			toObj.CreationDate = fromEnt.CreationDate;
			toObj.CreatedBy = fromEnt.CreatedBy;
			toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
			toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
			if (toObj.RoleFunctionID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntSEC_RoleFunction(ObjSEC_RoleFunction fromObj, SEC_RoleFunction toEnt)
		{
			toEnt.RoleFunctionID = fromObj.RoleFunctionID;
			toEnt.RoleID = fromObj.RoleID;
			toEnt.FunctionID = fromObj.FunctionID;
			toEnt.Description = fromObj.Description;
			toEnt.CreationDate = fromObj.CreationDate;
			toEnt.CreatedBy = fromObj.CreatedBy;
			toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
			toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
		}

		public static ObjSEC_RoleFunction BuildNewObjSEC_RoleFunction(SEC_RoleFunction entSEC_RoleFunction)
		{
			ObjSEC_RoleFunction objSEC_RoleFunction = new ObjSEC_RoleFunction();
			SEC_RoleFunctionHelper.CopyToObjSEC_RoleFunction(entSEC_RoleFunction, objSEC_RoleFunction);
			return objSEC_RoleFunction;
		}

		public static IList<ObjSEC_RoleFunction> BuildListObjSEC_RoleFunction(IList<SEC_RoleFunction> lstEntSEC_RoleFunction)
		{
			IList<ObjSEC_RoleFunction> lstObjSEC_RoleFunction = new List<ObjSEC_RoleFunction>();
			foreach (SEC_RoleFunction entSEC_RoleFunction in lstEntSEC_RoleFunction)
			{
				lstObjSEC_RoleFunction.Add(SEC_RoleFunctionHelper.BuildNewObjSEC_RoleFunction(entSEC_RoleFunction));
			}
			return lstObjSEC_RoleFunction;
		}

		public static SEC_RoleFunction BuildNewEntSEC_RoleFunction(ObjSEC_RoleFunction objSEC_RoleFunction)
		{
			SEC_RoleFunction entSEC_RoleFunction = new SEC_RoleFunction();
			SEC_RoleFunctionHelper.CopyToEntSEC_RoleFunction(objSEC_RoleFunction, entSEC_RoleFunction);
			return entSEC_RoleFunction;
		}

		public static IList<SEC_RoleFunction> BuildListEntSEC_RoleFunction(IList<ObjSEC_RoleFunction> lstObjSEC_RoleFunction)
		{
			IList<SEC_RoleFunction> lstEntSEC_RoleFunction = new List<SEC_RoleFunction>();
			foreach (ObjSEC_RoleFunction objSEC_RoleFunction in lstObjSEC_RoleFunction)
			{
				lstEntSEC_RoleFunction.Add(SEC_RoleFunctionHelper.BuildNewEntSEC_RoleFunction(objSEC_RoleFunction));
			}
			return lstEntSEC_RoleFunction;
		}
	}
}

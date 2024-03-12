using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class SEC_TypeInfoHelper
	{
		public static void CopyToObjSEC_TypeInfo(SEC_TypeInfo fromEnt, ObjSEC_TypeInfo toObj)
		{
			toObj.TypeInfoID = fromEnt.TypeInfoID;
			toObj.TypeInfo = fromEnt.TypeInfo;
			toObj.AssemblyID = fromEnt.AssemblyID;
			toObj.NPSEC_AssemblyAssemblyInfo = fromEnt.SEC_Assembly.AssemblyInfo;
			if (toObj.TypeInfoID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntSEC_TypeInfo(ObjSEC_TypeInfo fromObj, SEC_TypeInfo toEnt)
		{
			toEnt.TypeInfoID = fromObj.TypeInfoID;
			toEnt.TypeInfo = fromObj.TypeInfo;
			toEnt.AssemblyID = fromObj.AssemblyID;
		}

		public static ObjSEC_TypeInfo BuildNewObjSEC_TypeInfo(SEC_TypeInfo entSEC_TypeInfo)
		{
			ObjSEC_TypeInfo objSEC_TypeInfo = new ObjSEC_TypeInfo();
			SEC_TypeInfoHelper.CopyToObjSEC_TypeInfo(entSEC_TypeInfo, objSEC_TypeInfo);
			return objSEC_TypeInfo;
		}

		public static IList<ObjSEC_TypeInfo> BuildListObjSEC_TypeInfo(IList<SEC_TypeInfo> lstEntSEC_TypeInfo)
		{
			IList<ObjSEC_TypeInfo> lstObjSEC_TypeInfo = new List<ObjSEC_TypeInfo>();
			foreach (SEC_TypeInfo entSEC_TypeInfo in lstEntSEC_TypeInfo)
			{
				lstObjSEC_TypeInfo.Add(SEC_TypeInfoHelper.BuildNewObjSEC_TypeInfo(entSEC_TypeInfo));
			}
			return lstObjSEC_TypeInfo;
		}

		public static SEC_TypeInfo BuildNewEntSEC_TypeInfo(ObjSEC_TypeInfo objSEC_TypeInfo)
		{
			SEC_TypeInfo entSEC_TypeInfo = new SEC_TypeInfo();
			SEC_TypeInfoHelper.CopyToEntSEC_TypeInfo(objSEC_TypeInfo, entSEC_TypeInfo);
			return entSEC_TypeInfo;
		}

		public static IList<SEC_TypeInfo> BuildListEntSEC_TypeInfo(IList<ObjSEC_TypeInfo> lstObjSEC_TypeInfo)
		{
			IList<SEC_TypeInfo> lstEntSEC_TypeInfo = new List<SEC_TypeInfo>();
			foreach (ObjSEC_TypeInfo objSEC_TypeInfo in lstObjSEC_TypeInfo)
			{
				lstEntSEC_TypeInfo.Add(SEC_TypeInfoHelper.BuildNewEntSEC_TypeInfo(objSEC_TypeInfo));
			}
			return lstEntSEC_TypeInfo;
		}
	}
}

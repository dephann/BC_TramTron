using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class SEC_AssemblyHelper
	{
		public static void CopyToObjSEC_Assembly(SEC_Assembly fromEnt, ObjSEC_Assembly toObj)
		{
			toObj.AssemblyID = fromEnt.AssemblyID;
			toObj.AssemblyInfo = fromEnt.AssemblyInfo;
			if (toObj.AssemblyID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntSEC_Assembly(ObjSEC_Assembly fromObj, SEC_Assembly toEnt)
		{
			toEnt.AssemblyID = fromObj.AssemblyID;
			toEnt.AssemblyInfo = fromObj.AssemblyInfo;
		}

		public static ObjSEC_Assembly BuildNewObjSEC_Assembly(SEC_Assembly entSEC_Assembly)
		{
			ObjSEC_Assembly objSEC_Assembly = new ObjSEC_Assembly();
			SEC_AssemblyHelper.CopyToObjSEC_Assembly(entSEC_Assembly, objSEC_Assembly);
			return objSEC_Assembly;
		}

		public static IList<ObjSEC_Assembly> BuildListObjSEC_Assembly(IList<SEC_Assembly> lstEntSEC_Assembly)
		{
			IList<ObjSEC_Assembly> lstObjSEC_Assembly = new List<ObjSEC_Assembly>();
			foreach (SEC_Assembly entSEC_Assembly in lstEntSEC_Assembly)
			{
				lstObjSEC_Assembly.Add(SEC_AssemblyHelper.BuildNewObjSEC_Assembly(entSEC_Assembly));
			}
			return lstObjSEC_Assembly;
		}

		public static SEC_Assembly BuildNewEntSEC_Assembly(ObjSEC_Assembly objSEC_Assembly)
		{
			SEC_Assembly entSEC_Assembly = new SEC_Assembly();
			SEC_AssemblyHelper.CopyToEntSEC_Assembly(objSEC_Assembly, entSEC_Assembly);
			return entSEC_Assembly;
		}

		public static IList<SEC_Assembly> BuildListEntSEC_Assembly(IList<ObjSEC_Assembly> lstObjSEC_Assembly)
		{
			IList<SEC_Assembly> lstEntSEC_Assembly = new List<SEC_Assembly>();
			foreach (ObjSEC_Assembly objSEC_Assembly in lstObjSEC_Assembly)
			{
				lstEntSEC_Assembly.Add(SEC_AssemblyHelper.BuildNewEntSEC_Assembly(objSEC_Assembly));
			}
			return lstEntSEC_Assembly;
		}
	}
}

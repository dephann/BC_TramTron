using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class PCOutputHelper
	{
		public static void CopyToObjPCOutput(PCOutput fromEnt, ObjPCOutput toObj)
		{
			toObj.PCOutputID = fromEnt.PCOutputID;
			toObj.Code = fromEnt.Code;
			toObj.Value = fromEnt.Value;
			toObj.Description = fromEnt.Description;
			if (toObj.PCOutputID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntPCOutput(ObjPCOutput fromObj, PCOutput toEnt)
		{
			toEnt.PCOutputID = fromObj.PCOutputID;
			toEnt.Code = fromObj.Code;
			toEnt.Value = fromObj.Value;
			toEnt.Description = fromObj.Description;
		}

		public static ObjPCOutput BuildNewObjPCOutput(PCOutput entPCOutput)
		{
			ObjPCOutput objPCOutput = new ObjPCOutput();
			PCOutputHelper.CopyToObjPCOutput(entPCOutput, objPCOutput);
			return objPCOutput;
		}

		public static IList<ObjPCOutput> BuildListObjPCOutput(IList<PCOutput> lstEntPCOutput)
		{
			IList<ObjPCOutput> lstObjPCOutput = new List<ObjPCOutput>();
			foreach (PCOutput entPCOutput in lstEntPCOutput)
			{
				lstObjPCOutput.Add(PCOutputHelper.BuildNewObjPCOutput(entPCOutput));
			}
			return lstObjPCOutput;
		}

		public static PCOutput BuildNewEntPCOutput(ObjPCOutput objPCOutput)
		{
			PCOutput entPCOutput = new PCOutput();
			PCOutputHelper.CopyToEntPCOutput(objPCOutput, entPCOutput);
			return entPCOutput;
		}

		public static IList<PCOutput> BuildListEntPCOutput(IList<ObjPCOutput> lstObjPCOutput)
		{
			IList<PCOutput> lstEntPCOutput = new List<PCOutput>();
			foreach (ObjPCOutput objPCOutput in lstObjPCOutput)
			{
				lstEntPCOutput.Add(PCOutputHelper.BuildNewEntPCOutput(objPCOutput));
			}
			return lstEntPCOutput;
		}
	}
}

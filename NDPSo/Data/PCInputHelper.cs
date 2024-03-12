using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class PCInputHelper
	{
		public static void CopyToObjPCInput(PCInput fromEnt, ObjPCInput toObj)
		{
			toObj.PCInputID = fromEnt.PCInputID;
			toObj.Code = fromEnt.Code;
			toObj.Value = fromEnt.Value;
			toObj.Description = fromEnt.Description;
			if (toObj.PCInputID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntPCInput(ObjPCInput fromObj, PCInput toEnt)
		{
			toEnt.PCInputID = fromObj.PCInputID;
			toEnt.Code = fromObj.Code;
			toEnt.Value = fromObj.Value;
			toEnt.Description = fromObj.Description;
		}

		public static ObjPCInput BuildNewObjPCInput(PCInput entPCInput)
		{
			ObjPCInput objPCInput = new ObjPCInput();
			PCInputHelper.CopyToObjPCInput(entPCInput, objPCInput);
			return objPCInput;
		}

		public static IList<ObjPCInput> BuildListObjPCInput(IList<PCInput> lstEntPCInput)
		{
			IList<ObjPCInput> lstObjPCInput = new List<ObjPCInput>();
			foreach (PCInput entPCInput in lstEntPCInput)
			{
				lstObjPCInput.Add(PCInputHelper.BuildNewObjPCInput(entPCInput));
			}
			return lstObjPCInput;
		}

		public static PCInput BuildNewEntPCInput(ObjPCInput objPCInput)
		{
			PCInput entPCInput = new PCInput();
			PCInputHelper.CopyToEntPCInput(objPCInput, entPCInput);
			return entPCInput;
		}

		public static IList<PCInput> BuildListEntPCInput(IList<ObjPCInput> lstObjPCInput)
		{
			IList<PCInput> lstEntPCInput = new List<PCInput>();
			foreach (ObjPCInput objPCInput in lstObjPCInput)
			{
				lstEntPCInput.Add(PCInputHelper.BuildNewEntPCInput(objPCInput));
			}
			return lstEntPCInput;
		}
	}
}

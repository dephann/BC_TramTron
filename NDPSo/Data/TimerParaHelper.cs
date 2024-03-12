using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class TimerParaHelper
	{
		public static void CopyToObjTimerPara(TimerPara fromEnt, ObjTimerPara toObj)
		{
			toObj.TimerParaID = fromEnt.TimerParaID;
			toObj.TimerParaCode = fromEnt.TimerParaCode;
			toObj.TimerParaValue = fromEnt.TimerParaValue;
			toObj.Description = fromEnt.Description;
			if (toObj.TimerParaID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntTimerPara(ObjTimerPara fromObj, TimerPara toEnt)
		{
			toEnt.TimerParaID = fromObj.TimerParaID;
			toEnt.TimerParaCode = fromObj.TimerParaCode;
			toEnt.TimerParaValue = fromObj.TimerParaValue;
			toEnt.Description = fromObj.Description;
		}

		public static ObjTimerPara BuildNewObjTimerPara(TimerPara entTimerPara)
		{
			ObjTimerPara objTimerPara = new ObjTimerPara();
			TimerParaHelper.CopyToObjTimerPara(entTimerPara, objTimerPara);
			return objTimerPara;
		}

		public static IList<ObjTimerPara> BuildListObjTimerPara(IList<TimerPara> lstEntTimerPara)
		{
			IList<ObjTimerPara> lstObjTimerPara = new List<ObjTimerPara>();
			foreach (TimerPara entTimerPara in lstEntTimerPara)
			{
				lstObjTimerPara.Add(TimerParaHelper.BuildNewObjTimerPara(entTimerPara));
			}
			return lstObjTimerPara;
		}

		public static TimerPara BuildNewEntTimerPara(ObjTimerPara objTimerPara)
		{
			TimerPara entTimerPara = new TimerPara();
			TimerParaHelper.CopyToEntTimerPara(objTimerPara, entTimerPara);
			return entTimerPara;
		}

		public static IList<TimerPara> BuildListEntTimerPara(IList<ObjTimerPara> lstObjTimerPara)
		{
			IList<TimerPara> lstEntTimerPara = new List<TimerPara>();
			foreach (ObjTimerPara objTimerPara in lstObjTimerPara)
			{
				lstEntTimerPara.Add(TimerParaHelper.BuildNewEntTimerPara(objTimerPara));
			}
			return lstEntTimerPara;
		}
	}
}

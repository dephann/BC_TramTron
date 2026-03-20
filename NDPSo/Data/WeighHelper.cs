using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
	public class WeighHelper
	{
		public static void CopyToObjWeigh(Weigh fromEnt, ObjWeigh toObj)
		{
			toObj.WeighID = fromEnt.WeighID;
			toObj.WeighCode = fromEnt.WeighCode;
			toObj.WeighName = fromEnt.WeighName;
			toObj.Description = fromEnt.Description;
			toObj.STT = fromEnt.STT;
			toObj.Zero = fromEnt.Zero;
			toObj.Max = fromEnt.Max;
			toObj.Offset = fromEnt.Offset;
			toObj.KLEmpty = fromEnt.KLEmpty;
			toObj.TimeEmpty = fromEnt.TimeEmpty;
			toObj.Limit = fromEnt.Limit;
			toObj.WeiToVib = fromEnt.WeiToVib;
			toObj.TON = fromEnt.TON;
			toObj.TOFF = fromEnt.TOFF;
			toObj.Spare = fromEnt.Spare;
			toObj.GiuKLTC = fromEnt.GiuKLTC;
			//toObj.TiLeXa = fromEnt.TiLeXa;
			if (toObj.WeighID > 0)
			{
				toObj.IsNewObject = false;
			}
		}

		public static void CopyToEntWeigh(ObjWeigh fromObj, Weigh toEnt)
		{
			toEnt.WeighID = fromObj.WeighID;
			toEnt.WeighCode = fromObj.WeighCode;
			toEnt.WeighName = fromObj.WeighName;
			toEnt.Description = fromObj.Description;
			toEnt.STT = fromObj.STT;
			toEnt.Zero = fromObj.Zero;
			toEnt.Max = fromObj.Max;
			toEnt.Offset = fromObj.Offset;
			toEnt.KLEmpty = fromObj.KLEmpty;
			toEnt.TimeEmpty = fromObj.TimeEmpty;
			toEnt.Limit = fromObj.Limit;
			toEnt.WeiToVib = fromObj.WeiToVib;
			toEnt.TON = fromObj.TON;
			toEnt.TOFF = fromObj.TOFF;
			toEnt.Spare = fromObj.Spare;
			toEnt.GiuKLTC = fromObj.GiuKLTC;
			//toEnt.TiLeXa = fromObj.TiLeXa;
		}

		public static ObjWeigh BuildNewObjWeigh(Weigh entWeigh)
		{
			ObjWeigh objWeigh = new ObjWeigh();
			WeighHelper.CopyToObjWeigh(entWeigh, objWeigh);
			return objWeigh;
		}

		public static IList<ObjWeigh> BuildListObjWeigh(IList<Weigh> lstEntWeigh)
		{
			IList<ObjWeigh> lstObjWeigh = new List<ObjWeigh>();
			foreach (Weigh entWeigh in lstEntWeigh)
			{
				lstObjWeigh.Add(WeighHelper.BuildNewObjWeigh(entWeigh));
			}
			return lstObjWeigh;
		}

		public static Weigh BuildNewEntWeigh(ObjWeigh objWeigh)
		{
			Weigh entWeigh = new Weigh();
			WeighHelper.CopyToEntWeigh(objWeigh, entWeigh);
			return entWeigh;
		}

		public static IList<Weigh> BuildListEntWeigh(IList<ObjWeigh> lstObjWeigh)
		{
			IList<Weigh> lstEntWeigh = new List<Weigh>();
			foreach (ObjWeigh objWeigh in lstObjWeigh)
			{
				lstEntWeigh.Add(WeighHelper.BuildNewEntWeigh(objWeigh));
			}
			return lstEntWeigh;
		}
	}
}

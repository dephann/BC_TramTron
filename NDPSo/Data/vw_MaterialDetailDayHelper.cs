using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
    class vw_MaterialDetailDayHelper
    {
		public static void CopyToObjvw_MaterialDetailDay(vw_PvMaterialDetailDay fromEnt, Objvw_MaterialDetailDay toObj)
		{
			toObj.MaterialID = (int)fromEnt.MaterialID;
			toObj.MaterialCode = fromEnt.MaterialCode;
			toObj.MaterialName = fromEnt.MaterialName;
			toObj.Sum_ValueCP = fromEnt.Sum_ValueCP;
			toObj.Sum_ValueBat = fromEnt.Sum_ValueBat;
			toObj.Sum_ValueBatMan = fromEnt.Sum_ValueBatMan;
			toObj.SaiSo = fromEnt.SaiSo;
			toObj.PerSaiSo = fromEnt.PerSaiSo;
			toObj.NgayMeTron = fromEnt.NgayMeTron;
			toObj.IsManual = fromEnt.IsManual;
		}
		public static void CopyToEntvw_MaterialDetailDay(Objvw_MaterialDetailDay fromObj, vw_PvMaterialDetailDay toEnt)
		{
			toEnt.MaterialID = fromObj.MaterialID;
			toEnt.MaterialCode = fromObj.MaterialCode;
			toEnt.MaterialName = fromObj.MaterialName;
			toEnt.Sum_ValueCP = fromObj.Sum_ValueCP;
			toEnt.Sum_ValueBat = fromObj.Sum_ValueBat;
			toEnt.Sum_ValueBatMan = fromObj.Sum_ValueBatMan;
			toEnt.SaiSo = fromObj.SaiSo;
			toEnt.PerSaiSo = fromObj.PerSaiSo;
			toEnt.NgayMeTron = fromObj.NgayMeTron;
			toEnt.IsManual = fromObj.IsManual;
		}
		public static Objvw_MaterialDetailDay BuildNewObjvw_MaterialDetailDay(vw_PvMaterialDetailDay entvw_MaterialDetailDay)
		{
			Objvw_MaterialDetailDay objvw_MaterialDetailDay = new Objvw_MaterialDetailDay();
			vw_MaterialDetailDayHelper.CopyToObjvw_MaterialDetailDay(entvw_MaterialDetailDay, objvw_MaterialDetailDay);
			return objvw_MaterialDetailDay;
		}
		public static IList<Objvw_MaterialDetailDay> BuildListObjvw_MaterialDetailDay(IList<vw_PvMaterialDetailDay> lstEntvw_MaterialDetailDay)
		{
			IList<Objvw_MaterialDetailDay> lstObjvw_MaterialDetailDay = new List<Objvw_MaterialDetailDay>();
			foreach (vw_PvMaterialDetailDay entvw_MaterialDetailDay in lstEntvw_MaterialDetailDay)
			{
				lstObjvw_MaterialDetailDay.Add(vw_MaterialDetailDayHelper.BuildNewObjvw_MaterialDetailDay(entvw_MaterialDetailDay));
			}
			return lstObjvw_MaterialDetailDay;
		}
		public static vw_PvMaterialDetailDay BuildNewEntvw_MaterialDetailDay(Objvw_MaterialDetailDay objvw_MaterialDetailDay)
		{
			vw_PvMaterialDetailDay entvw_MaterialDetailDay = new vw_PvMaterialDetailDay();
			vw_MaterialDetailDayHelper.CopyToEntvw_MaterialDetailDay(objvw_MaterialDetailDay, entvw_MaterialDetailDay);
			return entvw_MaterialDetailDay;
		}
		public static IList<vw_PvMaterialDetailDay> BuildListEntvw_MaterialDetailDay(IList<Objvw_MaterialDetailDay> lstObjvw_MaterialDetailDay)
		{
			IList<vw_PvMaterialDetailDay> lstEntvw_MaterialDetailDay = new List<vw_PvMaterialDetailDay>();
			foreach (Objvw_MaterialDetailDay objvw_MaterialDetailDay in lstObjvw_MaterialDetailDay)
			{
				lstEntvw_MaterialDetailDay.Add(vw_MaterialDetailDayHelper.BuildNewEntvw_MaterialDetailDay(objvw_MaterialDetailDay));
			}
			return lstEntvw_MaterialDetailDay;
		}
	}
}

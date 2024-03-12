using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
    class vw_TotalMaterialHelper
    {
        public static void CopyToObjvw_TotalMaterial(vw_PvTotalMaterial fromEnt, Objvw_TotalMaterial toObj)
        {
			toObj.MaterialID = fromEnt.MaterialID;
			toObj.MaterialCode = fromEnt.MaterialCode;
			toObj.MaterialName = fromEnt.MaterialName;
			toObj.Sum_ValueCP = fromEnt.Sum_ValueCP;
			toObj.Sum_ValueBat = fromEnt.Sum_ValueBat;
			toObj.Sum_ValueBatMan = fromEnt.Sum_ValueBatMan;
			toObj.SaiSo = fromEnt.SaiSo;
			toObj.PerSaiSo = fromEnt.PerSaiSo;
			toObj.IsManual = fromEnt.IsManual;
		}
		public static void CopyToEntvw_TotalMaterial(Objvw_TotalMaterial fromObj, vw_PvTotalMaterial toEnt)
        {
			toEnt.MaterialID = fromObj.MaterialID;
			toEnt.MaterialCode = fromObj.MaterialCode;
			toEnt.MaterialName = fromObj.MaterialName;
			toEnt.Sum_ValueCP = fromObj.Sum_ValueCP;
			toEnt.Sum_ValueBat = fromObj.Sum_ValueBat;
			toEnt.Sum_ValueBatMan = fromObj.Sum_ValueBatMan;
			toEnt.SaiSo = fromObj.SaiSo;
			toEnt.PerSaiSo = fromObj.PerSaiSo;
			toEnt.IsManual = fromObj.IsManual;
		}
		public static Objvw_TotalMaterial BuildNewObjvw_TotalMaterial(vw_PvTotalMaterial entvw_TotalMaterial)
		{
			Objvw_TotalMaterial objvw_TotalMateria = new Objvw_TotalMaterial();
			vw_TotalMaterialHelper.CopyToObjvw_TotalMaterial(entvw_TotalMaterial, objvw_TotalMateria);
			return objvw_TotalMateria;
		}
		public static IList<Objvw_TotalMaterial> BuildListObjvw_TotalMateria(IList<vw_PvTotalMaterial> lstEntvw_TotalMateria)
		{
			IList<Objvw_TotalMaterial> lstObjvw_TotalMateria = new List<Objvw_TotalMaterial>();
			foreach (vw_PvTotalMaterial entvw_TotalMateria in lstEntvw_TotalMateria)
			{
				lstObjvw_TotalMateria.Add(vw_TotalMaterialHelper.BuildNewObjvw_TotalMaterial(entvw_TotalMateria));
			}
			return lstObjvw_TotalMateria;
		}
		public static vw_PvTotalMaterial BuildNewEntvw_TotalMateria(Objvw_TotalMaterial objvw_TotalMaterial)
		{
			vw_PvTotalMaterial entvw_TotalMaterial = new vw_PvTotalMaterial();
			vw_TotalMaterialHelper.CopyToEntvw_TotalMaterial(objvw_TotalMaterial, entvw_TotalMaterial);
			return entvw_TotalMaterial;
		}
		public static IList<vw_PvTotalMaterial> BuildListEntHangMuc(IList<Objvw_TotalMaterial> lstObjvw_TotalMaterial)
		{
			IList<vw_PvTotalMaterial> lstEntvw_TotalMaterial = new List<vw_PvTotalMaterial>();
			foreach (Objvw_TotalMaterial objvw_TotalMaterial in lstObjvw_TotalMaterial)
			{
				lstEntvw_TotalMaterial.Add(vw_TotalMaterialHelper.BuildNewEntvw_TotalMateria(objvw_TotalMaterial));
			}
			return lstEntvw_TotalMaterial;
		}
	}
}

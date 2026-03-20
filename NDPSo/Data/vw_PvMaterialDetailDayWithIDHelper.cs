using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    class vw_PvMaterialDetailDayWithIDHelper
    {
        public static void CopyToObjvw_MaterialDetailDayWithID(vw_PvMaterialDetailDay_WithID fromEnt, Objvw_MaterialDetailDayWithID toObj)
        {
            toObj.ID = (int)fromEnt.ID;
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
        public static void CopyToEntvw_MaterialDetailDayWithID(Objvw_MaterialDetailDayWithID fromObj, vw_PvMaterialDetailDay_WithID toEnt)
        {
            toEnt.ID = fromObj.ID;
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
        public static Objvw_MaterialDetailDayWithID BuildNewObjvw_MaterialDetailDayWithID(vw_PvMaterialDetailDay_WithID entvw_MaterialDetailDay)
        {
            Objvw_MaterialDetailDayWithID objvw_MaterialDetailDay = new Objvw_MaterialDetailDayWithID();
            vw_PvMaterialDetailDayWithIDHelper.CopyToObjvw_MaterialDetailDayWithID(entvw_MaterialDetailDay, objvw_MaterialDetailDay);
            return objvw_MaterialDetailDay;
        }
        public static IList<Objvw_MaterialDetailDayWithID> BuildListObjvw_MaterialDetailDayWithID(IList<vw_PvMaterialDetailDay_WithID> lstEntvw_MaterialDetailDay)
        {
            IList<Objvw_MaterialDetailDayWithID> lstObjvw_MaterialDetailDay = new List<Objvw_MaterialDetailDayWithID>();
            foreach (vw_PvMaterialDetailDay_WithID entvw_MaterialDetailDay in lstEntvw_MaterialDetailDay)
            {
                lstObjvw_MaterialDetailDay.Add(vw_PvMaterialDetailDayWithIDHelper.BuildNewObjvw_MaterialDetailDayWithID(entvw_MaterialDetailDay));
            }
            return lstObjvw_MaterialDetailDay;
        }
        public static vw_PvMaterialDetailDay_WithID BuildNewEntvw_MaterialDetailDayWithID(Objvw_MaterialDetailDayWithID objvw_MaterialDetailDay)
        {
            vw_PvMaterialDetailDay_WithID entvw_MaterialDetailDay = new vw_PvMaterialDetailDay_WithID();
            vw_PvMaterialDetailDayWithIDHelper.CopyToEntvw_MaterialDetailDayWithID(objvw_MaterialDetailDay, entvw_MaterialDetailDay);
            return entvw_MaterialDetailDay;
        }
        public static IList<vw_PvMaterialDetailDay_WithID> BuildListEntvw_MaterialDetailDayWithID(IList<Objvw_MaterialDetailDayWithID> lstObjvw_MaterialDetailDay)
        {
            IList<vw_PvMaterialDetailDay_WithID> lstEntvw_MaterialDetailDay = new List<vw_PvMaterialDetailDay_WithID>();
            foreach (Objvw_MaterialDetailDayWithID objvw_MaterialDetailDay in lstObjvw_MaterialDetailDay)
            {
                lstEntvw_MaterialDetailDay.Add(vw_PvMaterialDetailDayWithIDHelper.BuildNewEntvw_MaterialDetailDayWithID(objvw_MaterialDetailDay));
            }
            return lstEntvw_MaterialDetailDay;
        }
    }
}

using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    class vw_DriverDetailDayWithIDHelper
    {
        public static void CopyToObjvw_DriverDetailDayWithID(vw_PvDriverDetailDay_WithID fromEnt, Objvw_DriverDetailDayWithID toObj)
        {
            toObj.ID = (int)fromEnt.ID;
            toObj.TaiXeID = (int)fromEnt.TaiXeID;
            toObj.TenTaiXe = fromEnt.TenTaiXe;
            toObj.Total_Tranfer = fromEnt.Total_Tranfer;
            toObj.Total_KL = fromEnt.Total_KL;
            toObj.NgayMeTron = fromEnt.NgayMeTron;
            toObj.IsManual = fromEnt.IsManual;
        }
        public static void CopyToEntvw_DriverDetailDayWithID(Objvw_DriverDetailDayWithID fromObj, vw_PvDriverDetailDay_WithID toEnt)
        {
            toEnt.ID = fromObj.ID;
            toEnt.TaiXeID = fromObj.TaiXeID;
            toEnt.TenTaiXe = fromObj.TenTaiXe;
            toEnt.Total_Tranfer = fromObj.Total_Tranfer;
            toEnt.Total_KL = fromObj.Total_KL;
            toEnt.NgayMeTron = fromObj.NgayMeTron;
            toEnt.IsManual = fromObj.IsManual;
        }
        public static Objvw_DriverDetailDayWithID BuildNewObjvw_DriverDetailDayWithID(vw_PvDriverDetailDay_WithID entvw_MaterialDetailDay)
        {
            Objvw_DriverDetailDayWithID objvw_MaterialDetailDay = new Objvw_DriverDetailDayWithID();
            vw_DriverDetailDayWithIDHelper.CopyToObjvw_DriverDetailDayWithID(entvw_MaterialDetailDay, objvw_MaterialDetailDay);
            return objvw_MaterialDetailDay;
        }
        public static IList<Objvw_DriverDetailDayWithID> BuildListObjvw_DriverDetailDayWithID(IList<vw_PvDriverDetailDay_WithID> lstEntvw_MaterialDetailDay)
        {
            IList<Objvw_DriverDetailDayWithID> lstObjvw_MaterialDetailDay = new List<Objvw_DriverDetailDayWithID>();
            foreach (vw_PvDriverDetailDay_WithID entvw_MaterialDetailDay in lstEntvw_MaterialDetailDay)
            {
                lstObjvw_MaterialDetailDay.Add(vw_DriverDetailDayWithIDHelper.BuildNewObjvw_DriverDetailDayWithID(entvw_MaterialDetailDay));
            }
            return lstObjvw_MaterialDetailDay;
        }
        public static vw_PvDriverDetailDay_WithID BuildNewEntvw_DriverDetailDayWithID(Objvw_DriverDetailDayWithID objvw_MaterialDetailDay)
        {
            vw_PvDriverDetailDay_WithID entvw_MaterialDetailDay = new vw_PvDriverDetailDay_WithID();
            vw_DriverDetailDayWithIDHelper.CopyToEntvw_DriverDetailDayWithID(objvw_MaterialDetailDay, entvw_MaterialDetailDay);
            return entvw_MaterialDetailDay;
        }
        public static IList<vw_PvDriverDetailDay_WithID> BuildListEntCopyToObjvw_DriverDetailDayWithID(IList<Objvw_DriverDetailDayWithID> lstObjvw_MaterialDetailDay)
        {
            IList<vw_PvDriverDetailDay_WithID> lstEntvw_MaterialDetailDay = new List<vw_PvDriverDetailDay_WithID>();
            foreach (Objvw_DriverDetailDayWithID objvw_MaterialDetailDay in lstObjvw_MaterialDetailDay)
            {
                lstEntvw_MaterialDetailDay.Add(vw_DriverDetailDayWithIDHelper.BuildNewEntvw_DriverDetailDayWithID(objvw_MaterialDetailDay));
            }
            return lstEntvw_MaterialDetailDay;
        }
    }
}

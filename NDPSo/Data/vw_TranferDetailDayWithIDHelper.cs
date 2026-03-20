using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    class vw_TranferDetailDayWithIDHelper
    {
        public static void CopyToObjvw_TranferDetailDayWithID(vw_PvTranferDetailDay_WithID fromEnt, Objvw_TranferDetailDayWithID toObj)
        {
            toObj.ID = (int)fromEnt.ID;
            toObj.XeID = fromEnt.XeID;
            toObj.BienSo = fromEnt.BienSo;
            toObj.Total_Tranfer = fromEnt.Total_Tranfer;
            toObj.Total_KL = fromEnt.Total_KL;
            toObj.NgayMeTron = fromEnt.NgayMeTron;
            toObj.IsQueued = fromEnt.IsQueued;
        }

        public static void CopyToEntvw_TranferDetailDayWithID(Objvw_TranferDetailDayWithID fromObj, vw_PvTranferDetailDay_WithID toEnt)
        {
            toEnt.ID = fromObj.ID;
            toEnt.XeID = fromObj.XeID;
            toEnt.BienSo = fromObj.BienSo;
            toEnt.Total_Tranfer = fromObj.Total_Tranfer;
            toEnt.Total_KL = fromObj.Total_KL;
            toEnt.NgayMeTron = fromObj.NgayMeTron;
            toEnt.IsQueued = fromObj.IsQueued;

        }

        public static Objvw_TranferDetailDayWithID BuildNewObjvw_TranferDetailDayWithID(vw_PvTranferDetailDay_WithID entCongTruong)
        {
            Objvw_TranferDetailDayWithID objCongTruong = new Objvw_TranferDetailDayWithID();
            vw_TranferDetailDayWithIDHelper.CopyToObjvw_TranferDetailDayWithID(entCongTruong, objCongTruong);
            return objCongTruong;
        }

        public static IList<Objvw_TranferDetailDayWithID> BuildListObjvw_TranferDetailDayWithID(IList<vw_PvTranferDetailDay_WithID> lstEntCongTruong)
        {
            IList<Objvw_TranferDetailDayWithID> lstObjCongTruong = new List<Objvw_TranferDetailDayWithID>();
            foreach (vw_PvTranferDetailDay_WithID entCongTruong in lstEntCongTruong)
            {
                lstObjCongTruong.Add(vw_TranferDetailDayWithIDHelper.BuildNewObjvw_TranferDetailDayWithID(entCongTruong));
            }
            return lstObjCongTruong;
        }

        public static vw_PvTranferDetailDay_WithID BuildNewEntvw_TranferDetailDayWithID(Objvw_TranferDetailDayWithID objCongTruong)
        {
            vw_PvTranferDetailDay_WithID entCongTruong = new vw_PvTranferDetailDay_WithID();
            vw_TranferDetailDayWithIDHelper.CopyToEntvw_TranferDetailDayWithID(objCongTruong, entCongTruong);
            return entCongTruong;
        }

        public static IList<vw_PvTranferDetailDay_WithID> BuildListEntvw_TranferDetailDayWithID(IList<Objvw_TranferDetailDayWithID> lstObjCongTruong)
        {
            IList<vw_PvTranferDetailDay_WithID> lstEntCongTruong = new List<vw_PvTranferDetailDay_WithID>();
            foreach (Objvw_TranferDetailDayWithID objCongTruong in lstObjCongTruong)
            {
                lstEntCongTruong.Add(vw_TranferDetailDayWithIDHelper.BuildNewEntvw_TranferDetailDayWithID(objCongTruong));
            }
            return lstEntCongTruong;
        }
    }
}

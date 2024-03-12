using System;
using System.Collections.Generic;
using NDPSo.EntityModel;

namespace NDPSo.Data
{
    public class vw_TranferDetailDayHelper
    {
		public static void CopyToObjCongTruong(vw_PvTranferDetailDay fromEnt, Objvw_TranferDetailDay toObj)
		{
			toObj.XeID = fromEnt.XeID;
			toObj.BienSo = fromEnt.BienSo;
			toObj.Total_Tranfer = fromEnt.Total_Tranfer;
			toObj.Total_KL = fromEnt.Total_KL;
			toObj.NgayMeTron = fromEnt.NgayMeTron;
			toObj.IsQueued = fromEnt.IsQueued;
		}

		public static void CopyToEntCongTruong(Objvw_TranferDetailDay fromObj, vw_PvTranferDetailDay toEnt)
		{
			toEnt.XeID = fromObj.XeID;
			toEnt.BienSo = fromObj.BienSo;
			toEnt.Total_Tranfer = fromObj.Total_Tranfer;
			toEnt.Total_KL = fromObj.Total_KL;
			toEnt.NgayMeTron = fromObj.NgayMeTron;
			toEnt.IsQueued = fromObj.IsQueued;
			
		}

		public static Objvw_TranferDetailDay BuildNewObjCongTruong(vw_PvTranferDetailDay entCongTruong)
		{
			Objvw_TranferDetailDay objCongTruong = new Objvw_TranferDetailDay();
			vw_TranferDetailDayHelper.CopyToObjCongTruong(entCongTruong, objCongTruong);
			return objCongTruong;
		}

		public static IList<Objvw_TranferDetailDay> BuildListObjvw_TranferDetailDay(IList<vw_PvTranferDetailDay> lstEntCongTruong)
		{
			IList<Objvw_TranferDetailDay> lstObjCongTruong = new List<Objvw_TranferDetailDay>();
			foreach (vw_PvTranferDetailDay entCongTruong in lstEntCongTruong)
			{
				lstObjCongTruong.Add(vw_TranferDetailDayHelper.BuildNewObjCongTruong(entCongTruong));
			}
			return lstObjCongTruong;
		}

		public static vw_PvTranferDetailDay BuildNewEntvw_TranferDetailDay(Objvw_TranferDetailDay objCongTruong)
		{
			vw_PvTranferDetailDay entCongTruong = new vw_PvTranferDetailDay();
			vw_TranferDetailDayHelper.CopyToEntCongTruong(objCongTruong, entCongTruong);
			return entCongTruong;
		}

		public static IList<vw_PvTranferDetailDay> BuildListEntvw_TranferDetailDay(IList<Objvw_TranferDetailDay> lstObjCongTruong)
		{
			IList<vw_PvTranferDetailDay> lstEntCongTruong = new List<vw_PvTranferDetailDay>();
			foreach (Objvw_TranferDetailDay objCongTruong in lstObjCongTruong)
			{
				lstEntCongTruong.Add(vw_TranferDetailDayHelper.BuildNewEntvw_TranferDetailDay(objCongTruong));
			}
			return lstEntCongTruong;
		}
	}
}

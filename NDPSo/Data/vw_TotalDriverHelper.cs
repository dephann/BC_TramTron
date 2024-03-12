using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    class vw_TotalDriverHelper
    {
		public static void CopyToObjvw_TotalDriver(vw_PvTotalDriver fromEnt, Objvw_TotalDriver toObj)
		{
			toObj.TaiXeID = fromEnt.TaiXeID;
			toObj.MaTaiXe = fromEnt.MaTaiXe;
			toObj.TenTaiXe = fromEnt.TenTaiXe;
			toObj.Total_Tranfer = fromEnt.Total_Tranfer;
			toObj.Total_KL = fromEnt.Total_KL;
			toObj.IsManual = fromEnt.IsManual;
		}
		public static void CopyToEntvw_TotalDriver(Objvw_TotalDriver fromObj, vw_PvTotalDriver toEnt)
		{
			toEnt.TaiXeID = fromObj.TaiXeID;
			toEnt.MaTaiXe = fromObj.MaTaiXe;
			toEnt.TenTaiXe = fromObj.TenTaiXe;
			toEnt.Total_Tranfer = fromObj.Total_Tranfer;
			toEnt.Total_KL = fromObj.Total_KL;
			toEnt.IsManual = fromObj.IsManual;
		}
		public static Objvw_TotalDriver BuildNewObjvw_TotalDriver(vw_PvTotalDriver entvw_TotalDriver)
		{
			Objvw_TotalDriver objvw_TotalDriver = new Objvw_TotalDriver();
			vw_TotalDriverHelper.CopyToObjvw_TotalDriver(entvw_TotalDriver, objvw_TotalDriver);
			return objvw_TotalDriver;
		}
		public static IList<Objvw_TotalDriver> BuildListObjvw_TotalDriver(IList<vw_PvTotalDriver> lstEntvw_TotalDriver)
		{
			IList<Objvw_TotalDriver> lstObjvw_TotalDriver = new List<Objvw_TotalDriver>();
			foreach (vw_PvTotalDriver entvw_TotalDriver in lstEntvw_TotalDriver)
			{
				lstObjvw_TotalDriver.Add(vw_TotalDriverHelper.BuildNewObjvw_TotalDriver(entvw_TotalDriver));
			}
			return lstObjvw_TotalDriver;
		}
		public static vw_PvTotalDriver BuildNewEntvw_TotalDriver(Objvw_TotalDriver objvw_TotalDriver)
		{
			vw_PvTotalDriver entvw_TotalDriver = new vw_PvTotalDriver();
			vw_TotalDriverHelper.CopyToEntvw_TotalDriver(objvw_TotalDriver, entvw_TotalDriver);
			return entvw_TotalDriver;
		}
		public static IList<vw_PvTotalDriver> BuildListEntTotalTranfer(IList<Objvw_TotalDriver> lstObjvw_TotalDriver)
		{
			IList<vw_PvTotalDriver> lstEntvw_TotalDriver = new List<vw_PvTotalDriver>();
			foreach (Objvw_TotalDriver objvw_TotalDriver in lstObjvw_TotalDriver)
			{
				lstEntvw_TotalDriver.Add(vw_TotalDriverHelper.BuildNewEntvw_TotalDriver(objvw_TotalDriver));
			}
			return lstEntvw_TotalDriver;
		}
	}
}

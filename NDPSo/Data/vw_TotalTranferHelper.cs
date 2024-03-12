using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    class vw_TotalTranferHelper
    {
		public static void CopyToObjvw_TotalTranfer(vw_PvTotalTranfer fromEnt, Objvw_TotalTranfer toObj)
		{
			toObj.XeID = fromEnt.XeID;
			toObj.BienSo = fromEnt.BienSo;
			toObj.Total_Tranfer = fromEnt.Total_Tranfer;
			toObj.Total_KL = fromEnt.Total_KL;
			toObj.IsManual = fromEnt.IsManual;
		}
		public static void CopyToEntvw_TotalTranfer(Objvw_TotalTranfer fromObj, vw_PvTotalTranfer toEnt)
		{
			toEnt.XeID = fromObj.XeID;
			toEnt.BienSo = fromObj.BienSo;
			toEnt.Total_Tranfer = fromObj.Total_Tranfer;
			toEnt.Total_KL = fromObj.Total_KL;
			toEnt.IsManual = fromObj.IsManual;
		}
		public static Objvw_TotalTranfer BuildNewObjvw_TotalTranfer(vw_PvTotalTranfer entvw_TotalTranfer)
		{
			Objvw_TotalTranfer objvw_TotalTranfer = new Objvw_TotalTranfer();
			vw_TotalTranferHelper.CopyToObjvw_TotalTranfer(entvw_TotalTranfer, objvw_TotalTranfer);
			return objvw_TotalTranfer;
		}
		public static IList<Objvw_TotalTranfer> BuildListObjvw_TotalTranfer(IList<vw_PvTotalTranfer> lstEntvw_TotalTranfer)
		{
			IList<Objvw_TotalTranfer> lstObjvw_TotalTranfer = new List<Objvw_TotalTranfer>();
			foreach (vw_PvTotalTranfer entvw_TotalTranfer in lstEntvw_TotalTranfer)
			{
				lstObjvw_TotalTranfer.Add(vw_TotalTranferHelper.BuildNewObjvw_TotalTranfer(entvw_TotalTranfer));
			}
			return lstObjvw_TotalTranfer;
		}
		public static vw_PvTotalTranfer BuildNewEntvw_TotalTranfer(Objvw_TotalTranfer objvw_TotalTranfer)
		{
			vw_PvTotalTranfer entvw_TotalTranfer = new vw_PvTotalTranfer();
			vw_TotalTranferHelper.CopyToEntvw_TotalTranfer(objvw_TotalTranfer, entvw_TotalTranfer);
			return entvw_TotalTranfer;
		}
		public static IList<vw_PvTotalTranfer> BuildListEntTotalTranfer(IList<Objvw_TotalTranfer> lstObjvw_TotalTranfer)
		{
			IList<vw_PvTotalTranfer> lstEntvw_TotalTranfer = new List<vw_PvTotalTranfer>();
			foreach (Objvw_TotalTranfer objvw_TotalTranfer in lstObjvw_TotalTranfer)
			{
				lstEntvw_TotalTranfer.Add(vw_TotalTranferHelper.BuildNewEntvw_TotalTranfer(objvw_TotalTranfer));
			}
			return lstEntvw_TotalTranfer;
		}
	}
}

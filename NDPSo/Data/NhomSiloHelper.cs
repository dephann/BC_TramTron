using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    public class NhomSiloHelper
    {
        public static void CopyToObjNhomSilo(NhomSilo fromEnt, ObjNhomSilo toObj)
        {
            toObj.NhomSiloID = fromEnt.NhomSiloID;
            toObj.MaNhomSilo = fromEnt.MaNhomSilo;
            toObj.TenNhomSilo = fromEnt.TenNhomSilo;
            toObj.GhiChu = fromEnt.GhiChu;
            toObj.CreationDate = fromEnt.CreationDate;
            toObj.CreatedBy = fromEnt.CreatedBy;
            toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
            toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
            if (toObj.NhomSiloID <= 0)
                return;
            toObj.IsNewObject = false;
        }

        public static void CopyToEntNhomSilo(ObjNhomSilo fromObj, NhomSilo toEnt)
        {
            toEnt.NhomSiloID = fromObj.NhomSiloID;
            toEnt.MaNhomSilo = fromObj.MaNhomSilo;
            toEnt.TenNhomSilo = fromObj.TenNhomSilo;
            toEnt.GhiChu = fromObj.GhiChu;
            toEnt.CreationDate = fromObj.CreationDate;
            toEnt.CreatedBy = fromObj.CreatedBy;
            toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
            toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
        }

        public static ObjNhomSilo BuildNewObjNhomSilo(NhomSilo entNhomSilo)
        {
            ObjNhomSilo toObj = new ObjNhomSilo();
            NhomSiloHelper.CopyToObjNhomSilo(entNhomSilo, toObj);
            return toObj;
        }

        public static IList<ObjNhomSilo> BuildListObjNhomSilo(IList<NhomSilo> lstEntNhomSilo)
        {
            IList<ObjNhomSilo> objNhomSiloList = (IList<ObjNhomSilo>)new List<ObjNhomSilo>();
            foreach (NhomSilo entNhomSilo in (IEnumerable<NhomSilo>)lstEntNhomSilo)
                objNhomSiloList.Add(NhomSiloHelper.BuildNewObjNhomSilo(entNhomSilo));
            return objNhomSiloList;
        }

        public static NhomSilo BuildNewEntNhomSilo(ObjNhomSilo objNhomSilo)
        {
            NhomSilo toEnt = new NhomSilo();
            NhomSiloHelper.CopyToEntNhomSilo(objNhomSilo, toEnt);
            return toEnt;
        }

        public static IList<NhomSilo> BuildListEntNhomSilo(IList<ObjNhomSilo> lstObjNhomSilo)
        {
            IList<NhomSilo> nhomSiloList = (IList<NhomSilo>)new List<NhomSilo>();
            foreach (ObjNhomSilo objNhomSilo in (IEnumerable<ObjNhomSilo>)lstObjNhomSilo)
                nhomSiloList.Add(NhomSiloHelper.BuildNewEntNhomSilo(objNhomSilo));
            return nhomSiloList;
        }
    }
}

using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    public class MeTronHelper
    {
        public static void CopyToObjMeTron(MeTron fromEnt, ObjMeTron toObj)
        {
            toObj.MeTronID = fromEnt.MeTronID;
            toObj.LnNo = fromEnt.LnNo;
            toObj.NgayMeTron = fromEnt.NgayMeTron;
            toObj.KhoiLuong = fromEnt.KhoiLuong;
            toObj.PhieuTronID = fromEnt.PhieuTronID;
            toObj.MoTa = fromEnt.MoTa;
            toObj.Status = fromEnt.Status;
            toObj.IsManual = fromEnt.IsManual;
            toObj.IsDeleted = fromEnt.IsDeleted;
            toObj.DeletedBy = fromEnt.DeletedBy;
            toObj.DeleteReason = fromEnt.DeleteReason;
            toObj.CreationDate = fromEnt.CreationDate;
            toObj.CreatedBy = fromEnt.CreatedBy;
            toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
            toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
            toObj.NPPhieuTronMaPhieuTron = fromEnt.PhieuTron.MaPhieuTron;
            if (toObj.MeTronID <= 0)
                return;
            toObj.IsNewObject = false;
        }

        public static void CopyToEntMeTron(ObjMeTron fromObj, MeTron toEnt)
        {
            toEnt.MeTronID = fromObj.MeTronID;
            toEnt.LnNo = fromObj.LnNo;
            toEnt.NgayMeTron = fromObj.NgayMeTron;
            toEnt.KhoiLuong = fromObj.KhoiLuong;
            toEnt.PhieuTronID = fromObj.PhieuTronID;
            toEnt.MoTa = fromObj.MoTa;
            toEnt.Status = fromObj.Status;
            toEnt.IsManual = fromObj.IsManual;
            toEnt.IsDeleted = fromObj.IsDeleted;
            toEnt.DeletedBy = fromObj.DeletedBy;
            toEnt.DeleteReason = fromObj.DeleteReason;
            toEnt.CreationDate = fromObj.CreationDate;
            toEnt.CreatedBy = fromObj.CreatedBy;
            toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
            toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
        }

        public static ObjMeTron BuildNewObjMeTron(MeTron entMeTron)
        {
            ObjMeTron toObj = new ObjMeTron();
            MeTronHelper.CopyToObjMeTron(entMeTron, toObj);
            return toObj;
        }

        public static IList<ObjMeTron> BuildListObjMeTron(IList<MeTron> lstEntMeTron)
        {
            IList<ObjMeTron> objMeTronList = (IList<ObjMeTron>)new List<ObjMeTron>();
            foreach (MeTron entMeTron in (IEnumerable<MeTron>)lstEntMeTron)
                objMeTronList.Add(MeTronHelper.BuildNewObjMeTron(entMeTron));
            return objMeTronList;
        }

        public static MeTron BuildNewEntMeTron(ObjMeTron objMeTron)
        {
            MeTron toEnt = new MeTron();
            MeTronHelper.CopyToEntMeTron(objMeTron, toEnt);
            return toEnt;
        }

        public static IList<MeTron> BuildListEntMeTron(IList<ObjMeTron> lstObjMeTron)
        {
            IList<MeTron> meTronList = (IList<MeTron>)new List<MeTron>();
            foreach (ObjMeTron objMeTron in (IEnumerable<ObjMeTron>)lstObjMeTron)
                meTronList.Add(MeTronHelper.BuildNewEntMeTron(objMeTron));
            return meTronList;
        }
    }
}

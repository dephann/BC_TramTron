using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    public class MACHelper
    {
        public static string GenMemberValues(ObjMAC obj) => string.Empty + "#1@#MACID#2@#" + (object)obj.MACID + "#1@#MaMAC#2@#" + obj.MaMAC + "#1@#TenMAC#2@#" + obj.TenMAC + "#1@#GhiChu#2@#" + obj.GhiChu + "#1@#DoSut#2@#" + obj.DoSut + "#1@#ThemBotNuoc1#2@#" + (object)obj.ThemBotNuoc1 + "#1@#ThemBotNuoc2#2@#" + (object)obj.ThemBotNuoc2 + "#1@#Activated#2@#" + obj.Activated.ToString() + "#1@#CreationDate#2@#" + (object)obj.CreationDate + "#1@#CreatedBy#2@#" + (object)obj.CreatedBy + "#1@#LatestUpdateDate#2@#" + (object)obj.LatestUpdateDate + "#1@#LatestUpdatedBy#2@#" + (object)obj.LatestUpdatedBy + "#1@#VersionNo#2@#" + (object)obj.VersionNo;

        public static string GenMemberValues(MAC ent)
        {
            string r = string.Empty;
            r = r + "#1@#MACID#2@#" + ent.MACID;
            r = r + "#1@#MaMAC#2@#" + ent.MaMAC;
            r = r + "#1@#TenMAC#2@#" + ent.TenMAC;
            r = r + "#1@#GhiChu#2@#" + ent.GhiChu;
            r = r + "#1@#DoSut#2@#" + ent.DoSut;
            r = r + "#1@#ThemBotNuoc1#2@#" + ent.ThemBotNuoc1;
            r = r + "#1@#ThemBotNuoc2#2@#" + ent.ThemBotNuoc2;
            r = r + "#1@#Activated#2@#" + ent.Activated.ToString();
            r = r + "#1@#CreationDate#2@#" + ent.CreationDate;
            r = r + "#1@#CreatedBy#2@#" + ent.CreatedBy;
            r = r + "#1@#LatestUpdateDate#2@#" + ent.LatestUpdateDate;
            r = r + "#1@#LatestUpdatedBy#2@#" + ent.LatestUpdatedBy;
            return r + "#1@#VersionNo#2@#" + ent.VersionNo;
        }
        public static void CopyToObjMAC(MAC fromEnt, ObjMAC toObj)
        {
            toObj.MACID = fromEnt.MACID;
            toObj.MaMAC = fromEnt.MaMAC;
            toObj.TenMAC = fromEnt.TenMAC;
            toObj.GhiChu = fromEnt.GhiChu;
            toObj.DoSut = fromEnt.DoSut;
            toObj.ThemBotNuoc1 = fromEnt.ThemBotNuoc1;
            toObj.ThemBotNuoc2 = fromEnt.ThemBotNuoc2;
            toObj.Activated = fromEnt.Activated;
            toObj.CreationDate = fromEnt.CreationDate;
            toObj.CreatedBy = fromEnt.CreatedBy;
            toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
            toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
            toObj.VersionNo = fromEnt.VersionNo;
            if (toObj.MACID <= 0)
                return;
            toObj.IsNewObject = false;
        }

        public static void CopyToEntMAC(ObjMAC fromObj, MAC toEnt)
        {
            toEnt.MACID = fromObj.MACID;
            toEnt.MaMAC = fromObj.MaMAC;
            toEnt.TenMAC = fromObj.TenMAC;
            toEnt.GhiChu = fromObj.GhiChu;
            toEnt.DoSut = fromObj.DoSut;
            toEnt.ThemBotNuoc1 = fromObj.ThemBotNuoc1;
            toEnt.ThemBotNuoc2 = fromObj.ThemBotNuoc2;
            toEnt.Activated = fromObj.Activated;
            toEnt.CreationDate = fromObj.CreationDate;
            toEnt.CreatedBy = fromObj.CreatedBy;
            toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
            toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
            toEnt.VersionNo = fromObj.VersionNo;
        }

        public static ObjMAC BuildNewObjMAC(MAC entMAC)
        {
            ObjMAC toObj = new ObjMAC();
            MACHelper.CopyToObjMAC(entMAC, toObj);
            return toObj;
        }

        public static IList<ObjMAC> BuildListObjMAC(IList<MAC> lstEntMAC)
        {
            IList<ObjMAC> objMacList = (IList<ObjMAC>)new List<ObjMAC>();
            foreach (MAC entMAC in (IEnumerable<MAC>)lstEntMAC)
                objMacList.Add(MACHelper.BuildNewObjMAC(entMAC));
            return objMacList;
        }

        public static MAC BuildNewEntMAC(ObjMAC objMAC)
        {
            MAC toEnt = new MAC();
            MACHelper.CopyToEntMAC(objMAC, toEnt);
            return toEnt;
        }

        public static IList<MAC> BuildListEntMAC(IList<ObjMAC> lstObjMAC)
        {
            IList<MAC> macList = (IList<MAC>)new List<MAC>();
            foreach (ObjMAC objMAC in (IEnumerable<ObjMAC>)lstObjMAC)
                macList.Add(MACHelper.BuildNewEntMAC(objMAC));
            return macList;
        }
    }
}

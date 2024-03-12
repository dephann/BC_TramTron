using NDPSo.EntityModel;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    public class MaterialHelper
    {
        public static void CopyToObjMaterial(Material fromEnt, ObjMaterial toObj)
        {
            toObj.MaterialID = fromEnt.MaterialID;
            toObj.MaterialCode = fromEnt.MaterialCode;
            toObj.MaterialName = fromEnt.MaterialName;
            toObj.Supplier = fromEnt.Supplier;
            toObj.Unit = fromEnt.Unit;
            toObj.Price = fromEnt.Price;
            toObj.Description = fromEnt.Description;
            toObj.Activated = fromEnt.Activated;
            toObj.VersionNo = fromEnt.VersionNo;
            toObj.CreationDate = fromEnt.CreationDate;
            toObj.CreatedBy = fromEnt.CreatedBy;
            toObj.LatestUpdateDate = fromEnt.LatestUpdateDate;
            toObj.LatestUpdatedBy = fromEnt.LatestUpdatedBy;
            if (toObj.MaterialID <= 0)
                return;
            toObj.IsNewObject = false;
            if(fromEnt.Unit != null)
            {

                for(int i = 0; i < Converter.EnumToListFieldCode<Enums.Unit>(true).Count; i++)
                {
                    if(Converter.EnumToListFieldCode<Enums.Unit>(true)[i].ID == (int)fromEnt.Unit)
                    {
                        toObj.UnitName = Converter.EnumToListFieldCode<Enums.Unit>(true)[i].Code;
                    }
                }
            }
        }

        public static void CopyToEntMaterial(ObjMaterial fromObj, Material toEnt)
        {
            toEnt.MaterialID = fromObj.MaterialID;
            toEnt.MaterialCode = fromObj.MaterialCode;
            toEnt.MaterialName = fromObj.MaterialName;
            toEnt.Supplier = fromObj.Supplier;
            toEnt.Unit = fromObj.Unit;
            toEnt.Price = fromObj.Price;
            toEnt.Description = fromObj.Description;
            toEnt.Activated = fromObj.Activated;
            toEnt.VersionNo = fromObj.VersionNo;
            toEnt.CreationDate = fromObj.CreationDate;
            toEnt.CreatedBy = fromObj.CreatedBy;
            toEnt.LatestUpdateDate = fromObj.LatestUpdateDate;
            toEnt.LatestUpdatedBy = fromObj.LatestUpdatedBy;
        }

        public static ObjMaterial BuildNewObjMaterial(Material entMaterial)
        {
            ObjMaterial toObj = new ObjMaterial();
            MaterialHelper.CopyToObjMaterial(entMaterial, toObj);
            return toObj;
        }

        public static IList<ObjMaterial> BuildListObjMaterial(IList<Material> lstEntMaterial)
        {
            IList<ObjMaterial> objMaterialList = (IList<ObjMaterial>)new List<ObjMaterial>();
            foreach (Material entMaterial in (IEnumerable<Material>)lstEntMaterial)
                objMaterialList.Add(MaterialHelper.BuildNewObjMaterial(entMaterial));
            return objMaterialList;
        }

        public static Material BuildNewEntMaterial(ObjMaterial objMaterial)
        {
            Material toEnt = new Material();
            MaterialHelper.CopyToEntMaterial(objMaterial, toEnt);
            return toEnt;
        }

        public static IList<Material> BuildListEntMaterial(IList<ObjMaterial> lstObjMaterial)
        {
            IList<Material> materialList = (IList<Material>)new List<Material>();
            foreach (ObjMaterial objMaterial in (IEnumerable<ObjMaterial>)lstObjMaterial)
                materialList.Add(MaterialHelper.BuildNewEntMaterial(objMaterial));
            return materialList;
        }
    }
}

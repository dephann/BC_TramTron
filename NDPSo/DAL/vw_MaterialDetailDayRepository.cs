using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Wordprocessing;
using NDPSo.Core;
using NDPSo.Data;
using NDPSo.EntityModel;
using NDPSo.KWS;
using NDPSo.Utils;

namespace NDPSo.DAL
{
    class vw_MaterialDetailDayRepository : EFRepository<vw_PvMaterialDetailDay_WithID>, Ivw_MaterialDetailDayRepository, IEFRepository<vw_PvMaterialDetailDay_WithID>
    {
        public vw_MaterialDetailDayRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            base.KeyProperty = base.GetKeyColumnName(new vw_PvMaterialDetailDay_WithID(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
        }

        public IList<vw_PvMaterialDetailDay_WithID> ListvwMaterialDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? MaterialID, bool? isManual)
        {
            Specification<vw_PvMaterialDetailDay_WithID> spec = new Specification<vw_PvMaterialDetailDay_WithID>((vw_PvMaterialDetailDay_WithID o) => (o.MaterialID == MaterialID || MaterialID == null) && (o.NgayMeTron >= fromDate || fromDate == (DateTime?)DateTime.MinValue) && (o.NgayMeTron <= toDate || toDate == (DateTime?)DateTime.MinValue) && ((bool?)o.IsManual == isManual || isManual == null));
            return (IList<vw_PvMaterialDetailDay_WithID>)base.GetAll();
            //return base.SelectAll(spec);
        }

        IList<vw_PvMaterialDetailDay_WithID> Ivw_MaterialDetailDayRepository.ListvwMaterialDetailDay_ByCondition_Update(DateTime? fromDate, DateTime? toDate, int? MaterialID, bool? isManual)
        {
            /*List<vw_PvMaterialDetailDay_WithID> lst = new List<vw_PvMaterialDetailDay_WithID> ();   
            Specification<vw_PvMaterialDetailDay_WithID> spec;
            spec = new Specification<vw_PvMaterialDetailDay_WithID>(o =>
                 (o.ID == MaterialID));
            var data = base.SelectAll(spec);
            foreach (vw_PvMaterialDetailDay_WithID obj in data)
            {
                lst.Add(obj);
            }

            return lst;*/
            Specification<vw_PvMaterialDetailDay_WithID> spec = new Specification<vw_PvMaterialDetailDay_WithID>((vw_PvMaterialDetailDay_WithID o) => (o.ID == MaterialID || MaterialID == null) );
            return base.SelectAll(spec);
        }
    }
}

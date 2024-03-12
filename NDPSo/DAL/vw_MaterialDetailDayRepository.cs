using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;

namespace NDPSo.DAL
{
    class vw_MaterialDetailDayRepository : EFRepository<vw_PvMaterialDetailDay>, Ivw_MaterialDetailDayRepository, IEFRepository<vw_PvMaterialDetailDay>
    {
        public vw_MaterialDetailDayRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            base.KeyProperty = base.GetKeyColumnName(new vw_PvMaterialDetailDay(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
        }

        public IList<vw_PvMaterialDetailDay> ListvwMaterialDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? MaterialID, bool? isManual)
        {
            Specification<vw_PvMaterialDetailDay> spec = new Specification<vw_PvMaterialDetailDay>((vw_PvMaterialDetailDay o) => (o.MaterialID == MaterialID || MaterialID == null) && (o.NgayMeTron >= fromDate || fromDate == (DateTime?)DateTime.MinValue) && (o.NgayMeTron <= toDate || toDate == (DateTime?)DateTime.MinValue) && ((bool?)o.IsManual == isManual || isManual == null));
            return base.SelectAll(spec);
        }
    }
}

using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;

namespace NDPSo.DAL
{
    class vw_TotalMaterialRepository : EFRepository<vw_PvTotalMaterial>, Ivw_TotalMaterialRepository, IEFRepository<vw_PvTotalMaterial>
    {
        public vw_TotalMaterialRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            base.KeyProperty = base.GetKeyColumnName(new vw_PvTotalMaterial(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
        }

        public IList<vw_PvTotalMaterial> ListvwTotalMaterial_ByCondition(int? MaterialID, bool? isManual)
        {
            Specification<vw_PvTotalMaterial> spec = new Specification<vw_PvTotalMaterial>((vw_PvTotalMaterial o) => (o.MaterialID == MaterialID || MaterialID == null) && ((bool?)o.IsManual == isManual || isManual == null));
            return base.SelectAll(spec);
        }
    }
}

using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;

namespace NDPSo.DAL
{
    class vw_TotalDriverRepository : EFRepository<vw_PvTotalDriver>, Ivw_TotalDriverRepository, IEFRepository<vw_PvTotalDriver>
    {
        public vw_TotalDriverRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            //base.KeyProperty = base.GetKeyColumnName(new vw_PvTotalTranfer(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
            base.KeyProperty = "TaiXeID";
        }

        public IList<vw_PvTotalDriver> ListvwTotalDriver_ByCondition(int? taixeID, bool? isManual)
        {
            Specification<vw_PvTotalDriver> spec = new Specification<vw_PvTotalDriver>((vw_PvTotalDriver o) => (o.TaiXeID == taixeID || taixeID == null) && ((bool?)o.IsManual == isManual || isManual == null));
            return base.SelectAll(spec);
        }
    }
}
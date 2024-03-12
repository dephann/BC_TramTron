using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;

namespace NDPSo.DAL
{
    class vw_TotalTranferRepository : EFRepository<vw_PvTotalTranfer>, Ivw_TotalTranferRepository, IEFRepository<vw_PvTotalTranfer>
    {
        public vw_TotalTranferRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            //base.KeyProperty = base.GetKeyColumnName(new vw_PvTotalTranfer(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
            base.KeyProperty = "XeID";
        }

        public IList<vw_PvTotalTranfer> ListvwTotalTranfer_ByCondition(int? xeID, bool? isManual)
        {
            Specification<vw_PvTotalTranfer> spec = new Specification<vw_PvTotalTranfer>((vw_PvTotalTranfer o) => (o.XeID == xeID || xeID == null) && ((bool?)o.IsManual == isManual || isManual == null));
            return base.SelectAll(spec);
        }
    }
}
    
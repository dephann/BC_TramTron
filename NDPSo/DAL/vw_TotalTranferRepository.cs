using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;

namespace NDPSo.DAL
{
    class vw_TotalTranferRepository : EFRepository<vw_PvTranferDetailDay_WithID>, Ivw_TotalTranferRepository, IEFRepository<vw_PvTranferDetailDay_WithID>
    {
        public vw_TotalTranferRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            //base.KeyProperty = base.GetKeyColumnName(new vw_PvTotalTranfer(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
            base.KeyProperty = "XeID";
        }

        public IList<vw_PvTranferDetailDay_WithID> ListvwTotalTranfer_ByCondition(int? xeID, bool? isManual)
        {
            Specification<vw_PvTranferDetailDay_WithID> spec = new Specification<vw_PvTranferDetailDay_WithID>((vw_PvTranferDetailDay_WithID o) => (o.XeID == xeID || xeID == null));
            return base.SelectAll(spec);
        }
    }
}
    
using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;

namespace NDPSo.DAL
{
    class vw_TotalDriverRepository : EFRepository<vw_PvDriverDetailDay_WithID>, Ivw_TotalDriverRepository, IEFRepository<vw_PvDriverDetailDay_WithID>
    {
        public vw_TotalDriverRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            //base.KeyProperty = base.GetKeyColumnName(new vw_PvTotalTranfer(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
            base.KeyProperty = "TaiXeID";
        }

        public IList<vw_PvDriverDetailDay_WithID> ListvwTotalDriver_ByCondition(int? taixeID, bool? isManual)
        {
            return (IList<vw_PvDriverDetailDay_WithID>)base.GetAll();
        }
    }
}
using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
    class vw_DriverDetailDayRepository : EFRepository<vw_PvDriverDetailDay_WithID>, Ivw_DriverDetailDayRepository, IEFRepository<vw_PvDriverDetailDay_WithID>
    {
        public vw_DriverDetailDayRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            base.KeyProperty = base.GetKeyColumnName(new vw_PvDriverDetailDay_WithID(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
        }
        public IList<vw_PvDriverDetailDay_WithID> ListDriverDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? taiXeID, bool? isManual)
        {
            Specification<vw_PvDriverDetailDay_WithID> spec = new Specification<vw_PvDriverDetailDay_WithID>((vw_PvDriverDetailDay_WithID o) => (o.ID == taiXeID || taiXeID == null) && ((bool?)o.IsManual == isManual || isManual == null));
            return (IList<vw_PvDriverDetailDay_WithID>)base.GetAll();
        }

        public IList<vw_PvDriverDetailDay_WithID> ListDriverDetailDay_ByCondition_Update(DateTime? fromDate, DateTime? toDate, int? taiXeID, bool? isManual)
        {
            Specification<vw_PvDriverDetailDay_WithID> spec = new Specification<vw_PvDriverDetailDay_WithID>((vw_PvDriverDetailDay_WithID o) => (o.ID == taiXeID || taiXeID == null));
            return base.SelectAll(spec);
        }
    }
}

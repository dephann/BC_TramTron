using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;

namespace NDPSo.DAL
{
    public class vw_TranferDetailDayRepository : EFRepository<vw_PvTranferDetailDay>, Ivw_TranferDetailDayRepository, IEFRepository<vw_PvTranferDetailDay>
    {
        public vw_TranferDetailDayRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            //base.KeyProperty = base.GetKeyColumnName(new vw_PvTranferDetailDay(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
            base.KeyProperty = "NgayMeTron_BienSo";
        }
        public IList<vw_PvTranferDetailDay> ListTranferDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? xeID, bool? isQueued)
        {
             /*Specification<vw_PvTranferDetailDay> spec = new Specification<vw_PvTranferDetailDay>((vw_PvTranferDetailDay o) =>
             (o.XeID == xeID || xeID == null) &&
             (o.NgayMeTron >= (DateTime?)fromDate) && (o.NgayMeTron <= (DateTime?)toDate) &&
             ((bool?)o.IsQueued == isQueued || isQueued == new bool?()));
             return base.SelectAll(spec);*/
            var query = GetAll();

            
            /*if (xeID.HasValue)
            {
                query = query.Where(c => c.XeID == xeID);
            }

            *//*if (fromDate.HasValue)
            {
                var fromDateValue = fromDate.Value.Date;
                query = query.Where(c => c.NgayMeTron >= fromDateValue);
            }

            if (toDate.HasValue)
            {
                var toDateValue = toDate.Value.Date.AddDays(1); // Bổ sung một ngày để bao gồm cả ngày kết thúc
                query = query.Where(c => c.NgayMeTron < toDateValue);
            }*//*

            if (isQueued.HasValue)
            {
                query = query.Where(c => c.IsQueued == isQueued);
            }*/
            /*query.Where(c => c.NgayMeTron >= fromDatex && c.NgayMeTron <= toDatex)
            .ToList();*/

            return query.ToList();


        }
    }
}

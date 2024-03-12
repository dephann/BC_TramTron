using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;

namespace NDPSo.DAL
{
    public class CongTruongRepository : EFRepository<CongTruong>, ICongTruongRepository, IEFRepository<CongTruong>
    {
        public CongTruongRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            base.KeyProperty = base.GetKeyColumnName(new CongTruong(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
        }

        public IList<CongTruong> ListCongTruong_ByCondition(DateTime? fromDate, DateTime? toDate, string maCT, string tenCT, string diaChi, string phone, bool? active)
        {
            var query = GetAll();
            if (!string.IsNullOrEmpty(maCT))
                query = query.Where(c => c.MaCongTruong.Contains(maCT));
            if (!string.IsNullOrEmpty(tenCT))
                query = query.Where(c => c.TenCongTruong.Contains(tenCT));
            if (!string.IsNullOrEmpty(diaChi))
                query = query.Where(c => c.DiaChi.Contains(diaChi));
            if (!string.IsNullOrEmpty(phone))
                query = query.Where(c => c.Phone.Contains(phone));
            if (fromDate.HasValue)
                query = query.Where(c => c.CreationDate >= fromDate);
            if (toDate.HasValue)
                query = query.Where(c => c.CreationDate <= toDate);
            if (active.HasValue)
                query = query.Where(c => c.Activated == active.Value);

            return query.ToList();
        }
    }
}

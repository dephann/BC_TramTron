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
    class HangMucRepository : EFRepository<HangMuc>, IHangMucRepository, IEFRepository<HangMuc>
	{
		public HangMucRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new HangMuc(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public IList<HangMuc> ListHangMuc_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, bool? active)
		{
			Specification<HangMuc> spec = new Specification<HangMuc>((HangMuc o) => (o.MaHangMuc.Contains(maKH) || maKH.Trim() == string.Empty) && (o.TenHangMuc.Contains(tenKH) || tenKH.Trim() == string.Empty) && (o.CreationDate >= fromDate || fromDate == (DateTime?)DateTime.MinValue) && (o.CreationDate <= toDate || toDate == (DateTime?)DateTime.MinValue) && ((bool?)o.Activated == active || active == null));
			return base.SelectAll(spec);
		}
	}
}

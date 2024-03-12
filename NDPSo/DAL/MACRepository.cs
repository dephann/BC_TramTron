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
	public class MACRepository : EFRepository<MAC>, IMACRepository, IEFRepository<MAC>
	{
		public MACRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new MAC(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public IList<MAC> ListMAC_ByCondition(DateTime? fromDate, DateTime? toDate, string maMAC, string tenMAC, bool? active)
		{
			Specification<MAC> spec = new Specification<MAC>((MAC o) => (o.MaMAC.Contains(maMAC) || maMAC.Trim() == string.Empty) && (o.TenMAC.Contains(tenMAC) || tenMAC.Trim() == string.Empty) && (o.CreationDate >= fromDate || fromDate == (DateTime?)DateTime.MinValue) && (o.CreationDate <= toDate || toDate == (DateTime?)DateTime.MinValue) && ((bool?)o.Activated == active || active == null));
			return base.SelectAll(spec);
		}
	}
}
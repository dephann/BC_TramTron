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
	public class XeRepository : EFRepository<Xe>, IXeRepository, IEFRepository<Xe>
	{
		public XeRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new Xe(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public IList<Xe> ListXe_ByCondition(DateTime? fromDate, DateTime? toDate, string bienSo, bool? active)
		{
			Specification<Xe> spec = new Specification<Xe>((Xe o) => (o.BienSo.Contains(bienSo) || bienSo.Trim() == string.Empty) && (o.CreationDate >= fromDate || fromDate == (DateTime?)DateTime.MinValue) && (o.CreationDate <= toDate || toDate == (DateTime?)DateTime.MinValue) && ((bool?)o.Activated == active || active == null));
			return base.SelectAll(spec);
		}
	}
}
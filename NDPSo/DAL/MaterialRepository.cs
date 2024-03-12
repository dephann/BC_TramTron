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
	public class MaterialRepository : EFRepository<Material>, IMaterialRepository, IEFRepository<Material>
	{
		public MaterialRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new Material(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public IList<Material> ListMaterial_ByCondition(DateTime? fromDate, DateTime? toDate, string maVT, string tenVT, bool? active)
		{
			Specification<Material> spec = new Specification<Material>((Material o) => (o.MaterialCode.Contains(maVT) || maVT.Trim() == string.Empty) && (o.MaterialName.Contains(tenVT) || tenVT.Trim() == string.Empty) && (o.CreationDate >= fromDate || fromDate == (DateTime?)DateTime.MinValue) && (o.CreationDate <= toDate || toDate == (DateTime?)DateTime.MinValue) && ((bool?)o.Activated == active || active == null));
			return base.SelectAll(spec);
		}
	}
}

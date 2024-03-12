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
	public class MACSiloRepository : EFRepository<MACSilo>, IMACSiloRepository, IEFRepository<MACSilo>
	{
		public MACSiloRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new MACSilo(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public IList<MACSilo> ListMACSilo_ByMACID(int macID)
		{
			Specification<MACSilo> spec = new Specification<MACSilo>((MACSilo ms) => ms.MACID.Equals(macID));
			return base.SelectAll(spec);
		}
	}
}
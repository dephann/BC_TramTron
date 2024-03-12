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
	public class WeighRepository : EFRepository<Weigh>, IWeighRepository, IEFRepository<Weigh>
	{
		public WeighRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new Weigh(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}
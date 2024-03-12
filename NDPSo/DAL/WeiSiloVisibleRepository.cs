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
	public class WeiSiloVisibleRepository : EFRepository<WeiSiloVisible>, IWeiSiloVisibleRepository, IEFRepository<WeiSiloVisible>
	{
		public WeiSiloVisibleRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new WeiSiloVisible(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}

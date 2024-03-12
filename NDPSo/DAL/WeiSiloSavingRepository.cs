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
	public class WeiSiloSavingRepository : EFRepository<WeiSiloSaving>, IWeiSiloSavingRepository, IEFRepository<WeiSiloSaving>
	{
		public WeiSiloSavingRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new WeiSiloSaving(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}
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
	public class PCInputRepository : EFRepository<PCInput>, IPCInputRepository, IEFRepository<PCInput>
	{
		public PCInputRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName( new PCInput(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}

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
	public class PCOutputRepository : EFRepository<PCOutput>, IPCOutputRepository, IEFRepository<PCOutput>
	{
		public PCOutputRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName( new PCOutput(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}
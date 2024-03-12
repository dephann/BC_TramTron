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
	public class SEC_AssemblyRepository : EFRepository<SEC_Assembly>, ISEC_AssemblyRepository, IEFRepository<SEC_Assembly>
	{
		public SEC_AssemblyRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName( new SEC_Assembly(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}


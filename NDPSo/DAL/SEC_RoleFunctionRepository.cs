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
	public class SEC_RoleFunctionRepository : EFRepository<SEC_RoleFunction>, ISEC_RoleFunctionRepository, IEFRepository<SEC_RoleFunction>
	{
		public SEC_RoleFunctionRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new SEC_RoleFunction(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}
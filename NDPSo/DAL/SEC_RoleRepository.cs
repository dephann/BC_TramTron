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
	public class SEC_RoleRepository : EFRepository<SEC_Role>, ISEC_RoleRepository, IEFRepository<SEC_Role>
	{
		public SEC_RoleRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName( new SEC_Role(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}
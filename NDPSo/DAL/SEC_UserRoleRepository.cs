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
	public class SEC_UserRoleRepository : EFRepository<SEC_UserRole>, ISEC_UserRoleRepository, IEFRepository<SEC_UserRole>
	{
		public SEC_UserRoleRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName( new SEC_UserRole(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}
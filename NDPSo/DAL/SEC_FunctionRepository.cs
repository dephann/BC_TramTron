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
	public class SEC_FunctionRepository : EFRepository<SEC_Function>, ISEC_FunctionRepository, IEFRepository<SEC_Function>
	{
		public SEC_FunctionRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName( new SEC_Function(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public IList<SEC_Function> ListSEC_Function_ByFunctionType(int funcType)
		{
			Specification<SEC_Function> spec = new Specification<SEC_Function>((SEC_Function f) => f.FunctionType == (int?)funcType);
			return base.SelectAll(spec);
		}

		public IList<SEC_Function> ListSEC_Function_ByUserID(int userID)
		{
			Specification<SEC_Function> spec = new Specification<SEC_Function>((SEC_Function f) => f.SEC_RoleFunction.Any((SEC_RoleFunction rf) => rf.SEC_Role.SEC_UserRole.Any((SEC_UserRole ur) => ur.UserID == userID)));
			return base.SelectAll(spec);
		}
	}
}

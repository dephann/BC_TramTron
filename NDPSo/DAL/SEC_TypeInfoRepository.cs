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
	public class SEC_TypeInfoRepository : EFRepository<SEC_TypeInfo>, ISEC_TypeInfoRepository, IEFRepository<SEC_TypeInfo>
	{
		public SEC_TypeInfoRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new SEC_TypeInfo(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}
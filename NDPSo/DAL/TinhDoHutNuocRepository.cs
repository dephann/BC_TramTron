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
	public class TinhDoHutNuocRepository : EFRepository<TinhDoHutNuoc>, ITinhDoHutNuocRepository, IEFRepository<TinhDoHutNuoc>
	{
		public TinhDoHutNuocRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new TinhDoHutNuoc(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}
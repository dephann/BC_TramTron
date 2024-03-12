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
	public class TinhDoHutNuocChiTietRepository : EFRepository<TinhDoHutNuocChiTiet>, ITinhDoHutNuocChiTietRepository, IEFRepository<TinhDoHutNuocChiTiet>
	{
		public TinhDoHutNuocChiTietRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new TinhDoHutNuocChiTiet(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}

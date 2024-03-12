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
	public class NhomSiloRepository : EFRepository<NhomSilo>, INhomSiloRepository, IEFRepository<NhomSilo>
	{
		public NhomSiloRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName( new NhomSilo(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}
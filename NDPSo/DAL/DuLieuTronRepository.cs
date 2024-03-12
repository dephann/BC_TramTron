using System;
using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;

namespace NDPSo.DAL
{
	public class DuLieuTronRepository : EFRepository<DuLieuTron>, IDuLieuTronRepository, IEFRepository<DuLieuTron>
	{
		public DuLieuTronRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new DuLieuTron(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
	}
}

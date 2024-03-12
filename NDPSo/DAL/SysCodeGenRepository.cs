using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public class SysCodeGenRepository : EFRepository<SysCodeGen>, ISysCodeGenRepository, IEFRepository<SysCodeGen>
	{
		public SysCodeGenRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new SysCodeGen(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public SysCodeGen GetSysCodeGen_ByTblName(string strTblName)
		{
			return this.DoQuery((ISpecification<SysCodeGen>)new Specification<SysCodeGen>((Expression<Func<SysCodeGen, bool>>)(cg => cg.TableName == strTblName))).FirstOrDefault<SysCodeGen>();

		}
	}
}

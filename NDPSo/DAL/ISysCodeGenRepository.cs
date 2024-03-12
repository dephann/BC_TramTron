using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public interface ISysCodeGenRepository : IEFRepository<SysCodeGen>
	{
		SysCodeGen GetSysCodeGen_ByTblName(string strTblName);
	}
}

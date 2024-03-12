using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public interface IXeRepository : IEFRepository<Xe>
	{
		IList<Xe> ListXe_ByCondition(DateTime? fromDate, DateTime? toDate, string bienSo, bool? active);
	}
}


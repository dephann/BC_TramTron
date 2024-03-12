using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public interface ITaiXeRepository : IEFRepository<TaiXe>
	{
		IList<TaiXe> ListTaiXe_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string phone, bool? active);
	}
}
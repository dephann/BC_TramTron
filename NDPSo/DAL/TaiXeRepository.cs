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
	public class TaiXeRepository : EFRepository<TaiXe>, ITaiXeRepository, IEFRepository<TaiXe>
	{
		public TaiXeRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new TaiXe(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public IList<TaiXe> ListTaiXe_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string phone, bool? active)
		{
			Specification<TaiXe> spec = new Specification<TaiXe>((TaiXe o) => (o.MaTaiXe.Contains(maKH) || maKH.Trim() == string.Empty) && (o.TenTaiXe.Contains(tenKH) || tenKH.Trim() == string.Empty) && (o.Phone.Contains(phone) || phone.Trim() == string.Empty) && (o.CreationDate >= fromDate || fromDate == (DateTime?)DateTime.MinValue) && (o.CreationDate <= toDate || toDate == (DateTime?)DateTime.MinValue) && ((bool?)o.Activated == active || active == null));
			return base.SelectAll(spec);
		}
	}
}

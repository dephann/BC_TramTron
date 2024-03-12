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
    class NhanVienRepository : EFRepository<NhanVien>, INhanVienRepository, IEFRepository<NhanVien>
	{
		public NhanVienRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new NhanVien(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public IList<NhanVien> ListNhanVien_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string phone, bool? active)
		{
			Specification<NhanVien> spec = new Specification<NhanVien>((NhanVien o) => (o.MaNhanVien.Contains(maKH) || maKH.Trim() == string.Empty) && (o.TenNhanVien.Contains(tenKH) || tenKH.Trim() == string.Empty) && (o.Phone.Contains(phone) || phone.Trim() == string.Empty) && (o.CreationDate >= fromDate || fromDate == (DateTime?)DateTime.MinValue) && (o.CreationDate <= toDate || toDate == (DateTime?)DateTime.MinValue) && ((bool?)o.Activated == active || active == null));
			return base.SelectAll(spec);
		}
	}
}

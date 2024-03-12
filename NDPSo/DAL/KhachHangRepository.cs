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
    public class KhachHangRepository : EFRepository<KhachHang>,IKhachHangRepository, IEFRepository<KhachHang>
    {
        public KhachHangRepository(IDbContextManager dbCtxMng)
          : base(dbCtxMng)
        {
            base.KeyProperty = base.GetKeyColumnName(new KhachHang(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
        }

        public IList<KhachHang> ListKhachHang_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string diaChi, string phone, bool? active)
        {
            return this.SelectAll((ISpecification<KhachHang>)new Specification<KhachHang>((Expression<Func<KhachHang, bool>>)(o => (o.MaKhachHang.Contains(maKH) || maKH.Trim() == string.Empty) && (o.TenKhachHang.Contains(tenKH) || tenKH.Trim() == string.Empty) && (o.DiaChi.Contains(diaChi) || diaChi.Trim() == string.Empty) && (o.Phone.Contains(phone) || phone.Trim() == string.Empty) && (o.CreationDate >= fromDate || fromDate == (DateTime?)DateTime.MinValue) && (o.CreationDate <= toDate || toDate == (DateTime?)DateTime.MinValue) && ((bool?)o.Activated == active || active == new bool?()))));
        }
    }
}

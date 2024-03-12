using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
    public class HopDongRepository : EFRepository<HopDong>,IHopDongRepository, IEFRepository<HopDong>
    {
        public HopDongRepository(IDbContextManager dbCtxMng)
          : base(dbCtxMng)
        {
            this.KeyProperty = this.GetKeyColumnName(new HopDong(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
        }

        public IList<HopDong> ListHopDong_ByCondition(
          string maHopDong,
          DateTime fromDate,
          DateTime toDate,
          int? status,
          int? khachHangID,
          int? congTruongID,
          int? macID)
        {
            return this.SelectAll((ISpecification<HopDong>)new Specification<HopDong>((Expression<Func<HopDong, bool>>)(hd => (hd.MaHopDong.Contains(maHopDong) || maHopDong.Trim() == string.Empty) && hd.NgayHopDong >= (DateTime?)fromDate && hd.NgayHopDong <= (DateTime?)toDate && (hd.Status == status || status == (int?)-1) && (hd.KhachHangID == khachHangID || khachHangID == new int?()) && (hd.CongTruongID == congTruongID || congTruongID == new int?()) && (hd.MACID == macID || macID == new int?()))));
        }

        public HopDong GetByMaHD(string maHD) => this.DoQuery((ISpecification<HopDong>)new Specification<HopDong>((Expression<Func<HopDong, bool>>)(o => o.MaHopDong == maHD))).FirstOrDefault<HopDong>();
    }
}

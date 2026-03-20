using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
    class ViewSumWeightRepository : EFRepository<vw_SumWeight>, IViewSumWeightRepository, IEFRepository<vw_SumWeight>
    {
        public ViewSumWeightRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            base.KeyProperty = "PhieuTronID";
        }

        public IList<vw_SumWeight> ListSumWeight_ByCondition(
            DateTime? fromDate, 
            DateTime? toDate, 
            string maPhieuTron, 
            int? khachHang, 
            int? congTruong, 
            int? hangMuc, 
            int? mac, 
            int? bienSo, 
            int? taiXe,
            int? nhanVien,
            bool? active)
        {
            Specification<vw_SumWeight> spec = new Specification<vw_SumWeight>((vw_SumWeight o) =>
            (o.NgayPhieuTron >= (DateTime?)fromDate) && (o.NgayPhieuTron <= (DateTime?)toDate) &&
            (o.MaPhieuTron.Contains(maPhieuTron) || maPhieuTron.Trim() == string.Empty) &&
            (o.KH_int == khachHang || khachHang == null) &&
            (o.CT_int == congTruong || congTruong == null) &&
            (o.HM_int == hangMuc || hangMuc == null) &&
            (o.MAC_int == mac || mac == null) &&
            (o.Xe_int == bienSo || bienSo == null) &&
            (o.TX_int == taiXe || taiXe == null) &&
            (o.CreatedBy == nhanVien || nhanVien == null) &&
            ((bool?)o.IsQueued == active || active == new bool?()));
            return base.SelectAll(spec);
        }
    }
}

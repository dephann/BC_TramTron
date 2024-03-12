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
            (o.KhachHangID == khachHang || khachHang == null) &&
            (o.CongTruongID == congTruong || congTruong == null) &&
            (o.HangMucID == hangMuc || hangMuc == null) &&
            (o.MACID == mac || mac == null) &&
            (o.XeID == bienSo || bienSo == null) &&
            (o.TaiXeID == taiXe || taiXe == null) &&
            (o.CreatedBy == nhanVien || nhanVien == null) &&
            ((bool?)o.IsQueued == active || active == new bool?()));
            return base.SelectAll(spec);
        }
    }
}

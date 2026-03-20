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
    public class PhieuGiaoHangRepository : EFRepository<PhieuGiaoHang>, IPhieuGiaoHangRepository, IEFRepository<PhieuGiaoHang>
    {
        public PhieuGiaoHangRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
        {
            base.KeyProperty = base.GetKeyColumnName(new PhieuGiaoHang(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
        }

        public PhieuGiaoHang GetByCode(string code)
        {
            Specification<PhieuGiaoHang> spec = new Specification<PhieuGiaoHang>((PhieuGiaoHang pt) => pt.MaPhieuTron == code);
            return base.DoQuery(spec).FirstOrDefault<PhieuGiaoHang>();
        }

        public PhieuGiaoHang GetLastest()
        {
            return (from mt in base.DoQuery()
                    orderby mt.PhieuTronID descending
                    select mt).FirstOrDefault<PhieuGiaoHang>();
        }

        public IList<string> ListMaPhieuTron_AutoComplete(string strInput, int? length)
        {
            if (strInput.Trim() == string.Empty)
            {
                return new List<string>();
            }
            Specification<PhieuGiaoHang> spec = new Specification<PhieuGiaoHang>((PhieuGiaoHang pt) => pt.MaPhieuTron.Contains(strInput));
            List<string> lst = new List<string>();
            if (length != null)
            {
                lst = (from p in base.DoQuery(spec).Take(length.Value)
                       select p.MaPhieuTron).ToList<string>();
            }
            else
            {
                lst = (from p in base.DoQuery(spec)
                       select p.MaPhieuTron).ToList<string>();
            }
            return lst;
        }

        public IList<PhieuGiaoHang> ListPhieuTron_AutoComplete(string strInput, int? length)
        {
            if (strInput.Trim() == string.Empty)
            {
                return new List<PhieuGiaoHang>();
            }
            Specification<PhieuGiaoHang> spec = new Specification<PhieuGiaoHang>((PhieuGiaoHang pt) => pt.MaPhieuTron.Contains(strInput));
            List<PhieuGiaoHang> lst = new List<PhieuGiaoHang>();
            if (length != null)
            {
                lst = base.DoQuery(spec).Take(length.Value).ToList<PhieuGiaoHang>();
            }
            else
            {
                lst = base.DoQuery(spec).ToList<PhieuGiaoHang>();
            }
            return lst;
        }

        public IList<PhieuGiaoHang> ListPhieuTron_ByCondition(string maPhieuTron, DateTime fromDate, DateTime toDate, int? status, bool? isQueued)
        {
            Specification<PhieuGiaoHang> spec = new Specification<PhieuGiaoHang>((PhieuGiaoHang pt) => (pt.MaPhieuTron.Contains(maPhieuTron) || maPhieuTron.Trim() == string.Empty) && pt.NgayPhieuTron >= (DateTime?)fromDate && pt.NgayPhieuTron <= (DateTime?)toDate && (pt.Activated == isQueued || isQueued == null));
            var resultList = base.SelectAll(spec).OrderByDescending(pt => pt.PhieuTronID).ToList();

            return resultList;
        }

        public IList<PhieuGiaoHang> ListPhieuTron_ByCondition(string maPhieuTron, DateTime fromDate, DateTime toDate, bool? isQueued)
        {
            throw new NotImplementedException();
        }

        public IList<PhieuGiaoHang> ListPhieuTron_ByIsQueued(bool isQueued)
        {
            Specification<PhieuGiaoHang> spec = new Specification<PhieuGiaoHang>((PhieuGiaoHang pt) => pt.Activated == (bool?)isQueued);
            return base.SelectAll(spec);
        }
    }
}
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
	public class PhieuTronRepository : EFRepository<PhieuTron>, IPhieuTronRepository, IEFRepository<PhieuTron>
	{
		public PhieuTronRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName( new PhieuTron(),new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public PhieuTron GetByCode(string code)
		{
			Specification<PhieuTron> spec = new Specification<PhieuTron>((PhieuTron pt) => pt.MaPhieuTron == code);
			return base.DoQuery(spec).FirstOrDefault<PhieuTron>();
		}

		public PhieuTron GetLastest()
		{
			return (from mt in base.DoQuery()
					orderby mt.PhieuTronID descending
					select mt).FirstOrDefault<PhieuTron>();
		}

		public IList<PhieuTron> ListPhieuTron_ForTronOnline()
		{
			Specification<PhieuTron> spec = new Specification<PhieuTron>((PhieuTron pt) => pt.IsQueued == (bool?)true && (pt.Status == (int?)0 || pt.Status == (int?)2 || pt.Status == (int?)3 || pt.Status == (int?)6 || pt.Status == (int?)5 || pt.Status == (int?)7));
			return (from m in base.DoQuery(spec)
					orderby m.PhieuTronID
					select m).ToList<PhieuTron>();
		}

		public IList<PhieuTron> ListPhieuTron_ByStatus(int status)
		{
			Specification<PhieuTron> spec = new Specification<PhieuTron>((PhieuTron pt) => pt.Status == (int?)status);
			return base.SelectAll(spec);
		}

		public IList<PhieuTron> ListPhieuTron_ByIsQueued(bool isQueued)
		{
			Specification<PhieuTron> spec = new Specification<PhieuTron>((PhieuTron pt) => pt.IsQueued == (bool?)isQueued);
			return base.SelectAll(spec);
		}

		public IList<PhieuTron> ListPhieuTron_ByCondition(string maPhieuTron, DateTime fromDate, DateTime toDate, int? status, bool? isQueued)
		{
			Specification<PhieuTron> spec = new Specification<PhieuTron>((PhieuTron pt) => (pt.MaPhieuTron.Contains(maPhieuTron) || maPhieuTron.Trim() == string.Empty) && pt.NgayPhieuTron >= (DateTime?)fromDate && pt.NgayPhieuTron <= (DateTime?)toDate && (pt.Status == status || status == (int?)-1) && (pt.IsQueued == isQueued || isQueued == null));
			var resultList = base.SelectAll(spec).OrderByDescending(pt => pt.PhieuTronID).ToList();

			return resultList;
		}

		public IList<string> ListMaPhieuTron_AutoComplete(string strInput, int? length)
		{
			if (strInput.Trim() == string.Empty)
			{
				return new List<string>();
			}
			Specification<PhieuTron> spec = new Specification<PhieuTron>((PhieuTron pt) => pt.MaPhieuTron.Contains(strInput));
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

		public IList<PhieuTron> ListPhieuTron_AutoComplete(string strInput, int? length)
		{
			if (strInput.Trim() == string.Empty)
			{
				return new List<PhieuTron>();
			}
			Specification<PhieuTron> spec = new Specification<PhieuTron>((PhieuTron pt) => pt.MaPhieuTron.Contains(strInput));
			List<PhieuTron> lst = new List<PhieuTron>();
			if (length != null)
			{
				lst = base.DoQuery(spec).Take(length.Value).ToList<PhieuTron>();
			}
			else
			{
				lst = base.DoQuery(spec).ToList<PhieuTron>();
			}
			return lst;
		}
	}
}
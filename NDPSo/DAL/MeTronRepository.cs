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
	public class MeTronRepository : EFRepository<MeTron>, IMeTronRepository, IEFRepository<MeTron>
	{
		public MeTronRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new MeTron(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public MeTron GetMeTron(int phieuTronId, int lnNo)
		{
			Specification<MeTron> spec = new Specification<MeTron>((MeTron mt) => mt.PhieuTronID == phieuTronId && mt.LnNo == (int?)lnNo);
			return (from mt in base.DoQuery(spec)
					orderby mt.MeTronID descending
					select mt).FirstOrDefault<MeTron>();
		}

		public MeTron GetLatestMeTronFromPhieuTron(int phieuTronId)
		{
			Specification<MeTron> spec = new Specification<MeTron>((MeTron mt) => mt.PhieuTronID == phieuTronId);
			return (from mt in base.DoQuery(spec)
					orderby mt.MeTronID descending
					select mt).FirstOrDefault<MeTron>();
		}
	}
}

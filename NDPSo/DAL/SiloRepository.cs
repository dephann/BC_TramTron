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
	public class SiloRepository : EFRepository<Silo>, ISiloRepository, IEFRepository<Silo>
	{
		public SiloRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName( new Silo(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}

		public IList<Silo> ListSilo_ByActivated(bool activated)
		{
			Specification<Silo> spec = new Specification<Silo>((Silo sl) => sl.Activated == (bool?)activated);
			return base.DoQuery(spec).ToList<Silo>();
		}

		public IList<Silo> ListSilo_ByActivated_MaNhomSilo(bool? activated, string maNhomSL)
		{
			Specification<Silo> spec = new Specification<Silo>((Silo sl) => (sl.Activated == (bool?)activated || activated == null) && sl.NhomSilo.MaNhomSilo == maNhomSL);
			return base.SelectAll(spec);
		}
	}
}
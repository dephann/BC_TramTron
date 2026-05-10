using NDPSo.Core;
using NDPSo.EntityModel;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public class MeTronChiTietRepository : EFRepository<MeTronChiTiet>, IMeTronChiTietRepository, IEFRepository<MeTronChiTiet>
	{
		public MeTronChiTietRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = base.GetKeyColumnName(new MeTronChiTiet(), new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString));
		}
        public IList<MeTronChiTiet> ListByMeTronID(int meTronID)
        {
            return base.DoQuery()
                .Where(c => c.MeTronID == meTronID && c.MACSiloID != null)
                .Include(c => c.MACSilo)
                .ToList();
        }
    }
}
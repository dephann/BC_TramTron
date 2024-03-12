using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
    public interface IMACRepository : IEFRepository<MAC>
    {
        IList<MAC> ListMAC_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maMAC,
          string tenMAC,
          bool? active);
    }
}

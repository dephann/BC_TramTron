using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
    public interface IMACSiloRepository : IEFRepository<MACSilo>
    {
        IList<MACSilo> ListMACSilo_ByMACID(int macID);
    }
}

using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
    public interface IMaterialRepository : IEFRepository<Material>
    {
        IList<Material> ListMaterial_ByCondition(
          DateTime? fromDate,
          DateTime? toDate,
          string maVT,
          string tenVT,
          bool? active);
    }
}
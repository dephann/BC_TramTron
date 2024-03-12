using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;

namespace NDPSo.DAL
{
    public interface Ivw_TotalMaterialRepository : IEFRepository<vw_PvTotalMaterial>
    {
        IList<vw_PvTotalMaterial> ListvwTotalMaterial_ByCondition(int? MaterialID, bool? isManual);
    }
}

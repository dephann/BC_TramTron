using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;

namespace NDPSo.DAL
{
    interface Ivw_TotalDriverRepository : IEFRepository<vw_PvDriverDetailDay_WithID>
    {
        IList<vw_PvDriverDetailDay_WithID> ListvwTotalDriver_ByCondition(int? taixeID, bool? isManual);
    }
}

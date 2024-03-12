using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;

namespace NDPSo.DAL
{
    interface Ivw_TotalDriverRepository : IEFRepository<vw_PvTotalDriver>
    {
        IList<vw_PvTotalDriver> ListvwTotalDriver_ByCondition(int? taixeID, bool? isManual);
    }
}

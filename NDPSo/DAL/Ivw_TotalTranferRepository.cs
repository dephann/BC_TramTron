using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;

namespace NDPSo.DAL
{
    interface Ivw_TotalTranferRepository : IEFRepository<vw_PvTranferDetailDay_WithID>
    {
        IList<vw_PvTranferDetailDay_WithID> ListvwTotalTranfer_ByCondition(int? xeID, bool? isManual);
    }
}

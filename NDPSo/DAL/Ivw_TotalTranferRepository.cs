using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;

namespace NDPSo.DAL
{
    interface Ivw_TotalTranferRepository : IEFRepository<vw_PvTotalTranfer>
    {
        IList<vw_PvTotalTranfer> ListvwTotalTranfer_ByCondition(int? xeID, bool? isManual);
    }
}

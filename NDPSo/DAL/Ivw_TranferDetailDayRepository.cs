using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;

namespace NDPSo.DAL
{
    public interface Ivw_TranferDetailDayRepository : IEFRepository<vw_PvTranferDetailDay>
    {
        IList<vw_PvTranferDetailDay> ListTranferDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? xeID, bool? isQueued);
    }
}

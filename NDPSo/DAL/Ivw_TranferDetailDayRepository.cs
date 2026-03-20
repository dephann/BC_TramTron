using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;

namespace NDPSo.DAL
{
    public interface Ivw_TranferDetailDayRepository : IEFRepository<vw_PvTranferDetailDay_WithID>
    {
        IList<vw_PvTranferDetailDay_WithID> ListTranferDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? xeID, bool? isQueued);
        IList<vw_PvTranferDetailDay_WithID> ListTranferDetailDay_ByCondition_Update(DateTime? fromDate, DateTime? toDate, int? xeID, bool? isQueued);
    }
}

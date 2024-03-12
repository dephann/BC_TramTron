using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;

namespace NDPSo.DAL
{
    public interface Ivw_MaterialDetailDayRepository : IEFRepository<vw_PvMaterialDetailDay>
    {
        IList<vw_PvMaterialDetailDay> ListvwMaterialDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? MaterialID, bool? isManual);
    }
}

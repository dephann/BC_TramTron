using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.Data;
using NDPSo.EntityModel;
using NDPSo.KWS;

namespace NDPSo.DAL
{
    public interface Ivw_MaterialDetailDayRepository : IEFRepository<vw_PvMaterialDetailDay_WithID>
    {
        IList<vw_PvMaterialDetailDay_WithID> ListvwMaterialDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? MaterialID, bool? isManual);
        IList<vw_PvMaterialDetailDay_WithID> ListvwMaterialDetailDay_ByCondition_Update(DateTime? fromDate, DateTime? toDate, int? MaterialID, bool? isManual);
    }
}

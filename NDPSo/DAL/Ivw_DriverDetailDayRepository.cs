using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
    public interface Ivw_DriverDetailDayRepository : IEFRepository<vw_PvDriverDetailDay_WithID>
    {
        IList<vw_PvDriverDetailDay_WithID> ListDriverDetailDay_ByCondition(DateTime? fromDate, DateTime? toDate, int? taiXeID, bool? isManual);
        IList<vw_PvDriverDetailDay_WithID> ListDriverDetailDay_ByCondition_Update(DateTime? fromDate, DateTime? toDate, int? taiXeID, bool? isManual);

    }
}

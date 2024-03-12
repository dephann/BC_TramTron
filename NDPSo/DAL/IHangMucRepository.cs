using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
    public interface IHangMucRepository : IEFRepository<HangMuc>
    {
        IList<HangMuc> ListHangMuc_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, bool? active);

    }
}

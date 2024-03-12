using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
    public interface IHopDongRepository : IEFRepository<HopDong>
    {
        IList<HopDong> ListHopDong_ByCondition(
          string maHopDong,
          DateTime fromDate,
          DateTime toDate,
          int? status,
          int? khachHangID,
          int? congTruongID,
          int? macID);

        HopDong GetByMaHD(string maHD);
    }
}

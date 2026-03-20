using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
    public interface IPhieuGiaoHangRepository : IEFRepository<PhieuGiaoHang>
    {
        PhieuGiaoHang GetByCode(string code);

        PhieuGiaoHang GetLastest();

        IList<PhieuGiaoHang> ListPhieuTron_ByIsQueued(bool isQueued);

        IList<PhieuGiaoHang> ListPhieuTron_ByCondition(
          string maPhieuTron,
          DateTime fromDate,
          DateTime toDate,
          bool? isQueued);

        IList<string> ListMaPhieuTron_AutoComplete(string strInput, int? length);

        IList<PhieuGiaoHang> ListPhieuTron_AutoComplete(string strInput, int? length);

    }
}

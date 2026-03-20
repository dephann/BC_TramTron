using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
    public interface IPhieuTronRepository : IEFRepository<PhieuTron>
    {
        PhieuTron GetByCode(string code);

        PhieuTron GetLastest();

        IList<PhieuTron> ListPhieuTron_ForTronOnline();

        IList<PhieuTron> ListPhieuTron_ByStatus(int status);

        IList<PhieuTron> ListPhieuTron_ByIsQueued(bool isQueued);

        IList<PhieuTron> ListPhieuTron_ByCondition(
          string maPhieuTron,
          DateTime fromDate,
          DateTime toDate,
          int? status,
          bool? isQueued);

        IList<string> ListMaPhieuTron_AutoComplete(string strInput, int? length);

        IList<PhieuTron> ListPhieuTron_AutoComplete(string strInput, int? length);
    
    }
}


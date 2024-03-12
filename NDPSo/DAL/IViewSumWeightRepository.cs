using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDPSo.Core;
using NDPSo.EntityModel;

namespace NDPSo.DAL
{
    public interface IViewSumWeightRepository: IEFRepository<vw_SumWeight>
    {
        IList<vw_SumWeight> ListSumWeight_ByCondition(DateTime? fromDate, DateTime? toDate, string maPhieuTron, int? khachHang, int? congTruong, int? hangMuc, int? mac, int? bienSo, int? taiXe, int? nhanVien, bool? active);
    }
}

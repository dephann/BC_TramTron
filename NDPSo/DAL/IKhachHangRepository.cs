using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public interface IKhachHangRepository : IEFRepository<KhachHang>
	{
		
		IList<KhachHang> ListKhachHang_ByCondition(DateTime? fromDate, DateTime? toDate, string maKH, string tenKH, string diaChi, string phone, bool? active);
	}
}

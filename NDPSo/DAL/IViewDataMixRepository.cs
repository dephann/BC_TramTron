using NDPSo.Core;
using NDPSo.Data;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public interface IViewDataMixRepository : IEFRepository<vw_DataMix>
	{
		IList<vw_DataMix> ListDataMix_ByCondition(DateTime? fromDate, DateTime? toDate, string maPhieuTron, string khachHang, string congTruong, string hangMuc, string taiXe, string bienSo, string mac, string nhanVien);
		IList<vw_DataMix> ListDataMix_ByCondition(DateTime? fromDate, DateTime? toDate, string maPhieuTron, int? khachHang, int? congTruong, int? hangMuc, int? mac, int? bienSo, int? taiXe, int? nhanVien, bool? active);
		ObjAggregationResult GetSumForIsQueuedAndTimeRange(DateTime? fromDate, DateTime? toDate, bool? activated);


	}
}

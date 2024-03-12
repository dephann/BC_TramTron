using NDPSo.Core;
using NDPSo.Data;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public class ViewDataMixRepository : EFRepository<vw_DataMix>, IViewDataMixRepository, IEFRepository<vw_DataMix>
	{
		public ViewDataMixRepository(IDbContextManager dbCtxMng) : base(dbCtxMng)
		{
			base.KeyProperty = "MeTronID";
		}

		public IList<vw_DataMix> ListDataMix(DateTime? fromDate, DateTime? toDate, string maPhieuTron)
		{
			Specification<vw_DataMix> spec = new Specification<vw_DataMix>((vw_DataMix o) => (o.MaPhieuTron.Contains(maPhieuTron) || maPhieuTron.Trim() == string.Empty) && o.NgayMeTron >= (DateTime?)fromDate && o.NgayMeTron <= (DateTime?)toDate);
			return base.SelectAll(spec);
		}

		public IList<vw_DataMix> ListDataMix_ByCondition(DateTime? fromDate, DateTime? toDate, string maPhieuTron, string khachHang, string congTruong, string hangMuc, string taiXe, string bienSo, string mac, string nhanVien)
		{
			Specification<vw_DataMix> spec = new Specification<vw_DataMix>((vw_DataMix o) => (o.NgayMeTron >= (DateTime?)fromDate && o.NgayMeTron <= (DateTime?)toDate && o.MaPhieuTron.Contains(maPhieuTron) || maPhieuTron.Trim() == string.Empty) && (o.KH.Contains(khachHang) || khachHang.Trim() == string.Empty) && (o.CT.Contains(congTruong) || congTruong.Trim() == string.Empty) && (o.Plate.Contains(hangMuc) || hangMuc.Trim() == string.Empty) && (o.Name.Contains(taiXe) || taiXe.Trim() == string.Empty) && (o.TX.Contains(bienSo) || bienSo.Trim() == string.Empty) && (o.MAC.Contains(mac) || mac.Trim() == string.Empty) && (o.NoteMAC.Contains(nhanVien) || nhanVien.Trim() == string.Empty));

			return  base.SelectAll(spec);
		}

		public IList<vw_DataMix> ListDataMix_ByCondition(
			DateTime? fromDate,
			DateTime? toDate,
			string maPhieuTron,
			int? khachHang,
			int? congTruong,
			int? hangMuc,
			int? mac,
			int? bienSo,
			int? taiXe,
			int? nhanVien,
			bool? moPhong)
		{
			Specification<vw_DataMix> spec = new Specification<vw_DataMix>((vw_DataMix o) =>
			(o.NgayMeTron >= (DateTime?)fromDate) && (o.NgayMeTron <= (DateTime?)toDate) &&
			(o.MaPhieuTron.Contains(maPhieuTron) || maPhieuTron.Trim() == string.Empty) &&
			(o.KH_int == khachHang || khachHang == null) &&
			(o.CT_int == congTruong || congTruong == null) &&
			(o.HM_int == hangMuc || hangMuc == null) &&
			(o.MAC_int == mac || mac == null) &&
			(o.Xe_int == bienSo || bienSo == null) &&
			(o.TaiXeID == taiXe || taiXe == null) &&
			(o.CreatedBy == nhanVien || nhanVien == null) &&
			((bool?)o.IsQueued == moPhong || moPhong == new bool?()));
			var resultList = base.SelectAll(spec).OrderByDescending(dm => dm.MeTronID).ToList();

			return resultList;
		}

		public ObjAggregationResult GetSumForIsQueuedAndTimeRange(DateTime? fromDate, DateTime? toDate, bool ? activated )
		{
			Specification<vw_DataMix> spec = new Specification<vw_DataMix>((data) =>
			(data.IsQueued == (bool?)activated || activated == null)
			&& (data.NgayMeTron >= fromDate || fromDate == DateTime.MinValue)
			&& (data.NgayMeTron <= toDate || toDate == DateTime.MinValue));

			var queryResult = base.DoQuery(spec);

			return new ObjAggregationResult
			{
				Total_Agg1 = queryResult.Sum(data => data.Agg1),
				Total_Agg2 = queryResult.Sum(data => data.Agg2),
				Total_Agg3 = queryResult.Sum(data => data.Agg3),
				Total_Agg4 = queryResult.Sum(data => data.Agg4),
				Total_Agg5 = queryResult.Sum(data => data.Agg5),
				Total_Ce1 = queryResult.Sum(data => data.Ce1),
				Total_Ce2 = queryResult.Sum(data => data.Ce2),
				Total_Ce3 = queryResult.Sum(data => data.Ce3),
				Total_Ce4 = queryResult.Sum(data => data.Ce4),
				Total_Ce5 = queryResult.Sum(data => data.Ce5),
				Total_Wa1 = queryResult.Sum(data => data.Wa1),
				Total_Wa2 = queryResult.Sum(data => data.Wa2),
				Total_Add1 = queryResult.Sum(data => data.Add1),
				Total_Add2 = queryResult.Sum(data => data.Add2),
				Total_Add3 = queryResult.Sum(data => data.Add3),
				Total_Add4 = queryResult.Sum(data => data.Add4),
				Total_Add5 = queryResult.Sum(data => data.Add5),
				Total_Add6 = queryResult.Sum(data => data.Add6),
				Total_Agg1_Bat = queryResult.Sum(data => data.Agg1_Bat),
				Total_Agg2_Bat = queryResult.Sum(data => data.Agg2_Bat),
				Total_Agg3_Bat = queryResult.Sum(data => data.Agg3_Bat),
				Total_Agg4_Bat = queryResult.Sum(data => data.Agg4_Bat),
				Total_Agg5_Bat = queryResult.Sum(data => data.Agg5_Bat),
				Total_Ce1_Bat = queryResult.Sum(data => data.Ce1_Bat),
				Total_Ce2_Bat = queryResult.Sum(data => data.Ce2_Bat),
				Total_Ce3_Bat = queryResult.Sum(data => data.Ce3_Bat),
				Total_Ce4_Bat = queryResult.Sum(data => data.Ce4_Bat),
				Total_Ce5_Bat = queryResult.Sum(data => data.Ce5_Bat),
				Total_Wa1_Bat = queryResult.Sum(data => data.Wa1_Bat),
				Total_Wa2_Bat = queryResult.Sum(data => data.Wa2_Bat),
				Total_Add1_Bat = queryResult.Sum(data => data.Add1_Bat),
				Total_Add2_Bat = queryResult.Sum(data => data.Add2_Bat),
				Total_Add3_Bat = queryResult.Sum(data => data.Add3_Bat),
				Total_Add4_Bat = queryResult.Sum(data => data.Add4_Bat),
				Total_Add5_Bat = queryResult.Sum(data => data.Add5_Bat),
				Total_Add6_Bat = queryResult.Sum(data => data.Add6_Bat),
				Total_Agg1_Man = queryResult.Sum(data => data.Agg1_Man),
				Total_Agg2_Man = queryResult.Sum(data => data.Agg2_Man),
				Total_Agg3_Man = queryResult.Sum(data => data.Agg3_Man),
				Total_Agg4_Man = queryResult.Sum(data => data.Agg4_Man),
				Total_Agg5_Man = queryResult.Sum(data => data.Agg5_Man),
				Total_Ce1_Man = queryResult.Sum(data => data.Ce1_Man),
				Total_Ce2_Man = queryResult.Sum(data => data.Ce2_Man),
				Total_Ce3_Man = queryResult.Sum(data => data.Ce3_Man),
				Total_Ce4_Man = queryResult.Sum(data => data.Ce4_Man),
				Total_Ce5_Man = queryResult.Sum(data => data.Ce5_Man),
				Total_Wa1_Man = queryResult.Sum(data => data.Wa1_Man),
				Total_Wa2_Man = queryResult.Sum(data => data.Wa2_Man),
				Total_Add1_Man = queryResult.Sum(data => data.Add1_Man),
				Total_Add2_Man = queryResult.Sum(data => data.Add2_Man),
				Total_Add3_Man = queryResult.Sum(data => data.Add3_Man),
				Total_Add4_Man = queryResult.Sum(data => data.Add4_Man),
				Total_Add5_Man = queryResult.Sum(data => data.Add5_Man),
				Total_Add6_Man = queryResult.Sum(data => data.Add6_Man)
			};
		}
	}
}
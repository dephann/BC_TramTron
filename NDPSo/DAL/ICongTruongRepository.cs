using System;
using System.Collections.Generic;
using NDPSo.Core;
using NDPSo.EntityModel;

namespace NDPSo.DAL
{
	public interface ICongTruongRepository : IEFRepository<CongTruong>
	{
		IList<CongTruong> ListCongTruong_ByCondition(DateTime? fromDate, DateTime? toDate, string maCT, string tenCT, string diaChi, string phone, bool? active);
	}
}

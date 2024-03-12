using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjRptTheoPhieu : ObjectBase
	{
		[DataMember]
		public int MeTronID { get; set; }

		[DataMember]
		public DateTime? NgayMeTron { get; set; }

		[DataMember]
		public DateTime? Ngay { get; set; }

		[DataMember]
		public DateTime? Gio { get; set; }

		[DataMember]
		public int? Phieu { get; set; }

		[DataMember]
		public int? PhieuTronID { get; set; }

		[DataMember]
		public string MaPhieuTron { get; set; }

		[DataMember]
		public int? HD { get; set; }

		[DataMember]
		public string NoteHD { get; set; }

		[DataMember]
		public string MaHopDong { get; set; }

		[DataMember]
		public string KH { get; set; }

		[DataMember]
		public string NoteKH { get; set; }

		[DataMember]
		public string CT { get; set; }

		[DataMember]
		public string NoteCT { get; set; }

		[DataMember]
		public int? TaiXeID { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string TX { get; set; }

		[DataMember]
		public int? TX_int { get; set; }

		[DataMember]
		public string Plate { get; set; }

		[DataMember]
		public string MAC { get; set; }

		[DataMember]
		public string NoteMAC { get; set; }

		[DataMember]
		public string DoSut { get; set; }

		[DataMember]
		public decimal? KLVC { get; set; }

		[DataMember]
		public decimal? KLMe { get; set; }

		[DataMember]
		public decimal? Agg1 { get; set; }

		[DataMember]
		public decimal? Agg2 { get; set; }

		[DataMember]
		public decimal? Agg3 { get; set; }

		[DataMember]
		public decimal? Agg4 { get; set; }

		[DataMember]
		public decimal? Agg5 { get; set; }

		[DataMember]
		public decimal? Agg6 { get; set; }

		[DataMember]
		public decimal? Ce1 { get; set; }

		[DataMember]
		public decimal? Ce2 { get; set; }

		[DataMember]
		public decimal? Ce3 { get; set; }

		[DataMember]
		public decimal? Ce4 { get; set; }

		[DataMember]
		public decimal? Wa { get; set; }

		[DataMember]
		public decimal? Add1 { get; set; }

		[DataMember]
		public decimal? Add2 { get; set; }

		[DataMember]
		public decimal? Add3 { get; set; }

		[DataMember]
		public decimal? Add4 { get; set; }

		[DataMember]
		public decimal? Add5 { get; set; }

		[DataMember]
		public decimal? Add6 { get; set; }

		[DataMember]
		public decimal? Agg1_Bat { get; set; }

		[DataMember]
		public decimal? Agg2_Bat { get; set; }

		[DataMember]
		public decimal? Agg3_Bat { get; set; }

		[DataMember]
		public decimal? Agg4_Bat { get; set; }

		[DataMember]
		public decimal? Agg5_Bat { get; set; }

		[DataMember]
		public decimal? Agg6_Bat { get; set; }

		[DataMember]
		public decimal? Ce1_Bat { get; set; }

		[DataMember]
		public decimal? Ce2_Bat { get; set; }

		[DataMember]
		public decimal? Ce3_Bat { get; set; }

		[DataMember]
		public decimal? Ce4_Bat { get; set; }

		[DataMember]
		public decimal? Wa_Bat { get; set; }

		[DataMember]
		public decimal? Add1_Bat { get; set; }

		[DataMember]
		public decimal? Add2_Bat { get; set; }

		[DataMember]
		public decimal? Add3_Bat { get; set; }

		[DataMember]
		public decimal? Add4_Bat { get; set; }

		[DataMember]
		public decimal? Add5_Bat { get; set; }

		[DataMember]
		public decimal? Add6_Bat { get; set; }

		[DataMember]
		public decimal? TKLVC { get; set; }

		[DataMember]
		public decimal? TKLVCTheoNgay { get; set; }
	}
}

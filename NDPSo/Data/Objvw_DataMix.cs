using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class Objvw_DataMix : ObjectBase
	{
		[DataMember]
		public int MeTronID { get; set; }
		[DataMember]
		public int? LnNo { get; set; }

		[DataMember]
		public DateTime? NgayMeTron { get; set; }

		[DataMember]
		public DateTime? Ngay { get; set; }

		[DataMember]
		public TimeSpan? Gio { get; set; }

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
		public int? KH_int { get; set; }

		[DataMember]
		public string NoteKH { get; set; }

		[DataMember]
		public string CT { get; set; }

		[DataMember]
		public int? CT_int { get; set; }

		[DataMember]
		public string NoteCT { get; set; }

		[DataMember]
		public string HM { get; set; }

		[DataMember]
		public int? HM_int { get; set; }

		[DataMember]
		public decimal? KLDuTinh { get; set; }

		[DataMember]
		public bool IsQueued { get; set; }

		[DataMember]
		public string TenNV { get; set; }

		[DataMember]
		public int? NV_int { get; set; }

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
		public int? Xe_int { get; set; }

		[DataMember]
		public string MAC { get; set; }

		[DataMember]
		public int? MAC_int { get; set; }

		[DataMember]
		public string NoteMAC { get; set; }

		[DataMember]
		public string DoSut { get; set; }

		[DataMember]
		public decimal? KLVC { get; set; }

		[DataMember]
		public decimal? KLMe { get; set; }

		[DataMember]
		public int? CreatedBy { get; set; }
		[DataMember]
		public string FullName { get; set; }

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
		public decimal? Ce5 { get; set; }

		[DataMember]
		public decimal? Ce6 { get; set; }

		[DataMember]
		public decimal? Wa1 { get; set; }

		[DataMember]
		public decimal? Wa2 { get; set; }

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
		public decimal? Add7 { get; set; }

		[DataMember]
		public decimal? Add8 { get; set; }

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
		public decimal? Ce5_Bat { get; set; }

		[DataMember]
		public decimal? Ce6_Bat { get; set; }

		[DataMember]
		public decimal? Wa1_Bat { get; set; }

		[DataMember]
		public decimal? Wa2_Bat { get; set; }

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
		public decimal? Add7_Bat { get; set; }

		[DataMember]
		public decimal? Add8_Bat { get; set; }

		[DataMember]
		public decimal? Agg1_Mac { get; set; }

		[DataMember]
		public decimal? Agg2_Mac { get; set; }

		[DataMember]
		public decimal? Agg3_Mac { get; set; }

		[DataMember]
		public decimal? Agg4_Mac { get; set; }

		[DataMember]
		public decimal? Agg5_Mac { get; set; }

		[DataMember]
		public decimal? Agg6_Mac { get; set; }

		[DataMember]
		public decimal? Ce1_Mac { get; set; }

		[DataMember]
		public decimal? Ce2_Mac { get; set; }

		[DataMember]
		public decimal? Ce3_Mac { get; set; }

		[DataMember]
		public decimal? Ce4_Mac { get; set; }

		[DataMember]
		public decimal? Ce5_Mac { get; set; }

		[DataMember]
		public decimal? Ce6_Mac { get; set; }

		[DataMember]
		public decimal? Wa1_Mac { get; set; }

		[DataMember]
		public decimal? Wa2_Mac { get; set; }

		[DataMember]
		public decimal? Add1_Mac { get; set; }

		[DataMember]
		public decimal? Add2_Mac { get; set; }

		[DataMember]
		public decimal? Add3_Mac { get; set; }

		[DataMember]
		public decimal? Add4_Mac { get; set; }

		[DataMember]
		public decimal? Add5_Mac { get; set; }

		[DataMember]
		public decimal? Add6_Mac { get; set; }

		[DataMember]
		public decimal? Add7_Mac { get; set; }

		[DataMember]
		public decimal? Add8_Mac { get; set; }
		[DataMember]
		public decimal? Agg1_Man { get; set; }

		[DataMember]
		public decimal? Agg2_Man { get; set; }

		[DataMember]
		public decimal? Agg3_Man { get; set; }

		[DataMember]
		public decimal? Agg4_Man { get; set; }

		[DataMember]
		public decimal? Agg5_Man { get; set; }

		[DataMember]
		public decimal? Agg6_Man { get; set; }

		[DataMember]
		public decimal? Ce1_Man { get; set; }

		[DataMember]
		public decimal? Ce2_Man { get; set; }

		[DataMember]
		public decimal? Ce3_Man { get; set; }

		[DataMember]
		public decimal? Ce4_Man { get; set; }

		[DataMember]
		public decimal? Ce5_Man { get; set; }

		[DataMember]
		public decimal? Ce6_Man { get; set; }

		[DataMember]
		public decimal? Wa1_Man { get; set; }

		[DataMember]
		public decimal? Wa2_Man { get; set; }

		[DataMember]
		public decimal? Add1_Man { get; set; }

		[DataMember]
		public decimal? Add2_Man { get; set; }

		[DataMember]
		public decimal? Add3_Man { get; set; }

		[DataMember]
		public decimal? Add4_Man { get; set; }

		[DataMember]
		public decimal? Add5_Man { get; set; }

		[DataMember]
		public decimal? Add6_Man { get; set; }

		[DataMember]
		public decimal? Add7_Man { get; set; }

		[DataMember]
		public decimal? Add8_Man { get; set; }

		[DataMember]
		public decimal? Agg1_Tol { get; set; }

		[DataMember]
		public decimal? Agg2_Tol { get; set; }

		[DataMember]
		public decimal? Agg3_Tol { get; set; }

		[DataMember]
		public decimal? Agg4_Tol { get; set; }

		[DataMember]
		public decimal? Agg5_Tol { get; set; }

		[DataMember]
		public decimal? Agg6_Tol { get; set; }

		[DataMember]
		public decimal? Ce1_Tol { get; set; }

		[DataMember]
		public decimal? Ce2_Tol { get; set; }

		[DataMember]
		public decimal? Ce3_Tol { get; set; }

		[DataMember]
		public decimal? Ce4_Tol { get; set; }

		[DataMember]
		public decimal? Ce5_Tol { get; set; }

		[DataMember]
		public decimal? Ce6_Tol { get; set; }

		[DataMember]
		public decimal? Wa1_Tol { get; set; }

		[DataMember]
		public decimal? Wa2_Tol { get; set; }

		[DataMember]
		public decimal? Add1_Tol { get; set; }

		[DataMember]
		public decimal? Add2_Tol { get; set; }

		[DataMember]
		public decimal? Add3_Tol { get; set; }

		[DataMember]
		public decimal? Add4_Tol { get; set; }

		[DataMember]
		public decimal? Add5_Tol { get; set; }

		[DataMember]
		public decimal? Add6_Tol { get; set; }

		[DataMember]
		public decimal? Add7_Tol { get; set; }

		[DataMember]
		public decimal? Add8_Tol { get; set; }

		[DataMember]
		public decimal? Agg1_PerTol { get; set; }

		[DataMember]
		public decimal? Agg2_PerTol { get; set; }

		[DataMember]
		public decimal? Agg3_PerTol { get; set; }

		[DataMember]
		public decimal? Agg4_PerTol { get; set; }

		[DataMember]
		public decimal? Agg5_PerTol { get; set; }

		[DataMember]
		public decimal? Agg6_PerTol { get; set; }

		[DataMember]
		public decimal? Ce1_PerTol { get; set; }

		[DataMember]
		public decimal? Ce2_PerTol { get; set; }

		[DataMember]
		public decimal? Ce3_PerTol { get; set; }

		[DataMember]
		public decimal? Ce4_PerTol { get; set; }

		[DataMember]
		public decimal? Ce5_PerTol { get; set; }

		[DataMember]
		public decimal? Ce6_PerTol { get; set; }

		[DataMember]
		public decimal? Wa1_PerTol { get; set; }

		[DataMember]
		public decimal? Wa2_PerTol { get; set; }

		[DataMember]
		public decimal? Add1_PerTol { get; set; }

		[DataMember]
		public decimal? Add2_PerTol { get; set; }

		[DataMember]
		public decimal? Add3_PerTol { get; set; }

		[DataMember]
		public decimal? Add4_PerTol { get; set; }

		[DataMember]
		public decimal? Add5_PerTol { get; set; }

		[DataMember]
		public decimal? Add6_PerTol { get; set; }

		[DataMember]
		public decimal? Add7_PerTol { get; set; }

		[DataMember]
		public decimal? Add8_PerTol { get; set; }

	}
}

using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjMeTronChiTiet : ObjectBase
	{
		[DataMember]
		public int MeTronChiTietID { get; set; }

		[DataMember]
		public int MeTronID { get; set; }

		[DataMember]
		public int? MACSiloID { get; set; }

		[DataMember]
		public decimal? Value { get; set; }

		[DataMember]
		public decimal? ValueBat { get; set; }

		[DataMember]
		public decimal? ValueBatAuto { get; set; }

		[DataMember]
		public decimal? ValueBatMan { get; set; }

		[DataMember]
		public decimal? ValueTol { get; set; }

		[DataMember]
		public decimal? ValuePerTol { get; set; }

		[DataMember]
		public decimal? SiloValue { get; set; }

		[DataMember]
		public decimal? SaiSoDuoi { get; set; }

		[DataMember]
		public decimal? SaiSoTren { get; set; }

		[DataMember]
		public decimal? KLCanNhoNhat { get; set; }

		[DataMember]
		public decimal? KLCanLonNhat { get; set; }

		[DataMember]
		public decimal? TGNhapNhaOn { get; set; }

		[DataMember]
		public decimal? TGNhapNhaOff { get; set; }

		[DataMember]
		public decimal? TGKiemTraVatLieuRoi { get; set; }

		[DataMember]
		public decimal? KLRoi { get; set; }

		[DataMember]
		public decimal? KLDT_Tu1 { get; set; }

		[DataMember]
		public decimal? KLDT_Tu2 { get; set; }

		[DataMember]
		public decimal? KLDT_Tu3 { get; set; }

		[DataMember]
		public decimal? KLDT_Den1 { get; set; }

		[DataMember]
		public decimal? KLDT_Den2 { get; set; }

		[DataMember]
		public decimal? KLDT_Den3 { get; set; }

		[DataMember]
		public int? TinhDoHutNuocID { get; set; }

		[DataMember]
		public decimal? DoAm_NhomSlioAgg { get; set; }

		[DataMember]
		public decimal? DoHutNuoc_NhomSiloAgg { get; set; }

		[DataMember]
		public int? SoiTrongCat_SiloId_NhomSiloAgg { get; set; }

		[DataMember]
		public decimal? SoiTrongCat_Percent_NhomSiloAgg { get; set; }

		[DataMember]
		public int? MaterialID { get; set; }

		[DataMember]
		public string MaterialCode { get; set; }

		[DataMember]
		public string MaterialName { get; set; }

		[DataMember]
		public string MaSilo { get; set; }

		[DataMember]
		public int? STTSiloPLC { get; set; }

		[DataMember]
		public bool? IsManual { get; set; }

		[DataMember]
		public DateTime? NgayMTCT { get; set; }

		[DataMember]
		public int? PLCSaveId { get; set; }

		[DataMember]
		public DateTime? CreationDate { get; set; }

		[DataMember]
		public int? CreatedBy { get; set; }

		[DataMember]
		public DateTime? LatestUpdateDate { get; set; }

		[DataMember]
		public int? LatestUpdatedBy { get; set; }

		[DataMember]
		public byte[] VersionNo { get; set; }

		[DataMember]
		public string NDTenSilo { get; set; }
	}
}

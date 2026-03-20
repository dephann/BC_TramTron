using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjSilo : ObjectBase
	{
		[DataMember]
		public int SiloID { get; set; }

		[DataMember]
		public string MaSilo { get; set; }

		[DataMember]
		public string TenSilo { get; set; }

		[DataMember]
		public int NhomSiloID { get; set; }

		[DataMember]
		public int? SoTT { get; set; }

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
		public decimal? K_Pulse { get; set; }

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
		public decimal? KLDT_DungTruoc1 { get; set; }

		[DataMember]
		public decimal? KLDT_DungTruoc2 { get; set; }

		[DataMember]
		public decimal? KLDT_DungTruoc3 { get; set; }

		[DataMember]
		public int? TinhDoHutNuocID { get; set; }

		[DataMember]
		public string TinhDoHutNuocName { get; set; }

		[DataMember]
		public decimal? DoAm_NhomSlioAgg { get; set; }

		[DataMember]
		public decimal? DoHutNuoc_NhomSiloAgg { get; set; }

		[DataMember]
		public decimal? SoiTrongCat_NhomSiloAgg { get; set; }

		[DataMember]
		public int? SoiTrongCat_TruVaoSilo_NhomSiloAgg { get; set; }

		[DataMember]
		public int? MaterialID { get; set; }

		[DataMember]
		public string MaterialCode { get; set; }

		[DataMember]
		public string MaterialName { get; set; }

		[DataMember]
		public bool? Activated { get; set; }

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
        public bool? BuTruKLMT { get; set; }
        [DataMember]
        public bool? TuDongXNCD { get; set; }
    }
}

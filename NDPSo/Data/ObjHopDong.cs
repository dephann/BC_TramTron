using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjHopDong : ObjectBase
	{
		[DataMember]
		public int HopDongID { get; set; }

		[DataMember]
		public string MaHopDong { get; set; }

		[DataMember]
		public string TenHopDong { get; set; }

		[DataMember]
		public DateTime? NgayHopDong { get; set; }

		[DataMember]
		public string MoTa { get; set; }

		[DataMember]
		public int? KhachHangID { get; set; }

		[DataMember]
		public int? CongTruongID { get; set; }

		[DataMember]
		public int? MACID { get; set; }

		[DataMember]
		public int? HangMucID { get; set; }

		[DataMember]
		public string DoSut { get; set; }

		[DataMember]
		public decimal? KLDatHang { get; set; }

		[DataMember]
		public decimal? KLDaGiao { get; set; }

		[DataMember]
		public decimal? KLConLai { get; set; }

		[DataMember]
		public decimal? KLTaoPhieuTron { get; set; }

		[DataMember]
		public int? TongPhieu { get; set; }

		[DataMember]
		public int? Status { get; set; }

		[DataMember]
		public decimal? DLT_KLDuTinh { get; set; }

		[DataMember]
		public decimal? DLT_KLTronNhoNhat { get; set; }

		[DataMember]
		public decimal? DLT_KLTronLonNhat { get; set; }

		[DataMember]
		public decimal? DLT_KLDuTinhCuaTungMe { get; set; }

		[DataMember]
		public decimal? DLT_KLDuTinhCuaTungMe_NoiB { get; set; }

		[DataMember]
		public bool DLT_KLDuTinhCuaTungMe_NoiB_IsUsed { get; set; }

		[DataMember]
		public decimal? DLT_KLBuTruMeCuoi { get; set; }

		[DataMember]
		public decimal? DLT_SLMeDuTinh { get; set; }

		[DataMember]
		public decimal? DLT_KLXeChoLonNhat { get; set; }

		[DataMember]
		public decimal? DLT_MACSUMSiloValueCalc { get; set; }

		[DataMember]
		public decimal? DLT_MACSUMSiloValue { get; set; }

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
		public string NPKhachHangMaKhachHang { get; set; }

		[DataMember]
		public string NPKhachHangTenKhachHang { get; set; }

		[DataMember]
		public string NPCongTruongMaCongTruong { get; set; }

		[DataMember]
		public string NPCongTruongTenCongTruong { get; set; }

		[DataMember]
		public string NPMACMaMAC { get; set; }

		[DataMember]
		public string NPMACTenMAC { get; set; }

		[DataMember]
		public decimal NPMACThemBotNuoc1 { get; set; }

		[DataMember]
		public decimal NPMACThemBotNuoc2 { get; set; }

		public decimal? KLLyThuyetCoTheTaoPT
		{
			get
			{
				decimal? temp = new decimal?(0m);
				decimal? kldaGiao = this.KLDaGiao;
				decimal? num = this.KLTaoPhieuTron;
				if (kldaGiao.GetValueOrDefault() > num.GetValueOrDefault() & (kldaGiao != null & num != null))
				{
					temp = this.KLDatHang - this.KLDaGiao;
				}
				else
				{
					temp = this.KLDatHang - this.KLTaoPhieuTron;
				}
				num = temp;
				decimal d = 0m;
				if (num.GetValueOrDefault() < d & num != null)
				{
					temp = new decimal?(0m);
				}
				return temp;
			}
		}

		public string StatusDisplay
		{
			get
			{
				return string.Empty;
			}
		}
	}
}

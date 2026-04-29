using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjDuLieuTron : ObjectBase
	{
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

		public string NPStatus
		{
			get
			{
				return this.Status.ToString();
			}
		}

		public string Status2
		{
			get
			{
				return this._Status2;
			}
			set
			{
				this._Status2 = value;
			}
		}

		[DataMember]
		public int DuLieuTronID { get; set; }

		[DataMember]
		public int? HopDongID { get; set; }

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
		public int? Status { get; set; }

		[DataMember]
		public int? LastStatus { get; set; }

		[DataMember]
		public int LnNo { get; set; }

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
		public int? TongPhieu { get; set; }

		[DataMember]
		public bool Activated { get; set; }

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
		public DateTime? ThoiGianGiaoHang { get; set; }

		/// <summary>
		/// Critical Ratio = thời gian còn lại / thời gian xử lý ước tính
		/// CR &lt; 1.0 = đã trễ, 1.0–1.5 = sắp trễ, &gt; 1.5 = an toàn
		/// </summary>
		public double? CriticalRatio
		{
			get
			{
				if (!ThoiGianGiaoHang.HasValue) return null;
				double slMe = (double)(DLT_SLMeDuTinh ?? 1m);
				double estimatedMinutes = slMe * 5.0; // ước tính 5 phút/mẻ
				if (estimatedMinutes <= 0) return null;
				double remainingMinutes = (ThoiGianGiaoHang.Value - DateTime.Now).TotalMinutes;
				return remainingMinutes / estimatedMinutes;
			}
		}

		/// <summary>Trạng thái thời gian giao hàng dựa theo CR</summary>
		public string TrangThaiThoiGian
		{
			get
			{
				if (!ThoiGianGiaoHang.HasValue) return "";
				double? cr = CriticalRatio;
				if (cr == null) return "";
				if (cr < 1.0) return "TRỄ";
				if (cr < 1.5) return "SẮP TRỄ";
				return "ĐÚNG HẠN";
			}
		}

		private string _Status2 = "1";
	}
}

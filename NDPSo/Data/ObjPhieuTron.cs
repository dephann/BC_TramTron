using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjPhieuTron : ObjectBase
	{
		[DataMember]
		public int PhieuTronID { get; set; }

		[DataMember]
		public string MaPhieuTron { get; set; }

		[DataMember]
		public int? NoPhieu { get; set; }

		[DataMember]
		public DateTime? NgayPhieuTron { get; set; }

		[DataMember]
		public decimal? KLDuTinh { get; set; }

		[DataMember]
		public decimal? KLThuc { get; set; }

		[DataMember]
		public decimal? KLTronNhoNhat { get; set; }

		[DataMember]
		public decimal? KLTronLonNhat { get; set; }

		[DataMember]
		public decimal? KLDuTinhCuaTungMe { get; set; }

		[DataMember]
		public decimal? KLBuTruMeCuoi { get; set; }

		[DataMember]
		public decimal? SLMeDuTinh { get; set; }

		[DataMember]
		public decimal? SLMeHieuChinh { get; set; }

		[DataMember]
		public decimal? SLMeDaTron { get; set; }

		[DataMember]
		public int? HopDongID { get; set; }

		[DataMember]
		public int? KhachHangID { get; set; }

		[DataMember]
		public int? CongTruongID { get; set; }

		[DataMember]
		public int? MACID { get; set; }

		[DataMember]
		public int? HangMucID { get; set; }

		[DataMember]
		public string MoTa { get; set; }

		[DataMember]
		public int? Status { get; set; }

		[DataMember]
		public int? NguoiTron { get; set; }

		[DataMember]
		public DateTime? ThoiGianTron { get; set; }

		[DataMember]
		public bool? IsQueued { get; set; }

		[DataMember]
		public decimal? MinKLTron { get; set; }

		[DataMember]
		public decimal? MaxKLTron { get; set; }

		[DataMember]
		public decimal? MaxKLXeCho { get; set; }

		[DataMember]
		public int? XeID { get; set; }

		[DataMember]
		public int? TaiXeID { get; set; }
		[DataMember]
		public int? NhanVienID { get; set; }

		[DataMember]
		public DateTime? CreationDate { get; set; }

		[DataMember]
		public int? CreatedBy { get; set; }

		[DataMember]
		public DateTime? LatestUpdateDate { get; set; }

		[DataMember]
		public int? LatestUpdatedBy { get; set; }

		[DataMember]
		public string NPHopDongMaHopDong { get; set; }

		[DataMember]
		public string NPHopDongTenHopDong { get; set; }

		[DataMember]
		public string NPHangMucTenHangMuc { get; set; }
		[DataMember]
		public string NPKhachHangTenKhachHang { get; set; }
		[DataMember]
		public string NPCongTruongTenCongTruong { get; set; }
		[DataMember]
		public string NPCongTruongDiaChi { get; set; }

		[DataMember]
		public string NPTaiXeMaTaiXe { get; set; }
		[DataMember]
		public string NPTaiXeTenTaiXe { get; set; }

		[DataMember]
		public string NPXeBienSo { get; set; }
		[DataMember]
		public string NPNhanVienTenNhanVien { get; set; }

		[DataMember]
		public string NPMACMaMAC { get; set; }

		[DataMember]
		public string NPMACTenMAC { get; set; }

		[DataMember]
		public int NPMACMACID { get; set; }
		[DataMember]
		public string NPMACCuongDo { get; set; }
		[DataMember]
		public string NPMACDoSut { get; set; }
		[DataMember]
		public decimal? NPHopDongKLDatHang { get; set; }
		[DataMember]
		public decimal? NPHopDongKLDaGiao { get; set; }
	}
}

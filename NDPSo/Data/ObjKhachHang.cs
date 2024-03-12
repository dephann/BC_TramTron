using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjKhachHang : ObjectBase
	{
		[DataMember]
		public int KhachHangID { get; set; }

		[DataMember]
		public string MaKhachHang { get; set; }

		[DataMember]
		public string TenKhachHang { get; set; }

		[DataMember]
		public string GioiTinh { get; set; }

		[DataMember]
		public string DiaChi { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public string Phone { get; set; }

		[DataMember]
		public string Fax { get; set; }

		[DataMember]
		public string GhiChu { get; set; }

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
	}
}

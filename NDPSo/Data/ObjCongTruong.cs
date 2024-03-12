using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjCongTruong : ObjectBase
	{
		[DataMember]
		public int CongTruongID { get; set; }

		[DataMember]
		public string MaCongTruong { get; set; }

		[DataMember]
		public string TenCongTruong { get; set; }

		[DataMember]
		public string DiaChi { get; set; }

		[DataMember]
		public string Phone { get; set; }

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

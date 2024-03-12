using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjXe : ObjectBase
	{
		[DataMember]
		public int XeID { get; set; }

		[DataMember]
		public string BienSo { get; set; }

		[DataMember]
		public decimal? KhoiLuong { get; set; }

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

using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjTinhDoHutNuocChiTiet : ObjectBase
	{
		[DataMember]
		public int TinhDoHutNuocChiTietID { get; set; }

		[DataMember]
		public int TinhDoHutNuocID { get; set; }

		[DataMember]
		public string KichCo { get; set; }

		[DataMember]
		public decimal Percentage { get; set; }

		[DataMember]
		public decimal Value { get; set; }

		[DataMember]
		public byte[] VersionNo { get; set; }

		[DataMember]
		public DateTime? CreationDate { get; set; }

		[DataMember]
		public int? CreatedBy { get; set; }

		[DataMember]
		public DateTime? LatestUpdateDate { get; set; }

		[DataMember]
		public int? LatestUpdatedBy { get; set; }
	}
}

using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjEventActionCode : ObjectBase
	{
		[DataMember]
		public int EventActionCodeID { get; set; }

		[DataMember]
		public string Code { get; set; }

		[DataMember]
		public int? CodeNumber { get; set; }

		[DataMember]
		public string Content { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int? LnNo { get; set; }

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

using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjEventLog : ObjectBase
	{
		[DataMember]
		public int EventLogID { get; set; }

		[DataMember]
		public string LogCode { get; set; }

		[DataMember]
		public DateTime LogDate { get; set; }

		[DataMember]
		public int? UserID { get; set; }

		[DataMember]
		public string UserName { get; set; }

		[DataMember]
		public int EventActionCodeID { get; set; }

		[DataMember]
		public string EventActionContent { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public decimal? OldValueNumeric { get; set; }

		[DataMember]
		public decimal? NewValueNumeric { get; set; }

		[DataMember]
		public string OldValueText { get; set; }

		[DataMember]
		public string NewValueText { get; set; }

		[DataMember]
		public string Title1 { get; set; }

		[DataMember]
		public decimal? Value1 { get; set; }

		[DataMember]
		public string Content1 { get; set; }

		[DataMember]
		public string Title2 { get; set; }

		[DataMember]
		public decimal? Value2 { get; set; }

		[DataMember]
		public string Content2 { get; set; }

		[DataMember]
		public string Title3 { get; set; }

		[DataMember]
		public decimal? Value3 { get; set; }

		[DataMember]
		public string Content3 { get; set; }

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

using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjWeiSiloSaving : ObjectBase
	{
		[DataMember]
		public int WeiSiloSavingID { get; set; }

		[DataMember]
		public string MaCan { get; set; }

		[DataMember]
		public string MaSilo { get; set; }

		[DataMember]
		public string GhiChu { get; set; }

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

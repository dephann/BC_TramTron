using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjNhomSilo : ObjectBase
	{
		[DataMember]
		public int NhomSiloID { get; set; }

		[DataMember]
		public string MaNhomSilo { get; set; }

		[DataMember]
		public string TenNhomSilo { get; set; }

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

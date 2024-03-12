using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjMACSilo : ObjectBase
	{
		[DataMember]
		public int MACSiloID { get; set; }

		[DataMember]
		public int MACID { get; set; }

		[DataMember]
		public int SiloID { get; set; }

		[DataMember]
		public decimal? SiloValue { get; set; }

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

		[DataMember]
		public string NPSiloMaSilo { get; set; }

		[DataMember]
		public string NPSiloTenSilo { get; set; }
		[DataMember]
		public string NPSiloMaterialName { get; set; }
	}
}

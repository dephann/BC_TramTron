using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjMaterial : ObjectBase
	{
		[DataMember]
		public int MaterialID { get; set; }

		[DataMember]
		public string MaterialCode { get; set; }

		[DataMember]
		public string MaterialName { get; set; }
		[DataMember]
		public string Supplier { get; set; }
		[DataMember]
		public int? Unit { get; set; }
		[DataMember]
		public string UnitName { get; set; }
		[DataMember]
		public decimal? Price { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public bool Activated { get; set; }

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

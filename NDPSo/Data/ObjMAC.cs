using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjMAC : ObjectBase
	{
		[DataMember]
		public List<ObjMACSilo> LstMACSilo { get; set; }

		[DataMember]
		public decimal? NPSUMSiloValue { get; set; }

		[DataMember]
		public int MACID { get; set; }

		[DataMember]
		public string MaMAC { get; set; }

		[DataMember]
		public string TenMAC { get; set; }

		[DataMember]
		public string GhiChu { get; set; }

		[DataMember]
		public string DoSut { get; set; }

		[DataMember]
		public decimal ThemBotNuoc1 { get; set; }

		[DataMember]
		public decimal ThemBotNuoc2 { get; set; }

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

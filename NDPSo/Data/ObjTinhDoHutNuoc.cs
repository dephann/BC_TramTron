using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjTinhDoHutNuoc : ObjectBase
	{
		public BindingList<ObjTinhDoHutNuocChiTiet> BLstTinhDoHutNuocChiTiet { get; set; }

		[DataMember]
		public int TinhDoHutNuocID { get; set; }

		[DataMember]
		public string MaTinhDoHutNuoc { get; set; }

		[DataMember]
		public DateTime NgayTinhDoHut { get; set; }

		[DataMember]
		public int NhomSiloID { get; set; }

		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public decimal DoHutNuoc { get; set; }

		[DataMember]
		public string Description { get; set; }

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

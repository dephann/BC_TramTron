using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjSEC_Role : ObjectBase
	{
		[DataMember]
		public bool NPSelect { get; set; }

		[DataMember]
		public int RoleID { get; set; }

		[DataMember]
		public string RoleName { get; set; }

		[DataMember]
		public string Description { get; set; }

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

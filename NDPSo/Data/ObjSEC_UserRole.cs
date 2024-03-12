using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjSEC_UserRole : ObjectBase
	{
		[DataMember]
		public int UserRoleID { get; set; }

		[DataMember]
		public int UserID { get; set; }

		[DataMember]
		public int RoleID { get; set; }

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

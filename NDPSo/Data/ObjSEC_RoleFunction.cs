using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjSEC_RoleFunction : ObjectBase
	{
		[DataMember]
		public int RoleFunctionID { get; set; }

		[DataMember]
		public int RoleID { get; set; }

		[DataMember]
		public int FunctionID { get; set; }

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

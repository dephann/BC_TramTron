using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjSEC_User : ObjectBase
	{
		[DataMember]
		public int UserID { get; set; }

		[DataMember]
		public string UserName { get; set; }

		[DataMember]
		public string Password { get; set; }

		[DataMember]
		public string FullName { get; set; }

		[DataMember]
		public string Department { get; set; }

		[DataMember]
		public string Email { get; set; }

		[DataMember]
		public string Phone { get; set; }

		[DataMember]
		public string CellPhone { get; set; }

		[DataMember]
		public bool? IsActived { get; set; }

		[DataMember]
		public bool? IsInUse { get; set; }

		[DataMember]
		public DateTime? CreationDate { get; set; }

		[DataMember]
		public int? CreatedBy { get; set; }

		[DataMember]
		public DateTime? LatestUpdateDate { get; set; }

		[DataMember]
		public int? LatestUpdatedBy { get; set; }

		[DataMember]
		public string NPOtherInfo { get; set; }
	}
}

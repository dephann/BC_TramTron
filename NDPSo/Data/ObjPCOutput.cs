using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjPCOutput : ObjectBase
	{
		[DataMember]
		public int PCOutputID { get; set; }

		[DataMember]
		public string Code { get; set; }

		[DataMember]
		public decimal Value { get; set; }

		[DataMember]
		public string Description { get; set; }
	}
}

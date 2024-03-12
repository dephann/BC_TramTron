using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjPCInput : ObjectBase
	{
		[DataMember]
		public int PCInputID { get; set; }

		[DataMember]
		public string Code { get; set; }

		[DataMember]
		public decimal Value { get; set; }

		[DataMember]
		public string Description { get; set; }
	}
}

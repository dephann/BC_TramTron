using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjSEC_TypeInfo : ObjectBase
	{
		[DataMember]
		public int TypeInfoID { get; set; }

		[DataMember]
		public string TypeInfo { get; set; }

		[DataMember]
		public int? AssemblyID { get; set; }

		[DataMember]
		public string NPSEC_AssemblyAssemblyInfo { get; set; }
	}
}

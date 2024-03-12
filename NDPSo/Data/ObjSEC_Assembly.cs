using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjSEC_Assembly : ObjectBase
	{
		[DataMember]
		public int AssemblyID { get; set; }

		[DataMember]
		public string AssemblyInfo { get; set; }
	}
}

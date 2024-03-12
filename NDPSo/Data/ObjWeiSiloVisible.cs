using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjWeiSiloVisible : ObjectBase
	{
		[DataMember]
		public int WeiSiloVisibleID { get; set; }

		[DataMember]
		public string Code { get; set; }

		[DataMember]
		public int Type { get; set; }

		[DataMember]
		public bool Visible { get; set; }
	}
}

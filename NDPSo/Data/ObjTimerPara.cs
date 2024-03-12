using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjTimerPara : ObjectBase
	{
		[DataMember]
		public int TimerParaID { get; set; }

		[DataMember]
		public string TimerParaCode { get; set; }

		[DataMember]
		public decimal? TimerParaValue { get; set; }

		[DataMember]
		public string Description { get; set; }
	}
}

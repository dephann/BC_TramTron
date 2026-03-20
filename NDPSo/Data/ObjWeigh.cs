using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjWeigh : ObjectBase
	{
		[DataMember]
		public int WeighID { get; set; }

		[DataMember]
		public string WeighCode { get; set; }

		[DataMember]
		public string WeighName { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int? STT { get; set; }

		[DataMember]
		public decimal? Zero { get; set; }

		[DataMember]
		public decimal? Max { get; set; }

		[DataMember]
		public decimal? Offset { get; set; }

		[DataMember]
		public decimal? KLEmpty { get; set; }

		[DataMember]
		public decimal? TimeEmpty { get; set; }

		[DataMember]
		public decimal? Limit { get; set; }

		[DataMember]
		public decimal? WeiToVib { get; set; }

		[DataMember]
		public decimal? TON { get; set; }

		[DataMember]
		public decimal? TOFF { get; set; }

		[DataMember]
		public decimal? Spare { get; set; }

		[DataMember]
		public decimal? TiLeXa { get; set; }

        [DataMember]
        public bool? GiuKLTC { get; set; }
    }
}

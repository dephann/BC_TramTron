using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjMeTron : ObjectBase
	{
		[DataMember]
		public int MeTronID { get; set; }

		[DataMember]
		public int? LnNo { get; set; }

		[DataMember]
		public DateTime? NgayMeTron { get; set; }

		[DataMember]
		public decimal? KhoiLuong { get; set; }

		[DataMember]
		public int PhieuTronID { get; set; }

		[DataMember]
		public string MoTa { get; set; }

		[DataMember]
		public int? Status { get; set; }

		[DataMember]
		public bool? IsManual { get; set; }

		[DataMember]
		public bool? IsDeleted { get; set; }

		[DataMember]
		public int? DeletedBy { get; set; }

		[DataMember]
		public string DeleteReason { get; set; }

		[DataMember]
		public DateTime? CreationDate { get; set; }

		[DataMember]
		public int? CreatedBy { get; set; }

		[DataMember]
		public DateTime? LatestUpdateDate { get; set; }

		[DataMember]
		public int? LatestUpdatedBy { get; set; }

		[DataMember]
		public string NPPhieuTronMaPhieuTron { get; set; }

		[DataMember]
		public List<ObjMeTronChiTiet> LstMeTronChiTiet { get; set; }
	}
}

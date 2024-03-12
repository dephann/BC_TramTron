using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjSEC_Function : ObjectBase
	{
		[DataMember]
		public int FunctionID { get; set; }

		[DataMember]
		public string FunctionCode { get; set; }

		[DataMember]
		public string FunctionName { get; set; }

		[DataMember]
		public string MenuName { get; set; }

		[DataMember]
		public string OtherName { get; set; }

		[DataMember]
		public int? FunctionType { get; set; }

		[DataMember]
		public int? ParentID { get; set; }

		[DataMember]
		public bool? IsStatic { get; set; }

		[DataMember]
		public bool? ShowAsBarItem { get; set; }

		[DataMember]
		public int? DisplayOrder { get; set; }

		[DataMember]
		public bool? BeginAsAGroup { get; set; }

		[DataMember]
		public bool? Visible { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public int? TypeInfoID { get; set; }

		[DataMember]
		public DateTime? CreationDate { get; set; }

		[DataMember]
		public int? CreatedBy { get; set; }

		[DataMember]
		public DateTime? LatestUpdateDate { get; set; }

		[DataMember]
		public int? LatestUpdatedBy { get; set; }

		[DataMember]
		public bool NPSelect { get; set; }

		public List<ObjSEC_Function> LstChildFunction { get; set; }
	}
}

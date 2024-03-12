using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
	[DataContract]
	public class ObjectBase
	{
		[DataMember]
		public bool MarkAsDeleted
		{
			get
			{
				return this._markAsDeleted;
			}
			set
			{
				this._markAsDeleted = value;
			}
		}

		[DataMember]
		public bool IsNewObject
		{
			get
			{
				return this._isNewObject;
			}
			set
			{
				this._isNewObject = value;
			}
		}

		private bool _markAsDeleted;

		private bool _isNewObject = true;
	}
}

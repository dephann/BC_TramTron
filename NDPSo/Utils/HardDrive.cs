using System;

namespace NDPSo.Utils
{
	internal class HardDrive
	{
		public string Model
		{
			get
			{
				return this.model;
			}
			set
			{
				this.model = value;
			}
		}

		public string Type
		{
			get
			{
				return this.type;
			}
			set
			{
				this.type = value;
			}
		}

		public string SerialNo
		{
			get
			{
				return this.serialNo;
			}
			set
			{
				this.serialNo = value;
			}
		}

		private string model;

		private string type;

		private string serialNo;
	}
}

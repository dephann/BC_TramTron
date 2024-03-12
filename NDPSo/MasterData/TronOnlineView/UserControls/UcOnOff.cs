using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    public partial class UcOnOff : DevExpress.XtraEditors.XtraUserControl
    {
		private Bitmap _iconOff = ResourceNDP.Led_Dark;

		private Bitmap _iconOn = ResourceNDP.Led_red;

		private bool _isOn = true;

		private OffMode _offMode;
		private MyColor _colorLed;

		public enum MyColor
		{
			Green,
			Red,
			Yellow
		}
		public MyColor ColorLed
        {
			get => this._colorLed;
            set
            {
				this._colorLed = value;
                switch (_colorLed)
                {
					case MyColor.Green:
						this._iconOn = ResourceNDP.Led_Green;
						return;
					case MyColor.Red:
						this._iconOn = ResourceNDP.Led_red;
						return;
					case MyColor.Yellow:
						this._iconOn = ResourceNDP.Led_Yellow;
						return;
				}
					
            }
        }
		public enum OffMode
		{
			Default,
			IconOff
		}
		public UcOnOff()
        {
            InitializeComponent();
			
        }
		
		private void SetOffIcon(OffMode offMode)
		{
			switch (offMode)
			{
				case OffMode.Default:
				case OffMode.IconOff:
					this.picOnOff.EditValue = this._iconOff;
					return;

				default:
					return;
			}
		}

		public bool IsOn
		{
			get
			{
				return this._isOn;
			}
			set
			{
				this._isOn = value;
				if (this._isOn)
				{
					this.picOnOff.EditValue = this._iconOn;
					return;
				}
				this.SetOffIcon(this._offMode);
			}
		}
	}
}

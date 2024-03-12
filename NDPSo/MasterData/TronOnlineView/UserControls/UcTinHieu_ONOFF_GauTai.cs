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
    public partial class UcTinHieu_ONOFF_GauTai : DevExpress.XtraEditors.XtraUserControl
    {
		private Bitmap _iconOff = ResourceNDP.TinHieu_OnOff_GauTai;

		private Bitmap _iconOn = ResourceNDP.TinHieu_On_GauTai;

		private bool _isOn = true;

		private OffMode _offMode;

		public enum OffMode
		{
			Default,
			IconOff
		}
		public UcTinHieu_ONOFF_GauTai()
        {
            InitializeComponent();
        }
		private void SetOffIcon(OffMode offMode)
		{
			switch (offMode)
			{
				case OffMode.Default:
				case OffMode.IconOff:
					this.pictureEdit1.EditValue = this._iconOff;
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
					this.pictureEdit1.EditValue = this._iconOn;
					return;
				}
				this.SetOffIcon(this._offMode);
			}
		}
	}
}

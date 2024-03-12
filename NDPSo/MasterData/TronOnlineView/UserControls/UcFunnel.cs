using NDPSo.Properties;
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
    public partial class UcFunnel : UserControl
    {
		public event DelCaptionEventHandler FunnelClick;
		public delegate void DelCaptionEventHandler(object sender, EventArgs e);
		private bool _isFull;

		public bool IsFull
		{
			get
			{
				return this._isFull;
			}
			set
			{
				this._isFull = value;
				if (value)
				{
					this.picBackground.BackgroundImage = ResourceNDP.FunnelYellow;
					return;
				}
				this.picBackground.BackgroundImage = ResourceNDP.FunnelBlue;
			}
		}
		public UcFunnel()
        {
            InitializeComponent();
        }

        private void picBackground_Click(object sender, EventArgs e)
        {
			if (this.FunnelClick == null)
				return;
			this.FunnelClick((object)this, new EventArgs());
		}
    }
}

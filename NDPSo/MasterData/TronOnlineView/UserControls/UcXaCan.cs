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
    public partial class UcXaCan : DevExpress.XtraEditors.XtraUserControl
    {
        private MyColor _iconColor = MyColor.Blue;
        public UcXaCan()
        {
            InitializeComponent();
        }

        public enum MyColor
        {
            Blue,
            Red
        }
		public MyColor IconColor
		{
			get
			{
				return this._iconColor;
			}
			set
			{
				this._iconColor = value;
				switch (this._iconColor)
				{
					case MyColor.Blue:
						this.picArrow.Image = ResourceNDP.Arrow_Blue;
						return;
					case MyColor.Red:
						this.picArrow.Image = ResourceNDP.Arrow_Red;
						return;
					default:
						return;
				}
			}
		}
	}
}

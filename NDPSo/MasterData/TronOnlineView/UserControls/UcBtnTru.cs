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
    public partial class UcBtnTru : UserControl
    {
        private Bitmap _color_Click;
        private Bitmap _color_NoClick;
        private bool _isOn;

        public event DelButtonEventHandler ButtonClick;
        public delegate void DelButtonEventHandler(object sender, EventArgs e);
        public bool IsOn
        {
            get => this._isOn;
            set
            {
                this._isOn = value;
            }
        }
        public Bitmap Color_Click
        {
            get => this._color_Click;
            set
            {
                this._color_Click = value;
            }
        }
        public Bitmap Color_NoClick
        {
            get => this._color_NoClick;
            set
            {
                this._color_NoClick = value;
            }
        }

        public UcBtnTru()
        {
            InitializeComponent();
        }

        private void UcBtnTru_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick == null)
            {
                return;
            }
            this.ButtonClick((object)this, new EventArgs());
            IsOn = true;
        }

        private void UcBtnTru_MouseDown(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = Color_Click;
        }

        private void UcBtnTru_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackgroundImage = Color_NoClick;
        }
    }
}

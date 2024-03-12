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
    public partial class UcButtonF : DevExpress.XtraEditors.XtraUserControl
    {
        private Bitmap _color_Click = ResourceNDP.Btn_F_Click;
        private Bitmap _color_NoClick = ResourceNDP.Btn_F;
        private bool _isOn;

        public event DelButtonEventHandler ButtonMouseDown;

        public event DelButtonEventHandler ButtonMouseUp;

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

        public UcButtonF()
        {
            InitializeComponent();
        }

       
        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseDown == null)
                return;
            this.ButtonMouseDown((object)this, new EventArgs());
            this.pictureEdit1.BackgroundImage = Color_Click;
            IsOn = true;
        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseUp == null)
                return;
            this.ButtonMouseUp((object)this, new EventArgs());
            this.pictureEdit1.BackgroundImage = Color_NoClick;
            IsOn = false;
        }
    }
}

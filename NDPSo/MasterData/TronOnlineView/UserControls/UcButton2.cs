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
    public partial class UcButton2 : DevExpress.XtraEditors.XtraUserControl
    {

        private Color _color_Click;
        private Color _color_NoClick;
        private bool _isOn;
        private string _caption;

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
        public string Caption
        {
            get => this._caption;
            set
            {
                this._caption = value;
                this.labelControl1.Text = _caption;
            }
        }
        public Color Color_Click
        {
            get => this._color_Click;
            set
            {
                this._color_Click = value;
                this.labelControl1.BackColor = _color_Click;
            }
        }
        public Color Color_NoClick
        {
            get => this._color_NoClick;
            set
            {
                this._color_NoClick = value;
                this.labelControl1.BackColor = _color_NoClick;
            }
        }
        public UcButton2()
        {
            InitializeComponent();
        }
        private void UcBtnRun_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick == null)
            {
                return;
            }
            this.ButtonClick((object)this, new EventArgs());
            IsOn = true;
        }

        private void UcBtnRun_MouseDown(object sender, MouseEventArgs e)
        {
            this.labelControl1.BackColor = Color_Click;
        }

        private void UcBtnRun_MouseUp(object sender, MouseEventArgs e)
        {
            this.labelControl1.BackColor = Color_NoClick;
        }
    }
}

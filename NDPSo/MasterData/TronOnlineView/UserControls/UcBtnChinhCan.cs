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
    public partial class UcBtnChinhCan : DevExpress.XtraEditors.XtraUserControl
    {

        private BGColorEnum _bgColor;
        public Color _color_MouseDown;
        public Color _color_MouseUp;
        private string _caption;
        private bool _isOn;

        public event DelButtonEventHandler ButtonClick;
        public event DelButtonEventHandler ButtonMoveDown_Click;
        public event DelButtonEventHandler ButtonMoveUp_Click;

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
                this.labelControl1.Text = this._caption;
            }
        }
        public Color ColorMouseDown
        {
            get => _color_MouseDown;
            set
            {
                this._color_MouseDown = value;
            }
        }
        public Color ColorBG
        {
            get => _color_MouseUp;
            set
            {
                this._color_MouseUp = value;
                this.BackColor = _color_MouseUp;
                
            }
        }
        
        public BGColorEnum BGColor
        {
            get => this._bgColor;
            set
            {
                this._bgColor = value;
                switch (this._bgColor)
                {
                    case BGColorEnum.Orange:
                        //this.BackColor = Color.Orange;
                        break;
                    case BGColorEnum.Dark:
                        //this.BackColor = Color.DarkGray;
                        break;
                    case BGColorEnum.Green:
                        //this.BackColor = Color.DarkGreen;
                        break;
                }
            }
        }
        public enum BGColorEnum
        {
            Orange,
            Dark,
            Green,
        }

        public UcBtnChinhCan()
        {
            InitializeComponent();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick == null)
                return;
            this.ButtonClick((object)this, new EventArgs());
            this.BackColor = ColorMouseDown;
        }

        private void labelControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ButtonMoveDown_Click == null)
                return;
            this.ButtonMoveDown_Click((object)this, new EventArgs());
            this.BackColor = ColorMouseDown;
            IsOn = true;
        }

        private void labelControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if(this.ButtonMoveUp_Click == null)
                return;
            this.ButtonMoveUp_Click((object)this, new EventArgs());
            this.BackColor = ColorBG;
            IsOn = false;
        }
    }
}

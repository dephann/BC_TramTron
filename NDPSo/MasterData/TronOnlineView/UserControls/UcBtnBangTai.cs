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
    public partial class UcBtnBangTai : System.Windows.Forms.UserControl
    {
        private string _caption;
        private bool _isOn;
        private BGColorEnum _bgColor;
        private Bitmap _colorClick = ResourceNDP.Button_BangTai_Click;
        private Bitmap _colorNoClick = ResourceNDP.Button_BangTai;

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
            get => this._colorClick;
            set
            {
                this._colorClick = value;
            }
        }
        public Bitmap Color_NoClick
        {
            get => this._colorNoClick;
            set
            {
                this._colorNoClick = value;
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
                    case BGColorEnum.Clik:
                        this.BackgroundImage = ResourceNDP.Button_BangTai_Click;
                        this.labelControl1.ForeColor = Color.White;
                        break;
                    case BGColorEnum.NoClick:
                        this.BackgroundImage = ResourceNDP.Button_BangTai;
                        this.labelControl1.ForeColor = Color.White;
                        break;

                }
            }
        }
        public enum BGColorEnum
        {
            Clik,
            NoClick,
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
        public UcBtnBangTai()
        {
            InitializeComponent();
            BGColor = BGColorEnum.NoClick;
        }

        private void labelControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseDown == null)
                return;
            this.ButtonMouseDown((object)this, new EventArgs());
            BGColor = BGColorEnum.Clik;
            IsOn = true;
        }

        private void labelControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseUp == null)
                return;
            this.ButtonMouseUp((object)this, new EventArgs());
            BGColor = BGColorEnum.NoClick;
            IsOn = false;
        }
    }
}

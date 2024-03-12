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

namespace NDPSo.MasterData
{
    public partial class UcButton : UserControl
    {
        private bool _isOn;
        private bool _isRun;
        private BGColorEnum _bgColor;
        private string _caption;
        private TrangThai _trangThai;

        public event DelButtonEventHandler ButtonClick;
        public delegate void DelButtonEventHandler(object sender, EventArgs e);


        public string Caption
        {
            get => this._caption;
            set
            {
                this._caption = value;
                this.labelControl1.Text = this._caption;
            }
        }

        public bool IsOn
        {
            get=> this._isOn;
            set
            {
                this._isOn = value;
                
            }
        }
        public bool IsRun
        {
            get => this._isRun;
            set
            {
                this._isRun = value;

            }
        }
        public enum TrangThai
        {
            Run,
            Stop
        }
        public TrangThai IsTrangThai
        {
            get => this._trangThai;
            set
            {
                _trangThai = value;
                switch (this._trangThai)
                {
                    case TrangThai.Run:
                        {
                            //this.labelControl1.Text = "CHẠY";
                            BGColor = BGColorEnum.Orange;
                            IsOn = false;
                            IsRun = true;

                            break;
                        }

                    case TrangThai.Stop:
                        {
                            //this.labelControl1.Text = "DỪNG";
                            BGColor = BGColorEnum.Green;
                            IsOn = true;
                            IsRun = false;
                            break;
                        }

                }
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
                        this.BackgroundImage = (Image)ResourceNDP.SquareButtonOrangeOff;
                        break;
                    case BGColorEnum.Dark:
                        this.BackgroundImage = (Image)ResourceNDP.SquareButtonDarkOff;
                        break;
                    case BGColorEnum.Green:
                        this.BackgroundImage = (Image)ResourceNDP.SquareButtonGreenOff;
                        break;
                }
            }
        }
        public UcButton()
        {
            InitializeComponent();
            IsTrangThai = TrangThai.Stop;
        }

        public enum BGColorEnum
        {
            Orange,
            Dark,
            Green,
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick == null)
                return;
            this.ButtonClick((object)this, new EventArgs());
            if (IsTrangThai == TrangThai.Run)
            {
                // Change to "STOP" state   
                IsTrangThai = TrangThai.Stop;
                

            }
            else if (IsTrangThai == TrangThai.Stop)
            {
                // Change to "RUN" state
                IsTrangThai = TrangThai.Run;
                
            }
        }

        

        
    }
}

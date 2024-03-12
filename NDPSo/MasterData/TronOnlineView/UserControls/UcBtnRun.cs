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
    public partial class UcBtnRun : UserControl
    {
        private Bitmap _color_Click;
        private Bitmap _color_NoClick;
        private bool _isOn;
       // private TrangThai _trangThai;

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
        public enum TrangThai
        {
            Run,
            Stop
        }
        /*public TrangThai IsTrangThai
        {
            *//*get => this._trangThai;
            set
            {
                _trangThai = value;
                switch (this._trangThai)
                {
                    case TrangThai.Run:
                        {
                            this.BackgroundImage = Color_NoClick;
                            IsOn = false;
                            break;
                        }

                    case TrangThai.Stop:
                        {
                            this.BackgroundImage = Color_Click;
                            IsOn = true;
                            break;
                        }
                }
            }*//*
        }
*/
        public UcBtnRun()
        {
            InitializeComponent();
            //IsTrangThai = TrangThai.Stop;
        }

        private void UcBtnRun_Click(object sender, EventArgs e)
        {
            /*if(this.ButtonClick == null)
            {
                return;
            }
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

            }*/
            if (this.ButtonClick == null)
            {
                return;
            }
            this.ButtonClick((object)this, new EventArgs());
            IsOn = true;

        }

        private void UcBtnRun_MouseDown(object sender, MouseEventArgs e)
        {
            /*this.BackgroundImage = Color_Click;
            IsOn = true;*/
            this.BackgroundImage = Color_Click;
        }

        private void UcBtnRun_MouseUp(object sender, MouseEventArgs e)
        {
            /* this.BackgroundImage = Color_NoClick;
             IsOn = false;*/
            this.BackgroundImage = Color_NoClick;
        }
    }
}

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
    public partial class UcButtonPauseWeight : DevExpress.XtraEditors.XtraUserControl
    {

        private bool _isOn;
        private bool _isRun;
        private BGColorEnum _bgColor;
        private TrangThai _trangThai;

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
                            BGColor = BGColorEnum.Red;

                            IsOn = false;
                            IsRun = true;

                            break;
                        }

                    case TrangThai.Stop:
                        {
                            BGColor = BGColorEnum.Gray;
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
                    case BGColorEnum.Red:
                        this.pictureEdit1.BackgroundImage = ResourceNDP.Pause_Weigh; 
                        break;
                    case BGColorEnum.Gray:
                        this.pictureEdit1.BackgroundImage = ResourceNDP.Btn_TamDungCan;
                        break;
                }
            }
        }

        public enum BGColorEnum
        {
            Red,
            Gray,
        }

        public UcButtonPauseWeight()
        {
            InitializeComponent();
            IsTrangThai = TrangThai.Stop;
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
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

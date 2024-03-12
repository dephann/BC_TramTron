using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    public partial class UcOnOff_NoiTron : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _isOn;
        private bool _isRun;
        private TrangThai _trangThai;
        public event DelCaptionEventHandler OnOff_NoiTronClick;
        public delegate void DelCaptionEventHandler(object sender, EventArgs e);
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
                            IsOn = false;
                            IsRun = true;
                            break;
                        }

                    case TrangThai.Stop:
                        {
                            IsOn = true;
                            IsRun = false;
                            break;
                        }
                }
            }
        }
        public UcOnOff_NoiTron()
        {
            InitializeComponent();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            if (this.OnOff_NoiTronClick == null)
                return;
            this.OnOff_NoiTronClick((object)this, new EventArgs());
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

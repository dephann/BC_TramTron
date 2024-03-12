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
    public partial class UcBaoDongThungCan : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _isOn;
        private bool _isRun;
        private BGColorEnum _bgColor;
        private TrangThai _trangThai;

        public bool IsOn
        {
            get => this._isOn;
            set
            {
                this._isOn = value;
                if (this._isOn)
                {
                    this.pictureEdit1.BackColor = Color.FromArgb(0, 70, 255);
                }
                else
                {
                    this.pictureEdit1.BackColor = Color.DarkGray;
                }
                
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
                /*switch (this._trangThai)
                {
                    case TrangThai.Run:
                        {
                            BGColor = BGColorEnum.Blue;
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
                }*/
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
                    case BGColorEnum.Blue:
                        this.pictureEdit1.BackColor = Color.FromArgb(0, 70, 255);
                        break;
                    case BGColorEnum.Gray:
                        this.pictureEdit1.BackColor = Color.DarkGray;
                        break;
                }
            }
        }

        public enum BGColorEnum
        {
            Blue,
            Gray,
        }

        public UcBaoDongThungCan()
        {
            InitializeComponent();
        }
    }
}

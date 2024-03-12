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
    public partial class UcButtonBangTai : DevExpress.XtraEditors.XtraUserControl
    {
        public bool isRunning = false;
        public bool isStopped = true;
        private BGColorEnum _bgColor;
        public event DelButtonEventHandler ButtonClick;
        public delegate void DelButtonEventHandler(object sender, EventArgs e);
       
        public UcButtonBangTai()
        {
            InitializeComponent();
            this.labelControl1.Text = "CHẠY";
            BGColor = BGColorEnum.Blue;
            isRunning = false;
            isStopped = true;
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
                        this.labelControl1.BackColor = Color.Blue;
                        break;
                    case BGColorEnum.Dark:
                        this.labelControl1.BackColor = Color.DimGray;
                        break;
                }
            }
        }
        public enum BGColorEnum
        {
            Blue,
            Dark,
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick == null)
                return;
            this.ButtonClick((object)this, new EventArgs());
            if (isRunning)
            {
                // Change to "STOP" state
                this.labelControl1.Text = "DỪNG";
                BGColor = BGColorEnum.Dark;
                isRunning = false;
                isStopped = true;
            }
            else if (isStopped)
            {
                // Change to "RUN" state
                this.labelControl1.Text = "CHẠY";
                BGColor = BGColorEnum.Blue;
                isRunning = true;
                isStopped = false;
            }
        }
    }
}

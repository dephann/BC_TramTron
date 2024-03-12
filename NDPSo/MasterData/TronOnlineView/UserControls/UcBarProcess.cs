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
    public partial class UcBarProcess : DevExpress.XtraEditors.XtraUserControl
    {

        private Double _percent;
        private int _width;
        private PictureEdit _picProcess;
        private PictureEdit _picBG;
        public Double Percent
        {
            get => this._percent;
            set
            {
                if(_percent <= 0)
                    this._percent = 0;
                else if(_percent > 100)
                    this._percent = 100;
                this._percent = value;
                 _picProcess.Width = (int)(this._percent * _picBG.Width) / 100;
                if(_percent < 90)
                {
                    this._picProcess.BackColor = Color.LimeGreen;
                }
                else if(_percent >= 90)
                {
                    this._picProcess.BackColor = Color.Red;
                }
            }
        }

        public UcBarProcess()
        {
            InitializeComponent();
            _picProcess = this.picProcess;
            _picBG = this.picBG;
        }
    }
}

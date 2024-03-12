using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo
{
    public partial class FrmPLCPort : DialogViewBase
    {
        private string _plcPort = string.Empty;
        public string PLCPortName => this._plcPort;
        public FrmPLCPort()
        {
            InitializeComponent();
            this.luePLCPort.Properties.DataSource = (object)SerialPort.GetPortNames();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.luePLCPort.ItemIndex == -1)
            {
                this.luePLCPort.ErrorText = "Please select a Port";
            }
            else
            {
                this._plcPort = this.luePLCPort.EditValue.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
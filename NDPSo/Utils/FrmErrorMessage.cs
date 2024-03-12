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

namespace NDPSo.Utils
{
    public partial class FrmErrorMessage : DevExpress.XtraEditors.XtraForm
    {
        private int _originSize;
        private int _fixedSize;
        private bool _showException;
        private string _alertMsg = "Error in system.\nPlease contact with Aministrator for more detail.";
        private string _errorContent = string.Empty;

        public string AlertMessage
        {
            get => this._alertMsg;
            set => this._alertMsg = value;
        }

        public string ErrorContent
        {
            get => this._errorContent;
            set => this._errorContent = value;
        }
        public FrmErrorMessage()
        {
            InitializeComponent();
            this._originSize = this.Height;
            this._fixedSize = this.Height - this.pnlException.Height;
        }
        public FrmErrorMessage(System.Exception ex, bool showException) : this()
        {
            this._errorContent = ex.ToString();
            this._showException = showException;
        }

        public FrmErrorMessage(string errorContent, bool showException) : this()
        {
            this._errorContent = errorContent;
            this._showException = showException;
        }

        private void ShowException(bool showException)
        {
            this.pnlException.Visible = showException;
            this.Height = showException ? this._originSize : this._fixedSize;
        }

        private void picDown_MouseUp(object sender, MouseEventArgs e)
        {
            this.ShowException(!this.pnlException.Visible);
            this.btnOk.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e) => this.Close();

        private void FrmErrorMessage_Load(object sender, EventArgs e)
        {
            this.ShowException(this._showException);
            this.lblErrorMessage.Text = this._alertMsg;
            this.memException.Text = this._errorContent;
        }
    }
}
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

namespace NDPSo
{
    public partial class UcSearchBase : ControlViewBase
    {
        private UcSearchBase()
        {
            InitializeComponent();
        }
        public UcSearchBase(ControlViewBase ctrView, string caption)
      : this()
        {
            ctrView.Dock = DockStyle.Fill;
            this.pnlContainer.Controls.Add((Control)ctrView);
            MessageBox.Show(pnlContainer.Controls.Count.ToString());
            this.Caption = caption;
        }

        public new List<T> GetSelectedObjects<T>() where T : class
        {
            if (this.pnlContainer.Controls.Count > 0)
            {
                ControlViewBase controlViewBase = this.pnlContainer.Controls[0] as ControlViewBase;
                return controlViewBase.GetSelectedObjects<T>();
            }
            return null;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this._dlgRes = DialogResult.OK;
            //this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base._dlgRes = DialogResult.Cancel;
            this.Close();
        }
    }
}

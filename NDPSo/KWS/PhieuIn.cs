using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace NDPSo.KWS
{
    public partial class PhieuIn : DevExpress.XtraEditors.XtraForm
    {
        private FormPhieuIn pi;
        public PhieuIn()
        {
            InitializeComponent();
            pi = new FormPhieuIn();
            pi.Location = new System.Drawing.Point(1,1);
            pi.Size = new System.Drawing.Size(1148, 719);
            this.Controls.Add(pi);
            this.KeyDown += MainForm_KeyDown;

        }

        private void PhieuIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.A)
            {
                //ConfigManager.TramTronConfig.IsCanFixPGH = !ConfigManager.TramTronConfig.IsCanFixPGH;
                //ConfigManager.TramTronConfig.IsCanFixPCT = !ConfigManager.TramTronConfig.IsCanFixPCT;

            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.A)
            {
                pi.HandleShortcutKeys(e.KeyCode, e.Shift);
                e.Handled = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                MainForm_KeyDown(this, new KeyEventArgs(keyData));
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class FrmRemind : DialogViewBase
    {
        public FrmRemind()
        {
            InitializeComponent();
        }

        private void FrmRemind_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void FrmRemind_Load(object sender, EventArgs e)
        {
            this.EndPreventEvent();

        }
    }
}
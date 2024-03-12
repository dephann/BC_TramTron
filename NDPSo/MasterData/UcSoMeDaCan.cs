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

namespace NDPSo.MasterData
{
    public partial class UcSoMeDaCan : DevExpress.XtraEditors.XtraUserControl
    {

        private Decimal _tongSoMe;
        private Decimal _soMeDaTron;
        private Color _color;

        public Decimal SoLuongMeCanTron
        {
            get => this._tongSoMe;
            set
            {
                this._tongSoMe = value;
                this.ShowValue();
            }
        }

        public Color TextColor
        {
            get => this.labelControl1.ForeColor;
            set
            {
                this.labelControl1.ForeColor = value;

            }
        }
        public Decimal SoLuongMeDaTron
        {
            get => this._soMeDaTron;
            set
            {
                this._soMeDaTron = value;
                this.ShowValue();
            }
        }
        private void ShowValue()
        {
            if (this.InvokeRequired)
                this.Invoke((Delegate)new MethodInvoker(this.ShowValue));
            else
                this.labelControl1.Text = string.Format("{0}/{1}", (object)this._soMeDaTron.ToString(), (object)this._tongSoMe.ToString());
        }
        public UcSoMeDaCan()
        {
            InitializeComponent();
        }
    }
}

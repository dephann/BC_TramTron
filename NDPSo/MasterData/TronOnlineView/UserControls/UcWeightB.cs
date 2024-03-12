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
    public partial class UcWeightB : DevExpress.XtraEditors.XtraUserControl
    {
        private Decimal _weight;

        public event UcBaseSilo2.DelCaptionEventHandler WeightClick;
        public delegate void DelCaptionEventHandler(object sender, EventArgs e);
        public Decimal Weight
        {
            get => this.spinEdit1.Value;
            set
            {
                this.spinEdit1.Value = value;
            }
        }

        public UcWeightB()
        {
            InitializeComponent();
        }
        public Decimal GiaTriWeight
        {
            get => Convert.ToDecimal(this.spinEdit1.EditValue);
            set => this.spinEdit1.EditValue = (object)value;
        }

        private void picWeigh_Click(object sender, EventArgs e)
        {
            if (this.WeightClick == null)
                return;
            this.WeightClick((object)this, new EventArgs());
        }

        private void spinEdit1_Click(object sender, EventArgs e)
        {
            if (this.WeightClick == null)
                return;
            this.WeightClick((object)this, new EventArgs());
        }
    }
}

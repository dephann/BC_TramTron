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
    public partial class UcKhoiLuongNoiTron : DevExpress.XtraEditors.XtraUserControl
    {
        private Decimal _giaTri;

        public Decimal GiaTri
        {
            get => Convert.ToDecimal(this.spinEdit1.EditValue);
            set => this.spinEdit1.EditValue = (object)value;
        }
        public UcKhoiLuongNoiTron()
        {
            InitializeComponent();
        }
    }
}

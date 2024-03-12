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
    public partial class UcXeBonTron : DevExpress.XtraEditors.XtraUserControl
    {

        public event UcBaseSilo2.DelCaptionEventHandler BangTaiClick;
        public delegate void DelCaptionEventHandler(object sender, EventArgs e);


        public UcXeBonTron()
        {
            InitializeComponent();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            if (this.BangTaiClick == null)
                return;
            this.BangTaiClick((object)this, new EventArgs());
        }
    }
}

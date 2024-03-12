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

namespace NDPSo.MasterData.Config
{
    public partial class ucBTC : DevExpress.XtraEditors.XtraUserControl
    {
        public event DelButtonEventHandler ButtonMouseDown;
        public event DelButtonEventHandler ButtonMouseMove;
        public event DelButtonEventHandler ButtonMouseUp;

        public delegate void DelButtonEventHandler(object sender, MouseEventArgs e);
        public delegate void DelKeyEventHandler(object sender, KeyEventArgs e);
        public ucBTC()
        {
            InitializeComponent();
        }
        public string ToaDoX
        {
            get => this.lblToaDoX.Text;
            set => this.lblToaDoX.Text = value;
        }
        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseDown == null)
                return;
            this.ButtonMouseDown((object)this, e);
        }

        private void pictureEdit1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseMove == null)
                return;
            this.ButtonMouseMove((object)this, e);
        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseUp == null)
                return;
            this.ButtonMouseUp((object)this, e);
        }
    }
}

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
    public partial class ucSilo : UserControl
    {
        private MySilo _silo;

        public event DelButtonEventHandler ButtonMouseDown;
        public event DelButtonEventHandler ButtonMouseMove;
        public event DelButtonEventHandler ButtonMouseUp;
        //public event DelKeyEventHandler ButtonKeyDown;

        public delegate void DelButtonEventHandler(object sender, MouseEventArgs e);
        public delegate void DelKeyEventHandler(object sender, KeyEventArgs e);
        public ucSilo()
        {
            InitializeComponent();
        }

        public MySilo Silo
        {
            get => this._silo;
            set
            {
                this._silo = value;
                switch (_silo)
                {
                    case MySilo.AGG:
                        this.pictureEdit1.EditValue = ResourceNDP.Tank_Green;
                        return;
                    case MySilo.CE:
                        this.pictureEdit1.EditValue = ResourceNDP.Tank_Organges;
                        return;
                    case MySilo.WA:
                        this.pictureEdit1.EditValue = ResourceNDP.Tank_Blue;
                        return;
                    case MySilo.ADD:
                        this.pictureEdit1.EditValue = ResourceNDP.Tank_Tim;
                        return;
                }

            }
        }
        public string ToaDoX
        {
            get => this.lblToaDoX.Text;
            set => this.lblToaDoX.Text = value;
        }
        public string Caption
        {
            get => this.lblCaption.Text;
            set => this.lblCaption.Text = value;
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

        private void lblToaDoX_TextChanged(object sender, EventArgs e)
        {
            lblToaDoX.Text = lblToaDoX.Text.ToUpper();
        }

        private void lblCaption_TextChanged(object sender, EventArgs e)
        {
            lblCaption.Text = lblCaption.Text.ToUpper();
        }

        public enum MySilo
        {
            AGG,
            CE,
            WA,
            ADD
        }
    }
}

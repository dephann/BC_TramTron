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
    public partial class ucWeight : UserControl
    {

        private MyWeight _weight;

        public event DelButtonEventHandler ButtonMouseDown;
        public event DelButtonEventHandler ButtonMouseMove;
        public event DelButtonEventHandler ButtonMouseUp;
        public delegate void DelButtonEventHandler(object sender, MouseEventArgs e);

        public MyWeight Weight
        {
            get => this._weight;
            set
            {
                this._weight = value;
                switch (_weight)
                {
                    case MyWeight.AGG:
                        this.picWeight.EditValue = ResourceNDP.Weight_Green;
                        return;
                    case MyWeight.CE:
                        this.picWeight.EditValue = ResourceNDP.Weight_Organges;
                        return;
                    case MyWeight.WA:
                        this.picWeight.EditValue = ResourceNDP.Weight_Blue;
                        return;
                    case MyWeight.ADD:
                        this.picWeight.EditValue = ResourceNDP.Weight_Tim;
                        return;
                }

            }
        }

        public int ToaDoX
        {
            get => (int)this.spinEdit1.Value;
            set => this.spinEdit1.Value = value;
        }

        public string Caption
        {
            get => this.labelControl1.Text;
            set => this.labelControl1.Text = value;
        }
        public ucWeight()
        {
            InitializeComponent();
        }

        public enum MyWeight
        {
            AGG,
            CE,
            WA,
            ADD
        }

        private void labelControl1_TextChanged(object sender, EventArgs e)
        {
            labelControl1.Text = labelControl1.Text.ToUpper();
        }

        private void picWeight_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseDown == null)
                return;
            this.ButtonMouseDown((object)this, e);
        }

        private void picWeight_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseMove == null)
                return;
            this.ButtonMouseMove((object)this, e);
        }

        private void picWeight_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseUp == null)
                return;
            this.ButtonMouseUp((object)this, e);
        }
    }
}

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
    public partial class ucLabelDataPrint : DevExpress.XtraEditors.XtraUserControl
    {
        private string _code;
        private string _value;

        public event DelButtonEventHandler ButtonMouseDown;
        public event DelButtonEventHandler ButtonMouseMove;
        public event DelButtonEventHandler ButtonMouseUp;
        public event DelButtonEventHandler ButtonMouseClick;
        public event DelKeyEventHandler ButtonKeyDown;

        public delegate void DelButtonEventHandler(object sender, MouseEventArgs e);
        public delegate void DelKeyEventHandler(object sender, KeyEventArgs e);

        public ucLabelDataPrint()
        {
            InitializeComponent();
        }
        public string Code
        {
            get => this._code;
            set => this._code= value;
        }
        public string Value
        {
            get => this._value;
            set => this._value = value;
        }

        public string Caption
        {
            get => this.lblCaption.Text;
            set => this.lblCaption.Text = value;
        }
        public string ToaDo
        {
            get => this.lblToaDo.Text;
            set => this.lblToaDo.Text = value;
        }

        private void lblCaption_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseDown == null)
                return;
            this.ButtonMouseDown((object)this, e);
        }

        private void lblCaption_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseMove == null)
                return;
            this.ButtonMouseMove((object)this, e);
        }

        private void lblCaption_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseUp == null)
                return;
            this.ButtonMouseUp((object)this, e);
        }

        private void lblCaption_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.ButtonKeyDown == null)
                return;
            this.ButtonKeyDown((object)this, e);
        }

        private void lblCaption_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseClick == null)
                return;
            this.ButtonMouseClick((object)this, e);
        }
    }
}

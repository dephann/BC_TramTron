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
    public partial class UcButtonNoiTron : DevExpress.XtraEditors.XtraUserControl
    {
        private bool _isOn;
        private string _caption;
        private BGColorEnum _bgColor;
        private Color _colorClick;
        private Color _colorNoClick;

        public event DelButtonEventHandler ButtonMouseDown;

        public event DelButtonEventHandler ButtonMouseUp;

        public delegate void DelButtonEventHandler(object sender, EventArgs e);

        public bool IsOn
        {
            get => this._isOn;
            set
            {
                this._isOn = value;

            }
        }
        public string Caption
        {
            get => this._caption;
            set
            {
                this._caption = value;
                this.labelControl1.Text = this._caption;
            }
        }
        public BGColorEnum BGColor
        {
            get => this._bgColor;
            set
            {
                this._bgColor = value;
                switch (this._bgColor)
                {
                    case BGColorEnum.Clik:
                        this.pictureEdit1.BackColor = Color.YellowGreen;
                        break;
                    case BGColorEnum.NoClick:
                        this.pictureEdit1.BackColor = Color.Yellow;
                        break;

                }
            }
        }
       
        public enum BGColorEnum
        {
            Clik,
            NoClick,
        }

        public UcButtonNoiTron()
        {
            InitializeComponent();
            
        }

        private void labelControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseDown == null)
                return;
            this.ButtonMouseDown((object)this, new EventArgs());
            BGColor = BGColorEnum.Clik;
            IsOn = true;
        }

        private void labelControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseUp == null)
                return;
            this.ButtonMouseUp((object)this, new EventArgs());
            BGColor = BGColorEnum.NoClick;
            IsOn = false;
        }
    }
}

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
    public partial class UcButtonCan : DevExpress.XtraEditors.XtraUserControl
    {

        private bool _isOn;
        private BGColorEnum _bgColor;
        private Color _colorClick;
        private Color _colorNoClick;

        public event DelButtonEventHandler ButtonMouseDown;
        public event DelButtonEventHandler ButtonMouseUp;
        public event DelButtonEventHandler ButtonMouseHover;
        public event DelButtonEventHandler ButtonMouseLeave;

        public delegate void DelButtonEventHandler(object sender, EventArgs e);
        public bool IsOn
        {
            get => this._isOn;
            set
            {
                this._isOn = value;

            }
        }

        public Color Color_Click
        {
            get => this._colorClick;
            set
            {
                this._colorClick = value;
            }
        }
        public Color Color_NoClick
        {
            get => this._colorNoClick;
            set
            {
                this._colorNoClick = value;
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
                        this.pictureEdit1.BackColor = Color.DimGray;
                        break;
                    case BGColorEnum.NoClick:
                        this.pictureEdit1.BackColor = Color.DarkGray;
                        break;
                    
                }
            }
        }
        public enum BGColorEnum
        {
            Clik,
            NoClick,
        }

        public UcButtonCan()
        {
            InitializeComponent();
            Color_Click = Color.DimGray;
            Color_NoClick = Color.DarkGray;
        }

        
        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseDown == null)
                return;
            this.ButtonMouseDown((object)this, new EventArgs());
            BGColor = BGColorEnum.Clik;
            IsOn = true;
        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseUp == null)
                return;
            this.ButtonMouseUp((object)this, new EventArgs());
            BGColor = BGColorEnum.NoClick;
            IsOn = false;
        }

        private void pictureEdit1_MouseHover(object sender, EventArgs e)
        {
            if (this.ButtonMouseHover == null)
                return;
            this.ButtonMouseHover((object)this, new EventArgs());
        }

        private void pictureEdit1_MouseLeave(object sender, EventArgs e)
        {
            if (this.ButtonMouseLeave == null)
                return;
            this.ButtonMouseLeave((object)this, new EventArgs());
        }
    }
}

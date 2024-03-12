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
    public partial class UcButtonRungCan : DevExpress.XtraEditors.XtraUserControl
    {
        private Bitmap _iconOff = ResourceNDP.RungCan;

        private Bitmap _iconOn = ResourceNDP.RungCan_Gr;

        private bool _isOn = true;

        private OffMode _offMode;
        private MyColor _colorLed;

        public event DelButtonEventHandler ButtonMouseDown;
        public event DelButtonEventHandler ButtonMouseUp;
        public event DelButtonEventHandler ButtonMouseHover;
        public event DelButtonEventHandler ButtonMouseLeave;

        public delegate void DelButtonEventHandler(object sender, EventArgs e);
        public enum MyColor
        {
            Green,
            Orange,
            Yellow
        }
        public MyColor ColorLed
        {
            get => this._colorLed;
            set
            {
                this._colorLed = value;
                switch (_colorLed)
                {
                    case MyColor.Green:
                        this._iconOn = ResourceNDP.RungCan_Gr;
                        return;
                    case MyColor.Orange:
                        this._iconOn = ResourceNDP.RungCan_Or;
                        return;
                    case MyColor.Yellow:
                        this._iconOn = ResourceNDP.RungCan_Ye;
                        return;

                }

            }
        }
        public enum OffMode
        {
            Default,
            IconOff
        }
        public UcButtonRungCan()
        {
            InitializeComponent();
           
        }
        private void SetOffIcon(OffMode offMode)
        {
            switch (offMode)
            {
                case OffMode.Default:
                case OffMode.IconOff:
                    this.pictureEdit1.EditValue = this._iconOff;
                    return;

                default:
                    return;
            }
        }

        public bool IsOn
        {
            get
            {
                return this._isOn;
            }
            set
            {
                this._isOn = value;
                if (this._isOn)
                {
                    this.pictureEdit1.EditValue = this._iconOn;
                    return;
                }
                this.SetOffIcon(this._offMode);
            }
        }

        private void pictureEdit1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseDown == null)
                return;
            this.ButtonMouseDown((object)this, new EventArgs());
            //this.pictureEdit1.BackgroundImage = Color_Click;
            //IsOn = true;
        }

        private void pictureEdit1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.ButtonMouseUp == null)
                return;
            this.ButtonMouseUp((object)this, new EventArgs());
            //this.pictureEdit1.BackgroundImage = Color_NoClick;
            //IsOn = false;
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

        private void pictureEdit1_Click(object sender, EventArgs e)
        {

        }
    }
}

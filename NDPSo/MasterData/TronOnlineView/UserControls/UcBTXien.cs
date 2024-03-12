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
    public partial class UcBTXien : DevExpress.XtraEditors.XtraUserControl
    {
        Image _image = ResourceNDP.BTXien;
        Bitmap animatedImage = ResourceNDP.Anim_BXT;
        bool currentlyAnimating = false;
        public Action _action = Action.Pause;
        public event DelButtonEventHandler ButtonClick_MouseDown;
        public event DelButtonEventHandler ButtonClick_MouseUp;
        public event DelButtonEventHandler ButtonClick;
        public delegate void DelButtonEventHandler(object sender, EventArgs e);

        private bool _isOn = true;

        public void AnimateImage()
        {
            if (!currentlyAnimating)
            {
                ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
            }
        }
        public UcBTXien()
        {
            InitializeComponent();
            this.pictureEdit1.Paint += new PaintEventHandler(pictureEdit1_Paint);
        }
        void OnFrameChanged(object sender, EventArgs e)
        {
            this.pictureEdit1.Invalidate();
        }

        private void pictureEdit1_Paint(object sender, PaintEventArgs e)
        {
            AnimateImage();
            ImageAnimator.UpdateFrames();
            e.Graphics.DrawImage(this.animatedImage, Point.Empty);
        }
        public Action CheDo
        {
            get
            {
                return this._action;
            }
            set
            {
                this._action = value;
                switch (this._action)
                {
                    case Action.Start:
                        this.pictureEdit2.Visible = false;
                        
                        return;
                    case Action.Pause:
                        this.pictureEdit2.Visible = true;
                        return;
                    default:
                        return;
                }
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
                    this.CheDo = Action.Start;
                    return;
                }
                this.CheDo = Action.Pause;
            }
        }
        public enum Action
        {
            Start,
            Pause
        }

        private void pictureEdit2_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.ButtonClick_MouseDown == null)
                return;
            this.ButtonClick_MouseDown((object)this, new EventArgs());
            
        }

        private void pictureEdit2_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.ButtonClick_MouseUp == null)
                return;
            this.ButtonClick_MouseUp((object)this, new EventArgs());
            
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            if (this.ButtonClick == null)
                return;
            this.ButtonClick((object)this, new EventArgs());
            
        }

        private void UcBTXien_Load(object sender, EventArgs e)
        {
            currentlyAnimating = true;
            ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
        }
    }
}

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
    public partial class UcPrpelSe : DevExpress.XtraEditors.XtraUserControl
    {
        Bitmap animatedImage = ResourceNDP.tt;
        bool currentlyAnimating = false;
        public Action _action;
        public event DelButtonEventHandler Button_NoiTronClick_MouseDown;
        public event DelButtonEventHandler Button_NoiTronClick_MouseUp;
        public event DelButtonEventHandler Button_NoiTronClick;
        public delegate void DelButtonEventHandler(object sender, EventArgs e);
        public void AnimateImage()
        {
            if (!currentlyAnimating)
            {
                ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
            }
        }
        public UcPrpelSe()
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

        public enum Action
        {
            Start,
            Pause
        }
        
        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            if (this.Button_NoiTronClick == null)
                return;
            this.Button_NoiTronClick((object)this, new EventArgs());
        }
        private void UcPrpelSe_Load(object sender, EventArgs e)
        {
            currentlyAnimating = true;
            ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
        }
        private void pictureEdit2_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Button_NoiTronClick_MouseDown == null)
                return;
            this.Button_NoiTronClick_MouseDown((object)this, new EventArgs());
        }

        private void pictureEdit2_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Button_NoiTronClick_MouseUp == null)
                return;
            this.Button_NoiTronClick_MouseUp((object)this, new EventArgs());
        }

        
    }
}

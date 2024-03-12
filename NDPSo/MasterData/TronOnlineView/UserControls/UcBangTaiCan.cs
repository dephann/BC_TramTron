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
    public partial class UcBangTaiCan : DevExpress.XtraEditors.XtraUserControl
    {
        Bitmap animatedImage = ResourceNDP.BT_Can;
        bool currentlyAnimating = false;
        public Action _action = Action.Pause;
        public void AnimateImage()
        {
            if (!currentlyAnimating)
            {
                ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
            }
        }
        public UcBangTaiCan()
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
                        currentlyAnimating = true;
                        ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
                        return;
                    case Action.Pause:
                        ImageAnimator.StopAnimate(this.animatedImage, new EventHandler(this.OnFrameChanged));
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
    }
}

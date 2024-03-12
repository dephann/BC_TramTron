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
    public partial class UcBTCan : DevExpress.XtraEditors.XtraUserControl
    {
        Bitmap animatedImage = ResourceNDP.MAnim_BTC;
        bool currentlyAnimating = false;
        public Action _action;
        public event DelButtonEventHandler Button_MouseDown;
        public event DelButtonEventHandler Button_MouseUp;
        public event DelButtonEventHandler Button_Click;
        public delegate void DelButtonEventHandler(object sender, EventArgs e);
        public void AnimateImage()
        {
            if (!currentlyAnimating)
            {
                ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
            }
        }
        
        public UcBTCan()
        {
            InitializeComponent();
            this.pictureEdit2.Paint += new PaintEventHandler(pictureEdit2_Paint);
        }
        void OnFrameChanged(object sender, EventArgs e)
        {
            this.pictureEdit2.Invalidate();
        }
        private void pictureEdit2_Paint(object sender, PaintEventArgs e)
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
                        this.pictureEdit5.Visible = false;
                        return;
                    case Action.Pause:
                        this.pictureEdit5.Visible = true;
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

        private void UcBTCan_Load(object sender, EventArgs e)
        {
            currentlyAnimating = true;
            ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));

        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            if (this.Button_Click == null)
                return;
            this.Button_Click((object)this, new EventArgs());
        }

        private void pictureEdit5_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Button_MouseDown == null)
                return;
            this.Button_MouseDown((object)this, new EventArgs());

        }

        private void pictureEdit5_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Button_MouseUp == null)
                return;
            this.Button_MouseUp((object)this, new EventArgs());
        }
    }
}

using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    public partial class UcFanControl : UserControl
    {

        private Image fanImage;
        private int fanAngle = 0;
        private Timer fanTimer;

        private bool isOn = false;
        public bool IsOn
        {
            get { return isOn; }
            set
            {
                isOn = value;
                if (isOn)
                {
                    fanTimer.Start();
                }
                else
                {
                    fanTimer.Stop();
                }
            }
        }
        public UcFanControl()
        {
            InitializeComponent();
            fanImage = ResourceNDP.CanhQ; // Thiết lập ảnh cánh quạt
            pictureEdit1.Image = fanImage;

            fanTimer = new Timer();
            fanTimer.Interval = 50; // Thời gian giữa mỗi lần xoay (đơn vị: millisecond)
            fanTimer.Tick += new EventHandler(fanTimer_Tick);
        }
        private void fanTimer_Tick(object sender, EventArgs e)
        {
            fanAngle += 10;
            if (fanAngle >= 360)
            {
                fanAngle = 0;
            }
            RotatePictureEdit(pictureEdit1, fanAngle);
        }

        private void RotatePictureEdit(PictureEdit pictureEdit, float angle)
        {
            // Lấy giá trị chiều rộng và chiều cao của PictureEdit
            int width = pictureEdit.Width;
            int height = pictureEdit.Height;

            // Tính toán tọa độ của trung tâm PictureEdit
            PointF center = new PointF(40 / 2f, 40 / 2f);

            // Tạo đối tượng Matrix để thực hiện xoay quanh trục tâm quay
            Matrix matrix = new Matrix();
            matrix.Translate(center.X, center.Y);
            matrix.Rotate(angle);
            matrix.Translate(-center.X, -center.Y);

            // Áp dụng ma trận xoay lên hình ảnh và hiển thị lên PictureEdit
            pictureEdit.Image = RotateImage(pictureEdit.Image, matrix);
        }
        private Image RotateImage(Image image, Matrix matrix)
        {
            Bitmap rotatedImage = new Bitmap(image.Width, image.Height);

            // Tạo đối tượng Graphics để vẽ hình ảnh vào Bitmap
            using (Graphics g = Graphics.FromImage(rotatedImage))
            {
                // Thực hiện việc xoay hình ảnh bằng cách áp dụng ma trận Matrix
                g.Transform = matrix;
                g.DrawImage(image, 0, 0);
            }

            return rotatedImage;
        }
    }
}

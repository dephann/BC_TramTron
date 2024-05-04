using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo
{
    public partial class SettingProduct : DialogViewBase
    {
        public SettingProduct()
        {
            InitializeComponent();
        }
        protected override void PopulateData()
        {
            try
            {
                this.txtNameProduct.Text = ConfigManager.TramTronConfig.NameProduct;
                this.txtLocalProduct.Text = ConfigManager.TramTronConfig.LocalProduct;
                this.txtPhoneProduct.Text = ConfigManager.TramTronConfig.PhoneProduct;
                this.bteIconLogoPathProducer.Text = ConfigManager.TramTronConfig.LogoProduct;
                this.lblTime.Text = ConfigManager.TramTronConfig.TimeLife.ToString();
                this.lblTime.Visible = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                TramTronLogger.WriteError(ex);
                //DNMessageBox.ShowDNErrorDialog(ex);
            }
        }

        private void bteIconLogoPathProducer_EditValueChanged(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(bteIconLogoPathProducer.Text))
            {
                pictureEdit1.Image = Image.FromFile(bteIconLogoPathProducer.Text);
                pictureEdit1.Properties.SizeMode = PictureSizeMode.Zoom; // Chọn loại thay đổi kích thước tùy chỉnh
                pictureEdit1.Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True; // Cho phép hiển thị menu Zoom

                // Đảm bảo rằng hình ảnh vừa với kích thước của PictureEdit
                pictureEdit1.Properties.SizeMode = PictureSizeMode.Squeeze;

            }
            else
            {
                MessageBox.Show("Đường dẫn không phù hợp, vui lòng chọn lại đường dẫn!");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigManager.TramTronConfig.NameProduct = this.txtNameProduct.Text;
                ConfigManager.TramTronConfig.LocalProduct = this.txtLocalProduct.Text;
                ConfigManager.TramTronConfig.PhoneProduct = this.txtPhoneProduct.Text;
                ConfigManager.TramTronConfig.LogoProduct = this.bteIconLogoPathProducer.Text;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
                //TramTronLogger.WriteError(ex);
                //TramTromMessageBox.ShowDNErrorDialog(ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bteIconLogoPathProducer_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.Title = "Chọn hình ảnh";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string imagePath = openFileDialog1.FileName;
                    bteIconLogoPathProducer.Text = imagePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void SettingProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.T)
            {
                this.lblTime.Visible = true;
            }
        }
    }
}
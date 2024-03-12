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
    public partial class UcMeTronNoiTron : DevExpress.XtraEditors.XtraUserControl
    {
        private Decimal _tongSoMe;
        private Decimal _soMeDaTron;
        private Color _color;

        public Decimal SoLuongMeCanTron
        {
            get => this._tongSoMe;
            set
            {
                this._tongSoMe = value;
                this.ShowValue();
            }
        }
        public Decimal SoLuongMeDaTron
        {
            get => this._soMeDaTron;
            set
            {
                this._soMeDaTron = value;
                this.ShowValue();
            }
        }
        private void ShowValue()
        {
            if (this.InvokeRequired)
                this.Invoke((Delegate)new MethodInvoker(this.ShowValue));
            else
            {
                this.labelControl1.Text = string.Format("{0}/{1}", (object)this._soMeDaTron.ToString(), (object)this._tongSoMe.ToString());
                ScaleLabelFont(this.labelControl1);
            }
        }
        public UcMeTronNoiTron()
        {
            InitializeComponent();
        }
        private void ScaleLabelFont(LabelControl label)
        {
            int charCount = label.Text.Length;

            // Kích thước tối thiểu bạn muốn đảm bảo rằng nó có thể đọc được
            int minCharCount = 3;

            // Tính toán kích thước mới của font
            float newSize = 12 * ((float)minCharCount / charCount);

            // Kiểm tra để tránh lỗi khi newSize <= 0
            if (newSize > 0)
            {
                label.Font = new Font(label.Font.FontFamily, newSize, FontStyle.Bold);
            }

        }
    }
}

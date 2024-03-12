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
    public partial class UcNhomChinhCanAdd : DevExpress.XtraEditors.XtraUserControl
    {
        private string _nameGroup;
        private string _giaTriXung;
        private string _giaTriNhap0;
        private string _giaTriNhapTai;
        private string _giaTriKLThucTe;

        public event DelButtonEventHandler ButtonChinh0_Down;
        public event DelButtonEventHandler ButtonChinh0_Up;
        public event DelButtonEventHandler ButtonChinhTai_Down;
        public event DelButtonEventHandler ButtonChinhTai_Up;

        public delegate void DelButtonEventHandler(object sender, EventArgs e);
        public string NameGroup
        {
            get => _nameGroup;
            set
            {
                this._nameGroup = value;
                groupBox1.Text = _nameGroup;
            }
        }

        public string GiaTri_Xung
        {
            get => _giaTriXung;
            set
            {
                this._giaTriXung = value;
                this.ip_Xung.GiaTri = _giaTriXung;
            }
        }
       
        public string GiaTri_NhapTai
        {
            get => _giaTriNhapTai;
            set
            {
                this._giaTriNhapTai = value;
                this.ip_NhapTai.GiaTri = _giaTriNhapTai;
            }
        }
        
        public UcNhomChinhCanAdd()
        {
            InitializeComponent();
        }

        

        /*private void btnChinhTai_ButtonClick(object sender, EventArgs e)
        {
            if (this.ButtonChinhTai == null)
                return;
            this.ButtonChinhTai((object)this, new EventArgs());
        }*/

        private void ip_Xung_ValueEditChanged(object sender, EventArgs e)
        {
            GiaTri_Xung = ip_Xung.GiaTri;
        }

       

        private void ip_NhapTai_ValueEditChanged(object sender, EventArgs e)
        {
            GiaTri_NhapTai = ip_NhapTai.GiaTri;
        }

        
        private void ip_Xung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void ip_Nhap0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void ip_NhapTai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnChinh0_ButtonMoveDown_Click(object sender, EventArgs e)
        {
            if (this.ButtonChinh0_Down == null)
                return;
            this.ButtonChinh0_Down((object)this, new EventArgs());
        }

        private void btnChinh0_ButtonMoveUp_Click(object sender, EventArgs e)
        {
            if (this.ButtonChinh0_Up == null)
                return;
            this.ButtonChinh0_Up((object)this, new EventArgs());
        }

        private void btnChinhTai_ButtonMoveDown_Click(object sender, EventArgs e)
        {
            if (this.ButtonChinhTai_Down == null)
                return;
            this.ButtonChinhTai_Down((object)this, new EventArgs());
        }

        private void btnChinhTai_ButtonMoveUp_Click(object sender, EventArgs e)
        {
            if (this.ButtonChinhTai_Up == null)
                return;
            this.ButtonChinhTai_Up((object)this, new EventArgs());
        }
    }
}

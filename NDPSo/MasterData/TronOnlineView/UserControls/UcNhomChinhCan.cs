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
    public partial class UcNhomChinhCan : DevExpress.XtraEditors.XtraUserControl
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

        public event EnterKey Enter_Down_Nhap0;
        public event EnterKey Enter_Down_NhapTai;

        public delegate void DelButtonEventHandler(object sender, EventArgs e);
        public delegate void EnterKey(object sender, KeyEventArgs e);
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
        public string GiaTri_Nhap0
        {
            get => _giaTriNhap0;
            set
            {
                this._giaTriNhap0 = value;
                this.ip_Nhap0.GiaTri = _giaTriNhap0;
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
        public string GiaTri_KLThucTe
        {
            get => _giaTriKLThucTe;
            set
            {
                this._giaTriKLThucTe = value;
                this.ip_KLThucTe.GiaTri = _giaTriKLThucTe;
            }
        }
        public UcNhomChinhCan()
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

        private void ip_Nhap0_ValueEditChanged(object sender, EventArgs e)
        {
            GiaTri_Nhap0 = ip_Nhap0.GiaTri;
        }

        private void ip_NhapTai_ValueEditChanged(object sender, EventArgs e)
        {
            GiaTri_NhapTai = ip_NhapTai.GiaTri;
        }

        private void ip_KLThucTe_ValueEditChanged(object sender, EventArgs e)
        {
            GiaTri_KLThucTe = ip_KLThucTe.GiaTri;
        }

        private void ip_Xung_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void ip_Nhap0_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ip_NhapTai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                
            }
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

        

        
        private void ip_Nhap0_KeyDown(object sender, KeyEventArgs e)
        {
            
           
        }

        private void ip_Nhap0_EnterKeyCode(object sender, KeyEventArgs e)
        {
            if (this.Enter_Down_Nhap0 == null)
                return;
            this.Enter_Down_Nhap0((object)this, new KeyEventArgs(e.KeyCode));
        }

        private void ip_NhapTai_EnterKeyCode(object sender, KeyEventArgs e)
        {
            if (this.Enter_Down_NhapTai == null)
                return;
            this.Enter_Down_NhapTai((object)this, new KeyEventArgs(e.KeyCode));
        }
    }
}

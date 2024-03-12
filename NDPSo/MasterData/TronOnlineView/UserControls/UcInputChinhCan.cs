using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    public partial class UcInputChinhCan : DevExpress.XtraEditors.XtraUserControl
    {
        private CheDoNhap _cheDoNhap;
        private string _value;

        public event ValueEditChangedEventHandler ValueEditChanged;

        public event EnterKey EnterKeyCode;
        public delegate void ValueEditChangedEventHandler(object sender, EventArgs e);
        public delegate void EnterKey(object sender, KeyEventArgs e);
        public CheDoNhap CheDo
        {
            get => _cheDoNhap;
            set
            {
                this._cheDoNhap = value;
                switch (_cheDoNhap)
                {
                    case CheDoNhap.Input:
                        this.textEdit1.ReadOnly = false;
                        this.textEdit1.BackColor = Color.White;
                        break;
                    case CheDoNhap.Output:
                        this.textEdit1.ReadOnly = true;
                        this.textEdit1.BackColor = Color.White;
                        
                        break;
                }
            }
        }
        public enum CheDoNhap
        {
            Input,
            Output,
        }

        public string GiaTri
        {
            get => _value;
            set
            {
                this._value = value;
                if (string.IsNullOrEmpty(_value))
                    _value = "";
                this.textEdit1.Text = _value.ToString();
                
            }
        }
        public UcInputChinhCan()
        {
            InitializeComponent();
            
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.ValueEditChanged == null)
                return;
            this.ValueEditChanged((object)this, new EventArgs());
            
            if (string.IsNullOrEmpty(this.textEdit1.Text))
                return;
            GiaTri = this.textEdit1.Text.ToString();
            
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void textEdit1_KeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.EnterKeyCode == null)
                return;
            this.EnterKeyCode((object)this, new KeyEventArgs(e.KeyCode));
        }
    }
}

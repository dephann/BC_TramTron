using NDPSo.Data;
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

namespace NDPSo.MasterData
{

    public partial class UcLogic : UserControl
    {

        private string _nhomSilo = string.Empty;

        public delegate void LogicEventHandler(int value);
        public event LogicEventHandler LogicEventHandlerSend;

        public BindingList<ObjSilo> Silos
        {
            set
            {
                if (value == null)
                    return;
                this.lueFrom.Properties.DataSource = (object)value;
                this.lueTo.Properties.DataSource = (object)value;
            }
        }

        public string NhomSilo
        {
            set => this._nhomSilo = value;
        }
        public UcLogic()
        {
            InitializeComponent();
        }


        public void SetLogic(int value)
        {
            string str1 = (value / 10).ToString();
            string str2 = (value % 10).ToString();
            this.lueFrom.EditValue = (object)(this._nhomSilo + str1);
            this.lueTo.EditValue = (object)(this._nhomSilo + str2);
        }

        private void ShowThongSoThietLap(string thongso)
        {
            if (thongso == string.Empty)
                this.labelControl1.Text = thongso;
            else
                this.labelControl1.Text = string.Format("Đã thiết lập {0}", (object)thongso);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.LogicEventHandlerSend == null)
                return;
            if (this.lueFrom.Text == string.Empty || this.lueTo.Text == string.Empty)
            {
                TramTromMessageBox.ShowWarningDialog("Vui lòng chọn silo.");
            }
            else
            {
                string str1 = this.lueFrom.Text.Replace(this._nhomSilo, "");
                string str2 = this.lueTo.Text.Replace(this._nhomSilo, "");
                if (str1 == str2)
                {
                    TramTromMessageBox.ShowWarningDialog("Không được chọn trùng silo!");
                }
                else
                {
                    if (TramTromMessageBox.ShowYesNoDialog("Xác nhận LOGIC ?") != DialogResult.Yes)
                        return;
                    int num = int.Parse(this.Tag.ToString() + str1 + str2);
                    this.LogicEventHandlerSend(num);
                    this.ShowThongSoThietLap(num.ToString());
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (this.LogicEventHandlerSend == null || TramTromMessageBox.ShowYesNoDialog("Xác nhận làm mới ?") != DialogResult.Yes)
                return;
            this.lueFrom.EditValue = (object)null;
            this.lueTo.EditValue = (object)null;
            this.LogicEventHandlerSend(0);
            this.ShowThongSoThietLap(string.Empty);
        }


        private void chkThietLap_EditValueChanged(object sender, EventArgs e)
        {
        }

        
    }
}

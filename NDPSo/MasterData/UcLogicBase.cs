using DevExpress.XtraEditors;
using NDPSo.ClientSetting;
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
    public partial class UcLogicBase : UserControl
    {
        private NhomSiloEnum _nhomSilo;
        private Double _valueLogic;
        private string _numberSiloLogic;
        protected BindingList<ObjSilo> _blstSiloLogic = new BindingList<ObjSilo>();
        protected BindingList<ObjSilo> _blstSiloLogicSeleted1 = new BindingList<ObjSilo>();
        protected BindingList<ObjSilo> _blstSiloLogicSeleted2 = new BindingList<ObjSilo>();

        public event ButtonEventHandler ButtonSetupLogic;
        public event ChangeValueEventHandler ChangeValueBlstLogic_01;
        public event ChangeValueEventHandler ChangeValueBlstLogic_02;
        
        public delegate void ButtonEventHandler(object sender, EventArgs e);
        public delegate void ChangeValueEventHandler(object sender, EventArgs e);
        public string SiloLogicTittle
        {
            get => this.lblLogicName.Text;
            set => this.lblLogicName.Text = value;
        }
        public Double ValueLogic
        {
            get => this._valueLogic;
            set
            {
                this._valueLogic = value;
            }
        }
        public NhomSiloEnum NhomSilo
        {
            get => this._nhomSilo;
            set
            {
                this._nhomSilo = value;
            }
        } 
        public enum NhomSiloEnum
        {
            AGG,
            CE,
            ADD
        }
       
        public UcLogicBase()
        {
            InitializeComponent();
            //ResetValue();
        }

        public virtual void GetBlstSiloLogic(BindingList<ObjSilo> _blstSilo)
        {
            /*this._blstSiloLogic = _blstSiloLogic;
            if (this._blstSiloLogic != null)
            {
                this.lueWeigh1.Properties.DataSource = _blstSiloLogic;
                this.lueWeigh2.Properties.DataSource = _blstSiloLogic;
            }*/
            //this.lueWeigh1.Properties.DataSource = this._blstSiloLogicSeleted1;
        }
        public void GetValueLogic()
        {
            double numlogic = 0;

            if (!this.ValidateData())
            {
                ValueLogic = numlogic;
            }
            else
            {
                switch (NhomSilo)
                {
                    case NhomSiloEnum.AGG:
                        this._numberSiloLogic = GetNumLogicSiloAG(this.lueWeigh1).ToString() + GetNumLogicSiloAG(this.lueWeigh2).ToString();
                        break;
                    case NhomSiloEnum.CE:
                        this._numberSiloLogic = GetNumLogicSiloCE(this.lueWeigh1).ToString() + GetNumLogicSiloCE(this.lueWeigh2).ToString();
                        break;
                    case NhomSiloEnum.ADD:
                        this._numberSiloLogic = GetNumLogicSiloAD(this.lueWeigh1).ToString() + GetNumLogicSiloAD(this.lueWeigh2).ToString();
                        break;
                }
                string a = this._numberSiloLogic;
                numlogic = double.Parse(a);
                ValueLogic = numlogic;
            }
        }
      
        private bool ValidateData()
        {
            bool flag = true;
            if ((int)this.lueWeigh1.EditValue == -1)
            {
                this.lueWeigh1.ErrorText = "Silo is requied";
                flag = false;
            }
            if ((int)this.lueWeigh2.EditValue == -1)
            {
                this.lueWeigh2.ErrorText = "Silo is requied";
                flag = false;
            }
            return flag;
        }
        private int GetNumLogicSiloAG(LookUpEdit lueSiloLogic)
        {
            int a = 0;
            string maSilo = lueSiloLogic.GetColumnValue("MaSilo").ToString();
            switch (maSilo)
            {
                case "Agg1":
                    a = 1;
                    break;
                case "Agg2":
                    a = 2;
                    break;
                case "Agg3":
                    a = 3;
                    break;
                case "Agg4":
                    a = 4;
                    break;
                case "Agg5":
                    a = 5;
                    break;
                case "Agg6":
                    a = 6;
                    break;
                default:
                    break;
            }
            return a;
        }
        private int GetNumLogicSiloCE(LookUpEdit lueSiloLogic)
        {
            int a = 0;
            string maSilo = lueSiloLogic.GetColumnValue("MaSilo").ToString();
            switch (maSilo)
            {
                case "Ce1":
                    a = 1;
                    break;
                case "Ce2":
                    a = 2;
                    break;
                case "Ce3":
                    a = 3;
                    break;
                case "Ce4":
                    a = 4;
                    break;
                case "Ce5":
                    a = 5;
                    break;
                default:
                    break;
            }
            return a;
        }
        private int GetNumLogicSiloAD(LookUpEdit lueSiloLogic)
        {
            int a = 0;
            string maSilo = lueSiloLogic.GetColumnValue("MaSilo").ToString();
            switch (maSilo)
            {
                case "Add1":
                    a = 1;
                    break;
                case "Add2":
                    a = 2;
                    break;
                case "Add3":
                    a = 3;
                    break;
                case "Add4":
                    a = 4;
                    break;
                case "Add5":
                    a = 5;
                    break;
                case "Add6":
                    a = 6;
                    break;
                default:
                    break;
            }
            return a;
        }
        protected virtual void lueWeigh1_EditValueChanged(object sender, EventArgs e)
        {
            if (this.ChangeValueBlstLogic_01 == null)
            {
                return;
            }
            this.ChangeValueBlstLogic_01((object)this, new EventArgs());
        }

        protected virtual void lueWeigh2_EditValueChanged(object sender, EventArgs e)
        {
            //Support.GetListSiloLogic(this._blstSiloLogic, this._blstSiloLogicSeleted1, this.lueWeigh2, this.lueWeigh1);
            if (this.ChangeValueBlstLogic_02 == null)
            {
                return;
            }
            this.ChangeValueBlstLogic_02((object)this, new EventArgs());
        }

        protected virtual void btnSetUpLogic_Click(object sender, EventArgs e)
        {
            if (this.ButtonSetupLogic == null)
            {
                return;
            }
            this.ButtonSetupLogic((object)this, new EventArgs());
            if (this.lueWeigh1.Text == string.Empty || this.lueWeigh2.Text == string.Empty)
            {
                GetValueLogic();
                TramTromMessageBox.ShowMessageDialog("Đã đưa LOGIC về trạng thái ban đầu.");
            }
            else
            {
                string str1 = this.lueWeigh1.Text.ToString();
                string str2 = this.lueWeigh2.Text.ToString();
                string str = string.Format("Xác nhận thực hiện {0} - LOGIC - {1} ?", str1, str2);

                if (TramTromMessageBox.ShowYesNoDialog(str) != DialogResult.Yes)
                    return;
                GetValueLogic();
            }
        }

        protected virtual void btnResetValue_Click(object sender, EventArgs e)
        {
            this.ResetValue();
        }
        private void ResetValue()
        {
            this.lueWeigh1.EditValue = (object)-1;
            this.lueWeigh2.EditValue = (object)-1;
        }
    }
}

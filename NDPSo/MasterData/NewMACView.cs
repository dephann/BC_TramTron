using DevExpress.XtraEditors;
using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.MasterData
{
    public partial class NewMACView : ControlViewBase, INewMACView, IBase
    {
        private NewMACDataPresenter _presenter;
        private string _NewMACCaption = "Thêm MAC";
        private string _EditMACCaption = "Sửa MAC";
        private string _ViewMACCaption = "Xem MAC";
        private ObjMAC _mac;
        private BindingList<ObjSilo> _bLstSilo = new BindingList<ObjSilo>();
        private BindingList<ObjMACSilo> _bLstMACSilo = new BindingList<ObjMACSilo>();
        private bool IsSaveClose { get; set; }
        public NewMACView()
        {
            InitializeComponent();
            this._presenter = new NewMACDataPresenter((INewMACView)this);
        }
        public NewMACView(ObjMAC mac, Enums.FormAction action)
      : this()
        {
            this._mac = mac;
            this.FormAction = action;
            this.SetCaption();
        }

        public ObjMAC MAC
        {
            set => this._mac = value;
        }

        public BindingList<ObjSilo> BLstSilo
        {
            set
            {
                this._bLstSilo = value;
                this.BuildNewBlstMACSilo();
            }
        }

        public BindingList<ObjMACSilo> BLstMACSilo
        {
            set
            {
                this._bLstMACSilo = value;
                this.grcMACSilo.DataSource = (object)this._bLstMACSilo;
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        protected override void SetupLayout() => this.DisableConstrol();
        protected override void PopulateData()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this._presenter.BuildNewMAC();
                    this._presenter.ListSilo_ByActivated(true);
                    break;
                case Enums.FormAction.Edit:
                    this._presenter.GetMACByKey(this._mac.MACID);
                    this._presenter.ListSilo_ByActivated(true);
                    this._presenter.ListMACSilo_ByMACID(this._mac.MACID);
                    break;
                case Enums.FormAction.View:
                    this._presenter.GetMACByKey(this._mac.MACID);
                    this._presenter.ListSilo_ByActivated(true);
                    this._presenter.ListMACSilo_ByMACID(this._mac.MACID);
                    break;
            }
        }
        protected override void BindData()
        {
            this.txtMaMAC.DataBindings.Clear();
            this.txtMaMAC.DataBindings.Add("Text", (object)this._mac, "MaMAC");
            this.txtTenMAC.DataBindings.Clear();
            this.txtTenMAC.DataBindings.Add("Text", (object)this._mac, "TenMAC");
            this.spnThemBotNuoc1.DataBindings.Clear();
            this.spnThemBotNuoc1.DataBindings.Add("EditValue", (object)this._mac, "ThemBotNuoc1");
            this.spnThemBotNuoc2.DataBindings.Clear();
            this.spnThemBotNuoc2.DataBindings.Add("EditValue", (object)this._mac, "ThemBotNuoc2");
            this.txtDoSut.DataBindings.Clear();
            this.txtDoSut.DataBindings.Add("Text", (object)this._mac, "DoSut");
            this.txtCuongDo.DataBindings.Clear();
            this.txtCuongDo.DataBindings.Add("EditValue", (object)this._mac, "GhiChu");
            this.chkActive.DataBindings.Clear();
            this.chkActive.DataBindings.Add("Checked", (object)this._mac, "Activated");
        }

        private void SetCaption()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this.Caption = this._NewMACCaption;
                    break;
                case Enums.FormAction.Edit:
                    this.Caption = this._EditMACCaption;
                    break;
                case Enums.FormAction.View:
                    this.Caption = this._ViewMACCaption;
                    break;
            }
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtMaMAC.Text == string.Empty)
            {
                this.txtMaMAC.ErrorText = GlobalValues.Messages.MACCodeIsRequired;
                flag = false;
            }
            if (this.txtTenMAC.Text == string.Empty)
            {
                this.txtTenMAC.ErrorText = GlobalValues.Messages.MACNameIsRequired;
                flag = false;
            }
            foreach (ObjMACSilo objMacSilo in (Collection<ObjMACSilo>)this._bLstMACSilo)
            {
                if (!objMacSilo.SiloValue.HasValue)
                    objMacSilo.SiloValue = new Decimal?(0M);
                foreach (ObjSilo objSilo in (Collection<ObjSilo>)this._bLstSilo)
                {
                    if(objMacSilo.SiloID == objSilo.SiloID)
                    {
                        if (objMacSilo.SiloValue > objSilo.KLCanLonNhat)
                        {
                            TramTromMessageBox.ShowWarningDialog(string.Format("Giá trị silo {0} vượt quá giới hạn cho phép!", objMacSilo.NPSiloTenSilo));
                            flag = false;
                        }
                        if (objSilo.MaSilo == "Add1" || objSilo.MaSilo == "Add2" || objSilo.MaSilo == "Add3" || objSilo.MaSilo == "Add4" || objSilo.MaSilo == "Add5" || objSilo.MaSilo == "Add6")
                        {
                            if (objMacSilo.SiloValue > 5)
                            {
                                TramTromMessageBox.ShowWarningDialog(string.Format("Giá trị silo {0} vượt quá giới hạn cho phép!", objMacSilo.NPSiloTenSilo));
                                flag = false;
                            }
                        }

                    }
                    
                }
            }
           
            return flag;
        }

        private void DisableConstrol()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.Edit:
                    this.btnSaveNew.Visible = false;
                    break;
                case Enums.FormAction.View:
                    this.txtMaMAC.Properties.ReadOnly = true;
                    this.txtTenMAC.Properties.ReadOnly = true;
                    this.spnThemBotNuoc1.Properties.ReadOnly = true;
                    this.spnThemBotNuoc2.Properties.ReadOnly = true;
                    this.txtDoSut.Properties.ReadOnly = true;
                    this.txtCuongDo.Properties.ReadOnly = true;
                    this.btnSaveNew.Visible = false;
                    this.btnSave.Visible = false;
                    break;
            }
        }

        private void BuildNewBlstMACSilo()
        {
            BindingList<ObjMACSilo> bindingList = new BindingList<ObjMACSilo>();
            foreach (ObjSilo objSilo in (Collection<ObjSilo>)this._bLstSilo)
            {
                ObjMACSilo objMacSilo = new ObjMACSilo()
                {
                    SiloID = objSilo.SiloID,
                    NPSiloMaSilo = objSilo.MaSilo,
                    NPSiloTenSilo = objSilo.TenSilo,
                    SiloValue = new Decimal?(0M),
                    GhiChu = string.Empty
                };
                bindingList.Add(objMacSilo);
            }
            this.BLstMACSilo = bindingList;
        }

        private void SaveData()
        {
            if (!this.ValidateData())
                return;
            this._mac.LstMACSilo = Converter.ConvertToList<ObjMACSilo>(this._bLstMACSilo);
            BindingList<ObjMAC> blstCT = new BindingList<ObjMAC>();
            blstCT.Add(this._mac);
            this._presenter.SaveMAC(blstCT);
        }

        private void SuccessfullySave(bool isSuccess)
        {
            if (!isSuccess)
                return;
            TramTromMessageBox.ShowMessageDialog(GlobalValues.Messages.SuccessProceed);
            this._dlgRes = DialogResult.OK;
            if (this.IsSaveClose)
            {
                this.Close();
            }
            else
            {
                this._presenter.BuildNewMAC();
                this.BindData();
            }
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            this.IsSaveClose = false;
            this.SaveData();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.IsSaveClose = true;
            this.SaveData();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string str1 = txtDoSut.Text;
            string str2 = " ± ";
            txtDoSut.Text = str1 + str2;
        }
    }
}

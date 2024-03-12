using DevExpress.XtraEditors;
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
    public partial class NewMaterialView : ControlViewBase, INewMaterialView, IBase
    {
        private NewMaterialDataPresenter _presenter;
        private string _NewMaterialCaption = "Thêm Vật liệu";
        private string _EditMaterialCaption = "Sửa Vật liệu";
        private string _ViewMaterialCaption = "Xem Vật liệu";
        private ObjMaterial _ct;
        private bool IsSaveClose { get; set; }
        public NewMaterialView()
        {
            InitializeComponent();
            this._presenter = new NewMaterialDataPresenter((INewMaterialView)this);
        }
        public NewMaterialView(ObjMaterial ct, Enums.FormAction action): this()
        {
            this._ct = ct;
            this.FormAction = action;
            this.SetCaption();
        }
        public ObjMaterial Material
        {
            set => this._ct = value;
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
                    this._presenter.BuildNewMaterial();
                    break;
                case Enums.FormAction.Edit:
                    this._presenter.GetMaterialByKey(this._ct.MaterialID);
                    break;
            }
        }

        protected override void PopulateStaticData()
        {
            this.lueDonVi.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.Unit>(true);
        }

        protected override void BindData()
        {
            this.txtMaterialCode.DataBindings.Clear();
            this.txtMaterialCode.DataBindings.Add("Text", (object)this._ct, "MaterialCode");
            this.txtMaterialName.DataBindings.Clear();
            this.txtMaterialName.DataBindings.Add("Text", (object)this._ct, "MaterialName");
            this.txtNhaCungCap.DataBindings.Clear();
            this.txtNhaCungCap.DataBindings.Add("Text", (object)this._ct, "Supplier");
            this.lueDonVi.DataBindings.Clear();
            this.lueDonVi.DataBindings.Add("EditValue", (object)this._ct, "Unit");
            this.spnDonGia.DataBindings.Clear();
            this.spnDonGia.DataBindings.Add("EditValue", (object)this._ct, "Price");
            this.txtDescription.DataBindings.Clear();
            this.txtDescription.DataBindings.Add("Text", (object)this._ct, "Description");
            this.chkActive.DataBindings.Clear();
            this.chkActive.DataBindings.Add("Checked", (object)this._ct, "Activated");
        }

        private void SetCaption()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this.Caption = this._NewMaterialCaption;
                    break;
                case Enums.FormAction.Edit:
                    this.Caption = this._EditMaterialCaption;
                    break;
                case Enums.FormAction.View:
                    this.Caption = this._ViewMaterialCaption;
                    break;
            }
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtMaterialCode.Text == string.Empty)
            {
                this.txtMaterialCode.ErrorText = GlobalValues.Messages.MaterialCodeIsRequired;
                flag = false;
            }
            if (this.txtMaterialName.Text == string.Empty)
            {
                this.txtMaterialName.ErrorText = GlobalValues.Messages.MaterialNameIsRequired;
                flag = false;
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
                    this.txtMaterialCode.Properties.ReadOnly = true;
                    this.txtMaterialName.Properties.ReadOnly = true;
                    this.txtDescription.Properties.ReadOnly = true;
                    this.txtNhaCungCap.Properties.ReadOnly = true;
                    this.lueDonVi.Properties.ReadOnly = true;
                    this.spnDonGia.Properties.ReadOnly = true;
                    this.btnSaveNew.Visible = false;
                    this.btnSave.Visible = false;
                    break;
            }
        }

        private void SaveData()
        {
            if (!this.ValidateData())
                return;
            BindingList<ObjMaterial> blstCT = new BindingList<ObjMaterial>();
            blstCT.Add(this._ct);
            this._presenter.SaveMaterial(blstCT);
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
                this._presenter.BuildNewMaterial();
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

        private void lueDonVi_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lueDonVi.EditValue != DBNull.Value)
                this._ct.Unit = new int?(Convert.ToInt32(this.lueDonVi.EditValue));
        }

        private void spnDonGia_EditValueChanged(object sender, EventArgs e)
        {
            this._ct.Price = new Decimal?(this.spnDonGia.Value);
        }
    }
}

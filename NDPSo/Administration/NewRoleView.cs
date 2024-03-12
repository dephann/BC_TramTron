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

namespace NDPSo.Administration
{
    public partial class NewRoleView : ControlViewBase, INewRoleView, IBase
    {
        private NewRoleDataPresenter _presenter;
        private ObjSEC_Role _role;
        private bool IsSaveClose { get; set; }
        public ObjSEC_Role Role
        {
            set => this._role = value;
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        public NewRoleView()
        {
            InitializeComponent();
            this._presenter = new NewRoleDataPresenter((INewRoleView)this);
        }
        public NewRoleView(ObjSEC_Role user, Enums.FormAction action) : this()
        {
            this._role = user;
            this.FormAction = action;
            this.SetCaption();
        }
        protected override void SetupLayout() => this.DisableConstrol();

        protected override void PopulateStaticData()
        {
        }

        protected override void PopulateData()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this._presenter.BuildNewRole();
                    break;
                case Enums.FormAction.Edit:
                    this._presenter.GetRoleByKey(this._role.RoleID);
                    break;
            }
        }

        protected override void BindData()
        {
            this.txtRoleName.DataBindings.Clear();
            this.txtRoleName.DataBindings.Add("Text", (object)this._role, "RoleName");
            this.txtDesc.DataBindings.Clear();
            this.txtDesc.DataBindings.Add("Text", (object)this._role, "Description");
        }

        private void SetCaption()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this.Caption = "Thêm Vai Trò";
                    break;
                case Enums.FormAction.Edit:
                    this.Caption = "Sửa Vai Trò";
                    break;
                case Enums.FormAction.View:
                    this.Caption = "Xem Vai Trò";
                    break;
            }
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtRoleName.Text == string.Empty)
            {
                this.txtRoleName.ErrorText = "Tên Vai Trò is required.";
                flag = false;
            }
            return flag;
        }

        private void DisableConstrol()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.Edit:
                    this.btnSave.Visible = true;
                    break;
                case Enums.FormAction.View:
                    this.txtRoleName.Properties.ReadOnly = true;
                    this.txtDesc.Properties.ReadOnly = true;
                    this.btnSave.Visible = false;
                    break;
            }
        }

        private void SaveData()
        {
            if (!this.ValidateData())
                return;
            BindingList<ObjSEC_Role> blstCT = new BindingList<ObjSEC_Role>();
            blstCT.Add(this._role);
            this._presenter.SaveRole(blstCT);
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
                this._presenter.BuildNewRole();
                this.BindData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.IsSaveClose = false;
            this.SaveData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

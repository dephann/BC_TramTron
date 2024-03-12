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
    public partial class NewUserView : ControlViewBase, IBase, INewUserView
    {
        private NewUserDataPresenter _presenter;
        private ObjSEC_User _user;
        private bool IsSaveClose { get; set; }
        public ObjSEC_User User
        {
            set => this._user = value;
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }

        public NewUserView()
        {
            InitializeComponent();
            this._presenter = new NewUserDataPresenter((INewUserView)this);
        }
        public NewUserView(ObjSEC_User user, Enums.FormAction action): this()
        {
            this._user = user;
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
                    this._presenter.BuildNewUser();
                    break;
                case Enums.FormAction.Edit:
                    this._presenter.GetUserByKey(this._user.UserID);
                    break;
            }
        }

        protected override void BindData()
        {
            this.txtUserName.DataBindings.Clear();
            this.txtUserName.DataBindings.Add("Text", (object)this._user, "UserName");
            this.txtPass.DataBindings.Clear();
            this.txtPass.DataBindings.Add("Text", (object)this._user, "Password");
            this.txtFullName.DataBindings.Clear();
            this.txtFullName.DataBindings.Add("Text", (object)this._user, "FullName");
            this.txtEmail.DataBindings.Clear();
            this.txtEmail.DataBindings.Add("Text", (object)this._user, "Email");
            this.txtPhone.DataBindings.Clear();
            this.txtPhone.DataBindings.Add("Text", (object)this._user, "Phone");
            /*this.chkIsActive.DataBindings.Clear();
            this.chkIsActive.DataBindings.Add("Checked", (object)this._user, "IsActived");*/
        }

        private void SetCaption()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this.Caption = "THÊM NGƯỜI DÙNG";
                    break;
                case Enums.FormAction.Edit:
                    this.Caption = "CẬP NHẬT THÔNG TIN NGƯỜI DÙNG";
                    break;
                case Enums.FormAction.View:
                    this.Caption = "XEM THÔNG TIN NGƯỜI DÙNG";
                    break;
            }
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtUserName.Text == string.Empty)
            {
                this.txtUserName.ErrorText = "Tên Đăng Nhập is required.";
                flag = false;
            }
            if (this.txtPass.Text == string.Empty && this.txtPass.Text.Length > 30)
            {
                this.txtPass.ErrorText = "Mật Mã is required.";
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
                    this.txtUserName.Properties.ReadOnly = true;
                    this.txtPass.Properties.ReadOnly = true;
                    this.txtFullName.Properties.ReadOnly = true;
                    this.btnSaveNew.Visible = false;
                    this.btnSave.Visible = false;
                    break;
            }
        }

        private void SaveData()
        {
            if (!this.ValidateData())
                return;
            BindingList<ObjSEC_User> blstCT = new BindingList<ObjSEC_User>();
            this._user.IsActived = true;
            blstCT.Add(this._user);
            this._presenter.SaveUser(blstCT);
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
                this._presenter.BuildNewUser();
                this.BindData();
            }
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            this.IsSaveClose = false;
            this.SaveData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.IsSaveClose = true;
            this.SaveData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            this._user.IsActived = new bool?(this.chkIsActive.Checked);
        }

        private void txtPass_EditValueChanged(object sender, EventArgs e)
        {
            if(this.txtPass.Text.Length > 30)
            {
                TramTromMessageBox.ShowWarningDialog("Mật khẩu vượt quá 30 ký tự!");
                this.txtPass.Text = string.Empty;
            }
        }
    }
}

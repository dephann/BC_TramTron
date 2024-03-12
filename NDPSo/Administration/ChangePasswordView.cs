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
    public partial class ChangePasswordView : DialogViewBase, IChangePasswordView, IBase
    {
        private ChangePasswordDataPresenter _presenter;
        private ObjSEC_User _loginUser;
        private string enPassword;
        private string enPasswordNew;

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        public ChangePasswordView()
        {
            InitializeComponent();
            this._presenter = new ChangePasswordDataPresenter((IChangePasswordView)this);
            this.Text = "Thay đổi mật khẩu";
        }
        public ChangePasswordView(ObjSEC_User loginUser) : this()
        {
            this._loginUser = loginUser;
        }
        protected override void AdjustCulture()
        {
            try
            {
                /*this.btnOk.Text = FrmMain.ResMng.GetString("Command.Ok", FrmMain.Culture);
                this.btnCancel.Text = FrmMain.ResMng.GetString("Command.Cancel", FrmMain.Culture);
                this.Text = FrmMain.ResMng.GetString("ChangePasswordView.Text", FrmMain.Culture);
                this.lblOldPass.Text = FrmMain.ResMng.GetString("ChangePasswordView.lblOldPass", FrmMain.Culture);
                this.lblNewPass.Text = FrmMain.ResMng.GetString("ChangePasswordView.lblNewPass", FrmMain.Culture);
                this.lblConfirmNewPass.Text = FrmMain.ResMng.GetString("ChangePasswordView.lblConfirmNewPass", FrmMain.Culture);*/
            }
            catch
            {
            }
        }
        private bool ValidateData()
        {
            enPassword = EncryptionHelper.Encrypt(this.txtOldPass.Text);
            //enPassword =this.txtOldPass.Text;
            if (enPassword != this._loginUser.Password)
            {
                TramTromMessageBox.ShowMessageDialog("Old Password is not correct.");
                return false;
            }
            if (this.txtNewPass.Text != this.txtConfirmPass1.Text)
            {
                TramTromMessageBox.ShowMessageDialog("New Password doesn't match the Confirmation Password.");
                return false;
            }
            return true;
        }
        private void SuccessfullySave(bool isSuccess)
        {
            if (isSuccess)
                this.Close();
            else
                TramTromMessageBox.ShowErrorDialog("Error in updating Password.");
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!this.ValidateData())
                return;
            enPasswordNew = EncryptionHelper.Encrypt(this.txtNewPass.Text);
            this._loginUser.Password = enPasswordNew;
            BindingList<ObjSEC_User> blstUser = new BindingList<ObjSEC_User>();
            blstUser.Add(this._loginUser);
            this._presenter.SaveUser(blstUser);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
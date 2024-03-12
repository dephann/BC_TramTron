using DevExpress.XtraEditors;
using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.Administration
{
    public partial class LoginView : DialogViewBase, ILoginView, IBase
    {
        private LoginDataPresenter _presenter;
        private ObjSEC_User _loginUser;
        private string decryptedPassword;
        public LoginView()
        {
            InitializeComponent();
            this._presenter = new LoginDataPresenter((ILoginView) this);
            this.Text = "Đăng nhập";
            if (ConfigManager.TramTronConfig.DevEnv)
            {
                this.txtUserName.Text = "manager";
                this.txtPassword.Text = "manager";
            }
        }

        public ObjSEC_User LoginUser 
        {
            get => this._loginUser;
            set => this._loginUser = value;
        }

        protected override void AdjustCulture()
        {
            try
            {
                /*this.Text = FrmMain.ResMng.GetString("LoginView.Text", FrmMain.Culture);
                this.lblUsername.Text = FrmMain.ResMng.GetString("LoginView.lblUsername", FrmMain.Culture);
                this.lblPassword.Text = FrmMain.ResMng.GetString("LoginView.lblPassword", FrmMain.Culture);
                this.btnLogin.Text = FrmMain.ResMng.GetString("LoginView.btnLogin", FrmMain.Culture);
                this.btnCancel.Text = FrmMain.ResMng.GetString("LoginView.btnCancel", FrmMain.Culture);*/
            }
            catch (System.Exception ex)
            {
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this._presenter.GetSEC_User_ByUsername_Pass(this.txtUserName.Text, this.txtPassword.Text);
                if (this._loginUser == null)
                    TramTromMessageBox.ShowErrorDialog("Tên đăng nhập không tồn tại");
                else if (!this._loginUser.IsActived.Value)
                {
                    TramTromMessageBox.ShowErrorDialog("Tên đăng nhập không chưa được cấp phép hoạt động");
                }
                else
                {
                    GlobalValues.DisplayUser = this._loginUser.UserName;
                    GlobalValues.DisplayRole = this._loginUser.NPOtherInfo;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    EventLogController.InsertEventLog(new int?(this._loginUser.UserID), this._loginUser.UserName, "LOG_IN", string.Empty, string.Empty, string.Empty);
                }
            }
            catch (WebException ex)
            {
                MessageBox.Show("Không thể kết nối");
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show("Không thể kết nối");
            }
            catch (CommunicationException ex)
            {
                MessageBox.Show("Không thể kết nối");
            }
            catch (System.Exception ex)
            {
                //TramTronLogger.WriteError(ex);
                //TramTromMessageBox.ShowDNErrorDialog(ex);
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnOk_Enter(object sender, EventArgs e)
        {
            
        }

       
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Ngăn việc tạo tiếng "beep"
                e.SuppressKeyPress = true; // Ngăn việc xuống dòng

                try
                {
                    this._presenter.GetSEC_User_ByUsername_Pass(this.txtUserName.Text, this.txtPassword.Text);
                    if (this._loginUser == null)
                        TramTromMessageBox.ShowErrorDialog("Tên đăng nhập không tồn tại");
                    else if (!this._loginUser.IsActived.Value)
                    {
                        TramTromMessageBox.ShowErrorDialog("Tên đăng nhập không chưa được cấp phép hoạt động");
                    }
                    else
                    {
                        GlobalValues.DisplayUser = this._loginUser.UserName;
                        GlobalValues.DisplayRole = this._loginUser.NPOtherInfo;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        EventLogController.InsertEventLog(new int?(this._loginUser.UserID), this._loginUser.UserName, "LOG_IN", string.Empty, string.Empty, string.Empty);
                    }
                }
                catch (WebException ex)
                {
                    TramTromMessageBox.ShowErrorDialog("Không thể kết nối");
                }
                catch (TimeoutException ex)
                {
                    TramTromMessageBox.ShowErrorDialog("Không thể kết nối");
                }
                catch (CommunicationException ex)
                {
                    TramTromMessageBox.ShowErrorDialog("Không thể kết nối");
                }
                catch (System.Exception ex)
                {
                    TramTronLogger.WriteError(ex);
                    //TramTromMessageBox.ShowDNErrorDialog(ex);
                    TramTromMessageBox.ShowErrorDialog(ex.ToString());
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
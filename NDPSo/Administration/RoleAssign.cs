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
    public partial class RoleAssign : ControlViewBase, IBase, IRoleAssignView
    {
        private BindingList<ObjSEC_Role> _blstRole = new BindingList<ObjSEC_Role>();

        private BindingList<ObjSEC_User> _blstUser = new BindingList<ObjSEC_User>();

        private BindingList<ObjSEC_UserRole> _blstUserRole = new BindingList<ObjSEC_UserRole>();

        private RoleAssignDataPresenter _presenter;

        private ObjSEC_User _user;

        public BindingList<ObjSEC_Role> BLstRole 
        {
            set
            {
                this._blstRole = value;
                this.grcRole.DataSource = this._blstRole;
            }
        }
        public BindingList<ObjSEC_User> BLstUser 
        {
            set
            {
                this._blstUser = value;
                this.grcUser.DataSource = this._blstUser;
            }
        }
        public BindingList<ObjSEC_UserRole> BLstUserRole 
        {
            set
            {
                this._blstUserRole = value;
                this.MapUserRole();
            }
        }
        private void MapUserRole()
        {
            foreach (ObjSEC_Role current in this._blstRole)
            {
                current.NPSelect = this.CheckIsSelected(this._user, current);
            }
            this.grvRole.RefreshData();
        }
        protected override void PopulateData()
        {
            this._presenter.ListUserRole();
        }

        protected override void PopulateStaticData()
        {
            this._presenter.ListUser();
            this._presenter.ListRole();
        }

        private void SaveData()
        {
            this._presenter.SaveUserRole(this._blstUserRole);
        }
        private bool CheckIsSelected(ObjSEC_User user, ObjSEC_Role role)
        {
            foreach (ObjSEC_UserRole current in this._blstUserRole)
            {
                if (!current.MarkAsDeleted && current.UserID == user.UserID && current.RoleID == role.RoleID)
                {
                    return true;
                }
            }
            return false;
        }
        public bool IsSuccessfulSaved 
        {
            set
            {
                this.SuccessfullySave(value);
            }
        }
        private void SuccessfullySave(bool isSuccess)
        {
            if (isSuccess)
            {
                this._presenter.ListUserRole();
                TramTromMessageBox.ShowMessageDialog(GlobalValues.Messages.SuccessProceed);
            }
        }
        public RoleAssign()
        {
            InitializeComponent();
            this._presenter = new RoleAssignDataPresenter(this);
            base.Caption = "Phân quyền vai trò";
        }
        private void AssignRole(ObjSEC_User user, ObjSEC_Role role, bool isAssign)
        {
            if (isAssign)
            {
                ObjSEC_UserRole objSEC_UserRole = this.GetUserRole(user, role);
                if (objSEC_UserRole == null)
                {
                    objSEC_UserRole = new ObjSEC_UserRole();
                    objSEC_UserRole.UserID = user.UserID;
                    objSEC_UserRole.RoleID = role.RoleID;
                    this._blstUserRole.Add(objSEC_UserRole);
                    return;
                }
                objSEC_UserRole.MarkAsDeleted = false;
                return;
            }
            else
            {
                ObjSEC_UserRole userRole = this.GetUserRole(user, role);
                if (userRole.IsNewObject)
                {
                    this._blstUserRole.Remove(userRole);
                    return;
                }
                userRole.MarkAsDeleted = true;
                return;
            }
        }
        private ObjSEC_UserRole GetUserRole(ObjSEC_User user, ObjSEC_Role role)
        {
            foreach (ObjSEC_UserRole current in this._blstUserRole)
            {
                if (current.UserID == user.UserID && current.RoleID == role.RoleID)
                {
                    return current;
                }
            }
            return null;
        }
        private void grvUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                this._user = (this.grvUser.GetRow(this.grvUser.FocusedRowHandle) as ObjSEC_User);
                this.MapUserRole();
            }
        }

        private void grvRole_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ObjSEC_Role role = this.grvRole.GetRow(this.grvRole.FocusedRowHandle) as ObjSEC_Role;
            this.AssignRole(this._user, role, Convert.ToBoolean(e.Value));
            //MessageBox.Show(e.Value.ToString());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

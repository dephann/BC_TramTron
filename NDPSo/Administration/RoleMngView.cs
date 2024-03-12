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

namespace NDPSo.Administration
{
    public partial class RoleMngView : ControlViewBase, IRoleMngView,  IBase, IPermission
    {
        private RoleMngDataPresenter _presenter;
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }
        private BindingList<ObjSEC_Role> _blstRole = new BindingList<ObjSEC_Role>();
        public BindingList<ObjSEC_Role> BLstRole
        {
            set
            {
                this._blstRole = value;
                this.grcRole.DataSource = (object)this._blstRole;
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }

        public RoleMngView()
        {
            InitializeComponent();
            this._presenter = new RoleMngDataPresenter((IRoleMngView)this);
            this.Caption = this.bsiCaption.Caption;
        }
        protected override void PopulateData() => this._presenter.ListRole();
        private void SuccessfullySave(bool isSuccess)
        {
        }

        private void bbiInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewRoleView ctrView = new NewRoleView((ObjSEC_Role)null, Enums.FormAction.New);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListRole();
            this.FocusRow(this.grvRole, this.grvRole.RowCount);
        }

        private void bbiUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvRole.RowCount == 0)
                return;
            int focusedRowHandle = this.grvRole.FocusedRowHandle;
            NewRoleView ctrView = new NewRoleView(this.grvRole.GetRow(focusedRowHandle) as ObjSEC_Role, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListRole();
            this.FocusRow(this.grvRole, focusedRowHandle);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TramTromMessageBox.ShowYesNoDialog("Xác nhận xóa dữ liệu đã chọn.") != DialogResult.Yes)
                return;
            BindingList<ObjSEC_Role> blstCT = new BindingList<ObjSEC_Role>();
            foreach (int selectedRow in this.grvRole.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjSEC_Role row = this.grvRole.GetRow(selectedRow) as ObjSEC_Role;
                    row.MarkAsDeleted = true;
                    blstCT.Add(row);
                }
            }
            foreach (ObjSEC_Role objSecRole in (Collection<ObjSEC_Role>)blstCT)
                this._blstRole.Remove(objSecRole);
            this.FocusRow(this.grvRole, this.grvRole.RowCount);
            this._presenter.SaveRole(blstCT);
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvRole.RowCount == 0)
                return;
            ViewManager.ShowViewDialog((ControlViewBase)new NewRoleView(this.grvRole.GetRow(this.grvRole.FocusedRowHandle) as ObjSEC_Role, Enums.FormAction.View));

        }
        private void BindPermission()
        {
            this.bbiInsert.Enabled = this.CheckHasPermission(this.bbiInsert.Name);
            this.bbiUpdate.Enabled = this.CheckHasPermission(this.bbiUpdate.Name);
            this.bbiDelete.Enabled = this.CheckHasPermission(this.bbiDelete.Name);
            this.bbiView.Enabled = this.CheckHasPermission(this.bbiView.Name);
        }

        private bool CheckHasPermission(string funcName)
        {
            foreach (ObjSEC_Function current in this._lstFunction)
            {
                if (current.MenuName == funcName)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

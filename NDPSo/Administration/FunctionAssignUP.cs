using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class FunctionAssignUP : ControlViewBase, IFunctionAssignView, IBase
    {
        private FunctionAssignDataPresenter _presenter;
        private ObjSEC_Role _role;
        private BindingList<ObjSEC_Function> _blstFunction_FuncType = new BindingList<ObjSEC_Function>();
        private BindingList<ObjSEC_Function> _blstFunction_MenuType = new BindingList<ObjSEC_Function>();
        private BindingList<ObjSEC_Role> _blstRole = new BindingList<ObjSEC_Role>();
        private BindingList<ObjSEC_RoleFunction> _blstRoleFunction = new BindingList<ObjSEC_RoleFunction>();

        public FunctionAssignUP()
        {
            InitializeComponent();
            this._presenter = new FunctionAssignDataPresenter((IFunctionAssignView)this);
            this.Caption = "Phân quyền chức năng";
        }

        BindingList<ObjSEC_Function> IFunctionAssignView.BLstFunction_FuncType 
        {
            set
            {
                this._blstFunction_FuncType = value;
                foreach (ObjSEC_Function objSecFunction1 in (Collection<ObjSEC_Function>)this._blstFunction_MenuType)
                {
                    objSecFunction1.LstChildFunction = new List<ObjSEC_Function>();
                    foreach (ObjSEC_Function objSecFunction2 in (Collection<ObjSEC_Function>)this._blstFunction_FuncType)
                    {
                        int? parentId = objSecFunction2.ParentID;
                        int functionId = objSecFunction1.FunctionID;
                        if (parentId.GetValueOrDefault() == functionId & parentId.HasValue)
                            objSecFunction1.LstChildFunction.Add(objSecFunction2);
                    }
                }
            }
        }
        BindingList<ObjSEC_Function> IFunctionAssignView.BLstFunction_MenuType 
        {
            set
            {
                this._blstFunction_MenuType = value;
                this.grcFunction.DataSource = (object)this._blstFunction_MenuType;
            }
        }
        BindingList<ObjSEC_Role> IFunctionAssignView.BLstRole 
        {
            set
            {
                this._blstRole = value;
                this.grcRole.DataSource = (object)this._blstRole;
            }
        }
        BindingList<ObjSEC_RoleFunction> IFunctionAssignView.BLstRoleFunction 
        {
            set
            {
                this._blstRoleFunction = value;
                this.MapRoleFunction();
            }
        }
        bool IFunctionAssignView.IsSuccessfulSaved 
        {
            set => this.SuccessfullySave(value);
        }
        protected override void PopulateStaticData()
        {
            this._presenter.ListRole();
            this._presenter.ListFunction_MenuType();
            this._presenter.ListFunction_FuncType();
        }

        protected override void PopulateData() => this._presenter.ListRoleFunction();

        private void MapRoleFunction()
        {
            foreach (ObjSEC_Function function in (Collection<ObjSEC_Function>)this._blstFunction_MenuType)
                function.NPSelect = this.CheckIsSelected(this._role, function);
            foreach (ObjSEC_Function function in (Collection<ObjSEC_Function>)this._blstFunction_FuncType)
                function.NPSelect = this.CheckIsSelected(this._role, function);
            this.grvFunction.RefreshData();
            for (int rowHandle = 0; rowHandle < this.grvFunction.DataRowCount; ++rowHandle)
            {
                if (this.grvFunction.GetVisibleDetailView(rowHandle) is GridView visibleDetailView)
                    visibleDetailView.RefreshData();
            }
        }

        private bool CheckIsSelected(ObjSEC_Role role, ObjSEC_Function function)
        {
            foreach (ObjSEC_RoleFunction objSecRoleFunction in (Collection<ObjSEC_RoleFunction>)this._blstRoleFunction)
            {
                if (!objSecRoleFunction.MarkAsDeleted && objSecRoleFunction.RoleID == role.RoleID && objSecRoleFunction.FunctionID == function.FunctionID)
                    return true;
            }
            return false;
        }

        private ObjSEC_RoleFunction GetRoleFunction(ObjSEC_Role role, ObjSEC_Function function)
        {
            foreach (ObjSEC_RoleFunction roleFunction in (Collection<ObjSEC_RoleFunction>)this._blstRoleFunction)
            {
                if (roleFunction.RoleID == role.RoleID && roleFunction.FunctionID == function.FunctionID)
                    return roleFunction;
            }
            return (ObjSEC_RoleFunction)null;
        }

        private void AssignFunction(ObjSEC_Role role, ObjSEC_Function function, bool isAssign)
        {
            if (isAssign)
            {
                ObjSEC_RoleFunction roleFunction = this.GetRoleFunction(role, function);
                if (roleFunction == null)
                    this._blstRoleFunction.Add(new ObjSEC_RoleFunction()
                    {
                        RoleID = role.RoleID,
                        FunctionID = function.FunctionID
                    });
                else
                    roleFunction.MarkAsDeleted = false;
            }
            else
            {
                ObjSEC_RoleFunction roleFunction = this.GetRoleFunction(role, function);
                if (roleFunction.IsNewObject)
                    this._blstRoleFunction.Remove(roleFunction);
                else
                    roleFunction.MarkAsDeleted = true;
            }
        }

        private void SaveData() => this._presenter.SaveRoleFunction(this._blstRoleFunction);

        private void SuccessfullySave(bool isSuccess)
        {
            if (!isSuccess)
                return;
            this._presenter.ListRoleFunction();
            TramTromMessageBox.ShowMessageDialog(GlobalValues.Messages.SuccessProceed);
        }

        private void grvRole_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                return;
            this._role = this.grvRole.GetRow(this.grvRole.FocusedRowHandle) as ObjSEC_Role;
            this.MapRoleFunction();
        }

        private void grvFunction_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) => this.AssignFunction(this._role, this.grvFunction.GetRow(this.grvFunction.FocusedRowHandle) as ObjSEC_Function, Convert.ToBoolean(e.Value));

        private void grvFunctionDetail_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e) => this.AssignFunction(this._role, (sender as GridView).GetRow(e.RowHandle) as ObjSEC_Function, Convert.ToBoolean(e.Value));

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

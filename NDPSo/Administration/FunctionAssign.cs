using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
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
    public partial class FunctionAssign : ControlViewBase, IFunctionAssignView, IBase
    {
        private FunctionAssignDataPresenter _presenter;
        private ObjSEC_Role _role;
        private BindingList<ObjSEC_Function> _blstFunction_FuncType = new BindingList<ObjSEC_Function>();
        private BindingList<ObjSEC_Function> _blstFunction_MenuType = new BindingList<ObjSEC_Function>();
        private BindingList<ObjSEC_Role> _blstRole = new BindingList<ObjSEC_Role>();
        private BindingList<ObjSEC_RoleFunction> _blstRoleFunction = new BindingList<ObjSEC_RoleFunction>();

        public BindingList<ObjSEC_Function> BLstFunction_FuncType
        {
            set
            {
                this._blstFunction_FuncType = value;
                foreach (ObjSEC_Function current in this._blstFunction_MenuType)
                {
                    current.LstChildFunction = new List<ObjSEC_Function>();
                    foreach (ObjSEC_Function current2 in this._blstFunction_FuncType)
                    {
                        int? parentID = current2.ParentID;
                        int functionID = current.FunctionID;
                        if (parentID.GetValueOrDefault() == functionID & parentID != null)
                        {
                            current.LstChildFunction.Add(current2);
                        }
                    }
                }
            }
        }

        public BindingList<ObjSEC_Function> BLstFunction_MenuType
        {
            set
            {
                this._blstFunction_MenuType = value;
                this.grcFunction.DataSource = (object)this._blstFunction_MenuType;
            }
        }

        public BindingList<ObjSEC_Role> BLstRole
        {
            set
            {
                this._blstRole = value;
                this.grcRole.DataSource = (object)this._blstRole;
            }
        }

        public BindingList<ObjSEC_RoleFunction> BLstRoleFunction
        {
            set
            {
                this._blstRoleFunction = value;
                this.MapRoleFunction();
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }


        public FunctionAssign()
        {
            this.InitializeComponent();
            this._presenter = new FunctionAssignDataPresenter((IFunctionAssignView)this);
            this.Caption = "Phân quyền chức năng";
        }
        private void AssignFunction(ObjSEC_Role role, ObjSEC_Function function, bool isAssign)
        {
            if (isAssign)
            {
                ObjSEC_RoleFunction objSEC_RoleFunction = this.GetRoleFunction(role, function);
                if (objSEC_RoleFunction == null)
                {
                    objSEC_RoleFunction = new ObjSEC_RoleFunction();
                    objSEC_RoleFunction.RoleID = role.RoleID;
                    objSEC_RoleFunction.FunctionID = function.FunctionID;
                    this._blstRoleFunction.Add(objSEC_RoleFunction);
                    return;
                }
                objSEC_RoleFunction.MarkAsDeleted = false;
                return;
            }
            else
            {
                ObjSEC_RoleFunction roleFunction = this.GetRoleFunction(role, function);
                if (roleFunction.IsNewObject)
                {
                    this._blstRoleFunction.Remove(roleFunction);
                    return;
                }
                roleFunction.MarkAsDeleted = true;
                return;
            }
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
            {
                function.NPSelect = this.CheckIsSelected(this._role, function);
            }
                
            foreach (ObjSEC_Function function in (Collection<ObjSEC_Function>)this._blstFunction_FuncType)
            {
                function.NPSelect = this.CheckIsSelected(this._role, function);
            }
                
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

        private void grvFunction_CellValueChanging(object sender, CellValueChangedEventArgs e) => this.AssignFunction(this._role, this.grvFunction.GetRow(this.grvFunction.FocusedRowHandle) as ObjSEC_Function, Convert.ToBoolean(e.Value));

        private void grvFunctionDetail_CellValueChanging(object sender, CellValueChangedEventArgs e) => this.AssignFunction(this._role, (sender as GridView).GetRow(e.RowHandle) as ObjSEC_Function, Convert.ToBoolean(e.Value));

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

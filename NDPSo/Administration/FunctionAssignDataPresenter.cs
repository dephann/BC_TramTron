using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
    public class FunctionAssignDataPresenter : AdministrationPresenter<IFunctionAssignView>
    {
        public FunctionAssignDataPresenter(IFunctionAssignView view)
          : base(view)
        {
        }

        public void ListFunction_FuncType() => this._iView.BLstFunction_FuncType = AdministrationPresenter<IFunctionAssignView>._iAdministrationModel.ListSEC_Function_ByFunctionType(2);

        public void ListFunction_MenuType() => this._iView.BLstFunction_MenuType = AdministrationPresenter<IFunctionAssignView>._iAdministrationModel.ListSEC_Function_ByFunctionType(1);

        public void ListRole() => this._iView.BLstRole = AdministrationPresenter<IFunctionAssignView>._iAdministrationModel.ListSEC_Role();

        public void ListRoleFunction() => this._iView.BLstRoleFunction = AdministrationPresenter<IFunctionAssignView>._iAdministrationModel.ListSEC_RoleFunction();

        public void SaveRoleFunction(BindingList<ObjSEC_RoleFunction> blstRoleFunction) => this._iView.IsSuccessfulSaved = AdministrationPresenter<IFunctionAssignView>._iAdministrationModel.SaveSEC_RoleFunction(blstRoleFunction);
    }
}

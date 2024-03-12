using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public interface IFunctionAssignView : IBase
	{
		BindingList<ObjSEC_Function> BLstFunction_FuncType { set; }

		BindingList<ObjSEC_Function> BLstFunction_MenuType { set; }

		BindingList<ObjSEC_Role> BLstRole { set; }

		BindingList<ObjSEC_RoleFunction> BLstRoleFunction { set; }

		bool IsSuccessfulSaved { set; }
	}
}
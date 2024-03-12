using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public class RoleAssignDataPresenter : AdministrationPresenter<IRoleAssignView>
	{
		public RoleAssignDataPresenter(IRoleAssignView view) : base(view)
		{
		}

		public void ListRole()
		{
			base._iView.BLstRole = AdministrationPresenter<IRoleAssignView>._iAdministrationModel.ListSEC_Role();
		}

		public void ListUser()
		{
			base._iView.BLstUser = AdministrationPresenter<IRoleAssignView>._iAdministrationModel.ListSEC_User();
		}

		public void ListUserRole()
		{
			base._iView.BLstUserRole = AdministrationPresenter<IRoleAssignView>._iAdministrationModel.ListSEC_UserRole();
		}

		public void SaveUserRole(BindingList<ObjSEC_UserRole> blstUserRole)
		{
			base._iView.IsSuccessfulSaved = AdministrationPresenter<IRoleAssignView>._iAdministrationModel.SaveSEC_UserRole(blstUserRole);
		}
	}
}

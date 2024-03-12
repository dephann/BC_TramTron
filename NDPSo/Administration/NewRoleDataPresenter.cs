using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public class NewRoleDataPresenter : AdministrationPresenter<INewRoleView>
	{
		public NewRoleDataPresenter(INewRoleView view) : base(view)
		{
		}

		public void BuildNewRole()
		{
			ObjSEC_Role role = new ObjSEC_Role
			{
				RoleName = string.Empty,
				Description = string.Empty
			};
			base._iView.Role = role;
		}

		public void GetRoleByKey(int soID)
		{
			ObjSEC_Role sEC_RoleByKey = AdministrationPresenter<INewRoleView>._iAdministrationModel.GetSEC_RoleByKey(soID);
			base._iView.Role = sEC_RoleByKey;
		}

		public void SaveRole(BindingList<ObjSEC_Role> blstCT)
		{
			base._iView.IsSuccessfulSaved = AdministrationPresenter<INewRoleView>._iAdministrationModel.SaveSEC_Role(blstCT);
		}
	}
}

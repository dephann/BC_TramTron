using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public class RoleMngDataPresenter : AdministrationPresenter<IRoleMngView>
	{
		public RoleMngDataPresenter(IRoleMngView view) : base(view)
		{
		}

		public void ListRole()
		{
			base._iView.BLstRole = AdministrationPresenter<IRoleMngView>._iAdministrationModel.ListSEC_Role();
		}

		public void SaveRole(BindingList<ObjSEC_Role> blstCT)
		{
			base._iView.IsSuccessfulSaved = AdministrationPresenter<IRoleMngView>._iAdministrationModel.SaveSEC_Role(blstCT);
		}
	}
}

using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public class UserMngDataPresenter : AdministrationPresenter<IUserMngView>
	{
		public UserMngDataPresenter(IUserMngView view) : base(view)
		{
		}

		public void ListUser()
		{
			base._iView.BLstUser = AdministrationPresenter<IUserMngView>._iAdministrationModel.ListSEC_User();
		}
		public void ListUser_ByActive(bool? active)
        {
			base._iView.BLstUser = AdministrationPresenter<IUserMngView>._iAdministrationModel.ListSEC_User_ByActive(active);
        }
		public void SaveUser(BindingList<ObjSEC_User> blstCT)
		{
			base._iView.IsSuccessfulSaved = AdministrationPresenter<IUserMngView>._iAdministrationModel.SaveSEC_User(blstCT);
		}
	}
}

using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public class NewUserDataPresenter : AdministrationPresenter<INewUserView>
	{
		public NewUserDataPresenter(INewUserView view) : base(view)
		{
		}

		public void BuildNewUser()
		{
			ObjSEC_User user = new ObjSEC_User
			{
				UserName = string.Empty,
				Password = string.Empty,
				FullName = string.Empty,
				Department = string.Empty,
				Email = string.Empty,
				Phone = string.Empty,
				IsActived = new bool?(true),
				IsInUse = new bool?(false)
			};
			base._iView.User = user;
		}

		public void GetUserByKey(int soID)
		{
			ObjSEC_User sEC_UserByKey = AdministrationPresenter<INewUserView>._iAdministrationModel.GetSEC_UserByKey(soID);
			base._iView.User = sEC_UserByKey;
		}

		public void SaveUser(BindingList<ObjSEC_User> blstCT)
		{
			base._iView.IsSuccessfulSaved = AdministrationPresenter<INewUserView>._iAdministrationModel.SaveSEC_User(blstCT);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public class LoginDataPresenter : AdministrationPresenter<ILoginView>
	{
		public LoginDataPresenter(ILoginView view) : base(view)
		{
		}

		public void GetSEC_User_ByUsername_Pass(string username, string password)
		{
			base._iView.LoginUser = AdministrationPresenter<ILoginView>._iAdministrationModel.GetSEC_User_ByUsername_Pass(username, password);
		}
	}
}

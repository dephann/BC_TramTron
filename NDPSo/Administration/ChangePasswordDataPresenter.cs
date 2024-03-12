using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
    public class ChangePasswordDataPresenter : AdministrationPresenter<IChangePasswordView>
    {
        public ChangePasswordDataPresenter(IChangePasswordView view)
          : base(view)
        {
        }

        public void SaveUser(BindingList<ObjSEC_User> blstUser) => this._iView.IsSuccessfulSaved = AdministrationPresenter<IChangePasswordView>._iAdministrationModel.SaveSEC_User(blstUser);
    }
}

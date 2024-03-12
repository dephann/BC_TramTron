using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public interface IUserMngView : IBase, IPermission
	{
		BindingList<ObjSEC_User> BLstUser { set; }

		bool IsSuccessfulSaved { set; }
	}
}

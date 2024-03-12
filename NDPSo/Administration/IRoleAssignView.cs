using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public interface IRoleAssignView : IBase
	{
		BindingList<ObjSEC_Role> BLstRole { set; }

		BindingList<ObjSEC_User> BLstUser { set; }

		BindingList<ObjSEC_UserRole> BLstUserRole { set; }

		bool IsSuccessfulSaved { set; }
	}
}

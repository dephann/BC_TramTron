using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public interface IRoleMngView : IBase, IPermission
	{
		BindingList<ObjSEC_Role> BLstRole { set; }

		bool IsSuccessfulSaved { set; }
	}
}

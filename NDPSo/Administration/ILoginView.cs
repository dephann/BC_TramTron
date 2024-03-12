using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public interface ILoginView : IBase
	{
		ObjSEC_User LoginUser { set; }
	}
}

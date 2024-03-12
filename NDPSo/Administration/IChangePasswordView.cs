using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Administration
{
	public interface IChangePasswordView : IBase
	{
		bool IsSuccessfulSaved { set; }
	}
}


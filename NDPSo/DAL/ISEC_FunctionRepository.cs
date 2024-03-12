using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public interface ISEC_FunctionRepository : IEFRepository<SEC_Function>
	{
		IList<SEC_Function> ListSEC_Function_ByFunctionType(int funcType);

		IList<SEC_Function> ListSEC_Function_ByUserID(int userID);
	}
}

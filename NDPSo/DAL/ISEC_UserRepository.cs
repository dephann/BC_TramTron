using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public interface ISEC_UserRepository : IEFRepository<SEC_User>
	{
		SEC_User GetSEC_User_ByUsername_Pass(string username, string password);
		IList<SEC_User> ListSEC_User_ByActive(bool? active);

	}
}
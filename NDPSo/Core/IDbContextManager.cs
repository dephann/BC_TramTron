using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Core
{
	public interface IDbContextManager
	{
		IDBContext GetDBContext();
	}
}	

using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
	public interface ISiloRepository : IEFRepository<Silo>
	{
		IList<Silo> ListSilo_ByActivated(bool activated);

		IList<Silo> ListSilo_ByActivated_MaNhomSilo(bool? activated, string maNhomSL);
	}
}

using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
	public interface ICongTruongMngView : IBase, IPermission
	{
		BindingList<ObjCongTruong> BLstCongTruong { set; }

		bool IsSuccessfulSaved { set; }
	}
}

using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface IMACMngView : IBase, IPermission
    {
        BindingList<ObjMAC> BLstMAC { set; }

        bool IsSuccessfulSaved { set; }
    }
}

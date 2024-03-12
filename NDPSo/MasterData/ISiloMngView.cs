using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface ISiloMngView : IBase, IPermission
    {
        BindingList<ObjSilo> BLstSilo { set; }

        BindingList<ObjNhomSilo> BLstNhomSilo { set; }

        bool IsSuccessfulSaved { set; }
    }
}

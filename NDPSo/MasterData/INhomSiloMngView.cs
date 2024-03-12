using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface INhomSiloMngView : IBase, IPermission
    {
        BindingList<ObjNhomSilo> BLstNhomSilo { set; }

        bool IsSuccessfulSaved { set; }
    }
}

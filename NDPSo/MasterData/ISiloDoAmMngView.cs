using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface ISiloDoAmMngView : IBase, IPermission
    {
        BindingList<ObjSilo> BLstSiloDoAm { set; }

        bool IsSuccessfulSaved { set; }
    }
}
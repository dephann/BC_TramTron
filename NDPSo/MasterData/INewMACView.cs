using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface INewMACView : IBase
    {
        ObjMAC MAC { set; }

        BindingList<ObjSilo> BLstSilo { set; }

        BindingList<ObjMACSilo> BLstMACSilo { set; }

        bool IsSuccessfulSaved { set; }
    }
}


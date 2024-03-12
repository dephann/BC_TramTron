using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface ITimerParaMngView : IBase, IPermission
    {
        BindingList<ObjTimerPara> BLstTimerPara { set; }

        bool IsSuccessfulSaved { set; }
    }
}


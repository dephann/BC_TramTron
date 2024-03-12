using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface IXeMngView : IBase, IPermission
    {
        BindingList<ObjXe> BLstXe { set; }

        bool IsSuccessfulSaved { set; }
    }
}

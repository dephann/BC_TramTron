using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface ITinhDoHutNuocMngView : IBase, IPermission
    {
        BindingList<ObjTinhDoHutNuoc> BLstTinhDoHutNuoc { set; }

        bool IsSuccessfulSaved { set; }

        BindingList<ObjNhomSilo> BLstNhomSilo { set; }
    }
}

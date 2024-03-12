using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    interface IHangMucMngView : IBase, IPermission
    {
        BindingList<ObjHangMuc> BLstHangMuc { set; }

        bool IsSuccessfulSaved { set; }
    }
}
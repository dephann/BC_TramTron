using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    interface INhanVienMngView : IBase, IPermission
    {
        BindingList<ObjNhanVien> BLstNhanVien { set; }

        bool IsSuccessfulSaved { set; }
    }
}


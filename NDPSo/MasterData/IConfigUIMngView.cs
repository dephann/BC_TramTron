using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    interface IConfigUIMngView : IBase, IPermission
    {
        BindingList<ObjSilo> BLstSilo_Agg { set; }
        BindingList<ObjSilo> BLstSilo_Ce { set; }
        BindingList<ObjSilo> BLstSilo_Wa { set; }
        BindingList<ObjSilo> BLstSilo_Add { set; }

        BindingList<ObjNhomSilo> BLstNhomSilo { set; }

        bool IsSuccessfulSaved { set; }
    }
}
using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface INewSiloView : IBase
    {
        ObjSilo Silo { set; }

        BindingList<ObjNhomSilo> BLstNhomSilo { set; }

        BindingList<ObjSilo> BLstSiloNhomAgg { set; }

        BindingList<ObjMaterial> BLstMaterial { set; }

        bool IsSuccessfulSaved { set; }
    }
}
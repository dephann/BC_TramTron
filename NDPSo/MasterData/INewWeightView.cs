using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NDPSo.Data;

namespace NDPSo.MasterData
{
    interface INewWeightView : IBase
    {
        ObjWeigh Weight { set; }

        bool IsSuccessfulSaved { set; }
    }
}

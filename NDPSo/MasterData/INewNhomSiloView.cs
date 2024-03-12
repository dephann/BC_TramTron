using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface INewNhomSiloView : IBase
    {
        ObjNhomSilo NhomSilo { set; }

        bool IsSuccessfulSaved { set; }
    }
}

using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface INewXeView : IBase
    {
        ObjXe Xe { set; }

        bool IsSuccessfulSaved { set; }
    }
}

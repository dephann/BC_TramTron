using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    interface INewNhanVienView : IBase
    {
        ObjNhanVien NhanVien { set; }

        bool IsSuccessfulSaved { set; }
    }
}

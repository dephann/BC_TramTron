using NDPSo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public interface INewMaterialView : IBase
    {
        ObjMaterial Material { set; }

        bool IsSuccessfulSaved { set; }
    }
}
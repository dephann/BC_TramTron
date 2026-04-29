using NDPSo.Data;
using System.Collections.Generic;

namespace NDPSo.MasterData
{
    public interface IOptimizeScheduleView : IBase
    {
        List<ObjScheduleItem> LstScheduleItems { set; }
        List<ObjDuLieuTron> LstPendingDuLieuTron { set; }
        List<ObjMAC> LstMAC { set; }
    }
}

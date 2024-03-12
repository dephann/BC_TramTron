using NDPSo.Core;
using NDPSo.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.DAL
{
    public interface IMeTronRepository : IEFRepository<MeTron>
    {
        MeTron GetMeTron(int phieuTronId, int lnNo);

        MeTron GetLatestMeTronFromPhieuTron(int phieuTronId);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.KWS
{
    public class ObjMaterialSummary
    {
        public int MaterialID { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialName { get; set; }
        public decimal Sum_ValueCP { get; set; }
        public decimal Sum_ValueBat { get; set; }
        public decimal Sum_ValueBatMan { get; set; }
        public decimal SaiSo { get; set; }
        public decimal PerSaiSo { get; set; }
        public bool IsManual {  get; set; }

    }
}

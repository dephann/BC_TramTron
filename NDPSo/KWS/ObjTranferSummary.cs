using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.KWS
{
    public class ObjTranferSummary
    {
        public int XeID { get; set; }
        public string BienSo { get; set; }
        public int? Total_Tranfer { get; set; }
        public decimal? Total_KL { get; set; }
        public bool? IsManual { get; set; }
    }
}

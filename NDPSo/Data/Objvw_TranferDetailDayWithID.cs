using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    [DataContract]
    public class Objvw_TranferDetailDayWithID
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int XeID { get; set; }
        [DataMember]
        public string BienSo { get; set; }
        [DataMember]
        public int? Total_Tranfer { get; set; }
        [DataMember]
        public decimal? Total_KL { get; set; }
        [DataMember]
        public DateTime? NgayMeTron { get; set; }
        [DataMember]
        public bool? IsQueued { get; set; }
    }
}

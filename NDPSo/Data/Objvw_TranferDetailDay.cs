using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
    [DataContract]

    public class Objvw_TranferDetailDay
    {
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

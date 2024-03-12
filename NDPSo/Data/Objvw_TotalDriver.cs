using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
    [DataContract]
    public class Objvw_TotalDriver
    {
        [DataMember]
        public int TaiXeID { get; set; }
        [DataMember]
        public string MaTaiXe { get; set; }
        [DataMember]
        public string TenTaiXe { get; set; }
        [DataMember]
        public int? Total_Tranfer { get; set; }
        [DataMember]
        public decimal? Total_KL { get; set; }
        [DataMember]
        public bool? IsManual { get; set; }

    }
}

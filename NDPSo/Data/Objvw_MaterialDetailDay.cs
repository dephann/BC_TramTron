using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
    [DataContract]
    public class Objvw_MaterialDetailDay
    {
        [DataMember]
        public DateTime? NgayMeTron { get; set; }
        [DataMember]
        public int MaterialID { get; set; }
        [DataMember]
        public string MaterialCode { get; set; }
        [DataMember]
        public string MaterialName { get; set; }
        [DataMember]
        public decimal? Sum_ValueCP { get; set; }
        [DataMember]
        public decimal? Sum_ValueBat { get; set; }
        [DataMember]
        public decimal? Sum_ValueBatMan { get; set; }
        [DataMember]
        public decimal? SaiSo { get; set; }
        [DataMember]
        public decimal? PerSaiSo { get; set; }
        [DataMember]
        public bool? IsManual { get; set; }
    }
}

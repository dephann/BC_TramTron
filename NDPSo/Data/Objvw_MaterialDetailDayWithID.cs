using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    [DataContract]
    public class Objvw_MaterialDetailDayWithID
    {
        [DataMember]
        public int ID { get; set; }
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

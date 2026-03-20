using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    [DataContract]
    public  class Objvw_DriverDetailDayWithID
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime? NgayMeTron { get; set; }
        [DataMember]
        public int TaiXeID { get; set; }
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

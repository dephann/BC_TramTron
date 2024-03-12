using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    [DataContract]
    public class ObjTaiXe : ObjectBase
    {
        [DataMember]
        public int TaiXeID { get; set; }

        [DataMember]
        public string MaTaiXe { get; set; }

        [DataMember]
        public string TenTaiXe { get; set; }

        [DataMember]
        public int? NamSinh { get; set; }

        [DataMember]
        public string GioiTinh { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string GhiChu { get; set; }

        [DataMember]
        public bool Activated { get; set; }

        [DataMember]
        public DateTime? CreationDate { get; set; }

        [DataMember]
        public int? CreatedBy { get; set; }

        [DataMember]
        public DateTime? LatestUpdateDate { get; set; }

        [DataMember]
        public int? LatestUpdatedBy { get; set; }

        [DataMember]
        public byte[] VersionNo { get; set; }
    }
}

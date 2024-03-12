using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    public class ObjHangMuc : ObjectBase
    {
        [DataMember]
        public int HangMucID { get; set; }

        [DataMember]
        public string MaHangMuc { get; set; }

        [DataMember]
        public string TenHangMuc { get; set; }

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

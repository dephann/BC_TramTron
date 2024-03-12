using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    [DataContract]
    public class ObjNhanVien : ObjectBase
    {
        [DataMember]
        public int NhanVienID { get; set; }

        [DataMember]
        public string MaNhanVien { get; set; }

        [DataMember]
        public string TenNhanVien { get; set; }

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

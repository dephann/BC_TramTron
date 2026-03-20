using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
    [DataContract]
    public class ObjPhieuGiaoHang : ObjectBase
    {
        [DataMember]
        public int PhieuTronID { get; set; }

        [DataMember]
        public string MaPhieuTron { get; set; }

        [DataMember]
        public int? NoPhieu { get; set; }

        [DataMember]
        public DateTime? NgayPhieuTron { get; set; }

        [DataMember]
        public decimal? KLDuTinh { get; set; }

        [DataMember]
        public decimal? KLThuc { get; set; }

        [DataMember]
        public decimal? KLTronNhoNhat { get; set; }

        [DataMember]
        public decimal? KLTronLonNhat { get; set; }

        [DataMember]
        public decimal? KLDuTinhCuaTungMe { get; set; }

        [DataMember]
        public decimal? KLBuTruMeCuoi { get; set; }

        [DataMember]
        public decimal? SLMeDuTinh { get; set; }

        [DataMember]
        public decimal? SLMeHieuChinh { get; set; }

        [DataMember]
        public decimal? SLMeDaTron { get; set; }

        [DataMember]
        public int? HopDongID { get; set; }

        [DataMember]
        public int? KhachHangID { get; set; }
        [DataMember]
        public string TenKhachHang { get; set; }
        [DataMember]
        public int? CongTruongID { get; set; }
        [DataMember]
        public string TenCongTruong { get; set; }
        [DataMember]
        public int? HangMucID { get; set; }
        [DataMember]
        public string TenHangMuc { get; set; }
        [DataMember]
        public string DiaDiem { get; set; }
        [DataMember]
        public int? MACID { get; set; }
        [DataMember]
        public string TenMAC { get; set; }
        [DataMember]
        public string CuongDo { get; set; }
        [DataMember]
        public string DoSut { get; set; }
        [DataMember]
        public decimal? TheTich { get; set; }
        [DataMember]
        public decimal? LuyKe { get; set; }
        [DataMember]
        public int? TaiXeID { get; set; }

        [DataMember]
        public string TenTaiXe { get; set; }
        [DataMember]
        public int? XeID { get; set; }
        [DataMember]
        public string BienSo { get; set; }
        [DataMember]
        public string NiemChi { get; set; }
        [DataMember]
        public string NguoiTron { get; set; }
        [DataMember]
        public string Temp1 { get; set; }
        [DataMember]
        public string Temp2 { get; set; } // KL DatHang
        
        [DataMember]
        public string GioBD { get; set; }
        [DataMember]
        public string GioKT { get; set; }

        [DataMember]
        public bool? Activated { get; set; }
        [DataMember]
        public DateTime? CreationDate { get; set; }
        [DataMember]
        public int? CreatedBy { get; set; }

        [DataMember]
        public DateTime? LatestUpdateDate { get; set; }

        [DataMember]
        public int? LatestUpdatedBy { get; set; }
        [DataMember]
        public string MaHopDong { get; set; }

    }
}

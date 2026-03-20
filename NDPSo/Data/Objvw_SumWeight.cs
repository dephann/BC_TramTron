using System;
using System.Runtime.Serialization;

namespace NDPSo.Data
{
    [DataContract]
    public class Objvw_SumWeight : ObjectBase
    {
        [DataMember]
        public int PhieuTronID { get; set; }
        [DataMember]
        public string MaPhieuTron { get; set; }
        [DataMember]
        public DateTime? NgayPhieuTron { get; set; }

        [DataMember]
        public DateTime? Ngay { get; set; }

        [DataMember]
        public TimeSpan? Gio { get; set; }
        [DataMember]
        public decimal? KLDuTinh { get; set; }
        [DataMember]
        public decimal? KLThuc { get; set; }
        [DataMember]
        public decimal? SLMeDuTinh { get; set; }
        [DataMember]
        public decimal? KLDuTinhCuaTungMe { get; set; }
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
        public int? MACID { get; set; }
        [DataMember]
        public string TenMAC { get; set; }
        [DataMember]
        public int? XeID { get; set; }
        [DataMember]
        public string BienSo { get; set; }
        [DataMember]
        public int? TaiXeID { get; set; }
        [DataMember]
        public string TenTaiXe { get; set; }
        [DataMember]
        public decimal? SUM_Total_Value { get; set; }
        [DataMember]
        public decimal? SUM_Total_ValueBat { get; set; }
        [DataMember]
        public decimal? SUM_Total_ValueBatMan { get; set; }
        [DataMember]
        public bool IsQueued { get; set; }
        [DataMember]
        public int? CreatedBy { get; set; }
        [DataMember]
        public string FullName { get; set; }
        [DataMember]
        public decimal? TongKhoiLuong { get; set; }
        [DataMember]
        public int? TongMeTron { get; set; }

    }
}

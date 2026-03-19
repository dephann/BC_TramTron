namespace NDPSo.Chatbot
{
    /// <summary>
    /// STEP 3 — Query Functions
    /// SQL template sẵn cho các câu hỏi phổ biến nhất.
    /// Ưu tiên dùng template này thay vì để AI tự sinh SQL — nhanh hơn, chính xác hơn.
    /// </summary>
    public static class QueryFunctions
    {
        // ═══════════════════════════════════════════════════════
        //  SẢN LƯỢNG & MẺ TRỘN
        // ═══════════════════════════════════════════════════════
        public const string SAN_LUONG_HOM_NAY = @"
SELECT COUNT(*) AS SoMe, ISNULL(SUM(KhoiLuong),0) AS TongKL_m3
FROM dbo.MeTron
WHERE CAST(NgayMeTron AS DATE) = CAST(GETDATE() AS DATE)
  AND IsDeleted = 0";

        public const string SAN_LUONG_TUAN_NAY = @"
SELECT COUNT(*) AS SoMe, ISNULL(SUM(KhoiLuong),0) AS TongKL_m3
FROM dbo.MeTron
WHERE DATEPART(week,NgayMeTron) = DATEPART(week,GETDATE())
  AND YEAR(NgayMeTron) = YEAR(GETDATE())
  AND IsDeleted = 0";

        public const string SAN_LUONG_THANG_NAY = @"
SELECT COUNT(*) AS SoMe, ISNULL(SUM(KhoiLuong),0) AS TongKL_m3
FROM dbo.MeTron
WHERE MONTH(NgayMeTron) = MONTH(GETDATE())
  AND YEAR(NgayMeTron) = YEAR(GETDATE())
  AND IsDeleted = 0";

        public const string DANH_SACH_ME_TRON_HOM_NAY = @"
SELECT TOP 100
    v.MeTronID, v.NgayMeTron, v.MaPhieuTron, v.LnNo,
    v.KH AS KhachHang, v.CT AS CongTruong,
    v.Plate AS BienSo, v.Name AS TaiXe,
    v.KLMe AS KhoiLuong_m3, v.TenNV AS NguoiTron,
    v.MAC AS MayTron
FROM dbo.vw_Infos v
WHERE CAST(v.NgayMeTron AS DATE) = CAST(GETDATE() AS DATE)
ORDER BY v.NgayMeTron DESC";

        public const string ME_TRON_GAN_NHAT = @"
SELECT TOP 1
    v.MeTronID, v.NgayMeTron, v.MaPhieuTron,
    v.KH AS KhachHang, v.CT AS CongTruong,
    v.Plate AS BienSo, v.KLMe AS KhoiLuong_m3
FROM dbo.vw_Infos v
WHERE v.KLMe > 0
ORDER BY v.NgayMeTron DESC";

        public const string SO_SANH_THANG_NAY_VS_TRUOC = @"
SELECT
    SUM(CASE WHEN MONTH(NgayMeTron)=MONTH(GETDATE()) AND YEAR(NgayMeTron)=YEAR(GETDATE()) THEN KhoiLuong ELSE 0 END) AS TongKL_ThangNay,
    COUNT(CASE WHEN MONTH(NgayMeTron)=MONTH(GETDATE()) AND YEAR(NgayMeTron)=YEAR(GETDATE()) THEN 1 END) AS SoMe_ThangNay,
    SUM(CASE WHEN MONTH(NgayMeTron)=MONTH(DATEADD(month,-1,GETDATE())) AND YEAR(NgayMeTron)=YEAR(DATEADD(month,-1,GETDATE())) THEN KhoiLuong ELSE 0 END) AS TongKL_ThangTruoc,
    COUNT(CASE WHEN MONTH(NgayMeTron)=MONTH(DATEADD(month,-1,GETDATE())) AND YEAR(NgayMeTron)=YEAR(DATEADD(month,-1,GETDATE())) THEN 1 END) AS SoMe_ThangTruoc
FROM dbo.MeTron
WHERE IsDeleted = 0
  AND NgayMeTron >= DATEADD(month,-2,GETDATE())";

        public const string SAN_LUONG_7_NGAY = @"
SELECT
    CAST(NgayMeTron AS DATE) AS Ngay,
    COUNT(*) AS SoMe,
    ISNULL(SUM(KhoiLuong),0) AS TongKL_m3
FROM dbo.MeTron
WHERE NgayMeTron >= DATEADD(day,-7,GETDATE())
  AND IsDeleted = 0
GROUP BY CAST(NgayMeTron AS DATE)
ORDER BY Ngay DESC";

        // ═══════════════════════════════════════════════════════
        //  PHIẾU TRỘN & GIAO HÀNG
        // ═══════════════════════════════════════════════════════
        public const string PHIEU_TRON_HOM_NAY = @"
SELECT TOP 100
    p.PhieuTronID, p.MaPhieuTron, p.NgayPhieuTron,
    p.KH AS KhachHang, p.CT AS CongTruong,
    p.KLDuTinh AS KL_DuTinh_m3, p.KLThuc AS KL_Thuc_m3,
    p.BS AS BienSo, p.TX AS TaiXe, p.HM AS HangMuc
FROM dbo.vw_InfoPT p
WHERE CAST(p.NgayPhieuTron AS DATE) = CAST(GETDATE() AS DATE)
ORDER BY p.NgayPhieuTron DESC";

        public const string PHIEU_TRON_THANG_NAY = @"
SELECT TOP 200
    p.MaPhieuTron, p.NgayPhieuTron,
    p.KH AS KhachHang, p.CT AS CongTruong,
    p.KLDuTinh AS KL_DuTinh_m3, p.KLThuc AS KL_Thuc_m3,
    p.BS AS BienSo, p.TX AS TaiXe
FROM dbo.vw_InfoPT p
WHERE MONTH(p.NgayPhieuTron) = MONTH(GETDATE())
  AND YEAR(p.NgayPhieuTron) = YEAR(GETDATE())
ORDER BY p.NgayPhieuTron DESC";

        public const string PHIEU_DANG_CHO = @"
SELECT TOP 50
    p.MaPhieuTron, p.NgayPhieuTron,
    kh.TenKhachHang, ct.TenCongTruong,
    p.KLDuTinh, p.SLMeDuTinh, p.SLMeDaTron
FROM dbo.PhieuTron p
LEFT JOIN dbo.KhachHang kh ON p.KhachHangID = kh.KhachHangID
LEFT JOIN dbo.CongTruong ct ON p.CongTruongID = ct.CongTruongID
WHERE p.IsQueued = 1
ORDER BY p.NgayPhieuTron ASC";

        // ═══════════════════════════════════════════════════════
        //  KHÁCH HÀNG & HỢP ĐỒNG
        // ═══════════════════════════════════════════════════════
        public const string TOP_KHACH_HANG_THANG_NAY = @"
SELECT TOP 10
    kh.TenKhachHang,
    COUNT(pt.PhieuTronID) AS SoPhieu,
    ISNULL(SUM(pt.KLDuTinh),0) AS TongKL_DuTinh_m3,
    ISNULL(SUM(pt.KLThuc),0) AS TongKL_Thuc_m3
FROM dbo.PhieuTron pt
JOIN dbo.KhachHang kh ON pt.KhachHangID = kh.KhachHangID
WHERE MONTH(pt.NgayPhieuTron) = MONTH(GETDATE())
  AND YEAR(pt.NgayPhieuTron) = YEAR(GETDATE())
GROUP BY kh.KhachHangID, kh.TenKhachHang
ORDER BY TongKL_Thuc_m3 DESC";

        public const string HOP_DONG_CON_LAI = @"
SELECT TOP 20
    hd.MaHopDong, hd.TenHopDong,
    kh.TenKhachHang, ct.TenCongTruong,
    hd.KLDatHang AS KL_DatHang_m3,
    hd.KLDaGiao  AS KL_DaGiao_m3,
    hd.KLConLai  AS KL_ConLai_m3,
    hd.NgayHopDong
FROM dbo.HopDong hd
JOIN dbo.KhachHang kh ON hd.KhachHangID = kh.KhachHangID
LEFT JOIN dbo.CongTruong ct ON hd.CongTruongID = ct.CongTruongID
WHERE hd.KLConLai > 0 AND hd.Status = 1
ORDER BY hd.KLConLai DESC";

        public const string TOP_CONG_TRUONG_THANG_NAY = @"
SELECT TOP 10
    ct.TenCongTruong, kh.TenKhachHang,
    COUNT(mt.MeTronID) AS SoMe,
    ISNULL(SUM(mt.KhoiLuong),0) AS TongKL_m3
FROM dbo.MeTron mt
JOIN dbo.PhieuTron pt ON mt.PhieuTronID = pt.PhieuTronID
JOIN dbo.CongTruong ct ON pt.CongTruongID = ct.CongTruongID
JOIN dbo.KhachHang kh ON pt.KhachHangID = kh.KhachHangID
WHERE MONTH(mt.NgayMeTron) = MONTH(GETDATE())
  AND YEAR(mt.NgayMeTron) = YEAR(GETDATE())
  AND mt.IsDeleted = 0
GROUP BY ct.CongTruongID, ct.TenCongTruong, kh.TenKhachHang
ORDER BY TongKL_m3 DESC";

        // ═══════════════════════════════════════════════════════
        //  VẬT LIỆU & SILO
        // ═══════════════════════════════════════════════════════
        public const string TON_KHO_SILO = @"
SELECT
    s.MaSilo, s.TenSilo, s.MaterialName AS VatLieu,
    ms.SiloValue AS TonKho_kg,
    ns.TenNhomSilo AS NhomSilo
FROM dbo.Silo s
LEFT JOIN dbo.MACSilo ms ON s.SiloID = ms.SiloID
LEFT JOIN dbo.NhomSilo ns ON s.NhomSiloID = ns.NhomSiloID
WHERE s.Activated = 1
ORDER BY s.SoTT";

        public const string TIEU_THU_VAT_LIEU_HOM_NAY = @"
SELECT
    MaterialCode, MaterialName AS VatLieu,
    ISNULL(Sum_ValueCP,0) AS KL_ThietKe_kg,
    ISNULL(Sum_ValueBat,0) AS KL_ThucTe_kg,
    ISNULL(SaiSo,0) AS SaiSo_kg,
    ISNULL(PerSaiSo,0) AS SaiSo_PhanTram
FROM dbo.vw_PvMaterialDetailDay
WHERE CAST(NgayMeTron AS DATE) = CAST(GETDATE() AS DATE)
ORDER BY Sum_ValueCP DESC";

        public const string TIEU_THU_VAT_LIEU_TONG = @"
SELECT TOP 20
    MaterialCode, MaterialName AS VatLieu,
    ISNULL(Sum_ValueCP,0)  AS TongKL_ThietKe_kg,
    ISNULL(Sum_ValueBat,0) AS TongKL_ThucTe_kg,
    ISNULL(SaiSo,0)        AS TongSaiSo_kg,
    ISNULL(PerSaiSo,0)     AS SaiSo_PhanTram
FROM dbo.vw_PvTotalMaterial
ORDER BY TongKL_ThucTe_kg DESC";

        public const string DO_HUT_NUOC_HIEN_TAI = @"
SELECT TOP 10
    t.MaTinhDoHutNuoc, t.Name, t.NgayTinhDoHut,
    t.DoHutNuoc AS DoHutNuoc_PhanTram,
    ns.TenNhomSilo
FROM dbo.TinhDoHutNuoc t
JOIN dbo.NhomSilo ns ON t.NhomSiloID = ns.NhomSiloID
ORDER BY t.NgayTinhDoHut DESC";

        // ═══════════════════════════════════════════════════════
        //  XE & TÀI XẾ
        // ═══════════════════════════════════════════════════════
        public const string XE_HOM_NAY = @"
SELECT
    BienSo, Total_Tranfer AS SoChuyenHomNay,
    Total_KL AS TongKL_m3, NgayMeTron
FROM dbo.vw_PvTranferDetailDay
WHERE NgayMeTron = CAST(GETDATE() AS DATE)
ORDER BY Total_KL DESC";

        public const string XE_NHIEU_NHAT = @"
SELECT TOP 10
    XeID, BienSo,
    Total_Tranfer AS TongSoChuyen,
    Total_KL AS TongKL_m3
FROM dbo.vw_PvTotalTranfer
ORDER BY Total_KL DESC";

        public const string TAI_XE_HOM_NAY = @"
SELECT
    TenTaiXe, Total_Tranfer AS SoChuyenHomNay,
    Total_KL AS TongKL_m3
FROM dbo.vw_PvDriverDetailDay
WHERE NgayMeTron = CAST(GETDATE() AS DATE)
ORDER BY Total_KL DESC";

        public const string TAI_XE_NHIEU_NHAT = @"
SELECT TOP 10
    MaTaiXe, TenTaiXe,
    Total_Tranfer AS TongSoChuyen,
    Total_KL AS TongKL_m3
FROM dbo.vw_PvTotalDriver
ORDER BY Total_KL DESC";

        // ═══════════════════════════════════════════════════════
        //  SỰ KIỆN & LOG
        // ═══════════════════════════════════════════════════════
        public const string CANH_BAO_HOM_NAY = @"
SELECT TOP 50
    LogDate, UserName, EventActionContent, Description
FROM dbo.EventLog
WHERE CAST(LogDate AS DATE) = CAST(GETDATE() AS DATE)
ORDER BY LogDate DESC";

        public const string DANG_NHAP_HOM_NAY = @"
SELECT TOP 20
    RecordTime, UserName, FullName, FormName, ActionName
FROM dbo.TraceRecord
WHERE CAST(RecordTime AS DATE) = CAST(GETDATE() AS DATE)
ORDER BY RecordTime DESC";

        // ═══════════════════════════════════════════════════════
        //  TEMPLATE LOOKUP — map intent → SQL template
        // ═══════════════════════════════════════════════════════
        public static string GetTemplate(string intent)
        {
            switch (intent)
            {
                case "SAN_LUONG_HOM_NAY": return SAN_LUONG_HOM_NAY;
                case "SAN_LUONG_TUAN_NAY": return SAN_LUONG_TUAN_NAY;
                case "SAN_LUONG_THANG_NAY": return SAN_LUONG_THANG_NAY;
                case "DANH_SACH_ME_HOM_NAY": return DANH_SACH_ME_TRON_HOM_NAY;
                case "ME_GAN_NHAT": return ME_TRON_GAN_NHAT;
                case "SO_SANH_THANG": return SO_SANH_THANG_NAY_VS_TRUOC;
                case "SAN_LUONG_7_NGAY": return SAN_LUONG_7_NGAY;
                case "PHIEU_HOM_NAY": return PHIEU_TRON_HOM_NAY;
                case "PHIEU_THANG_NAY": return PHIEU_TRON_THANG_NAY;
                case "PHIEU_DANG_CHO": return PHIEU_DANG_CHO;
                case "TOP_KHACH_HANG": return TOP_KHACH_HANG_THANG_NAY;
                case "HOP_DONG_CON_LAI": return HOP_DONG_CON_LAI;
                case "TOP_CONG_TRUONG": return TOP_CONG_TRUONG_THANG_NAY;
                case "TON_KHO_SILO": return TON_KHO_SILO;
                case "TIEU_THU_VAT_LIEU_HOM_NAY": return TIEU_THU_VAT_LIEU_HOM_NAY;
                case "TIEU_THU_VAT_LIEU_TONG": return TIEU_THU_VAT_LIEU_TONG;
                case "DO_HUT_NUOC": return DO_HUT_NUOC_HIEN_TAI;
                case "XE_HOM_NAY": return XE_HOM_NAY;
                case "XE_NHIEU_NHAT": return XE_NHIEU_NHAT;
                case "TAI_XE_HOM_NAY": return TAI_XE_HOM_NAY;
                case "TAI_XE_NHIEU_NHAT": return TAI_XE_NHIEU_NHAT;
                case "CANH_BAO_HOM_NAY": return CANH_BAO_HOM_NAY;
                case "DANG_NHAP_HOM_NAY": return DANG_NHAP_HOM_NAY;
                default: return null;
            }
        }
    }
}
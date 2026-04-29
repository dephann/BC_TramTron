-- =============================================================
-- TỐI ƯU HIỆU NĂNG BÁO CÁO — Tạo indexes cho các bảng hot
-- Chạy 1 lần trên môi trường production sau khi backup DB
-- =============================================================

SET NOCOUNT ON;
PRINT '=== TẠO INDEXES TỐI ƯU BÁO CÁO ===';
PRINT '';

-- ── MeTron ────────────────────────────────────────────────────
-- vw_DataMix, vw_MaterialDetailDayWithID đều JOIN MeTron
-- Filter thường gặp: NgayMeTron (range), PhieuTronID, IsManual, IsDeleted

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_MeTron_NgayMeTron_PhieuTronID' AND object_id = OBJECT_ID('MeTron'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_MeTron_NgayMeTron_PhieuTronID
    ON MeTron (NgayMeTron, PhieuTronID)
    INCLUDE (KhoiLuong, Status, IsManual, IsDeleted, CreatedBy);
    PRINT 'Created: IX_MeTron_NgayMeTron_PhieuTronID';
END
ELSE PRINT 'Skip (exists): IX_MeTron_NgayMeTron_PhieuTronID';

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_MeTron_PhieuTronID_Status' AND object_id = OBJECT_ID('MeTron'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_MeTron_PhieuTronID_Status
    ON MeTron (PhieuTronID, Status)
    INCLUDE (MeTronID, NgayMeTron, KhoiLuong, IsManual, IsDeleted);
    PRINT 'Created: IX_MeTron_PhieuTronID_Status';
END
ELSE PRINT 'Skip (exists): IX_MeTron_PhieuTronID_Status';

-- ── PhieuTron ─────────────────────────────────────────────────
-- Filter: NgayPhieuTron (range), KhachHangID, CongTruongID, MACID, TaiXeID, XeID

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_PhieuTron_NgayPhieuTron' AND object_id = OBJECT_ID('PhieuTron'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_PhieuTron_NgayPhieuTron
    ON PhieuTron (NgayPhieuTron)
    INCLUDE (PhieuTronID, MaPhieuTron, KhachHangID, CongTruongID, MACID,
             TaiXeID, XeID, NhanVienID, HangMucID, Status, IsQueued, HopDongID);
    PRINT 'Created: IX_PhieuTron_NgayPhieuTron';
END
ELSE PRINT 'Skip (exists): IX_PhieuTron_NgayPhieuTron';

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_PhieuTron_KhachHang_CongTruong' AND object_id = OBJECT_ID('PhieuTron'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_PhieuTron_KhachHang_CongTruong
    ON PhieuTron (KhachHangID, CongTruongID)
    INCLUDE (PhieuTronID, NgayPhieuTron, MACID, HangMucID, Status);
    PRINT 'Created: IX_PhieuTron_KhachHang_CongTruong';
END
ELSE PRINT 'Skip (exists): IX_PhieuTron_KhachHang_CongTruong';

-- ── MeTronChiTiet ─────────────────────────────────────────────
-- JOIN với MeTron để lấy số liệu vật tư từng mẻ

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_MeTronChiTiet_MeTronID' AND object_id = OBJECT_ID('MeTronChiTiet'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_MeTronChiTiet_MeTronID
    ON MeTronChiTiet (MeTronID)
    INCLUDE ([Value], ValueBat, ValueBatMan, MACSiloID, MaterialID, MaSilo);
    PRINT 'Created: IX_MeTronChiTiet_MeTronID';
END
ELSE PRINT 'Skip (exists): IX_MeTronChiTiet_MeTronID';

-- ── NhapKho / XuatKho ────────────────────────────────────────
-- Báo cáo tồn kho, lịch sử nhập/xuất theo ngày

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NhapKho')
BEGIN
    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_NhapKho_NgayNhap_SiloID' AND object_id = OBJECT_ID('NhapKho'))
    BEGIN
        CREATE NONCLUSTERED INDEX IX_NhapKho_NgayNhap_SiloID
        ON NhapKho (NgayNhap, SiloID)
        INCLUDE (SoLuongNhap, MaterialID, NhaCungCap, CreatedBy);
        PRINT 'Created: IX_NhapKho_NgayNhap_SiloID';
    END
    ELSE PRINT 'Skip (exists): IX_NhapKho_NgayNhap_SiloID';
END

IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'XuatKho')
BEGIN
    IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_XuatKho_NgayXuat_SiloID' AND object_id = OBJECT_ID('XuatKho'))
    BEGIN
        CREATE NONCLUSTERED INDEX IX_XuatKho_NgayXuat_SiloID
        ON XuatKho (NgayXuat, SiloID)
        INCLUDE (SoLuongXuat, MaterialID, PhieuTronID, MeTronID, CreatedBy);
        PRINT 'Created: IX_XuatKho_NgayXuat_SiloID';
    END
    ELSE PRINT 'Skip (exists): IX_XuatKho_NgayXuat_SiloID';
END

-- ── HopDong ───────────────────────────────────────────────────
-- Dùng trong JOIN khi lọc theo hợp đồng

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_HopDong_KhachHangID' AND object_id = OBJECT_ID('HopDong'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_HopDong_KhachHangID
    ON HopDong (KhachHangID)
    INCLUDE (HopDongID, MaHopDong, CongTruongID, MACID, Status);
    PRINT 'Created: IX_HopDong_KhachHangID';
END
ELSE PRINT 'Skip (exists): IX_HopDong_KhachHangID';

-- ── Kiểm tra kết quả ─────────────────────────────────────────
PRINT '';
PRINT '=== DANH SÁCH INDEXES SAU KHI TẠO ===';
SELECT
    t.name      AS TableName,
    i.name      AS IndexName,
    i.type_desc AS IndexType,
    i.is_unique AS IsUnique,
    STUFF((
        SELECT ', ' + c2.name
        FROM sys.index_columns ic2
        JOIN sys.columns c2
          ON c2.object_id = ic2.object_id AND c2.column_id = ic2.column_id
        WHERE ic2.object_id = i.object_id
          AND ic2.index_id  = i.index_id
          AND ic2.is_included_column = 0
        ORDER BY ic2.key_ordinal
        FOR XML PATH(''), TYPE
    ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS KeyColumns
FROM sys.indexes i
JOIN sys.tables t ON t.object_id = i.object_id
WHERE t.name IN ('MeTron', 'PhieuTron', 'MeTronChiTiet', 'NhapKho', 'XuatKho', 'HopDong')
  AND i.type > 0
ORDER BY t.name, i.name;

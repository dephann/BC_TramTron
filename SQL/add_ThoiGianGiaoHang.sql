-- Thêm cột ThoiGianGiaoHang vào bảng PhieuTron
-- Chạy script này 1 lần trên database production

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'PhieuTron' AND COLUMN_NAME = 'ThoiGianGiaoHang'
)
BEGIN
    ALTER TABLE PhieuTron
    ADD ThoiGianGiaoHang DATETIME NULL;

    PRINT 'Đã thêm cột ThoiGianGiaoHang vào bảng PhieuTron.';
END
ELSE
BEGIN
    PRINT 'Cột ThoiGianGiaoHang đã tồn tại, bỏ qua.';
END

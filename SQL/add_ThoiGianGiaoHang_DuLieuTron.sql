-- Thêm cột ThoiGianGiaoHang vào bảng DuLieuTron
IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'DuLieuTron' AND COLUMN_NAME = 'ThoiGianGiaoHang'
)
BEGIN
    ALTER TABLE DuLieuTron ADD ThoiGianGiaoHang DATETIME NULL;
    PRINT 'Đã thêm cột ThoiGianGiaoHang vào DuLieuTron.';
END
ELSE
    PRINT 'Cột đã tồn tại.';

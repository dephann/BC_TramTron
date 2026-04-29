-- =============================================================
-- SEED: Nhập tồn kho test — tạo dữ liệu thực tế để kiểm tra
-- Gán tồn kho cho từng silo: một số đủ, một số sắp hết, một số hết
-- =============================================================

SET NOCOUNT ON;

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TonKho')
BEGIN
    RAISERROR('Chưa tạo bảng TonKho. Hãy chạy create_tonkho_tables.sql trước.', 16, 1);
    RETURN;
END

-- Xem danh sách silo hiện có
SELECT s.SiloID, s.MaSilo, s.TenSilo, m.MaterialName,
       ISNULL(tk.SoLuongTon, -1) AS TonHienTai
FROM Silo s
LEFT JOIN Material m  ON m.MaterialID = s.MaterialID
LEFT JOIN TonKho   tk ON tk.SiloID    = s.SiloID
WHERE s.MaterialID IS NOT NULL AND ISNULL(s.Activated, 1) = 1
ORDER BY s.SiloID;

-- Reset tồn kho để seed lại
UPDATE TonKho SET SoLuongTon = 0;

-- Phân nhóm silo theo tồn kho để test đủ 3 trạng thái:
--   1/3 đầu (SiloID nhỏ nhất): tồn nhiều  → ĐỦ
--   1/3 giữa: tồn gần mức cảnh báo        → CẢNH BÁO
--   1/3 cuối (SiloID lớn nhất): tồn = 0   → HẾT KHO

DECLARE @TotalSilo INT = (SELECT COUNT(*) FROM TonKho);
PRINT 'Tổng silo có tồn kho: ' + CAST(@TotalSilo AS VARCHAR(5));

UPDATE tk
SET tk.SoLuongTon =
    CASE
        WHEN rn.RowRank <= @TotalSilo / 3
            -- Nhóm ĐỦ: tồn = 5× mức cảnh báo
            THEN tk.MucCanhBao * 5
        WHEN rn.RowRank <= (@TotalSilo * 2) / 3
            -- Nhóm CẢNH BÁO: tồn = 50% mức cảnh báo
            THEN tk.MucCanhBao * 0.5
        ELSE
            -- Nhóm HẾT KHO: tồn = 0
            0
    END,
    tk.LatestUpdateDate = GETDATE()
FROM TonKho tk
INNER JOIN (
    SELECT TonKhoID,
           ROW_NUMBER() OVER (ORDER BY TonKhoID ASC) AS RowRank
    FROM TonKho
) rn ON rn.TonKhoID = tk.TonKhoID;

-- Báo kết quả
SELECT
    s.MaSilo,
    s.TenSilo,
    m.MaterialName,
    tk.SoLuongTon   AS TonHienTai,
    tk.MucCanhBao,
    CASE
        WHEN tk.SoLuongTon <= 0             THEN N'✗ HẾT KHO'
        WHEN tk.SoLuongTon < tk.MucCanhBao   THEN N'⚠ CẢNH BÁO'
        ELSE                                     N'✓ ĐỦ'
    END AS TrangThai
FROM TonKho tk
JOIN Silo     s ON s.SiloID     = tk.SiloID
JOIN Material m ON m.MaterialID = tk.MaterialID
ORDER BY tk.SoLuongTon ASC;

-- Kiểm tra tồn kho đủ cho các đơn hàng đang chờ
PRINT '';
PRINT '=== KIỂM TRA TỒN KHO VS ĐƠN HÀNG ĐANG CHỜ ===';
EXEC sp_KiemTra_TonKho_DuLieuTron;

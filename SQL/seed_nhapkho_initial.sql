-- =============================================================
-- KHỞI TẠO TỒN KHO BAN ĐẦU — Nhập nhiều đợt, đủ loại vật tư
-- Nhóm vật tư:
--   Agg (Cát Đá)  : số lớn, không thập phân
--   Ce  (Xi Măng) : số lớn, không thập phân
--   Wa  (Nước)    : số lớn, không thập phân
--   Add (Phụ Gia) : số nhỏ, 2 chữ số thập phân
-- =============================================================

SET NOCOUNT ON;

IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TonKho')
BEGIN
    RAISERROR('Chưa tạo bảng TonKho.', 16, 1); RETURN;
END
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'sp_NhapKho')
BEGIN
    RAISERROR('Chưa tạo sp_NhapKho.', 16, 1); RETURN;
END

-- ── Reset về 0 ────────────────────────────────────────────────
PRINT '>> Reset tồn kho về 0...';
UPDATE TonKho SET SoLuongTon = 0, LatestUpdateDate = GETDATE();
PRINT 'Reset xong: ' + CAST(@@ROWCOUNT AS VARCHAR(5)) + ' silo.';

-- ── Biến dùng chung ───────────────────────────────────────────
DECLARE @SiloID     INT;
DECLARE @MatName    VARCHAR(200);
DECLARE @NhomCode   VARCHAR(20);
DECLARE @SoLuong    DECIMAL(18,2);
DECLARE @Dot        INT;          -- đợt nhập (1,2,3)
DECLARE @NCC        NVARCHAR(200);
DECLARE @SoHD       VARCHAR(50);
DECLARE @GhiChu     NVARCHAR(500);

-- Danh sách nhà cung cấp xoay vòng
DECLARE @NCC1 NVARCHAR(200) = N'Công ty TNHH Vật Liệu Xây Dựng An Phát';
DECLARE @NCC2 NVARCHAR(200) = N'Công ty CP Khoáng Sản Bình Minh';
DECLARE @NCC3 NVARCHAR(200) = N'Công ty Hóa Chất Đông Nam Á';
DECLARE @NCC4 NVARCHAR(200) = N'Nhà cung cấp Minh Trí';

-- ── Nhập 3 đợt cho mỗi silo ───────────────────────────────────
-- Đợt 1: ~10 ngày trước
-- Đợt 2: ~5 ngày trước
-- Đợt 3: hôm nay

SET @Dot = 1;
WHILE @Dot <= 3
BEGIN
    PRINT '';
    PRINT '>> Đợt nhập ' + CAST(@Dot AS VARCHAR(2)) + '/3...';

    DECLARE curSilo CURSOR FAST_FORWARD FOR
        SELECT
            s.SiloID,
            m.MaterialName,
            ISNULL(ns.MaNhomSilo, 'Agg') AS NhomCode
        FROM Silo s
        JOIN Material  m  ON m.MaterialID  = s.MaterialID
        LEFT JOIN NhomSilo ns ON ns.NhomSiloID = s.NhomSiloID
        WHERE s.MaterialID IS NOT NULL
          AND ISNULL(s.Activated, 1) = 1
        ORDER BY ns.MaNhomSilo, s.SiloID;

    OPEN curSilo;
    FETCH NEXT FROM curSilo INTO @SiloID, @MatName, @NhomCode;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Tính số lượng theo nhóm và đợt
        SET @SoLuong =
            CASE @NhomCode
                WHEN 'Agg' THEN  -- Cát Đá: 30,000–60,000 kg/đợt
                    CASE @Dot
                        WHEN 1 THEN 60000
                        WHEN 2 THEN 45000
                        ELSE        30000
                    END
                WHEN 'Ce'  THEN  -- Xi Măng: 20,000–40,000 kg/đợt
                    CASE @Dot
                        WHEN 1 THEN 40000
                        WHEN 2 THEN 30000
                        ELSE        20000
                    END
                WHEN 'Wa'  THEN  -- Nước: 10,000–25,000 lít/đợt
                    CASE @Dot
                        WHEN 1 THEN 25000
                        WHEN 2 THEN 18000
                        ELSE        10000
                    END
                ELSE             -- Add (Phụ Gia): 800–2,000 kg/đợt
                    CASE @Dot
                        WHEN 1 THEN 2000.00
                        WHEN 2 THEN 1250.50
                        ELSE         800.75
                    END
            END;

        -- Nhà cung cấp xoay vòng theo đợt
        SET @NCC = CASE @Dot
            WHEN 1 THEN @NCC1
            WHEN 2 THEN CASE @NhomCode WHEN 'Add' THEN @NCC3 ELSE @NCC2 END
            ELSE        @NCC4
        END;

        -- Mã hóa đơn
        SET @SoHD = 'HD' + FORMAT(DATEADD(DAY, -((3-@Dot)*5), GETDATE()), 'yyyyMMdd')
                    + '-' + @NhomCode + '-' + CAST(@SiloID AS VARCHAR(5));

        SET @GhiChu = N'Nhập đợt ' + CAST(@Dot AS NVARCHAR(1))
                    + N' — ' + CAST(@MatName AS NVARCHAR(100));

        EXEC sp_NhapKho
            @SiloID      = @SiloID,
            @SoLuongNhap = @SoLuong,
            @NhaCungCap  = @NCC,
            @SoHoaDon    = @SoHD,
            @GhiChu      = @GhiChu,
            @CreatedBy   = 1;

        FETCH NEXT FROM curSilo INTO @SiloID, @MatName, @NhomCode;
    END

    CLOSE curSilo; DEALLOCATE curSilo;
    PRINT 'Đợt ' + CAST(@Dot AS VARCHAR(2)) + ' xong.';

    SET @Dot = @Dot + 1;
END

-- ── Tổng hợp kết quả ─────────────────────────────────────────
PRINT '';
PRINT '=== TỒN KHO SAU KHI KHỞI TẠO ===';
SELECT
    ns.TenNhomSilo                              AS Nhom,
    s.MaSilo,
    m.MaterialName,
    CASE
        WHEN ns.MaNhomSilo = 'Add'
            THEN CAST(CAST(tk.SoLuongTon AS DECIMAL(18,2)) AS VARCHAR(20))
        ELSE CAST(CAST(tk.SoLuongTon AS BIGINT) AS VARCHAR(20))
    END                                          AS [Ton_kg],
    CASE
        WHEN ns.MaNhomSilo = 'Add'
            THEN CAST(CAST(tk.MucCanhBao AS DECIMAL(18,2)) AS VARCHAR(20))
        ELSE CAST(CAST(tk.MucCanhBao AS BIGINT) AS VARCHAR(20))
    END                                          AS [MucCanhBao_kg],
    N'DU'                                        AS TrangThai
FROM TonKho tk
JOIN Silo      s  ON s.SiloID      = tk.SiloID
JOIN Material  m  ON m.MaterialID  = tk.MaterialID
LEFT JOIN NhomSilo ns ON ns.NhomSiloID = s.NhomSiloID
ORDER BY ns.MaNhomSilo, s.SiloID;

-- ── Lịch sử NhapKho vừa tạo ──────────────────────────────────
PRINT '';
PRINT '=== TỔNG PHIẾU NHẬP KHO ĐÃ TẠO ===';
SELECT
    ns.MaNhomSilo                               AS Nhom,
    m.MaterialName,
    COUNT(*)                                     AS SoPhieu,
    CASE
        WHEN ns.MaNhomSilo = 'Add'
            THEN CAST(CAST(SUM(nk.SoLuongNhap) AS DECIMAL(18,2)) AS VARCHAR(20))
        ELSE CAST(CAST(SUM(nk.SoLuongNhap) AS BIGINT) AS VARCHAR(20))
    END                                          AS [TongNhap_kg],
    MIN(CONVERT(VARCHAR(10), nk.NgayNhap, 120)) AS NhapTuNgay,
    MAX(CONVERT(VARCHAR(10), nk.NgayNhap, 120)) AS NhapDenNgay
FROM NhapKho nk
JOIN Silo      s  ON s.SiloID      = nk.SiloID
JOIN Material  m  ON m.MaterialID  = nk.MaterialID
LEFT JOIN NhomSilo ns ON ns.NhomSiloID = s.NhomSiloID
GROUP BY ns.MaNhomSilo, ns.TenNhomSilo, m.MaterialName
ORDER BY ns.MaNhomSilo, m.MaterialName;

-- ── Kiểm tra vs đơn hàng đang chờ ────────────────────────────
PRINT '';
PRINT '=== KIỂM TRA TỒN KHO VS ĐƠN HÀNG ĐANG CHỜ ===';
EXEC sp_KiemTra_TonKho_DuLieuTron;

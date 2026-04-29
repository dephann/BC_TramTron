-- =============================================================
-- SEED: Dữ liệu nhập kho test
-- Tạo 3 nhóm tồn kho: ĐỦ / CẢNH BÁO / HẾT KHO
-- =============================================================

SET NOCOUNT ON;

-- ── 0. Kiểm tra điều kiện ─────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TonKho')
BEGIN
    RAISERROR('Chưa tạo bảng TonKho. Hãy chạy create_tonkho_tables.sql trước.', 16, 1);
    RETURN;
END
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'sp_NhapKho')
BEGIN
    RAISERROR('Chưa tạo sp_NhapKho. Hãy chạy sp_tonkho_operations.sql trước.', 16, 1);
    RETURN;
END

-- ── 1. Trạng thái trước khi nhập ──────────────────────────────
PRINT '=== TRẠNG THÁI TRƯỚC KHI NHẬP ===';
SELECT
    s.MaSilo,
    m.MaterialName,
    ISNULL(tk.SoLuongTon, 0) AS TonHienTai,
    ISNULL(tk.MucCanhBao, 0) AS MucCanhBao,
    CASE
        WHEN ISNULL(tk.SoLuongTon,0) <= 0            THEN N'HET KHO'
        WHEN ISNULL(tk.SoLuongTon,0) < tk.MucCanhBao THEN N'CANH BAO'
        ELSE                                              N'DU'
    END AS TrangThai
FROM Silo s
JOIN Material m ON m.MaterialID = s.MaterialID
LEFT JOIN TonKho tk ON tk.SiloID = s.SiloID
WHERE s.MaterialID IS NOT NULL AND ISNULL(s.Activated, 1) = 1
ORDER BY s.SiloID;

-- ── 2. Reset tồn kho về 0 ─────────────────────────────────────
PRINT '';
PRINT '>> Reset tất cả tồn kho về 0...';
UPDATE TonKho SET SoLuongTon = 0, LatestUpdateDate = GETDATE();
PRINT 'Đã reset ' + CAST(@@ROWCOUNT AS VARCHAR(5)) + ' silo.';

-- ── 3. Phân nhóm ──────────────────────────────────────────────
DECLARE @Total  INT = (SELECT COUNT(*) FROM TonKho);
DECLARE @CutA   INT = @Total / 3;           -- nhóm ĐỦ: hàng 1..CutA
DECLARE @CutAB  INT = (@Total * 2) / 3;    -- nhóm CẢNH BÁO: hàng CutA+1..CutAB
                                             -- nhóm HẾT KHO: hàng CutAB+1..Total

PRINT '';
PRINT 'Tổng silo: ' + CAST(@Total AS VARCHAR(5))
    + ' | ĐỦ: '       + CAST(@CutA AS VARCHAR(5))
    + ' | CẢNH BÁO: ' + CAST(@CutAB - @CutA AS VARCHAR(5))
    + ' | HẾT KHO: '  + CAST(@Total - @CutAB AS VARCHAR(5));

-- ── 4. Nhóm A: nhập 5× mức cảnh báo → ĐỦ ────────────────────
PRINT '';
PRINT '>> Nhập kho Nhóm A (ĐỦ)...';

DECLARE @SiloID  INT;
DECLARE @MucCB   DECIMAL(18,2);
DECLARE @SoLuong DECIMAL(18,2);

DECLARE curA CURSOR FAST_FORWARD FOR
    SELECT SiloID, MucCanhBao
    FROM (
        SELECT TonKhoID, SiloID, MucCanhBao,
               ROW_NUMBER() OVER (ORDER BY TonKhoID ASC) AS rn
        FROM TonKho
    ) t
    WHERE rn <= @CutA;

OPEN curA;
FETCH NEXT FROM curA INTO @SiloID, @MucCB;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @SoLuong = @MucCB * 5;
    EXEC sp_NhapKho
        @SiloID      = @SiloID,
        @SoLuongNhap = @SoLuong,
        @NhaCungCap  = N'Công ty Vật Liệu An Phát',
        @SoHoaDon    = 'HD-TEST-2026-A',
        @GhiChu      = N'Seed test - nhóm ĐỦ',
        @CreatedBy   = 1;
    FETCH NEXT FROM curA INTO @SiloID, @MucCB;
END
CLOSE curA; DEALLOCATE curA;
PRINT 'Nhóm A xong.';

-- ── 5. Nhóm B: nhập 50% mức cảnh báo → CẢNH BÁO ─────────────
PRINT '';
PRINT '>> Nhập kho Nhóm B (CẢNH BÁO)...';

DECLARE curB CURSOR FAST_FORWARD FOR
    SELECT SiloID, MucCanhBao
    FROM (
        SELECT TonKhoID, SiloID, MucCanhBao,
               ROW_NUMBER() OVER (ORDER BY TonKhoID ASC) AS rn
        FROM TonKho
    ) t
    WHERE rn > @CutA AND rn <= @CutAB;

OPEN curB;
FETCH NEXT FROM curB INTO @SiloID, @MucCB;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @SoLuong = CASE WHEN @MucCB * 0.5 < 1 THEN 1 ELSE @MucCB * 0.5 END;
    EXEC sp_NhapKho
        @SiloID      = @SiloID,
        @SoLuongNhap = @SoLuong,
        @NhaCungCap  = N'Công ty Xây Dựng Bình Minh',
        @SoHoaDon    = 'HD-TEST-2026-B',
        @GhiChu      = N'Seed test - nhóm CẢNH BÁO',
        @CreatedBy   = 1;
    FETCH NEXT FROM curB INTO @SiloID, @MucCB;
END
CLOSE curB; DEALLOCATE curB;
PRINT 'Nhóm B xong.';

-- Nhóm C: không nhập → tồn = 0 → HẾT KHO
PRINT '';
PRINT '>> Nhóm C (HẾT KHO): giữ tồn = 0.';

-- ── 6. Kết quả tổng hợp ───────────────────────────────────────
PRINT '';
PRINT '=== KẾT QUẢ SAU KHI NHẬP ===';
SELECT
    s.MaSilo,
    s.TenSilo,
    m.MaterialName,
    -- Phụ gia: 2 số thập phân, các vật tư khác: số nguyên
    CASE
        WHEN m.MaterialName LIKE N'%phụ gia%' OR m.MaterialName LIKE N'%phu gia%'
            THEN CAST(CAST(tk.SoLuongTon AS DECIMAL(18,2)) AS VARCHAR(20))
        ELSE CAST(CAST(tk.SoLuongTon AS INT) AS VARCHAR(20))
    END AS [Ton_kg],
    CASE
        WHEN m.MaterialName LIKE N'%phụ gia%' OR m.MaterialName LIKE N'%phu gia%'
            THEN CAST(CAST(tk.MucCanhBao AS DECIMAL(18,2)) AS VARCHAR(20))
        ELSE CAST(CAST(tk.MucCanhBao AS INT) AS VARCHAR(20))
    END AS [MucCanhBao_kg],
    CASE
        WHEN tk.SoLuongTon <= 0            THEN N'HET KHO'
        WHEN tk.SoLuongTon < tk.MucCanhBao THEN N'CANH BAO'
        ELSE                                   N'DU'
    END AS TrangThai
FROM TonKho tk
JOIN Silo     s ON s.SiloID     = tk.SiloID
JOIN Material m ON m.MaterialID = tk.MaterialID
ORDER BY
    CASE WHEN tk.SoLuongTon <= 0            THEN 0
         WHEN tk.SoLuongTon < tk.MucCanhBao THEN 1
         ELSE 2 END,
    tk.SoLuongTon ASC;

-- ── 7. Lịch sử phiếu nhập hôm nay ────────────────────────────
PRINT '';
PRINT '=== PHIẾU NHẬP KHO HÔM NAY ===';
SELECT
    nk.MaPhieuNhap,
    s.MaSilo,
    m.MaterialName,
    CASE
        WHEN m.MaterialName LIKE N'%phụ gia%' OR m.MaterialName LIKE N'%phu gia%'
            THEN CAST(CAST(nk.SoLuongNhap AS DECIMAL(18,2)) AS VARCHAR(20))
        ELSE CAST(CAST(nk.SoLuongNhap AS INT) AS VARCHAR(20))
    END AS [SoLuong_kg],
    nk.NhaCungCap,
    nk.SoHoaDon,
    nk.GhiChu,
    CONVERT(VARCHAR(19), nk.NgayNhap, 120) AS NgayNhap
FROM NhapKho nk
JOIN Silo     s ON s.SiloID     = nk.SiloID
JOIN Material m ON m.MaterialID = nk.MaterialID
WHERE CAST(nk.NgayNhap AS DATE) = CAST(GETDATE() AS DATE)
ORDER BY nk.NhapKhoID;

-- ── 8. Kiểm tra tồn vs đơn hàng đang chờ ─────────────────────
PRINT '';
PRINT '=== TỒN KHO VS ĐƠN HÀNG ĐANG CHỜ ===';
EXEC sp_KiemTra_TonKho_DuLieuTron;

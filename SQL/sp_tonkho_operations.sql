-- =============================================================
-- STORED PROCEDURES: Nghiệp vụ tồn kho
-- =============================================================

-- ── SP1: Nhập kho (thêm NVL vào silo) ────────────────────────
IF OBJECT_ID('sp_NhapKho', 'P') IS NOT NULL DROP PROCEDURE sp_NhapKho;
GO
CREATE PROCEDURE sp_NhapKho
    @SiloID       INT,
    @SoLuongNhap  DECIMAL(18,2),
    @NhaCungCap   NVARCHAR(200) = NULL,
    @SoHoaDon     VARCHAR(50)   = NULL,
    @GhiChu       NVARCHAR(500) = NULL,
    @CreatedBy    INT           = 1
AS
BEGIN
    SET NOCOUNT ON;

    -- Sinh mã phiếu nhập: NK + ngày + số thứ tự
    DECLARE @MaPhieu VARCHAR(20);
    DECLARE @SoTT INT = ISNULL((
        SELECT COUNT(*) FROM NhapKho
        WHERE CAST(NgayNhap AS DATE) = CAST(GETDATE() AS DATE)
    ), 0) + 1;
    SET @MaPhieu = 'NK' + FORMAT(GETDATE(), 'yyyyMMdd') + RIGHT('000' + CAST(@SoTT AS VARCHAR(3)), 3);

    -- Lấy MaterialID từ Silo
    DECLARE @MaterialID INT = (SELECT MaterialID FROM Silo WHERE SiloID = @SiloID);
    IF @MaterialID IS NULL
    BEGIN
        RAISERROR('Silo không có vật liệu được gán.', 16, 1);
        RETURN;
    END

    BEGIN TRANSACTION;
    BEGIN TRY
        -- Ghi phiếu nhập
        INSERT INTO NhapKho (MaPhieuNhap, SiloID, MaterialID, SoLuongNhap,
                              NhaCungCap, SoHoaDon, GhiChu, IsApplied, CreatedBy)
        VALUES (@MaPhieu, @SiloID, @MaterialID, @SoLuongNhap,
                @NhaCungCap, @SoHoaDon, @GhiChu, 1, @CreatedBy);

        -- Cộng vào TonKho
        IF EXISTS (SELECT 1 FROM TonKho WHERE SiloID = @SiloID)
            UPDATE TonKho
            SET SoLuongTon     = SoLuongTon + @SoLuongNhap,
                LatestUpdateDate = GETDATE(),
                LatestUpdatedBy  = @CreatedBy
            WHERE SiloID = @SiloID;
        ELSE
            INSERT INTO TonKho (SiloID, MaterialID, SoLuongTon, MucCanhBao, LatestUpdateDate)
            VALUES (@SiloID, @MaterialID, @SoLuongNhap, 500, GETDATE());

        COMMIT;
        SELECT @MaPhieu AS MaPhieuNhap, @SoLuongNhap AS DaNhap,
               (SELECT SoLuongTon FROM TonKho WHERE SiloID = @SiloID) AS TonSauNhap;
    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END;
GO

-- ── SP2: Xuất kho tự động khi 1 mẻ trộn hoàn tất ─────────────
IF OBJECT_ID('sp_XuatKho_TuDong', 'P') IS NOT NULL DROP PROCEDURE sp_XuatKho_TuDong;
GO
CREATE PROCEDURE sp_XuatKho_TuDong
    @MeTronID     INT,
    @PhieuTronID  INT,
    @DuLieuTronID INT,
    @CreatedBy    INT = 1
AS
BEGIN
    SET NOCOUNT ON;
    -- Lấy tất cả vật liệu thực tế đã dùng trong mẻ từ MeTronChiTiet
    INSERT INTO XuatKho (SiloID, MaterialID, SoLuongXuat,
                         MeTronID, MeTronChiTietID, PhieuTronID, DuLieuTronID,
                         NgayXuat, CreatedBy)
    SELECT
        s.SiloID,
        mtct.MaterialID,
        ISNULL(mtct.Value, 0),        -- kg thực tế đã cân
        mtct.MeTronID,
        mtct.MeTronChiTietID,
        @PhieuTronID,
        @DuLieuTronID,
        GETDATE(),
        @CreatedBy
    FROM MeTronChiTiet mtct
    JOIN MACSilo ms ON ms.MACSiloID = mtct.MACSiloID
    JOIN Silo    s  ON s.SiloID     = ms.SiloID
    WHERE mtct.MeTronID = @MeTronID
      AND mtct.MaterialID IS NOT NULL
      AND ISNULL(mtct.Value, 0) > 0;

    -- Trừ tồn kho
    UPDATE tk
    SET tk.SoLuongTon      = tk.SoLuongTon - xk.SoLuongXuat,
        tk.LatestUpdateDate = GETDATE()
    FROM TonKho tk
    INNER JOIN (
        SELECT SiloID, SUM(SoLuongXuat) AS SoLuongXuat
        FROM XuatKho
        WHERE MeTronID = @MeTronID
        GROUP BY SiloID
    ) xk ON xk.SiloID = tk.SiloID;

    -- Đảm bảo tồn không âm
    UPDATE TonKho SET SoLuongTon = 0 WHERE SoLuongTon < 0;

    SELECT COUNT(*) AS SilosDaTru FROM XuatKho WHERE MeTronID = @MeTronID;
END;
GO

-- ── SP3: Kiểm tra tồn kho đủ cho list DuLieuTron ──────────────
IF OBJECT_ID('sp_KiemTra_TonKho_DuLieuTron', 'P') IS NOT NULL
    DROP PROCEDURE sp_KiemTra_TonKho_DuLieuTron;
GO
CREATE PROCEDURE sp_KiemTra_TonKho_DuLieuTron
AS
BEGIN
    SET NOCOUNT ON;
    -- Tổng hợp: với từng vật liệu, tồn bao nhiêu và cần bao nhiêu
    WITH NhuCau AS (
        SELECT
            m.MaterialID,
            m.MaterialName,
            s.SiloID,
            s.MaSilo,
            SUM(ISNULL(d.DLT_SLMeDuTinh, 1) * ISNULL(ms.SiloValue, 0)) AS TongCanDung
        FROM DuLieuTron d
        JOIN MACSilo  ms ON ms.MACID     = d.MACID
        JOIN Silo     s  ON s.SiloID     = ms.SiloID
        JOIN Material m  ON m.MaterialID = s.MaterialID
        WHERE d.Status IN (0, 2)
          AND s.MaterialID IS NOT NULL
        GROUP BY m.MaterialID, m.MaterialName, s.SiloID, s.MaSilo
    )
    SELECT
        n.MaterialName,
        n.MaSilo,
        ISNULL(tk.SoLuongTon, 0)            AS TonHienTai,
        n.TongCanDung                        AS TongCanDung,
        ISNULL(tk.SoLuongTon,0) - n.TongCanDung AS Chenh_Lech,
        ISNULL(tk.MucCanhBao, 500)           AS MucCanhBao,
        CASE
            WHEN ISNULL(tk.SoLuongTon,0) >= n.TongCanDung   THEN N'✓ ĐỦ'
            WHEN ISNULL(tk.SoLuongTon,0) > 0                 THEN N'⚠ THIẾU'
            ELSE                                                   N'✗ HẾT KHO'
        END AS TrangThai,
        CASE
            WHEN ISNULL(tk.SoLuongTon,0) < ISNULL(tk.MucCanhBao,500) THEN 1 ELSE 0
        END AS CanCanhBao
    FROM NhuCau n
    LEFT JOIN TonKho tk ON tk.SiloID = n.SiloID
    ORDER BY CanCanhBao DESC, Chenh_Lech ASC;
END;
GO

PRINT 'Đã tạo 3 stored procedures: sp_NhapKho, sp_XuatKho_TuDong, sp_KiemTra_TonKho_DuLieuTron';

-- ── Test nhanh: chạy kiểm tra tồn kho ngay ───────────────────
EXEC sp_KiemTra_TonKho_DuLieuTron;

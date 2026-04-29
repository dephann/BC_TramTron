-- =============================================================
-- TẠO MODULE TỒN KHO NGUYÊN VẬT LIỆU
-- Gồm 3 bảng:
--   TonKho      : số dư hiện tại theo từng Silo
--   NhapKho     : phiếu nhập NVL (thêm tồn)
--   XuatKho     : phiếu xuất NVL (tự động khi trộn xong)
-- =============================================================

-- ── 1. TonKho: số dư hiện tại ────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TonKho')
BEGIN
    CREATE TABLE TonKho (
        TonKhoID        INT IDENTITY(1,1) PRIMARY KEY,
        SiloID          INT NOT NULL,               -- Silo chứa NVL
        MaterialID      INT NOT NULL,               -- NVL loại gì
        SoLuongTon      DECIMAL(18,2) NOT NULL DEFAULT 0,  -- tồn hiện tại (kg)
        MucCanhBao      DECIMAL(18,2) NOT NULL DEFAULT 500, -- ngưỡng cảnh báo (kg)
        GhiChu          NVARCHAR(500),
        LatestUpdateDate DATETIME,
        LatestUpdatedBy INT,
        CONSTRAINT FK_TonKho_Silo     FOREIGN KEY (SiloID)     REFERENCES Silo(SiloID),
        CONSTRAINT FK_TonKho_Material FOREIGN KEY (MaterialID) REFERENCES Material(MaterialID),
        CONSTRAINT UQ_TonKho_Silo     UNIQUE (SiloID)          -- 1 silo = 1 bản ghi tồn
    );
    PRINT 'Đã tạo bảng TonKho.';
END
ELSE
    PRINT 'TonKho đã tồn tại.';

-- ── 2. NhapKho: phiếu nhập NVL ───────────────────────────────
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NhapKho')
BEGIN
    CREATE TABLE NhapKho (
        NhapKhoID       INT IDENTITY(1,1) PRIMARY KEY,
        MaPhieuNhap     VARCHAR(20) NOT NULL,       -- NK20260412001
        SiloID          INT NOT NULL,
        MaterialID      INT NOT NULL,
        SoLuongNhap     DECIMAL(18,2) NOT NULL,     -- kg nhập
        DonViTinh       VARCHAR(20) DEFAULT 'kg',
        NhaCungCap      NVARCHAR(200),
        NgayNhap        DATETIME NOT NULL DEFAULT GETDATE(),
        SoHoaDon        VARCHAR(50),
        GhiChu          NVARCHAR(500),
        IsApplied       BIT NOT NULL DEFAULT 0,     -- đã cộng vào TonKho chưa
        CreationDate    DATETIME DEFAULT GETDATE(),
        CreatedBy       INT,
        CONSTRAINT FK_NhapKho_Silo     FOREIGN KEY (SiloID)     REFERENCES Silo(SiloID),
        CONSTRAINT FK_NhapKho_Material FOREIGN KEY (MaterialID) REFERENCES Material(MaterialID)
    );
    PRINT 'Đã tạo bảng NhapKho.';
END
ELSE
    PRINT 'NhapKho đã tồn tại.';

-- ── 3. XuatKho: phiếu xuất tự động khi trộn xong ─────────────
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'XuatKho')
BEGIN
    CREATE TABLE XuatKho (
        XuatKhoID       INT IDENTITY(1,1) PRIMARY KEY,
        SiloID          INT NOT NULL,
        MaterialID      INT NOT NULL,
        SoLuongXuat     DECIMAL(18,2) NOT NULL,     -- kg đã dùng
        MeTronID        INT,                        -- liên kết mẻ trộn
        MeTronChiTietID INT,                        -- liên kết chi tiết mẻ
        PhieuTronID     INT,                        -- liên kết phiếu trộn
        DuLieuTronID    INT,                        -- liên kết đơn hàng
        NgayXuat        DATETIME NOT NULL DEFAULT GETDATE(),
        GhiChu          NVARCHAR(200),
        CreationDate    DATETIME DEFAULT GETDATE(),
        CreatedBy       INT,
        CONSTRAINT FK_XuatKho_Silo FOREIGN KEY (SiloID) REFERENCES Silo(SiloID),
        CONSTRAINT FK_XuatKho_Material FOREIGN KEY (MaterialID) REFERENCES Material(MaterialID)
    );
    PRINT 'Đã tạo bảng XuatKho.';
END
ELSE
    PRINT 'XuatKho đã tồn tại.';

-- ── 4. Seed TonKho ban đầu từ Silo hiện có ────────────────────
-- Với mỗi Silo đã có MaterialID, tạo bản ghi tồn kho = 0 (để sau nhập tay)
INSERT INTO TonKho (SiloID, MaterialID, SoLuongTon, MucCanhBao, GhiChu)
SELECT
    s.SiloID,
    s.MaterialID,
    0,                          -- tồn ban đầu = 0, nhập thực tế sau
    CASE
        WHEN s.MaterialName LIKE N'%xi măng%' OR s.MaterialName LIKE N'%ximang%' THEN 2000
        WHEN s.MaterialName LIKE N'%cát%'     OR s.MaterialName LIKE N'%cat%'    THEN 5000
        WHEN s.MaterialName LIKE N'%đá%'      OR s.MaterialName LIKE N'%da%'     THEN 8000
        WHEN s.MaterialName LIKE N'%nước%'    OR s.MaterialName LIKE N'%nuoc%'   THEN 3000
        ELSE 1000
    END AS MucCanhBao,
    N'Khởi tạo ban đầu'
FROM Silo s
WHERE s.MaterialID IS NOT NULL
  AND s.Activated = 1
  AND NOT EXISTS (
    SELECT 1 FROM TonKho tk WHERE tk.SiloID = s.SiloID
  );

PRINT 'Seed TonKho: ' + CAST(@@ROWCOUNT AS VARCHAR(5)) + ' silo.';

-- ── 5. View tổng hợp tồn kho ─────────────────────────────────
IF OBJECT_ID('vw_TonKhoTongHop', 'V') IS NOT NULL
    DROP VIEW vw_TonKhoTongHop;
GO

CREATE VIEW vw_TonKhoTongHop AS
SELECT
    tk.TonKhoID,
    s.SiloID,
    s.MaSilo,
    s.TenSilo,
    m.MaterialID,
    m.MaterialCode,
    m.MaterialName,
    tk.SoLuongTon                               AS TonHienTai,
    tk.MucCanhBao,
    CASE
        WHEN tk.SoLuongTon <= 0           THEN N'HẾT KHO'
        WHEN tk.SoLuongTon < tk.MucCanhBao THEN N'CẢNH BÁO'
        ELSE                                   N'ĐỦ'
    END AS TrangThaiTon,
    ISNULL((
        SELECT SUM(nk.SoLuongNhap)
        FROM NhapKho nk
        WHERE nk.SiloID = s.SiloID
          AND nk.NgayNhap >= DATEADD(DAY, -7, GETDATE())
    ), 0) AS NhapTrongTuan,
    ISNULL((
        SELECT SUM(xk.SoLuongXuat)
        FROM XuatKho xk
        WHERE xk.SiloID = s.SiloID
          AND xk.NgayXuat >= DATEADD(DAY, -7, GETDATE())
    ), 0) AS XuatTrongTuan,
    tk.LatestUpdateDate
FROM TonKho tk
JOIN Silo     s ON s.SiloID     = tk.SiloID
JOIN Material m ON m.MaterialID = tk.MaterialID;
GO

-- ── 6. View ước tính nhu cầu NVL cho DuLieuTron đang chờ ─────
IF OBJECT_ID('vw_NhuCauNVL_DuLieuTron', 'V') IS NOT NULL
    DROP VIEW vw_NhuCauNVL_DuLieuTron;
GO

CREATE VIEW vw_NhuCauNVL_DuLieuTron AS
-- Ước tính NVL cần cho từng DuLieuTron đang chờ
-- Dựa trên: MACSilo.SiloValue (kg/mẻ theo MAC) × DLT_SLMeDuTinh
SELECT
    d.DuLieuTronID,
    d.MaHopDong,
    d.NPKhachHangTenKhachHang   AS KhachHang,
    d.DLT_SLMeDuTinh            AS SoMeDuTinh,
    d.ThoiGianGiaoHang,
    s.SiloID,
    s.MaSilo,
    s.TenSilo,
    m.MaterialID,
    m.MaterialName,
    ms.SiloValue                AS KgMoiMe,
    ISNULL(d.DLT_SLMeDuTinh, 1) * ISNULL(ms.SiloValue, 0) AS TongKgCanDung,
    ISNULL(tk.SoLuongTon, 0)    AS TonHienTai,
    CASE
        WHEN ISNULL(tk.SoLuongTon, 0) >= ISNULL(d.DLT_SLMeDuTinh, 1) * ISNULL(ms.SiloValue, 0)
            THEN N'ĐỦ'
        WHEN ISNULL(tk.SoLuongTon, 0) > 0
            THEN N'THIẾU'
        ELSE
            N'HẾT KHO'
    END AS TrangThai
FROM DuLieuTron d
JOIN MACSilo  ms ON ms.MACID  = d.MACID
JOIN Silo     s  ON s.SiloID  = ms.SiloID
JOIN Material m  ON m.MaterialID = s.MaterialID
LEFT JOIN TonKho tk ON tk.SiloID = s.SiloID
WHERE d.Status IN (0, 2)
  AND s.MaterialID IS NOT NULL;
GO

PRINT 'Hoàn tất tạo module TonKho.';

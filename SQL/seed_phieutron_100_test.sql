-- =============================================================
-- SEED DATA: 100 Phiếu Trộn đang chờ xử lý — ngày 11/04/2026
-- Script tự lấy dữ liệu thực từ các bảng HopDong, MAC, Xe, TaiXe
-- Status: 0=Mới, 2=Đợi  |  ThoiGianGiaoHang: rải từ sáng đến tối
-- =============================================================

SET NOCOUNT ON;

-- ── 1. Kiểm tra có dữ liệu gốc không ──────────────────────────
IF NOT EXISTS (SELECT 1 FROM HopDong WHERE MACID IS NOT NULL)
BEGIN
    RAISERROR('Không có dữ liệu HopDong. Hãy đảm bảo database có dữ liệu gốc.', 16, 1);
    RETURN;
END

-- ── 2. Bảng tạm chứa các nguồn dữ liệu ─────────────────────────
-- Lấy HopDong còn hiệu lực (còn KL có thể tạo phiếu)
CREATE TABLE #SrcHopDong (
    RowNum  INT IDENTITY(1,1),
    HopDongID   INT,
    KhachHangID INT,
    CongTruongID INT,
    MACID       INT,
    HangMucID   INT,
    KLDuTinh    DECIMAL(18,2),
    SLMeDuTinh  DECIMAL(18,2),
    KLDTMeTron  DECIMAL(18,2),
    KLBuTruMeCuoi DECIMAL(18,2)
);

INSERT INTO #SrcHopDong
    (HopDongID, KhachHangID, CongTruongID, MACID, HangMucID,
     KLDuTinh, SLMeDuTinh, KLDTMeTron, KLBuTruMeCuoi)
SELECT TOP 30
    hd.HopDongID,
    hd.KhachHangID,
    hd.CongTruongID,
    hd.MACID,
    hd.HangMucID,
    ISNULL(hd.DLT_KLDuTinh, 6.0),
    ISNULL(hd.DLT_SLMeDuTinh, 6.0),
    ISNULL(hd.DLT_KLDuTinhCuaTungMe, 1.0),
    ISNULL(hd.DLT_KLBuTruMeCuoi, 0.0)
FROM HopDong hd
WHERE hd.MACID IS NOT NULL
  AND hd.HangMucID IS NOT NULL
ORDER BY hd.HopDongID DESC;   -- lấy hợp đồng gần nhất

-- Lấy Xe
CREATE TABLE #SrcXe (RowNum INT IDENTITY(1,1), XeID INT);
INSERT INTO #SrcXe SELECT XeID FROM Xe;

-- Lấy TaiXe
CREATE TABLE #SrcTaiXe (RowNum INT IDENTITY(1,1), TaiXeID INT);
INSERT INTO #SrcTaiXe SELECT TaiXeID FROM TaiXe;

DECLARE @CntHD   INT = (SELECT COUNT(*) FROM #SrcHopDong);
DECLARE @CntXe   INT = (SELECT COUNT(*) FROM #SrcXe);
DECLARE @CntTX   INT = (SELECT COUNT(*) FROM #SrcTaiXe);

IF @CntHD = 0 BEGIN RAISERROR('Không tìm được HopDong hợp lệ.',16,1); RETURN; END

-- ── 3. Lấy số thứ tự MaPhieuTron mới nhất ────────────────────────
DECLARE @MaxNo INT = 0;
SELECT @MaxNo = ISNULL(MAX(CAST(SUBSTRING(MaPhieuTron, 3, 8) AS INT)), 0)
FROM PhieuTron
WHERE MaPhieuTron LIKE 'PT[0-9]%'
  AND ISNUMERIC(SUBSTRING(MaPhieuTron, 3, 8)) = 1;

-- ── 4. Tạo 100 phiếu trộn ────────────────────────────────────────
DECLARE @i        INT = 1;
DECLARE @BaseDate DATETIME = '2026-04-11 06:00:00';   -- bắt đầu ca sáng

-- Phân bố giờ giao hàng: 100 phiếu rải đều 6:00–22:00 = 960 phút / 100 = ~9.6 phút/phiếu
-- Nhưng để thực tế hơn: 30 phiếu gấp (6-10h), 40 phiếu bình thường (10-16h), 30 phiếu chiều (16-22h)

DECLARE @MaPhieu    VARCHAR(20);
DECLARE @HdRow      INT;
DECLARE @XeRow      INT;
DECLARE @TxRow      INT;
DECLARE @HopDongID  INT;
DECLARE @KhachHangID INT;
DECLARE @CongTruongID INT;
DECLARE @MACID      INT;
DECLARE @HangMucID  INT;
DECLARE @KLDuTinh   DECIMAL(18,2);
DECLARE @SLMeDuTinh DECIMAL(18,2);
DECLARE @KLDTMeTron DECIMAL(18,2);
DECLARE @KLBuTru    DECIMAL(18,2);
DECLARE @XeID       INT;
DECLARE @TaiXeID    INT;
DECLARE @GioGiao    DATETIME;
DECLARE @Status     INT;
DECLARE @NoPhieu    INT;

WHILE @i <= 100
BEGIN
    -- Xoay vòng nguồn dữ liệu
    SET @HdRow = ((@i - 1) % @CntHD) + 1;
    SET @XeRow = CASE WHEN @CntXe > 0 THEN ((@i - 1) % @CntXe) + 1 ELSE NULL END;
    SET @TxRow = CASE WHEN @CntTX > 0 THEN ((@i - 1) % @CntTX) + 1 ELSE NULL END;

    SELECT
        @HopDongID    = HopDongID,
        @KhachHangID  = KhachHangID,
        @CongTruongID = CongTruongID,
        @MACID        = MACID,
        @HangMucID    = HangMucID,
        @KLDuTinh     = KLDuTinh,
        @SLMeDuTinh   = SLMeDuTinh,
        @KLDTMeTron   = KLDTMeTron,
        @KLBuTru      = KLBuTruMeCuoi
    FROM #SrcHopDong WHERE RowNum = @HdRow;

    SELECT @XeID    = XeID    FROM #SrcXe    WHERE RowNum = @XeRow;
    SELECT @TaiXeID = TaiXeID FROM #SrcTaiXe WHERE RowNum = @TxRow;

    -- Tên phiếu
    SET @MaPhieu = 'PT' + RIGHT('00000000' + CAST(@MaxNo + @i AS VARCHAR(8)), 8);

    -- Số thứ tự phiếu trong hợp đồng (tính từ phiếu hiện có + vị trí trong loop)
    SELECT @NoPhieu = ISNULL(MAX(NoPhieu), 0) + 1 FROM PhieuTron WHERE HopDongID = @HopDongID;

    -- Phân bố giờ giao hàng theo 3 nhóm:
    --   i=1-30  : gấp  → 06:00–10:00 (8 phút/phiếu)
    --   i=31-70 : bình thường → 10:00–16:00 (9 phút/phiếu)
    --   i=71-100: chiều → 16:00–22:00 (12 phút/phiếu)
    IF @i <= 30
        SET @GioGiao = DATEADD(MINUTE, (@i - 1) * 8,   '2026-04-11 06:00:00');
    ELSE IF @i <= 70
        SET @GioGiao = DATEADD(MINUTE, (@i - 31) * 9,  '2026-04-11 10:00:00');
    ELSE
        SET @GioGiao = DATEADD(MINUTE, (@i - 71) * 12, '2026-04-11 16:00:00');

    -- Xen kẽ Status 0 (Mới) và 2 (Đợi) để có cả hai loại trong danh sách chờ
    SET @Status = CASE WHEN @i % 3 = 0 THEN 2 ELSE 0 END;

    INSERT INTO PhieuTron (
        MaPhieuTron, NoPhieu, NgayPhieuTron,
        KLDuTinh, KLTronNhoNhat, KLTronLonNhat,
        KLDuTinhCuaTungMe, KLBuTruMeCuoi,
        SLMeDuTinh, SLMeHieuChinh,
        HopDongID, KhachHangID, CongTruongID,
        MACID, HangMucID,
        Status,
        XeID, TaiXeID,
        ThoiGianGiaoHang,
        IsQueued,
        CreationDate, CreatedBy
    )
    VALUES (
        @MaPhieu,
        @NoPhieu,
        '2026-04-11 06:00:00',           -- ngày tạo phiếu
        @KLDuTinh,
        @KLDTMeTron * 0.8,               -- KLTronNhoNhat
        @KLDTMeTron,                     -- KLTronLonNhat
        @KLDTMeTron,                     -- KLDuTinhCuaTungMe
        @KLBuTru,
        @SLMeDuTinh,
        @SLMeDuTinh,                     -- SLMeHieuChinh = SLMeDuTinh ban đầu
        @HopDongID,
        @KhachHangID,
        @CongTruongID,
        @MACID,
        @HangMucID,
        @Status,
        @XeID,
        @TaiXeID,
        @GioGiao,                        -- ← Giờ giao hàng phân bố 6h–22h
        0,                               -- IsQueued = false (chưa xếp hàng tự động)
        GETDATE(), 1
    );

    SET @i = @i + 1;
END

-- ── 5. Dọn bảng tạm ───────────────────────────────────────────
DROP TABLE #SrcHopDong;
DROP TABLE #SrcXe;
DROP TABLE #SrcTaiXe;

-- ── 6. Báo kết quả ────────────────────────────────────────────
SELECT
    COUNT(*)                              AS TongPhieuDaTao,
    SUM(CASE WHEN Status = 0 THEN 1 ELSE 0 END) AS SoPhieuMoi,
    SUM(CASE WHEN Status = 2 THEN 1 ELSE 0 END) AS SoPhieuDoi,
    MIN(ThoiGianGiaoHang)                AS GioGiaoSomNhat,
    MAX(ThoiGianGiaoHang)                AS GioGiaoMuonNhat
FROM PhieuTron
WHERE NgayPhieuTron >= '2026-04-11'
  AND MaPhieuTron LIKE 'PT%'
  AND Status IN (0, 2);

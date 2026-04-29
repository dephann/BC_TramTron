-- =============================================================
-- SEED: Tạo 20 DuLieuTron mới để test hệ thống ưu tiên CR
-- Script tự lấy dữ liệu thực từ HopDong, MAC hiện có trong DB
-- ThoiGianGiaoHang tính theo GETDATE() → luôn có đủ 3 màu
--
-- Phân bố CR (5 phút/mẻ):
--   7 dòng: CR ≈ 0.4  → TRỄ  (Đỏ)
--   7 dòng: CR ≈ 1.2  → GẤP  (Vàng)
--   6 dòng: CR ≈ 3.5  → OK   (Xanh)
-- =============================================================

SET NOCOUNT ON;

-- ── 1. Kiểm tra dữ liệu nguồn ────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM HopDong WHERE MACID IS NOT NULL AND HangMucID IS NOT NULL)
BEGIN
    RAISERROR('Không có HopDong hợp lệ. Cần có HopDong với MACID và HangMucID.', 16, 1);
    RETURN;
END

-- ── 2. Bảng tạm nguồn dữ liệu ────────────────────────────────
CREATE TABLE #SrcHD (
    RowNum       INT IDENTITY(1,1),
    HopDongID    INT,
    MaHopDong    VARCHAR(50),
    TenHopDong   NVARCHAR(500),
    KhachHangID  INT,
    CongTruongID INT,
    MACID        INT,
    HangMucID    INT,
    DoSut        VARCHAR(50),
    KLDatHang    DECIMAL(18,2),
    KLDaGiao     DECIMAL(18,2),
    KLConLai     DECIMAL(18,2),
    KLDuTinh     DECIMAL(18,2),
    KLTronMin    DECIMAL(18,2),
    KLTronMax    DECIMAL(18,2),
    KLMeTron     DECIMAL(18,2),
    KLBuTru      DECIMAL(18,2),
    SLMeDuTinh   DECIMAL(18,2),
    KLXeCho      DECIMAL(18,2),
    MaMAC        VARCHAR(50),
    TenMAC       NVARCHAR(200),
    MaKH         VARCHAR(50),
    TenKH        NVARCHAR(200),
    MaCT         VARCHAR(50),
    TenCT        NVARCHAR(500)
);

INSERT INTO #SrcHD
SELECT TOP 20
    hd.HopDongID,
    hd.MaHopDong,
    hd.TenHopDong,
    hd.KhachHangID,
    hd.CongTruongID,
    hd.MACID,
    hd.HangMucID,
    ISNULL(hd.DoSut, ''),
    ISNULL(hd.KLDatHang,  100.0),
    ISNULL(hd.KLDaGiao,     0.0),
    ISNULL(hd.KLConLai,   100.0),
    ISNULL(hd.DLT_KLDuTinh,        6.0),
    ISNULL(hd.DLT_KLTronNhoNhat,   0.8),
    ISNULL(hd.DLT_KLTronLonNhat,   1.0),
    ISNULL(hd.DLT_KLDuTinhCuaTungMe, 1.0),
    ISNULL(hd.DLT_KLBuTruMeCuoi,   0.0),
    ISNULL(hd.DLT_SLMeDuTinh,      6.0),
    ISNULL(hd.DLT_KLXeChoLonNhat,  3.0),
    m.MaMAC,
    m.TenMAC,
    kh.MaKhachHang,
    kh.TenKhachHang,
    ct.MaCongTruong,
    ct.TenCongTruong
FROM HopDong hd
JOIN MAC        m  ON m.MACID          = hd.MACID
JOIN KhachHang  kh ON kh.KhachHangID   = hd.KhachHangID
JOIN CongTruong ct ON ct.CongTruongID  = hd.CongTruongID
WHERE hd.MACID IS NOT NULL
  AND hd.HangMucID IS NOT NULL
ORDER BY hd.HopDongID DESC;

DECLARE @srcCnt INT = (SELECT COUNT(*) FROM #SrcHD);
IF @srcCnt = 0
BEGIN
    DROP TABLE #SrcHD;
    RAISERROR('Không lấy được HopDong nguồn.', 16, 1);
    RETURN;
END
PRINT 'HopDong nguồn: ' + CAST(@srcCnt AS VARCHAR(5));

-- ── 3. Lấy LnNo lớn nhất hiện có ─────────────────────────────
DECLARE @MaxLnNo INT = ISNULL((SELECT MAX(LnNo) FROM DuLieuTron WHERE Status IN (0,2)), 0);

-- ── 4. Tạo 20 DuLieuTron mới ─────────────────────────────────
DECLARE @i      INT = 1;
DECLARE @Total  INT = 20;

-- Biến tạm
DECLARE @HopDongID    INT, @MaHopDong VARCHAR(50), @TenHopDong NVARCHAR(500);
DECLARE @KhachHangID  INT, @CongTruongID INT, @MACID INT, @HangMucID INT;
DECLARE @DoSut        VARCHAR(50);
DECLARE @KLDatHang    DECIMAL(18,2), @KLDaGiao DECIMAL(18,2), @KLConLai DECIMAL(18,2);
DECLARE @KLDuTinh     DECIMAL(18,2), @KLTronMin DECIMAL(18,2), @KLTronMax DECIMAL(18,2);
DECLARE @KLMeTron     DECIMAL(18,2), @KLBuTru  DECIMAL(18,2), @SLMe     DECIMAL(18,2);
DECLARE @KLXeCho      DECIMAL(18,2);
DECLARE @MaMAC        VARCHAR(50),   @TenMAC   NVARCHAR(200);
DECLARE @MaKH         VARCHAR(50),   @TenKH    NVARCHAR(200);
DECLARE @MaCT         VARCHAR(50),   @TenCT    NVARCHAR(500);
DECLARE @ThoiGian     DATETIME;
DECLARE @HdRow        INT;

WHILE @i <= @Total
BEGIN
    -- Xoay vòng qua các HopDong nguồn
    SET @HdRow = ((@i - 1) % @srcCnt) + 1;

    SELECT
        @HopDongID    = HopDongID,
        @MaHopDong    = MaHopDong,
        @TenHopDong   = TenHopDong,
        @KhachHangID  = KhachHangID,
        @CongTruongID = CongTruongID,
        @MACID        = MACID,
        @HangMucID    = HangMucID,
        @DoSut        = DoSut,
        @KLDatHang    = KLDatHang,
        @KLDaGiao     = KLDaGiao,
        @KLConLai     = KLConLai,
        @KLDuTinh     = KLDuTinh,
        @KLTronMin    = KLTronMin,
        @KLTronMax    = KLTronMax,
        @KLMeTron     = KLMeTron,
        @KLBuTru      = KLBuTru,
        @SLMe         = SLMeDuTinh,
        @KLXeCho      = KLXeCho,
        @MaMAC        = MaMAC,
        @TenMAC       = TenMAC,
        @MaKH         = MaKH,
        @TenKH        = TenKH,
        @MaCT         = MaCT,
        @TenCT        = TenCT
    FROM #SrcHD WHERE RowNum = @HdRow;

    -- Gán ThoiGianGiaoHang theo nhóm CR (5 phút/mẻ × hệ số)
    -- Nhóm 1 (i=1-7):  CR ≈ 0.4  (TRỄ - Đỏ)
    -- Nhóm 2 (i=8-14): CR ≈ 1.2  (GẤP - Vàng)
    -- Nhóm 3 (i=15-20):CR ≈ 3.5  (OK  - Xanh)
    IF @i <= 7
        SET @ThoiGian = DATEADD(MINUTE, CAST(@SLMe * 5.0 * 0.4 AS INT), GETDATE());
    ELSE IF @i <= 14
        SET @ThoiGian = DATEADD(MINUTE, CAST(@SLMe * 5.0 * 1.2 AS INT), GETDATE());
    ELSE
        SET @ThoiGian = DATEADD(MINUTE, CAST(@SLMe * 5.0 * 3.5 AS INT), GETDATE());

    INSERT INTO DuLieuTron (
        HopDongID, MaHopDong, TenHopDong, NgayHopDong,
        KhachHangID, CongTruongID, MACID, HangMucID, DoSut,
        KLDatHang, KLDaGiao, KLConLai, KLTaoPhieuTron,
        Status, LastStatus,
        LnNo,
        DLT_KLDuTinh, DLT_KLTronNhoNhat, DLT_KLTronLonNhat,
        DLT_KLDuTinhCuaTungMe, DLT_KLDuTinhCuaTungMe_NoiB,
        DLT_KLDuTinhCuaTungMe_NoiB_IsUsed,
        DLT_KLBuTruMeCuoi, DLT_SLMeDuTinh, DLT_KLXeChoLonNhat,
        NPKhachHangMaKhachHang, NPKhachHangTenKhachHang,
        NPCongTruongMaCongTruong, NPCongTruongTenCongTruong,
        NPMACMaMAC, NPMACTenMAC,
        Activated,
        ThoiGianGiaoHang,
        CreationDate, CreatedBy
    )
    VALUES (
        @HopDongID, @MaHopDong, @TenHopDong, GETDATE(),
        @KhachHangID, @CongTruongID, @MACID, @HangMucID, @DoSut,
        @KLDatHang, @KLDaGiao, @KLConLai, 0,
        0, 0,                                    -- Status=0 (Mới), LastStatus=0
        @MaxLnNo + @i,                           -- LnNo tiếp theo
        @KLDuTinh, @KLTronMin, @KLTronMax,
        @KLMeTron, 1,                            -- DLT_KLDuTinhCuaTungMe_NoiB = 1 (đứng đầu)
        0,                                       -- NoiB_IsUsed = false
        @KLBuTru, @SLMe, @KLXeCho,
        @MaKH, @TenKH,
        @MaCT, @TenCT,
        @MaMAC, @TenMAC,
        1,                                       -- Activated = true
        @ThoiGian,
        GETDATE(), 1
    );

    SET @i = @i + 1;
END

-- ── 5. Dọn bảng tạm ───────────────────────────────────────────
DROP TABLE #SrcHD;

-- ── 6. Báo kết quả + phân bố CR ──────────────────────────────
PRINT 'Đã tạo ' + CAST(@Total AS VARCHAR(5)) + ' DuLieuTron mới.';

SELECT
    d.DuLieuTronID,
    d.LnNo,
    d.MaHopDong,
    d.NPKhachHangTenKhachHang                                         AS KhachHang,
    d.DLT_SLMeDuTinh                                                  AS SoMe,
    d.ThoiGianGiaoHang,
    CAST(
        DATEDIFF(SECOND, GETDATE(), d.ThoiGianGiaoHang) / 60.0
        / NULLIF(d.DLT_SLMeDuTinh * 5.0, 0)
    AS DECIMAL(6,2))                                                  AS CR,
    CASE
        WHEN DATEDIFF(SECOND, GETDATE(), d.ThoiGianGiaoHang) / 60.0
             / NULLIF(d.DLT_SLMeDuTinh*5.0,0) < 1.0 THEN 'TRỄ  (Đỏ)'
        WHEN DATEDIFF(SECOND, GETDATE(), d.ThoiGianGiaoHang) / 60.0
             / NULLIF(d.DLT_SLMeDuTinh*5.0,0) < 1.5 THEN 'GẤP  (Vàng)'
        ELSE                                                          'OK   (Xanh)'
    END AS TrangThai
FROM DuLieuTron d
WHERE d.CreationDate >= DATEADD(MINUTE, -1, GETDATE())
  AND d.Status = 0
ORDER BY d.ThoiGianGiaoHang;

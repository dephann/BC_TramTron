-- =============================================================
-- SEED: Gán ThoiGianGiaoHang dựa theo GETDATE() để test CR
-- Chạy script này BẤT KỲ LÚC NÀO — giờ giao hàng luôn tính
-- tương đối so với thời điểm chạy script.
--
-- Kết quả phân bố CR:
--   Nhóm A (~1/3): CR ≈ 0.4  → TRỄ  (Đỏ)
--   Nhóm B (~1/3): CR ≈ 1.2  → GẤP  (Vàng)
--   Nhóm C (~1/3): CR ≈ 3.5  → OK   (Xanh)
--
-- Công thức: ThoiGianGiaoHang = NOW + (SLMeDuTinh * 5 phút * hệ_số_CR)
-- =============================================================

SET NOCOUNT ON;

IF NOT EXISTS (
    SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
    WHERE TABLE_NAME = 'DuLieuTron' AND COLUMN_NAME = 'ThoiGianGiaoHang'
)
BEGIN
    RAISERROR('Cột ThoiGianGiaoHang chưa tồn tại. Hãy chạy add_ThoiGianGiaoHang_DuLieuTron.sql trước.', 16, 1);
    RETURN;
END

DECLARE @cnt INT = (SELECT COUNT(*) FROM DuLieuTron WHERE Status IN (0, 2));
PRINT 'Số DuLieuTron đang chờ: ' + CAST(@cnt AS VARCHAR(10));

IF @cnt = 0
BEGIN
    RAISERROR('Không có DuLieuTron nào đang chờ (Status 0 hoặc 2).', 16, 1);
    RETURN;
END

-- Reset giờ cũ
UPDATE DuLieuTron SET ThoiGianGiaoHang = NULL WHERE Status IN (0, 2);

-- ── Gán ThoiGianGiaoHang theo nhóm CR ──────────────────────
-- Hệ số nhân CR: 0.4 = trễ, 1.2 = gấp, 3.5 = an toàn
-- EstimatedMinutes = ISNULL(DLT_SLMeDuTinh, 3) * 5 phút/mẻ
UPDATE d
SET d.ThoiGianGiaoHang =
    CASE
        WHEN rn.RowRank <= @cnt / 3
            -- Nhóm TRỄ: CR ≈ 0.4 → giao hàng = NOW + 40% thời gian xử lý
            THEN DATEADD(MINUTE,
                    CAST(ISNULL(d.DLT_SLMeDuTinh, 3) * 5.0 * 0.4 AS INT),
                    GETDATE())
        WHEN rn.RowRank <= (@cnt * 2) / 3
            -- Nhóm GẤP: CR ≈ 1.2 → giao hàng = NOW + 120% thời gian xử lý
            THEN DATEADD(MINUTE,
                    CAST(ISNULL(d.DLT_SLMeDuTinh, 3) * 5.0 * 1.2 AS INT),
                    GETDATE())
        ELSE
            -- Nhóm OK: CR ≈ 3.5 → giao hàng = NOW + 350% thời gian xử lý
            DATEADD(MINUTE,
                    CAST(ISNULL(d.DLT_SLMeDuTinh, 3) * 5.0 * 3.5 AS INT),
                    GETDATE())
    END
FROM DuLieuTron d
INNER JOIN (
    SELECT DuLieuTronID,
           ROW_NUMBER() OVER (ORDER BY LnNo ASC) AS RowRank
    FROM DuLieuTron
    WHERE Status IN (0, 2)
) rn ON d.DuLieuTronID = rn.DuLieuTronID
WHERE d.Status IN (0, 2);

-- ── Xác nhận kết quả + CR thực tế ──────────────────────────
SELECT
    COUNT(*)                                                           AS TongDLT,
    SUM(CASE WHEN ThoiGianGiaoHang IS NOT NULL THEN 1 ELSE 0 END)     AS DaCo_GioGiao,
    MIN(ThoiGianGiaoHang)                                             AS GioGiaoSomNhat,
    MAX(ThoiGianGiaoHang)                                             AS GioGiaoMuonNhat
FROM DuLieuTron WHERE Status IN (0, 2);

-- Chi tiết CR từng dòng
SELECT
    d.DuLieuTronID,
    d.LnNo,
    d.ThoiGianGiaoHang,
    d.DLT_SLMeDuTinh,
    CAST(ISNULL(d.DLT_SLMeDuTinh, 3) * 5.0 AS INT)                  AS EstMinutes,
    CAST(
        DATEDIFF(SECOND, GETDATE(), d.ThoiGianGiaoHang) / 60.0
        / NULLIF(ISNULL(d.DLT_SLMeDuTinh, 3) * 5.0, 0)
    AS DECIMAL(6,2))                                                  AS CR_Thuc,
    CASE
        WHEN DATEDIFF(SECOND, GETDATE(), d.ThoiGianGiaoHang) / 60.0
             / NULLIF(ISNULL(d.DLT_SLMeDuTinh,3)*5.0,0) < 1.0 THEN 'TRỄ  (Đỏ)'
        WHEN DATEDIFF(SECOND, GETDATE(), d.ThoiGianGiaoHang) / 60.0
             / NULLIF(ISNULL(d.DLT_SLMeDuTinh,3)*5.0,0) < 1.5 THEN 'GẤP  (Vàng)'
        ELSE                                                          'OK   (Xanh)'
    END AS TrangThai
FROM DuLieuTron d
WHERE d.Status IN (0, 2)
ORDER BY d.ThoiGianGiaoHang;

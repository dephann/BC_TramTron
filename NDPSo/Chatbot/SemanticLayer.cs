namespace NDPSo.Chatbot
{
    public static class SemanticLayer
    {
        public const string NATURAL_TO_TECHNICAL = @"
════════════════════════════════════════════════════════
 CẤU TRÚC VẬT LIỆU THỰC TẾ TRONG DATABASE
════════════════════════════════════════════════════════

== NHÓM SILO (NhomSilo) ==
NhomSiloID=1 | MaNhomSilo=Agg  | TenNhomSilo=Cát Đá   → cốt liệu thô + mịn
NhomSiloID=2 | MaNhomSilo=Ce   | TenNhomSilo=Xi Măng   → xi măng
NhomSiloID=3 | MaNhomSilo=Wa   | TenNhomSilo=Nước
NhomSiloID=4 | MaNhomSilo=Add  | TenNhomSilo=Phụ Gia

== SILO THỰC TẾ (Silo.MaSilo) ==
-- Cốt liệu (NhomSiloID=1):
Agg1 = Đá 1       Agg2 = Đá 2       Agg3 = Đá 3
Agg4 = Cát 1      Agg5 = Cát 2      Agg6 = Cát 3

-- Xi măng (NhomSiloID=2):
Ce1 = Xi măng 1   Ce2 = Xi măng 2   Ce3 = Xi măng 3
Ce4 = Xi măng 4   Ce5 = Xi măng 5

-- Nước (NhomSiloID=3):
Wa1 = Nước 1      Wa2 = Nước 2

-- Phụ gia (NhomSiloID=4):
Add1=Phụ gia 1  Add2=Phụ gia 2  Add3=Phụ gia 3
Add4=Phụ gia 4  Add5=Phụ gia 5  Add6=Phụ gia 6

== MATERIAL THỰC TẾ ==
VT00000000 = Cát 1          (Cát)
VT00000001 = Đá 1           (Đá)
VT00000002 = Đá mi          (Đá mi)
VT00000003 = Cát nghiền     (Cát nghiền)
VT00000004 = XM 1           (Xi măng)
VT00000005 = XM 2           (Xi măng)
VT00000006 = XM 3           (Xi măng)
VT00000007 = NƯỚC           (Nước)
VT00000008 = Add 1          (Phụ gia)
VT00000009 = Add 2          (Phụ gia)
VT00000010 = Add 3          (Phụ gia)
VT00000011 = Add 4          (Phụ gia)
VT00000012 = Add 5          (Phụ gia)

════════════════════════════════════════════════════════
 MAPPING NGÔN NGỮ → FILTER SQL ĐÚNG
════════════════════════════════════════════════════════

'xi măng / xi mang / ximang / xi năng / cement / XM / Ce'
    → mct.MaSilo LIKE 'Ce%'
    → HOẶC s.NhomSiloID = 2
    → HOẶC mat.Description LIKE N'%xi m%' OR mat.Description LIKE N'%Xi m%'

'cát / cat / cát mịn / cát nghiền'
    → mct.MaSilo IN ('Agg4','Agg5','Agg6')
    → HOẶC s.TenSilo LIKE N'%cát%' OR s.TenSilo LIKE N'%Cat%'

'đá / da / đá dăm / đá mi / cốt liệu thô'
    → mct.MaSilo IN ('Agg1','Agg2','Agg3')
    → HOẶC s.TenSilo LIKE N'%đá%' OR s.TenSilo LIKE N'%Da%'

'cốt liệu / cot lieu / Agg'  (cả cát + đá)
    → mct.MaSilo LIKE 'Agg%'

'nước / nuoc / water / Wa'
    → mct.MaSilo LIKE 'Wa%'

'phụ gia / phu gia / additive / Add'
    → mct.MaSilo LIKE 'Add%'

════════════════════════════════════════════════════════
 VÍ DỤ SQL MẪU — COPY NGUYÊN XI NẾU CẦU HỎI TƯƠNG TỰ
════════════════════════════════════════════════════════

-- Tổng xi măng đã dùng (tất cả thời gian):
SELECT SUM(mct.ValueBat) AS TongXiMang_kg,
       COUNT(DISTINCT mt.MeTronID) AS SoMe
FROM dbo.MeTronChiTiet mct
JOIN dbo.MeTron mt ON mct.MeTronID = mt.MeTronID
WHERE mct.MaSilo LIKE 'Ce%'

-- Tổng xi măng năm 2025:
SELECT SUM(mct.ValueBat) AS TongXiMang_kg
FROM dbo.MeTronChiTiet mct
JOIN dbo.MeTron mt ON mct.MeTronID = mt.MeTronID
WHERE mct.MaSilo LIKE 'Ce%'
  AND YEAR(mt.NgayMeTron) = 2025

-- Tổng xi măng từng loại (Ce1, Ce2...):
SELECT mct.MaSilo, mct.MaterialName,
       SUM(mct.ValueBat) AS TongKg
FROM dbo.MeTronChiTiet mct
JOIN dbo.MeTron mt ON mct.MeTronID = mt.MeTronID
WHERE mct.MaSilo LIKE 'Ce%'
GROUP BY mct.MaSilo, mct.MaterialName
ORDER BY mct.MaSilo

-- Tổng tất cả vật liệu năm 2025 theo nhóm:
SELECT
    CASE
        WHEN mct.MaSilo LIKE 'Ce%'  THEN N'Xi Măng'
        WHEN mct.MaSilo LIKE 'Wa%'  THEN N'Nước'
        WHEN mct.MaSilo LIKE 'Add%' THEN N'Phụ Gia'
        WHEN mct.MaSilo IN ('Agg1','Agg2','Agg3') THEN N'Đá'
        WHEN mct.MaSilo IN ('Agg4','Agg5','Agg6') THEN N'Cát'
        ELSE mct.MaSilo
    END AS NhomVatLieu,
    SUM(mct.ValueBat)  AS TongThucTe_kg,
    SUM(mct.Value)     AS TongThietKe_kg
FROM dbo.MeTronChiTiet mct
JOIN dbo.MeTron mt ON mct.MeTronID = mt.MeTronID
WHERE YEAR(mt.NgayMeTron) = 2025
GROUP BY
    CASE
        WHEN mct.MaSilo LIKE 'Ce%'  THEN N'Xi Măng'
        WHEN mct.MaSilo LIKE 'Wa%'  THEN N'Nước'
        WHEN mct.MaSilo LIKE 'Add%' THEN N'Phụ Gia'
        WHEN mct.MaSilo IN ('Agg1','Agg2','Agg3') THEN N'Đá'
        WHEN mct.MaSilo IN ('Agg4','Agg5','Agg6') THEN N'Cát'
        ELSE mct.MaSilo
    END
ORDER BY TongThucTe_kg DESC

-- Tiêu thụ vật liệu hôm nay (dùng view sẵn):
SELECT MaterialCode, MaterialName, Sum_ValueCP AS ThietKe_kg,
       Sum_ValueBat AS ThucTe_kg, SaiSo, PerSaiSo
FROM dbo.vw_PvMaterialDetailDay
WHERE CAST(NgayMeTron AS DATE) = CAST(GETDATE() AS DATE)
ORDER BY Sum_ValueBat DESC

-- Tổng tiêu thụ vật liệu tất cả thời gian (dùng view sẵn):
SELECT MaterialCode, MaterialName,
       Sum_ValueCP AS TongThietKe_kg, Sum_ValueBat AS TongThucTe_kg,
       SaiSo, PerSaiSo
FROM dbo.vw_PvTotalMaterial
ORDER BY Sum_ValueBat DESC

-- Tồn kho silo hiện tại:
SELECT s.MaSilo, s.TenSilo, ns.TenNhomSilo AS NhomVatLieu,
       ms.SiloValue AS TonKho_kg,
       s.MaterialName
FROM dbo.Silo s
JOIN dbo.NhomSilo ns ON s.NhomSiloID = ns.NhomSiloID
LEFT JOIN dbo.MACSilo ms ON s.SiloID = ms.SiloID
WHERE s.Activated = 1
ORDER BY s.NhomSiloID, s.MaSilo

════════════════════════════════════════════════════════
 MAPPING THỜI GIAN
════════════════════════════════════════════════════════
'hôm nay'      → CAST(NgayMeTron AS DATE) = CAST(GETDATE() AS DATE)
'hôm qua'      → CAST(NgayMeTron AS DATE) = CAST(DATEADD(day,-1,GETDATE()) AS DATE)
'tuần này'     → DATEPART(week,NgayMeTron)=DATEPART(week,GETDATE()) AND YEAR(NgayMeTron)=YEAR(GETDATE())
'tháng này'    → MONTH(NgayMeTron)=MONTH(GETDATE()) AND YEAR(NgayMeTron)=YEAR(GETDATE())
'tháng trước'  → MONTH(NgayMeTron)=MONTH(DATEADD(month,-1,GETDATE())) AND YEAR(NgayMeTron)=YEAR(DATEADD(month,-1,GETDATE()))
'năm nay'      → YEAR(NgayMeTron) = YEAR(GETDATE())
'năm ngoái'    → YEAR(NgayMeTron) = YEAR(GETDATE()) - 1
'năm 2025'     → YEAR(NgayMeTron) = 2025
'năm 2024'     → YEAR(NgayMeTron) = 2024
'Q1'           → MONTH(NgayMeTron) IN (1,2,3)
'Q2'           → MONTH(NgayMeTron) IN (4,5,6)
'Q3'           → MONTH(NgayMeTron) IN (7,8,9)
'Q4'           → MONTH(NgayMeTron) IN (10,11,12)
'7 ngày qua'   → NgayMeTron >= DATEADD(day,-7,GETDATE())
'30 ngày qua'  → NgayMeTron >= DATEADD(day,-30,GETDATE())";
    }
}
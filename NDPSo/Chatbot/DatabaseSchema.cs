namespace NDPSo.Chatbot
{
    /// <summary>
    /// STEP 1 — Chuẩn hóa database schema 100%
    /// Bao gồm: tên bảng/cột chính xác, kiểu dữ liệu, đơn vị, quan hệ FK, business rules
    /// </summary>
    public static class DatabaseSchema
    {
        // ═══════════════════════════════════════════════════════
        //  FOREIGN KEY RELATIONSHIPS
        // ═══════════════════════════════════════════════════════
        public const string FK_MAP = @"
=== KHOÁ CHÍNH (PRIMARY KEYS) ===
CongTruong.CongTruongID         DuLieuTron.DuLieuTronID
EventActionCode.EventActionCodeID  EventLog.EventLogID
HangMuc.HangMucID               HopDong.HopDongID
KhachHang.KhachHangID           MAC.MACID
MACSilo.MACSiloID               Material.MaterialID
MeTron.MeTronID                 MeTronChiTiet.MeTronChiTietID
MeTronChiTietGiaoHang.MeTronChiTietID
NhanVien.NhanVienID             NhomSilo.NhomSiloID
PhieuGiaoHang.PhieuTronID       PhieuTron.PhieuTronID
SEC_Assembly.AssemblyID         SEC_Function.FunctionID
SEC_Role.RoleID                 SEC_RoleFunction.RoleFunctionID
SEC_TypeInfo.TypeInfoID         SEC_User.UserID
SEC_UserRole.UserRoleID         Silo.SiloID
TaiXe.TaiXeID                   TinhDoHutNuoc.TinhDoHutNuocID
TinhDoHutNuocChiTiet.TinhDoHutNuocChiTietID
TraceRecord.TraceRecordID       VatTu.VatTuID
Weigh.WeighID                   Xe.XeID

=== KHOÁ NGOẠI (FOREIGN KEYS) — trích xuất trực tiếp từ DB ===
-- Sản xuất chính
MeTron.PhieuTronID                         → PhieuTron.PhieuTronID
MeTronChiTiet.MeTronID                     → MeTron.MeTronID
MeTronChiTiet.MACSiloID                    → MACSilo.MACSiloID
MeTronChiTietGiaoHang.MeTronID             → MeTron.MeTronID
MeTronChiTietGiaoHang.MACSiloID            → MACSilo.MACSiloID

-- Phiếu trộn
PhieuTron.HopDongID                        → HopDong.HopDongID
PhieuTron.KhachHangID                      → KhachHang.KhachHangID
PhieuTron.CongTruongID                     → CongTruong.CongTruongID
PhieuTron.MACID                            → MAC.MACID
PhieuTron.HangMucID                        → HangMuc.HangMucID
PhieuTron.XeID                             → Xe.XeID
PhieuTron.TaiXeID                          → TaiXe.TaiXeID
PhieuTron.NhanVienID                       → NhanVien.NhanVienID

-- Hợp đồng
HopDong.KhachHangID                        → KhachHang.KhachHangID
HopDong.CongTruongID                       → CongTruong.CongTruongID
HopDong.MACID                              → MAC.MACID
HopDong.HangMucID                          → HangMuc.HangMucID
DuLieuTron.HopDongID                       → HopDong.HopDongID

-- Silo / vật liệu
MACSilo.MACID                              → MAC.MACID
MACSilo.SiloID                             → Silo.SiloID
Silo.NhomSiloID                            → NhomSilo.NhomSiloID
Silo.MaterialID                            → Material.MaterialID
Silo.TinhDoHutNuocID                       → TinhDoHutNuoc.TinhDoHutNuocID
Silo.SoiTrongCat_TruVaoSilo_NhomSiloAgg   → Silo.SiloID
TinhDoHutNuoc.NhomSiloID                   → NhomSilo.NhomSiloID
TinhDoHutNuocChiTiet.TinhDoHutNuocID       → TinhDoHutNuoc.TinhDoHutNuocID

-- Sự kiện / log
EventLog.EventActionCodeID                 → EventActionCode.EventActionCodeID

-- Bảo mật
SEC_Function.TypeInfoID                    → SEC_TypeInfo.TypeInfoID
SEC_RoleFunction.FunctionID                → SEC_Function.FunctionID
SEC_RoleFunction.RoleID                    → SEC_Role.RoleID
SEC_TypeInfo.AssemblyID                    → SEC_Assembly.AssemblyID
SEC_UserRole.RoleID                        → SEC_Role.RoleID
SEC_UserRole.UserID                        → SEC_User.UserID";

        // ═══════════════════════════════════════════════════════
        //  COLUMN UNITS & MEANINGS
        // ═══════════════════════════════════════════════════════
        public const string COLUMN_UNITS = @"
=== ĐƠN VỊ & Ý NGHĨA CỘT QUAN TRỌNG ===
-- Khối lượng (đơn vị: m³ hoặc kg tuỳ context)
MeTron.KhoiLuong            = khối lượng thực tế mẻ trộn (m³)
PhieuTron.KLDuTinh          = khối lượng dự tính (m³)
PhieuTron.KLThuc            = khối lượng thực tế đã trộn (m³)
PhieuTron.KLDuTinhCuaTungMe = KL dự tính mỗi mẻ (m³)
PhieuTron.SLMeDuTinh        = số lượng mẻ dự tính
PhieuTron.SLMeDaTron        = số lượng mẻ đã trộn
HopDong.KLDatHang           = khối lượng đặt hàng theo hợp đồng (m³)
HopDong.KLDaGiao            = khối lượng đã giao (m³)
HopDong.KLConLai            = khối lượng còn lại chưa giao (m³)
Xe.KhoiLuong                = tải trọng xe (tấn)
MeTronChiTiet.Value         = khối lượng thiết kế vật liệu (kg)
MeTronChiTiet.ValueBat      = khối lượng thực tế cân được (kg)
MeTronChiTiet.ValueBatMan   = khối lượng cân thủ công (kg)
MeTronChiTiet.ValueTol      = sai số tuyệt đối (kg)
MeTronChiTiet.ValuePerTol   = sai số phần trăm (%)
MeTronChiTiet.SiloValue     = tham số silo (kg)
MACSilo.SiloValue           = khối lượng tham chiếu silo trong MAC (kg)

-- Thời gian
MeTronChiTiet.TGNhapNhaOn   = thời gian nhập nhả ON (giây)
MeTronChiTiet.TGNhapNhaOff  = thời gian nhập nhả OFF (giây)

-- Trạng thái (Status codes)
MeTron.Status=0             = chưa hoàn thành
MeTron.Status=1             = hoàn thành

MeTron.IsManual=1           = trộn thủ công
PhieuTron.Status=0          = mới tạo
PhieuTron.Status=1          = đang thực hiện
PhieuTron.Status=2          = hoàn thành
PhieuTron.IsQueued=1        = đang chờ trong hàng đợi
HopDong.Status=1            = hợp đồng đang hiệu lực
KhachHang.Activated=1       = khách hàng đang hoạt động
Silo.Activated=1            = silo đang sử dụng

-- Tên alias trong các VIEW
KH    = TenKhachHang
CT    = TenCongTruong
Name  = TenTaiXe
Plate = BienSo (xe)
TX    = TenTaiXe (viết tắt)
MAC   = MaMAC hoặc TenMAC (tuỳ view)
BS    = BienSo (trong vw_InfoPT)
HM    = TenHangMuc
KLMe  = KhoiLuong (khối lượng mẻ trộn)
KLVC  = KhoiLuong Xe (tải trọng xe chở)";

        // ═══════════════════════════════════════════════════════
        //  JOIN PATTERNS — dùng thay vì IN (subquery)
        // ═══════════════════════════════════════════════════════
        public const string JOIN_PATTERNS = @"
=== JOIN PATTERNS CHUẨN — LUÔN DÙNG JOIN, KHÔNG DÙNG IN (subquery) ===

-- [1] Mẻ trộn đầy đủ → DÙNG VIEW (nhanh nhất)
SELECT * FROM dbo.vw_Infos WHERE CAST(NgayMeTron AS DATE)=CAST(GETDATE() AS DATE)

-- [2] MeTron + chi tiết vật liệu
SELECT mt.MeTronID, mt.NgayMeTron, mt.KhoiLuong,
       mct.MaterialName, mct.MaSilo, mct.Value, mct.ValueBat, mct.ValueBatMan
FROM dbo.MeTron mt
JOIN dbo.MeTronChiTiet mct ON mct.MeTronID = mt.MeTronID  -- FK: MeTronChiTiet.MeTronID → MeTron


-- [3] MeTron + PhieuTron + KhachHang + CongTruong
SELECT mt.MeTronID, mt.NgayMeTron, mt.KhoiLuong,
       pt.MaPhieuTron, kh.TenKhachHang, ct.TenCongTruong
FROM dbo.MeTron mt
JOIN dbo.PhieuTron pt  ON mt.PhieuTronID  = pt.PhieuTronID  -- FK: MeTron.PhieuTronID → PhieuTron
JOIN dbo.KhachHang kh  ON pt.KhachHangID  = kh.KhachHangID  -- FK: PhieuTron.KhachHangID → KhachHang
LEFT JOIN dbo.CongTruong ct ON pt.CongTruongID = ct.CongTruongID


-- [4] PhieuTron đầy đủ → DÙNG VIEW
SELECT * FROM dbo.vw_InfoPT WHERE CAST(NgayPhieuTron AS DATE)=CAST(GETDATE() AS DATE)

-- [5] PhieuTron + tất cả quan hệ
SELECT pt.MaPhieuTron, pt.NgayPhieuTron, pt.KLDuTinh,
       kh.TenKhachHang, ct.TenCongTruong,
       m.TenMAC, tx.TenTaiXe, xe.BienSo,
       nv.TenNhanVien, hm.TenHangMuc
FROM dbo.PhieuTron pt
JOIN dbo.HopDong hd    ON pt.HopDongID    = hd.HopDongID     -- FK: PhieuTron.HopDongID → HopDong
JOIN dbo.KhachHang kh  ON pt.KhachHangID  = kh.KhachHangID
LEFT JOIN dbo.CongTruong ct ON pt.CongTruongID = ct.CongTruongID
LEFT JOIN dbo.MAC m        ON pt.MACID         = m.MACID       -- FK: PhieuTron.MACID → MAC
LEFT JOIN dbo.TaiXe tx     ON pt.TaiXeID       = tx.TaiXeID    -- FK: PhieuTron.TaiXeID → TaiXe
LEFT JOIN dbo.Xe xe        ON pt.XeID          = xe.XeID       -- FK: PhieuTron.XeID → Xe
LEFT JOIN dbo.NhanVien nv  ON pt.NhanVienID     = nv.NhanVienID -- FK: PhieuTron.NhanVienID → NhanVien
LEFT JOIN dbo.HangMuc hm   ON pt.HangMucID     = hm.HangMucID  -- FK: PhieuTron.HangMucID → HangMuc

-- [6] MACSilo + Silo + MAC + NhomSilo + Material
SELECT ms.MACSiloID, ms.SiloValue,
       s.MaSilo, s.TenSilo, s.MaterialName, s.MaterialCode,
       m.MaMAC, m.TenMAC,
       ns.TenNhomSilo
FROM dbo.MACSilo ms
JOIN dbo.Silo s    ON ms.SiloID = s.SiloID     -- FK: MACSilo.SiloID → Silo
JOIN dbo.MAC m     ON ms.MACID  = m.MACID      -- FK: MACSilo.MACID → MAC
JOIN dbo.NhomSilo ns ON s.NhomSiloID = ns.NhomSiloID  -- FK: Silo.NhomSiloID → NhomSilo
WHERE s.Activated = 1

-- [7] MeTronChiTiet + Silo + MAC (truy vết vật liệu từng mẻ)
SELECT mct.MeTronID, mct.MaSilo, mct.Value, mct.ValueBat,
       s.TenSilo, s.MaterialName,
       ms.SiloValue, m.TenMAC
FROM dbo.MeTronChiTiet mct
JOIN dbo.MACSilo ms ON mct.MACSiloID = ms.MACSiloID  -- FK: MeTronChiTiet.MACSiloID → MACSilo
JOIN dbo.Silo s     ON ms.SiloID     = s.SiloID      -- FK: MACSilo.SiloID → Silo
JOIN dbo.MAC m      ON ms.MACID      = m.MACID       -- FK: MACSilo.MACID → MAC

-- [8] HopDong đầy đủ
SELECT hd.MaHopDong, hd.KLDatHang, hd.KLDaGiao, hd.KLConLai,
       kh.TenKhachHang, ct.TenCongTruong,
       m.TenMAC, hm.TenHangMuc
FROM dbo.HopDong hd
JOIN dbo.KhachHang kh     ON hd.KhachHangID  = kh.KhachHangID  -- FK: HopDong.KhachHangID → KhachHang
LEFT JOIN dbo.CongTruong ct ON hd.CongTruongID = ct.CongTruongID -- FK: HopDong.CongTruongID → CongTruong
LEFT JOIN dbo.MAC m         ON hd.MACID        = m.MACID         -- FK: HopDong.MACID → MAC
LEFT JOIN dbo.HangMuc hm    ON hd.HangMucID    = hm.HangMucID    -- FK: HopDong.HangMucID → HangMuc
WHERE hd.Status = 1

-- [9] Độ hút nước đầy đủ
SELECT t.NgayTinhDoHut, t.Name, t.DoHutNuoc,
       ns.TenNhomSilo, tc.KichCo, tc.Percentage
FROM dbo.TinhDoHutNuoc t
JOIN dbo.NhomSilo ns ON t.NhomSiloID = ns.NhomSiloID                         -- FK: TinhDoHutNuoc.NhomSiloID → NhomSilo
LEFT JOIN dbo.TinhDoHutNuocChiTiet tc ON tc.TinhDoHutNuocID = t.TinhDoHutNuocID -- FK: TinhDoHutNuocChiTiet.TinhDoHutNuocID → TinhDoHutNuoc

-- [10] EventLog + mã sự kiện
SELECT el.LogDate, el.Description, el.OldValueText, el.NewValueText,
       ea.Content AS LoaiSuKien, ea.Description AS MoTaLoai
FROM dbo.EventLog el
JOIN dbo.EventActionCode ea ON el.EventActionCodeID = ea.EventActionCodeID  -- FK: EventLog.EventActionCodeID → EventActionCode
WHERE CAST(el.LogDate AS DATE) = CAST(GETDATE() AS DATE)

=== QUY TẮC JOIN ===
- LUÔN dùng JOIN...ON theo đúng FK ở trên, KHÔNG dùng WHERE a.id IN (SELECT...)
- INNER JOIN: khi FK NOT NULL (MeTronChiTiet→MeTron, MACSilo→Silo, MACSilo→MAC)
- LEFT JOIN: khi FK nullable (PhieuTron→TaiXe, PhieuTron→Xe, PhieuTron→NhanVien...)
- Alias chuẩn: mt=MeTron, mct=MeTronChiTiet, pt=PhieuTron, kh=KhachHang,
  ct=CongTruong, m=MAC, ms=MACSilo, s=Silo, ns=NhomSilo,
  tx=TaiXe, xe=Xe, nv=NhanVien, hd=HopDong, hm=HangMuc,
  el=EventLog, ea=EventActionCode, u=SEC_User, t=TinhDoHutNuoc";

        // ═══════════════════════════════════════════════════════
        //  BUSINESS RULES
        // ═══════════════════════════════════════════════════════
        public const string BUSINESS_RULES = @"
=== BUSINESS RULES BẮT BUỘC ===
1. Phiếu trộn đang hoạt động: Status IN (0,1) hoặc Activated=1
2. Hợp đồng còn hiệu lực: Status=1 AND KLConLai > 0
3. Khách hàng/CongTruong/Xe/TaiXe đang dùng: Activated=1
4. Khi JOIN MeTron với PhieuTron: dùng MeTron.PhieuTronID = PhieuTron.PhieuTronID
5. Khi cần thông tin đầy đủ mẻ trộn: DÙNG vw_Infos thay vì tự JOIN
6. Khi cần thông tin đầy đủ phiếu trộn: DÙNG vw_InfoPT thay vì tự JOIN
7. Sản lượng = SUM(MeTron.KhoiLuong) — KHÔNG thêm WHERE IsDeleted=0
8. Số mẻ = COUNT(MeTron.MeTronID) — KHÔNG thêm WHERE IsDeleted=0
9. TUYỆT ĐỐI KHÔNG dùng IsDeleted = 0 trong bất kỳ câu truy vấn nào

=== QUY TẮC ALIAS BẮT BUỘC ===
Khi đặt alias cho bảng, PHẢI dùng alias đó NHẤT QUÁN trong toàn bộ câu SQL.
KHÔNG được trộn lẫn tên bảng đầy đủ và alias trong cùng một câu.

ĐÚNG:
  SELECT mct.ValueBat, mct.MaterialName
  FROM dbo.MeTronChiTiet mct
  WHERE mct.MeTronID = 1

SAI (gây lỗi 'multi-part identifier could not be bound'):
  SELECT MeTronChiTiet.ValueBat, mct.MaterialName  ← TRỘN LẪN tên bảng và alias
  FROM dbo.MeTronChiTiet mct

ALIAS CHUẨN (dùng nhất quán):
  mt   = MeTron              mct  = MeTronChiTiet
  pt   = PhieuTron           pg   = PhieuGiaoHang
  kh   = KhachHang           ct   = CongTruong
  hd   = HopDong             hm   = HangMuc
  m    = MAC                 ms   = MACSilo
  s    = Silo                ns   = NhomSilo
  tx   = TaiXe               xe   = Xe
  nv   = NhanVien            u    = SEC_User
  el   = EventLog            ea   = EventActionCode
  t    = TinhDoHutNuoc       tc   = TinhDoHutNuocChiTiet
  mat  = Material            dlt  = DuLieuTron";
    }
}
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
=== QUAN HỆ KHOÁ NGOẠI ===
MeTron.PhieuTronID          → PhieuTron.PhieuTronID
MeTron.CreatedBy            → SEC_User.UserID
MeTronChiTiet.MeTronID      → MeTron.MeTronID
MeTronChiTiet.MACSiloID     → MACSilo.MACSiloID
MeTronChiTiet.MaterialID    → Material.MaterialID
MeTronChiTiet.TinhDoHutNuocID → TinhDoHutNuoc.TinhDoHutNuocID
PhieuTron.HopDongID         → HopDong.HopDongID
PhieuTron.KhachHangID       → KhachHang.KhachHangID
PhieuTron.CongTruongID      → CongTruong.CongTruongID
PhieuTron.MACID             → MAC.MACID
PhieuTron.HangMucID         → HangMuc.HangMucID
PhieuTron.XeID              → Xe.XeID
PhieuTron.TaiXeID           → TaiXe.TaiXeID
PhieuTron.NhanVienID        → NhanVien.NhanVienID
HopDong.KhachHangID         → KhachHang.KhachHangID
HopDong.CongTruongID        → CongTruong.CongTruongID
HopDong.MACID               → MAC.MACID
HopDong.HangMucID           → HangMuc.HangMucID
MACSilo.MACID               → MAC.MACID
MACSilo.SiloID              → Silo.SiloID
Silo.NhomSiloID             → NhomSilo.NhomSiloID
Silo.MaterialID             → Material.MaterialID
Silo.TinhDoHutNuocID        → TinhDoHutNuoc.TinhDoHutNuocID
TinhDoHutNuocChiTiet.TinhDoHutNuocID → TinhDoHutNuoc.TinhDoHutNuocID
DuLieuTron.HopDongID        → HopDong.HopDongID
EventLog.UserID             → SEC_User.UserID
SEC_UserRole.UserID         → SEC_User.UserID
SEC_UserRole.RoleID         → SEC_Role.RoleID";

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
MeTron.IsDeleted=0          = hợp lệ (luôn filter IsDeleted=0 khi đếm sản lượng)
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
        //  BUSINESS RULES
        // ═══════════════════════════════════════════════════════
        public const string BUSINESS_RULES = @"
=== BUSINESS RULES BẮT BUỘC ===
1. Khi đếm/tổng sản lượng mẻ trộn: LUÔN thêm WHERE IsDeleted=0
2. Mẻ trộn hợp lệ: IsDeleted=0 AND Status=1
3. Phiếu trộn đang hoạt động: Status IN (0,1) hoặc Activated=1
4. Hợp đồng còn hiệu lực: Status=1 AND KLConLai > 0
5. Khách hàng/CongTruong/Xe/TaiXe đang dùng: Activated=1
6. Khi JOIN MeTron với PhieuTron: dùng MeTron.PhieuTronID = PhieuTron.PhieuTronID
7. Khi cần thông tin đầy đủ mẻ trộn: DÙNG vw_Infos thay vì tự JOIN
8. Khi cần thông tin đầy đủ phiếu trộn: DÙNG vw_InfoPT thay vì tự JOIN
9. Sản lượng = SUM(MeTron.KhoiLuong) WHERE IsDeleted=0
10. Số mẻ = COUNT(MeTron.MeTronID) WHERE IsDeleted=0";
    }
}
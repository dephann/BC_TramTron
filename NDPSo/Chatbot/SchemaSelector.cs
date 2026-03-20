using System.Text;

namespace NDPSo.Chatbot
{
    /// <summary>
    /// Chọn schema phù hợp theo từ khóa trong câu hỏi.
    /// Chuẩn hóa tiếng Việt không dấu để match chính xác hơn.
    /// Giảm token ~65% so với gửi toàn bộ schema.
    /// </summary>
    public static class SchemaSelector
    {
        // ═══════════════════════════════════════════════════════
        //  BASE RULES — luôn gửi, ngắn gọn
        // ═══════════════════════════════════════════════════════
        private const string BASE_RULES =
@"Trợ lý AI trạm trộn bê tông. Database: Microsoft SQL Server.
KHI CẦN DỮ LIỆU → trả về: SQL: SELECT ...
KHI CÓ DỮ LIỆU  → diễn giải kết quả bằng tiếng Việt, ngắn gọn.
KHÔNG dùng backtick(`). Chỉ SELECT. Luôn TOP 200 hoặc lọc ngày.
Hôm nay: CAST(GETDATE() AS DATE)
Tháng này: MONTH(col)=MONTH(GETDATE()) AND YEAR(col)=YEAR(GETDATE())
Tuần này: DATEPART(week,col)=DATEPART(week,GETDATE()) AND YEAR(col)=YEAR(GETDATE())
QUAN TRỌNG: Ưu tiên dùng VIEW trước, chỉ dùng bảng gốc khi VIEW không đủ.";

        // ═══════════════════════════════════════════════════════
        //  SCHEMA GROUPS
        // ═══════════════════════════════════════════════════════

        private const string SCHEMA_METRON =
@"=== MẺ TRỘN ===
-- Bảng gốc
dbo.MeTron(MeTronID, LnNo, NgayMeTron, PhieuTronID, KhoiLuong, MoTa, Status, IsManual, CreationDate, CreatedBy)
dbo.MeTronChiTiet(MeTronChiTietID, MeTronID, MACSiloID, Value, ValueBat, ValueBatMan, ValueTol, SiloValue, MaterialID, MaterialCode, MaterialName, MaSilo, STTSiloPLC, IsManual, NgayMTCT, CreationDate)

-- VIEW (ưu tiên dùng - đã JOIN sẵn PhieuTron, KhachHang, CongTruong, TaiXe, Xe, MAC, NhanVien)
dbo.vw_Infos       → MeTronID, NgayMeTron, Ngay(date), Gio(time), MaPhieuTron, LnNo,
                      KH(TenKhachHang), CT(TenCongTruong), Name(TenTaiXe), Plate(BienSo),
                      MAC(MaMAC), NoteMAC(TenMAC), DoSut, KLVC(KhoiLuongXe), KLMe(KhoiLuong),
                      TenNV(TenNhanVien), KLDuTinh, HM(TenHangMuc), FullName
dbo.vw_DataMix     → (tất cả cột vw_Infos) + Agg1..6, Ce1..6, Wa1..2, Add1..8
                      + _Bat / _Mac / _Man / _Tol / _PerTol variants

-- Ví dụ SQL đúng:
SQL: SELECT COUNT(*) AS SoMe, SUM(KhoiLuong) AS TongKL_m3 FROM dbo.MeTron WHERE CAST(NgayMeTron AS DATE)=CAST(GETDATE() AS DATE)
SQL: SELECT TOP 50 MaPhieuTron, KH, CT, Plate, KLMe, LnNo, TenNV, NgayMeTron FROM dbo.vw_Infos WHERE CAST(NgayMeTron AS DATE)=CAST(GETDATE() AS DATE) ORDER BY NgayMeTron DESC
SQL: SELECT COUNT(*) AS SoMe, SUM(KLMe) AS TongKL FROM dbo.vw_Infos WHERE MONTH(NgayMeTron)=MONTH(GETDATE()) AND YEAR(NgayMeTron)=YEAR(GETDATE())";

        private const string SCHEMA_PHIEU =
@"=== PHIẾU TRỘN & GIAO HÀNG ===
-- Bảng gốc
dbo.PhieuTron(PhieuTronID, MaPhieuTron, NgayPhieuTron, KLDuTinh, KLThuc, KLDuTinhCuaTungMe,
              SLMeDuTinh, SLMeHieuChinh, SLMeDaTron, HopDongID, KhachHangID, CongTruongID,
              MACID, HangMucID, XeID, TaiXeID, NhanVienID, NguoiTron, Status, IsQueued,
              NoPhieu, CreationDate, CreatedBy)
dbo.PhieuGiaoHang(PhieuTronID, MaPhieuTron, NgayPhieuTron, KLDuTinh, KLThuc,
                  KhachHangID, TenKhachHang, CongTruongID, TenCongTruong,
                  HangMucID, TenHangMuc, DiaDiem, MACID, TenMAC, CuongDo, DoSut,
                  TaiXeID, TenTaiXe, XeID, BienSo, NiemChi, NguoiTron,
                  Activated, GioBD, GioKT, MaHopDong, NoPhieu, CreationDate)

-- VIEW (ưu tiên dùng)
dbo.vw_InfoPT   → PhieuTronID, MaPhieuTron, NgayPhieuTron, Ngay, Gio,
                   KLDuTinh, KLThuc, SLMeDuTinh, KLDuTinhCuaTungMe,
                   KH(TenKhachHang), KH_int(KhachHangID),
                   CT(TenCongTruong), CT_int(CongTruongID),
                   MAC(TenMAC), MAC_int(MACID),
                   BS(BienSo), Xe_int(XeID),
                   TX(TenTaiXe), TX_int(TaiXeID),
                   HM(TenHangMuc), HM_int(HangMucID),
                   IsQueued, CreatedBy, FullName
dbo.vw_SumWeight → PhieuTronID, MaPhieuTron, NgayPhieuTron, KLDuTinh, KLThuc,
                    SUM_Total_Value, SUM_Total_ValueBat, SUM_Total_ValueBatMan, IsQueued, FullName

-- Ví dụ SQL đúng:
SQL: SELECT TOP 50 MaPhieuTron, NgayPhieuTron, KH, CT, KLDuTinh, KLThuc, BS, TX FROM dbo.vw_InfoPT WHERE CAST(NgayPhieuTron AS DATE)=CAST(GETDATE() AS DATE) ORDER BY NgayPhieuTron DESC
SQL: SELECT TOP 100 MaPhieuTron, NgayPhieuTron, KH, CT, KLDuTinh, KLThuc FROM dbo.vw_InfoPT WHERE MONTH(NgayPhieuTron)=MONTH(GETDATE()) AND YEAR(NgayPhieuTron)=YEAR(GETDATE())";

        private const string SCHEMA_KHACHHANG =
@"=== KHÁCH HÀNG, CÔNG TRƯỜNG, HỢP ĐỒNG, HẠNG MỤC ===
dbo.KhachHang(KhachHangID, MaKhachHang, TenKhachHang, DiaChi, Phone, Email, GhiChu, Activated)
dbo.CongTruong(CongTruongID, MaCongTruong, TenCongTruong, DiaChi, Phone, GhiChu, Activated)
dbo.HopDong(HopDongID, MaHopDong, TenHopDong, NgayHopDong, KhachHangID, CongTruongID,
            MACID, HangMucID, DoSut, KLDatHang, KLDaGiao, KLConLai,
            Status, TongPhieu, CreationDate, CreatedBy)
dbo.HangMuc(HangMucID, MaHangMuc, TenHangMuc, GhiChu, Activated)
dbo.DuLieuTron(DuLieuTronID, HopDongID, MaHopDong, KhachHangID, CongTruongID,
               KLDatHang, KLDaGiao, KLConLai, Status, HangMucID, Activated)

-- Ví dụ SQL đúng:
SQL: SELECT TOP 20 kh.TenKhachHang, COUNT(pt.PhieuTronID) AS SoPhieu, SUM(pt.KLDuTinh) AS TongKL FROM dbo.PhieuTron pt JOIN dbo.KhachHang kh ON pt.KhachHangID=kh.KhachHangID WHERE MONTH(pt.NgayPhieuTron)=MONTH(GETDATE()) AND YEAR(pt.NgayPhieuTron)=YEAR(GETDATE()) GROUP BY kh.TenKhachHang ORDER BY TongKL DESC
SQL: SELECT MaHopDong, TenHopDong, KLDatHang, KLDaGiao, KLConLai FROM dbo.HopDong WHERE KLConLai > 0 AND Status=1 ORDER BY KLConLai DESC";

        private const string SCHEMA_VATTU =
@"=== VẬT LIỆU, SILO, TỒN KHO ===
dbo.Material(MaterialID, MaterialCode, MaterialName, Description, Activated, Supplier, Unit, Price)
dbo.Silo(SiloID, MaSilo, TenSilo, NhomSiloID, MaterialID, MaterialCode, MaterialName,
         SaiSoDuoi, SaiSoTren, KLCanNhoNhat, KLCanLonNhat,
         DoAm_NhomSlioAgg, DoHutNuoc_NhomSiloAgg, Activated)
dbo.NhomSilo(NhomSiloID, MaNhomSilo, TenNhomSilo, GhiChu)
dbo.MACSilo(MACSiloID, MACID, SiloID, SiloValue, GhiChu, CreationDate)
dbo.WeiSiloSaving(WeiSiloSavingID, MaCan, MaSilo, GhiChu, CreationDate)
dbo.TinhDoHutNuoc(TinhDoHutNuocID, MaTinhDoHutNuoc, NgayTinhDoHut, NhomSiloID, Name, DoHutNuoc)
dbo.TinhDoHutNuocChiTiet(TinhDoHutNuocChiTietID, TinhDoHutNuocID, KichCo, Percentage, Value)

-- VIEW vật liệu (ưu tiên dùng):
dbo.vw_PvMaterialDetailDay  → MaterialID, MaterialCode, MaterialName,
                               Sum_ValueCP(KLThietKe), Sum_ValueBat(KLThucTe), Sum_ValueBatMan,
                               SaiSo, PerSaiSo(%), NgayMeTron, IsManual, KhoiLuong
dbo.vw_PvTotalMaterial      → MaterialID, MaterialCode, MaterialName,
                               Sum_ValueCP, Sum_ValueBat, Sum_ValueBatMan, SaiSo, PerSaiSo

-- Ví dụ SQL đúng:
SQL: SELECT s.MaSilo, s.TenSilo, s.MaterialName, ms.SiloValue FROM dbo.Silo s LEFT JOIN dbo.MACSilo ms ON s.SiloID=ms.SiloID WHERE s.Activated=1 ORDER BY s.MaSilo
SQL: SELECT MaterialCode, MaterialName, Sum_ValueCP, Sum_ValueBat, SaiSo, PerSaiSo FROM dbo.vw_PvMaterialDetailDay WHERE CAST(NgayMeTron AS DATE)=CAST(GETDATE() AS DATE) ORDER BY Sum_ValueCP DESC
SQL: SELECT MaterialCode, MaterialName, Sum_ValueCP, Sum_ValueBat, SaiSo FROM dbo.vw_PvTotalMaterial ORDER BY Sum_ValueCP DESC";

        private const string SCHEMA_XETAIXE =
@"=== XE, TÀI XẾ, MÁY TRỘN ===
dbo.Xe(XeID, BienSo, KhoiLuong, GhiChu, Activated)
dbo.TaiXe(TaiXeID, MaTaiXe, TenTaiXe, NamSinh, GioiTinh, Phone, GhiChu, Activated)
dbo.MAC(MACID, MaMAC, TenMAC, GhiChu, DoSut, ThemBotNuoc1, ThemBotNuoc2, Activated)

-- VIEW xe & tài xế (ưu tiên dùng):
dbo.vw_PvDriverDetailDay     → NgayMeTron(date), TaiXeID, TenTaiXe, Total_Tranfer(SoChuyến), Total_KL, IsManual
dbo.vw_PvDriverDetailDay_WithID → (như trên + ID tự tăng)
dbo.vw_PvTotalDriver         → TaiXeID, MaTaiXe, TenTaiXe, Total_Tranfer, Total_KL, IsManual
dbo.vw_PvTranferDetailDay    → XeID, BienSo, Total_Tranfer, Total_KL, NgayMeTron, IsQueued
dbo.vw_PvTranferDetailDay_WithID → (như trên + ID tự tăng)
dbo.vw_PvTotalTranfer        → XeID, BienSo, Total_Tranfer, Total_KL, IsManual

-- Ví dụ SQL đúng:
SQL: SELECT TenTaiXe, Total_Tranfer, Total_KL FROM dbo.vw_PvDriverDetailDay WHERE NgayMeTron=CAST(GETDATE() AS DATE) ORDER BY Total_KL DESC
SQL: SELECT TaiXeID, MaTaiXe, TenTaiXe, Total_Tranfer, Total_KL FROM dbo.vw_PvTotalDriver ORDER BY Total_KL DESC
SQL: SELECT BienSo, Total_Tranfer, Total_KL FROM dbo.vw_PvTranferDetailDay WHERE NgayMeTron=CAST(GETDATE() AS DATE) ORDER BY Total_KL DESC
SQL: SELECT XeID, BienSo, Total_Tranfer, Total_KL FROM dbo.vw_PvTotalTranfer ORDER BY Total_KL DESC";

        private const string SCHEMA_NHANSU =
@"=== NHÂN SỰ & NGƯỜI DÙNG ===
dbo.NhanVien(NhanVienID, MaNhanVien, TenNhanVien, NamSinh, GioiTinh, Phone, GhiChu, Activated)
dbo.SEC_User(UserID, UserName, FullName, Department, Email, Phone, CellPhone, IsActived, IsInUse)
dbo.SEC_Role(RoleID, RoleName, Description)
dbo.SEC_UserRole(UserRoleID, UserID, RoleID, CreationDate)
dbo.SEC_Function(FunctionID, FunctionCode, FunctionName, FunctionType, ParentID, Visible, DisplayOrder)

-- Ví dụ SQL đúng:
SQL: SELECT UserName, FullName, Department, IsActived FROM dbo.SEC_User WHERE IsActived=1 ORDER BY FullName
SQL: SELECT nv.TenNhanVien, COUNT(mt.MeTronID) AS SoMe FROM dbo.MeTron mt JOIN dbo.NhanVien nv ON mt.CreatedBy=nv.NhanVienID WHERE CAST(mt.NgayMeTron AS DATE)=CAST(GETDATE() AS DATE) GROUP BY nv.TenNhanVien ORDER BY SoMe DESC";

        private const string SCHEMA_SUKIEN =
@"=== SỰ KIỆN, CẢNH BÁO & THEO DÕI ===
dbo.EventLog(EventLogID, LogCode, LogDate, UserID, UserName, EventActionCodeID,
             EventActionContent, Description, OldValueText, NewValueText,
             Title1, Value1, Content1, CreationDate)
dbo.EventActionCode(EventActionCodeID, Code, CodeNumber, Content, Description, LnNo)
dbo.TraceRecord(TraceRecordID, RecordTime, UserID, UserName, FullName, FormName, ActionName)
dbo.PCInput(PCInputID, Code, Value, Description)
dbo.PCOutput(PCOutputID, Code, Value, Description)
dbo.TimerPara(TimerParaID, TimerParaCode, TimerParaValue, Description)
dbo.bandwidth(bandwidthid, lastday, lasthour, lastweek, lastmonth, active)

-- Ví dụ SQL đúng:
SQL: SELECT TOP 50 LogCode, LogDate, UserName, EventActionContent, Description FROM dbo.EventLog WHERE CAST(LogDate AS DATE)=CAST(GETDATE() AS DATE) ORDER BY LogDate DESC
SQL: SELECT TOP 20 RecordTime, UserName, FullName, FormName, ActionName FROM dbo.TraceRecord WHERE CAST(RecordTime AS DATE)=CAST(GETDATE() AS DATE) ORDER BY RecordTime DESC";

        // ═══════════════════════════════════════════════════════
        //  KEYWORD MAPS
        // ═══════════════════════════════════════════════════════
        private static readonly string[] KW_METRON = {
            "me tron", "metron", "me ", "san luong", "san xuat",
            "trong luong", "khoiluong", "bao nhieu m3", "bao nhieu m³",
            "lnno", "isdeleted", "so me", "tong kl", "mẻ", "sản lượng",
            "mẻ trộn", "trộn hôm", "trộn tuần", "trộn tháng",
            "san luong hom nay", "hom nay tron","khối", "m3", "m khối", "đổ được", "chạy được", "sản lượng", "tổng kết"
        };

        private static readonly string[] KW_PHIEU = {
            "phieu tron", "phieu giao", "phieutron", "phieugiaohang",
            "giao hang", "lenh san", "ma phieu", "sophieu",
            "phiếu", "giao hàng", "lệnh", "phiếu trộn", "phiếu giao",
            "ngay phieu", "kldu tinh", "klthuc", "slme",
            "chua hoan thanh", "dang thi cong", "hang cho"
        };

        private static readonly string[] KW_KHACHHANG = {
            "khach hang", "khachhang", "cong truong", "congtruong",
            "hop dong", "hopdong", "hang muc", "hangmuc",
            "khách hàng", "công trường", "hợp đồng", "hạng mục",
            "du lieu tron", "con lai", "da giao", "dat hang",
            "top khach", "nhieu nhat", "cong trinh"
        };

        private static readonly string[] KW_VATTU = {
            "vat tu", "vattu", "vat lieu", "vatlieu", "silo",
            "xi mang", "cat ", "da ", "nuoc", "phu gia",
            "ton kho", "muc ton", "nguyen lieu",
            "do hut nuoc", "do am", "tinh do hut",
            "materialname", "materialcode",
            "vật tư", "vật liệu", "xi măng", "nước", "tồn kho",
            "nguyên liệu", "độ hút", "độ ẩm", "cốt liệu",
            "nhom silo", "wei silo", "sai so vat lieu"
        };

        private static readonly string[] KW_XETAIXE = {
            "xe ", " xe", "bien so", "bienso", "tai xe", "taixe",
            "chuyen", "may tron", "maytron", "mac ",
            "lai xe", "van chuyen", "total_kl", "total_tranfer",
            "xe cho", "xe nao", "bien so xe",
            "tài xế", "biển số", "chuyến", "máy trộn",
            "vận chuyển", "xe chở", "tài xế nào", "xe nào",
            "nhieu chuyen", "nhieu nhat hom nay"
        };

        private static readonly string[] KW_NHANSU = {
            "nhan vien", "nhanvien", "nguoi tron", "ca lam",
            "sec_user", "user", "fullname", "department",
            "quyen han", "role", "dang nhap",
            "nhân viên", "người trộn", "quyền", "đăng nhập",
            "nguoi dung", "nguoi van hanh", "ai tron"
        };

        private static readonly string[] KW_SUKIEN = {
            "su kien", "sukien", "canh bao", "log ", "eventlog",
            "loi he thong", "trace", "theo doi", "pc input",
            "timer", "bandwidth", "lich su",
            "sự kiện", "cảnh báo", "lỗi", "theo dõi",
            "ai dang nhap", "hoat dong he thong", "ket noi mang"
        };

        // ═══════════════════════════════════════════════════════
        //  PUBLIC METHOD
        // ═══════════════════════════════════════════════════════
        public static string GetSchema(string question)
        {
            // Chuẩn hóa: lowercase + bỏ dấu tiếng Việt
            var q = question.ToLower();
            var qNoDau = RemoveDiacritics(q);

            var sb = new StringBuilder();
            sb.AppendLine(BASE_RULES);

            bool matched = false;

            if (MatchAny(q, qNoDau, KW_METRON)) { sb.AppendLine(SCHEMA_METRON); matched = true; }
            if (MatchAny(q, qNoDau, KW_PHIEU)) { sb.AppendLine(SCHEMA_PHIEU); matched = true; }
            if (MatchAny(q, qNoDau, KW_KHACHHANG)) { sb.AppendLine(SCHEMA_KHACHHANG); matched = true; }
            if (MatchAny(q, qNoDau, KW_VATTU)) { sb.AppendLine(SCHEMA_VATTU); matched = true; }
            if (MatchAny(q, qNoDau, KW_XETAIXE)) { sb.AppendLine(SCHEMA_XETAIXE); matched = true; }
            if (MatchAny(q, qNoDau, KW_NHANSU)) { sb.AppendLine(SCHEMA_NHANSU); matched = true; }
            if (MatchAny(q, qNoDau, KW_SUKIEN)) { sb.AppendLine(SCHEMA_SUKIEN); matched = true; }

            // Không match → gửi schema phổ biến nhất
            if (!matched)
            {
                sb.AppendLine(SCHEMA_METRON);
                sb.AppendLine(SCHEMA_PHIEU);
            }

            return sb.ToString();
        }

        // ═══════════════════════════════════════════════════════
        //  HELPERS
        // ═══════════════════════════════════════════════════════

        /// <summary>Match trên cả text có dấu lẫn không dấu</summary>
        private static bool MatchAny(string q, string qNoDau, string[] keywords)
        {
            foreach (var kw in keywords)
                if (q.Contains(kw) || qNoDau.Contains(kw))
                    return true;
            return false;
        }

        /// <summary>Bỏ dấu tiếng Việt để match không phân biệt dấu</summary>
        private static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            text = text
                .Replace("à", "a").Replace("á", "a").Replace("ả", "a").Replace("ã", "a").Replace("ạ", "a")
                .Replace("ă", "a").Replace("ắ", "a").Replace("ằ", "a").Replace("ẳ", "a").Replace("ẵ", "a").Replace("ặ", "a")
                .Replace("â", "a").Replace("ấ", "a").Replace("ầ", "a").Replace("ẩ", "a").Replace("ẫ", "a").Replace("ậ", "a")
                .Replace("è", "e").Replace("é", "e").Replace("ẻ", "e").Replace("ẽ", "e").Replace("ẹ", "e")
                .Replace("ê", "e").Replace("ế", "e").Replace("ề", "e").Replace("ể", "e").Replace("ễ", "e").Replace("ệ", "e")
                .Replace("ì", "i").Replace("í", "i").Replace("ỉ", "i").Replace("ĩ", "i").Replace("ị", "i")
                .Replace("ò", "o").Replace("ó", "o").Replace("ỏ", "o").Replace("õ", "o").Replace("ọ", "o")
                .Replace("ô", "o").Replace("ố", "o").Replace("ồ", "o").Replace("ổ", "o").Replace("ỗ", "o").Replace("ộ", "o")
                .Replace("ơ", "o").Replace("ớ", "o").Replace("ờ", "o").Replace("ở", "o").Replace("ỡ", "o").Replace("ợ", "o")
                .Replace("ù", "u").Replace("ú", "u").Replace("ủ", "u").Replace("ũ", "u").Replace("ụ", "u")
                .Replace("ư", "u").Replace("ứ", "u").Replace("ừ", "u").Replace("ử", "u").Replace("ữ", "u").Replace("ự", "u")
                .Replace("ỳ", "y").Replace("ý", "y").Replace("ỷ", "y").Replace("ỹ", "y").Replace("ỵ", "y")
                .Replace("đ", "d");
            return text;
        }
    }
}
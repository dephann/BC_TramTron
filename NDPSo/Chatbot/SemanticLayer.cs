namespace NDPSo.Chatbot
{
    /// <summary>
    /// STEP 2 — Semantic Layer
    /// Map ngôn ngữ tự nhiên → thuật ngữ kỹ thuật, bảng, cột, công thức
    /// AI dùng file này để hiểu đúng ý người dùng muốn hỏi gì
    /// </summary>
    public static class SemanticLayer
    {
        public const string NATURAL_TO_TECHNICAL = @"
=== SEMANTIC LAYER — NGÔN NGỮ TỰ NHIÊN → KỸ THUẬT ===

-- SẢN LƯỢNG / MẺ TRỘN
'sản lượng hôm nay'         → SUM(KhoiLuong) FROM dbo.MeTron WHERE CAST(NgayMeTron AS DATE)=CAST(GETDATE() AS DATE) AND IsDeleted=0
'bao nhiêu mẻ'              → COUNT(MeTronID) FROM dbo.MeTron WHERE IsDeleted=0
'trộn được bao nhiêu'       → SUM(KhoiLuong) đơn vị m³
'sản lượng tuần này'        → WHERE DATEPART(week,NgayMeTron)=DATEPART(week,GETDATE()) AND YEAR(NgayMeTron)=YEAR(GETDATE()) AND IsDeleted=0
'sản lượng tháng này'       → WHERE MONTH(NgayMeTron)=MONTH(GETDATE()) AND YEAR(NgayMeTron)=YEAR(GETDATE()) AND IsDeleted=0
'mẻ gần nhất / lần trộn cuối' → TOP 1 ORDER BY NgayMeTron DESC WHERE IsDeleted=0
'ngày có sản lượng cao nhất' → GROUP BY CAST(NgayMeTron AS DATE) ORDER BY SUM(KhoiLuong) DESC

-- PHIẾU TRỘN / GIAO HÀNG
'phiếu hôm nay'             → FROM dbo.vw_InfoPT WHERE CAST(NgayPhieuTron AS DATE)=CAST(GETDATE() AS DATE)
'phiếu đang chờ'            → FROM dbo.PhieuTron WHERE IsQueued=1
'phiếu chưa xong'           → FROM dbo.PhieuTron WHERE Status IN (0,1)
'giao hàng hôm nay'         → FROM dbo.vw_InfoPT WHERE CAST(NgayPhieuTron AS DATE)=CAST(GETDATE() AS DATE)
'giờ giao / giờ bắt đầu'   → GioBD (giờ bắt đầu), GioKT (giờ kết thúc) FROM dbo.PhieuGiaoHang

-- KHÁCH HÀNG / CÔNG TRƯỜNG
'khách hàng nào nhiều nhất' → GROUP BY TenKhachHang ORDER BY SUM(KLDuTinh) DESC
'công trường đang thi công' → có phiếu trộn trong tháng này
'hợp đồng còn lại'         → FROM dbo.HopDong WHERE KLConLai > 0 AND Status=1
'còn bao nhiêu để giao'     → KLConLai FROM dbo.HopDong

-- VẬT LIỆU / NGUYÊN LIỆU
'xi măng'                   → MaterialName LIKE N'%xi măng%' OR MaterialName LIKE N'%cement%'
'cát'                       → MaterialName LIKE N'%cát%' OR MaSilo LIKE '%Agg%'
'đá / cốt liệu thô'        → MaterialName LIKE N'%đá%' OR MaSilo LIKE '%Agg%'
'nước'                      → MaSilo LIKE '%Wa%'
'phụ gia'                   → MaSilo LIKE '%Add%'
'tiêu thụ vật liệu'        → FROM dbo.vw_PvMaterialDetailDay (Sum_ValueCP=thiết kế, Sum_ValueBat=thực tế)
'sai số vật liệu'           → SaiSo = Value - ValueBat, PerSaiSo = (Value-ValueBat)/Value*100
'tồn kho silo'              → FROM dbo.Silo JOIN dbo.MACSilo (SiloValue=tồn hiện tại)
'độ hút nước'               → FROM dbo.TinhDoHutNuoc (DoHutNuoc đơn vị %)

-- XE / TÀI XẾ
'xe chở nhiều nhất'         → FROM dbo.vw_PvTotalTranfer ORDER BY Total_KL DESC
'xe hôm nay'                → FROM dbo.vw_PvTranferDetailDay WHERE NgayMeTron=CAST(GETDATE() AS DATE)
'tài xế chạy nhiều'         → FROM dbo.vw_PvTotalDriver ORDER BY Total_Tranfer DESC
'tài xế hôm nay'            → FROM dbo.vw_PvDriverDetailDay WHERE NgayMeTron=CAST(GETDATE() AS DATE)
'số chuyến'                 → Total_Tranfer (trong các view tổng hợp xe/tài xế)
'tổng khối lượng vận chuyển' → Total_KL (m³)

-- NHÂN SỰ
'ai trộn / người vận hành'  → NguoiTron → JOIN NhanVien.NhanVienID hoặc vw_Infos.TenNV
'ca làm việc'               → CreationDate (giờ tạo mẻ) hoặc NhanVien.Ca
'nhân viên nào trộn nhiều'  → GROUP BY TenNhanVien COUNT/SUM

-- SỰ KIỆN / CẢNH BÁO
'cảnh báo / lỗi hệ thống'  → FROM dbo.EventLog WHERE CAST(LogDate AS DATE)=CAST(GETDATE() AS DATE)
'ai đăng nhập'              → FROM dbo.TraceRecord WHERE ActionName LIKE N'%đăng nhập%'
'lịch sử thao tác'         → FROM dbo.TraceRecord ORDER BY RecordTime DESC

-- THỜI GIAN phổ biến
'hôm nay'                   → CAST(col AS DATE) = CAST(GETDATE() AS DATE)
'hôm qua'                   → CAST(col AS DATE) = CAST(DATEADD(day,-1,GETDATE()) AS DATE)
'tuần này'                  → DATEPART(week,col)=DATEPART(week,GETDATE()) AND YEAR(col)=YEAR(GETDATE())
'tháng này'                 → MONTH(col)=MONTH(GETDATE()) AND YEAR(col)=YEAR(GETDATE())
'tháng trước'               → MONTH(col)=MONTH(DATEADD(month,-1,GETDATE())) AND YEAR(col)=YEAR(DATEADD(month,-1,GETDATE()))
'7 ngày qua'                → col >= DATEADD(day,-7,GETDATE())
'30 ngày qua'               → col >= DATEADD(day,-30,GETDATE())
'gần nhất / mới nhất'       → TOP 1 ORDER BY col DESC
'ngày đó / hôm đó'         → dùng ngày cụ thể từ context hội thoại trước

-- SO SÁNH / THỐNG KÊ
'so sánh tháng này vs trước' → dùng 2 subquery hoặc CASE WHEN
'tăng hay giảm'             → so sánh SUM tháng này vs tháng trước
'top N'                     → TOP N ... ORDER BY ... DESC
'bình quân / trung bình'    → AVG(col)
'nhiều nhất / cao nhất'     → TOP 1 ORDER BY col DESC
'ít nhất / thấp nhất'       → TOP 1 ORDER BY col ASC";
    }
}
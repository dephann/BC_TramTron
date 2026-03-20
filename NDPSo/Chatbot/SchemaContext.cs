namespace NDPSo.Chatbot
{
    public static class SchemaContext
    {
        // ═══════════════════════════════════════════════════════════════
        //  SYSTEM_PROMPT — giữ nguyên cũ (dùng cho các nơi gọi trực tiếp)
        // ═══════════════════════════════════════════════════════════════
        public const string SYSTEM_PROMPT =
@"Bạn là trợ lý AI vận hành trạm trộn bê tông. Database: Microsoft SQL Server.

KHI CẦN DỮ LIỆU: trả về đúng định dạng:
SQL: SELECT ...

KHI ĐÃ CÓ DỮ LIỆU: diễn giải kết quả bằng tiếng Việt, ngắn gọn.

=== QUY TẮC BẮT BUỘC ===
- KHÔNG dùng backtick (`). Chỉ SQL Server syntax.
- Chỉ SELECT, không INSERT/UPDATE/DELETE.
- Luôn TOP 200 hoặc lọc ngày.
- Hôm nay: CAST(GETDATE() AS DATE)
- Tháng này: MONTH(col)=MONTH(GETDATE()) AND YEAR(col)=YEAR(GETDATE())
- Ưu tiên dùng VIEW thay vì tự JOIN nhiều bảng.
- KHÔNG tự thêm IsDeleted=0.
- KHÔNG dùng @tham số — dùng giá trị cụ thể hoặc GETDATE().
- LUÔN dùng JOIN...ON theo FK, KHÔNG dùng IN(subquery).
- MeTron KHÔNG CÓ cột MACID — phải JOIN qua PhieuTron.";

        // ═══════════════════════════════════════════════════════════════
        //  INTERPRET_PROMPT — giữ nguyên cũ + nâng cấp tone
        // ═══════════════════════════════════════════════════════════════
        public const string INTERPRET_PROMPT =
@"Bạn là trợ lý vận hành trạm trộn bê tông, nói chuyện thân thiện như đồng nghiệp.

CÁCH TRẢ LỜI:
- Dùng ngôn ngữ tự nhiên, gần gũi — KHÔNG dùng markdown (**, ##, -)
- Trả lời trực tiếp vào câu hỏi, dùng số liệu cụ thể
- Tóm tắt tổng thể trước, chi tiết nổi bật sau
- Nếu không có dữ liệu: gợi ý cách hỏi khác, KHÔNG nói cứng là 'không có'";

        // ═══════════════════════════════════════════════════════════════
        //  ALL_TABLES — 39 bảng chính xác từ script.sql
        // ═══════════════════════════════════════════════════════════════
        public const string ALL_TABLES =
@"=== 39 BẢNG CHÍNH XÁC TỪ DATABASE ===

-- SẢN XUẤT CHÍNH
MeTron(MeTronID[PK], LnNo, NgayMeTron[datetime], PhieuTronID[FK→PhieuTron],
  KhoiLuong[m³], MoTa, Status, IsManual, IsDeleted, CreationDate, CreatedBy)
  !! MeTron KHÔNG CÓ cột MACID, KhachHangID, CongTruongID, XeID, TaiXeID !!
  !! Muốn lấy MAC/KH/CT/Xe: phải JOIN PhieuTron trước !!

MeTronChiTiet(MeTronChiTietID[PK], MeTronID[FK→MeTron], MACSiloID[FK→MACSilo],
  Value[KL thiết kế,kg], ValueBat[KL thực tế,kg], ValueBatAuto, ValueBatMan[cân tay,kg],
  ValueTol[sai số,kg], ValuePerTol[sai số,%], SiloValue,
  SaiSoDuoi, SaiSoTren, KLCanNhoNhat, KLCanLonNhat, KLRoi,
  MaterialID[FK→Material], MaterialCode, MaterialName,
  MaSilo[Agg1-6/Ce1-6/Wa1-2/Add1-8], STTSiloPLC, IsManual, NgayMTCT, CreationDate, CreatedBy)

MeTronChiTietGiaoHang(MeTronChiTietID[PK], MeTronID[FK→MeTron], MACSiloID[FK→MACSilo],
  Value, ValueBat, SiloValue, MaterialID, MaterialCode, MaterialName,
  MaSilo, IsManual, NgayMTCT, CreationDate, CreatedBy)

PhieuTron(PhieuTronID[PK], MaPhieuTron, NgayPhieuTron[datetime],
  KLDuTinh[m³], KLThuc[m³], KLDuTinhCuaTungMe, KLBuTruMeCuoi,
  SLMeDuTinh, SLMeHieuChinh, SLMeDaTron,
  HopDongID[FK→HopDong], KhachHangID[FK→KhachHang],
  CongTruongID[FK→CongTruong], MACID[FK→MAC],
  HangMucID[FK→HangMuc], XeID[FK→Xe], TaiXeID[FK→TaiXe],
  NhanVienID[FK→NhanVien], NguoiTron, MoTa, Status, ThoiGianTron,
  IsQueued, MinKLTron, MaxKLTron, MaxKLXeCho, NoPhieu, CreationDate, CreatedBy)

PhieuGiaoHang(PhieuTronID[PK], MaPhieuTron, NgayPhieuTron,
  KLDuTinh, KLThuc, SLMeDuTinh, SLMeDaTron,
  HopDongID, KhachHangID, TenKhachHang[denorm],
  CongTruongID, TenCongTruong[denorm], HangMucID, TenHangMuc[denorm],
  DiaDiem, MACID, TenMAC[denorm], CuongDo, DoSut, TheTich, LuyKe,
  TaiXeID, TenTaiXe[denorm], XeID, BienSo[denorm],
  NiemChi, NguoiTron, Activated, GioBD, GioKT, MaHopDong, NoPhieu,
  CreationDate, CreatedBy)

HopDong(HopDongID[PK], MaHopDong, TenHopDong, NgayHopDong,
  KhachHangID[FK→KhachHang], CongTruongID[FK→CongTruong],
  MACID[FK→MAC], HangMucID[FK→HangMuc], DoSut,
  KLDatHang[m³], KLDaGiao[m³], KLConLai[m³], KLTaoPhieuTron,
  Status, TongPhieu, MoTa, CreationDate, CreatedBy)

DuLieuTron(DuLieuTronID[PK], HopDongID[FK→HopDong],
  MaHopDong, TenHopDong, NgayHopDong, KhachHangID, CongTruongID, MACID,
  HangMucID, DoSut, KLDatHang, KLDaGiao, KLConLai, KLTaoPhieuTron,
  NPKhachHangTenKhachHang, NPCongTruongTenCongTruong,
  NPMACMaMAC, NPMACTenMAC,
  Status, LastStatus, LnNo, Activated, CreationDate, CreatedBy)

KhachHang(KhachHangID[PK], MaKhachHang, TenKhachHang, GioiTinh,
  DiaChi, Email, Phone, Fax, GhiChu, Activated)

CongTruong(CongTruongID[PK], MaCongTruong, TenCongTruong,
  DiaChi, Phone, GhiChu, Activated)

HangMuc(HangMucID[PK], MaHangMuc, TenHangMuc, GhiChu, Activated)

MAC(MACID[PK], MaMAC, TenMAC, GhiChu, DoSut, ThemBotNuoc1, ThemBotNuoc2, Activated)
  -- MACID chỉ có trong: PhieuTron, HopDong, DuLieuTron, MACSilo
  -- KHÔNG có trong MeTron — phải qua PhieuTron

MACSilo(MACSiloID[PK], MACID[FK→MAC], SiloID[FK→Silo], SiloValue[kg], GhiChu)

Silo(SiloID[PK], MaSilo, TenSilo, NhomSiloID[FK→NhomSilo],
  SaiSoDuoi, SaiSoTren, KLCanNhoNhat, KLCanLonNhat,
  TinhDoHutNuocID[FK→TinhDoHutNuoc],
  MaterialID[FK→Material], MaterialCode, MaterialName, Activated)

NhomSilo(NhomSiloID[PK], MaNhomSilo, TenNhomSilo, GhiChu)
Material(MaterialID[PK], MaterialCode, MaterialName, Description, Activated, Supplier, Unit, Price)
VatTu(VatTuID[PK], MaVatTu, TenVatTu, Description, CreationDate)

TinhDoHutNuoc(TinhDoHutNuocID[PK], MaTinhDoHutNuoc, NgayTinhDoHut,
  NhomSiloID[FK→NhomSilo], Name, DoHutNuoc[%], Description)
TinhDoHutNuocChiTiet(TinhDoHutNuocChiTietID[PK],
  TinhDoHutNuocID[FK→TinhDoHutNuoc], KichCo, Percentage, Value)

WeiSiloSaving(WeiSiloSavingID[PK], MaCan, MaSilo, GhiChu)
WeiSiloVisible(WeiSiloVisibleID[PK], Code, Type, Visible)
Weigh(WeighID[PK], WeighCode, WeighName, STT, Zero, Max, Offset, KLEmpty, Limit)

Xe(XeID[PK], BienSo, KhoiLuong[tải trọng,tấn], GhiChu, Activated)
TaiXe(TaiXeID[PK], MaTaiXe, TenTaiXe, NamSinh, GioiTinh, Phone, GhiChu, Activated)
NhanVien(NhanVienID[PK], MaNhanVien, TenNhanVien, NamSinh, GioiTinh, Phone, GhiChu, Activated)

SEC_User(UserID[PK], UserName, FullName, Department, Email, Phone, IsActived, IsInUse)
SEC_Role(RoleID[PK], RoleName, Description)
SEC_UserRole(UserRoleID[PK], UserID[FK→SEC_User], RoleID[FK→SEC_Role])
SEC_Function(FunctionID[PK], FunctionCode, FunctionName, FunctionType, ParentID, Visible)
SEC_RoleFunction(RoleFunctionID[PK], RoleID[FK→SEC_Role], FunctionID[FK→SEC_Function])
SEC_TypeInfo(TypeInfoID[PK], TypeInfo, AssemblyID[FK→SEC_Assembly])
SEC_Assembly(AssemblyID[PK], AssemblyInfo)

EventLog(EventLogID[PK], LogCode, LogDate[datetime], UserID, UserName,
  EventActionCodeID[FK→EventActionCode], EventActionContent, Description,
  OldValueText, NewValueText, Title1, Value1, Content1, CreationDate)
EventActionCode(EventActionCodeID[PK], Code, CodeNumber, Content, Description, LnNo)
TraceRecord(TraceRecordID[PK], RecordTime[datetime], UserID, UserName, FullName, FormName, ActionName)

PCInput(PCInputID[PK], Code, Value, Description)
PCOutput(PCOutputID[PK], Code, Value, Description)
TimerPara(TimerParaID[PK], TimerParaCode, TimerParaValue, Description)
SysCodeGen(SysCodeGenID[PK], TableName, Prefix, Length, CurrentNumber)
bandwidth(bandwidthid[PK], networkid, lastday, lasthour, lastweek, lastmonth, active)

RptTongTungXe(MeTronID[PK], Ngay, MaPhieuTron, KH, CT, Name, Plate, MAC, KLMe,
  Agg1-5, Ce1-6, Wa1-2, Add1-8 + _Bat variants)
RptViewDataMix(MeTronID[PK], NgayMeTron, Ngay, Gio, MaPhieuTron, KH, CT, MAC, KLMe,
  Agg1-5, Ce1-6, Wa1-2, Add1-8 + _Bat variants)";

        // ═══════════════════════════════════════════════════════════════
        //  FK_COMPLETE — 31 FK chính xác từ script.sql
        // ═══════════════════════════════════════════════════════════════
        public const string FK_COMPLETE =
@"=== 31 FOREIGN KEYS CHÍNH XÁC ===
MeTron.PhieuTronID                        → PhieuTron.PhieuTronID
MeTronChiTiet.MeTronID                    → MeTron.MeTronID
MeTronChiTiet.MACSiloID                   → MACSilo.MACSiloID
MeTronChiTietGiaoHang.MeTronID            → MeTron.MeTronID
MeTronChiTietGiaoHang.MACSiloID           → MACSilo.MACSiloID
PhieuTron.HopDongID                       → HopDong.HopDongID
PhieuTron.KhachHangID                     → KhachHang.KhachHangID
PhieuTron.CongTruongID                    → CongTruong.CongTruongID
PhieuTron.MACID                           → MAC.MACID
PhieuTron.HangMucID                       → HangMuc.HangMucID
PhieuTron.XeID                            → Xe.XeID
PhieuTron.TaiXeID                         → TaiXe.TaiXeID
PhieuTron.NhanVienID                      → NhanVien.NhanVienID
HopDong.KhachHangID                       → KhachHang.KhachHangID
HopDong.CongTruongID                      → CongTruong.CongTruongID
HopDong.MACID                             → MAC.MACID
HopDong.HangMucID                         → HangMuc.HangMucID
DuLieuTron.HopDongID                      → HopDong.HopDongID
MACSilo.MACID                             → MAC.MACID
MACSilo.SiloID                            → Silo.SiloID
Silo.NhomSiloID                           → NhomSilo.NhomSiloID
Silo.MaterialID                           → Material.MaterialID
Silo.TinhDoHutNuocID                      → TinhDoHutNuoc.TinhDoHutNuocID
Silo.SoiTrongCat_TruVaoSilo_NhomSiloAgg   → Silo.SiloID
TinhDoHutNuoc.NhomSiloID                  → NhomSilo.NhomSiloID
TinhDoHutNuocChiTiet.TinhDoHutNuocID      → TinhDoHutNuoc.TinhDoHutNuocID
EventLog.EventActionCodeID                → EventActionCode.EventActionCodeID
SEC_Function.TypeInfoID                   → SEC_TypeInfo.TypeInfoID
SEC_RoleFunction.FunctionID               → SEC_Function.FunctionID
SEC_RoleFunction.RoleID                   → SEC_Role.RoleID
SEC_TypeInfo.AssemblyID                   → SEC_Assembly.AssemblyID
SEC_UserRole.RoleID                       → SEC_Role.RoleID
SEC_UserRole.UserID                       → SEC_User.UserID";

        // ═══════════════════════════════════════════════════════════════
        //  ALL_VIEWS — 16 view với cột đầy đủ
        // ═══════════════════════════════════════════════════════════════
        public const string ALL_VIEWS =
@"=== 16 VIEWS ===

-- Mẻ trộn đầy đủ (ưu tiên dùng nhất)
vw_Infos: MeTronID, NgayMeTron, Ngay[date], Gio[time], Phieu, PhieuTronID, MaPhieuTron,
  LnNo, KLDuTinhCuaTungMe, KLBuTruMeCuoi, MaHopDong,
  KH[TenKhachHang], KH_int[KhachHangID],
  CT[TenCongTruong], CT_int[CongTruongID],
  Name[TenTaiXe], TaiXeID, Plate[BienSo], Xe_int[XeID],
  MAC[MaMAC], NoteMAC[TenMAC], MAC_int[MACID], DoSut,
  KLVC[KhoiLuongXe], KLMe[KhoiLuong_m³],
  NV[NguoiTron], NV_int[NhanVienID], TenNV,
  KLDuTinh, IsQueued, HM[TenHangMuc], HM_int[HangMucID],
  CreatedBy, FullName

-- Phiếu trộn đầy đủ
vw_InfoPT: PhieuTronID, MaPhieuTron, NgayPhieuTron, Ngay, Gio,
  KLDuTinh, KLThuc, SLMeDuTinh, KLDuTinhCuaTungMe,
  KH[TenKhachHang], KH_int, CT[TenCongTruong], CT_int,
  MAC[TenMAC], MAC_int[MACID], BS[BienSo], Xe_int,
  TX[TenTaiXe], TX_int, HM[TenHangMuc], HM_int,
  IsQueued, CreatedBy, FullName, UserID

-- Mẻ trộn + vật liệu pivot
vw_DataMix: (tất cả cột vw_Infos)
  + Agg1..6, Ce1..6, Wa1..2, Add1..8
  + _Bat, _Mac, _Man, _Tol, _PerTol variants

-- Phiếu + tổng KL vật liệu
vw_SumWeight: PhieuTronID, MaPhieuTron, NgayPhieuTron,
  KLDuTinh, KLThuc, SLMeDuTinh,
  SUM_Total_Value, SUM_Total_ValueBat, SUM_Total_ValueBatMan,
  IsQueued, FullName

-- Thống kê xe
vw_PvTranferDetailDay:       XeID, BienSo, Total_Tranfer, Total_KL, NgayMeTron[date]
vw_PvTranferDetailDay_WithID: (như trên + ID)
vw_PvTotalTranfer:            XeID, BienSo, Total_Tranfer, Total_KL, IsManual

-- Thống kê tài xế
vw_PvDriverDetailDay:        NgayMeTron[date], TaiXeID, TenTaiXe, Total_Tranfer, Total_KL, IsManual
vw_PvDriverDetailDay_WithID: (như trên + ID)
vw_PvTotalDriver:             TaiXeID, MaTaiXe, TenTaiXe, Total_Tranfer, Total_KL, IsManual

-- Thống kê vật liệu
vw_PvMaterialDetailDay:       MaterialID, MaterialCode, MaterialName,
  Sum_ValueCP[KL thiết kế,kg], Sum_ValueBat[KL thực tế,kg], Sum_ValueBatMan,
  SaiSo[kg], PerSaiSo[%], NgayMeTron[datetime], IsManual, KhoiLuong
vw_PvMaterialDetailDay_WithID: (như trên + ID)
vw_PvTotalMaterial:            MaterialID, MaterialCode, MaterialName,
  Sum_ValueCP, Sum_ValueBat, Sum_ValueBatMan, SaiSo, PerSaiSo, IsManual

-- KL vật liệu theo phiếu
vw_PvTotalWeghit: PhieuTronID, NgayPhieuTron,
  Total_Value/ValueBat/ValueBatMan_Agg1..6, Ce1..5, Wa1..2, Add1..6
vw_PvSUMTotal: PhieuTronID, SUM_Total_Value, SUM_Total_ValueBat, SUM_Total_ValueBatMan

-- Pivot chi tiết mẻ
vw_PvtMTCT: MeTronID, Agg1..6, Ce1..6, Wa1..2, Add1..8 (Value/Bat/Mac/Man/Tol/PerTol)";

        // ═══════════════════════════════════════════════════════════════
        //  JOIN_PATHS — đường đi FK đúng + ví dụ SQL chuẩn
        // ═══════════════════════════════════════════════════════════════
        public const string JOIN_PATHS =
@"=== ĐƯỜNG ĐI JOIN ĐÚNG ===

[MAC từ mẻ trộn] — MeTron KHÔNG có MACID:
  MeTron → PhieuTron (PhieuTronID) → MAC (MACID)
  SQL: FROM dbo.MeTron mt
       JOIN dbo.PhieuTron pt ON mt.PhieuTronID=pt.PhieuTronID
       JOIN dbo.MAC m ON pt.MACID=m.MACID
  HOẶC ngắn hơn: SELECT MAC_int,MAC,NoteMAC FROM dbo.vw_Infos

[KhachHang/CongTruong/Xe/TaiXe từ mẻ trộn]:
  MeTron → PhieuTron → KhachHang/CongTruong/Xe/TaiXe
  HOẶC: SELECT KH,CT,Plate,TX FROM dbo.vw_Infos

[Vật liệu từ mẻ trộn]:
  MeTronChiTiet.MaterialName, MaterialCode, MaSilo (cột trực tiếp — không cần JOIN)

[Silo từ mẻ trộn]:
  MeTronChiTiet → MACSilo (MACSiloID) → Silo (SiloID)

[MAC từ silo]:
  Silo → MACSilo (SiloID) → MAC (MACID)

=== VÍ DỤ SQL CHUẨN ===

-- MAC dùng nhiều nhất năm 2024 (dùng view):
SQL: SELECT MAC, NoteMAC, MAC_int, COUNT(MeTronID) AS SoMe, SUM(KLMe) AS TongKL_m3
     FROM dbo.vw_Infos WHERE YEAR(NgayMeTron)=2024
     GROUP BY MAC, NoteMAC, MAC_int ORDER BY SoMe DESC

-- MAC dùng nhiều nhất (tự JOIN đúng cách):
SQL: SELECT m.MACID, m.MaMAC, m.TenMAC,
       COUNT(mt.MeTronID) AS SoMe, SUM(mt.KhoiLuong) AS TongKL_m3
     FROM dbo.MeTron mt
     JOIN dbo.PhieuTron pt ON mt.PhieuTronID=pt.PhieuTronID
     JOIN dbo.MAC m ON pt.MACID=m.MACID
     WHERE YEAR(mt.NgayMeTron)=2024
     GROUP BY m.MACID,m.MaMAC,m.TenMAC ORDER BY SoMe DESC

-- Sản lượng hôm nay:
SQL: SELECT COUNT(*) AS SoMe, SUM(KhoiLuong) AS TongKL_m3
     FROM dbo.MeTron WHERE CAST(NgayMeTron AS DATE)=CAST(GETDATE() AS DATE)

-- Mẻ trộn hôm nay đầy đủ:
SQL: SELECT TOP 50 MaPhieuTron,KH,CT,Plate,KLMe,LnNo,TenNV,NgayMeTron
     FROM dbo.vw_Infos WHERE CAST(NgayMeTron AS DATE)=CAST(GETDATE() AS DATE)

-- KL vật liệu hôm nay:
SQL: SELECT MaterialCode,MaterialName,Sum_ValueCP,Sum_ValueBat,SaiSo
     FROM dbo.vw_PvMaterialDetailDay
     WHERE CAST(NgayMeTron AS DATE)=CAST(GETDATE() AS DATE)

-- Phiếu tháng này:
SQL: SELECT TOP 100 MaPhieuTron,NgayPhieuTron,KH,CT,KLDuTinh,KLThuc,BS,TX
     FROM dbo.vw_InfoPT
     WHERE MONTH(NgayPhieuTron)=MONTH(GETDATE()) AND YEAR(NgayPhieuTron)=YEAR(GETDATE())

-- Tồn kho silo:
SQL: SELECT s.MaSilo,s.TenSilo,s.MaterialName,ms.SiloValue
     FROM dbo.Silo s LEFT JOIN dbo.MACSilo ms ON s.SiloID=ms.SiloID
     WHERE s.Activated=1

=== QUY TẮC ALIAS CHUẨN ===
mt=MeTron, mct=MeTronChiTiet, pt=PhieuTron,
kh=KhachHang, ct=CongTruong, m=MAC, ms=MACSilo,
s=Silo, ns=NhomSilo, tx=TaiXe, xe=Xe, nv=NhanVien,
hd=HopDong, hm=HangMuc, el=EventLog, u=SEC_User";
    }
}
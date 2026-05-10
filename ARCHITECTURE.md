# ARCHITECTURE.md — NDPSo Hệ Thống Quản Lý Trạm Trộn Bê Tông

> Tài liệu kiến trúc toàn bộ mã nguồn. Đọc file này thay cho việc đọc lại code từ đầu.
> Cập nhật lần cuối: 2026-05-08

---

## MỤC LỤC

1. [Tổng quan dự án](#1-tổng-quan-dự-án)
2. [Cấu trúc thư mục](#2-cấu-trúc-thư-mục)
3. [Kiến trúc phân lớp](#3-kiến-trúc-phân-lớp)
4. [Lớp Data (DTO)](#4-lớp-data-dto)
5. [Lớp EntityModel (EF)](#5-lớp-entitymodel-ef)
6. [Lớp DAL (Repository)](#6-lớp-dal-repository)
7. [Lớp Business Logic](#7-lớp-business-logic)
8. [Form chính: VanHanh](#8-form-chính-vanhanh)
9. [Giao tiếp PLC](#9-giao-tiếp-plc)
10. [Utils & Helpers](#10-utils--helpers)
11. [Các form/view phụ](#11-các-formview-phụ)
12. [Chatbot AI](#12-chatbot-ai)
13. [Luồng dữ liệu chính](#13-luồng-dữ-liệu-chính)
14. [Enums toàn bộ](#14-enums-toàn-bộ)
15. [Màu sắc grid & CR](#15-màu-sắc-grid--cr)
16. [Quick reference files](#16-quick-reference-files)

---

## 1. TỔNG QUAN DỰ ÁN

| Mục          | Giá trị                                                |
| ------------ | ------------------------------------------------------ |
| Loại         | Windows Desktop (WinForms)                             |
| Ngôn ngữ     | C#                                                     |
| Framework    | .NET Framework 4.8                                     |
| UI Library   | DevExpress 19.2.5                                      |
| ORM          | Entity Framework 6 (Database-First)                    |
| Database     | SQL Server — DB: `TramTron`, Server: `DESKTOP-7KUDOEF` |
| PLC          | Siemens S7-1500 qua S7.Net 0.10.0                      |
| DI           | Unity 4.0.1                                            |
| Tổng file C# | > 450 file                                             |

**Mục đích hệ thống:** Quản lý và điều khiển trực tuyến trạm trộn bê tông — hợp đồng, phiếu trộn, giao tiếp PLC theo thời gian thực, in ấn báo cáo, AI chatbot.

---

## 2. CẤU TRÚC THƯ MỤC

```
NDPSo/
├── Administration/      (37 cs)  Quản lý user, role, permission (SEC_*)
├── BusinessObject/      ( 5 cs)  Logic nghiệp vụ lõi
├── Chatbot/             (13 cs)  AI chatbot (Groq / OpenAI)
├── ClientSetting/       ( 3 cs)  ServiceFactory, config chạy Local/WCF
├── Core/                ( 9 cs)  IoC (Unity), EFRepository base, Specification
├── DAL/                 (87 cs)  40+ Repository interface + implementation
├── Data/               (101 cs)  52 DTO class (Obj*) — POCO cho binding/WCF
├── EntityModel/         (62 cs)  EF auto-generated từ EDMX (DbContext, entities)
├── KWS/                 (21 cs)  Service tìm kiếm / workflow
├── MasterData/         (201 cs)  CORE: VanHanh UI + Presenter + PLC
├── PLCMapping/          ( 1 cs)  MappingHelper (float→bytes)
├── PLCModule/           ( 2 cs)  PLCController (S7.Net wrapper), PLCSingleIns
├── Reports/             (22 cs)  Sinh báo cáo, in ấn
├── ServiceLibrary/      ( 2 cs)  Dịch vụ bổ sung
└── Utils/               (32 cs)  Enums, Config, Logger, Colors, Helpers
```

---

## 3. KIẾN TRÚC PHÂN LỚP

```
┌──────────────────────────────────────────────────────────────────┐
│  PRESENTATION  (MasterData/Administration/Reports/Chatbot)       │
│  VanHanh (partial: .cs .Designer .Grid .PLC .Commands .Printing) │
│  NewHopDongView · NewDuLieuTronView · UcSearchHopDong            │
└──────────────────────────┬───────────────────────────────────────┘
                           │ ITronOnlineView (interface)
┌──────────────────────────▼───────────────────────────────────────┐
│  MVP PRESENTER  (MasterData/)                                     │
│  TronOnlineDataPresenter → IMasterDataModel                      │
│  MasterDataPresenter<T> (generic base)                           │
└──────────────────────────┬───────────────────────────────────────┘
                           │
┌──────────────────────────▼───────────────────────────────────────┐
│  BUSINESS LOGIC  (MasterData/BusinessObject)                      │
│  MasterDataModel implements IMasterDataModel                      │
│  Điều phối repo, validate, transaction                            │
└──────────────────────────┬───────────────────────────────────────┘
                           │ Repository interfaces
┌──────────────────────────▼───────────────────────────────────────┐
│  DATA ACCESS  (DAL/ + Core/)                                      │
│  *Repository : EFRepository<T>  +  Specification<T>              │
└──────────────────────────┬───────────────────────────────────────┘
                           │ DbContext
┌──────────────────────────▼───────────────────────────────────────┐
│  ENTITY FRAMEWORK  (EntityModel/)                                 │
│  DEPTramTronEntities : DbContext, IDBContext                      │
│  38 DbSet<T> — SQL Server TramTron                               │
└──────────────────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────────────┐
│  PLC HARDWARE INTERFACE  (PLCModule/ + MasterData/)              │
│  PLCController → S7.Net.Plc → Siemens S7-1500 (TCP:102)         │
│  ReceivingFromPLC (read DB1/4/6/7/8)                             │
│  SendingToPLC + SendingCommand (write DB2)                       │
│  Thread polling 200–500ms                                         │
└──────────────────────────────────────────────────────────────────┘

┌──────────────────────────────────────────────────────────────────┐
│  CROSS-CUTTING  (Utils/ + Core/)                                  │
│  IoC (Unity) · ConfigManager · GlobalValues · TramTronLogger     │
│  ScheduleColorHelper · EncryptionHelper · TramTromMessageBox     │
└──────────────────────────────────────────────────────────────────┘
```

### Design Patterns áp dụng

| Pattern                  | Nơi dùng                                            |
| ------------------------ | --------------------------------------------------- |
| **MVP**                  | TronOnlineDataPresenter ↔ ITronOnlineView ↔ VanHanh |
| **Repository**           | DAL/\*Repository, Core/EFRepository<T>              |
| **Specification**        | Core/ISpecification, Core/Specification<T>          |
| **Dependency Injection** | Core/IoC.cs (Unity container)                       |
| **Factory**              | ClientSetting/ServiceFactories                      |
| **Singleton**            | PLCModule/PLCSingleIns                              |
| **BindingList**          | UI binding: BindingList<ObjDuLieuTron> → grcHopDong |

---

## 4. LỚP DATA (DTO)

**Base class:** `ObjectBase` — `MarkAsDeleted`, `IsNewObject`
**Attribute:** `[DataContract]` — serializable cho WCF/UI binding

### ObjDuLieuTron ← **TRỌNG TÂM GRID CHÍNH**

File: `NDPSo/Data/ObjDuLieuTron.cs`

| Property                                    | Kiểu             | Ghi chú                                                  |
| ------------------------------------------- | ---------------- | -------------------------------------------------------- |
| DuLieuTronID                                | int              | PK                                                       |
| HopDongID                                   | int?             | FK → HopDong                                             |
| MaHopDong, TenHopDong, NgayHopDong          | string/DateTime? |                                                          |
| KhachHangID, CongTruongID, MACID, HangMucID | int?             | FK master data                                           |
| KLDatHang, KLDaGiao, KLConLai               | decimal?         | Khối lượng                                               |
| DLT_KLDuTinh                                | decimal?         | KL dự tính tổng                                          |
| DLT_KLDuTinhCuaTungMe                       | decimal?         | KL mỗi mẻ                                                |
| DLT_SLMeDuTinh                              | decimal?         | Số mẻ dự tính                                            |
| DLT_KLBuTruMeCuoi                           | decimal?         | Bù trừ mẻ cuối                                           |
| DLT_MACSUMSiloValue                         | decimal?         | Tổng silo MAC                                            |
| ThoiGianGiaoHang                            | DateTime?        | Deadline giao hàng                                       |
| **Status**                                  | int?             | **0=New 1=Running 2=Pause 3=Abort 4=Finished**           |
| LastStatus                                  | int?             | Status trước đó                                          |
| **CriticalRatio**                           | double?          | _Computed_: thời gian còn lại / thời gian xử lý ước tính |
| TrangThaiThoiGian                           | string           | _Computed_: "TRỄ" / "SẮP TRỄ" / "ĐÚNG HẠN"               |
| NPStatus                                    | string           | _Computed_: Status→string                                |
| LnNo                                        | int?             | Thứ tự dòng (dùng để sắp xếp mặc định)                   |
| VersionNo                                   | byte[]           | Optimistic concurrency                                   |
| Activated                                   | bool             | Kích hoạt                                                |

**CriticalRatio formula:**

```
CR = (ThoiGianGiaoHang - DateTime.Now).TotalHours
   / (DLT_SLMeDuTinh * 5 phút/mẻ / 60)
```

### ObjHopDong

File: `NDPSo/Data/ObjHopDong.cs`

| Property                                      | Kiểu     | Ghi chú                                |
| --------------------------------------------- | -------- | -------------------------------------- |
| HopDongID                                     | int      | PK                                     |
| MaHopDong, TenHopDong, NgayHopDong            |          |                                        |
| KhachHangID, CongTruongID, MACID, HangMucID   | int?     | FK                                     |
| KLDatHang, KLDaGiao, KLConLai, KLTaoPhieuTron | decimal? |                                        |
| DoSut                                         | decimal? | Độ sụt                                 |
| TongPhieu                                     | int?     | Tổng số phiếu                          |
| DLT_KLDuTinh, DLT_SLMeDuTinh, ...             |          | Tham số tính toán DLT                  |
| Status                                        | int?     | HopDongStatus enum                     |
| NPMACTenMAC, NPMACThemBotNuoc1                |          | Computed từ MAC                        |
| KLLyThuyetCoTheTaoPT                          | decimal? | _Computed_: KL lý thuyết có thể tạo PT |

### ObjPhieuTron

File: `NDPSo/Data/ObjPhieuTron.cs`

| Property                                    | Kiểu      | Ghi chú              |
| ------------------------------------------- | --------- | -------------------- |
| PhieuTronID                                 | int       | PK                   |
| MaPhieuTron                                 | string    | Mã phiếu             |
| NoPhieu                                     | int?      | Số thứ tự            |
| NgayPhieuTron                               | DateTime? |                      |
| KLDuTinh, KLThuc                            | decimal?  | KL dự tính / thực tế |
| SLMeDuTinh, SLMeHieuChinh, SLMeDaTron       | int?      | Số mẻ                |
| HopDongID, KhachHangID, CongTruongID, MACID | int?      | FK                   |
| Status                                      | int?      | PhieuTronStatus enum |
| IsQueued                                    | bool?     | Đã vào hàng đợi      |
| XeID, TaiXeID, NhanVienID                   | int?      |                      |
| MinKLTron, MaxKLTron, MaxKLXeCho            | decimal?  | Ràng buộc KL         |

### Các Obj\* quan trọng khác

| Class                      | File                     | Mô tả                                                       |
| -------------------------- | ------------------------ | ----------------------------------------------------------- |
| ObjMAC                     | Data/ObjMAC.cs           | Máy trộn (MACID, MaMAC, TenMAC, LstMACSilo, ThemBotNuoc1/2) |
| ObjMACSilo                 | Data/ObjMACSilo.cs       | Silo của MAC (MACSiloID, MACID, SiloID, SiloValue)          |
| ObjSilo                    | Data/ObjSilo.cs          | Định nghĩa silo (SiloID, MaSilo, TenSilo, material)         |
| ObjNhomSilo                | Data/ObjNhomSilo.cs      | Nhóm silo (Agg/Ce/Wa/Add)                                   |
| ObjMeTron                  | Data/ObjMeTron.cs        | Mẻ trộn                                                     |
| ObjMeTronChiTiet           | Data/ObjMeTronChiTiet.cs | Chi tiết mẻ (KL từng silo)                                  |
| ObjPhieuGiaoHang           | Data/ObjPhieuGiaoHang.cs | Phiếu giao hàng                                             |
| ObjKhachHang               | Data/ObjKhachHang.cs     | Khách hàng                                                  |
| ObjCongTruong              | Data/ObjCongTruong.cs    | Công trường                                                 |
| ObjHangMuc                 | Data/ObjHangMuc.cs       | Hạng mục                                                    |
| ObjMaterial                | Data/ObjMaterial.cs      | Vật liệu                                                    |
| ObjWeigh                   | Data/ObjWeigh.cs         | Cân                                                         |
| ObjXe                      | Data/ObjXe.cs            | Xe                                                          |
| ObjTaiXe                   | Data/ObjTaiXe.cs         | Tài xế                                                      |
| ObjNhanVien                | Data/ObjNhanVien.cs      | Nhân viên                                                   |
| ObjTimerPara               | Data/ObjTimerPara.cs     | Cấu hình timer PLC                                          |
| ObjEventLog                | Data/ObjEventLog.cs      | Log sự kiện                                                 |
| ObjVatTu                   | Data/ObjVatTu.cs         | Vật tư                                                      |
| SEC_User/Role/Function/... | Data/SEC\_\*.cs          | Bảo mật phân quyền                                          |

---

## 5. LỚP ENTITYMODEL (EF)

File context: `NDPSo/EntityModel/TramTromModel.Context.cs`

**DbContext class:** `DEPTramTronEntities`

**Connection string** (App.config line 33):

```
Server:   DESKTOP-7KUDOEF
Database: TramTron
User:     sa
EF:       6.0, Database-First, EDMX
MARS:     enabled
```

**Các DbSet chính (38 bảng + views):**

| DbSet             | Bảng DB          | Mục đích                |
| ----------------- | ---------------- | ----------------------- |
| DuLieuTrons       | DuLieuTron       | Dữ liệu trộn / đơn hàng |
| HopDongs          | HopDong          | Hợp đồng                |
| PhieuTrons        | PhieuTron        | Phiếu trộn              |
| PhieuGiaoHangs    | PhieuGiaoHang    | Phiếu giao hàng         |
| MeTrons           | MeTron           | Mẻ trộn                 |
| MeTronChiTiets    | MeTronChiTiet    | Chi tiết mẻ (KL silo)   |
| MACs              | MAC              | Máy trộn                |
| MACSilos          | MACSilo          | Silo của máy            |
| Silos             | Silo             | Silo vật liệu           |
| NhomSilos         | NhomSilo         | Nhóm silo               |
| KhachHangs        | KhachHang        | Khách hàng              |
| CongTruongs       | CongTruong       | Công trường             |
| HangMucs          | HangMuc          | Hạng mục                |
| Materials         | Material         | Vật liệu                |
| Weighs            | Weigh            | Cân                     |
| Xes               | Xe               | Xe                      |
| TaiXes            | TaiXe            | Tài xế                  |
| NhanViens         | NhanVien         | Nhân viên               |
| TimerParas        | TimerPara        | Timer PLC               |
| SEC_Users         | SEC_User         | User bảo mật            |
| SEC_Roles         | SEC_Role         | Vai trò                 |
| SEC_Functions     | SEC_Function     | Chức năng/quyền         |
| SEC_RoleFunctions | SEC_RoleFunction | Mapping role-function   |
| SEC_UserRoles     | SEC_UserRole     | Mapping user-role       |
| EventLogs         | EventLog         | Log hệ thống            |
| WeiSiloSavings    | WeiSiloSaving    | Lưu giá trị cân silo    |
| WeiSiloVisibles   | WeiSiloVisible   | Hiển thị cân silo       |
| TinhDoHutNuocs    | TinhDoHutNuoc    | Độ hút nước             |
| vw_DataMix        | view             | Dữ liệu trộn (view)     |
| vw_InfoPT         | view             | Thông tin phiếu trộn    |
| vw_SumWeight      | view             | Tổng KL (view)          |

---

## 6. LỚP DAL (REPOSITORY)

**Base class:** `EFRepository<T>` (Core/EFRepository.cs)

- `SelectAll(ISpecification<T> spec)` — lọc bằng Specification
- `Insert(T entity)`, `Update(T entity)`, `Delete(T entity)`
- `GetByKey(int id)`

**Specification pattern** (Core/Specification.cs):

```csharp
var spec = new Specification<DuLieuTron>(d => d.Status != 4);
var results = _repo.SelectAll(spec); // → EF Where()
```

**40+ Repository interfaces** (tất cả ở `NDPSo/DAL/I*Repository.cs`):

| Interface                | Implementation          | Bảng          |
| ------------------------ | ----------------------- | ------------- |
| IDuLieuTronRepository    | DuLieuTronRepository    | DuLieuTron    |
| IHopDongRepository       | HopDongRepository       | HopDong       |
| IPhieuTronRepository     | PhieuTronRepository     | PhieuTron     |
| IPhieuGiaoHangRepository | PhieuGiaoHangRepository | PhieuGiaoHang |
| IMeTronRepository        | MeTronRepository        | MeTron        |
| IMeTronChiTietRepository | MeTronChiTietRepository | MeTronChiTiet |
| IMACRepository           | MACRepository           | MAC           |
| IMACSiloRepository       | MACSiloRepository       | MACSilo       |
| ISiloRepository          | SiloRepository          | Silo          |
| IKhachHangRepository     | KhachHangRepository     | KhachHang     |
| ICongTruongRepository    | CongTruongRepository    | CongTruong    |
| ITimerParaRepository     | TimerParaRepository     | TimerPara     |
| ... (30+ khác)           |                         |               |

**IoC đăng ký** (Core/IoC.cs — Unity container):

```csharp
IoC.Register<IHopDongRepository, HopDongRepository>();
var repo = IoC.Retrieve<IHopDongRepository>();
```

---

## 7. LỚP BUSINESS LOGIC

### IMasterDataModel (Interface)

File: `NDPSo/MasterData/IMasterDataModel.cs`

Định nghĩa toàn bộ CRUD cho hệ thống:

- `ListDuLieuTron()`, `GetDLTByKey()`, `AddDuLieuTron()`, `UpdateDuLieuTron()`, `DeleteDuLieuTron()`
- `ListHopDong()`, `GetHopDongByKey()`, `AddHopDong()`, `UpdateHopDong()`
- `ListPhieuTron()`, `ListPhieuGiaoHang()`, `SaveMeTronChiTiet()`
- `ListMAC()`, `ListMACSilo()`, `ListSilo()`
- `ListKhachHang()`, `ListCongTruong()`, `ListHangMuc()`
- `ListNhanVien()`, `ListTaiXe()`, `ListXe()`
- `ListTimerPara()`, `ListWeiSiloSaving()`, `ListWeiSiloVisible()`

### TronOnlineDataPresenter

File: `NDPSo/MasterData/TronOnlineDataPresenter.cs`

Inherits: `MasterDataPresenter<ITronOnlineView>`

**Các method chính:**

```
ListDuLieuTron()           → _iView.BLstDuLieuTron
ListMAC()                  → _iView.BLstMAC
ListPhieuTron_ForTronOnline() → _iView.BLstPhieuTron
GetDLTByKey(id)            → ObjDuLieuTron
GetHopDongByKey(id)        → ObjHopDong
AddDuLieuTron(obj)         → ObjDuLieuTron (saved)
UpdateDuLieuTron(obj)      → ObjDuLieuTron (saved)
DeleteDulieuTron(id)       → void
CreateAndSaveNewPhieuTron(hd, isManual) → ObjPhieuTron
CreateAndSaveNewPhieuGiaoHang(...)      → ObjPhieuGiaoHang
BuildNewMeTron1(pt)        → ObjMeTron
BuildNewMeTronChiTiet(...) → ObjMeTronChiTiet (với KL tính toán)
```

### MasterDataPresenter<T> (Base)

File: `NDPSo/MasterData/MasterDataPresenter.cs`

```csharp
protected T _iView;
protected static IMasterDataModel _iMasterDataModel;
```

### ITronOnlineView (Interface cho VanHanh)

Properties mà VanHanh phải implement:

```csharp
BindingList<ObjDuLieuTron> BLstDuLieuTron { set; }
BindingList<ObjPhieuTron>  BLstPhieuTron  { set; }
BindingList<ObjMAC>        BLstMAC        { set; }
BindingList<ObjMACSilo>    BLstMACSilo    { set; }
BindingList<ObjNhanVien>   BLstNhanVien   { set; }
BindingList<ObjTaiXe>      BLstTaiXe      { set; }
BindingList<ObjXe>         BLstXe         { set; }
BindingList<ObjTimerPara>  BLstTimerPara  { set; }
// ...
```

---

## 8. FORM CHÍNH: VANHANH

Form `VanHanh` được chia thành **nhiều partial class**:

| File                     | Nội dung                                                   |
| ------------------------ | ---------------------------------------------------------- |
| `VanHanh.cs`             | Fields, Properties, Form Load/Close, khởi động PLC thread  |
| `VanHanh.Designer.cs`    | Tất cả controls UI (auto-generated)                        |
| `VanHanh.Grid.cs`        | Grid grcHopDong: CRUD, RowStyle, Sort, Context Menu        |
| `VanHanh.PLC.cs`         | Send setpoints DB3, đọc giá trị cân, cập nhật UI từ PLC    |
| `VanHanh.Commands.cs`    | Click handlers: btnRun, btnPause, btnHuy, 120+ van/động cơ |
| `VanHanh.Silo.cs`        | Quản lý KL + độ ẩm silo                                    |
| `VanHanh.LogicConfig.cs` | Cấu hình logic silo (tab Agg/Ce/Wa/Add)                    |
| `VanHanh.Printing.cs`    | In phiếu trộn, in nhanh                                    |
| `VanHanh.resx`           | Resources (strings, images)                                |

### 8.1 Fields quan trọng trong VanHanh.cs

```csharp
// Presenter & Services
TronOnlineDataPresenter _presenter
IServices _ser                          // từ ServiceFactories
PLCController _plcController

// PLC objects
ReceivingFromPLC _ro                    // dữ liệu đọc từ PLC
SendingToPLC _so                        // lệnh ghi xuống PLC
Thread _thread                          // thread polling PLC

// Binding lists
BindingList<ObjDuLieuTron> _blstDuLieuTron   // grcHopDong DataSource
BindingList<ObjPhieuTron>  _blstPhieuTron
BindingList<ObjMAC>        _blstMAC
BindingList<ObjMACSilo>    _blstMACSilo, _blstMACSilo_Run

// Selected objects
ObjHopDong  _selectedHD_Run
ObjPhieuTron _selectedPT_Run, _selectedPT_NextRun, _savingPT
ObjPhieuGiaoHang _selectedPGH_Run

// State flags
bool _Ready, _running, _isSimulation
bool _isRunNoiTron, _isRunBTX, _isRunBTC, _error
bool _isPrioritySort                    // chế độ sắp xếp CR

// Permissions
bool _CanEditDuLieuTron, _CanDeleteDuLieuTron, ...
List<ObjSEC_Function> _lstFunction

// Tham số vận hành
decimal _themBotNuoc, _giuNuocTenCan
decimal _LuyKe_InNhanh
int slMeCanTron

// Trạng thái silo (38 flags)
bool _previousCanDuAgg1State ... _previousCanDuAdd6State
```

### 8.2 BLstDuLieuTron setter — điểm bind chính

```csharp
// VanHanh.cs ~line 215
public BindingList<ObjDuLieuTron> BLstDuLieuTron
{
    set
    {
        // Sort: Cancelled (Status=3) kế cuối, Finished (Status=4) cuối cùng, rồi theo LnNo
        var sorted = value
            .OrderBy(d => d.Status == 4 ? 2 : d.Status == 3 ? 1 : 0)
            .ThenBy(d => d.LnNo)
            .ToList();
        this._blstDuLieuTron = new BindingList<ObjDuLieuTron>(sorted);
        this.grcHopDong.DataSource = this._blstDuLieuTron;
    }
}
```

### 8.3 Controls chính (VanHanh.Designer.cs)

**Grid:**

- `grcHopDong` (GridControl) + `grvHopDong` (GridView) — danh sách hợp đồng/DLT
- Events: `RowStyle`, `PopupMenuShowing`, `FocusedRowChanged`, `DoubleClick`

**Columns của grvHopDong:**
`gcLnNo, gcStatus, gcMaHopDong, gcNgayHopDong, gcKhachHang, gcCongTruong, gcMAC`
`gcDLT_KLDuTinh, gcDLT_KLDuTinhCuaTungMe, gcDLT_SLMeDuTinh`
`gcMACSUMSiloValue, gcKLDatHang, gcKLDaGiao, gcTongPhieuTron`
`gcThoiGianGiaoHang, gcTrangThaiGiaoHang`

**Custom Controls (UcBtn\*):**
| Control | Type | Chức năng |
|---------|------|-----------|
| `btnRun` | UcBtnRun | Chạy/dừng tiến trình trộn |
| `btnPause` | UcBtnPause | Tạm dừng |
| `btnHuy` | UcBtnHuyMe | Hủy mẻ |
| `btnReturn` | UcBtnReset | Reset |
| `btnThemMe, btnGiamMe` | UcBtnThem/Tru | Thêm/giảm số mẻ |
| `btnInNhanh` | UcBtnTru | In nhanh |
| `ucBtnMoPhong1` | UcBtnMoPhong | Chế độ mô phỏng |
| `ucHeThongAuto1` | UcHeThongAuto | Hệ thống tự động |

**Labels hiển thị thông tin hợp đồng:**
`lblMaPhieuTron, lblTenKhachHang, lblTenCongTruong, lblMAC`
`lblTenHangMuc, lblXe, lblDriver, lblDiaDiem, lblKhoiLuong, lblLuyKe`

**Tabs:**

- `tpgDLTron` — danh sách hợp đồng + thông tin
- `xtraTabPage1` — cấu hình logic Agg/Ce/Wa/Add (6+5+2+5 silos)

**Timer:** `timer1` (System.Windows.Forms.Timer) — chu kỳ cập nhật UI

### 8.4 VanHanh.Grid.cs — Logic quan trọng

#### Sắp xếp (DoTogglePrioritySort)

```
_isPrioritySort = false (mặc định):
  OrderBy(Status==4 ? 2 : Status==3 ? 1 : 0) → ThenBy(LnNo)
  ← Active đầu, Cancelled kế cuối, Finished cuối

_isPrioritySort = true (chế độ CR):
  OrderBy(Status==4 ? 3 : Status==3 ? 2 : Status==1 ? 0 : 1)  ← Running đầu, Cancelled kế cuối, Done cuối
  ThenBy(ThoiGianGiaoHang.HasValue ? 0 : 1)                    ← có deadline trước
  ThenBy(CriticalRatio ?? double.MaxValue)                       ← CR thấp = gấp nhất
```

#### Màu dòng (grvHopDong_RowStyle)

```
Status == 3 (Cancelled) → ColorCancelled (#FFB4B4 hồng) + ForeCancelled (#8C0000 đỏ đậm)  [ưu tiên 1]
Status == 4 (Finished)  → ColorDone (#D2D2D2 xám) + DimGray                                [ưu tiên 2]
Status == 1 (Running)   → ColorRunning (#B4FFB4 xanh lá)                                    [ưu tiên 3]
ThoiGianGiaoHang set    → BackColorByCR(cr): Đỏ/Vàng/Xanh                                  [ưu tiên 4]
```

#### Context Menu (grvHopDong_PopupMenuShowing)

- Tạo mới Hợp đồng → `DoCreateNewDuLieuTron`
- Chỉnh sửa Hợp đồng → `DoEditDuLieuTron`
- Tìm Hợp đồng đã tạo → `DoChangeDuLieuTron`
- Xóa dữ liệu trộn → `DoRemoveDuLieuTron`
- Đặt giờ giao hàng → `DoSetThoiGianGiaoHang`
- Toggle sắp xếp CR / mặc định → `DoTogglePrioritySort`

#### Disable btnRun cho Cancelled & Finished (FocusedRowChanged)
```csharp
private void grvHopDong_FocusedRowChanged_1(...)
{
    ObjDuLieuTron dlt = grvHopDong.GetRow(e.FocusedRowHandle) as ObjDuLieuTron;
    btnRun.Enabled = dlt?.Status != 4 && dlt?.Status != 3;  // không chạy lại Cancelled/Finished
    DoFocusHopDong();
}
```

### 8.5 VanHanh.Commands.cs — btnRun

```csharp
private void btnRun_ButtonClick(object sender, EventArgs e)
{
    if (btnRun.IsOn)   // nút đang ở trạng thái ON
    {
        // Xác nhận → F1_Run = true → SendData_DB2_NewTread() → InitRunning(true)
    }
    else
    {
        _so.SendingCommand.F1_Run = false;
        SendData_DB2_NewTread();
    }
}
```

**btnRun.Visible** được điều khiển bởi `_running`:

- `_running = true` → `btnRun.Visible = false`
- `_running = false` → `btnRun.Visible = true`

(Nguồn: VanHanh.cs ~line 1468–1474, đọc từ `_ro.Op_RUNNING`)

**120+ valve button handlers** trong Commands.cs theo pattern:

```csharp
private void btnVanXa_Agg1_ButtonMouseDown(...)
{
    _so.SendingCommand.SW_VAN_XA_COT_LIEU_AGG1 = true;
    SendData_DB2_NewTread();
}
private void btnVanXa_Agg1_ButtonMouseUp(...)
{
    _so.SendingCommand.SW_VAN_XA_COT_LIEU_AGG1 = false;
    SendData_DB2_NewTread();
}
```

Silo: 6 Agg + 5 Ce + 2 Wa + 5 Add = **18 silo vật liệu**

### 8.6 Ranking & Auto-Advance Logic (VanHanh.cs)

#### RefreshRankingDLT()
Sắp xếp lại toàn bộ `_blstDuLieuTron`, lưu DB, refresh grid:
```
1. active   = Status != 3 && Status != 4  → sort theo DLT_KLDuTinhCuaTungMe_NoiB (priority field)
2. cancelled = Status == 3               → giữ nguyên thứ tự LnNo cũ
3. done      = Status == 4               → giữ nguyên thứ tự LnNo cũ
merged = active + cancelled + done → renumber LnNo = 1..n
→ SaveDuLieuTron() → ListDuLieuTron() → grvHopDong sort by LnNo asc → FocusedRowHandle = 0
```

#### UpdateRankingDLT(dulieutron)
Đặt `dulieutron` làm ưu tiên cao nhất (priority = 1):
```
→ Set dulieutron.DLT_KLDuTinhCuaTungMe_NoiB = 1, others increment
→ Gọi RefreshRankingDLT()
```

#### AutoAdvanceAfterCancel()  *(thêm 2026-05-08)*
Sau khi hủy đơn, tự động chuyển sang đơn active tiếp theo:
```csharp
var next = _blstDuLieuTron
    .Where(d => d.Status != 3 && d.Status != 4)
    .OrderBy(d => d.DLT_KLDuTinhCuaTungMe_NoiB)
    .FirstOrDefault();
if (next != null) UpdateRankingDLT(next);
else RefreshRankingDLT();
```

#### DoHuy() → luồng hủy đơn  *(cập nhật 2026-05-08)*
```
F3 pressed → ChangeStatusSelectedDuLieuTron(3, null) → AutoAdvanceAfterCancel()
```

#### InitRunning() — các guard  *(cập nhật 2026-05-08)*
```
Status == 4 → cảnh báo "đã hoàn thành", return
Status == 3 → cảnh báo "đã bị hủy", return
```

---

## 9. GIAO TIẾP PLC

### Kiến trúc tổng quát

```
VanHanh._thread (Thread)
  └── PLCReadThread() — vòng lặp 200-500ms
        ├── PLCController.ReadStruct<T>(DB1, 0)  → _ro (ReceivingFromPLC)
        ├── PLCController.ReadStruct<T>(DB4, 0)
        ├── PLCController.ReadStruct<T>(DB6, 0)
        ├── PLCController.ReadStruct<T>(DB7, 0)
        └── PLCController.ReadStruct<T>(DB8, 0)

VanHanh.SendData_DB2_NewTread() — ghi lệnh
  └── Thread mới → PLCController.WriteStruct(_so, DB2, 0)
```

### PLCController.cs

File: `NDPSo/PLCModule/PLCController.cs`

```csharp
Plc _plc;                    // S7.Net instance
int mutexTime = 500;         // timeout mutex
int maxNumberErrorAccepted = 10;

Init()                       // kết nối TCP:102 theo GlobalValues.IP/Port/Rack/Slot
IsConnected                  // kiểm tra kết nối
ReConnectAsync()             // tái kết nối bất đồng bộ
WriteStruct(object, DB, addr) // ghi struct xuống PLC
WriteBytes(DataType, DB, addr, byte[])
ReadStruct<T>(DB, addr)      // đọc struct từ PLC
ReadBytes(DataType, DB, addr, count)
HandleException()            // tăng error counter, tái kết nối sau 10 lỗi
```

### ReceivingFromPLC.cs — Dữ liệu đọc từ PLC

File: `NDPSo/MasterData/ReceivingFromPLC.cs`

**DB1 — Đếm mẻ & tín hiệu:**

```
_SoMeTron              // số mẻ hiện tại
_SoMeCan_Agg1-6        // số mẻ đã cân AGG 1-6
_SoMeXa_Agg            // số mẻ đã xả
_CapPhoi_Agg1-3        // cấp phối
_KL_CanCan_Agg1-3      // KL cân đặt
_KL_ThucCan_Agg1-3     // KL thực tế
```

**DB4 — Giá trị cân:**

```
_XungCan_Agg/Ce/Wa     // xung cân (pulse)
_KL_Chinh_0            // KL chính hiện tại
_KL_ChinhTai           // KL chính trên cân
_KL_Thuc               // KL thực tế
_Per_KL_AGG/CE/WA      // % KL Agg/Ce/Wa
```

**DB6 — Tham số (timing/KL):**

```
_ThoiGianTreCan_Ce, _ThoiGianTreXa_Ce    // thời gian trễ cân/xả Xi
_KhoiLuongBaoRong_Ce                      // KL báo rỗng
_KhoiLuongRungCan_Ce                      // KL rung cân
(tương tự cho từng silo)
```

**DB7 — Trạng thái I/O (18 bytes × 8 bit = 144 bit):**

```
_statusIO_00 ... _statusIO_17   // raw byte (đọc từng bit trong VanHanh)
Op_RUNNING  (bit cụ thể)        // → điều khiển btnRun.Visible
Op_SIMULATION                   // → chế độ mô phỏng
```

**DB8 — Cờ báo cáo:**

```
_Save_Report   // PLC yêu cầu lưu báo cáo → trigger save MeTronChiTiet
```

### SendingCommand.cs — Lệnh ghi xuống PLC

File: `NDPSo/MasterData/SendingCommand.cs`

```
Byte_0:  F1_Run, F2_Pause, F3_Cancel, F4_MoPhong, SW_MAN_AUTO, ...
Byte_1:  RUA_NOI_TRON, NN_BAT_TAT_NOI_TRON, SW_XA_PHEU_CHO, ...
Byte_2-7: Van AGG (SW_VAN_XA_COT_LIEU_AGG1-6, NN_DONG/MO_KEP_AGG1-6)
Byte_8+:  Van CE, WA, ADD tương tự
```

### SendingToPLC.cs

File: `NDPSo/MasterData/SendingToPLC.cs`

Chuyển đổi `SendingCommand` → byte array → ghi DB2.
Property `Byte_0..Byte_24` tổng hợp bit → byte để truyền xuống PLC.

---

## 10. UTILS & HELPERS

### ScheduleColorHelper

File: `NDPSo/Utils/ScheduleColorHelper.cs`

```csharp
// Màu sắc chính
ColorRunning   = RGB(180, 255, 180)  // #B4FFB4 xanh lá  — đang chạy
ColorDone      = RGB(210, 210, 210)  // #D2D2D2 xám      — hoàn tất
ColorCancelled = RGB(255, 180, 180)  // #FFB4B4 hồng nhạt — đã hủy
ColorSwitch    = RGB(255, 230, 180)  // #FFE6B4 cam nhạt  — đang vệ sinh

ColorLate      = RGB(255, 100, 100)  // #FF6464 đỏ       — CR < 1.0 (trễ)
ColorSoonLate  = RGB(255, 230,  80)  // #FFE650 vàng     — CR 1.0-1.5
ColorOnTime    = RGB(200, 240, 200)  // #C8F0C8 xanh nhạt — CR > 1.5

ForeRunning    = RGB(  0, 110,   0)  // xanh đậm
ForeDone       = RGB(120, 120, 120)  // xám
ForeCancelled  = RGB(140,   0,   0)  // đỏ đậm
ForeLate       = White
ForeSoonLate   = RGB( 80,  60,   0)  // nâu đậm
ForeOnTime     = RGB(  0,  80,   0)

// Methods
BackColorByCR(double? cr) → Color   // trả màu nền theo CR
ForeColorByCR(double? cr) → Color   // trả màu chữ theo CR
```

### GlobalValues

File: `NDPSo/Utils/GlobalValues.cs`

```csharp
static int UserID                  // user đang đăng nhập
static string DisplayUser          // tên hiển thị
static string DisplayRole          // tên role
static string IP, Port, Rack, Slot // PLC connection
static bool PLCConnected           // trạng thái kết nối PLC
static bool ReconnectedPLCData     // cờ retry
static Messages messages           // string constants
```

### ConfigManager

File: `NDPSo/Utils/ConfigManager.cs`

```csharp
ConfigManager.TramTronConfig   // cấu hình app (IP PLC, ...)
ConfigManager.ServiceConfig    // cấu hình service (local/WCF)
```

### SmartRetryEngine

File: `NDPSo/Utils/SmartRetryEngine.cs` (thêm gần đây)

- Cơ chế retry thông minh cho các thao tác có thể thất bại (kết nối PLC, DB)

### Các Utils khác

| Class                        | File                        | Mục đích                    |
| ---------------------------- | --------------------------- | --------------------------- |
| TramTronLogger               | Utils/TramTronLogger.cs     | WriteInfo/Error/Warning     |
| TramTromMessageBox           | Utils/TramTromMessageBox.cs | Dialog chuẩn của hệ thống   |
| EncryptionHelper             | Utils/EncryptionHelper.cs   | Mã hóa/giải mã              |
| Converter                    | Utils/Converter.cs          | Enum↔List, BitArray, format |
| FormatToString               | Utils/FormatToString.cs     | Format string helper        |
| Validation                   | Utils/Validation.cs         | Validate input              |
| DirectoryMng                 | Utils/DirectoryMng.cs       | Quản lý file/folder         |
| HelpperExport, SupportExport | Utils/                      | Export Excel/report         |
| SetPoint                     | Utils/                      | Dung sai KL và setpoint cân |
| TronOnlineAttributes         | Utils/                      | Thuộc tính vận hành online  |
| MappingHelper                | PLCMapping/MappingHelper.cs | float → 4 bytes cho PLC     |

---

## 11. CÁC FORM/VIEW PHỤ

| Form              | File                            | Chức năng                  |
| ----------------- | ------------------------------- | -------------------------- |
| NewHopDongView    | MasterData/NewHopDongView.cs    | Tạo/Sửa hợp đồng           |
| NewDuLieuTronView | MasterData/NewDuLieuTronView.cs | Tạo/Sửa/View DLT           |
| UcSearchHopDong   | MasterData/UcSearchHopDong.cs   | Tìm kiếm hợp đồng          |
| TimerParaMngView  | MasterData/TimerParaMngView.cs  | Quản lý timer PLC          |
| Administration/\* | Administration/                 | Quản lý User/Role/Function |
| Reports/\*        | Reports/                        | Báo cáo thống kê           |

**ViewManager** (helper mở form):

```csharp
ViewManager.ShowViewDialog(ctrView);  // hiển thị modal
ctrView.GetDialogResult()             // lấy kết quả
ctrView.GetSavedHopDong()             // lấy đối tượng đã lưu
```

---

## 12. CHATBOT AI

File: `NDPSo/Chatbot/ChatbotOrchestrator.cs`

- Tích hợp Groq API và OpenAI API
- `DatabaseSchema.cs` — ánh xạ schema DB sang mô tả cho AI
- `IntentDetector.cs` — phát hiện ý định người dùng
- Hỏi đáp tự nhiên về dữ liệu hệ thống (số liệu trộn, giao hàng, ...)

---

## 13. LUỒNG DỮ LIỆU CHÍNH

### 13.1 Load dữ liệu khởi động

```
Form.Load
  → _presenter.ListDuLieuTron()
  → IMasterDataModel.ListDuLieuTron(includeInActivated: true)
  → IDuLieuTronRepository.SelectAll(spec)
  → EF: DEPTramTronEntities.DuLieuTrons.Where(...)
  → SQL Server [TramTron].[dbo].[DuLieuTron]
  → BindingList<ObjDuLieuTron>
  → VanHanh.BLstDuLieuTron setter
    → Sort: Finished xuống cuối, ThenBy LnNo
    → grcHopDong.DataSource = _blstDuLieuTron
    → grvHopDong hiển thị
```

### 13.2 Chu kỳ đọc PLC (realtime)

```
Thread (_thread):
  loop (200–500ms):
    PLCController.ReadStruct(DB1) → _ro cập nhật SoMeTron, batch counts
    PLCController.ReadStruct(DB4) → _ro cập nhật weight values
    PLCController.ReadStruct(DB7) → _ro cập nhật status IO bits
    PLCController.ReadStruct(DB8) → _ro._Save_Report

    UI update (Invoke):
      lblSoPhieuTron.Text = _ro._SoMeTron
      các cân/đồng hồ cập nhật
      _running = _ro.Op_RUNNING
      btnRun.Visible = !_running

    if (_ro._Save_Report):
      SaveMeTronChiTiet() → DB
      Reset _Save_Report
```

### 13.3 Luồng Chạy Trộn (btnRun → PLC → DB)

```
1. User focus vào dòng DLT (Status != 4)
   → grvHopDong_FocusedRowChanged
   → btnRun.Enabled = true
   → DoFocusHopDong() → load thông tin HD lên labels

2. User click btnRun (IsOn = true)
   → Confirm dialog
   → SendingCommand.F1_Run = true
   → SendData_DB2_NewTread()
   → PLCController.WriteBytes(DB2, byte[])
   → InitRunning(true)
   → ChangeStatusSelectedDuLieuTron(1, null)  ← Status = Running

3. PLC thực thi (hardware):
   → Feed material (Agg/Ce/Wa/Add theo setpoint)
   → Weigh → Mix → Discharge
   → Cập nhật DB1 (batch counts), DB4 (weights), DB7 (status)

4. Poll vòng lặp đọc kết quả:
   → _ro._SoMeCan_Agg1++ khi PLC cân xong 1 mẻ
   → _ro._KL_ThucCan_Agg1 = KL thực tế
   → UI cập nhật realtime

5. Khi _ro._Save_Report = true:
   → Tạo ObjMeTronChiTiet với KL thực tế từng silo
   → _presenter.SaveMeTronChiTiet(...)
   → Cập nhật PhieuTron.SLMeDaTron++

6. Hoàn thành (SLMeDaTron >= SLMeDuTinh):
   → ChangeStatusSelectedDuLieuTron(4, null)  ← Status = Finished
   → btnRun tự disable cho dòng này
   → Dòng chuyển màu xám trong grid
   → Auto-print nếu checkAutoPrint.Checked
```

---

## 14. ENUMS TOÀN BỘ

File: `NDPSo/Utils/Enums.cs`

```csharp
DuLieuTronStatus:   New=0, Running=1, Pause=2, Abort=3, Finished=4
HopDongStatus:      New=0, InProcess=1, Cancel=2, Close=3, Completed=4
PhieuTronStatus:    New=0, Cancel=1, Waiting=2, InProcess=3, Failed=4, Finished=5
MeTronStatus:       Mixing, Failed, Finished
SiloType:           Agg, Ce, Wa, Add
FormAction:         New, Edit, View
ActiveEnum:         Active=1, Deactive=0
SimMode:            Sim=1, Normal=0
RunningMode:        StandAlone, Service
Unit:               Kg, ml, m3
LanguageRes:        English=0, Vietnamese=1
MsgType:            Error, Info, Warning
TronProcess:        S00_None→S05_XaNoiTron (6 bước)
TronOnlineCommand:  Run, Pause, Stop, CancelAgg, CancelCe, ...
TronOnlineState:    Step0..Step6
S7Connector.CPUType:    S7200, S7300, S7400, S71200
S7Connector.DataType:   Input=129, Output, Marker, DataBlock, Timer=29, Counter=28
S7Connector.VarType:    Bit, Byte, Word, DWord, Int, DInt, Real, String, Timer, Counter
WeiSiloType:        Silo=1, Wei=11
```

---

## 15. MÀU SẮC GRID & CR

### Bảng màu hoàn chỉnh

| Điều kiện                | BackColor         | ForeColor        | Ưu tiên      |
| ------------------------ | ----------------- | ---------------- | ------------ |
| Status == 3 (Cancelled)  | #FFB4B4 hồng nhạt | #8C0000 đỏ đậm   | 1 (cao nhất) |
| Status == 4 (Finished)   | #D2D2D2 xám       | DimGray          | 2            |
| Status == 1 (Running)    | #B4FFB4 xanh lá   | #006E00 xanh đậm | 3            |
| CR < 1.0 (Trễ)           | #FF6464 đỏ        | White            | 4            |
| 1.0 ≤ CR < 1.5 (Sắp trễ) | #FFE650 vàng      | #503C00 nâu      | 4            |
| CR ≥ 1.5 (Đúng hạn)      | #C8F0C8 xanh nhạt | #005000 xanh đậm | 4            |
| Không có deadline        | (mặc định)        | (mặc định)       | —            |

### Critical Ratio (CR) formula

```
CR = (ThoiGianGiaoHang - DateTime.Now).TotalHours
   / (DLT_SLMeDuTinh × 5 ÷ 60)

Ý nghĩa:
CR < 1.0  → TRỄ (thời gian còn lại ít hơn thời gian cần)
CR 1.0-1.5 → SẮP TRỄ
CR > 1.5  → AN TOÀN
```

---

## 16. QUICK REFERENCE FILES

| Thành phần           | File                                          |
| -------------------- | --------------------------------------------- |
| Main Form            | `NDPSo/MasterData/VanHanh.cs`                 |
| Form Designer        | `NDPSo/MasterData/VanHanh.Designer.cs`        |
| Grid/CRUD/Sort/Color | `NDPSo/MasterData/VanHanh.Grid.cs`            |
| PLC Read/Write       | `NDPSo/MasterData/VanHanh.PLC.cs`             |
| Button Handlers      | `NDPSo/MasterData/VanHanh.Commands.cs`        |
| In ấn                | `NDPSo/MasterData/VanHanh.Printing.cs`        |
| Presenter            | `NDPSo/MasterData/TronOnlineDataPresenter.cs` |
| Interface Model      | `NDPSo/MasterData/IMasterDataModel.cs`        |
| Interface View       | `NDPSo/MasterData/ITronOnlineView.cs`         |
| DTO chính            | `NDPSo/Data/ObjDuLieuTron.cs`                 |
| DTO hợp đồng         | `NDPSo/Data/ObjHopDong.cs`                    |
| DTO phiếu trộn       | `NDPSo/Data/ObjPhieuTron.cs`                  |
| DTO MAC/Silo         | `NDPSo/Data/ObjMAC.cs`, `ObjMACSilo.cs`       |
| Enums                | `NDPSo/Utils/Enums.cs`                        |
| EF Context           | `NDPSo/EntityModel/TramTromModel.Context.cs`  |
| PLC Controller       | `NDPSo/PLCModule/PLCController.cs`            |
| PLC Receive          | `NDPSo/MasterData/ReceivingFromPLC.cs`        |
| PLC Send             | `NDPSo/MasterData/SendingToPLC.cs`            |
| PLC Commands         | `NDPSo/MasterData/SendingCommand.cs`          |
| IoC Container        | `NDPSo/Core/IoC.cs`                           |
| Colors               | `NDPSo/Utils/ScheduleColorHelper.cs`          |
| Global State         | `NDPSo/Utils/GlobalValues.cs`                 |
| Config               | `NDPSo/Utils/ConfigManager.cs`                |
| DB Connection        | `NDPSo/App.config` (line 33)                  |
| SmartRetry           | `NDPSo/Utils/SmartRetryEngine.cs`             |
| Chatbot              | `NDPSo/Chatbot/ChatbotOrchestrator.cs`        |
| TonKho Service       | `NDPSo/MasterData/TonKho/TonKhoService.cs`    |
| TonKho UI            | `NDPSo/MasterData/TonKho/TonKhoView.cs`       |
| NVL Monitor Design   | `NVL_Monitor_Dev.md` (tài liệu thiết kế)      |

---

---

## 17. MODULE TỒN KHO (TONKHO)

### 17.1 Files hiện có

```
NDPSo/MasterData/TonKho/
  ├── TonKhoService.cs        ← Service CRUD (ADO.NET, không qua EF)
  ├── TonKhoView.cs           ← UI màn hình tồn kho (2 grid: Tồn + Nhu cầu)
  ├── TonKhoView.Designer.cs
  ├── NhapKhoDialog.cs        ← Dialog nhập kho
  └── NhapKhoDialog.Designer.cs

SQL/
  ├── create_tonkho_tables.sql   ← TonKho + NhapKho + XuatKho tables + 2 views
  └── sp_tonkho_operations.sql   ← sp_NhapKho, sp_XuatKho_TuDong, sp_KiemTra_TonKho_DuLieuTron
```

### 17.2 Database schema

```
TonKho   (TonKhoID PK, SiloID FK UNIQUE, MaterialID FK,
          SoLuongTon decimal(18,2), MucCanhBao decimal(18,2))

NhapKho  (NhapKhoID PK, MaPhieuNhap, SiloID FK, MaterialID FK,
          SoLuongNhap, NhaCungCap, NgayNhap, SoHoaDon, IsApplied, CreatedBy)

XuatKho  (XuatKhoID PK, SiloID FK, MaterialID FK, SoLuongXuat,
          MeTronID, PhieuTronID, DuLieuTronID, NgayXuat, CreatedBy)
```

### 17.3 Công thức nhu cầu NVL

```
Nhu cầu (kg) = ObjDuLieuTron.DLT_SLMeDuTinh × ObjMACSilo.SiloValue
```

### 17.4 TonKhoService methods

| Method                            | Mô tả                                             |
| --------------------------------- | ------------------------------------------------- |
| `LoadTonKho()`                    | Tồn theo silo → `List<ObjTonKhoRow>`              |
| `KiemTraNhuCau()`                 | Tổng nhu cầu vs tồn → `List<ObjKiemTraTonKho>`    |
| `NhapKho(siloID, soLuong, ...)`   | Nhập kho, gọi sp_NhapKho                          |
| `XuatKhoTuDong(meTronID, ...)`    | Xuất tự động khi mẻ xong                          |
| `UpdateMucCanhBao(tonKhoID, muc)` | Cập nhật ngưỡng cảnh báo                          |
| `DemCanhBao()`                    | Tuple (HetKho, CanhBao) — số silo theo trạng thái |

### 17.5 NVL Monitor Engine (ĐANG PHÁT TRIỂN)

> Xem chi tiết thiết kế: `NVL_Monitor_Dev.md`

**Mục tiêu:** Background engine chạy mỗi 60s, giả lập tuần tự 10 đơn hàng tiếp theo, cảnh báo nếu thiếu NVL.

**Files sẽ tạo:**

```
NDPSo/MasterData/TonKho/Monitor/
  ├── NVLMonitorResult.cs    ← DTOs: NVLShortage, NVLOrderFeasibility, NVLAlertLevel
  ├── NVLSimulation.cs       ← Thuật toán greedy sequential simulation
  ├── NVLMonitorEngine.cs    ← System.Threading.Timer + event raising
  └── NVLMonitorPanel.cs     ← UI popup kết quả
```

**Tích hợp:** `VanHanh.cs` — thêm `_nvlMonitor` field, Start/Stop lifecycle, `lblNVLStatus` label.

---

_Tài liệu này được tổng hợp từ phân tích toàn bộ mã nguồn. Cập nhật khi có thay đổi kiến trúc lớn._

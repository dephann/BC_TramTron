# NVL Monitor — Tài Liệu Phát Triển
## Giám Sát & Dự Báo Nguyên Vật Liệu Tự Động

> Phiên bản: v1.0 — 2026-05-08  
> Cập nhật tài liệu này mỗi khi thay đổi thiết kế hoặc hoàn thành một phase.

---

## MỤC LỤC

1. [Tổng quan tính năng](#1-tổng-quan-tính-năng)
2. [Hiện trạng module TonKho](#2-hiện-trạng-module-tonkho)
3. [Khoảng trống — cần xây thêm](#3-khoảng-trống--cần-xây-thêm)
4. [Kiến trúc NVLMonitorEngine](#4-kiến-trúc-nvlmonitorengine)
5. [Thuật toán giả lập tuần tự](#5-thuật-toán-giả-lập-tuần-tự)
6. [DTOs kết quả](#6-dtos-kết-quả)
7. [Tích hợp vào VanHanh form](#7-tích-hợp-vào-vanhanh-form)
8. [UI đề xuất — NVLMonitorPanel](#8-ui-đề-xuất--nvlmonitorpanel)
9. [Kế hoạch triển khai (3 phase)](#9-kế-hoạch-triển-khai-3-phase)
10. [Hiệu năng & thread safety](#10-hiệu-năng--thread-safety)
11. [Các file cần tạo/sửa](#11-các-file-cần-tạosửa)

---

## 1. TỔNG QUAN TÍNH NĂNG

### Mục tiêu

Xây dựng một **engine chạy nền** (không ảnh hưởng hiệu năng trộn), liên tục:

| Chức năng | Mô tả |
|-----------|-------|
| **Giám sát tồn kho** | Đọc TonKho định kỳ (60s), phát hiện ngưỡng nguy hiểm |
| **Giả lập tuần tự** | Mô phỏng việc thực thi 10 đơn hàng tiếp theo → biết tồn kho tiêu hao sau mỗi đơn |
| **Đánh giá khả thi** | Từng đơn: CÓ THỂ / THIẾU X (materialname, cần Ykg còn Zkg) |
| **Phát hiện đơn gấp** | Phát hiện đơn có CR thấp mà lại thiếu NVL → cảnh báo ngay |
| **Khuyến nghị** | Đề xuất thứ tự đơn phù hợp nhất với tồn kho hiện tại |
| **Cảnh báo kịp thời** | Noti trên VanHanh form khi alert level thay đổi |

### Triết lý thiết kế

- **Chỉ đọc** — engine không ghi DB, không thay đổi dữ liệu thật
- **Tách biệt** — không phụ thuộc vào PLC thread, không share state với trộn
- **Nhẹ** — chạy ở `ThreadPriority.BelowNormal`, query SQL đơn giản
- **Event-driven** — kết quả trả qua `event`, UI quyết định hiển thị gì

---

## 2. HIỆN TRẠNG MODULE TONKHO

### 2.1 Files đã có

| File | Mô tả |
|------|-------|
| `NDPSo/MasterData/TonKho/TonKhoService.cs` | Service CRUD tồn kho |
| `NDPSo/MasterData/TonKho/TonKhoView.cs` | UI màn hình tồn kho |
| `NDPSo/MasterData/TonKho/TonKhoView.Designer.cs` | Designer UI |
| `NDPSo/MasterData/TonKho/NhapKhoDialog.cs` | Dialog nhập kho |
| `NDPSo/MasterData/TonKho/NhapKhoDialog.Designer.cs` | Designer dialog |
| `SQL/create_tonkho_tables.sql` | Schema: TonKho, NhapKho, XuatKho + 2 views |
| `SQL/sp_tonkho_operations.sql` | sp_NhapKho, sp_XuatKho_TuDong, sp_KiemTra_TonKho_DuLieuTron |

### 2.2 Schema database

```
TonKho (TonKhoID, SiloID [FK], MaterialID [FK], SoLuongTon decimal(18,2), 
        MucCanhBao decimal(18,2), GhiChu, LatestUpdateDate, LatestUpdatedBy)
  UNIQUE(SiloID)  -- 1 silo = 1 dòng

NhapKho (NhapKhoID, MaPhieuNhap, SiloID, MaterialID, SoLuongNhap,
         NhaCungCap, NgayNhap, SoHoaDon, IsApplied, CreatedBy)

XuatKho  (XuatKhoID, SiloID, MaterialID, SoLuongXuat,
          MeTronID, PhieuTronID, DuLieuTronID, NgayXuat, CreatedBy)
```

**Views có sẵn:**
- `vw_TonKhoTongHop` — tồn + nhập/xuất 7 ngày
- `vw_NhuCauNVL_DuLieuTron` — nhu cầu NVL cho từng DLT đang chờ

### 2.3 TonKhoService — các method đã có

```csharp
LoadTonKho()                         // List<ObjTonKhoRow> — tồn theo silo
KiemTraNhuCau()                      // List<ObjKiemTraTonKho> — tổng nhu cầu vs tồn
GetSiloList()                        // DataTable — danh sách silo (cho dropdown)
NhapKho(siloID, soLuong, ...)        // nhập kho + gọi sp_NhapKho
XuatKhoTuDong(meTronID, ...)         // xuất tự động khi mẻ xong
XuatKhoTheoPhieuTron(phieuTronID, .) // xuất theo phiếu trộn
UpdateMucCanhBao(tonKhoID, mucCB)    // cập nhật ngưỡng cảnh báo
DemCanhBao()                         // (int HetKho, int CanhBao) tuple
```

### 2.4 Công thức tính nhu cầu NVL (đã có)

```
Nhu cầu (kg) = DuLieuTron.DLT_SLMeDuTinh × MACSilo.SiloValue
```
- `DLT_SLMeDuTinh` — số mẻ dự kiến của đơn hàng
- `MACSilo.SiloValue` — kg vật liệu mỗi mẻ từ silo này (theo cấu hình MAC)

### 2.5 DTOs đã có

```csharp
ObjTonKhoRow    { SiloID, MaSilo, TenSilo, MaterialName, SoLuongTon, 
                  MucCanhBao, TrangThaiID[0=Hết/1=CB/2=Đủ] }

ObjKiemTraTonKho { MaterialName, MaSilo, TonHienTai, TongCanDung,
                   ChenhLech, MucCanhBao, TrangThaiID }
```

---

## 3. KHOẢNG TRỐNG — CẦN XÂY THÊM

| Thiếu | Mô tả |
|-------|-------|
| **Giả lập tuần tự** | `KiemTraNhuCau()` hiện tính TỔNG tất cả đơn đang chờ. Chưa có: "chạy A → còn lại cho B → còn lại cho C..." |
| **Next N orders** | Chưa có cơ chế lấy 10 đơn tiếp theo theo thứ tự ưu tiên (CR-based) |
| **Chạy nền** | Chưa có timer/thread giám sát định kỳ |
| **Event alert** | Chưa có cơ chế push thông báo lên VanHanh form |
| **Khuyến nghị** | Chưa có logic đề xuất thứ tự chạy phù hợp tồn kho |
| **Đơn gấp + thiếu NVL** | Chưa có phát hiện giao điểm "CR thấp & thiếu NVL" |

---

## 4. KIẾN TRÚC NVLMONITORENGINE

### 4.1 Tổng quan

```
VanHanh form (UI Thread)
    │
    ├─ khởi động: _nvlMonitor.Start(intervalSec: 60)
    │
    └─ subscribe: _nvlMonitor.AlertLevelChanged += OnNVLAlertChanged
                  _nvlMonitor.ResultUpdated     += OnNVLResultUpdated

NVLMonitorEngine (System.Threading.Timer — BelowNormal)
    │
    ├── RunCheck()
    │     ├── LoadInventorySnapshot()    → Dictionary<SiloID, kg>
    │     ├── LoadPendingOrdersSorted()  → List<ObjDuLieuTron> (CR order)
    │     ├── LoadAllMACSilos()          → List<ObjMACSilo>
    │     │
    │     └── NVLSimulation.Simulate()  → List<NVLOrderFeasibility>
    │               │
    │               └── Kết quả: NVLMonitorResult
    │
    └── raise events → VanHanh.Invoke() → cập nhật UI
```

### 4.2 Namespace

```
NDPSo.MasterData.TonKho.Monitor
```

### 4.3 Thư mục file mới

```
NDPSo/MasterData/TonKho/Monitor/
  ├── NVLMonitorEngine.cs     ← Engine chính (timer, orchestration)
  ├── NVLSimulation.cs        ← Thuật toán giả lập tuần tự
  └── NVLMonitorResult.cs     ← DTOs kết quả
```

---

## 5. THUẬT TOÁN GIẢ LẬP TUẦN TỰ

### Ý tưởng

Thay vì hỏi "tổng NVL của tất cả đơn có đủ không?", ta hỏi:
> "Nếu chạy đơn #1 trước, NVL còn lại có đủ cho đơn #2? Sau đó còn cho đơn #3?"

Đây là **greedy sequential simulation** — đơn giản, nhanh, O(n×k) với n = số đơn, k = số silo.

### Pseudocode

```
Input:
  - orderedOrders: List<DuLieuTron>  (đã sort theo CR hoặc LnNo)
  - inventory: Dict<SiloID, kg>      (snapshot tồn kho hiện tại)
  - macSilos: List<ObjMACSilo>
  - maxOrders: int = 10

virtualInventory = copy(inventory)  // KHÔNG sửa tồn thật

for order in orderedOrders.Take(maxOrders):
    needs = CalculateNeeds(order, macSilos)
    // needs = Dict<SiloID, kg> = DLT_SLMeDuTinh × SiloValue

    shortages = []
    for (siloID, kgNeeded) in needs:
        available = virtualInventory[siloID] ?? 0
        if available < kgNeeded:
            shortages.Add({ siloID, kgNeeded, available, deficit: kgNeeded - available })

    result = NVLOrderFeasibility {
        order = order,
        CoThe = (shortages.Count == 0),
        Shortages = shortages,
        IsUrgent = (order.CriticalRatio < 1.5 && shortages.Count > 0)
    }

    if CoThe:
        // Trừ tồn ảo — cho đơn tiếp theo biết
        for (siloID, kgNeeded) in needs:
            virtualInventory[siloID] -= kgNeeded

    results.Add(result)

Output:
  - results: List<NVLOrderFeasibility>
  - projectedInventory: Dict<SiloID, kg>  (tồn ảo sau khi chạy hết 10 đơn)
```

### Ví dụ kết quả (10 đơn)

```
Đơn #1 HD-001  CÁT Silo1: 5000kg cần, 8000kg còn → ĐỦ   ✓ CÓ THỂ
Đơn #2 HD-002  ĐÁ  Silo3: 7200kg cần, 6000kg còn → ⚠ THIẾU 1200kg  [GẤPO (CR=1.1)]
Đơn #3 HD-003  XM  Silo5: 3000kg cần, 3500kg còn → ĐỦ   ✓ CÓ THỂ
...
Đơn #10 HD-010  ...
```

---

## 6. DTOs KẾT QUẢ

### NVLShortage

```csharp
// NDPSo/MasterData/TonKho/Monitor/NVLMonitorResult.cs

public class NVLShortage
{
    public int     SiloID       { get; set; }
    public string  MaSilo       { get; set; }
    public string  MaterialName { get; set; }
    public decimal CanDung      { get; set; }  // kg cần
    public decimal HienCon      { get; set; }  // kg còn trong tồn ảo
    public decimal ThieuHut => CanDung - HienCon;  // kg thiếu
}
```

### NVLOrderFeasibility

```csharp
public class NVLOrderFeasibility
{
    public int               DuLieuTronID     { get; set; }
    public string            MaHopDong        { get; set; }
    public string            KhachHang        { get; set; }
    public decimal?          DLT_SLMeDuTinh   { get; set; }  // số mẻ
    public DateTime?         ThoiGianGiaoHang { get; set; }
    public double?           CriticalRatio    { get; set; }

    public bool              CoThe            { get; set; }  // có thể chạy không
    public List<NVLShortage> Shortages        { get; set; } = new List<NVLShortage>();

    // Đơn gấp mà thiếu NVL → cần cảnh báo ngay
    public bool IsUrgent => !CoThe && (CriticalRatio.HasValue && CriticalRatio < 1.5);

    public string TomTat => CoThe
        ? "✓ Đủ NVL"
        : $"⚠ Thiếu {string.Join(", ", Shortages.Select(s => $"{s.MaterialName} {s.ThieuHut:N0}kg"))}";
}
```

### NVLAlertLevel (enum)

```csharp
public enum NVLAlertLevel
{
    OK         = 0,  // Tất cả đơn trong 10 đơn tới đều đủ NVL
    Warning    = 1,  // Có đơn không gấp bị thiếu NVL
    Critical   = 2,  // Có đơn GẤPO (CR<1.5) bị thiếu NVL
    StockOut   = 3   // Có silo hết kho
}
```

### NVLMonitorResult

```csharp
public class NVLMonitorResult
{
    public DateTime                  CheckTime          { get; set; }
    public List<NVLOrderFeasibility> Feasibilities      { get; set; }
    public NVLAlertLevel             AlertLevel         { get; set; }

    // Tồn kho ảo sau khi giả lập xong 10 đơn
    public Dictionary<int, decimal>  ProjectedInventory { get; set; }

    // Đơn gấp nhất bị thiếu NVL (để hiển thị trong thông báo nhanh)
    public NVLOrderFeasibility MostUrgentShortage =>
        Feasibilities?.Where(f => !f.CoThe)
                       .OrderBy(f => f.CriticalRatio ?? double.MaxValue)
                       .FirstOrDefault();

    // Text tóm tắt cho status bar
    public string StatusBarText
    {
        get
        {
            if (AlertLevel == NVLAlertLevel.OK)
                return $"NVL ✓ Đủ cho {Feasibilities?.Count ?? 0} đơn tới";
            int shortCount = Feasibilities?.Count(f => !f.CoThe) ?? 0;
            int urgentCount = Feasibilities?.Count(f => f.IsUrgent) ?? 0;
            return urgentCount > 0
                ? $"NVL ⚠ {urgentCount} đơn GẤPO thiếu NVL!"
                : $"NVL ⚠ {shortCount} đơn thiếu NVL";
        }
    }
}
```

---

## 7. TÍCH HỢP VÀO VANHANH FORM

### 7.1 NVLMonitorEngine — skeleton

```csharp
// NDPSo/MasterData/TonKho/Monitor/NVLMonitorEngine.cs

public class NVLMonitorEngine : IDisposable
{
    private System.Threading.Timer _timer;
    private readonly string        _connStr;
    private NVLAlertLevel          _lastAlertLevel = NVLAlertLevel.OK;
    private bool                   _running = false;

    public event EventHandler<NVLMonitorResult> ResultUpdated;
    public event EventHandler<NVLAlertLevel>    AlertLevelChanged;

    public NVLMonitorResult LastResult { get; private set; }

    public NVLMonitorEngine()
    {
        var sc = ConfigManager.ServiceConfig;
        _connStr = BuildConnStr(sc);
    }

    public void Start(int intervalSeconds = 60)
    {
        _timer = new System.Threading.Timer(
            _ => SafeRunCheck(),
            null,
            TimeSpan.Zero,                          // chạy ngay lần đầu
            TimeSpan.FromSeconds(intervalSeconds));
    }

    public void Stop() => _timer?.Change(Timeout.Infinite, Timeout.Infinite);

    public void ForceRefresh() => SafeRunCheck();

    private void SafeRunCheck()
    {
        if (_running) return;  // bỏ qua nếu lần trước chưa xong
        _running = true;
        try
        {
            System.Threading.Thread.CurrentThread.Priority =
                System.Threading.ThreadPriority.BelowNormal;
            RunCheck();
        }
        catch (Exception ex) { TramTronLogger.WriteError(ex); }
        finally { _running = false; }
    }

    private void RunCheck()
    {
        var inventory = LoadInventorySnapshot();       // Dict<SiloID, kg>
        var orders    = LoadPendingOrdersSorted();     // List<ObjDuLieuTron> (CR-sorted)
        var macSilos  = LoadAllMACSilos();             // List<ObjMACSilo>

        var sim = new NVLSimulation();
        var feasibilities = sim.Simulate(orders, inventory, macSilos, maxOrders: 10);

        var alertLevel = CalcAlertLevel(feasibilities);

        var result = new NVLMonitorResult
        {
            CheckTime     = DateTime.Now,
            Feasibilities = feasibilities,
            AlertLevel    = alertLevel,
            ProjectedInventory = sim.LastProjectedInventory
        };

        LastResult = result;
        ResultUpdated?.Invoke(this, result);

        if (alertLevel != _lastAlertLevel)
        {
            _lastAlertLevel = alertLevel;
            AlertLevelChanged?.Invoke(this, alertLevel);
        }
    }

    private static NVLAlertLevel CalcAlertLevel(List<NVLOrderFeasibility> list)
    {
        if (list.Any(f => f.IsUrgent))   return NVLAlertLevel.Critical;
        if (list.Any(f => !f.CoThe))     return NVLAlertLevel.Warning;
        return NVLAlertLevel.OK;
    }

    public void Dispose() => _timer?.Dispose();
}
```

### 7.2 Thêm vào VanHanh.cs

```csharp
// Thêm field (cùng chỗ với _thread, _ro, _so):
private NVLMonitorEngine _nvlMonitor;

// Trong VanHanh_Load (sau khi khởi động PLC thread):
_nvlMonitor = new NVLMonitorEngine();
_nvlMonitor.AlertLevelChanged += OnNVLAlertLevelChanged;
_nvlMonitor.Start(intervalSeconds: 60);

// Trong VanHanh_FormClosed:
_nvlMonitor?.Stop();
_nvlMonitor?.Dispose();

// Handler nhận kết quả (phải Invoke vì từ background thread):
private void OnNVLAlertLevelChanged(object sender, NVLAlertLevel level)
{
    if (InvokeRequired)
    {
        BeginInvoke(new Action(() => OnNVLAlertLevelChanged(sender, level)));
        return;
    }
    UpdateNVLStatusBar(level);
}

private void UpdateNVLStatusBar(NVLAlertLevel level)
{
    switch (level)
    {
        case NVLAlertLevel.OK:
            lblNVLStatus.Text = "NVL ✓";
            lblNVLStatus.ForeColor = Color.Green;
            break;
        case NVLAlertLevel.Warning:
            lblNVLStatus.Text = "NVL ⚠ Có đơn thiếu";
            lblNVLStatus.ForeColor = Color.OrangeRed;
            break;
        case NVLAlertLevel.Critical:
            lblNVLStatus.Text = "NVL ⚠ Đơn gấp thiếu NVL!";
            lblNVLStatus.ForeColor = Color.Red;
            // Thêm âm thanh cảnh báo nếu cần:
            // SystemSounds.Exclamation.Play();
            break;
    }
}
```

### 7.3 Button "Chi tiết NVL" — mở popup

```csharp
// Nút này trong VanHanh toolbar (thêm vào Designer)
private void btnNVLDetail_Click(object sender, EventArgs e)
{
    var result = _nvlMonitor?.LastResult;
    if (result == null)
    {
        MessageBox.Show("Chưa có dữ liệu. Đợi lần kiểm tra tiếp theo.",
            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
    }
    using (var panel = new NVLMonitorPanel(result))
        panel.ShowDialog(this);
}
```

---

## 8. UI ĐỀ XUẤT — NVLMonitorPanel

### 8.1 Layout

```
┌────────────────────────────────────────────────────────────────┐
│  Giám Sát Nguyên Vật Liệu — Cập nhật: 2026-05-08 14:32:15    │
│  [Làm mới ngay]                                                │
├────────────────────────────────────────────────────────────────┤
│  TÀI KHOẢN 10 ĐƠN TIẾP THEO (theo thứ tự ưu tiên CR)          │
│                                                                │
│  # │ Mã HD    │ Khách hàng │ Số mẻ │ Giao hàng │ CR  │ Trạng thái   │
│  1 │ HD-001   │ ABC Corp   │  45   │ 10/05 08h │ 2.3 │ ✓ Đủ NVL     │
│  2 │ HD-007   │ XYZ Ltd    │  30   │ 10/05 10h │ 1.1 │ ⚠ THIẾU Đá 1200kg [GẤPO] │
│  3 │ HD-003   │ DEF Co.    │  20   │ 11/05 09h │ 3.2 │ ✓ Đủ NVL     │
│  ...                                                           │
├────────────────────────────────────────────────────────────────┤
│  TỒN KHO DỰ BÁO SAU 10 ĐƠN                                    │
│                                                                │
│  Silo  │ Vật liệu │ Tồn hiện tại │ Tồn dự báo │ Trạng thái  │
│  S1    │ Cát      │ 8,000 kg     │ 2,500 kg   │ ⚠ CẢNH BÁO  │
│  S3    │ Đá 1×2   │ 6,000 kg     │ 0 kg       │ ✗ HẾT KHO   │
│  ...                                                           │
└────────────────────────────────────────────────────────────────┘
```

### 8.2 File cần tạo

```
NDPSo/MasterData/TonKho/Monitor/
  ├── NVLMonitorPanel.cs          ← Form/UserControl hiển thị kết quả
  └── NVLMonitorPanel.Designer.cs ← Auto-generated
```

---

## 9. KẾ HOẠCH TRIỂN KHAI (3 PHASE)

### Phase 1 — Engine lõi (ưu tiên cao)

**Mục tiêu:** Engine chạy được, kết quả đúng, tích hợp cơ bản vào VanHanh.

- [x] Tạo `NVLMonitorResult.cs` (NVLShortage, NVLOrderFeasibility, NVLAlertLevel, NVLMonitorResult)
- [x] Tạo `NVLSimulation.cs` (thuật toán giả lập tuần tự)
- [x] Tạo `NVLMonitorEngine.cs` (timer, data loading, event raising)
- [x] SQL queries tích hợp inline trong `NVLMonitorEngine.LoadPendingOrdersSorted()`
- [x] Tích hợp vào `VanHanh.cs`: `InitNVLMonitor()`, subscribe `AlertLevelChanged`, `OnNVLAlertLevelChanged()`
- [x] Label `_lblNVLStatus` thêm programmatically vào `groupBox4` trong `InitNVLMonitor()`
- [x] Stop/Dispose engine trong `VanHanh_ControlClosing` (VanHanh.Commands.cs)
- [ ] Test: verify engine không làm chậm UI khi đang trộn (test sau khi build)

**Hoàn thành:** 2026-05-08

### Phase 2 — UI chi tiết

**Mục tiêu:** Người vận hành xem được full simulation kết quả.

- [ ] Tạo `NVLMonitorPanel.cs` (form popup với 2 grid)
- [ ] Grid 1: danh sách 10 đơn + feasibility + màu sắc (đỏ=thiếu gấp, vàng=thiếu, xanh=đủ)
- [ ] Grid 2: tồn kho dự báo sau 10 đơn (hiện tại vs dự báo)
- [ ] Nút "Làm mới ngay" → gọi `_nvlMonitor.ForceRefresh()`
- [ ] Thêm nút `btnNVLDetail` vào VanHanh toolbar
- [ ] Cột "Khuyến nghị": text đề xuất cho từng đơn

**Thời gian ước tính:** 1 ngày

### Phase 3 — Thông minh hóa (tùy chọn)

**Mục tiêu:** Thêm AI-level recommendations.

- [ ] **Sắp xếp khuyến nghị:** Engine đề xuất thứ tự chạy tối ưu theo inventory fit + CR
  - Ví dụ: "Nên chạy HD-003 trước HD-007 vì HD-003 đủ NVL, HD-007 đang thiếu đá"
- [ ] **Cảnh báo nhập kho:** "Cần nhập thêm Đá 1×2: tối thiểu 3,000kg để đáp ứng 5 đơn tới"
- [ ] **Lịch sử alert:** Lưu lại lịch sử cảnh báo (file log hoặc bảng DB AlertLog)
- [ ] **Tích hợp Chatbot:** Chatbot có thể truy vấn `LastResult` để trả lời
  - "Đơn nào sắp thiếu vật liệu?" → đọc từ `NVLMonitorResult`
- [ ] **Notification tray:** Balloon tooltip khi có alert mới

**Thời gian ước tính:** 2 ngày

---

## 10. HIỆU NĂNG & THREAD SAFETY

### Nguyên tắc

| Nguyên tắc | Cách áp dụng |
|------------|-------------|
| Engine chạy ở BelowNormal | `Thread.CurrentThread.Priority = BelowNormal` trong RunCheck |
| Không block UI | Dùng `System.Threading.Timer` (không phải `System.Windows.Forms.Timer`) |
| Không re-entrant | `_running` flag — bỏ qua nếu tick trước chưa xong |
| Không share state với PLC | Engine chỉ đọc DB, không đọc `_ro`, `_so` |
| Thread-safe UI update | Luôn dùng `BeginInvoke` khi update UI từ event handler |
| Snapshot độc lập | `virtualInventory = new Dictionary<>(currentInventory)` — không mutate bản gốc |

### Query performance

Các query trong engine dùng Index sẵn có:
- `DuLieuTron.Status` — nên có index (Status IN (0,2) rất phổ biến)
- `TonKho.SiloID` — UNIQUE, index sẵn
- `MACSilo.MACID` — FK, có index

**Ước tính thời gian query:** < 50ms với dữ liệu thực tế (< 100 đơn, < 20 silo)

**Chu kỳ khuyến nghị:** 60 giây. Có thể cho user cấu hình (30s–300s).

---

## 11. CÁC FILE CẦN TẠO/SỬA

### Files mới (Phase 1)

| File | Action | Mô tả |
|------|--------|-------|
| `NDPSo/MasterData/TonKho/Monitor/NVLMonitorResult.cs` | **TẠO MỚI** | DTOs: NVLShortage, NVLOrderFeasibility, NVLAlertLevel, NVLMonitorResult |
| `NDPSo/MasterData/TonKho/Monitor/NVLSimulation.cs` | **TẠO MỚI** | Thuật toán giả lập tuần tự |
| `NDPSo/MasterData/TonKho/Monitor/NVLMonitorEngine.cs` | **TẠO MỚI** | Engine chính (timer + orchestration) |

### Files sửa (Phase 1)

| File | Action | Thay đổi |
|------|--------|----------|
| `NDPSo/MasterData/VanHanh.cs` | **SỬA** | Thêm `_nvlMonitor` field, Start/Stop, subscribe event, UpdateNVLStatusBar |
| `NDPSo/MasterData/VanHanh.Designer.cs` | **SỬA** | Thêm `lblNVLStatus` label vào panel dưới |

### Files mới (Phase 2)

| File | Action | Mô tả |
|------|--------|-------|
| `NDPSo/MasterData/TonKho/Monitor/NVLMonitorPanel.cs` | **TẠO MỚI** | Form popup hiển thị kết quả |
| `NDPSo/MasterData/TonKho/Monitor/NVLMonitorPanel.Designer.cs` | **TẠO MỚI** | Designer auto-generated |

### Files không cần sửa

- `TonKhoService.cs` — Engine tự tạo query riêng (không dùng methods cũ để tránh coupling)
- `TonKhoView.cs` — Màn hình tồn kho thủ công, để nguyên
- SQL files — Không cần thêm bảng/SP mới (engine dùng query inline)

---

## LỊCH SỬ CẬP NHẬT

| Ngày | Version | Nội dung |
|------|---------|----------|
| 2026-05-08 | v1.0 | Tạo tài liệu ban đầu — thiết kế 3 phase |
| 2026-05-08 | v1.1 | Hoàn thành Phase 1 — tạo 3 file Monitor/ + tích hợp VanHanh |

---

*Cập nhật tài liệu này sau mỗi phase hoàn thành hoặc khi thiết kế thay đổi.*

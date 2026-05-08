using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;

namespace NDPSo.MasterData.TonKho.Monitor
{
    /// <summary>
    /// Engine chạy nền, định kỳ giả lập 10 đơn hàng tiếp theo và cảnh báo khi thiếu NVL.
    /// Chạy ở ThreadPriority.BelowNormal — không ảnh hưởng hiệu năng trộn.
    /// </summary>
    public class NVLMonitorEngine : IDisposable
    {
        private System.Threading.Timer _timer;
        private readonly string        _connStr;
        private NVLAlertLevel          _lastAlertLevel = NVLAlertLevel.OK;
        private volatile bool          _checkRunning   = false;

        public event EventHandler<NVLMonitorResult> ResultUpdated;
        public event EventHandler<NVLAlertLevel>    AlertLevelChanged;

        public NVLMonitorResult LastResult { get; private set; }

        public NVLMonitorEngine()
        {
            var sc = ConfigManager.ServiceConfig;
            _connStr = new SqlConnectionStringBuilder
            {
                DataSource         = sc.ServerName,
                InitialCatalog     = sc.DatabaseName,
                UserID             = sc.UserID,
                Password           = sc.Password,
                IntegratedSecurity = false
            }.ConnectionString;
        }

        /// <param name="intervalSeconds">Chu kỳ kiểm tra (mặc định 60 giây).</param>
        public void Start(int intervalSeconds = 60)
        {
            _timer = new System.Threading.Timer(
                _ => SafeRunCheck(),
                null,
                TimeSpan.Zero,                              // chạy ngay lần đầu
                TimeSpan.FromSeconds(intervalSeconds));
        }

        public void Stop()
        {
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>Chạy kiểm tra ngay lập tức (không chờ hết chu kỳ).</summary>
        public void ForceRefresh() => SafeRunCheck();

        private void SafeRunCheck()
        {
            // Bỏ qua nếu lần kiểm tra trước chưa xong
            if (_checkRunning) return;
            _checkRunning = true;
            try
            {
                Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;
                RunCheck();
            }
            catch (Exception ex)
            {
                TramTronLogger.WriteError(ex);
            }
            finally
            {
                _checkRunning = false;
            }
        }

        private void RunCheck()
        {
            var inventory  = LoadInventorySnapshot();
            var orders     = LoadPendingOrdersSorted();
            var macSilos   = LoadAllMACSilos();

            var sim           = new NVLSimulation();
            var feasibilities = sim.Simulate(orders, inventory, macSilos, maxOrders: 10);
            var alertLevel    = CalcAlertLevel(feasibilities, inventory);

            var result = new NVLMonitorResult
            {
                CheckTime          = DateTime.Now,
                Feasibilities      = feasibilities,
                AlertLevel         = alertLevel,
                ProjectedInventory = sim.LastProjectedInventory ?? new Dictionary<int, decimal>()
            };

            LastResult = result;
            ResultUpdated?.Invoke(this, result);

            if (alertLevel != _lastAlertLevel)
            {
                _lastAlertLevel = alertLevel;
                AlertLevelChanged?.Invoke(this, alertLevel);
            }
        }

        private static NVLAlertLevel CalcAlertLevel(
            List<NVLOrderFeasibility> list,
            Dictionary<int, decimal>  inventory)
        {
            if (inventory.Values.Any(v => v <= 0m)) return NVLAlertLevel.StockOut;
            if (list.Any(f => f.IsUrgent))          return NVLAlertLevel.Critical;
            if (list.Any(f => !f.CoThe))            return NVLAlertLevel.Warning;
            return NVLAlertLevel.OK;
        }

        // ── Data loaders (ADO.NET, read-only) ─────────────────────────────

        private Dictionary<int, decimal> LoadInventorySnapshot()
        {
            var dict = new Dictionary<int, decimal>();
            const string sql = "SELECT SiloID, SoLuongTon FROM TonKho";
            using (var conn = new SqlConnection(_connStr))
            using (var cmd  = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                    while (rd.Read())
                        dict[rd.GetInt32(0)] = Convert.ToDecimal(rd["SoLuongTon"]);
            }
            return dict;
        }

        private List<PendingOrder> LoadPendingOrdersSorted()
        {
            var list = new List<PendingOrder>();
            const string sql = @"
                SELECT d.DuLieuTronID,
                       d.MaHopDong,
                       ISNULL(kh.TenKhachHang, '') AS KhachHang,
                       d.MACID,
                       ISNULL(d.DLT_SLMeDuTinh, 1) AS SoMeDuTinh,
                       d.ThoiGianGiaoHang
                FROM DuLieuTron d
                LEFT JOIN KhachHang kh ON kh.KhachHangID = d.KhachHangID
                WHERE d.Status IN (0, 2)
                  AND ISNULL(d.Activated, 1) = 1";
            using (var conn = new SqlConnection(_connStr))
            using (var cmd  = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        decimal  soMe = Convert.ToDecimal(rd["SoMeDuTinh"]);
                        DateTime? tggh = rd["ThoiGianGiaoHang"] == DBNull.Value
                            ? (DateTime?)null
                            : Convert.ToDateTime(rd["ThoiGianGiaoHang"]);

                        double? cr = null;
                        if (tggh.HasValue && soMe > 0m)
                        {
                            double hoursLeft     = (tggh.Value - DateTime.Now).TotalHours;
                            double hoursRequired = (double)soMe * 5.0 / 60.0;
                            if (hoursRequired > 0)
                                cr = hoursLeft / hoursRequired;
                        }

                        list.Add(new PendingOrder
                        {
                            DuLieuTronID     = rd.GetInt32(0),
                            MaHopDong        = rd["MaHopDong"].ToString(),
                            KhachHang        = rd["KhachHang"].ToString(),
                            MACID            = rd.GetInt32(3),
                            SoMeDuTinh       = soMe,
                            ThoiGianGiaoHang = tggh,
                            CriticalRatio    = cr
                        });
                    }
                }
            }

            // Ưu tiên: đơn có deadline trước, trong đó CR thấp nhất = gấp nhất
            return list
                .OrderBy(o => o.ThoiGianGiaoHang.HasValue ? 0 : 1)
                .ThenBy(o => o.CriticalRatio ?? double.MaxValue)
                .ToList();
        }

        private List<MacSiloInfo> LoadAllMACSilos()
        {
            var list = new List<MacSiloInfo>();
            const string sql = @"
                SELECT ms.MACID, ms.SiloID, s.MaSilo, m.MaterialName,
                       ISNULL(ms.SiloValue, 0) AS SiloValue
                FROM MACSilo  ms
                JOIN Silo     s ON s.SiloID     = ms.SiloID
                JOIN Material m ON m.MaterialID = s.MaterialID
                WHERE s.MaterialID IS NOT NULL";
            using (var conn = new SqlConnection(_connStr))
            using (var cmd  = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                    while (rd.Read())
                        list.Add(new MacSiloInfo
                        {
                            MACID        = rd.GetInt32(0),
                            SiloID       = rd.GetInt32(1),
                            MaSilo       = rd["MaSilo"].ToString(),
                            MaterialName = rd["MaterialName"].ToString(),
                            SiloValue    = Convert.ToDecimal(rd["SiloValue"])
                        });
            }
            return list;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}

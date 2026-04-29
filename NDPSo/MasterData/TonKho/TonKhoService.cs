using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NDPSo.MasterData.TonKho
{
    /// <summary>
    /// Service tồn kho — dùng ADO.NET trực tiếp (bảng TonKho/NhapKho/XuatKho
    /// chưa có trong EDMX nên không đi qua EF).
    /// </summary>
    public class TonKhoService
    {
        private readonly string _connStr;

        public TonKhoService()
        {
            var sc = ConfigManager.ServiceConfig;
            _connStr = new System.Data.SqlClient.SqlConnectionStringBuilder
            {
                DataSource         = sc.ServerName,
                InitialCatalog     = sc.DatabaseName,
                UserID             = sc.UserID,
                Password           = sc.Password,
                IntegratedSecurity = false
            }.ConnectionString;
        }

        // ── Load tồn kho tổng hợp ─────────────────────────────────
        public List<ObjTonKhoRow> LoadTonKho()
        {
            var list = new List<ObjTonKhoRow>();
            const string sql = @"
                SELECT tk.TonKhoID, s.SiloID, s.MaSilo, s.TenSilo,
                       m.MaterialID, m.MaterialName,
                       tk.SoLuongTon, tk.MucCanhBao,
                       CASE WHEN tk.SoLuongTon <= 0 THEN 0
                            WHEN tk.SoLuongTon < tk.MucCanhBao THEN 1
                            ELSE 2 END AS TrangThaiID
                FROM TonKho tk
                JOIN Silo     s ON s.SiloID     = tk.SiloID
                JOIN Material m ON m.MaterialID = tk.MaterialID
                ORDER BY TrangThaiID ASC, tk.SoLuongTon ASC";
            using (var conn = new SqlConnection(_connStr))
            using (var cmd  = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                    while (rd.Read())
                        list.Add(new ObjTonKhoRow
                        {
                            TonKhoID     = rd.GetInt32(0),
                            SiloID       = rd.GetInt32(1),
                            MaSilo       = rd["MaSilo"].ToString(),
                            TenSilo      = rd["TenSilo"].ToString(),
                            MaterialID   = rd.GetInt32(4),
                            MaterialName = rd["MaterialName"].ToString(),
                            SoLuongTon   = Convert.ToDecimal(rd["SoLuongTon"]),
                            MucCanhBao   = Convert.ToDecimal(rd["MucCanhBao"]),
                            TrangThaiID  = Convert.ToInt32(rd["TrangThaiID"])
                        });
            }
            return list;
        }

        // ── Kiểm tra tồn kho vs nhu cầu DuLieuTron ───────────────
        public List<ObjKiemTraTonKho> KiemTraNhuCau()
        {
            var list = new List<ObjKiemTraTonKho>();
            const string sql = @"
                WITH NhuCau AS (
                    SELECT s.SiloID, s.MaSilo, m.MaterialName,
                           SUM(ISNULL(d.DLT_SLMeDuTinh,1) * ISNULL(ms.SiloValue,0)) AS TongCanDung
                    FROM DuLieuTron d
                    JOIN MACSilo  ms ON ms.MACID     = d.MACID
                    JOIN Silo     s  ON s.SiloID     = ms.SiloID
                    JOIN Material m  ON m.MaterialID = s.MaterialID
                    WHERE d.Status IN (0,2) AND s.MaterialID IS NOT NULL
                    GROUP BY s.SiloID, s.MaSilo, m.MaterialName
                )
                SELECT n.MaterialName, n.MaSilo,
                       ISNULL(tk.SoLuongTon,0)               AS TonHienTai,
                       n.TongCanDung,
                       ISNULL(tk.SoLuongTon,0)-n.TongCanDung AS ChenhLech,
                       ISNULL(tk.MucCanhBao,500)             AS MucCanhBao,
                       CASE WHEN ISNULL(tk.SoLuongTon,0) >= n.TongCanDung THEN 2
                            WHEN ISNULL(tk.SoLuongTon,0) >  0             THEN 1
                            ELSE 0 END AS TrangThaiID
                FROM NhuCau n
                LEFT JOIN TonKho tk ON tk.SiloID = n.SiloID
                ORDER BY TrangThaiID ASC, ChenhLech ASC";
            using (var conn = new SqlConnection(_connStr))
            using (var cmd  = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                    while (rd.Read())
                        list.Add(new ObjKiemTraTonKho
                        {
                            MaterialName = rd["MaterialName"].ToString(),
                            MaSilo       = rd["MaSilo"].ToString(),
                            TonHienTai   = Convert.ToDecimal(rd["TonHienTai"]),
                            TongCanDung  = Convert.ToDecimal(rd["TongCanDung"]),
                            ChenhLech    = Convert.ToDecimal(rd["ChenhLech"]),
                            MucCanhBao   = Convert.ToDecimal(rd["MucCanhBao"]),
                            TrangThaiID  = Convert.ToInt32(rd["TrangThaiID"])
                        });
            }
            return list;
        }

        // ── Lấy danh sách Silo có thể nhập kho ───────────────────
        public DataTable GetSiloList()
        {
            const string sql = @"
                SELECT s.SiloID, s.MaSilo + ' — ' + m.MaterialName AS TenHienThi,
                       m.MaterialName, s.MaSilo
                FROM Silo s
                JOIN Material m ON m.MaterialID = s.MaterialID
                WHERE ISNULL(s.Activated,1) = 1
                ORDER BY s.MaSilo";
            var dt = new DataTable();
            using (var conn = new SqlConnection(_connStr))
            using (var da   = new SqlDataAdapter(sql, conn))
                da.Fill(dt);
            return dt;
        }

        // ── Nhập kho ─────────────────────────────────────────────
        public bool NhapKho(int siloID, decimal soLuong, string nhaCungCap,
                             string soHoaDon, string ghiChu, int createdBy = 1)
        {
            const string sql = "EXEC sp_NhapKho @SiloID,@SoLuong,@NhaCungCap,@SoHoaDon,@GhiChu,@CreatedBy";
            try
            {
                using (var conn = new SqlConnection(_connStr))
                using (var cmd  = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@SiloID",       siloID);
                    cmd.Parameters.AddWithValue("@SoLuong",      soLuong);
                    cmd.Parameters.AddWithValue("@NhaCungCap",   (object)nhaCungCap  ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoHoaDon",     (object)soHoaDon    ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GhiChu",       (object)ghiChu      ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy",    createdBy);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return false;
            }
        }

        // ── Xuất kho tự động khi mẻ trộn hoàn tất ───────────────
        public void XuatKhoTuDong(int meTronID, int phieuTronID, int duLieuTronID, int createdBy = 1)
        {
            const string sql = "EXEC sp_XuatKho_TuDong @MeTronID,@PhieuTronID,@DuLieuTronID,@CreatedBy";
            try
            {
                using (var conn = new SqlConnection(_connStr))
                using (var cmd  = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@MeTronID",      meTronID);
                    cmd.Parameters.AddWithValue("@PhieuTronID",   phieuTronID);
                    cmd.Parameters.AddWithValue("@DuLieuTronID",  duLieuTronID);
                    cmd.Parameters.AddWithValue("@CreatedBy",     createdBy);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                TramTronLogger.WriteError(ex);
            }
        }

        // ── Xuất kho theo PhieuTronID (gọi khi PhieuTron hoàn tất) ──
        /// <summary>
        /// Tìm tất cả MeTron thuộc PhieuTronID, xuất kho cho từng MeTron.
        /// Dùng khi không có MeTronID trực tiếp.
        /// </summary>
        public void XuatKhoTheoPhieuTron(int phieuTronID, int duLieuTronID, int createdBy = 1)
        {
            const string sqlGetMeTron = "SELECT MeTronID FROM MeTron WHERE PhieuTronID = @PhieuTronID";
            try
            {
                using (var conn = new SqlConnection(_connStr))
                {
                    conn.Open();
                    var meTronIDs = new System.Collections.Generic.List<int>();
                    using (var cmd = new SqlCommand(sqlGetMeTron, conn))
                    {
                        cmd.Parameters.AddWithValue("@PhieuTronID", phieuTronID);
                        using (var rd = cmd.ExecuteReader())
                            while (rd.Read())
                                meTronIDs.Add(rd.GetInt32(0));
                    }
                    foreach (int meTronID in meTronIDs)
                    {
                        const string sql = "EXEC sp_XuatKho_TuDong @MeTronID,@PhieuTronID,@DuLieuTronID,@CreatedBy";
                        using (var cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@MeTronID",     meTronID);
                            cmd.Parameters.AddWithValue("@PhieuTronID",  phieuTronID);
                            cmd.Parameters.AddWithValue("@DuLieuTronID", duLieuTronID);
                            cmd.Parameters.AddWithValue("@CreatedBy",    createdBy);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TramTronLogger.WriteError(ex);
            }
        }

        // ── Cập nhật mức cảnh báo ─────────────────────────────────
        public bool UpdateMucCanhBao(int tonKhoID, decimal mucCanhBao)
        {
            const string sql = "UPDATE TonKho SET MucCanhBao=@Val, LatestUpdateDate=GETDATE() WHERE TonKhoID=@ID";
            try
            {
                using (var conn = new SqlConnection(_connStr))
                using (var cmd  = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Val", mucCanhBao);
                    cmd.Parameters.AddWithValue("@ID",  tonKhoID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return false;
            }
        }

        // ── Đếm số silo đang cảnh báo/hết kho ───────────────────
        public (int HetKho, int CanhBao) DemCanhBao()
        {
            const string sql = @"
                SELECT SUM(CASE WHEN SoLuongTon <= 0             THEN 1 ELSE 0 END) AS HetKho,
                       SUM(CASE WHEN SoLuongTon > 0
                                 AND SoLuongTon < MucCanhBao      THEN 1 ELSE 0 END) AS CanhBao
                FROM TonKho";
            using (var conn = new SqlConnection(_connStr))
            using (var cmd  = new SqlCommand(sql, conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                        return (Convert.ToInt32(rd["HetKho"]), Convert.ToInt32(rd["CanhBao"]));
                }
            }
            return (0, 0);
        }
    }

    // ── DTOs ─────────────────────────────────────────────────────
    public class ObjTonKhoRow
    {
        public int     TonKhoID     { get; set; }
        public int     SiloID       { get; set; }
        public string  MaSilo       { get; set; }
        public string  TenSilo      { get; set; }
        public int     MaterialID   { get; set; }
        public string  MaterialName { get; set; }
        public decimal SoLuongTon   { get; set; }
        public decimal MucCanhBao   { get; set; }
        public int     TrangThaiID  { get; set; } // 0=hết, 1=cảnh báo, 2=đủ

        public string TrangThai => TrangThaiID == 0 ? "HẾT KHO"
                                 : TrangThaiID == 1 ? "CẢNH BÁO"
                                 : "ĐỦ";
        public decimal PhanTramCon =>
            MucCanhBao > 0 ? Math.Min(SoLuongTon / MucCanhBao * 100, 100) : 0;
    }

    public class ObjKiemTraTonKho
    {
        public string  MaterialName { get; set; }
        public string  MaSilo       { get; set; }
        public decimal TonHienTai   { get; set; }
        public decimal TongCanDung  { get; set; }
        public decimal ChenhLech    { get; set; }
        public decimal MucCanhBao   { get; set; }
        public int     TrangThaiID  { get; set; } // 0=hết, 1=thiếu, 2=đủ

        public string TrangThai => TrangThaiID == 0 ? "✗ HẾT KHO"
                                 : TrangThaiID == 1 ? "⚠ THIẾU"
                                 : "✓ ĐỦ";
    }
}

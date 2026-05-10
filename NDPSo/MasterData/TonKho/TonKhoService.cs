using NDPSo.BusinessObject;
using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace NDPSo.MasterData.TonKho
{
    /// <summary>
    /// Service tồn kho — dùng ADO.NET trực tiếp (bảng TonKho/NhapKho/XuatKho
    /// chưa có trong EDMX nên không đi qua EF).
    /// </summary>
    public class TonKhoService
    {
        // Raised on background thread after XuatKho completes — subscribers must BeginInvoke
        public static event Action TonKhoChanged;

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

        public static void RaiseTonKhoChanged() => TonKhoChanged?.Invoke();

       
        // ── Load tồn kho tổng hợp ─────────────────────────────────
        public List<ObjTonKhoRow> LoadTonKho()
        {
            return new NDPTramTronBO().ListTonKho()
                .Select(t => new ObjTonKhoRow
                {
                    TonKhoID = t.TonKhoID,
                    SiloID = t.SiloID,
                    MaSilo = t.NPSiloMaSilo,
                    TenSilo = t.NPSiloTenSilo,
                    MaterialID = t.MaterialID,
                    MaterialName = t.NPMaterialName,
                    SoLuongTon = t.SoLuongTon,
                    MucCanhBao = t.MucCanhBao,
                    TrangThaiID = t.TrangThaiID
                }).ToList();
        }

        // ── Kiểm tra tồn kho vs nhu cầu DuLieuTron ───────────────
        public List<ObjKiemTraTonKho> KiemTraNhuCau()
        {
            try
            {
                return new NDPTramTronBO().KiemTraNhuCau();
            }
            catch (Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return new List<ObjKiemTraTonKho>();
            }
        }

        // ── Lấy danh sách Silo có thể nhập kho ───────────────────
        public DataTable GetSiloList()
        {
            try
            {
                return new NDPTramTronBO().GetSiloListForNhapKho();
            }
            catch (Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return new DataTable();
            }
        }

        // ── Nhập kho ─────────────────────────────────────────────
        public bool NhapKho(int siloID, decimal soLuong, string nhaCungCap,
                             string soHoaDon, string ghiChu, int createdBy = 1)
        {
            try
            {
                var bo = new NDPTramTronBO();
                var tonKho = bo.GetTonKhoBySiloID(siloID);
                var obj = new ObjNhapKho
                {
                    SiloID = siloID,
                    MaterialID = tonKho?.MaterialID ?? 0,
                    SoLuongNhap = soLuong,
                    NhaCungCap = nhaCungCap,
                    SoHoaDon = soHoaDon,
                    GhiChu = ghiChu,
                    NgayNhap = DateTime.Now
                };
                return bo.SaveNhapKho(new List<ObjNhapKho> { obj });
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
            try
            {
                new NDPTramTronBO().XuatKhoTheoMeTron(meTronID, phieuTronID, duLieuTronID);
            }
            catch (Exception ex)
            {
                TramTronLogger.WriteError(ex);
            }
        }

        // ── Xuất kho theo PhieuTronID (gọi khi PhieuTron hoàn tất) ──
        public void XuatKhoTheoPhieuTron(int phieuTronID, int duLieuTronID, int createdBy = 1)
        {
            const string sqlGetMeTron = "SELECT MeTronID FROM MeTron WHERE PhieuTronID = @PhieuTronID";
            TramTronLogger.WriteInfo($"[XuatKho] Bắt đầu — PhieuTronID={phieuTronID} DuLieuTronID={duLieuTronID}");
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

                    TramTronLogger.WriteInfo($"[XuatKho] Tìm thấy {meTronIDs.Count} MeTron cho PhieuTronID={phieuTronID}");

                    if (meTronIDs.Count == 0)
                    {
                        TramTronLogger.WriteInfo($"[XuatKho] CẢNH BÁO: Không có MeTron nào — bỏ qua trừ kho. PhieuTronID={phieuTronID}");
                    }

                    foreach (int meTronID in meTronIDs)
                    {
                        try
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
                            TramTronLogger.WriteInfo($"[XuatKho] OK — MeTronID={meTronID}");
                        }
                        catch (Exception exMe)
                        {
                            TramTronLogger.WriteInfo($"[XuatKho] LỖI MeTronID={meTronID}: {exMe.Message}");
                            TramTronLogger.WriteError(exMe);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                TramTronLogger.WriteInfo($"[XuatKho] LỖI kết nối/query: {ex.Message}");
                TramTronLogger.WriteError(ex);
            }
            finally
            {
                // Luôn raise event để TonKhoView refresh — kể cả khi có lỗi một phần
                TonKhoChanged?.Invoke();
                TramTronLogger.WriteInfo($"[XuatKho] Kết thúc — PhieuTronID={phieuTronID}");
            }
        }

        // ── Cập nhật mức cảnh báo ─────────────────────────────────
        public bool UpdateMucCanhBao(int tonKhoID, decimal mucCanhBao)
        {
            try
            {
                var bo = new NDPTramTronBO();
                var obj = bo.GetTonKhoByKey(tonKhoID);
                if (obj == null) return false;
                obj.MucCanhBao = mucCanhBao;
                return bo.SaveTonKho(new List<ObjTonKho> { obj });
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
            try
            {
                return new NDPTramTronBO().DemCanhBao();
            }
            catch (Exception ex)
            {
                TramTronLogger.WriteError(ex);
                return (0, 0);
            }
        }
    }

    // ── DTOs ─────────────────────────────────────────────────────
    public class ObjTonKhoRow
    {
        public int TonKhoID { get; set; }
        public int SiloID { get; set; }
        public string MaSilo { get; set; }
        public string TenSilo { get; set; }
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
        public decimal SoLuongTon { get; set; }
        public decimal MucCanhBao { get; set; }
        public int TrangThaiID { get; set; } // 0=hết, 1=cảnh báo, 2=đủ

        public string TrangThai => TrangThaiID == 0 ? "HẾT KHO"
                                 : TrangThaiID == 1 ? "CẢNH BÁO"
                                 : "ĐỦ";
        public decimal PhanTramCon =>
            MucCanhBao > 0 ? Math.Min(SoLuongTon / MucCanhBao * 100, 100) : 0;
    }

    public class ObjKiemTraTonKho
    {
        public string MaterialName { get; set; }
        public string MaSilo { get; set; }
        public decimal TonHienTai { get; set; }
        public decimal TongCanDung { get; set; }
        public decimal ChenhLech { get; set; }
        public decimal MucCanhBao { get; set; }
        public int TrangThaiID { get; set; } // 0=hết, 1=thiếu, 2=đủ

        public string TrangThai => TrangThaiID == 0 ? "✗ HẾT KHO"
                                 : TrangThaiID == 1 ? "⚠ THIẾU"
                                 : "✓ ĐỦ";
    }
}

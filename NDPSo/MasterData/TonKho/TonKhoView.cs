using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using NDPSo.Utils;
using NDPSo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NDPSo.MasterData.TonKho
{
    public partial class TonKhoView : ControlViewBase
    {
        private readonly TonKhoService _svc = new TonKhoService();

        public TonKhoView()
        {
            InitializeComponent();
            this.Caption = "Tồn Kho Nguyên Vật Liệu";
            Load += (s, e) => Refresh_All();
            TonKhoService.TonKhoChanged += OnTonKhoChanged;
            Disposed += (s, e) => TonKhoService.TonKhoChanged -= OnTonKhoChanged;
        }

        // Called from background thread after XuatKho — marshal to UI thread
        private void OnTonKhoChanged()
        {
            if (this.IsDisposed) return;
            if (this.InvokeRequired)
                this.BeginInvoke(new Action(Refresh_All));
            else
                Refresh_All();
        }

        private void Refresh_All()
        {
            LoadTonKho();
            LoadNhuCau();
            UpdateSummary();
        }

        private void LoadTonKho()
        {
            try
            {
                var data = _svc.LoadTonKho();
                grcTonKho.DataSource = data;
                grvTonKho.RefreshData();
            }
            catch (Exception ex) { TramTronLogger.WriteError(ex); }
        }

        private void LoadNhuCau()
        {
            try
            {
                var data = _svc.KiemTraNhuCau();
                grcNhuCau.DataSource = data;
                grvNhuCau.RefreshData();
            }
            catch (Exception ex) { TramTronLogger.WriteError(ex); }
        }

        private void UpdateSummary()
        {
            try
            {
                var (hetKho, canhBao) = _svc.DemCanhBao();
                lblSummary.Text = hetKho > 0
                    ? $"⚠  {hetKho} silo HẾT KHO   |   {canhBao} silo CẢNH BÁO"
                    : canhBao > 0
                        ? $"⚠  {canhBao} silo sắp hết — nên nhập thêm"
                        : "✓  Tồn kho đủ cho các đơn hàng đang chờ";

                lblSummary.ForeColor = hetKho > 0 ? Color.Red
                                     : canhBao > 0 ? Color.OrangeRed
                                     : Color.Green;
            }
            catch { }
        }

        // Tô màu grid TonKho theo trạng thái
        private void grvTonKho_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var row = grvTonKho.GetRow(e.RowHandle) as ObjTonKhoRow;
            if (row == null) return;
            switch (row.TrangThaiID)
            {
                case 0: // HẾT KHO
                    e.Appearance.BackColor = Color.FromArgb(255, 80, 80);
                    e.Appearance.ForeColor = Color.White;
                    break;
                case 1: // CẢNH BÁO
                    e.Appearance.BackColor = Color.FromArgb(255, 200, 0);
                    e.Appearance.ForeColor = Color.Black;
                    break;
                default: // ĐỦ
                    e.Appearance.BackColor = Color.FromArgb(200, 240, 200);
                    e.Appearance.ForeColor = Color.Black;
                    break;
            }
        }

        // Tô màu grid NhuCau
        private void grvNhuCau_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            var row = grvNhuCau.GetRow(e.RowHandle) as ObjKiemTraTonKho;
            if (row == null) return;
            switch (row.TrangThaiID)
            {
                case 0:
                    e.Appearance.BackColor = Color.FromArgb(255, 80, 80);
                    e.Appearance.ForeColor = Color.White;
                    break;
                case 1:
                    e.Appearance.BackColor = Color.FromArgb(255, 200, 0);
                    e.Appearance.ForeColor = Color.Black;
                    break;
                default:
                    e.Appearance.BackColor = Color.FromArgb(200, 240, 200);
                    e.Appearance.ForeColor = Color.Black;
                    break;
            }
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            var siloList = _svc.GetSiloList();
            if (siloList.Rows.Count == 0)
            {
                MessageBox.Show("Không có Silo nào. Hãy kiểm tra cấu hình Silo + Vật liệu.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var dlg = new NhapKhoDialog(siloList))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    bool ok = _svc.NhapKho(dlg.SiloID, dlg.SoLuong,
                                            dlg.NhaCungCap, dlg.SoHoaDon, dlg.GhiChu,
                                            GlobalValues.UserID);
                    if (ok)
                    {
                        Refresh_All();
                        MessageBox.Show("Nhập kho thành công!", "OK",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Lỗi khi nhập kho. Kiểm tra log.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) => Refresh_All();

        // ── Format số: phụ gia 2 chữ số thập phân, vật tư khác số nguyên ──
        private static bool IsPhuGia(string materialName)
        {
            if (string.IsNullOrEmpty(materialName)) return false;
            var name = materialName.Trim().ToLower();
            // Nhóm Add (Add 1, Add 2...) hoặc tên tiếng Việt
            return name.StartsWith("add")
                || name.Contains("phụ gia") || name.Contains("phu gia");
        }

        private static string FormatSoLuong(decimal value, string materialName)
        {
            return IsPhuGia(materialName)
                ? value.ToString("N2")   // 1,250.50
                : ((long)value).ToString("N0"); // 5,000
        }

        private void grvTonKho_CustomColumnDisplayText(object sender,
            DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName != "SoLuongTon" && e.Column.FieldName != "MucCanhBao") return;
            if (e.ListSourceRowIndex < 0) return;
            var data = grcTonKho.DataSource as System.Collections.Generic.List<ObjTonKhoRow>;
            if (data == null || e.ListSourceRowIndex >= data.Count) return;
            var row = data[e.ListSourceRowIndex];
            decimal val = e.Column.FieldName == "SoLuongTon" ? row.SoLuongTon : row.MucCanhBao;
            e.DisplayText = FormatSoLuong(val, row.MaterialName);
        }

        private void grvNhuCau_CustomColumnDisplayText(object sender,
            DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            var numCols = new[] { "TonHienTai", "TongCanDung", "ChenhLech", "MucCanhBao" };
            if (System.Array.IndexOf(numCols, e.Column.FieldName) < 0) return;
            if (e.ListSourceRowIndex < 0) return;
            var data = grcNhuCau.DataSource as System.Collections.Generic.List<ObjKiemTraTonKho>;
            if (data == null || e.ListSourceRowIndex >= data.Count) return;
            var row = data[e.ListSourceRowIndex];
            decimal val;
            switch (e.Column.FieldName)
            {
                case "TonHienTai":  val = row.TonHienTai;  break;
                case "TongCanDung": val = row.TongCanDung; break;
                case "ChenhLech":   val = row.ChenhLech;   break;
                case "MucCanhBao":  val = row.MucCanhBao;  break;
                default: return;
            }
            e.DisplayText = FormatSoLuong(val, row.MaterialName);
        }
    }
}

using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace NDPSo.MasterData.TonKho
{
    public partial class NhapKhoDialog : XtraForm
    {
        public int     SiloID      { get; private set; }
        public decimal SoLuong    { get; private set; }
        public string  NhaCungCap { get; private set; }
        public string  SoHoaDon   { get; private set; }
        public string  GhiChu     { get; private set; }

        private readonly DataTable _siloList;

        public NhapKhoDialog(DataTable siloList)
        {
            InitializeComponent();
            _siloList = siloList;

            lueSilo.Properties.DataSource    = siloList;
            lueSilo.Properties.DisplayMember = "TenHienThi";
            lueSilo.Properties.ValueMember   = "SiloID";
            lueSilo.Properties.ShowHeader    = false;
            lueSilo.Properties.Columns.Add(
                new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenHienThi", "Silo — Vật liệu", 300));

            if (siloList.Rows.Count > 0)
                lueSilo.EditValue = siloList.Rows[0]["SiloID"];
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lueSilo.EditValue == null || lueSilo.EditValue == DBNull.Value)
            {
                XtraMessageBox.Show("Vui lòng chọn Silo.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal sl;
            if (!decimal.TryParse(txtSoLuong.Text.Trim(), out sl) || sl <= 0)
            {
                XtraMessageBox.Show("Số lượng nhập phải là số dương.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            SiloID      = Convert.ToInt32(lueSilo.EditValue);
            SoLuong    = sl;
            NhaCungCap = txtNhaCungCap.Text.Trim();
            SoHoaDon   = txtSoHoaDon.Text.Trim();
            GhiChu     = txtGhiChu.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.Reports
{
    public partial class ReportChiTietChuyenXe : ControlViewBase
    {
        public ReportChiTietChuyenXe()
        {
            InitializeComponent();
            this.Caption = "Chi tiết chuyến xe";

            DevExpress.XtraGrid.GridControl gridControl1 = new DevExpress.XtraGrid.GridControl();
            
            GridView gridView1 = new GridView(gridControl1);
            gridControl1.MainView = gridView1;

            // Tạo cột và thêm vào GridView, dựa vào cấu hình
            GridColumn colBienSo = new GridColumn();
            colBienSo.Caption = "Biển số";
            colBienSo.FieldName = "ID";
            colBienSo.Visible = true;
            gridView1.Columns.Add(colBienSo);

            GridColumn colTaiXe = new GridColumn();
            colTaiXe.Caption = "Tài xế";
            colTaiXe.FieldName = "Name";
            colTaiXe.Visible = true;
            gridView1.Columns.Add(colTaiXe);

            GridColumn colTongKhoiLuong = new GridColumn();
            colTongKhoiLuong.Caption = "Tổng khối lương";
            colTongKhoiLuong.FieldName = "Name";
            colTongKhoiLuong.Visible = true;
            gridView1.Columns.Add(colTongKhoiLuong);

            GridColumn colSoChuyen = new GridColumn();
            colSoChuyen.Caption = "Số chuyến";
            colSoChuyen.FieldName = "Name";
            colSoChuyen.Visible = true;
            gridView1.Columns.Add(colSoChuyen);

            this.grcDuLieu.Controls.Add(gridControl1);
            gridControl1.Dock = DockStyle.Fill;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "BÁO CÁO CHI TIẾT CHUYẾN XE";
                string str = string.Format("Từ ngày: {0} - đến ngày: {1}", (object)FormatToString.DateTimeToString(this.datFromDate.DateTime), (object)FormatToString.DateTimeToString(this.datToDate.DateTime));
                string str2 = string.Format("Biển số: {0}", (object)this.lueBienXe.Text);
                List<string> lst = new List<string>();
                lst.Add(str);
                if (this.lueBienXe.EditValue != (object)null)
                    lst.Add(str2);
                new Helpper().ExportExcelWithHeader(true, (IPrintable)this.grcChiTietChuyenXe, true, true, title, lst);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }
    }
}

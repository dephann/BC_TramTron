using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace NDPSo.KWS
{
    public partial class PhieuTronChiTietRP : DevExpress.XtraReports.UI.XtraReport
    {
        private DataTable _table;
        public PhieuTronChiTietRP(DataTable table)
        {
            InitializeComponent();
            this._table = table;
            UpdateTableColumns();
        }
        
        private void UpdateTableColumns()
        {
            DataTable dataTable = this._table;

            this.xrTable1.BeginInit();
            this.xrTable1.Rows.Clear();
            this.xrTable1.EndInit();

            XRTableRow headerRow = new XRTableRow();
            foreach (DataColumn column in dataTable.Columns)
            {
                XRTableCell tableCell = new XRTableCell()
                {
                    Text = column.ColumnName,
                    // Cấu hình các thuộc tính của ô, chẳng hạn như font, màu sắc, v.v.
                };

                // Thêm ô vào dòng tiêu đề
                headerRow.Cells.Add(tableCell);
            }

            this.xrTable1.Rows.Add(headerRow);
        }

    }
}

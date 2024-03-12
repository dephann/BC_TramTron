using DevExpress.XtraReports.UI;
using NDPSo.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace NDPSo.KWS
{
    public partial class PhieuTronChiTietRP1 : DevExpress.XtraReports.UI.XtraReport
    {
        public PhieuTronChiTietRP1(List<string> para, List<decimal> totalTextList, List<string> headerTextList, DataTable table, decimal sumCP, params int[] targetColumnIndexes)
        {
            InitializeComponent();
            LoadParam(para);
            UpdateTableColumns(totalTextList, headerTextList, table, sumCP, targetColumnIndexes);
        }

        private void LoadParam(List<string> para)
        {
            this.xrLblTenTram.Text = para[0];
            this.xrLblDate0.Text = para[1];
            this.xrLblCongTruong0.Text = para[2];
            this.xrLblMaPhieu.Text = para[16];
            this.xrLblKhachHang.Text = para[3];
            this.xrLblCongTruong.Text = para[2];
            this.xrLblDiaDiem.Text = para[15];
            this.xrLblMAC.Text = para[4];
            this.xrLblTheTichXe.Text = para[10];
            this.xrLblDate.Text = para[1];
            this.xrLblTime.Text = para[14];
            this.xrLblHangMuc.Text = para[18];
            this.xrLblBienSo.Text = para[13];
            this.xrLblLaiXe.Text = para[9];
            this.xrLblNhanVien.Text = "- Tạo bởi - " + GlobalValues.DisplayUser;
        }
        private void UpdateTableColumns(List<decimal> totalTextList, List<string> headerTextList, DataTable dataTable, decimal sumCP, params int[] targetColumnIndexes)
        {
            if (headerTextList.Count > 0 && targetColumnIndexes.Length > 0)
            {
                // Tạo một dòng mới cho XRTable
                XRTableRow headerRow = new XRTableRow();

                // Thêm các cột tiêu đề cho bảng
                for (int i = 0; i < targetColumnIndexes.Length; i++)
                {
                    int columnIndex = i;

                    // Kiểm tra xem chỉ mục cột có hợp lệ không
                    if (columnIndex >= 0 && columnIndex < headerTextList.Count)
                    {
                        // Lấy nội dung tiêu đề từ danh sách
                        string headerText = headerTextList[columnIndex];

                        // Tạo một ô (cột) mới cho XRTable với nội dung là tiêu đề
                        XRTableCell headerCell = new XRTableCell()
                        {
                            Text = headerText,
                            //Borders = DevExpress.XtraPrinting.BorderSide.All,
                            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                            Width = 150
                        };

                        headerCell.Font = new Font(headerCell.Font.FontFamily, 9, FontStyle.Bold);
                        // Nếu là cột đầu tiên, đặt độ đậm cho font
                        if (i == 0)
                        {
                            
                        }

                        // Thêm ô vào dòng tiêu đề
                        headerRow.Cells.Add(headerCell);
                    }
                    else
                    {
                        // Hiển thị thông báo hoặc xử lý trường hợp không hợp lệ tại đây
                    }
                }

                // Thêm dòng tiêu đề vào XRTable
                this.xrTable1.Rows.Add(headerRow);
                int rowCount = 0;

                // Lặp qua mỗi dòng trong DataTable để thêm dữ liệu
                foreach (DataRow row in dataTable.Rows)
                {
                    // Tạo một dòng mới cho XRTable
                    XRTableRow dataRow = new XRTableRow();

                    // Thêm dữ liệu từ DataTable vào cột tương ứng trong XRTable
                    for (int i = 0; i < targetColumnIndexes.Length; i++)
                    {
                        int columnIndex = targetColumnIndexes[i];

                        // Kiểm tra xem chỉ mục cột có hợp lệ không
                        if (columnIndex >= 0 && columnIndex < dataTable.Columns.Count)
                        {
                            // Lấy dữ liệu từ DataTable tại chỉ mục cột
                            string cellData = row[columnIndex].ToString();

                            // Tạo một ô (cột) mới cho XRTable với nội dung là dữ liệu từ DataTable
                            XRTableCell tableCell = new XRTableCell()
                            {
                                Text = cellData,
                                //Borders = DevExpress.XtraPrinting.BorderSide.All,
                                TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                                Width = 150
                            };

                            // Nếu là cột đầu tiên, đặt độ đậm cho font
                            if (i == 0)
                            {
                                tableCell.Font = new Font(tableCell.Font.FontFamily, 9, FontStyle.Bold);
                            }
                            else
                            {
                                tableCell.Font = new Font(tableCell.Font.FontFamily, 9, FontStyle.Regular);
                            }
                            
                            // Thêm ô vào dòng dữ liệu
                            dataRow.Cells.Add(tableCell);
                        }
                        else
                        {
                            // Hiển thị thông báo hoặc xử lý trường hợp không hợp lệ tại đây
                        }
                    }

                    // Thêm dòng dữ liệu vào XRTable
                    this.xrTable1.Rows.Add(dataRow);

                    rowCount++;

                    // Kiểm tra nếu rowCount đạt đến 3, thêm một hàng mới và Merge & Center
                    if (rowCount == 3)
                    {
                        // Tạo một dòng mới cho XRTable
                        XRTableRow mergeRow = new XRTableRow();

                        // Tạo một ô duy nhất cho dòng merge và center
                        XRTableCell mergeCell = new XRTableCell()
                        {
                            Text = "CHI TIẾT MẺ TRỘN(DETAIL)",
                            WidthF = 450, // Độ rộng của ô dọc theo tất cả các cột
                            //Borders = DevExpress.XtraPrinting.BorderSide.All, // Hiển thị đường viền
                            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter, // Canh giữa nội dung
                        };

                        mergeCell.Font = new Font(mergeCell.Font.FontFamily, 8, FontStyle.Bold);
                        // Thêm ô vào dòng merge
                        mergeRow.Cells.Add(mergeCell);

                        // Thêm dòng merge vào XRTable
                        this.xrTable1.Rows.Add(mergeRow);

                        //rowCount = 0; // Đặt lại rowCount sau khi thêm hàng merge
                    }
                }

                // Tạo một dòng mới cho XRTable
                XRTableRow totalRow = new XRTableRow();

                // Thêm các cột tiêu đề cho bảng
                for (int i = 0; i < targetColumnIndexes.Length; i++)
                {
                    int columnIndex = i;
                    if (columnIndex == 0)
                    {
                        XRTableCell textTotalCell = new XRTableCell()
                        {
                            Text = "Tổng",
                            //Borders = DevExpress.XtraPrinting.BorderSide.All, // Hiển thị đường viền
                            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter, // Canh giữa nội dung
                            Width = 150
                        };
                        textTotalCell.Font = new Font(textTotalCell.Font.FontFamily, 9, FontStyle.Bold);
                        // Thêm ô vào dòng merge
                        totalRow.Cells.Add(textTotalCell);
                    }
                    // Kiểm tra xem chỉ mục cột có hợp lệ không
                    if (columnIndex > 0 && columnIndex < totalTextList.Count)
                    {
                        
                        // Lấy nội dung tiêu đề từ danh sách
                        string totalText = totalTextList[columnIndex].ToString();

                        // Tạo một ô (cột) mới cho XRTable với nội dung là tiêu đề
                        XRTableCell totalCell = new XRTableCell()
                        {
                            Text = totalText,
                            //Borders = DevExpress.XtraPrinting.BorderSide.All,
                            TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter,
                            Width = 150
                        };

                        totalCell.Font = new Font(totalCell.Font.FontFamily, 9, FontStyle.Regular);
                        // Nếu là cột đầu tiên, đặt độ đậm cho font
                        

                        // Thêm ô vào dòng tiêu đề
                        totalRow.Cells.Add(totalCell);
                    }
                    else
                    {
                        // Hiển thị thông báo hoặc xử lý trường hợp không hợp lệ tại đây
                    }
                }

                // Thêm dòng tiêu đề vào XRTable
                this.xrTable1.Rows.Add(totalRow);

                // Tạo một dòng mới cho XRTable
                XRTableRow mergeSumRow = new XRTableRow();

                // Tạo một ô duy nhất cho dòng merge và center
                XRTableCell mergeSumCell = new XRTableCell()
                {
                    Text = sumCP.ToString(),
                    WidthF = 450, // Độ rộng của ô dọc theo tất cả các cột
                                  //Borders = DevExpress.XtraPrinting.BorderSide.All, // Hiển thị đường viền
                    TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter, // Canh giữa nội dung
                };

                mergeSumCell.Font = new Font(mergeSumCell.Font.FontFamily, 9, FontStyle.Bold);
                // Thêm ô vào dòng merge
                mergeSumRow.Cells.Add(mergeSumCell);

                // Thêm dòng merge vào XRTable
                this.xrTable1.Rows.Add(mergeSumRow);
            }
            else
            {
                // Hiển thị thông báo hoặc xử lý trường hợp không có dữ liệu hoặc không có cột để hiển thị tại đây
            }
        }

    }
}
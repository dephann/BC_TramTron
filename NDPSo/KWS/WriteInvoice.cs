using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace NDPSo.KWS
{
    public class WriteInvoice
    {
        public void WriteDetailInvoice()
        {
            string filePath = "path/to/your/document.docx";

            // Dữ liệu để cập nhật bảng
            List<decimal> totalTextList = new List<decimal> { 100, 200, 300 };
            List<string> headerTextList = new List<string> { "Header1", "Header2", "Header3" };
            DataTable dataTable = new DataTable();
            decimal sumCP = 12345; // Thay thế bằng giá trị thực của bạn
            int[] targetColumnIndexes = { 0, 1, 2 }; // Thay thế bằng chỉ mục cột thực tế của bạn

            // Gọi hàm cập nhật bảng
            UpdateTableColumns(filePath, totalTextList, headerTextList, dataTable, sumCP, targetColumnIndexes);

        }
        static void UpdateTableColumns(string filePath, List<decimal> totalTextList, List<string> headerTextList, DataTable dataTable, decimal sumCP, params int[] targetColumnIndexes)
        {

            using (WordprocessingDocument doc = WordprocessingDocument.Open(filePath, true))
            {
                // Lấy bảng đầu tiên trong tài liệu Word
                var table = doc.MainDocumentPart.Document.Body.Descendants<Table>().FirstOrDefault();

                if (table != null)
                {
                    // Xóa tất cả các dòng hiện tại trong bảng
                    table.RemoveAllChildren<TableRow>();

                    // Tạo dòng tiêu đề và thêm vào bảng
                    AddRowToTable(table, headerTextList, true);

                    // Lặp qua mỗi dòng trong DataTable để thêm dữ liệu
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Tạo dòng dữ liệu và thêm vào bảng
                        AddRowToTable(table, row.ItemArray.Select(item => item.ToString()).ToList(), false);
                    }

                    // Tạo dòng tổng và thêm vào bảng
                    AddRowToTable(table, totalTextList.Select(total => total.ToString()).ToList(), false);

                    // Tạo dòng tổng cộng và thêm vào bảng
                    AddRowToTable(table, new List<string> { "Tổng cộng", sumCP.ToString() }, false);
                }

                // Lưu các thay đổi
                doc.MainDocumentPart.Document.Save();
            }
        }

        static void AddRowToTable(Table table, List<string> cellValues, bool isHeader)
        {
            var row = new TableRow();

            foreach (var value in cellValues)
            {
                var cell = new TableCell(new Paragraph(new Run(new Text(value))))
                {
                    TableCellProperties = new TableCellProperties
                    {
                        TableCellWidth = new TableCellWidth { Type = TableWidthUnitValues.Dxa, Width = "150" }, // Điều chỉnh theo nhu cầu của bạn
                        //TableCellVerticalAlignment = new VerticalAlignment { Val = TableVerticalAlignmentValues.Center }
                    }
                };

                if (isHeader)
                {
                    cell.TableCellProperties = new TableCellProperties(new TableCellBorders(new TopBorder(), new BottomBorder(), new LeftBorder(), new RightBorder()));
                    //cell.Paragraph.ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center });
                    //cell.Paragraph.ParagraphProperties.ParagraphStyleId = new ParagraphStyleId { Val = "Heading1" }; // Thay đổi theo nhu cầu của bạn
                }
                else
                {
                    //cell.Paragraph.ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center });
                }

                row.Append(cell);
            }

            table.Append(row);
        }
    }
}

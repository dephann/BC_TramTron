using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.Pdf;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using System.Collections.Generic;

namespace NDPSo.Utils
{
    public class WriteInvoice
    {
        public string folderPhieuThuc;
        public bool inTrucTiep;
        public WriteInvoice()
        {
        }

        public bool WriteDetailInvoiceTPCP(string[] param, GridView gridView, int somauphieu, int sobanin)
        {
            try
            {
                // Copy template Word document
                string templatePath = "MAUTPCP" + somauphieu + ".docx";
                string outputPath = Path.Combine(folderPhieuThuc, "MAUTPCP" + somauphieu + ".pdf");

                // Load the template document
                using (RichEditDocumentServer richEdit = new RichEditDocumentServer())
                {
                    richEdit.LoadDocument(templatePath);

                    // Replace placeholders in the document with values from the param array
                    for (int i = 0; i < param.Length; i++)
                    {
                        string bereplaced = "{" + i + "}";
                        ReplacePlaceholder(richEdit, bereplaced, param[i]);
                    }

                    // Create a table in the document based on the data in the gridView
                    //  CreateTableCP(richEdit, gridView);

                    // Save the document as a PDF
                    richEdit.ExportToPdf(outputPath);
                }

                // Print or open the PDF based on the inTrucTiep flag
                if (inTrucTiep)
                {
                    for (int i = 0; i < sobanin; i++)
                    {
                        //Utilities.PrintReport(outputPath);
                    }
                }
                else
                {
                    Process.Start(outputPath);
                }

                // Optionally, delete the temporary Word document
                File.Delete(templatePath);

                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        private void ReplacePlaceholder(RichEditDocumentServer richEdit, string placeholder, string replacement)
        {
            Document document = richEdit.Document;

            string documentText = document.Text;

            documentText = documentText.Replace(placeholder, replacement);

            document.Delete(document.Range);

            document.AppendText(documentText);
        }

        private void CreateTableCP(Document doc, GridView gridView)
        {
            // Your existing code to get the DataTable and list of columns
            DataTable dataTable = (DataTable)gridView.GridControl.DataSource;
            List<string> list = new List<string>();
            int num = 0;
            Table table = doc.Tables.Create(doc.Range.End, num, 1);

            // Set table formatting
            table.PreferredWidth = DevExpress.Office.Utils.Units.InchesToDocumentsF(6f); // Adjust the width as needed
           
            // Add header row
            TableRow headerRow = table.Rows[0];
            /*for (int i = 0; i < num; i++)
            {
                headerRow.Cells[i].BeginUpdate();
                headerRow.Cells[i].Range.Text = list[i];
                headerRow.Cells[i].EndUpdate();
            }
            headerRow.Bold = true;

            // Add data rows
            for (int i = 0; i < gridView.RowCount; i++)
            {
                TableRow dataRow = table.Rows[i + 1];
                for (int j = 0; j < num; j++)
                {
                    dataRow.Cells[j].BeginUpdate();
                    dataRow.Cells[j].Range.Text = gridView.GetRowCellValue(i, gridView.Columns[list[j]]).ToString();
                    dataRow.Cells[j].EndUpdate();
                }
            }

            // Add total row
            TableRow totalRow = table.Rows[gridView.RowCount + 1];
            totalRow.MergeCells(0, num - 1);
            totalRow.Cells[0].BeginUpdate();
            totalRow.Cells[0].Range.Text = "Tổng";
            totalRow.Cells[0].EndUpdate();
            totalRow.Bold = true;

            // Calculate and add sum row
            TableRow sumRow = table.Rows[gridView.RowCount + 2];
            sumRow.Cells[0].BeginUpdate();
            sumRow.Cells[0].Range.Text = dataTable.Compute("SUM([" + list[1] + "])", "").ToString(); // Change the column name as needed
            sumRow.Cells[0].EndUpdate();
            sumRow.Bold = true;
*/
            // Add additional rows if needed
            // ...

            // Your existing code for styling and additional rows
            // ...
        }
    }
}

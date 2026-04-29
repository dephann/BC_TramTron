using Microsoft.Office.Interop.Word;
using NDPSo.MasterData.Config;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Task = System.Threading.Tasks.Task;

namespace NDPSo.MasterData
{
    public partial class VanHanh
    {
        #region Printing & Reporting

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            LoadParam();
        }
        private void LoadParam()
        {
            //FrmPrintGiaoHang frm = new FrmPrintGiaoHang();
            paras.Clear();
            paras.Add(ConfigManager.TramTronConfig.TenCty);
            paras.Add(this._selectedPT_Run.NgayPhieuTron.Value.ToString("dd/MM/yyyy"));
            paras.Add(lblTenCongTruong.Text);
            paras.Add(lblTenKhachHang.Text);
            paras.Add(lblMAC.Text);
            paras.Add(this._selectedPT_Run.NPMACCuongDo);
            paras.Add(this.lblSoPhieuTron.Text);
            paras.Add("200");
            paras.Add(this._selectedPT_Run.NPMACDoSut);
            paras.Add(lblDriver.Text);
            paras.Add(ConfigManager.TramTronConfig.KLChoLonNhat.ToString() + "m³");
            paras.Add(lblKhoiLuong.Text + "m³");
            paras.Add(_LuyKe_InNhanh.ToString() + "m³");
            paras.Add(lblXe.Text);
            paras.Add(this._selectedPT_Run.NgayPhieuTron.Value.ToString("HH: mm:ss"));
            paras.Add(this._selectedPT_Run.NPCongTruongDiaChi);
            paras.Add(this._selectedPT_Run.MaPhieuTron);
            paras.Add(lblKhoiLuong.Text);
            paras.Add(lblTenHangMuc.Text);
            paras.Add(lblNiemChi.Text);
            paras.Add(this.lblNguoiTron.Text);
            paras.Add(this.lblDiaDiem.Text);
            DateTime originalDateTime = this._selectedPT_Run.NgayPhieuTron.Value;
            DateTime modifiedDateTime = originalDateTime.AddMinutes(5);
            paras.Add(modifiedDateTime.ToString("HH: mm:ss"));

            if (ConfigManager.TramTronConfig.InPITuMau) // In Phiếu Trộn từ mẫu có sẳn được load từ file
            {
                WriteDetailInvoice(paras);
                PrintPTFromFile();
            }
            else
            {
               /* frm.FillDataPrinter(paras);
                frm.PrintPhieuTron();*/
            }
            
        }
        private void PrintPTFromFile()
        {
            try
            {
                string sourceFileName = ConfigManager.TramTronConfig.PIPath;

                string fileName = "";
                string filePathMau = ConfigManager.TramTronConfig.PIPath;
                if (filePathMau != string.Empty)
                {
                    fileName = Path.GetFileName(filePathMau);
                }
                string folderDesPhieuPath = ConfigManager.TramTronConfig.ReportPath;
                string wordFilePath = Path.Combine(folderDesPhieuPath, fileName);
                string pdfFilePath = Path.ChangeExtension(wordFilePath, ".pdf");

                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

                // Export Word document as PDF
                var wordDoc = wordApp.Documents.Add(wordFilePath);
                wordApp.ActiveDocument.ExportAsFixedFormat(pdfFilePath, WdExportFormat.wdExportFormatPDF);

                // Close and release Word document
                wordDoc.Close(false);
                Marshal.ReleaseComObject(wordDoc);

                // Delete the Word document
                if (File.Exists(wordFilePath))
                {
                    try
                    {
                        File.Delete(wordFilePath);
                        PrinterInvoke(pdfFilePath, 1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xóa tệp tin Word: {ex.Message}");
                        TramTronLogger.WriteError(ex);
                    }
                }

                /*if (File.Exists(pdfFilePath))
                {
                    // In file PDF vừa tạo
                   
                }
                else
                {
                    TramTromMessageBox.ShowMessageDialog("Không tìm thấy file PDF để in");
                }*/

                wordApp.Quit();
            }
            catch (Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        public bool PrinterInvoke(string pdfFilePath, int numberOfCopies)
        {
            try
            {
                Task[] printTasks = new Task[numberOfCopies];

                for (int i = 0; i < numberOfCopies; i++)
                {
                    int copyIndex = i;
                    printTasks[i] = System.Threading.Tasks.Task.Run(() => Support.PrintReport(pdfFilePath));
                }

                Task.WaitAll(printTasks);

                return true;
            }
            catch (Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
            return false;
        }
        private void PrintPDF(string pdfFilePath)
            {
                try
                {
                    // Hiển thị hộp thoại chọn máy in
                    string printerName = ConfigManager.TramTronConfig.MayInPI;

                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Verb = "printto",
                        FileName = pdfFilePath,
                        UseShellExecute = true,
                        Arguments = $"\"{printerName}\""
                    };

                    using (Process process = new Process { StartInfo = startInfo }) // Kiem tra lai qua trinh in
                    {
                        process.Start();
                        process.WaitForExit(); // Chờ đến khi quá trình in kết thúc
                        //TramTromMessageBox.ShowMessageDialog("In file hoàn tất");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi in file PDF: {ex.Message}");
                    TramTronLogger.WriteError(ex);
                }
            }
        private void WriteDetailInvoice(List<string> param)
        {
            try
            {
                if (CopyTempFile() && !this._error)
                {
                    string sourceFileName = ConfigManager.TramTronConfig.PIPath;

                    string fileName = "";
                    string filePathMau = ConfigManager.TramTronConfig.PIPath;
                    if (filePathMau != string.Empty)
                    {
                        fileName = Path.GetFileName(filePathMau);
                    }
                    string folderDesPhieuPath = ConfigManager.TramTronConfig.ReportPath;

                    string filePath = Path.Combine(folderDesPhieuPath, fileName);

                    Microsoft.Office.Interop.Word.Application wordProcessor = new Microsoft.Office.Interop.Word.Application();

                    Microsoft.Office.Interop.Word.Document document = wordProcessor.Documents.Open(filePath);

                    for (int index = 0; index < param.Count; ++index)
                    {
                        string findText = "{" + index + "}";
                        ReplaceText(wordProcessor, findText, param[index]);
                    }

                    //managerLoadDataToTable(wordProcessor, dataTable);
                    wordProcessor.ActiveDocument.SaveAs(filePath, 12);
                    wordProcessor.Quit();

                }
            }
            catch (Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        private bool CopyTempFile()
        {

            string sourceFileName = ConfigManager.TramTronConfig.PIPath;

            string fileName = "";
            string filePath = ConfigManager.TramTronConfig.PIPath;
            if (filePath != string.Empty)
            {
                fileName = Path.GetFileName(filePath);
            }

            string folderDesPhieuPath = ConfigManager.TramTronConfig.ReportPath;

            string str = Path.Combine(folderDesPhieuPath, fileName);

            try
            {
                if (!File.Exists(str))
                    File.Copy(sourceFileName, str, true);
                this._error = false;
            }
            catch (Exception ex)
            {
                this._error = true;
                TramTromMessageBox.ShowErrorDialog(ex.ToString());

            }
            return true;
        }
        private void ReplaceText(Microsoft.Office.Interop.Word.Application word, string searchText, string replacementText)
        {
            Microsoft.Office.Interop.Word.Selection selection = word.Selection;

            Microsoft.Office.Interop.Word.Find find = selection.Find;
            find.ClearFormatting();
            find.Text = searchText;

            Microsoft.Office.Interop.Word.Replacement replacement = find.Replacement;
            replacement.ClearFormatting();
            replacement.Text = replacementText;

            object missing = System.Reflection.Missing.Value;
            object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

            find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);
        }

        #endregion
    }
}
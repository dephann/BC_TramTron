using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Utils
{
    public class WriteDataParam
    {
        private string folderPhieuThuc;
        public bool WriteDataPT(string[] param)
        {
            try
            {
                string templateFileName = $"MAUTPCP.docx";
                if (!CopyTempFile(templateFileName))
                {
                    return false;
                }

                Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();

                try
                {

                    string documentPath = Path.Combine(folderPhieuThuc, templateFileName);
                    Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(documentPath);

                    for (int index = 0; index < param.Length; ++index)
                    {
                        string placeholder = "{" + index + "}";
                        FillParam(wordApp, placeholder, param[index]);
                    }

                    //CreateTableCP(doc, gridView);

                    string pdfFilePath = Path.Combine(folderPhieuThuc, $"MAUTPCP.pdf");
                    doc.SaveAs2(pdfFilePath, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF);

                    doc.Close();
                }
                finally
                {
                    wordApp.Quit();
                    Marshal.ReleaseComObject(wordApp);
                }

            // Delete temporary Word document
                File.Delete(Path.Combine(folderPhieuThuc, templateFileName));

                /*if (inTrucTiep)
                {
                // Print the PDF multiple times if needed
                    for (int index = 0; index < sobanin; ++index)
                    {
                        //Utilities.PrintReport(pdfFilePath);
                    }
                }
                else
                {
                // Open the PDF with the default PDF viewer
                    Process.Start(pdfFilePath);
                }*/

                 return true;
            }
            catch (COMException ex)
            {
            // Log and show COMException details
                //Utilities.logException(Resources.khongthemoMSWord, ex.Message, ex.StackTrace, Utilities.GetCurrentDateTime());
                //MessageBox.Show(Resources.khongthemoMSWord, Resources.tenphanmem, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            catch (Exception ex)
            {
        // Log and show generic exception details
                //Utilities.logException("Không thể viết phiếu!", ex.Message, ex.StackTrace, Utilities.GetCurrentDateTime());
                //MessageBox.Show(Resources.khongthevietphieuxuat, Resources.tenphanmem, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            return false;
        }

        private void FillParam(Microsoft.Office.Interop.Word.Application wordApp, string placeholder, string replacement)
        {
            Microsoft.Office.Interop.Word.Find find = wordApp.Selection.Find;

            find.ClearFormatting();

            find.Text = placeholder;

            find.Replacement.ClearFormatting();
            find.Replacement.Text = replacement;

            object missing = Missing.Value;
            object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;
            find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);
        }

        private bool CopyTempFile(string fileName)
        {
            try
            {
                string folderMauPhieu = Path.Combine(Directory.GetCurrentDirectory(), "MAUPHIEU");
                string folderPhieuThuc = Path.Combine(Directory.GetCurrentDirectory(), "PHIEUTHUC");

                string sourceFileName = Path.Combine(folderMauPhieu, fileName);
                string destinationFilePath = Path.Combine(folderPhieuThuc, fileName);

                if (!Directory.Exists(folderPhieuThuc))
                {
                    Directory.CreateDirectory(folderPhieuThuc);
                }

                File.Copy(sourceFileName, destinationFilePath, true);

                //this.error = false;

                return true;
            }
            catch (DirectoryNotFoundException ex)
            {
                // Handle directory not found exception
                //Utilities.logException(string.Format(Resources.duongdandenthumucsai, "Phiếu thực"), ex.Message, ex.StackTrace, Utilities.GetCurrentDateTime());
                return false;
            }
            catch (IOException ex)
            {
                // Handle file copy exception
                //this.error = true;
                //MessageBox.Show(Resources.khongTimThayMauPhieu, Resources.tenphanmem, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                //FrmProgressBar.FinishShowProgress();
                //FrmExceptionNotifier.ShowAndLog(ex);
                return false;
            }
        }
    }
}

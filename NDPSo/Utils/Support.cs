using DevExpress.XtraEditors;
using NDPSo.Data;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Word.Application;

namespace NDPSo.Utils
{
    public class Support
    {


        public static string GetNextNiemChi(string inputString)
        {
            string resultString = "";
            string numericPart = new string(inputString.SkipWhile(c => c == '0').ToArray());

            if (int.TryParse(numericPart, out int intValue))
            {
                intValue++;

                resultString = new string('0', inputString.Length - numericPart.Length) + intValue.ToString();

                return resultString;

            }
            else
            {
                return resultString;
            }
        }

        public static void GetListSiloLogic(BindingList<ObjSilo> _blstSiloLogic, BindingList<ObjSilo> _blstSiloLogic1, LookUpEdit lue1, LookUpEdit lue2)
        {
            _blstSiloLogic1.Clear();
            foreach (ObjSilo siloLogic in _blstSiloLogic)
            {
                if (siloLogic.SiloID != (int)lue1.EditValue)
                {
                    _blstSiloLogic1.Add(siloLogic);
                }
            }
            lue2.Properties.DataSource = _blstSiloLogic1;
        }
        public static void GetListSiloLogic(BindingList<ObjSilo> _blstSiloLogic, LookUpEdit lue1)
        {
            BindingList<ObjSilo> _list = new BindingList<ObjSilo>();
            foreach (ObjSilo siloLogic in _blstSiloLogic)
            {
                if (siloLogic.SiloID != (int)lue1.EditValue)
                {
                    _list.Add(siloLogic);
                }
            }
            _blstSiloLogic.Clear();
            _blstSiloLogic = _list;
        }

        public static void UpdateListSiloLogic(BindingList<ObjSilo> _blstSiloLogic, string maSilo)
        {
            BindingList<ObjSilo> _list = new BindingList<ObjSilo>();
            foreach (ObjSilo siloLogic in _blstSiloLogic)
            {
                if (siloLogic.MaSilo == maSilo)
                {
                    //return;
                    //continue;
                }
                else
                    _list.Add(siloLogic);
            }
            _blstSiloLogic.Clear();
            foreach (ObjSilo silo in _list)
            {
                _blstSiloLogic.Add(silo);
            }
        }

        public static void SetValueSpinZero(SpinEdit spinEdit)
        {
            if (spinEdit != null && spinEdit.Value < 0)
            {
                spinEdit.Value = 0;
            }
        }
        public static void ResetValueLueLogic(LookUpEdit lue1, LookUpEdit lue2)
        {
            lue1.EditValue = (object)null;
            lue2.EditValue = (object)null;
        }

        public static double GetValueLogic(LookUpEdit lue1, LookUpEdit lue2, string nhomSilo)
        {
            double numlogic = 0;
            string _numberSiloLogic = "";

            if (!ValidateData(lue1, lue2))
            {
                return numlogic;
            }
            else
            {
                switch (nhomSilo)
                {
                    case "AG":
                        _numberSiloLogic = GetNumLogicSiloAG(lue1).ToString() + GetNumLogicSiloAG(lue2).ToString();
                        break;
                    case "CE":
                        _numberSiloLogic = GetNumLogicSiloCE(lue1).ToString() + GetNumLogicSiloCE(lue2).ToString();
                        break;
                    case "AD":
                        _numberSiloLogic = GetNumLogicSiloAD(lue1).ToString() + GetNumLogicSiloAD(lue2).ToString();
                        break;
                }
                string a = _numberSiloLogic;
                numlogic = double.Parse(a);
                return numlogic;
            }
        }
        private static bool ValidateData(LookUpEdit lue1, LookUpEdit lue2)
        {
            bool flag = true;
            if (lue1.EditValue == null)
            {
                lue1.ErrorText = "Silo is requied";
                flag = false;
            }
            if (lue2.EditValue == null)
            {
                lue2.ErrorText = "Silo is requied";
                flag = false;
            }
            return flag;
        }
        private static int GetNumLogicSiloAG(LookUpEdit lueSiloLogic)
        {
            int a = 0;
            string maSilo = lueSiloLogic.GetColumnValue("MaSilo").ToString();
            switch (maSilo)
            {
                case "Agg1":
                    a = 1;
                    break;
                case "Agg2":
                    a = 2;
                    break;
                case "Agg3":
                    a = 3;
                    break;
                case "Agg4":
                    a = 4;
                    break;
                case "Agg5":
                    a = 5;
                    break;
                case "Agg6":
                    a = 6;
                    break;
                default:
                    break;
            }
            return a;
        }
        private static int GetNumLogicSiloCE(LookUpEdit lueSiloLogic)
        {
            int a = 0;
            string maSilo = lueSiloLogic.GetColumnValue("MaSilo").ToString();
            switch (maSilo)
            {
                case "Ce1":
                    a = 1;
                    break;
                case "Ce2":
                    a = 2;
                    break;
                case "Ce3":
                    a = 3;
                    break;
                case "Ce4":
                    a = 4;
                    break;
                case "Ce5":
                    a = 5;
                    break;
                default:
                    break;
            }
            return a;
        }
        private static int GetNumLogicSiloAD(LookUpEdit lueSiloLogic)
        {
            int a = 0;
            string maSilo = lueSiloLogic.GetColumnValue("MaSilo").ToString();
            switch (maSilo)
            {
                case "Add1":
                    a = 1;
                    break;
                case "Add2":
                    a = 2;
                    break;
                case "Add3":
                    a = 3;
                    break;
                case "Add4":
                    a = 4;
                    break;
                case "Add5":
                    a = 5;
                    break;
                case "Add6":
                    a = 6;
                    break;
                default:
                    break;
            }
            return a;
        }

        public static double SetUpLogic(LookUpEdit lue1, LookUpEdit lue2, string nhomSilo)
        {
            if (lue1.Text == string.Empty || lue2.Text == string.Empty)
            {
                return GetValueLogic(lue1, lue2, nhomSilo);
                TramTromMessageBox.ShowMessageDialog("Đã đưa LOGIC về trạng thái ban đầu.");
            }
            else
            {
                string str1 = lue1.Text.ToString();
                string str2 = lue2.Text.ToString();
                string str = string.Format("Xác nhận thực hiện thiết lập {0} - LOGIC - {1} ?", str1, str2);

                if (TramTromMessageBox.ShowYesNoDialog(str) != DialogResult.Yes)
                    return 0;
                return GetValueLogic(lue1, lue2, nhomSilo);
            }
        }

        public static bool CheckSiloLogic(BindingList<ObjSilo> bllst, string maSilo)
        {
            bool flag = true;
            foreach (ObjSilo silo in bllst)
            {
                if (silo.MaSilo != maSilo)
                    flag = false;
            }
            return flag;
        }

        public static string SecondToHour(int sec)
        {
            int hours = sec / 3600;
            int minutes = (sec % 3600) / 60;
            int seconds = sec % 60;
            string timer = "PHẦN MỀM SẼ TỰ ĐỘNG CẬP NHẬT SAU: " + $"{hours} Giờ, {minutes} Phút, {seconds} Giây";
            return timer;
        }

        public static void PrintReport(string path)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    Verb = "print",
                    FileName = path,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                });
            }
            catch (Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        public static void PrintReportPDF(string path)
        {
            try
            {
                string printerApp = ConfigManager.TramTronConfig.PdfReaderPath;

                if (!File.Exists(printerApp))
                {
                    TramTromMessageBox.ShowErrorDialog("Foxit Reader not found.");
                    return;
                }

                ProcessStartInfo printProcessInfo = new ProcessStartInfo
                {
                    FileName = printerApp,
                    Arguments = $"/t \"{path}\"", // /t để in file PDF mà không hiện lên UI
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                };

                using (Process printProcess = new Process { StartInfo = printProcessInfo })
                {
                    printProcess.Start();
                    printProcess.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }

        public static void PrintReportWord(string path)
        {
            try
            {
                if (!File.Exists(path))
                {
                    TramTromMessageBox.ShowErrorDialog("Word file not found.");
                    return;
                }

                Application wordApp = new Application();

                Document wordDoc = wordApp.Documents.Open(path);

                wordDoc.PrintOut();

                wordDoc.Close(false);
                wordApp.Quit();

                // Giải phóng tài nguyên
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            }
            catch (Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }


    public static void CloseWordApplications()
        {
            string[] targetProcesses = { "winword", "acrobat", "FoxitReader", "FoxitPhantomPDF" };

            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    foreach (string targetProcess in targetProcesses)
                    {
                        if (process.ProcessName.ToLower().Contains(targetProcess))
                        {
                            process.Kill();
                            Console.WriteLine($"Đã đóng ứng dụng {targetProcess}.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi: " + ex.Message);
                }
            }
            Process[] processesByName = Process.GetProcessesByName("FoxitPDFReader");
            if (processesByName.Length != 0)
            {
                processesByName[0].Kill();
            }
        }

        public static string[] ReadWordFile(string filePath)
        {
            Application wordApp = new Application();
            Document doc = wordApp.Documents.Open(filePath);

            // Đọc toàn bộ nội dung văn bản từ tài liệu Word
            string text = doc.Content.Text;
            doc.Close();
            wordApp.Quit();

            // Trả về nội dung chia thành các dòng
            return text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static void WriteToExcel(string filePath, string[] lines)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Worksheets[1];

            // Ghi nội dung vào worksheet
            for (int i = 0; i < lines.Length; i++)
            {
                worksheet.Cells[i + 1, 1].Value = lines[i];
            }

            // Lưu tệp Excel
            workbook.SaveAs(filePath);
            workbook.Close();
            excelApp.Quit();

            // Giải phóng tài nguyên COM
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }
        public static void ReadTableFromWordAndWriteToExcel(string wordFile, string excelFile)
        {
            Application wordApp = new Application();
            Document doc = wordApp.Documents.Open(wordFile);

            // Đọc toàn bộ nội dung văn bản từ tài liệu Word
            string text = doc.Content.Text;
            doc.Close();
            wordApp.Quit();

            // Xử lý nội dung văn bản để phân chia dữ liệu thành các dòng và cột
            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Khởi tạo ứng dụng Excel
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Worksheets[1];

            // Ghi dữ liệu vào Excel
            for (int i = 0; i < lines.Length; i++)
            {
                // Giả sử mỗi dòng văn bản được phân tách bởi dấu phân cách (ví dụ: dấu phẩy hoặc tab)
                string[] columns = lines[i].Split(new[] { '\t', ',' }, StringSplitOptions.None);
                for (int j = 0; j < columns.Length; j++)
                {
                    worksheet.Cells[i + 1, j + 1].Value = columns[j].Trim();
                }
            }

            // Lưu tệp Excel
            workbook.SaveAs(excelFile);
            workbook.Close();
            excelApp.Quit();

            // Giải phóng tài nguyên COM
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }
        public static void ReadTextFromWordAndWriteToExcel(string wordFile, string excelFile)
        {
            Application wordApp = new Application();
            Document doc = wordApp.Documents.Open(wordFile);

            // Đọc toàn bộ nội dung văn bản từ tài liệu Word
            string text = doc.Content.Text;
            doc.Close();
            wordApp.Quit();

            // Chia văn bản thành các dòng
            string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Khởi tạo ứng dụng Excel
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Worksheets[1];

            // Ghi từng dòng văn bản vào ô đầu tiên của từng hàng trong worksheet
            for (int i = 0; i < lines.Length; i++)
            {
                worksheet.Cells[i + 1, 1].Value = lines[i];
            }

            // Lưu tệp Excel
            workbook.SaveAs(excelFile);
            workbook.Close();
            excelApp.Quit();

            // Giải phóng tài nguyên COM
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excelApp);
        }

        public static double GenerateFakeValue(decimal realValue, decimal lowerError, decimal upperError)
        {
            var valueCal = realValue * 0.005m;
            decimal lowerErrorN = lowerError + valueCal;
            decimal upperErrorN = upperError - valueCal;
            Random random = new Random();

            double randomError;
            if (random.Next(2) == 0)
            {
                randomError = (double)lowerErrorN + (double)(random.NextDouble() * (double)(upperErrorN - lowerErrorN) * 0.1);
            }
            else
            {
                randomError = (double)upperErrorN - (double)(random.NextDouble() * (double)(upperErrorN - lowerErrorN) * 0.1);
            }

            bool addOrSubtract = random.Next(2) == 0;
            double fakeValue = addOrSubtract ? (double)realValue + randomError : (double)realValue - randomError;

            return fakeValue;
        }


        public static double GenerateFakeValueADD(decimal realValue)
        {
            Random random = new Random();
            double randomError = (double)random.NextDouble();
            bool addOrSubtract = random.Next(2) == 0;

            double fakeValue;
            if (addOrSubtract)
            {
                fakeValue = (double)realValue + randomError;
            }
            else
            {
                fakeValue = (double)realValue - randomError;
            }

            return fakeValue;
        }
        public static double GenerateFakeValueN(decimal realValue, decimal errorPercent)
        {
            if (errorPercent < 0)
                throw new ArgumentException("Phần trăm sai số không thể âm");
            double errorRange = (double)realValue * (double)errorPercent / 100f;
            Random random = new Random();
            double randomError = (double)(random.NextDouble() * (2 * errorRange) - errorRange);

            return (double)realValue + randomError;
        }

    }
}
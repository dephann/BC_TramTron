using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using NDPSo.MasterData;
using NDPSo.Data;
using NDPSo.Utils;
using NDPSo.MasterData.Config;
using NDPSo.ClientSetting;
using Microsoft.Office.Interop.Word;
using Document = Microsoft.Office.Interop.Word.Document;
using System.IO;
using Application = Microsoft.Office.Interop.Word.Application;
using DevExpress.XtraEditors.Filtering.Templates;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace NDPSo.KWS
{
    public partial class PrinterPheuTron : ControlViewBase, IPhieuTronMngView, IBase, IPermission
    {
        private PhieuTronMngDataPresenter _presenter;
        private IServices _ser = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
        private BindingList<ObjPhieuTron> _blstPhieuTron = new BindingList<ObjPhieuTron>();
        private BindingList<ObjHopDong> _blstHopDong = new BindingList<ObjHopDong>();
        private BindingList<ObjMeTron> _blstMeTron = new BindingList<ObjMeTron>();
        private BindingList<ObjMeTronChiTiet> _blstMeTronChiTiet = new BindingList<ObjMeTronChiTiet>();
        
        private List<string> listPrinter = new List<string>();
        List<string> lst = new List<string>();

        private PrintDialog printDialog;
        private PrintDocument printDocument;
        private int userID;
        private int objectX = 100;
        private int objectY = 100;

        private bool _error;
        
        string sourceFileName = ConfigManager.TramTronConfig.PIPath;
        string fileName = "";
        string filePathMau = ConfigManager.TramTronConfig.PIPath;
        string folderDesPhieuPath = ConfigManager.TramTronConfig.ReportPath;

        private string printerName;
        private int numberOfCopies;
        private Thread thread;

        public PrinterPheuTron()
        {
            InitializeComponent();
            this._presenter = new PhieuTronMngDataPresenter((IPhieuTronMngView)this);
            SetCaption();

            float dpiX, dpiY;
            using (Graphics graphics = CreateGraphics())
            {
                dpiX = graphics.DpiX;
                dpiY = graphics.DpiY;
            }
        }

        public BindingList<ObjPhieuTron> BLstPhieuTron
        {
            set
            {
                this._blstPhieuTron = value;
                this.grcPhieuTron.DataSource = (object)this._blstPhieuTron;
            }
        }

        public BindingList<ObjHopDong> BLstHopDong
        {
            set
            {
                this._blstHopDong = value;
                //this.grcHopDong.DataSource = (object)this._blstHopDong;
                //this.ilueMaHopDong.DataSource = (object)this._blstHopDong;
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        public List<FieldCode> LstPhieuTronStatus { set => throw new NotImplementedException(); }
        public BindingList<ObjMeTron> BLstMeTron 
        {
            set
            {
                this._blstMeTron = value;
            } 
        }

        public BindingList<ObjMeTronChiTiet> BLstMeTronChiTiet 
        { 
            set
            {
                this._blstMeTronChiTiet = value;
            }
        }

        private void SuccessfullySave(bool isSuccess)
        {
            if (!isSuccess)
                return;
            this.grvPhieuTron.RefreshData();
        }
        protected override void PopulateStaticData()
        {
            //this._presenter.ListHopDong();
            this.LoadSearchDefaultValues();
            printerName = ConfigManager.TramTronConfig.MayInPI;
        }
        protected override void PopulateData() => this.LoadPhieuTron();


        private void LoadSearchDefaultValues()
        {
            //this.datTuNgay.EditValue = (object)DateTime.Now.AddDays(-(double)ConfigManager.TramTronConfig.LatestPhieuTronDays);
            this.datTuNgay.EditValue = (object)DateTime.Now.AddDays(-(double)ConfigManager.TramTronConfig.LatestPhieuTronDays);
            this.datDenNgay.EditValue = (object)DateTime.Now;

            DateTime endTime = DateTime.Now.Date.Add(new TimeSpan(23, 59, 59));
            tseToTime.EditValue = endTime.TimeOfDay;
        }

        private void LoadPhieuTron() => this._presenter.ListPhieuTron(string.Empty, Searching.BuildNew_StartDateTime(this.datTuNgay.DateTime, this.tseFromTime.TimeSpan), Searching.BuildNew_EndDateTime(this.datDenNgay.DateTime, this.tseToTime.TimeSpan), -1, new bool?());
            
        private void SetCaption()
        {
            this.Caption = "Phiếu giao hàng";
        }
        private void ClearDataPhieuTron()
        {
            this.datNgayTron.EditValue = "";
            this.txtGioTron.Text = "";
            this.txtGioKTTron.Text = "";
            this.txtMaPhieuTron.Text = string.Empty;
            this.txtSTTPhieuTron.Text = string.Empty;
            this.txtTenMAC.Text = string.Empty;
            this.txtCuongDo.Text = string.Empty;
            this.txtDoSut.Text = string.Empty;
            this.txtTheTich.Text = string.Empty;
            this.txtKhoiLuongDatHang.Text = string.Empty;
            this.txtLuyKe.Text = string.Empty;
            this.txtTenKhachHang.Text = string.Empty;
            this.txtTenCongTruong.Text = string.Empty;
            this.txtDiaDiem.Text = string.Empty;
            this.txtNiemChi.Text = string.Empty;
            this.txtNguoiTron.Text = string.Empty;
            this.txtTaiXe.Text = string.Empty;
            this.txtXe.Text = string.Empty;

        }

        
        private void DoFocusPhieuTron()
        {
            ClearDataPhieuTron();
            ObjPhieuTron objPhieuTron = this.grvPhieuTron.GetRow(this.grvPhieuTron.FocusedRowHandle) as ObjPhieuTron;
            if(objPhieuTron != null && objPhieuTron.PhieuTronID != null)
            {
                int? phieuTronID = objPhieuTron.PhieuTronID;
                int num = 0;
                if (!(phieuTronID.GetValueOrDefault() == num & phieuTronID != null)) 
                {
                     ObjPhieuTron phieuTronByKey = this._presenter.GetPhieuTronByKey(objPhieuTron.PhieuTronID);
                    if(phieuTronByKey == null)
                    {
                        return;
                    }
                    if (phieuTronByKey.CreatedBy.HasValue)
                    {
                        this.userID = (int)phieuTronByKey.CreatedBy;
                        ObjSEC_User user = _ser.GetSEC_UserByKey(userID);
                        txtNguoiTron.Text = user.FullName;
                    }
                    txtMaHopDong.Text = phieuTronByKey.NPHopDongMaHopDong;
                    datNgayTron.EditValue = phieuTronByKey.NgayPhieuTron;
                    txtGioTron.Text = phieuTronByKey.NgayPhieuTron.Value.ToString("HH:mm:ss");
                    if (phieuTronByKey.LatestUpdateDate.HasValue)
                    {
                        txtGioKTTron.Text = phieuTronByKey.LatestUpdateDate.Value.ToString("HH:mm:ss");
                    }
                    txtMaPhieuTron.Text = phieuTronByKey.MaPhieuTron;
                    txtSTTPhieuTron.Text = phieuTronByKey.NoPhieu.ToString();
                    txtTenMAC.Text = phieuTronByKey.NPMACTenMAC;
                    txtCuongDo.Text = phieuTronByKey.NPMACCuongDo;
                    txtDoSut.Text = phieuTronByKey.NPMACDoSut;
                    txtTenKhachHang.Text = phieuTronByKey.NPKhachHangTenKhachHang;
                    txtTenCongTruong.Text = phieuTronByKey.NPCongTruongTenCongTruong;
                    txtDiaDiem.Text = phieuTronByKey.NPCongTruongDiaChi;
                    txtHangMuc.Text = phieuTronByKey.NPHangMucTenHangMuc;
                    txtTaiXe.Text = phieuTronByKey.NPTaiXeTenTaiXe;
                    txtXe.Text = phieuTronByKey.NPXeBienSo;
                    txtNiemChi.Text = phieuTronByKey.MoTa;
                    txtTheTich.Text = phieuTronByKey.KLDuTinh.ToString();
                    txtLuyKe.Text = phieuTronByKey.KLThuc.ToString();
                    txtKhoiLuongDatHang.Text = phieuTronByKey.NPHopDongKLDatHang.ToString();

                    //List<ObjMeTronChiTiet> _listMeTronChiTiet = new List<ObjMeTronChiTiet>();
                    //this._presenter.ListMeTron(phieuTronID.Value);
                    //this.grcMeTron.DataSource = (object)this._blstMeTron;
                } 
            }
        }

       
        private void LoadPrinters()
        {
            try
            {
                
                foreach (string printerName in PrinterSettings.InstalledPrinters)
                {
                    listPrinter.Add(printerName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading printers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            lookupEditPrinters.Properties.DataSource = listPrinter;
            //lookupEditPrinters.EditValue = listPrinter[4];
        }

        private void PrinterPheuTron_Load(object sender, EventArgs e)
        {
            LoadPrinters();

            this.printDialog = new PrintDialog();
            this.printDocument = new PrintDocument();
            this.printDocument.PrintPage += new PrintPageEventHandler(this.PrintDocument_PrintPage);
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Define the content to be printed on the page
            string content = "Hello, this is the content to be printed.";

            // Set font and brush for drawing the content
            System.Drawing.Font font = new System.Drawing.Font("Arial", 12);
            Brush brush = Brushes.Black;

            // Draw the content on the page at the specified position
            e.Graphics.DrawString(content, font, brush, objectX, objectY);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            /*this.printDialog.Document = this.printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }*/
            List<string> lst = new List<string>();
            lst.Add(ConfigManager.TramTronConfig.TenCty);
            lst.Add(this.datNgayTron.DateTime.ToString("dd-MM-yyyy"));
            lst.Add(this.txtTenCongTruong.Text);
            lst.Add(this.txtTenKhachHang.Text);
            lst.Add(this.txtTenMAC.Text);
            lst.Add(this.txtCuongDo.Text);
            lst.Add(this.txtSTTPhieuTron.Text);
            lst.Add("200");
            lst.Add(this.txtDoSut.Text);
            lst.Add(this.txtTaiXe.Text);
            lst.Add(ConfigManager.TramTronConfig.KLChoLonNhat.ToString() + "m³");
            lst.Add(this.txtTheTich.Text + "m³");
            lst.Add(this.txtLuyKe.Text);
            lst.Add(this.txtXe.Text);
            lst.Add(txtGioTron.Text);
            lst.Add(this.txtDiaDiem.Text);
            lst.Add(this.txtMaPhieuTron.Text);
            lst.Add("1m³");
            lst.Add(this.txtHangMuc.Text);
            lst.Add(this.txtNiemChi.Text);
            lst.Add(this.txtNguoiTron.Text);
            lst.Add(this.txtGioKTTron.Text);

            //form.FillDataPrinter(lst);
            ////form.PrintPhieuTron();
            //form.ShowDialogPintPhieuTron();
        }

        private void simpleButton4_Click(object sender, EventArgs e) //Xem phiếu trộn chi tiết
        {
            /* PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
             printPreviewDialog.Document = printDocument;
             printPreviewDialog.ShowDialog();*/
            PrinterPheuTronChiTiet phieuTronChiTiet = new PrinterPheuTronChiTiet();
            ViewManager.ShowViewDialog(phieuTronChiTiet);

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            List<string> lst = new List<string>();
            lst.Add(ConfigManager.TramTronConfig.TenCty);
            lst.Add(this.datNgayTron.DateTime.ToString("dd-MM-yyyy"));
            lst.Add(this.txtTenCongTruong.Text);
            lst.Add(this.txtTenKhachHang.Text);
            lst.Add(this.txtTenMAC.Text);
            lst.Add(this.txtCuongDo.Text);
            lst.Add(this.txtSTTPhieuTron.Text);
            lst.Add("200");
            lst.Add(this.txtDoSut.Text);
            lst.Add(this.txtTaiXe.Text);
            lst.Add(ConfigManager.TramTronConfig.KLChoLonNhat.ToString() + "m³");
            lst.Add(this.txtTheTich.Text + "m³");
            lst.Add(this.txtLuyKe.Text);
            lst.Add(this.txtXe.Text);
            lst.Add(txtGioTron.Text);
            lst.Add(this.txtDiaDiem.Text);
            lst.Add(this.txtMaPhieuTron.Text);
            lst.Add("1m³");
            lst.Add(this.txtHangMuc.Text);
            lst.Add(this.txtNiemChi.Text);
            lst.Add(this.txtNguoiTron.Text);
            lst.Add(this.txtGioKTTron.Text);

            
            //form.FillDataPrinter(lst);
            //form.ShowDialogPreviewPrint();
        }

        private void grvPhieuTron_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DoFocusPhieuTron();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ClearDataPhieuTron();
            LoadPhieuTron();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadSearchDefaultValues();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(this.grvPhieuTron != null && this.grvPhieuTron.SelectedRowsCount != 0 )
            {
                this.btnPrint.Enabled = false;
                if (ConfigManager.TramTronConfig.InPITuMau) // In Phiếu Trộn từ mẫu có sẳn được load từ file
                {
                    this.PrintPTFromFile_NewTread();
                }
                else
                {
                    //form.PrintPhieuTron();
                }


            }
            /*lst.Clear();
            lst.Add(ConfigManager.TramTronConfig.TenCty);
            lst.Add(this.datNgayTron.DateTime.ToString("dd-MM-yyyy"));
            lst.Add(this.txtTenCongTruong.Text);
            lst.Add(this.txtTenKhachHang.Text);
            lst.Add(this.txtTenMAC.Text);
            lst.Add(this.txtCuongDo.Text);
            lst.Add(this.txtSTTPhieuTron.Text);
            lst.Add("200");
            lst.Add(this.txtDoSut.Text);
            lst.Add(this.txtTaiXe.Text);
            lst.Add(ConfigManager.TramTronConfig.KLChoLonNhat.ToString() + "m³");
            lst.Add(this.txtTheTich.Text + "m³");
            lst.Add(this.txtLuyKe.Text);
            lst.Add(this.txtXe.Text);
            lst.Add(txtGioTron.Text);
            lst.Add(this.txtDiaDiem.Text);
            lst.Add(this.txtMaPhieuTron.Text);
            lst.Add("1m³");
            lst.Add(this.txtHangMuc.Text);
            lst.Add(this.txtNiemChi.Text);
            lst.Add(this.txtNguoiTron.Text);
            lst.Add(this.txtGioKTTron.Text);*/

            //form.FillDataPrinter(lst);
            //form.ShowDialogPintPhieuTron();
            
        }

        private void PrintPTFromFile_NewTread() //BIT
        {
            thread = new Thread(new ThreadStart(this.PrintPTFromFile));
            thread.Start();
        }

        private void PrintPTFromFile()
        {
            GetParam();
            WriteDetailInvoice(lst);
            try
            {
                this.numberOfCopies = (int)spin_numberOfCopies.Value;
                if (filePathMau != string.Empty)
                {
                    fileName = Path.GetFileName(filePathMau);
                }
                
                string wordFilePath = Path.Combine(folderDesPhieuPath, fileName);
                string pdfFilePath = Path.ChangeExtension(wordFilePath, ".pdf");

                var wordApp = new Application();

                var wordDoc = wordApp.Documents.Add(wordFilePath);
                wordApp.ActiveDocument.ExportAsFixedFormat(pdfFilePath, WdExportFormat.wdExportFormatPDF);

                wordDoc.Close(false);
                Marshal.ReleaseComObject(wordDoc);

                if (File.Exists(wordFilePath))
                {
                    try
                    {
                        File.Delete(wordFilePath);
                        //PrintPDFAsync(pdfFilePath, numberOfCopies);
                        PrinterInvoke(pdfFilePath, numberOfCopies);
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine($"Lỗi khi xóa tệp tin Word: {ex.Message}");
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

        private async void PrintPDF(string pdfFilePath, int numberOfCopies)
        {
            try
            {
                for (int i = 0; i < numberOfCopies; i++)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Verb = "printto",
                        FileName = pdfFilePath,
                        UseShellExecute = true,
                        Arguments = $"\"{printerName}\""
                    };

                    using (Process process = new Process { StartInfo = startInfo })
                    {
                        process.Start();
                        //await System.Threading.Tasks.Task.Delay(1000); // Đợi 1 giây, bạn có thể điều chỉnh thời gian này tùy vào tốc độ của máy và quá trình in

                        /*while (!process.HasExited)
                        {
                            await System.Threading.Tasks.Task.Delay(100);
                        }*/
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi in file PDF: {ex.Message}");
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowMessageDialog(ex.Message);
            }
        }
        private async Task PrintPDFAsync(string pdfFilePath, int numberOfCopies)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

            try
            {
                for (int i = 0; i < numberOfCopies; i++)
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        Verb = "printto",
                        FileName = pdfFilePath,
                        UseShellExecute = true,
                        Arguments = $"\"{printerName}\""
                    };

                    using (Process process = new Process { StartInfo = startInfo })
                    {
                        process.Start();
                        process.WaitForExit(); // Chờ cho đến khi quá trình in hoàn tất
                    }
                }

                tcs.SetResult(true); // Đánh dấu việc in hoàn tất thành công
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi in file PDF: {ex.Message}");
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowMessageDialog(ex.Message);

                tcs.SetException(ex); // Đánh dấu việc in gặp lỗi
            }

            await tcs.Task;
        }
        public bool PrinterInvoke(string pdfFilePath, int numberOfCopies)
        {
            try
            {
                Task[] printTasks = new Task[numberOfCopies];

                for (int i = 0; i < numberOfCopies; i++)
                {
                    int copyIndex = i;
                    printTasks[i] = Task.Run(() => Support.PrintReport(pdfFilePath));
                }

                Task.WaitAll(printTasks);
                this.btnPrint.Enabled = true;
                return true;
            }
            catch(Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
            return false;
        }
        private void GetParam()
        {
            lst.Clear();
            lst.Add(ConfigManager.TramTronConfig.TenCty);
            lst.Add(this.datNgayTron.DateTime.ToString("dd-MM-yyyy"));
            lst.Add(this.txtTenCongTruong.Text);
            lst.Add(this.txtTenKhachHang.Text);
            lst.Add(this.txtTenMAC.Text);
            lst.Add(this.txtCuongDo.Text);
            lst.Add(this.txtSTTPhieuTron.Text);
            lst.Add("200");
            lst.Add(this.txtDoSut.Text);
            lst.Add(this.txtTaiXe.Text);
            lst.Add(ConfigManager.TramTronConfig.KLChoLonNhat.ToString() + "m³");
            lst.Add(this.txtTheTich.Text + "m³");
            lst.Add(this.txtLuyKe.Text);
            lst.Add(this.txtXe.Text);
            lst.Add(txtGioTron.Text);
            lst.Add(this.txtDiaDiem.Text);
            lst.Add(this.txtMaPhieuTron.Text);
            lst.Add("1m³");
            lst.Add(this.txtHangMuc.Text);
            lst.Add(this.txtNiemChi.Text);
            lst.Add(this.txtNguoiTron.Text);
            lst.Add(this.txtGioKTTron.Text);

            //WriteDetailInvoice(lst);
        }

        private void WriteDetailInvoice(List<string> param)
        {
            try
            {
                if (CopyTempFile() && !this._error)
                {
                    if (filePathMau != string.Empty)
                    {
                        fileName = Path.GetFileName(filePathMau);
                    }
                    string folderDesPhieuPath = ConfigManager.TramTronConfig.ReportPath;

                    string filePath = Path.Combine(folderDesPhieuPath, fileName);

                    Application wordProcessor = new Application();

                    Document document = wordProcessor.Documents.Open(filePath);

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
            if(filePath != string.Empty)
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            lst.Clear();
            lst.Add(ConfigManager.TramTronConfig.TenCty);
            lst.Add(this.datNgayTron.DateTime.ToString("dd-MM-yyyy"));
            lst.Add(this.txtTenCongTruong.Text);
            lst.Add(this.txtTenKhachHang.Text);
            lst.Add(this.txtTenMAC.Text);
            lst.Add(this.txtCuongDo.Text);
            lst.Add(this.txtSTTPhieuTron.Text);
            lst.Add("200");
            lst.Add(this.txtDoSut.Text);
            lst.Add(this.txtTaiXe.Text);
            lst.Add(ConfigManager.TramTronConfig.KLChoLonNhat.ToString() + "m³");
            lst.Add(this.txtTheTich.Text + "m³");
            lst.Add(this.txtLuyKe.Text);
            lst.Add(this.txtXe.Text);
            lst.Add(txtGioTron.Text);
            lst.Add(this.txtDiaDiem.Text);
            lst.Add(this.txtMaPhieuTron.Text);
            lst.Add("1m³");
            lst.Add(this.txtHangMuc.Text);
            lst.Add(this.txtNiemChi.Text);
            lst.Add(this.txtNguoiTron.Text);
            lst.Add(this.txtGioKTTron.Text);

            //form.FillDataPrinter(lst);
            //form.ShowDialogPreviewPrint();
        }

        private void spin_numberOfCopies_EditValueChanged(object sender, EventArgs e)
        {
            this.numberOfCopies = (int)spin_numberOfCopies.Value;
        }
    }
}

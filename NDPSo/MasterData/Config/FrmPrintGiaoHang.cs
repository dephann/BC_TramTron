using DevExpress.XtraEditors;
using NDPSo.KWS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Drawing.Printing;
using System.ComponentModel.DataAnnotations;
using NDPSo.Utils;
using NDPSo.Data;

namespace NDPSo.MasterData.Config
{
    public partial class FrmPrintGiaoHang : ControlViewBase, IBase, IPermission
    {

        private Dictionary<string, string> labelDictionary = new Dictionary<string, string>();
        private bool isDragging;
        private Point offset;
        int movementAmount = 5;
        private int pageWidthInPixels = 800; // Điều chỉnh kích thước theo cỡ trang in thực tế
        private int pageHeightInPixels = 1100;

        private PrintDialog printDialog;
        private PrintDocument printDocument;

        private ucLabelDataPrint selectedLabel = null;
        private ucTarrgetPoint selectedTarget = null;

        private WordprocessingDocument document;

        private List<string> _listPrinter = new List<string>();
        public FrmPrintGiaoHang()
        {
            InitializeComponent();
            InitializeLabelDictionary();
            InitializeLookupEdit();
            this.Caption = "Cấu hình tuỳ chỉnh phiếu in";
            CheckDataPrinter();
            LoadPrinters();
            LoadValuePrinter();
        }

        protected override void PopulateStaticData()
        {
            
        }
        private void InitializeLabelDictionary()
        {
            // Điều này đơn giản là một ví dụ, bạn có thể thay thế nó bằng dữ liệu thực tế của bạn.
            labelDictionary.Add("TenChuTram", "-Tên trạm");
            labelDictionary.Add("NgayTron", "-Ngày trộn");
            labelDictionary.Add("TenDuAn", "-Tên dự án");
            labelDictionary.Add("TenKhachHang", "-Khách hàng");
            labelDictionary.Add("TenMAC", "-MAC");
            labelDictionary.Add("CuongDo", "-Cường độ");
            labelDictionary.Add("SoPhieu", "-Số phiếu");
            labelDictionary.Add("CotLieuMax", "-Cốt liệu max");
            labelDictionary.Add("DoSut", "-Độ sụt");
            labelDictionary.Add("LaiXe", "-Lái xe");
            labelDictionary.Add("TheTichXeTron", "-Thể tích xe trộn");
            labelDictionary.Add("TheTichDatHang", "-Thể tích đặt hàng");
            labelDictionary.Add("LuyKe", "-Luỹ kế");
            labelDictionary.Add("BienSo", "-Biển số");
            labelDictionary.Add("TGBatDau", "-Giờ BĐ trộn");
            labelDictionary.Add("DiaDiemDuAn", "-Địa điểm dự án");
            labelDictionary.Add("MaPhieu", "-Mã phiếu trộn");
            labelDictionary.Add("TheTich1MeTron", "-Thể tích 1 mẻ trộn");
            labelDictionary.Add("TenHangMuc", "-Tên hạng mục");
            labelDictionary.Add("SoNiemChi", "-Số niêm chì");
            labelDictionary.Add("NhanVien", "-Nhân viên");
            labelDictionary.Add("TGKetThuc", "-Giờ KT trộn");

        }

        private void LoadValuePrinter()
        {
            checkEdit1.Checked = ConfigManager.TramTronConfig.InPITuMau;
            bteImportPIPath.Text = ConfigManager.TramTronConfig.PIPath;
            bteImportPICTPath.Text = ConfigManager.TramTronConfig.PICTPath;
            luePrinterPI.EditValue = ConfigManager.TramTronConfig.MayInPI;
            luePrinterPICT.EditValue = ConfigManager.TramTronConfig.MayInPICT;

        }

        private void InitializeLookupEdit()
        {
            // Gán nguồn dữ liệu cho Lookup Edit
            lookUpEdit1.Properties.DataSource = new BindingSource(labelDictionary, null);
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Word Documents (*.docx)|*.docx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                document = WordprocessingDocument.Open(openFileDialog.FileName, true);
                if (document != null)
                {
                    var body = document.MainDocumentPart.Document.Body;
                    var paragraphs = body.Elements<Paragraph>();

                    foreach (var paragraph in paragraphs)
                    {
                        string paragraphText = paragraph.InnerText;
                        string[] placeholders = paragraphText.Split(new[] { "{" }, StringSplitOptions.None);

                        if (placeholders.Length > 1)
                        {
                            string updatedText = placeholders[0];
                            for (int i = 1; i < placeholders.Length; i++)
                            {
                                int endBracketIndex = placeholders[i].IndexOf('}');
                                if (endBracketIndex != -1)
                                {
                                    int placeholderIndex;
                                    if (int.TryParse(placeholders[i].Substring(0, endBracketIndex), out placeholderIndex))
                                    {
                                        string replacement = GetReplacementValue(placeholderIndex); // Hàm lấy giá trị thay thế từ mảng chuỗi
                                        updatedText += replacement + placeholders[i].Substring(endBracketIndex + 1);
                                    }
                                    else
                                    {
                                        updatedText += "{" + placeholders[i];
                                    }
                                }
                                else
                                {
                                    updatedText += "{" + placeholders[i];
                                }
                            }

                            Run newRun = new Run(new Text(updatedText));
                            paragraph.RemoveAllChildren();
                            paragraph.Append(newRun);
                        }
                    }

                    document.MainDocumentPart.Document.Save();
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            /* OpenFileDialog openFileDialog = new OpenFileDialog();
             openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif; *.bmp)|*.jpg; *.jpeg; *.png; *.gif; *.bmp|All files (*.*)|*.*";

             if (openFileDialog.ShowDialog() == DialogResult.OK)
             {
                 string selectedImagePath = openFileDialog.FileName;
                 Image selectedImage = Image.FromFile(selectedImagePath);

                 //pictureBox1.Image = selectedImage;
                 //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize; // Đặt chế độ kích thước tự động.

                 Size imageSize = selectedImage.Size;
                // Size pictureBoxSize = pictureBox1.Size;

                 if (imageSize.Width == pictureBoxSize.Width && imageSize.Height == pictureBoxSize.Height)
                 {
                     MessageBox.Show("Ảnh có kích thước giống với PictureBox.");
                 }
                 else
                 {
                     MessageBox.Show("Ảnh không có kích thước giống với PictureBox.");
                 }
             }*/
        }

        // Hàm lấy giá trị thay thế từ mảng chuỗi
        private string GetReplacementValue(int index)
        {
            string[] replacements = { "Replacement1", "Replacement2", "Replacement3" }; // Mảng các giá trị thay thế
            if (index >= 0 && index < replacements.Length)
            {
                return replacements[index];
            }
            return "{" + index + "}";
        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            string selectedLabelKey = lookUpEdit1.EditValue.ToString();
            Console.WriteLine(selectedLabelKey);
            if (labelDictionary.ContainsKey(selectedLabelKey))
            {
                string labelText = labelDictionary[selectedLabelKey];
                CreateObjPointDataPrinter(labelText, selectedLabelKey, 100, 100);
            }
            
        }
        
        private void CreateObjPointDataPrinter(string name, string code, int x, int y)
        {
            ucLabelDataPrint newLabel = new ucLabelDataPrint();
            newLabel.Caption = name;
            newLabel.Code = code;
            newLabel.Location = new System.Drawing.Point(x, y);
            newLabel.ToaDo = "X:" + x + "-Y:" + y;
            newLabel.ButtonMouseDown += label_ButtonMouseDown;
            newLabel.ButtonMouseUp += label_ButtonMouseUp;
            newLabel.ButtonMouseMove += label_ButtonMouseMove;
            newLabel.ButtonMouseClick += label_MouseClick;
            panel1.Controls.Add(newLabel);
        }
        private void CreateTargetPoint()
        {
            ucTarrgetPoint targetPPoint = new ucTarrgetPoint();
            targetPPoint.Location = new System.Drawing.Point(20, 40);
            targetPPoint.ButtonMouseDown += target_ButtonMouseDown;
            targetPPoint.ButtonMouseUp += target_ButtonMouseUp;
            targetPPoint.ButtonMouseMove += target_ButtonMouseMove;
            targetPPoint.ButtonMouseClick += target_MouseClick;
            panel1.Controls.Add(targetPPoint);
        }
        private void CheckDataPrinter()
        {
            foreach (var dataPrinter in labelDictionary)
            {
                string key = dataPrinter.Key;
                string name = dataPrinter.Value;
                
                switch (key) {
                    case "TenChuTram":
                        if (ConfigManager.TramTronConfig.TenChuTram_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.TenChuTram_X, ConfigManager.TramTronConfig.TenChuTram_Y);
                        }
                        break;
                    case "NgayTron":
                        if (ConfigManager.TramTronConfig.NgayTron_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.NgayTron_X, ConfigManager.TramTronConfig.NgayTron_Y);
                        }
                        break;
                    case "TenDuAn":
                        if (ConfigManager.TramTronConfig.TenDuAn_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.TenDuAn_X, ConfigManager.TramTronConfig.TenDuAn_Y);
                        }
                        break;
                    case "TenKhachHang":
                        if (ConfigManager.TramTronConfig.TenKhachHang_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.TenKhachHang_X, ConfigManager.TramTronConfig.TenKhachHang_Y);
                        }
                        break;
                    case "TenMAC":
                        if (ConfigManager.TramTronConfig.TenMAC_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.TenMAC_X, ConfigManager.TramTronConfig.TenMAC_Y);
                        }
                        break;
                    case "CuongDo":
                        if (ConfigManager.TramTronConfig.CuongDo_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.CuongDo_X, ConfigManager.TramTronConfig.CuongDo_Y);
                        }
                        break;
                    case "SoPhieu":
                        if (ConfigManager.TramTronConfig.SoPhieu_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.SoPhieu_X, ConfigManager.TramTronConfig.SoPhieu_Y);
                        }
                        break;
                    case "CotLieuMax":
                        if (ConfigManager.TramTronConfig.CotLieuMax_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.CotLieuMax_X, ConfigManager.TramTronConfig.CotLieuMax_Y);
                        }
                        break;
                    case "DoSut":
                        if (ConfigManager.TramTronConfig.DoSut_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.DoSut_X, ConfigManager.TramTronConfig.DoSut_Y);
                        }
                        break;
                    case "LaiXe":
                        if (ConfigManager.TramTronConfig.LaiXe_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.LaiXe_X, ConfigManager.TramTronConfig.LaiXe_Y);
                        }
                        break;
                    case "TheTichXeTron":
                        if (ConfigManager.TramTronConfig.TheTichXeTron_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.TheTichXeTron_X, ConfigManager.TramTronConfig.TheTichXeTron_Y);
                        }
                        break;
                    case "TheTichDatHang":
                        if (ConfigManager.TramTronConfig.TheTichDatHang_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.TheTichDatHang_X, ConfigManager.TramTronConfig.TheTichDatHang_Y);
                        }
                        break;
                    case "LuyKe":
                        if (ConfigManager.TramTronConfig.LuyKe_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.LuyKe_X, ConfigManager.TramTronConfig.LuyKe_Y);
                        }
                        break;
                    case "BienSo":
                        if (ConfigManager.TramTronConfig.BienSo_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.BienSo_X, ConfigManager.TramTronConfig.BienSo_Y);
                        }
                        break;
                    case "TGBatDau":
                        if (ConfigManager.TramTronConfig.TGBatDau_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.TGBatDau_X, ConfigManager.TramTronConfig.TGBatDau_Y);
                        }
                        break;
                    case "DiaDiemDuAn":
                        if (ConfigManager.TramTronConfig.DiaDiemDuAn_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.DiaDiemDuAn_X, ConfigManager.TramTronConfig.DiaDiemDuAn_Y);
                        }
                        break;
                    case "MaPhieu":
                        if (ConfigManager.TramTronConfig.MaPhieu_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.MaPhieu_X, ConfigManager.TramTronConfig.MaPhieu_Y);
                        }
                        break;
                    case "TheTich1MeTron":
                        if (ConfigManager.TramTronConfig.TheTich1MeTron_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.TheTich1MeTron_X, ConfigManager.TramTronConfig.TheTich1MeTron_Y);
                        }
                        break;
                    case "TenHangMuc":
                        if (ConfigManager.TramTronConfig.TenHangMuc_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.TenHangMuc_X, ConfigManager.TramTronConfig.TenHangMuc_Y);
                        }
                        break;
                    case "SoNiemChi":
                        if (ConfigManager.TramTronConfig.SoNiemChi_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.SoNiemChi_X, ConfigManager.TramTronConfig.SoNiemChi_Y);
                        }
                        break;
                    case "NhanVien":
                        if (ConfigManager.TramTronConfig.NhanVien_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.NhanVien_X, ConfigManager.TramTronConfig.NhanVien_Y);
                        }
                        break;
                    case "TGKetThuc":
                        if (ConfigManager.TramTronConfig.TGKetThuc_Stus)
                        {
                            CreateObjPointDataPrinter(name, key, ConfigManager.TramTronConfig.TGKetThuc_X, ConfigManager.TramTronConfig.TGKetThuc_Y);
                        }
                        break;
                }
            }
        }
       
        public void FillDataPrinter(List<string> para)
        {
            labels = new Label[panel1.Controls.Count];
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                if (panel1.Controls[i] is ucLabelDataPrint label)
                {
                    switch (label.Code)
                    {
                        case "TenChuTram":
                            if (string.IsNullOrEmpty(para[0]))
                                label.Value = "";
                            label.Value = para[0];
                            break;
                        case "NgayTron":
                            if (string.IsNullOrEmpty(para[1]))
                                label.Value = "";
                            label.Value = para[1];
                            break;
                        case "TenDuAn":
                            if (string.IsNullOrEmpty(para[2]))
                                label.Value = "";
                            label.Value = para[2];
                            break;
                        case "TenKhachHang":
                            if (string.IsNullOrEmpty(para[3]))
                                label.Value = "";
                            label.Value = para[3];
                            break;
                        case "TenMAC":
                            if (string.IsNullOrEmpty(para[4]))
                                label.Value = "";
                            label.Value = para[4];
                            break;
                        case "CuongDo":
                            if (string.IsNullOrEmpty(para[5]))
                                label.Value = "";
                            label.Value = para[5];
                            break;
                        case "SoPhieu":
                            if (string.IsNullOrEmpty(para[6]))
                                label.Value = "";
                            label.Value = para[6];
                            break;
                        case "CotLieuMax":
                            if (string.IsNullOrEmpty(para[7]))
                                label.Value = "";
                            label.Value = para[7];
                            break;
                        case "DoSut":
                            if (string.IsNullOrEmpty(para[8]))
                                label.Value = "";
                            label.Value = para[8];
                            break;
                        case "LaiXe":
                            if (string.IsNullOrEmpty(para[9]))
                                label.Value = "";
                            label.Value = para[9];
                            break;
                        case "TheTichXeTron":
                            if (string.IsNullOrEmpty(para[10]))
                                label.Value = "";
                            label.Value = para[10];
                            break;
                        case "TheTichDatHang":
                            if (string.IsNullOrEmpty(para[11]))
                                label.Value = "";
                            label.Value = para[11];
                            break;
                        case "LuyKe":
                            if (string.IsNullOrEmpty(para[12]))
                                label.Value = "";
                            label.Value = para[12];
                            break;
                        case "BienSo":
                            if (string.IsNullOrEmpty(para[13]))
                                label.Value = "";
                            label.Value = para[13];
                            break;
                        case "TGBatDau":
                            if (string.IsNullOrEmpty(para[14]))
                                label.Value = "";
                            label.Value = para[14];
                            break;
                        
                        case "DiaDiemDuAn":
                            if (string.IsNullOrEmpty(para[15]))
                                label.Value = "";
                            label.Value = para[15];
                            break;
                        case "MaPhieu":
                            if (string.IsNullOrEmpty(para[16]))
                                label.Value = "";
                            label.Value = para[16];
                            break;
                        case "TheTich1MeTron":
                            if (string.IsNullOrEmpty(para[17]))
                                label.Value = "";
                            label.Value = para[17];
                            break;
                        case "TenHangMuc":
                            if (string.IsNullOrEmpty(para[18]))
                                label.Value = "";
                            label.Value = para[18];
                            break;
                        case "SoNiemChi":
                            if (string.IsNullOrEmpty(para[19]))
                                label.Value = "";
                            label.Value = para[19];
                            break;
                        case "NhanVien":
                            if (string.IsNullOrEmpty(para[20]))
                                label.Value = "";
                            label.Value = para[20];
                            break;
                        case "TGKetThuc":
                            if (string.IsNullOrEmpty(para[21]))
                                label.Value = "";
                            label.Value = para[21];
                            break;
                    }

                    labels[i] = new Label
                    {
                        Text = label.Value,
                        Location = new Point(label.Location.X, label.Location.Y),
                        TextAlign = ContentAlignment.MiddleCenter
                        

                    };
                }
                if(panel1.Controls[i] is ucTarrgetPoint target)
                {
                    labels[i] = new Label
                    {
                        Text = "+",
                        Location = new Point(target.Location.X, target.Location.Y)
                        
                    };
                }
            }
            
            PrinterPheuTron_Load();
            
        }
        public void ShowDialogPreviewPrint()
        {
            PrinterPheuTron_Load();
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = this.printDocument;
            printPreviewDialog.ClientSize = Screen.PrimaryScreen.Bounds.Size;
            printPreviewDialog.PrintPreviewControl.Zoom = (double)this.spnZoom.Value;
            printPreviewDialog.ShowDialog();
        }
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            List<string> paras = new List<string>();
            paras.Add("CTY TNHH NAM ĐẠI PHÁT");
            paras.Add("22/02/2022");
            paras.Add("Khu đô thị The Prvia");
            paras.Add("Cty Xây dựng Hoà Bình");
            paras.Add("MAC22C1");
            paras.Add("100");
            paras.Add("8");
            paras.Add("12");
            paras.Add("14 ± 2");
            paras.Add("TX Nam");
            paras.Add("8m³");
            paras.Add("20m³");
            paras.Add("16");
            paras.Add("39H1-4402");
            paras.Add("09:30");
            paras.Add("Quốc lộ 1A, Thuận An");
            paras.Add("PT00012");
            paras.Add("1.5m³");
            paras.Add("Cột Bê Tông");
            paras.Add("000912");
            paras.Add("Đại Phát");
            paras.Add("09:35");
            FillDataPrinter(paras);
            ShowDialogPreviewPrint();
        }
        private void PrinterPheuTron_Load()
        {
            this.printDialog = new PrintDialog();
            this.printDocument = new PrintDocument();
            this.printDocument.PrinterSettings.PrinterName = ConfigManager.TramTronConfig.MayInPI;
            this.printDocument.PrintPage += new PrintPageEventHandler(this.PrintDocument_PrintPage);
        }

        public void PrintPhieuTron()
        {
            PrinterPheuTron_Load();
            this.printDocument.Print();
        }
        public void ShowDialogPintPhieuTron()
        {
            PrinterPheuTron_Load();
            this.printDialog.Document = this.printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private Label[] labels;
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            foreach (Label label in labels)
            {
                using (SolidBrush brush = new SolidBrush(label.ForeColor))
                {
                    System.Drawing.Font font = new System.Drawing.Font("Arial", 30);
                    if (label.Text == "+")
                    {
                        e.Graphics.DrawString(label.Text, font, brush, label.Location);
                    }
                    else
                    {
                        font = new System.Drawing.Font("Arial", (float)this.spnSize.Value);
                        e.Graphics.DrawString(label.Text, font, brush, label.Location);
                    }
                }
                
            }
        }

        private void label_ButtonMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ucLabelDataPrint control = sender as ucLabelDataPrint;
                offset = e.Location;
                isDragging = true;
                control.BringToFront();
            }
        }
        private void label_ButtonMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                ucLabelDataPrint control = sender as ucLabelDataPrint;

                control.Left = e.X + control.Left - offset.X;
                control.Top = e.Y + control.Top - offset.Y;
                control.ToaDo = "X:" + control.Left.ToString() + "-Y:" + control.Top.ToString();
                spnToaDoX.EditValue = control.Left.ToString();
                spnToaDoY.EditValue = control.Top.ToString();
            }
        }
        private void label_ButtonMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void label_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedLabel = sender as ucLabelDataPrint;
                selectedTarget = null;
            }

        }
        private void target_ButtonMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ucTarrgetPoint control = sender as ucTarrgetPoint;
                offset = e.Location;
                isDragging = true;
                control.BringToFront();
            }
        }
        private void target_ButtonMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                ucTarrgetPoint control = sender as ucTarrgetPoint;

                control.Left = e.X + control.Left - offset.X;
                control.Top = e.Y + control.Top - offset.Y;
                spnToaDoX.EditValue = control.Left.ToString();
                spnToaDoY.EditValue = control.Top.ToString();
            }
        }
        private void target_ButtonMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        private void target_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                selectedTarget = sender as ucTarrgetPoint;
                selectedLabel = null;

            }

        }
        public override void DoKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (this.panel1.Enabled)
                    {
                        if(selectedLabel != null)
                        {
                            panel1.Controls.Remove(selectedLabel);
                            selectedLabel = null;
                        }
                        if(selectedTarget != null)
                        {
                            panel1.Controls.Remove(selectedTarget);
                            selectedTarget = null;
                            return;
                        }
                        
                    }
                    break;
                case Keys.A:
                    if (selectedLabel != null)
                    {
                        selectedLabel.Left -= 1;
                        selectedLabel.ToaDo = "X:" + selectedLabel.Left.ToString() + "-Y:" + selectedLabel.Top.ToString();
                    }
                    break;
                case Keys.W:
                    if (selectedLabel != null)
                    {
                        selectedLabel.Top -= 1;
                        selectedLabel.ToaDo = "X:" + selectedLabel.Left.ToString() + "-Y:" + selectedLabel.Top.ToString();
                    }
                    break;
                case Keys.S:
                    if (selectedLabel != null)
                    {
                        selectedLabel.Top += 1;
                        selectedLabel.ToaDo = "X:" + selectedLabel.Left.ToString() + "-Y:" + selectedLabel.Top.ToString();
                    }
                    break;
                case Keys.F:
                    if (selectedLabel != null)
                    {
                        selectedLabel.Left += 1;
                        selectedLabel.ToaDo = "X:" + selectedLabel.Left.ToString() + "-Y:" + selectedLabel.Top.ToString();
                    }
                    break;

            }
        }
       
        private void spnToaDoX_EditValueChanged(object sender, EventArgs e)
        {
            /*if (selectedLabel != null)
            {
                selectedLabel.Left = (int)spnToaDoX.Value;
                selectedLabel.ToaDo = "X:" + selectedLabel.Left.ToString() + "-Y:" + selectedLabel.Top.ToString();
            }*/
                
        }
        private void simpleButton6_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
        }

       
        private void ResetDataPrinter()
        {
            ConfigManager.TramTronConfig.TenChuTram_Stus = false;
            ConfigManager.TramTronConfig.TenChuTram_X = 20;
            ConfigManager.TramTronConfig.TenChuTram_Y = 20;

            ConfigManager.TramTronConfig.NgayTron_Stus = false;
            ConfigManager.TramTronConfig.NgayTron_X = 20;
            ConfigManager.TramTronConfig.NgayTron_Y = 20;

            ConfigManager.TramTronConfig.TenDuAn_Stus = false;
            ConfigManager.TramTronConfig.TenDuAn_X = 20;
            ConfigManager.TramTronConfig.TenDuAn_Y = 20;

            ConfigManager.TramTronConfig.TenKhachHang_Stus = false;
            ConfigManager.TramTronConfig.TenKhachHang_X = 20;
            ConfigManager.TramTronConfig.TenKhachHang_Y = 20;

            ConfigManager.TramTronConfig.TenMAC_Stus = false;
            ConfigManager.TramTronConfig.TenMAC_X = 20;
            ConfigManager.TramTronConfig.TenMAC_Y = 20;

            ConfigManager.TramTronConfig.CuongDo_Stus = false;
            ConfigManager.TramTronConfig.CuongDo_X = 20;
            ConfigManager.TramTronConfig.CuongDo_Y = 20;

            ConfigManager.TramTronConfig.SoPhieu_Stus = false;
            ConfigManager.TramTronConfig.SoPhieu_X = 20;
            ConfigManager.TramTronConfig.SoPhieu_Y = 20;

            ConfigManager.TramTronConfig.CotLieuMax_Stus = false;
            ConfigManager.TramTronConfig.CotLieuMax_X = 20;
            ConfigManager.TramTronConfig.CotLieuMax_Y = 20;

            ConfigManager.TramTronConfig.DoSut_Stus = false;
            ConfigManager.TramTronConfig.DoSut_X = 20;
            ConfigManager.TramTronConfig.DoSut_Y = 20;

            ConfigManager.TramTronConfig.LaiXe_Stus = false;
            ConfigManager.TramTronConfig.LaiXe_X = 20;
            ConfigManager.TramTronConfig.LaiXe_Y = 20;

            ConfigManager.TramTronConfig.TheTichXeTron_Stus = false;
            ConfigManager.TramTronConfig.TheTichXeTron_X = 20;
            ConfigManager.TramTronConfig.TheTichXeTron_Y = 20;

            ConfigManager.TramTronConfig.TheTichDatHang_Stus = false;
            ConfigManager.TramTronConfig.TheTichDatHang_X = 20;
            ConfigManager.TramTronConfig.TheTichDatHang_Y = 20;

            ConfigManager.TramTronConfig.LuyKe_Stus = false;
            ConfigManager.TramTronConfig.LuyKe_X = 20;
            ConfigManager.TramTronConfig.LuyKe_Y = 20;

            ConfigManager.TramTronConfig.BienSo_Stus = false;
            ConfigManager.TramTronConfig.BienSo_X = 20;
            ConfigManager.TramTronConfig.BienSo_Y = 20;

            ConfigManager.TramTronConfig.TGBatDau_Stus = false;
            ConfigManager.TramTronConfig.TGBatDau_X = 20;
            ConfigManager.TramTronConfig.TGBatDau_Y = 20;

            ConfigManager.TramTronConfig.TGKetThuc_Stus = false;
            ConfigManager.TramTronConfig.TGKetThuc_X = 20;
            ConfigManager.TramTronConfig.TGKetThuc_Y = 20;

            ConfigManager.TramTronConfig.DiaDiemDuAn_Stus = false;
            ConfigManager.TramTronConfig.DiaDiemDuAn_X = 20;
            ConfigManager.TramTronConfig.DiaDiemDuAn_Y = 20;

            ConfigManager.TramTronConfig.MaPhieu_Stus = false;
            ConfigManager.TramTronConfig.MaPhieu_X = 20;
            ConfigManager.TramTronConfig.MaPhieu_Y = 20;

            ConfigManager.TramTronConfig.TheTich1MeTron_Stus = false;
            ConfigManager.TramTronConfig.TheTich1MeTron_X = 20;
            ConfigManager.TramTronConfig.TheTich1MeTron_Y = 20;

            ConfigManager.TramTronConfig.TenHangMuc_Stus = false;
            ConfigManager.TramTronConfig.TenHangMuc_X = 20;
            ConfigManager.TramTronConfig.TenHangMuc_Y = 20;

            ConfigManager.TramTronConfig.SoNiemChi_Stus = false;
            ConfigManager.TramTronConfig.SoNiemChi_X = 20;
            ConfigManager.TramTronConfig.SoNiemChi_Y = 20;

            ConfigManager.TramTronConfig.NhanVien_Stus = false;
            ConfigManager.TramTronConfig.NhanVien_X = 20;
            ConfigManager.TramTronConfig.NhanVien_Y = 20;

        }
        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            ResetDataPrinter();
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                if (panel1.Controls[i] is ucLabelDataPrint label)
                {
                    switch (label.Code)
                    {
                        case "TenChuTram":
                            ConfigManager.TramTronConfig.TenChuTram_Stus = true;
                            ConfigManager.TramTronConfig.TenChuTram_X = label.Location.X;
                            ConfigManager.TramTronConfig.TenChuTram_Y = label.Location.Y;
                            break;
                        case "NgayTron":
                            ConfigManager.TramTronConfig.NgayTron_Stus = true;
                            ConfigManager.TramTronConfig.NgayTron_X = label.Location.X;
                            ConfigManager.TramTronConfig.NgayTron_Y = label.Location.Y;
                            break;
                        case "TenDuAn":
                            ConfigManager.TramTronConfig.TenDuAn_Stus = true;
                            ConfigManager.TramTronConfig.TenDuAn_X = label.Location.X;
                            ConfigManager.TramTronConfig.TenDuAn_Y = label.Location.Y;
                            break;
                        case "TenKhachHang":
                            ConfigManager.TramTronConfig.TenKhachHang_Stus = true;
                            ConfigManager.TramTronConfig.TenKhachHang_X = label.Location.X;
                            ConfigManager.TramTronConfig.TenKhachHang_Y = label.Location.Y;
                            break;
                        case "TenMAC":
                            ConfigManager.TramTronConfig.TenMAC_Stus = true;
                            ConfigManager.TramTronConfig.TenMAC_X = label.Location.X;
                            ConfigManager.TramTronConfig.TenMAC_Y = label.Location.Y;
                            break;
                        case "CuongDo":
                            ConfigManager.TramTronConfig.CuongDo_Stus = true;
                            ConfigManager.TramTronConfig.CuongDo_X = label.Location.X;
                            ConfigManager.TramTronConfig.CuongDo_Y = label.Location.Y;
                            break;
                        case "SoPhieu":
                            ConfigManager.TramTronConfig.SoPhieu_Stus = true;
                            ConfigManager.TramTronConfig.SoPhieu_X = label.Location.X;
                            ConfigManager.TramTronConfig.SoPhieu_Y = label.Location.Y;
                            break;
                        case "CotLieuMax":
                            ConfigManager.TramTronConfig.CotLieuMax_Stus = true;
                            ConfigManager.TramTronConfig.CotLieuMax_X = label.Location.X;
                            ConfigManager.TramTronConfig.CotLieuMax_Y = label.Location.Y;
                            break;
                        case "DoSut":
                            ConfigManager.TramTronConfig.DoSut_Stus = true;
                            ConfigManager.TramTronConfig.DoSut_X = label.Location.X;
                            ConfigManager.TramTronConfig.DoSut_Y = label.Location.Y;
                            break;
                        case "LaiXe":
                            ConfigManager.TramTronConfig.LaiXe_Stus = true;
                            ConfigManager.TramTronConfig.LaiXe_X = label.Location.X;
                            ConfigManager.TramTronConfig.LaiXe_Y = label.Location.Y;
                            break;
                        case "TheTichXeTron":
                            ConfigManager.TramTronConfig.TheTichXeTron_Stus = true;
                            ConfigManager.TramTronConfig.TheTichXeTron_X = label.Location.X;
                            ConfigManager.TramTronConfig.TheTichXeTron_Y = label.Location.Y;
                            break;
                        case "TheTichDatHang":
                            ConfigManager.TramTronConfig.TheTichDatHang_Stus = true;
                            ConfigManager.TramTronConfig.TheTichDatHang_X = label.Location.X;
                            ConfigManager.TramTronConfig.TheTichDatHang_Y = label.Location.Y;
                            break;
                        case "LuyKe":
                            ConfigManager.TramTronConfig.LuyKe_Stus = true;
                            ConfigManager.TramTronConfig.LuyKe_X = label.Location.X;
                            ConfigManager.TramTronConfig.LuyKe_Y = label.Location.Y;
                            break;
                        case "BienSo":
                            ConfigManager.TramTronConfig.BienSo_Stus = true;
                            ConfigManager.TramTronConfig.BienSo_X = label.Location.X;
                            ConfigManager.TramTronConfig.BienSo_Y = label.Location.Y;
                            break;
                        case "TGBatDau":
                            ConfigManager.TramTronConfig.TGBatDau_Stus = true;
                            ConfigManager.TramTronConfig.TGBatDau_X = label.Location.X;
                            ConfigManager.TramTronConfig.TGBatDau_Y = label.Location.Y;
                            break;
                        case "TGKetThuc":
                            ConfigManager.TramTronConfig.TGKetThuc_Stus = true;
                            ConfigManager.TramTronConfig.TGKetThuc_X = label.Location.X;
                            ConfigManager.TramTronConfig.TGKetThuc_Y = label.Location.Y;
                            break;


                        case "DiaDiemDuAn":
                            ConfigManager.TramTronConfig.DiaDiemDuAn_Stus = true;
                            ConfigManager.TramTronConfig.DiaDiemDuAn_X = label.Location.X;
                            ConfigManager.TramTronConfig.DiaDiemDuAn_Y = label.Location.Y;
                            break;
                        case "MaPhieu":
                            ConfigManager.TramTronConfig.MaPhieu_Stus = true;
                            ConfigManager.TramTronConfig.MaPhieu_X = label.Location.X;
                            ConfigManager.TramTronConfig.MaPhieu_Y = label.Location.Y;
                            break;
                        case "TheTich1MeTron":
                            ConfigManager.TramTronConfig.TheTich1MeTron_Stus = true;
                            ConfigManager.TramTronConfig.TheTich1MeTron_X = label.Location.X;
                            ConfigManager.TramTronConfig.TheTich1MeTron_Y = label.Location.Y;
                            break;
                        case "TenHangMuc":
                            ConfigManager.TramTronConfig.TenHangMuc_Stus = true;
                            ConfigManager.TramTronConfig.TenHangMuc_X = label.Location.X;
                            ConfigManager.TramTronConfig.TenHangMuc_Y = label.Location.Y;
                            break;
                        case "SoNiemChi":
                            ConfigManager.TramTronConfig.SoNiemChi_Stus = true;
                            ConfigManager.TramTronConfig.SoNiemChi_X = label.Location.X;
                            ConfigManager.TramTronConfig.SoNiemChi_Y = label.Location.Y;
                            break;
                        case "NhanVien":
                            ConfigManager.TramTronConfig.NhanVien_Stus = true;
                            ConfigManager.TramTronConfig.NhanVien_X = label.Location.X;
                            ConfigManager.TramTronConfig.NhanVien_Y = label.Location.Y;
                            break;

                    }
                }
            }

            ConfigManager.TramTronConfig.InPITuMau = checkEdit1.Checked;
            ConfigManager.TramTronConfig.PIPath = bteImportPIPath.Text;
            ConfigManager.TramTronConfig.PICTPath = bteImportPICTPath.Text;
            ConfigManager.TramTronConfig.MayInPI = luePrinterPI.Text;
            ConfigManager.TramTronConfig.MayInPICT = luePrinterPICT.Text;

            this.Close();

        }

        private void spnToaDoX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Ngăn việc tạo tiếng "beep"
                e.SuppressKeyPress = true; // Ngăn việc xuống dòng

                if (selectedLabel != null)
                {
                    selectedLabel.Left = (int)spnToaDoX.Value;
                    selectedLabel.ToaDo = "X:" + selectedLabel.Left.ToString() + "-Y:" + selectedLabel.Top.ToString();
                }
                if(selectedTarget != null)
                {
                    selectedTarget.Left = (int)spnToaDoX.Value;
                }
            }
        }

        private void spnToaDoY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Ngăn việc tạo tiếng "beep"
                e.SuppressKeyPress = true; // Ngăn việc xuống dòng

                if (selectedLabel != null)
                {
                    selectedLabel.Top = (int)spnToaDoY.Value;
                    selectedLabel.ToaDo = "X:" + selectedLabel.Left.ToString() + "-Y:" + selectedLabel.Top.ToString();
                }
                if (selectedTarget != null)
                {
                    selectedTarget.Top = (int)spnToaDoY.Value;
                }
            }
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            CreateTargetPoint();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                if (panel1.Controls[i] is ucLabelDataPrint label)
                    panel1.Controls.Remove(label);
            }
        }
        private void LoadPrinters()
        {
            try
            {
                _listPrinter.Clear();
                foreach (string printerName in PrinterSettings.InstalledPrinters)
                {
                    _listPrinter.Add(printerName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading printers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            luePrinterPI.Properties.DataSource = _listPrinter;
            
            luePrinterPICT.Properties.DataSource = _listPrinter;
            //lookupEditPrinters.EditValue = listPrinter[4];
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                lblPIPath.Enabled = true;
                bteImportPIPath.Enabled = true;
            }
            else
            {
                lblPIPath.Enabled = false;
                bteImportPIPath.Enabled = false;
            }
        }

       

        private void bteImportPIPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Document File|*.docx";
            openFileDialog1.Title = "Chọn File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog1.FileName;
                    bteImportPIPath.Text = filePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void bteImportPICTPath_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Document File|*.docx";
            openFileDialog1.Title = "Chọn File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog1.FileName;
                    bteImportPICTPath.Text = filePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void luePrinterPI_EditValueChanged(object sender, EventArgs e)
        {
            //TramTromMessageBox.ShowMessageDialog(luePrinterPI.EditValue.ToString());
        }
    }
}
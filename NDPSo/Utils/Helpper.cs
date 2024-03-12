using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.Utils
{
    public partial class Helpper : Form
    {
        private bool _PrintTenCongTy;
        private bool _PrintDiaChiDienThoai;
        private string _Title = "";
        private List<string> _ListHeader = new List<string>();
        private string _Footer1 = "";
        private string _Footer2 = "";
        private int _NumberOfLineFooter = 1;
        private string _AlignFooter1 = "";
        private string _AlignFooter2 = "";
        private float widthClient;

        public Helpper()
        {
            InitializeComponent();
        }

        public void PrintWithHeader(
          bool useLandscapeView,
          IPrintable printableComponent,
          bool printTenCongTy,
          bool printDiaChiDienThoai,
          string title,
          List<string> lstHeader,
          bool inTrucTiep)
        {
            Exception exception;
            try
            {
                foreach (BandedGridView view in (ReadOnlyCollectionBase)(printableComponent as GridControl).Views)
                    view.Columns["colDelete"].Visible = false;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            try
            {
                foreach (ColumnView view in (ReadOnlyCollectionBase)(printableComponent as GridControl).Views)
                    view.Columns["colDelete"].Visible = false;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            this._PrintTenCongTy = printTenCongTy;
            this._PrintDiaChiDienThoai = printDiaChiDienThoai;
            this._Title = title;
            this._ListHeader = lstHeader;
            this.printableComponentLink.Component = printableComponent;
            this.printableComponentLink.PaperKind = PaperKind.A4;
            this.printableComponentLink.Landscape = useLandscapeView;
            this.printableComponentLink.Margins.Bottom = 10;
            this.printableComponentLink.Margins.Left = 10;
            this.printableComponentLink.Margins.Right = 10;
            this.printableComponentLink.Margins.Top = 10;
            this.printingSystem.PageMargins.Bottom = 10;
            this.printingSystem.PageMargins.Left = 10;
            this.printingSystem.PageMargins.Right = 10;
            this.printingSystem.PageMargins.Top = 10;
            this.printableComponentLink.CreateReportHeaderArea += new CreateAreaEventHandler(this.printableComponentLink_CreateReportHeaderArea);
            this.printableComponentLink.CreateDocument();
            if (inTrucTiep)
                this.printingSystem.Print();
            else
                this.printableComponentLink.ShowPreviewDialog();
        }
        public void ExportExcelWithHeader(
          bool useLandscapeView,
          IPrintable printableComponent,
          bool printTenCongTy,
          bool printDiaChiDienThoai,
          string title,
          List<string> lstHeader)
        {
            widthClient = 1000f;
            Exception exception;
            try
            {
                
                foreach (AdvBandedGridView view in (printableComponent as GridControl).Views)
                {
                     
                }
                   
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            try
            {
                foreach (GridView view in (printableComponent as GridControl).Views)
                {
                    //System.Drawing.Rectangle bounds = printableComponent.Bounds;
                    //widthClient = (printableComponent as GridView).
                   
                   int estimatedWidth = 0;
                    foreach (DevExpress.XtraGrid.Columns.GridColumn column in view.Columns)
                    {
                        estimatedWidth += column.Width;
                    }
                   // widthClient = (float)estimatedWidth;
                }
                

            }
            catch (Exception ex)
            {
                exception = ex;
            }
            
            this._PrintTenCongTy = printTenCongTy;
            this._PrintDiaChiDienThoai = printDiaChiDienThoai;
            this._Title = title;
            this._ListHeader = lstHeader;
            this.printableComponentLink.Component = printableComponent;
            this.printableComponentLink.PaperKind = PaperKind.A4;
            this.printableComponentLink.Landscape = useLandscapeView;
            this.printableComponentLink.Margins.Bottom = 10;
            this.printableComponentLink.Margins.Left = 10;
            this.printableComponentLink.Margins.Right = 10;
            this.printableComponentLink.Margins.Top = 10;
            this.printingSystem.PageMargins.Bottom = 10;
            this.printingSystem.PageMargins.Left = 10;
            this.printingSystem.PageMargins.Right = 10;
            this.printingSystem.PageMargins.Top = 10;
            //this._Footer1 = "Ngày 27 tháng 10 năm 2023\n Nhân viên";
            //this._Footer2 = "Nhân viên";
            this.printableComponentLink.CreateReportHeaderArea += new CreateAreaEventHandler(this.printableComponentLink_CreateReportHeaderArea);
            this.printableComponentLink.CreateReportFooterArea += new CreateAreaEventHandler(this.printableComponentLink_CreateReportFooterArea);
            this.printableComponentLink.CreateDocument();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel file (*.xls)|*.xls";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            XlsExportOptions options = new XlsExportOptions();
            options.ShowGridLines = true;
            this.printableComponentLink.ExportToXls(saveFileDialog.FileName, options);
            try
            {
                new Process()
                {
                    StartInfo = {
                                FileName = saveFileDialog.FileName
                                }
                }.Start();
            }
            catch (Exception ex)
            {
                exception = ex;
               // int num = (int)MessageBox.Show(Resources.loiMoFile, Resources.tenphanmem, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            finally
            {
                //FrmProgressBar.FinishShowProgress();
            }
        }
        public void ExportPDFWithHeader(
          bool useLandscapeView,
          IPrintable printableComponent,
          bool printTenCongTy,
          bool printDiaChiDienThoai,
          string title,
          List<string> lstHeader)
        {
            Exception exception;
            try
            {
                foreach (AdvBandedGridView view in (ReadOnlyCollectionBase)(printableComponent as GridControl).Views);
                
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            try
            {
                foreach (GridView view in (ReadOnlyCollectionBase)(printableComponent as GridControl).Views) ;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
            
            this._PrintTenCongTy = printTenCongTy;
            this._PrintDiaChiDienThoai = printDiaChiDienThoai;
            this._Title = title;
            this._ListHeader = lstHeader;
            this.printableComponentLink.Component = printableComponent;
            this.printableComponentLink.PaperKind = PaperKind.A4;
            this.printableComponentLink.Landscape = useLandscapeView;
            this.printableComponentLink.Margins.Bottom = 10;
            this.printableComponentLink.Margins.Left = 10;
            this.printableComponentLink.Margins.Right = 10;
            this.printableComponentLink.Margins.Top = 10;
            this.printingSystem.PageMargins.Bottom = 10;
            this.printingSystem.PageMargins.Left = 10;
            this.printingSystem.PageMargins.Right = 10;
            this.printingSystem.PageMargins.Top = 10;
            this.printableComponentLink.CreateReportHeaderArea += new CreateAreaEventHandler(this.printableComponentLink_CreateReportHeaderArea);
            this.printableComponentLink.CreateDocument();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pdf file (*.pdf)|*.pdf";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;
            PdfExportOptions options = new PdfExportOptions();
            this.printableComponentLink.ExportToPdf(saveFileDialog.FileName, options);
            try
            {
                new Process()
                {
                    StartInfo = {
            FileName = saveFileDialog.FileName
          }
                }.Start();
            }
            catch (Exception ex)
            {
                exception = ex;
                //int num = (int)MessageBox.Show(Resources.loiMoFile, Resources.tenphanmem, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            finally
            {
                //FrmProgressBar.FinishShowProgress();
            }
        }

        

        public void PrintWithHeader(
          bool useLandscapeView,
          IPrintable printableComponent,
          bool printTenCongTy,
          bool printDiaChiDienThoai,
          bool printPageNumber,
          string title,
          List<string> lstHeader)
        {
            if (printPageNumber)
            {
                PageHeaderFooter pageHeaderFooter = this.printableComponentLink.PageHeaderFooter as PageHeaderFooter;
                pageHeaderFooter.Footer.Content.Clear();
                pageHeaderFooter.Footer.Content.AddRange(new string[3]
                {
          "",
          "",
          "Trang [Page #]"
                });
                pageHeaderFooter.Footer.LineAlignment = BrickAlignment.Center;
            }
            this._PrintTenCongTy = printTenCongTy;
            this._PrintDiaChiDienThoai = printDiaChiDienThoai;
            this._Title = title;
            this._ListHeader = lstHeader;
            this.printableComponentLink.Component = printableComponent;
            this.printableComponentLink.PaperKind = PaperKind.A4;
            this.printableComponentLink.Landscape = useLandscapeView;
            this.printableComponentLink.CreateReportHeaderArea += new CreateAreaEventHandler(this.printableComponentLink_CreateReportHeaderArea);
            this.printableComponentLink.CreateDocument();
            this.printableComponentLink.ShowPreview();
        }

        public void PrintWithHeaderAndFooter(
          bool useLandscapeView,
          IPrintable printableComponent,
          bool printTenCongTy,
          bool printDiaChiDienThoai,
          string title,
          List<string> lstHeader,
          string footer1,
          string footer2)
        {
            PageHeaderFooter pageHeaderFooter = this.printableComponentLink.PageHeaderFooter as PageHeaderFooter;
            pageHeaderFooter.Footer.Content.Clear();
            pageHeaderFooter.Footer.Content.AddRange(new string[3]
            {
        "",
        "",
        "Trang [Page #]"
            });
            pageHeaderFooter.Footer.LineAlignment = BrickAlignment.Center;
            this._PrintTenCongTy = printTenCongTy;
            this._PrintDiaChiDienThoai = printDiaChiDienThoai;
            this._Title = title;
            this._ListHeader = lstHeader;
            this._Footer1 = footer1;
            this._Footer2 = footer2;
            this.printableComponentLink.Component = printableComponent;
            this.printableComponentLink.PaperKind = PaperKind.A4;
            this.printableComponentLink.Landscape = useLandscapeView;
            this.printableComponentLink.CreateReportHeaderArea += new CreateAreaEventHandler(this.printableComponentLink_CreateReportHeaderArea);
            this.printableComponentLink.CreateReportFooterArea += new CreateAreaEventHandler(this.printableComponentLink_CreateReportFooterArea);
            this.printableComponentLink.CreateDocument();
            this.printableComponentLink.ShowPreview();
        }

        private void printableComponentLink_CreateReportHeaderArea(object sender, CreateAreaEventArgs e)
        {
            try
            {
                int y1 = 0;
                string str1 = "";
                string str2 = "";
                try
                {
                    str1 = ConfigManager.TramTronConfig.TenCty;
                    str2 = ConfigManager.TramTronConfig.DiaChiCty;
                }
                catch (Exception ex)
                {
                }

                System.Drawing.Image image = Image.FromFile(ConfigManager.TramTronConfig.LogoCty);
                // Kiểm tra xem tệp hình ảnh có tồn tại không
               
                if (this._PrintTenCongTy)
                {
                    string text = str1 + "\n" + str2;
                    e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near, StringAlignment.Center);
                    e.Graph.Font = new Font("Times New Roman", 12f, FontStyle.Regular);
                    //RectangleF rect = new RectangleF(0.0f, (float)y1, e.Graph.ClientPageSize.Width, 100f);


                    
                    RectangleF rect = new RectangleF(0.0f, (float)y1, 100f, 100f);
                    e.Graph.DrawImage(image, rect, BorderSide.None, Color.Transparent);

                    RectangleF textRect = new RectangleF(100f, (float)y1, widthClient - 100f, 100f);
                    e.Graph.DrawString(text, Color.Black, textRect, BorderSide.None);
                    y1 += 100;

                }
                
                SizeF clientPageSize;
                if (this._Title.Length > 0)
                {
                    e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center, StringAlignment.Center);
                    e.Graph.Font = new Font("Tahoma", 16f, FontStyle.Bold);
                    double y2 = (double)y1;
                    clientPageSize = e.Graph.ClientPageSize;
                    double width = (double)clientPageSize.Width;
                    RectangleF rect = new RectangleF(0.0f, (float)y2, widthClient, 50f);
                    y1 += 50;
                    e.Graph.DrawString(this._Title, Color.Black, rect, BorderSide.None);
                }
                
                for (int index = 0; index < this._ListHeader.Count; ++index)
                {
                    if (this._ListHeader[index].Length > 0)
                    {
                        e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Near);
                        e.Graph.Font = new Font("Tahoma", 10f, FontStyle.Regular);
                        double y3 = (double)y1;
                        clientPageSize = e.Graph.ClientPageSize;
                        double width = (double)clientPageSize.Width;
                        RectangleF rect = new RectangleF(0.0f, (float)y3, widthClient, 20f);
                        y1 += 20;
                        e.Graph.DrawString(this._ListHeader[index], Color.Black, rect, BorderSide.None);
                    }
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }

        private void printableComponentLink_CreateReportFooterArea(object sender, CreateAreaEventArgs e)
        {
            try
            {
                int y = 0;
                if (this._NumberOfLineFooter == 2)
                {
                    e.Graph.BackColor = Color.White;
                    RectangleF rect;
                    if (this._Footer1.Length > 0)
                    {
                        e.Graph.StringFormat = !(this._AlignFooter1.ToUpper() == "CENTER") ? (!(this._AlignFooter1.ToUpper() == "RIGHT") ? new BrickStringFormat(StringAlignment.Near) : new BrickStringFormat(StringAlignment.Far)) : new BrickStringFormat(StringAlignment.Center);
                        e.Graph.Font = new Font("Times New Roman", 12f, FontStyle.Regular);
                        rect = new RectangleF(0.0f, (float)y, e.Graph.ClientPageSize.Width, 30f);
                        y += 30;
                        e.Graph.DrawString(this._Footer1, Color.Black, rect, BorderSide.None);
                    }
                    if (this._Footer2.Length <= 0)
                        return;
                    e.Graph.StringFormat = !(this._AlignFooter2.ToUpper() == "CENTER") ? (!(this._AlignFooter2.ToUpper() == "RIGHT") ? new BrickStringFormat(StringAlignment.Near) : new BrickStringFormat(StringAlignment.Far)) : new BrickStringFormat(StringAlignment.Center);
                    e.Graph.Font = new Font("Times New Roman", 12f, FontStyle.Regular);
                    rect = new RectangleF(0.0f, (float)y, e.Graph.ClientPageSize.Width, 90f);
                    int num = y + 20;
                    e.Graph.DrawString(this._Footer2, Color.Black, rect, BorderSide.None);
                }
                else
                {
                    e.Graph.BackColor = Color.White;
                    RectangleF rect;
                    if (this._Footer1.Length > 0)
                    {
                        e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
                        e.Graph.Font = new Font("Times New Roman", 12f, FontStyle.Regular);
                        rect = new RectangleF(600.0f, 30f, 400f, 100f);
                        e.Graph.DrawString(this._Footer1, Color.Black, rect, BorderSide.None);
                    }
                    if (this._Footer2.Length > 0)
                    {
                        e.Graph.StringFormat = new BrickStringFormat(StringAlignment.Center);
                        e.Graph.Font = new Font("Times New Roman", 12f, FontStyle.Italic);
                        rect = new RectangleF(600f, 30f, 300f, 90f);
                        e.Graph.DrawString(this._Footer2, Color.Black, rect, BorderSide.None);
                    }
                }
            }
            catch (Exception ex)
            {
                int num = (int)MessageBox.Show(ex.Message);
            }
        }
        private void CustomColumnDisplayTextHandler(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.IsForGroupRow)
            {
                // Xử lý cho các tiêu đề nhóm (nếu có)
                e.DisplayText = "Tiêu đề nhóm tùy chỉnh";
            }
            else
            {
                // Xử lý cho các cột dữ liệu
                if (e.Column.FieldName == "MaMeTron")
                {
                    e.DisplayText = "wwww";
                }
                else if (e.Column.FieldName == "Ngay")
                {
                    e.DisplayText = "DAY";
                }
                // Tiếp tục xử lý cho các cột khác nếu cần
            }
        }

    }
}

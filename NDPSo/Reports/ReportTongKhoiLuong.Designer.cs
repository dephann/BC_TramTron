
namespace NDPSo.Reports
{
    partial class ReportTongKhoiLuong
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grcTongKhoiLuong = new DevExpress.XtraGrid.GridControl();
            this.grvTongKhoiLuong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMAC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTongKhoiLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMeTron = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lueCheDo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.lueMAC = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaPhieuTron = new DevExpress.XtraEditors.TextEdit();
            this.lueKhachHang = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lueCongTruong = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.datToDate = new DevExpress.XtraEditors.DateEdit();
            this.datFromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTongKhoiLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTongKhoiLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCheDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMAC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhieuTron.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKhachHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCongTruong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grcTongKhoiLuong);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(632, 513);
            this.groupControl2.TabIndex = 3;
            this.groupControl2.Text = "Dữ liệu";
            // 
            // grcTongKhoiLuong
            // 
            this.grcTongKhoiLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcTongKhoiLuong.Location = new System.Drawing.Point(2, 23);
            this.grcTongKhoiLuong.MainView = this.grvTongKhoiLuong;
            this.grcTongKhoiLuong.Name = "grcTongKhoiLuong";
            this.grcTongKhoiLuong.Size = new System.Drawing.Size(628, 488);
            this.grcTongKhoiLuong.TabIndex = 0;
            this.grcTongKhoiLuong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTongKhoiLuong});
            // 
            // grvTongKhoiLuong
            // 
            this.grvTongKhoiLuong.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvTongKhoiLuong.AppearancePrint.FooterPanel.Options.UseFont = true;
            this.grvTongKhoiLuong.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.grvTongKhoiLuong.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvTongKhoiLuong.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.grvTongKhoiLuong.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.grvTongKhoiLuong.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.grvTongKhoiLuong.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.grvTongKhoiLuong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcNgayLap,
            this.gcKhachHang,
            this.gcMAC,
            this.gcTongKhoiLuong,
            this.gcMeTron});
            this.grvTongKhoiLuong.GridControl = this.grcTongKhoiLuong;
            this.grvTongKhoiLuong.Name = "grvTongKhoiLuong";
            this.grvTongKhoiLuong.OptionsView.ShowFooter = true;
            // 
            // gcNgayLap
            // 
            this.gcNgayLap.Caption = "Ngày lập";
            this.gcNgayLap.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcNgayLap.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcNgayLap.FieldName = "NgayPhieuTron";
            this.gcNgayLap.Name = "gcNgayLap";
            this.gcNgayLap.OptionsColumn.AllowFocus = false;
            this.gcNgayLap.OptionsColumn.ReadOnly = true;
            this.gcNgayLap.Visible = true;
            this.gcNgayLap.VisibleIndex = 0;
            // 
            // gcKhachHang
            // 
            this.gcKhachHang.Caption = "Khách hàng";
            this.gcKhachHang.FieldName = "TenKhachHang";
            this.gcKhachHang.Name = "gcKhachHang";
            this.gcKhachHang.OptionsColumn.AllowFocus = false;
            this.gcKhachHang.OptionsColumn.ReadOnly = true;
            this.gcKhachHang.Visible = true;
            this.gcKhachHang.VisibleIndex = 1;
            // 
            // gcMAC
            // 
            this.gcMAC.Caption = "MAC";
            this.gcMAC.FieldName = "TenMAC";
            this.gcMAC.Name = "gcMAC";
            this.gcMAC.OptionsColumn.AllowFocus = false;
            this.gcMAC.OptionsColumn.ReadOnly = true;
            this.gcMAC.Visible = true;
            this.gcMAC.VisibleIndex = 2;
            // 
            // gcTongKhoiLuong
            // 
            this.gcTongKhoiLuong.Caption = "Tổng khối lượng";
            this.gcTongKhoiLuong.FieldName = "KLDuTinh";
            this.gcTongKhoiLuong.Name = "gcTongKhoiLuong";
            this.gcTongKhoiLuong.OptionsColumn.AllowFocus = false;
            this.gcTongKhoiLuong.OptionsColumn.ReadOnly = true;
            this.gcTongKhoiLuong.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "KLDuTinh", "{0:0.##}")});
            this.gcTongKhoiLuong.Visible = true;
            this.gcTongKhoiLuong.VisibleIndex = 3;
            // 
            // gcMeTron
            // 
            this.gcMeTron.Caption = "Mẻ trộn";
            this.gcMeTron.FieldName = "SLMeDuTinh";
            this.gcMeTron.Name = "gcMeTron";
            this.gcMeTron.OptionsColumn.AllowFocus = false;
            this.gcMeTron.OptionsColumn.ReadOnly = true;
            this.gcMeTron.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SLMeDuTinh", "{0:0.##}")});
            this.gcMeTron.Visible = true;
            this.gcMeTron.VisibleIndex = 4;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.groupBox2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(634, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(280, 513);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Tác vụ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lueCheDo);
            this.groupBox1.Controls.Add(this.labelControl11);
            this.groupBox1.Controls.Add(this.lueMAC);
            this.groupBox1.Controls.Add(this.labelControl9);
            this.groupBox1.Controls.Add(this.txtMaPhieuTron);
            this.groupBox1.Controls.Add(this.lueKhachHang);
            this.groupBox1.Controls.Add(this.labelControl5);
            this.groupBox1.Controls.Add(this.lueCongTruong);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.datToDate);
            this.groupBox1.Controls.Add(this.datFromDate);
            this.groupBox1.Controls.Add(this.labelControl8);
            this.groupBox1.Controls.Add(this.lblFromDate);
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 342);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bộ lọc";
            // 
            // lueCheDo
            // 
            this.lueCheDo.Location = new System.Drawing.Point(112, 210);
            this.lueCheDo.Name = "lueCheDo";
            this.lueCheDo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueCheDo.Properties.Appearance.Options.UseFont = true;
            this.lueCheDo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCheDo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayText", "Chế độ")});
            this.lueCheDo.Properties.DisplayMember = "DisplayText";
            this.lueCheDo.Properties.NullText = "";
            this.lueCheDo.Properties.ValueMember = "ID";
            this.lueCheDo.Size = new System.Drawing.Size(150, 22);
            this.lueCheDo.TabIndex = 86;
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Location = new System.Drawing.Point(15, 213);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(40, 16);
            this.labelControl11.TabIndex = 85;
            this.labelControl11.Text = "Chế độ";
            // 
            // lueMAC
            // 
            this.lueMAC.Location = new System.Drawing.Point(112, 180);
            this.lueMAC.Name = "lueMAC";
            this.lueMAC.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueMAC.Properties.Appearance.Options.UseFont = true;
            this.lueMAC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMAC.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MACID", "MACID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenMAC", "Tên MAC")});
            this.lueMAC.Properties.DisplayMember = "TenMAC";
            this.lueMAC.Properties.NullText = "";
            this.lueMAC.Properties.ValueMember = "MACID";
            this.lueMAC.Size = new System.Drawing.Size(150, 22);
            this.lueMAC.TabIndex = 84;
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Location = new System.Drawing.Point(15, 183);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(52, 16);
            this.labelControl9.TabIndex = 83;
            this.labelControl9.Text = "Tên MAC";
            // 
            // txtMaPhieuTron
            // 
            this.txtMaPhieuTron.Location = new System.Drawing.Point(112, 90);
            this.txtMaPhieuTron.Name = "txtMaPhieuTron";
            this.txtMaPhieuTron.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuTron.Properties.Appearance.Options.UseFont = true;
            this.txtMaPhieuTron.Size = new System.Drawing.Size(150, 22);
            this.txtMaPhieuTron.TabIndex = 82;
            // 
            // lueKhachHang
            // 
            this.lueKhachHang.Location = new System.Drawing.Point(112, 120);
            this.lueKhachHang.Name = "lueKhachHang";
            this.lueKhachHang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueKhachHang.Properties.Appearance.Options.UseFont = true;
            this.lueKhachHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueKhachHang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KhachHangID", "KhachHangID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenKhachHang", "Tên Khách hàng")});
            this.lueKhachHang.Properties.DisplayMember = "TenKhachHang";
            this.lueKhachHang.Properties.NullText = "";
            this.lueKhachHang.Properties.ValueMember = "KhachHangID";
            this.lueKhachHang.Size = new System.Drawing.Size(150, 22);
            this.lueKhachHang.TabIndex = 81;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(15, 123);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(66, 16);
            this.labelControl5.TabIndex = 80;
            this.labelControl5.Text = "Khách hàng";
            // 
            // lueCongTruong
            // 
            this.lueCongTruong.Location = new System.Drawing.Point(112, 150);
            this.lueCongTruong.Name = "lueCongTruong";
            this.lueCongTruong.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueCongTruong.Properties.Appearance.Options.UseFont = true;
            this.lueCongTruong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueCongTruong.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("CongTruongID", "CongTruongID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.True),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenCongTruong", "Tên Công trường")});
            this.lueCongTruong.Properties.DisplayMember = "TenCongTruong";
            this.lueCongTruong.Properties.NullText = "";
            this.lueCongTruong.Properties.ValueMember = "CongTruongID";
            this.lueCongTruong.Size = new System.Drawing.Size(150, 22);
            this.lueCongTruong.TabIndex = 79;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(15, 153);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 16);
            this.labelControl1.TabIndex = 78;
            this.labelControl1.Text = "Công trường";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(15, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 16);
            this.labelControl2.TabIndex = 77;
            this.labelControl2.Text = "Mã phiếu trộn";
            // 
            // datToDate
            // 
            this.datToDate.EditValue = null;
            this.datToDate.Location = new System.Drawing.Point(112, 60);
            this.datToDate.Name = "datToDate";
            this.datToDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datToDate.Properties.Appearance.Options.UseFont = true;
            this.datToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datToDate.Size = new System.Drawing.Size(150, 22);
            this.datToDate.TabIndex = 76;
            // 
            // datFromDate
            // 
            this.datFromDate.EditValue = null;
            this.datFromDate.Location = new System.Drawing.Point(112, 30);
            this.datFromDate.Name = "datFromDate";
            this.datFromDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datFromDate.Properties.Appearance.Options.UseFont = true;
            this.datFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datFromDate.Size = new System.Drawing.Size(150, 22);
            this.datFromDate.TabIndex = 75;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Location = new System.Drawing.Point(15, 63);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(54, 16);
            this.labelControl8.TabIndex = 74;
            this.labelControl8.Text = "Đến ngày";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Appearance.Options.UseFont = true;
            this.lblFromDate.Location = new System.Drawing.Point(15, 33);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(69, 16);
            this.lblFromDate.TabIndex = 73;
            this.lblFromDate.Text = "Tạo từ ngày";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(15, 260);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(108, 32);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "Làm mới";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.Location = new System.Drawing.Point(154, 260);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(108, 32);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExportExcel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(2, 365);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 146);
            this.groupBox2.TabIndex = 87;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Xuất dữ liệu";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.AllowFocus = false;
            this.btnExportExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Appearance.Options.UseFont = true;
            this.btnExportExcel.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.btnExportExcel.ImageOptions.Image = global::NDPSo.ResourceNDP.excel;
            this.btnExportExcel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExportExcel.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnExportExcel.Location = new System.Drawing.Point(80, 60);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(120, 45);
            this.btnExportExcel.TabIndex = 74;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(916, 50);
            this.panelControl1.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(10, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(904, 50);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "BÁO CÁO TỔNG KHỐI LƯỢNG BÊ TÔNG";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 50);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(916, 517);
            this.panelControl2.TabIndex = 5;
            // 
            // ReportTongKhoiLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ReportTongKhoiLuong";
            this.Size = new System.Drawing.Size(916, 567);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcTongKhoiLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTongKhoiLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCheDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMAC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhieuTron.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueKhachHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueCongTruong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grcTongKhoiLuong;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTongKhoiLuong;
        private DevExpress.XtraGrid.Columns.GridColumn gcNgayLap;
        private DevExpress.XtraGrid.Columns.GridColumn gcKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn gcMAC;
        private DevExpress.XtraGrid.Columns.GridColumn gcTongKhoiLuong;
        private DevExpress.XtraGrid.Columns.GridColumn gcMeTron;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit txtMaPhieuTron;
        private DevExpress.XtraEditors.LookUpEdit lueKhachHang;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LookUpEdit lueCongTruong;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit datToDate;
        private DevExpress.XtraEditors.DateEdit datFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
        private DevExpress.XtraEditors.LookUpEdit lueCheDo;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LookUpEdit lueMAC;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
    }
}


namespace NDPSo.Reports
{
    partial class ReportChiTietTaiXe
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
            DevExpress.XtraGrid.GridGroupSummaryItem gridGroupSummaryItem3 = new DevExpress.XtraGrid.GridGroupSummaryItem();
            DevExpress.XtraGrid.GridGroupSummaryItem gridGroupSummaryItem4 = new DevExpress.XtraGrid.GridGroupSummaryItem();
            this.gcTotal_Tranfer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTotal_KL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grcChiTietTaiXe = new DevExpress.XtraGrid.GridControl();
            this.grvChiTietTaiXe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMaTaiXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTenTaiXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lueCheDo = new DevExpress.XtraEditors.LookUpEdit();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.lueTaiXe = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.datToDate = new DevExpress.XtraEditors.DateEdit();
            this.datFromDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcChiTietTaiXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChiTietTaiXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCheDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTaiXe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.CalendarTimeProperties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcTotal_Tranfer
            // 
            this.gcTotal_Tranfer.Caption = "Tổng số chuyến";
            this.gcTotal_Tranfer.FieldName = "Total_Tranfer";
            this.gcTotal_Tranfer.GroupFormat.FormatString = "n2";
            this.gcTotal_Tranfer.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTotal_Tranfer.Name = "gcTotal_Tranfer";
            this.gcTotal_Tranfer.OptionsColumn.AllowFocus = false;
            this.gcTotal_Tranfer.OptionsColumn.ReadOnly = true;
            this.gcTotal_Tranfer.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_Tranfer", "{0:0.##}")});
            this.gcTotal_Tranfer.Visible = true;
            this.gcTotal_Tranfer.VisibleIndex = 2;
            // 
            // gcTotal_KL
            // 
            this.gcTotal_KL.Caption = "Tổng khối lượng";
            this.gcTotal_KL.FieldName = "Total_KL";
            this.gcTotal_KL.GroupFormat.FormatString = "n2";
            this.gcTotal_KL.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTotal_KL.Name = "gcTotal_KL";
            this.gcTotal_KL.OptionsColumn.AllowFocus = false;
            this.gcTotal_KL.OptionsColumn.ReadOnly = true;
            this.gcTotal_KL.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total_KL", "{0:0.##}")});
            this.gcTotal_KL.Visible = true;
            this.gcTotal_KL.VisibleIndex = 3;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 50);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(913, 466);
            this.panelControl2.TabIndex = 5;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grcChiTietTaiXe);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(629, 462);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Dữ liệu";
            // 
            // grcChiTietTaiXe
            // 
            this.grcChiTietTaiXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcChiTietTaiXe.Location = new System.Drawing.Point(2, 23);
            this.grcChiTietTaiXe.MainView = this.grvChiTietTaiXe;
            this.grcChiTietTaiXe.Name = "grcChiTietTaiXe";
            this.grcChiTietTaiXe.Size = new System.Drawing.Size(625, 437);
            this.grcChiTietTaiXe.TabIndex = 0;
            this.grcChiTietTaiXe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvChiTietTaiXe});
            // 
            // grvChiTietTaiXe
            // 
            this.grvChiTietTaiXe.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.grvChiTietTaiXe.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvChiTietTaiXe.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.grvChiTietTaiXe.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.grvChiTietTaiXe.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.grvChiTietTaiXe.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.grvChiTietTaiXe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            //this.gcMaTaiXe,
            this.gcTenTaiXe,
            this.gcTotal_Tranfer,
            this.gcTotal_KL});
            this.grvChiTietTaiXe.GridControl = this.grcChiTietTaiXe;
            gridGroupSummaryItem3.DisplayFormat = "Tổng CP:{0:0.##}";
            gridGroupSummaryItem3.FieldName = "Sum_ValueCP";
            gridGroupSummaryItem3.ShowInGroupColumnFooter = this.gcTotal_Tranfer;
            gridGroupSummaryItem3.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridGroupSummaryItem3.Tag = "Sum_ValueCP";
            gridGroupSummaryItem4.DisplayFormat = "Tổng Thực cân:{0:0.##}";
            gridGroupSummaryItem4.FieldName = "Sum_ValueBat";
            gridGroupSummaryItem4.ShowInGroupColumnFooter = this.gcTotal_KL;
            gridGroupSummaryItem4.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gridGroupSummaryItem4.Tag = "Sum_ValueBat";
            this.grvChiTietTaiXe.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            gridGroupSummaryItem3,
            gridGroupSummaryItem4});
            this.grvChiTietTaiXe.Name = "grvChiTietTaiXe";
            this.grvChiTietTaiXe.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvChiTietTaiXe.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvChiTietTaiXe.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.grvChiTietTaiXe.OptionsView.ShowFooter = true;
            this.grvChiTietTaiXe.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcTenTaiXe, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gcMaTaiXe
            // 
            this.gcMaTaiXe.Caption = "Mã Tài xế";
            this.gcMaTaiXe.FieldName = "MaTaiXe";
            this.gcMaTaiXe.Name = "gcMaTaiXe";
            this.gcMaTaiXe.OptionsColumn.AllowFocus = false;
            this.gcMaTaiXe.OptionsColumn.ReadOnly = true;
            this.gcMaTaiXe.Visible = true;
            this.gcMaTaiXe.VisibleIndex = 0;
            // 
            // gcTenTaiXe
            // 
            this.gcTenTaiXe.Caption = "Tên Tài xế";
            this.gcTenTaiXe.FieldName = "TenTaiXe";
            this.gcTenTaiXe.Name = "gcTenTaiXe";
            this.gcTenTaiXe.OptionsColumn.AllowFocus = false;
            this.gcTenTaiXe.OptionsColumn.ReadOnly = true;
            this.gcTenTaiXe.Visible = true;
            this.gcTenTaiXe.VisibleIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.groupBox2);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(631, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(280, 462);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Tác vụ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lueCheDo);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.lueTaiXe);
            this.groupBox2.Controls.Add(this.labelControl3);
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.datToDate);
            this.groupBox2.Controls.Add(this.datFromDate);
            this.groupBox2.Controls.Add(this.labelControl1);
            this.groupBox2.Controls.Add(this.lblFromDate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 291);
            this.groupBox2.TabIndex = 75;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bộ lọc";
            // 
            // lueCheDo
            // 
            this.lueCheDo.Location = new System.Drawing.Point(112, 120);
            this.lueCheDo.Name = "lueCheDo";
            // 
            // 
            // 
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
            this.lueCheDo.TabIndex = 72;
            // 
            // btnReset
            // 
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Appearance.Options.UseFont = true;
            this.btnReset.Location = new System.Drawing.Point(22, 173);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(108, 32);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Làm mới";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.Location = new System.Drawing.Point(154, 173);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(108, 32);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lueTaiXe
            // 
            this.lueTaiXe.Location = new System.Drawing.Point(112, 90);
            this.lueTaiXe.Name = "lueTaiXe";
            // 
            // 
            // 
            this.lueTaiXe.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueTaiXe.Properties.Appearance.Options.UseFont = true;
            this.lueTaiXe.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTaiXe.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TaiXeID", "TaiXeID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenTaiXe", "Tên Tài xế")});
            this.lueTaiXe.Properties.DisplayMember = "TenTaiXe";
            this.lueTaiXe.Properties.NullText = "";
            this.lueTaiXe.Properties.ValueMember = "TaiXeID";
            this.lueTaiXe.Size = new System.Drawing.Size(150, 22);
            this.lueTaiXe.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(22, 123);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 16);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Chế độ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(22, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 16);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Tên Tài xế";
            // 
            // datToDate
            // 
            this.datToDate.EditValue = new System.DateTime(2024, 5, 20, 0, 0, 0, 0);
            this.datToDate.Location = new System.Drawing.Point(112, 60);
            this.datToDate.Name = "datToDate";
            // 
            // 
            // 
            this.datToDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datToDate.Properties.Appearance.Options.UseFont = true;
            this.datToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            // 
            // 
            // 
            this.datToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datToDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datToDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datToDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datToDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datToDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datToDate.Size = new System.Drawing.Size(150, 22);
            this.datToDate.TabIndex = 3;
            // 
            // datFromDate
            // 
            this.datFromDate.EditValue = new System.DateTime(2024, 5, 20, 0, 0, 0, 0);
            this.datFromDate.Location = new System.Drawing.Point(112, 30);
            this.datFromDate.Name = "datFromDate";
            // 
            // 
            // 
            this.datFromDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datFromDate.Properties.Appearance.Options.UseFont = true;
            this.datFromDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            // 
            // 
            // 
            this.datFromDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFromDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datFromDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datFromDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datFromDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datFromDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datFromDate.Size = new System.Drawing.Size(150, 22);
            this.datFromDate.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(22, 63);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Đến ngày";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Appearance.Options.UseFont = true;
            this.lblFromDate.Location = new System.Drawing.Point(22, 33);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(69, 16);
            this.lblFromDate.TabIndex = 0;
            this.lblFromDate.Text = "Tạo từ ngày";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExportExcel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(2, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 146);
            this.groupBox1.TabIndex = 74;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xuất dữ liệu";
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
            this.panelControl1.Size = new System.Drawing.Size(913, 50);
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
            this.labelControl4.Size = new System.Drawing.Size(903, 0);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "BÁO CÁO CHI TIẾT TÀI XẾ";
            // 
            // ReportChiTietTaiXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ReportChiTietTaiXe";
            this.Size = new System.Drawing.Size(913, 516);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcChiTietTaiXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvChiTietTaiXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCheDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTaiXe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grcChiTietTaiXe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvChiTietTaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn gcMaTaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn gcTenTaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotal_Tranfer;
        private DevExpress.XtraGrid.Columns.GridColumn gcTotal_KL;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.LookUpEdit lueCheDo;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraEditors.LookUpEdit lueTaiXe;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit datToDate;
        private DevExpress.XtraEditors.DateEdit datFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}

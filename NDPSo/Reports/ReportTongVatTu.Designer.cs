
namespace NDPSo.Reports
{
    partial class ReportTongVatTu
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
            this.grcTongVatTu = new DevExpress.XtraGrid.GridControl();
            this.grvTongVatTu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMaVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNgayMeTron = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTenVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCapPhoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcThucCan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSaiSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPerSaiSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lueCheDo = new DevExpress.XtraEditors.LookUpEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.lueMaterial = new DevExpress.XtraEditors.LookUpEdit();
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTongVatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTongVatTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCheDo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaterial.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grcTongVatTu);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(629, 462);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Dữ liệu";
            // 
            // grcTongVatTu
            // 
            this.grcTongVatTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcTongVatTu.Location = new System.Drawing.Point(2, 23);
            this.grcTongVatTu.MainView = this.grvTongVatTu;
            this.grcTongVatTu.Name = "grcTongVatTu";
            this.grcTongVatTu.Size = new System.Drawing.Size(625, 437);
            this.grcTongVatTu.TabIndex = 0;
            this.grcTongVatTu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTongVatTu});
            // 
            // grvTongVatTu
            // 
            this.grvTongVatTu.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.DodgerBlue;
            this.grvTongVatTu.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvTongVatTu.AppearancePrint.HeaderPanel.ForeColor = System.Drawing.Color.White;
            this.grvTongVatTu.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
            this.grvTongVatTu.AppearancePrint.HeaderPanel.Options.UseFont = true;
            this.grvTongVatTu.AppearancePrint.HeaderPanel.Options.UseForeColor = true;
            this.grvTongVatTu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMaVatTu,
            this.gcNgayMeTron,
            this.gcTenVatTu,
            this.gcCapPhoi,
            this.gcThucCan,
            this.gcSaiSo,
            this.gcPerSaiSo});
            this.grvTongVatTu.GridControl = this.grcTongVatTu;
            this.grvTongVatTu.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Sum_ValueCP", this.gcCapPhoi, "Tổng CP:{0:0.##}", "Sum_ValueCP"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Sum_ValueBat", this.gcThucCan, "Tổng Thực cân:{0:0.##}", "Sum_ValueBat"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Custom, "", this.gcSaiSo, "Sai số: {Sum_ValueCP} -{Sum_ValueBat}")});
            this.grvTongVatTu.Name = "grvTongVatTu";
            this.grvTongVatTu.OptionsBehavior.AlignGroupSummaryInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.grvTongVatTu.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvTongVatTu.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.grvTongVatTu.OptionsView.ShowFooter = true;
            this.grvTongVatTu.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcTenVatTu, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gcMaVatTu
            // 
            this.gcMaVatTu.Caption = "Mã Vật tư";
            this.gcMaVatTu.FieldName = "MaterialCode";
            this.gcMaVatTu.GroupFormat.FormatString = "d";
            this.gcMaVatTu.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gcMaVatTu.Name = "gcMaVatTu";
            this.gcMaVatTu.OptionsColumn.AllowFocus = false;
            this.gcMaVatTu.OptionsColumn.ReadOnly = true;
            this.gcMaVatTu.Visible = true;
            this.gcMaVatTu.VisibleIndex = 0;
            // 
            // gcNgayMeTron
            // 
            this.gcNgayMeTron.Caption = "Ngày trộn";
            this.gcNgayMeTron.FieldName = "NgayMeTron";
            this.gcNgayMeTron.Name = "gcNgayMeTron";
            this.gcNgayMeTron.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            // 
            // gcTenVatTu
            // 
            this.gcTenVatTu.Caption = "Tên Vật tư";
            this.gcTenVatTu.FieldName = "MaterialName";
            this.gcTenVatTu.GroupFormat.FormatString = "d";
            this.gcTenVatTu.GroupFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gcTenVatTu.Name = "gcTenVatTu";
            this.gcTenVatTu.OptionsColumn.AllowFocus = false;
            this.gcTenVatTu.OptionsColumn.ReadOnly = true;
            this.gcTenVatTu.Visible = true;
            this.gcTenVatTu.VisibleIndex = 1;
            // 
            // gcPerSaiSo
            // 
            this.gcPerSaiSo.Caption = "% Sai số";
            this.gcPerSaiSo.DisplayFormat.FormatString = "n2";
            this.gcPerSaiSo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPerSaiSo.FieldName = "PerSaiSo";
            this.gcPerSaiSo.GroupFormat.FormatString = "n2";
            this.gcPerSaiSo.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcPerSaiSo.Name = "gcPerSaiSo";
            this.gcPerSaiSo.OptionsColumn.AllowFocus = false;
            this.gcPerSaiSo.OptionsColumn.ReadOnly = true;
            this.gcPerSaiSo.Visible = true;
            this.gcPerSaiSo.VisibleIndex = 5;
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
            this.groupBox2.Controls.Add(this.simpleButton1);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Controls.Add(this.lueMaterial);
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
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(21, 170);
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
            this.btnTimKiem.Location = new System.Drawing.Point(154, 170);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(108, 32);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // lueMaterial
            // 
            this.lueMaterial.Location = new System.Drawing.Point(112, 90);
            this.lueMaterial.Name = "lueMaterial";
            this.lueMaterial.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueMaterial.Properties.Appearance.Options.UseFont = true;
            this.lueMaterial.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMaterial.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaterialID", "MaterialID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaterialCode", "Mã Vật tư"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaterialName", "Tên Vật tư")});
            this.lueMaterial.Properties.DisplayMember = "MaterialName";
            this.lueMaterial.Properties.NullText = "";
            this.lueMaterial.Properties.ValueMember = "MaterialID";
            this.lueMaterial.Size = new System.Drawing.Size(150, 22);
            this.lueMaterial.TabIndex = 6;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(21, 123);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(40, 16);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Chế độ";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(21, 93);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(61, 16);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Tên Vật tư";
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
            this.datToDate.TabIndex = 3;
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
            this.datFromDate.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(21, 63);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Đến ngày";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Appearance.Options.UseFont = true;
            this.lblFromDate.Location = new System.Drawing.Point(21, 33);
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
            this.panelControl1.TabIndex = 2;
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
            this.labelControl4.Size = new System.Drawing.Size(903, 50);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "BÁO CÁO TỔNG VẬT TƯ";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 50);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(913, 466);
            this.panelControl2.TabIndex = 3;
            // 
            // ReportTongVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "ReportTongVatTu";
            this.Size = new System.Drawing.Size(913, 516);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcTongVatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTongVatTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueCheDo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMaterial.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.DateEdit datToDate;
        private DevExpress.XtraEditors.DateEdit datFromDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
        private DevExpress.XtraEditors.LookUpEdit lueMaterial;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl grcTongVatTu;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTongVatTu;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LookUpEdit lueCheDo;
        private DevExpress.XtraGrid.Columns.GridColumn gcTenVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn gcCapPhoi;
        private DevExpress.XtraGrid.Columns.GridColumn gcThucCan;
        private DevExpress.XtraGrid.Columns.GridColumn gcSaiSo;
        private DevExpress.XtraGrid.Columns.GridColumn gcPerSaiSo;
        private DevExpress.XtraGrid.Columns.GridColumn gcMaVatTu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.SimpleButton btnExportExcel;
        private DevExpress.XtraGrid.Columns.GridColumn gcNgayMeTron;
    }
}

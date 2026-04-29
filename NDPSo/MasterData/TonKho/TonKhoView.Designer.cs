
namespace NDPSo.MasterData.TonKho
{
    partial class TonKhoView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop           = new DevExpress.XtraEditors.PanelControl();
            this.lblSummary       = new DevExpress.XtraEditors.LabelControl();
            this.btnNhapKho       = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh       = new DevExpress.XtraEditors.SimpleButton();
            this.grpTonKho        = new DevExpress.XtraEditors.GroupControl();
            this.grcTonKho        = new DevExpress.XtraGrid.GridControl();
            this.grvTonKho        = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMaSilo         = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTenSilo        = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMaterialName   = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSoLuongTon     = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMucCanhBao     = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTrangThai      = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpNhuCau        = new DevExpress.XtraEditors.GroupControl();
            this.grcNhuCau        = new DevExpress.XtraGrid.GridControl();
            this.grvNhuCau        = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcNC_Material    = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNC_MaSilo      = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNC_TonHienTai  = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNC_TongCanDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNC_ChenhLech   = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNC_TrangThai   = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTonKho)).BeginInit();
            this.grpTonKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpNhuCau)).BeginInit();
            this.grpNhuCau.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcNhuCau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhuCau)).BeginInit();
            this.SuspendLayout();
            //
            // pnlTop
            //
            this.pnlTop.Controls.Add(this.lblSummary);
            this.pnlTop.Controls.Add(this.btnNhapKho);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1100, 46);
            this.pnlTop.TabIndex = 0;
            //
            // lblSummary
            //
            this.lblSummary.Appearance.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblSummary.Appearance.Options.UseFont = true;
            this.lblSummary.Location = new System.Drawing.Point(220, 13);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(200, 18);
            this.lblSummary.TabIndex = 2;
            this.lblSummary.Text = "Đang tải...";
            //
            // btnNhapKho
            //
            this.btnNhapKho.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnNhapKho.Appearance.Options.UseFont = true;
            this.btnNhapKho.Location = new System.Drawing.Point(8, 9);
            this.btnNhapKho.Name = "btnNhapKho";
            this.btnNhapKho.Size = new System.Drawing.Size(120, 28);
            this.btnNhapKho.TabIndex = 0;
            this.btnNhapKho.Text = "Nhập Kho";
            this.btnNhapKho.Click += new System.EventHandler(this.btnNhapKho_Click);
            //
            // btnRefresh
            //
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(136, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(78, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            //
            // grpTonKho
            //
            this.grpTonKho.Controls.Add(this.grcTonKho);
            this.grpTonKho.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTonKho.Location = new System.Drawing.Point(0, 46);
            this.grpTonKho.Name = "grpTonKho";
            this.grpTonKho.Size = new System.Drawing.Size(1100, 300);
            this.grpTonKho.TabIndex = 1;
            this.grpTonKho.Text = "Tồn Kho Hiện Tại";
            //
            // grcTonKho
            //
            this.grcTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcTonKho.Location = new System.Drawing.Point(2, 21);
            this.grcTonKho.MainView = this.grvTonKho;
            this.grcTonKho.Name = "grcTonKho";
            this.grcTonKho.Size = new System.Drawing.Size(1096, 277);
            this.grcTonKho.TabIndex = 0;
            this.grcTonKho.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.grvTonKho });
            //
            // grvTonKho
            //
            this.grvTonKho.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.gcMaSilo, this.gcTenSilo, this.gcMaterialName,
                this.gcSoLuongTon, this.gcMucCanhBao, this.gcTrangThai });
            this.grvTonKho.GridControl = this.grcTonKho;
            this.grvTonKho.Name = "grvTonKho";
            this.grvTonKho.OptionsBehavior.Editable = false;
            this.grvTonKho.OptionsView.ShowGroupPanel = false;
            this.grvTonKho.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvTonKho_RowStyle);
            this.grvTonKho.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grvTonKho_CustomColumnDisplayText);
            //
            // gcMaSilo
            //
            this.gcMaSilo.Caption = "Mã Silo";
            this.gcMaSilo.FieldName = "MaSilo";
            this.gcMaSilo.Name = "gcMaSilo";
            this.gcMaSilo.Visible = true;
            this.gcMaSilo.VisibleIndex = 0;
            this.gcMaSilo.Width = 80;
            //
            // gcTenSilo
            //
            this.gcTenSilo.Caption = "Tên Silo";
            this.gcTenSilo.FieldName = "TenSilo";
            this.gcTenSilo.Name = "gcTenSilo";
            this.gcTenSilo.Visible = true;
            this.gcTenSilo.VisibleIndex = 1;
            this.gcTenSilo.Width = 150;
            //
            // gcMaterialName
            //
            this.gcMaterialName.Caption = "Vật Liệu";
            this.gcMaterialName.FieldName = "MaterialName";
            this.gcMaterialName.Name = "gcMaterialName";
            this.gcMaterialName.Visible = true;
            this.gcMaterialName.VisibleIndex = 2;
            this.gcMaterialName.Width = 150;
            //
            // gcSoLuongTon
            //
            this.gcSoLuongTon.Caption = "Tồn (kg)";
            this.gcSoLuongTon.FieldName = "SoLuongTon";
            this.gcSoLuongTon.Name = "gcSoLuongTon";
            this.gcSoLuongTon.Visible = true;
            this.gcSoLuongTon.VisibleIndex = 3;
            this.gcSoLuongTon.Width = 100;
            //
            // gcMucCanhBao
            //
            this.gcMucCanhBao.Caption = "Mức C.Báo (kg)";
            this.gcMucCanhBao.FieldName = "MucCanhBao";
            this.gcMucCanhBao.Name = "gcMucCanhBao";
            this.gcMucCanhBao.Visible = true;
            this.gcMucCanhBao.VisibleIndex = 4;
            this.gcMucCanhBao.Width = 110;
            //
            // gcTrangThai
            //
            this.gcTrangThai.Caption = "Trạng Thái";
            this.gcTrangThai.FieldName = "TrangThai";
            this.gcTrangThai.Name = "gcTrangThai";
            this.gcTrangThai.Visible = true;
            this.gcTrangThai.VisibleIndex = 5;
            this.gcTrangThai.Width = 90;
            //
            // grpNhuCau
            //
            this.grpNhuCau.Controls.Add(this.grcNhuCau);
            this.grpNhuCau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNhuCau.Location = new System.Drawing.Point(0, 346);
            this.grpNhuCau.Name = "grpNhuCau";
            this.grpNhuCau.Size = new System.Drawing.Size(1100, 354);
            this.grpNhuCau.TabIndex = 2;
            this.grpNhuCau.Text = "Kiểm Tra Tồn Kho vs Đơn Hàng Đang Chờ";
            //
            // grcNhuCau
            //
            this.grcNhuCau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcNhuCau.Location = new System.Drawing.Point(2, 21);
            this.grcNhuCau.MainView = this.grvNhuCau;
            this.grcNhuCau.Name = "grcNhuCau";
            this.grcNhuCau.Size = new System.Drawing.Size(1096, 331);
            this.grcNhuCau.TabIndex = 0;
            this.grcNhuCau.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.grvNhuCau });
            //
            // grvNhuCau
            //
            this.grvNhuCau.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.gcNC_Material, this.gcNC_MaSilo, this.gcNC_TonHienTai,
                this.gcNC_TongCanDung, this.gcNC_ChenhLech, this.gcNC_TrangThai });
            this.grvNhuCau.GridControl = this.grcNhuCau;
            this.grvNhuCau.Name = "grvNhuCau";
            this.grvNhuCau.OptionsBehavior.Editable = false;
            this.grvNhuCau.OptionsView.ShowGroupPanel = false;
            this.grvNhuCau.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvNhuCau_RowStyle);
            this.grvNhuCau.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.grvNhuCau_CustomColumnDisplayText);
            //
            // gcNC_Material
            //
            this.gcNC_Material.Caption = "Vật Liệu";
            this.gcNC_Material.FieldName = "MaterialName";
            this.gcNC_Material.Name = "gcNC_Material";
            this.gcNC_Material.Visible = true;
            this.gcNC_Material.VisibleIndex = 0;
            this.gcNC_Material.Width = 150;
            //
            // gcNC_MaSilo
            //
            this.gcNC_MaSilo.Caption = "Mã Silo";
            this.gcNC_MaSilo.FieldName = "MaSilo";
            this.gcNC_MaSilo.Name = "gcNC_MaSilo";
            this.gcNC_MaSilo.Visible = true;
            this.gcNC_MaSilo.VisibleIndex = 1;
            this.gcNC_MaSilo.Width = 80;
            //
            // gcNC_TonHienTai
            //
            this.gcNC_TonHienTai.Caption = "Tồn Hiện Tại (kg)";
            this.gcNC_TonHienTai.FieldName = "TonHienTai";
            this.gcNC_TonHienTai.Name = "gcNC_TonHienTai";
            this.gcNC_TonHienTai.Visible = true;
            this.gcNC_TonHienTai.VisibleIndex = 2;
            this.gcNC_TonHienTai.Width = 120;
            //
            // gcNC_TongCanDung
            //
            this.gcNC_TongCanDung.Caption = "Cần Dùng (kg)";
            this.gcNC_TongCanDung.FieldName = "TongCanDung";
            this.gcNC_TongCanDung.Name = "gcNC_TongCanDung";
            this.gcNC_TongCanDung.Visible = true;
            this.gcNC_TongCanDung.VisibleIndex = 3;
            this.gcNC_TongCanDung.Width = 110;
            //
            // gcNC_ChenhLech
            //
            this.gcNC_ChenhLech.Caption = "Chênh Lệch (kg)";
            this.gcNC_ChenhLech.FieldName = "ChenhLech";
            this.gcNC_ChenhLech.Name = "gcNC_ChenhLech";
            this.gcNC_ChenhLech.Visible = true;
            this.gcNC_ChenhLech.VisibleIndex = 4;
            this.gcNC_ChenhLech.Width = 120;
            //
            // gcNC_TrangThai
            //
            this.gcNC_TrangThai.Caption = "Trạng Thái";
            this.gcNC_TrangThai.FieldName = "TrangThai";
            this.gcNC_TrangThai.Name = "gcNC_TrangThai";
            this.gcNC_TrangThai.Visible = true;
            this.gcNC_TrangThai.VisibleIndex = 5;
            this.gcNC_TrangThai.Width = 90;
            //
            // TonKhoView
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpNhuCau);
            this.Controls.Add(this.grpTonKho);
            this.Controls.Add(this.pnlTop);
            this.Name = "TonKhoView";
            this.Size = new System.Drawing.Size(1100, 700);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTop)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpTonKho)).EndInit();
            this.grpTonKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpNhuCau)).EndInit();
            this.grpNhuCau.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcNhuCau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNhuCau)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl     pnlTop;
        private DevExpress.XtraEditors.LabelControl     lblSummary;
        private DevExpress.XtraEditors.SimpleButton     btnNhapKho;
        private DevExpress.XtraEditors.SimpleButton     btnRefresh;
        private DevExpress.XtraEditors.GroupControl     grpTonKho;
        private DevExpress.XtraGrid.GridControl         grcTonKho;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTonKho;
        private DevExpress.XtraGrid.Columns.GridColumn  gcMaSilo;
        private DevExpress.XtraGrid.Columns.GridColumn  gcTenSilo;
        private DevExpress.XtraGrid.Columns.GridColumn  gcMaterialName;
        private DevExpress.XtraGrid.Columns.GridColumn  gcSoLuongTon;
        private DevExpress.XtraGrid.Columns.GridColumn  gcMucCanhBao;
        private DevExpress.XtraGrid.Columns.GridColumn  gcTrangThai;
        private DevExpress.XtraEditors.GroupControl     grpNhuCau;
        private DevExpress.XtraGrid.GridControl         grcNhuCau;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNhuCau;
        private DevExpress.XtraGrid.Columns.GridColumn  gcNC_Material;
        private DevExpress.XtraGrid.Columns.GridColumn  gcNC_MaSilo;
        private DevExpress.XtraGrid.Columns.GridColumn  gcNC_TonHienTai;
        private DevExpress.XtraGrid.Columns.GridColumn  gcNC_TongCanDung;
        private DevExpress.XtraGrid.Columns.GridColumn  gcNC_ChenhLech;
        private DevExpress.XtraGrid.Columns.GridColumn  gcNC_TrangThai;
    }
}

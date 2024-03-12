
namespace NDPSo.MasterData
{
    partial class SiloMngView
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
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bsiCaption = new DevExpress.XtraBars.BarStaticItem();
            this.bbiInsert = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiView = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grcMaster = new DevExpress.XtraEditors.GroupControl();
            this.grcSilo = new DevExpress.XtraGrid.GridControl();
            this.graSilo = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gcNhomSilo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.ilueNhomSilo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcMaSilo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcTenSilo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcSaiSoDuoi = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcSaiSoTren = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcKLCanNhoNhat = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcKLCanLonNhat = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcTGNhapNhaOn = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcTGNhapNhaOff = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcTGKiemTraVatLieuRoi = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcKLRoi = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcKPulse = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcSoTT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcActivated = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcTu1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcDen1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcDungTruoc1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcTu2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcDen2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcDungTruoc2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcTu3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcDen3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gcDungTruoc3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grdBandThongSoSilo = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.grdBandThongSoKhac = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMaster)).BeginInit();
            this.grcMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcSilo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graSilo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilueNhomSilo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bsiCaption,
            this.bbiInsert,
            this.bbiUpdate,
            this.bbiDelete,
            this.bbiView});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 5;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiInsert),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiUpdate),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiView)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bsiCaption
            // 
            this.bsiCaption.Caption = "Silo";
            this.bsiCaption.Id = 0;
            this.bsiCaption.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsiCaption.ItemAppearance.Normal.Options.UseFont = true;
            this.bsiCaption.Name = "bsiCaption";
            // 
            // bbiInsert
            // 
            this.bbiInsert.Caption = "Thêm";
            this.bbiInsert.Id = 1;
            this.bbiInsert.ImageOptions.Image = global::NDPSo.ResourceNDP.add__3_;
            this.bbiInsert.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbiInsert.ItemAppearance.Normal.Options.UseFont = true;
            this.bbiInsert.Name = "bbiInsert";
            this.bbiInsert.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiInsert.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiInsert_ItemClick);
            // 
            // bbiUpdate
            // 
            this.bbiUpdate.Caption = "Sửa";
            this.bbiUpdate.Id = 2;
            this.bbiUpdate.ImageOptions.Image = global::NDPSo.ResourceNDP.edit_fi;
            this.bbiUpdate.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbiUpdate.ItemAppearance.Normal.Options.UseFont = true;
            this.bbiUpdate.Name = "bbiUpdate";
            this.bbiUpdate.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUpdate_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Xoá";
            this.bbiDelete.Id = 3;
            this.bbiDelete.ImageOptions.Image = global::NDPSo.ResourceNDP.delete;
            this.bbiDelete.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbiDelete.ItemAppearance.Normal.Options.UseFont = true;
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiView
            // 
            this.bbiView.Caption = "Xem";
            this.bbiView.Id = 4;
            this.bbiView.ImageOptions.Image = global::NDPSo.ResourceNDP.wath_;
            this.bbiView.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbiView.ItemAppearance.Normal.Options.UseFont = true;
            this.bbiView.Name = "bbiView";
            this.bbiView.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiView_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(848, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 488);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(848, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 448);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(848, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 448);
            // 
            // grcMaster
            // 
            this.grcMaster.Controls.Add(this.grcSilo);
            this.grcMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcMaster.Location = new System.Drawing.Point(0, 40);
            this.grcMaster.Margin = new System.Windows.Forms.Padding(2);
            this.grcMaster.Name = "grcMaster";
            this.grcMaster.Size = new System.Drawing.Size(848, 448);
            this.grcMaster.TabIndex = 4;
            this.grcMaster.Text = "Dữ liệu";
            // 
            // grcSilo
            // 
            this.grcSilo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcSilo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grcSilo.Location = new System.Drawing.Point(2, 23);
            this.grcSilo.MainView = this.graSilo;
            this.grcSilo.Margin = new System.Windows.Forms.Padding(2);
            this.grcSilo.MenuManager = this.barManager1;
            this.grcSilo.Name = "grcSilo";
            this.grcSilo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.ilueNhomSilo});
            this.grcSilo.Size = new System.Drawing.Size(844, 423);
            this.grcSilo.TabIndex = 0;
            this.grcSilo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.graSilo});
            // 
            // graSilo
            // 
            this.graSilo.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand3,
            this.grdBandThongSoSilo,
            this.grdBandThongSoKhac});
            this.graSilo.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gcMaSilo,
            this.gcTenSilo,
            this.gcNhomSilo,
            this.gcSaiSoDuoi,
            this.gcSaiSoTren,
            this.gcKLCanNhoNhat,
            this.gcKLCanLonNhat,
            this.gcTGNhapNhaOn,
            this.gcTGNhapNhaOff,
            this.gcTGKiemTraVatLieuRoi,
            this.gcKLRoi,
            this.gcKPulse,
            this.gcSoTT,
            this.gcActivated,
            this.gcTu1,
            this.gcDen1,
            this.gcDungTruoc1,
            this.gcTu2,
            this.gcDen2,
            this.gcDungTruoc2,
            this.gcTu3,
            this.gcDen3,
            this.gcDungTruoc3});
            this.graSilo.DetailHeight = 284;
            this.graSilo.GridControl = this.grcSilo;
            this.graSilo.Name = "graSilo";
            // 
            // gcNhomSilo
            // 
            this.gcNhomSilo.Caption = "Nhóm Silo";
            this.gcNhomSilo.ColumnEdit = this.ilueNhomSilo;
            this.gcNhomSilo.FieldName = "NhomSiloID";
            this.gcNhomSilo.MinWidth = 324;
            this.gcNhomSilo.Name = "gcNhomSilo";
            this.gcNhomSilo.OptionsColumn.AllowEdit = false;
            this.gcNhomSilo.RowCount = 3;
            this.gcNhomSilo.Width = 378;
            // 
            // ilueNhomSilo
            // 
            this.ilueNhomSilo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ilueNhomSilo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NhomSiloID", "Name4", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaNhomSilo", "Mã Nhóm Silo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenNhomSilo", "Tên Nhóm Silo")});
            this.ilueNhomSilo.Name = "ilueNhomSilo";
            // 
            // gcMaSilo
            // 
            this.gcMaSilo.Caption = "Mã Silo";
            this.gcMaSilo.FieldName = "MaSilo";
            this.gcMaSilo.MinWidth = 324;
            this.gcMaSilo.Name = "gcMaSilo";
            this.gcMaSilo.OptionsColumn.AllowEdit = false;
            this.gcMaSilo.Visible = true;
            this.gcMaSilo.Width = 324;
            // 
            // gcTenSilo
            // 
            this.gcTenSilo.Caption = "Tên Silo";
            this.gcTenSilo.FieldName = "TenSilo";
            this.gcTenSilo.MinWidth = 324;
            this.gcTenSilo.Name = "gcTenSilo";
            this.gcTenSilo.OptionsColumn.AllowEdit = false;
            this.gcTenSilo.RowIndex = 1;
            this.gcTenSilo.Visible = true;
            this.gcTenSilo.Width = 324;
            // 
            // gcSaiSoDuoi
            // 
            this.gcSaiSoDuoi.Caption = "Sai Số Dưới [%]";
            this.gcSaiSoDuoi.FieldName = "SaiSoDuoi";
            this.gcSaiSoDuoi.MinWidth = 119;
            this.gcSaiSoDuoi.Name = "gcSaiSoDuoi";
            this.gcSaiSoDuoi.OptionsColumn.AllowEdit = false;
            this.gcSaiSoDuoi.RowCount = 2;
            this.gcSaiSoDuoi.Visible = true;
            this.gcSaiSoDuoi.Width = 119;
            // 
            // gcSaiSoTren
            // 
            this.gcSaiSoTren.Caption = "Sai Số Trên [%]";
            this.gcSaiSoTren.FieldName = "SaiSoTren";
            this.gcSaiSoTren.MinWidth = 119;
            this.gcSaiSoTren.Name = "gcSaiSoTren";
            this.gcSaiSoTren.OptionsColumn.AllowEdit = false;
            this.gcSaiSoTren.RowCount = 2;
            this.gcSaiSoTren.Visible = true;
            this.gcSaiSoTren.Width = 119;
            // 
            // gcKLCanNhoNhat
            // 
            this.gcKLCanNhoNhat.Caption = "KL Cân Nhỏ Nhất [Kg]";
            this.gcKLCanNhoNhat.FieldName = "KLCanNhoNhat";
            this.gcKLCanNhoNhat.MinWidth = 119;
            this.gcKLCanNhoNhat.Name = "gcKLCanNhoNhat";
            this.gcKLCanNhoNhat.OptionsColumn.AllowEdit = false;
            this.gcKLCanNhoNhat.RowCount = 2;
            this.gcKLCanNhoNhat.Visible = true;
            this.gcKLCanNhoNhat.Width = 119;
            // 
            // gcKLCanLonNhat
            // 
            this.gcKLCanLonNhat.Caption = "KL Cân Lớn Nhất [Kg]";
            this.gcKLCanLonNhat.FieldName = "KLCanLonNhat";
            this.gcKLCanLonNhat.MinWidth = 119;
            this.gcKLCanLonNhat.Name = "gcKLCanLonNhat";
            this.gcKLCanLonNhat.OptionsColumn.AllowEdit = false;
            this.gcKLCanLonNhat.RowCount = 2;
            this.gcKLCanLonNhat.Visible = true;
            this.gcKLCanLonNhat.Width = 119;
            // 
            // gcTGNhapNhaOn
            // 
            this.gcTGNhapNhaOn.Caption = "TG Nhấp Nhả On [0.1s]";
            this.gcTGNhapNhaOn.FieldName = "TGNhapNhaOn";
            this.gcTGNhapNhaOn.MinWidth = 119;
            this.gcTGNhapNhaOn.Name = "gcTGNhapNhaOn";
            this.gcTGNhapNhaOn.OptionsColumn.AllowEdit = false;
            this.gcTGNhapNhaOn.RowCount = 2;
            this.gcTGNhapNhaOn.Visible = true;
            this.gcTGNhapNhaOn.Width = 119;
            // 
            // gcTGNhapNhaOff
            // 
            this.gcTGNhapNhaOff.Caption = "TG Nhấp Nhả Off [0.1s]";
            this.gcTGNhapNhaOff.FieldName = "TGNhapNhaOff";
            this.gcTGNhapNhaOff.MinWidth = 119;
            this.gcTGNhapNhaOff.Name = "gcTGNhapNhaOff";
            this.gcTGNhapNhaOff.OptionsColumn.AllowEdit = false;
            this.gcTGNhapNhaOff.RowCount = 2;
            this.gcTGNhapNhaOff.Visible = true;
            this.gcTGNhapNhaOff.Width = 119;
            // 
            // gcTGKiemTraVatLieuRoi
            // 
            this.gcTGKiemTraVatLieuRoi.Caption = "TG Tính Lượng Rơi Thêm [0.1s]";
            this.gcTGKiemTraVatLieuRoi.FieldName = "TGKiemTraVatLieuRoi";
            this.gcTGKiemTraVatLieuRoi.MinWidth = 119;
            this.gcTGKiemTraVatLieuRoi.Name = "gcTGKiemTraVatLieuRoi";
            this.gcTGKiemTraVatLieuRoi.OptionsColumn.AllowEdit = false;
            this.gcTGKiemTraVatLieuRoi.RowCount = 2;
            this.gcTGKiemTraVatLieuRoi.Visible = true;
            this.gcTGKiemTraVatLieuRoi.Width = 119;
            // 
            // gcKLRoi
            // 
            this.gcKLRoi.Caption = "KL Rơi [Kg]";
            this.gcKLRoi.FieldName = "KLRoi";
            this.gcKLRoi.MinWidth = 119;
            this.gcKLRoi.Name = "gcKLRoi";
            this.gcKLRoi.OptionsColumn.AllowEdit = false;
            this.gcKLRoi.RowCount = 2;
            this.gcKLRoi.Visible = true;
            this.gcKLRoi.Width = 119;
            // 
            // gcKPulse
            // 
            this.gcKPulse.Caption = "Xung";
            this.gcKPulse.DisplayFormat.FormatString = "n0";
            this.gcKPulse.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcKPulse.FieldName = "K_Pulse";
            this.gcKPulse.MinWidth = 119;
            this.gcKPulse.Name = "gcKPulse";
            this.gcKPulse.OptionsColumn.AllowEdit = false;
            this.gcKPulse.RowCount = 2;
            this.gcKPulse.Width = 119;
            // 
            // gcSoTT
            // 
            this.gcSoTT.Caption = "STT";
            this.gcSoTT.FieldName = "SoTT";
            this.gcSoTT.MinWidth = 238;
            this.gcSoTT.Name = "gcSoTT";
            this.gcSoTT.OptionsColumn.AllowEdit = false;
            this.gcSoTT.RowCount = 2;
            this.gcSoTT.Visible = true;
            this.gcSoTT.Width = 238;
            // 
            // gcActivated
            // 
            this.gcActivated.AppearanceHeader.Options.UseTextOptions = true;
            this.gcActivated.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcActivated.Caption = "Kích Hoạt";
            this.gcActivated.FieldName = "Activated";
            this.gcActivated.MinWidth = 238;
            this.gcActivated.Name = "gcActivated";
            this.gcActivated.OptionsColumn.AllowEdit = false;
            this.gcActivated.RowCount = 2;
            this.gcActivated.Width = 238;
            // 
            // gcTu1
            // 
            this.gcTu1.AppearanceHeader.Options.UseTextOptions = true;
            this.gcTu1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcTu1.Caption = "Từ";
            this.gcTu1.FieldName = "KLDT_Tu1";
            this.gcTu1.MinWidth = 750;
            this.gcTu1.Name = "gcTu1";
            this.gcTu1.Visible = true;
            this.gcTu1.Width = 7045;
            // 
            // gcDen1
            // 
            this.gcDen1.AppearanceHeader.Options.UseTextOptions = true;
            this.gcDen1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcDen1.Caption = "Đến";
            this.gcDen1.FieldName = "KLDT_Den1";
            this.gcDen1.MinWidth = 750;
            this.gcDen1.Name = "gcDen1";
            this.gcDen1.Visible = true;
            this.gcDen1.Width = 7045;
            // 
            // gcDungTruoc1
            // 
            this.gcDungTruoc1.Caption = "Dừng Trước";
            this.gcDungTruoc1.FieldName = "KLDT_DungTruoc1";
            this.gcDungTruoc1.MinWidth = 750;
            this.gcDungTruoc1.Name = "gcDungTruoc1";
            this.gcDungTruoc1.Visible = true;
            this.gcDungTruoc1.Width = 7045;
            // 
            // gcTu2
            // 
            this.gcTu2.Caption = "Từ 2";
            this.gcTu2.FieldName = "KLDT_Tu2";
            this.gcTu2.MinWidth = 750;
            this.gcTu2.Name = "gcTu2";
            this.gcTu2.Visible = true;
            this.gcTu2.Width = 7045;
            // 
            // gcDen2
            // 
            this.gcDen2.Caption = "Đến2";
            this.gcDen2.FieldName = "KLDT_Den2";
            this.gcDen2.MinWidth = 750;
            this.gcDen2.Name = "gcDen2";
            this.gcDen2.Visible = true;
            this.gcDen2.Width = 7045;
            // 
            // gcDungTruoc2
            // 
            this.gcDungTruoc2.Caption = "Dừng Trước2";
            this.gcDungTruoc2.FieldName = "KLDT_DungTruoc2";
            this.gcDungTruoc2.MinWidth = 750;
            this.gcDungTruoc2.Name = "gcDungTruoc2";
            this.gcDungTruoc2.Visible = true;
            this.gcDungTruoc2.Width = 7045;
            // 
            // gcTu3
            // 
            this.gcTu3.Caption = "Từ 3";
            this.gcTu3.FieldName = "KLDT_Tu3";
            this.gcTu3.MinWidth = 750;
            this.gcTu3.Name = "gcTu3";
            this.gcTu3.Visible = true;
            this.gcTu3.Width = 7045;
            // 
            // gcDen3
            // 
            this.gcDen3.Caption = "Đến 3";
            this.gcDen3.FieldName = "KLDT_Den3";
            this.gcDen3.MinWidth = 750;
            this.gcDen3.Name = "gcDen3";
            this.gcDen3.Visible = true;
            this.gcDen3.Width = 7045;
            // 
            // gcDungTruoc3
            // 
            this.gcDungTruoc3.Caption = "Dừng Trước";
            this.gcDungTruoc3.FieldName = "KLDT_DungTruoc3";
            this.gcDungTruoc3.MinWidth = 750;
            this.gcDungTruoc3.Name = "gcDungTruoc3";
            this.gcDungTruoc3.Visible = true;
            this.gcDungTruoc3.Width = 7045;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Tên Gọi";
            this.gridBand3.Columns.Add(this.gcNhomSilo);
            this.gridBand3.Columns.Add(this.gcMaSilo);
            this.gridBand3.Columns.Add(this.gcTenSilo);
            this.gridBand3.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand3.MinWidth = 277;
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.OptionsBand.AllowMove = false;
            this.gridBand3.OptionsBand.ShowCaption = false;
            this.gridBand3.VisibleIndex = 0;
            this.gridBand3.Width = 324;
            // 
            // grdBandThongSoSilo
            // 
            this.grdBandThongSoSilo.Caption = "Thông Số Silo";
            this.grdBandThongSoSilo.Columns.Add(this.gcSaiSoDuoi);
            this.grdBandThongSoSilo.Columns.Add(this.gcSaiSoTren);
            this.grdBandThongSoSilo.Columns.Add(this.gcKLCanNhoNhat);
            this.grdBandThongSoSilo.Columns.Add(this.gcKLCanLonNhat);
            this.grdBandThongSoSilo.Columns.Add(this.gcTGNhapNhaOn);
            this.grdBandThongSoSilo.Columns.Add(this.gcTGNhapNhaOff);
            this.grdBandThongSoSilo.Columns.Add(this.gcTGKiemTraVatLieuRoi);
            this.grdBandThongSoSilo.Columns.Add(this.gcKLRoi);
            this.grdBandThongSoSilo.Columns.Add(this.gcKPulse);
            this.grdBandThongSoSilo.MinWidth = 480;
            this.grdBandThongSoSilo.Name = "grdBandThongSoSilo";
            this.grdBandThongSoSilo.VisibleIndex = 1;
            this.grdBandThongSoSilo.Width = 952;
            // 
            // grdBandThongSoKhac
            // 
            this.grdBandThongSoKhac.Caption = "Thông số khác";
            this.grdBandThongSoKhac.Columns.Add(this.gcSoTT);
            this.grdBandThongSoKhac.Columns.Add(this.gcActivated);
            this.grdBandThongSoKhac.MinWidth = 238;
            this.grdBandThongSoKhac.Name = "grdBandThongSoKhac";
            this.grdBandThongSoKhac.Visible = false;
            this.grdBandThongSoKhac.VisibleIndex = -1;
            this.grdBandThongSoKhac.Width = 238;
            // 
            // SiloMngView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcMaster);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "SiloMngView";
            this.Size = new System.Drawing.Size(848, 488);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMaster)).EndInit();
            this.grcMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcSilo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graSilo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilueNhomSilo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarStaticItem bsiCaption;
        private DevExpress.XtraBars.BarButtonItem bbiInsert;
        private DevExpress.XtraBars.BarButtonItem bbiUpdate;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiView;
        private DevExpress.XtraEditors.GroupControl grcMaster;
        private DevExpress.XtraGrid.GridControl grcSilo;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView graSilo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcNhomSilo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ilueNhomSilo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcMaSilo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcTenSilo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcSaiSoDuoi;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcSaiSoTren;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcKLCanNhoNhat;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcKLCanLonNhat;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcTGNhapNhaOn;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcTGNhapNhaOff;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcTGKiemTraVatLieuRoi;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcKLRoi;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcKPulse;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcSoTT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcActivated;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcTu1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcDen1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcDungTruoc1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcTu2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcDen2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcDungTruoc2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcTu3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcDen3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gcDungTruoc3;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grdBandThongSoSilo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand grdBandThongSoKhac;
    }
}

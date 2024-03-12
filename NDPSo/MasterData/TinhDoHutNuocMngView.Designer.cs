
namespace NDPSo.MasterData
{
    partial class TinhDoHutNuocMngView
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
            this.barButtons = new DevExpress.XtraBars.Bar();
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
            this.grcTinhDoHutNuoc = new DevExpress.XtraGrid.GridControl();
            this.grvTinhDoHutNuoc = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMaTinhDoHutNuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNgayTinhDoHut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.idatNgayTinhDoHut = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNhomSilo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ilueNhomSilo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcDoHutNuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnDoHutNuoc = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpStatus = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMaster)).BeginInit();
            this.grcMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTinhDoHutNuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTinhDoHutNuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatNgayTinhDoHut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatNgayTinhDoHut.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilueNhomSilo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnDoHutNuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStatus)).BeginInit();
            this.grpStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barButtons});
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
            this.barManager1.MainMenu = this.barButtons;
            this.barManager1.MaxItemId = 5;
            // 
            // barButtons
            // 
            this.barButtons.BarName = "Main menu";
            this.barButtons.DockCol = 0;
            this.barButtons.DockRow = 0;
            this.barButtons.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barButtons.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiInsert),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiUpdate),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiView)});
            this.barButtons.OptionsBar.MultiLine = true;
            this.barButtons.OptionsBar.UseWholeRow = true;
            this.barButtons.Text = "Main menu";
            // 
            // bsiCaption
            // 
            this.bsiCaption.Caption = "Tính Độ Hút Nước";
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
            this.bbiInsert.Name = "bbiInsert";
            this.bbiInsert.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiInsert.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiInsert_ItemClick);
            // 
            // bbiUpdate
            // 
            this.bbiUpdate.Caption = "Sửa";
            this.bbiUpdate.Id = 2;
            this.bbiUpdate.ImageOptions.Image = global::NDPSo.ResourceNDP.edit_fi;
            this.bbiUpdate.Name = "bbiUpdate";
            this.bbiUpdate.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUpdate_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Xoá";
            this.bbiDelete.Id = 3;
            this.bbiDelete.ImageOptions.Image = global::NDPSo.ResourceNDP.delete;
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiView
            // 
            this.bbiView.Caption = "Xem";
            this.bbiView.Id = 4;
            this.bbiView.ImageOptions.Image = global::NDPSo.ResourceNDP.wath_;
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
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(848, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 488);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(848, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 448);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(848, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 448);
            // 
            // grcMaster
            // 
            this.grcMaster.Controls.Add(this.grcTinhDoHutNuoc);
            this.grcMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcMaster.Location = new System.Drawing.Point(0, 40);
            this.grcMaster.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grcMaster.Name = "grcMaster";
            this.grcMaster.Size = new System.Drawing.Size(848, 448);
            this.grcMaster.TabIndex = 4;
            this.grcMaster.Text = "Dữ liệu";
            // 
            // grcTinhDoHutNuoc
            // 
            this.grcTinhDoHutNuoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcTinhDoHutNuoc.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grcTinhDoHutNuoc.Location = new System.Drawing.Point(2, 23);
            this.grcTinhDoHutNuoc.MainView = this.grvTinhDoHutNuoc;
            this.grcTinhDoHutNuoc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grcTinhDoHutNuoc.MenuManager = this.barManager1;
            this.grcTinhDoHutNuoc.Name = "grcTinhDoHutNuoc";
            this.grcTinhDoHutNuoc.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.idatNgayTinhDoHut,
            this.ilueNhomSilo,
            this.ispnDoHutNuoc});
            this.grcTinhDoHutNuoc.Size = new System.Drawing.Size(844, 423);
            this.grcTinhDoHutNuoc.TabIndex = 0;
            this.grcTinhDoHutNuoc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTinhDoHutNuoc});
            // 
            // grvTinhDoHutNuoc
            // 
            this.grvTinhDoHutNuoc.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMaTinhDoHutNuoc,
            this.gcNgayTinhDoHut,
            this.gcName,
            this.gcNhomSilo,
            this.gcDoHutNuoc,
            this.gcGhiChu});
            this.grvTinhDoHutNuoc.DetailHeight = 284;
            this.grvTinhDoHutNuoc.GridControl = this.grcTinhDoHutNuoc;
            this.grvTinhDoHutNuoc.Name = "grvTinhDoHutNuoc";
            this.grvTinhDoHutNuoc.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvTinhDoHutNuoc_FocusedRowChanged);
            // 
            // gcMaTinhDoHutNuoc
            // 
            this.gcMaTinhDoHutNuoc.Caption = "Mã Độ Hút Nước";
            this.gcMaTinhDoHutNuoc.FieldName = "MaTinhDoHutNuoc";
            this.gcMaTinhDoHutNuoc.MinWidth = 22;
            this.gcMaTinhDoHutNuoc.Name = "gcMaTinhDoHutNuoc";
            this.gcMaTinhDoHutNuoc.OptionsColumn.ReadOnly = true;
            this.gcMaTinhDoHutNuoc.Visible = true;
            this.gcMaTinhDoHutNuoc.VisibleIndex = 0;
            this.gcMaTinhDoHutNuoc.Width = 80;
            // 
            // gcNgayTinhDoHut
            // 
            this.gcNgayTinhDoHut.Caption = "Ngày tạo";
            this.gcNgayTinhDoHut.ColumnEdit = this.idatNgayTinhDoHut;
            this.gcNgayTinhDoHut.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gcNgayTinhDoHut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcNgayTinhDoHut.FieldName = "NgayTinhDoHut";
            this.gcNgayTinhDoHut.MinWidth = 22;
            this.gcNgayTinhDoHut.Name = "gcNgayTinhDoHut";
            this.gcNgayTinhDoHut.OptionsColumn.ReadOnly = true;
            this.gcNgayTinhDoHut.Visible = true;
            this.gcNgayTinhDoHut.VisibleIndex = 1;
            this.gcNgayTinhDoHut.Width = 80;
            // 
            // idatNgayTinhDoHut
            // 
            this.idatNgayTinhDoHut.AutoHeight = false;
            this.idatNgayTinhDoHut.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.idatNgayTinhDoHut.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.idatNgayTinhDoHut.DisplayFormat.FormatString = "g";
            this.idatNgayTinhDoHut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.idatNgayTinhDoHut.EditFormat.FormatString = "g";
            this.idatNgayTinhDoHut.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.idatNgayTinhDoHut.Mask.EditMask = "g";
            this.idatNgayTinhDoHut.Name = "idatNgayTinhDoHut";
            this.idatNgayTinhDoHut.ReadOnly = true;
            // 
            // gcName
            // 
            this.gcName.Caption = "Diễn Giải";
            this.gcName.FieldName = "Name";
            this.gcName.MinWidth = 22;
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.ReadOnly = true;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 2;
            this.gcName.Width = 80;
            // 
            // gcNhomSilo
            // 
            this.gcNhomSilo.Caption = "Nhóm Vật liệu";
            this.gcNhomSilo.ColumnEdit = this.ilueNhomSilo;
            this.gcNhomSilo.FieldName = "NhomSiloID";
            this.gcNhomSilo.MinWidth = 22;
            this.gcNhomSilo.Name = "gcNhomSilo";
            this.gcNhomSilo.OptionsColumn.ReadOnly = true;
            this.gcNhomSilo.Visible = true;
            this.gcNhomSilo.VisibleIndex = 3;
            this.gcNhomSilo.Width = 80;
            // 
            // ilueNhomSilo
            // 
            this.ilueNhomSilo.AutoHeight = false;
            this.ilueNhomSilo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ilueNhomSilo.DisplayMember = "TenNhomSilo";
            this.ilueNhomSilo.Name = "ilueNhomSilo";
            this.ilueNhomSilo.ReadOnly = true;
            this.ilueNhomSilo.ValueMember = "NhomSiloID";
            // 
            // gcDoHutNuoc
            // 
            this.gcDoHutNuoc.Caption = "Độ Hút Nước";
            this.gcDoHutNuoc.ColumnEdit = this.ispnDoHutNuoc;
            this.gcDoHutNuoc.FieldName = "DoHutNuoc";
            this.gcDoHutNuoc.MinWidth = 22;
            this.gcDoHutNuoc.Name = "gcDoHutNuoc";
            this.gcDoHutNuoc.OptionsColumn.ReadOnly = true;
            this.gcDoHutNuoc.Visible = true;
            this.gcDoHutNuoc.VisibleIndex = 4;
            this.gcDoHutNuoc.Width = 80;
            // 
            // ispnDoHutNuoc
            // 
            this.ispnDoHutNuoc.AutoHeight = false;
            this.ispnDoHutNuoc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnDoHutNuoc.DisplayFormat.FormatString = "n2";
            this.ispnDoHutNuoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ispnDoHutNuoc.EditFormat.FormatString = "n2";
            this.ispnDoHutNuoc.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ispnDoHutNuoc.Name = "ispnDoHutNuoc";
            this.ispnDoHutNuoc.ReadOnly = true;
            // 
            // gcGhiChu
            // 
            this.gcGhiChu.Caption = "Ghi Chú";
            this.gcGhiChu.FieldName = "Description";
            this.gcGhiChu.MinWidth = 22;
            this.gcGhiChu.Name = "gcGhiChu";
            this.gcGhiChu.OptionsColumn.ReadOnly = true;
            this.gcGhiChu.Visible = true;
            this.gcGhiChu.VisibleIndex = 5;
            this.gcGhiChu.Width = 80;
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.btnClose);
            this.grpStatus.Controls.Add(this.btnSelete);
            this.grpStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpStatus.Location = new System.Drawing.Point(0, 439);
            this.grpStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(848, 49);
            this.grpStatus.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(718, 13);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 24);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSelete
            // 
            this.btnSelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelete.Location = new System.Drawing.Point(613, 13);
            this.btnSelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSelete.Name = "btnSelete";
            this.btnSelete.Size = new System.Drawing.Size(98, 24);
            this.btnSelete.TabIndex = 3;
            this.btnSelete.Text = "Chọn";
            this.btnSelete.Click += new System.EventHandler(this.btnSelete_Click);
            // 
            // TinhDoHutNuocMngView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.grcMaster);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TinhDoHutNuocMngView";
            this.Size = new System.Drawing.Size(848, 488);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMaster)).EndInit();
            this.grcMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcTinhDoHutNuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTinhDoHutNuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatNgayTinhDoHut.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idatNgayTinhDoHut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilueNhomSilo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnDoHutNuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpStatus)).EndInit();
            this.grpStatus.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar barButtons;
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
        private DevExpress.XtraGrid.GridControl grcTinhDoHutNuoc;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTinhDoHutNuoc;
        private DevExpress.XtraGrid.Columns.GridColumn gcMaTinhDoHutNuoc;
        private DevExpress.XtraGrid.Columns.GridColumn gcNgayTinhDoHut;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit idatNgayTinhDoHut;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
        private DevExpress.XtraGrid.Columns.GridColumn gcNhomSilo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ilueNhomSilo;
        private DevExpress.XtraGrid.Columns.GridColumn gcDoHutNuoc;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnDoHutNuoc;
        private DevExpress.XtraGrid.Columns.GridColumn gcGhiChu;
        private DevExpress.XtraEditors.PanelControl grpStatus;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSelete;
    }
}


namespace NDPSo.MasterData
{
    partial class SiloDoAmMngView
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
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grcMaster = new DevExpress.XtraEditors.GroupControl();
            this.grcData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMaSilo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTenSilo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTinhDoHutNuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ibtnTinhDoHutNuoc = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gcDoHutNuoc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.spnDoHutNuoc = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcDoAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnDoAm = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcSoiTrongCat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnSoiTrongCat = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcSoiTrongCat_TruVaoSilo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ilueSoiTrongCat_TruVaoSilo = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMaster)).BeginInit();
            this.grcMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibtnTinhDoHutNuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnDoHutNuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnDoAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnSoiTrongCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilueSoiTrongCat_TruVaoSilo)).BeginInit();
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
            this.bbiSave,
            this.bbiRefresh});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefresh)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bsiCaption
            // 
            this.bsiCaption.Caption = "Độ hút nước";
            this.bsiCaption.Id = 0;
            this.bsiCaption.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsiCaption.ItemAppearance.Normal.Options.UseFont = true;
            this.bsiCaption.Name = "bsiCaption";
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Lưu";
            this.bbiSave.Id = 1;
            this.bbiSave.ImageOptions.Image = global::NDPSo.ResourceNDP.Save;
            this.bbiSave.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbiSave.ItemAppearance.Normal.Options.UseFont = true;
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Làm mới";
            this.bbiRefresh.Id = 2;
            this.bbiRefresh.ImageOptions.Image = global::NDPSo.ResourceNDP.refresh;
            this.bbiRefresh.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbiRefresh.ItemAppearance.Normal.Options.UseFont = true;
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
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
            this.grcMaster.Controls.Add(this.grcData);
            this.grcMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcMaster.Location = new System.Drawing.Point(0, 40);
            this.grcMaster.Margin = new System.Windows.Forms.Padding(2);
            this.grcMaster.Name = "grcMaster";
            this.grcMaster.Size = new System.Drawing.Size(848, 448);
            this.grcMaster.TabIndex = 4;
            this.grcMaster.Text = "Dữ liệu";
            // 
            // grcData
            // 
            this.grcData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcData.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grcData.Location = new System.Drawing.Point(2, 23);
            this.grcData.MainView = this.grvData;
            this.grcData.Margin = new System.Windows.Forms.Padding(2);
            this.grcData.MenuManager = this.barManager1;
            this.grcData.Name = "grcData";
            this.grcData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ibtnTinhDoHutNuoc,
            this.ilueSoiTrongCat_TruVaoSilo,
            this.ispnSoiTrongCat,
            this.spnDoHutNuoc,
            this.ispnDoAm});
            this.grcData.Size = new System.Drawing.Size(844, 423);
            this.grcData.TabIndex = 0;
            this.grcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMaSilo,
            this.gcTenSilo,
            this.gcTinhDoHutNuoc,
            this.gcDoHutNuoc,
            this.gcDoAm,
            this.gcSoiTrongCat,
            this.gcSoiTrongCat_TruVaoSilo});
            this.grvData.DetailHeight = 284;
            this.grvData.GridControl = this.grcData;
            this.grvData.Name = "grvData";
            // 
            // gcMaSilo
            // 
            this.gcMaSilo.Caption = "Mã Silo";
            this.gcMaSilo.FieldName = "MaSilo";
            this.gcMaSilo.MinWidth = 22;
            this.gcMaSilo.Name = "gcMaSilo";
            this.gcMaSilo.OptionsColumn.ReadOnly = true;
            this.gcMaSilo.Visible = true;
            this.gcMaSilo.VisibleIndex = 0;
            this.gcMaSilo.Width = 80;
            // 
            // gcTenSilo
            // 
            this.gcTenSilo.Caption = "Tên Silo";
            this.gcTenSilo.FieldName = "TenSilo";
            this.gcTenSilo.MinWidth = 22;
            this.gcTenSilo.Name = "gcTenSilo";
            this.gcTenSilo.OptionsColumn.ReadOnly = true;
            this.gcTenSilo.Visible = true;
            this.gcTenSilo.VisibleIndex = 1;
            this.gcTenSilo.Width = 80;
            // 
            // gcTinhDoHutNuoc
            // 
            this.gcTinhDoHutNuoc.Caption = "Công Thức Độ Hút Nước";
            this.gcTinhDoHutNuoc.ColumnEdit = this.ibtnTinhDoHutNuoc;
            this.gcTinhDoHutNuoc.FieldName = "TinhDoHutNuocName";
            this.gcTinhDoHutNuoc.MinWidth = 22;
            this.gcTinhDoHutNuoc.Name = "gcTinhDoHutNuoc";
            this.gcTinhDoHutNuoc.Visible = true;
            this.gcTinhDoHutNuoc.VisibleIndex = 2;
            this.gcTinhDoHutNuoc.Width = 80;
            // 
            // ibtnTinhDoHutNuoc
            // 
            this.ibtnTinhDoHutNuoc.AutoHeight = false;
            this.ibtnTinhDoHutNuoc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.ibtnTinhDoHutNuoc.Name = "ibtnTinhDoHutNuoc";
            this.ibtnTinhDoHutNuoc.NullText = "Không có";
            this.ibtnTinhDoHutNuoc.ReadOnly = true;
            this.ibtnTinhDoHutNuoc.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.ibtnTinhDoHutNuoc_ButtonPressed);
            // 
            // gcDoHutNuoc
            // 
            this.gcDoHutNuoc.Caption = "Độ Hút Nước";
            this.gcDoHutNuoc.ColumnEdit = this.spnDoHutNuoc;
            this.gcDoHutNuoc.DisplayFormat.FormatString = "n2";
            this.gcDoHutNuoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcDoHutNuoc.FieldName = "DoHutNuoc_NhomSiloAgg";
            this.gcDoHutNuoc.MinWidth = 22;
            this.gcDoHutNuoc.Name = "gcDoHutNuoc";
            this.gcDoHutNuoc.OptionsColumn.ReadOnly = true;
            this.gcDoHutNuoc.Visible = true;
            this.gcDoHutNuoc.VisibleIndex = 3;
            this.gcDoHutNuoc.Width = 80;
            // 
            // spnDoHutNuoc
            // 
            this.spnDoHutNuoc.AutoHeight = false;
            this.spnDoHutNuoc.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnDoHutNuoc.DisplayFormat.FormatString = "n2";
            this.spnDoHutNuoc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnDoHutNuoc.EditFormat.FormatString = "n2";
            this.spnDoHutNuoc.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spnDoHutNuoc.Name = "spnDoHutNuoc";
            // 
            // gcDoAm
            // 
            this.gcDoAm.Caption = "Độ Ấm";
            this.gcDoAm.ColumnEdit = this.ispnDoAm;
            this.gcDoAm.DisplayFormat.FormatString = "n2";
            this.gcDoAm.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcDoAm.FieldName = "DoAm_NhomSlioAgg";
            this.gcDoAm.MinWidth = 22;
            this.gcDoAm.Name = "gcDoAm";
            this.gcDoAm.OptionsColumn.ReadOnly = true;
            this.gcDoAm.Visible = true;
            this.gcDoAm.VisibleIndex = 4;
            this.gcDoAm.Width = 80;
            // 
            // ispnDoAm
            // 
            this.ispnDoAm.AutoHeight = false;
            this.ispnDoAm.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnDoAm.DisplayFormat.FormatString = "n2";
            this.ispnDoAm.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ispnDoAm.EditFormat.FormatString = "n2";
            this.ispnDoAm.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ispnDoAm.Name = "ispnDoAm";
            // 
            // gcSoiTrongCat
            // 
            this.gcSoiTrongCat.Caption = "Sỏi Trong Cát (%)";
            this.gcSoiTrongCat.ColumnEdit = this.ispnSoiTrongCat;
            this.gcSoiTrongCat.DisplayFormat.FormatString = "n2";
            this.gcSoiTrongCat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcSoiTrongCat.FieldName = "SoiTrongCat_NhomSiloAgg";
            this.gcSoiTrongCat.MinWidth = 22;
            this.gcSoiTrongCat.Name = "gcSoiTrongCat";
            this.gcSoiTrongCat.Visible = true;
            this.gcSoiTrongCat.VisibleIndex = 5;
            this.gcSoiTrongCat.Width = 80;
            // 
            // ispnSoiTrongCat
            // 
            this.ispnSoiTrongCat.AutoHeight = false;
            this.ispnSoiTrongCat.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnSoiTrongCat.DisplayFormat.FormatString = "n2";
            this.ispnSoiTrongCat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ispnSoiTrongCat.EditFormat.FormatString = "n2";
            this.ispnSoiTrongCat.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ispnSoiTrongCat.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ispnSoiTrongCat.Name = "ispnSoiTrongCat";
            // 
            // gcSoiTrongCat_TruVaoSilo
            // 
            this.gcSoiTrongCat_TruVaoSilo.Caption = "Trừ Vào Silo";
            this.gcSoiTrongCat_TruVaoSilo.ColumnEdit = this.ilueSoiTrongCat_TruVaoSilo;
            this.gcSoiTrongCat_TruVaoSilo.FieldName = "SoiTrongCat_TruVaoSilo_NhomSiloAgg";
            this.gcSoiTrongCat_TruVaoSilo.MinWidth = 22;
            this.gcSoiTrongCat_TruVaoSilo.Name = "gcSoiTrongCat_TruVaoSilo";
            this.gcSoiTrongCat_TruVaoSilo.Visible = true;
            this.gcSoiTrongCat_TruVaoSilo.VisibleIndex = 6;
            this.gcSoiTrongCat_TruVaoSilo.Width = 80;
            // 
            // ilueSoiTrongCat_TruVaoSilo
            // 
            this.ilueSoiTrongCat_TruVaoSilo.AutoHeight = false;
            this.ilueSoiTrongCat_TruVaoSilo.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ilueSoiTrongCat_TruVaoSilo.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaSilo", "Mã Silo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenSilo", "Tên Silo")});
            this.ilueSoiTrongCat_TruVaoSilo.DisplayMember = "TenSilo";
            this.ilueSoiTrongCat_TruVaoSilo.Name = "ilueSoiTrongCat_TruVaoSilo";
            this.ilueSoiTrongCat_TruVaoSilo.NullText = "";
            this.ilueSoiTrongCat_TruVaoSilo.ValueMember = "SiloID";
            // 
            // SiloDoAmMngView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcMaster);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "SiloDoAmMngView";
            this.Size = new System.Drawing.Size(848, 488);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMaster)).EndInit();
            this.grcMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ibtnTinhDoHutNuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnDoHutNuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnDoAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnSoiTrongCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilueSoiTrongCat_TruVaoSilo)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraEditors.GroupControl grcMaster;
        private DevExpress.XtraGrid.GridControl grcData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn gcMaSilo;
        private DevExpress.XtraGrid.Columns.GridColumn gcTenSilo;
        private DevExpress.XtraGrid.Columns.GridColumn gcTinhDoHutNuoc;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit ibtnTinhDoHutNuoc;
        private DevExpress.XtraGrid.Columns.GridColumn gcDoHutNuoc;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spnDoHutNuoc;
        private DevExpress.XtraGrid.Columns.GridColumn gcDoAm;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnDoAm;
        private DevExpress.XtraGrid.Columns.GridColumn gcSoiTrongCat;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnSoiTrongCat;
        private DevExpress.XtraGrid.Columns.GridColumn gcSoiTrongCat_TruVaoSilo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ilueSoiTrongCat_TruVaoSilo;
    }
}

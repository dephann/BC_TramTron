
namespace NDPSo.MasterData
{
    partial class PhieuTronMngView
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
            this.bbiUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiView = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSchedule = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grcSearch = new DevExpress.XtraEditors.GroupControl();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.lblActive = new DevExpress.XtraEditors.LabelControl();
            this.lblMaPhieuTron = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.luePTStatus = new DevExpress.XtraEditors.LookUpEdit();
            this.txtMaPhieuTron = new DevExpress.XtraEditors.TextEdit();
            this.datDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.datTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.grcMaster = new DevExpress.XtraEditors.GroupControl();
            this.grcPhieuTron = new DevExpress.XtraGrid.GridControl();
            this.grvPhieuTron = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMaPhieuTron = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNgayPhieuTron = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcViewMaHopDong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ilueMaHopDong = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.iluePTStatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcKLDuTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcKLThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcKLDuTinhTungMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcKLBuTruMeCuoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSLMeDuTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSLMeHieuChinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSLMeDaTron = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMoTa = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSearch)).BeginInit();
            this.grcSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luePTStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhieuTron.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMaster)).BeginInit();
            this.grcMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcPhieuTron)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPhieuTron)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilueMaHopDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iluePTStatus)).BeginInit();
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
            this.bbiUpdate,
            this.bbiDelete,
            this.bbiView,
            this.bbiSchedule});
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
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiUpdate),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiView),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSchedule)});
            this.barButtons.OptionsBar.MultiLine = true;
            this.barButtons.OptionsBar.UseWholeRow = true;
            this.barButtons.Text = "Main menu";
            // 
            // bsiCaption
            // 
            this.bsiCaption.Caption = "Phiếu trộn";
            this.bsiCaption.Id = 0;
            this.bsiCaption.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsiCaption.ItemAppearance.Normal.Options.UseFont = true;
            this.bsiCaption.Name = "bsiCaption";
            // 
            // bbiUpdate
            // 
            this.bbiUpdate.Caption = "Sửa";
            this.bbiUpdate.Id = 1;
            this.bbiUpdate.ImageOptions.Image = global::NDPSo.ResourceNDP.edit_fi;
            this.bbiUpdate.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbiUpdate.ItemAppearance.Normal.Options.UseFont = true;
            this.bbiUpdate.Name = "bbiUpdate";
            this.bbiUpdate.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Xoá";
            this.bbiDelete.Id = 2;
            this.bbiDelete.ImageOptions.Image = global::NDPSo.ResourceNDP.delete;
            this.bbiDelete.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbiDelete.ItemAppearance.Normal.Options.UseFont = true;
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiDelete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiView
            // 
            this.bbiView.Caption = "Xem";
            this.bbiView.Id = 3;
            this.bbiView.ImageOptions.Image = global::NDPSo.ResourceNDP.wath_;
            this.bbiView.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbiView.ItemAppearance.Normal.Options.UseFont = true;
            this.bbiView.Name = "bbiView";
            this.bbiView.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiView_ItemClick);
            //
            // bbiSchedule
            //
            this.bbiSchedule.Caption = "Lịch Trình";
            this.bbiSchedule.Id = 4;
            this.bbiSchedule.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbiSchedule.ItemAppearance.Normal.Options.UseFont = true;
            this.bbiSchedule.Name = "bbiSchedule";
            this.bbiSchedule.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiSchedule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSchedule_ItemClick);
            //
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlTop.Size = new System.Drawing.Size(772, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 488);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(772, 0);
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
            this.barDockControlRight.Location = new System.Drawing.Point(772, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 448);
            // 
            // grcSearch
            // 
            this.grcSearch.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcSearch.AppearanceCaption.Options.UseFont = true;
            this.grcSearch.Controls.Add(this.btnReset);
            this.grcSearch.Controls.Add(this.lblActive);
            this.grcSearch.Controls.Add(this.lblMaPhieuTron);
            this.grcSearch.Controls.Add(this.lblToDate);
            this.grcSearch.Controls.Add(this.btnSearch);
            this.grcSearch.Controls.Add(this.luePTStatus);
            this.grcSearch.Controls.Add(this.txtMaPhieuTron);
            this.grcSearch.Controls.Add(this.datDenNgay);
            this.grcSearch.Controls.Add(this.datTuNgay);
            this.grcSearch.Controls.Add(this.lblFromDate);
            this.grcSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.grcSearch.Location = new System.Drawing.Point(492, 40);
            this.grcSearch.Margin = new System.Windows.Forms.Padding(2);
            this.grcSearch.Name = "grcSearch";
            this.grcSearch.Size = new System.Drawing.Size(280, 448);
            this.grcSearch.TabIndex = 4;
            this.grcSearch.Text = "Tìm kiếm";
            // 
            // btnReset
            // 
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Appearance.Options.UseFont = true;
            this.btnReset.Location = new System.Drawing.Point(21, 185);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(105, 35);
            this.btnReset.TabIndex = 111;
            this.btnReset.Text = "Làm mới";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblActive
            // 
            this.lblActive.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActive.Appearance.Options.UseFont = true;
            this.lblActive.Location = new System.Drawing.Point(21, 138);
            this.lblActive.Margin = new System.Windows.Forms.Padding(2);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(59, 16);
            this.lblActive.TabIndex = 110;
            this.lblActive.Text = "Trạng thái";
            // 
            // lblMaPhieuTron
            // 
            this.lblMaPhieuTron.AutoSize = true;
            this.lblMaPhieuTron.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPhieuTron.Location = new System.Drawing.Point(18, 108);
            this.lblMaPhieuTron.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaPhieuTron.Name = "lblMaPhieuTron";
            this.lblMaPhieuTron.Size = new System.Drawing.Size(83, 16);
            this.lblMaPhieuTron.TabIndex = 109;
            this.lblMaPhieuTron.Text = "Mã Hợp đồng";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(18, 78);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(62, 16);
            this.lblToDate.TabIndex = 108;
            this.lblToDate.Text = "Đến ngày";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Location = new System.Drawing.Point(157, 185);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 35);
            this.btnSearch.TabIndex = 107;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // luePTStatus
            // 
            this.luePTStatus.Location = new System.Drawing.Point(112, 135);
            this.luePTStatus.Margin = new System.Windows.Forms.Padding(2);
            this.luePTStatus.MenuManager = this.barManager1;
            this.luePTStatus.Name = "luePTStatus";
            this.luePTStatus.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.luePTStatus.Properties.Appearance.Options.UseFont = true;
            this.luePTStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePTStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayText", "Trạng Thái")});
            this.luePTStatus.Properties.DisplayMember = "DisplayText";
            this.luePTStatus.Properties.NullText = "";
            this.luePTStatus.Properties.ValueMember = "ID";
            this.luePTStatus.Size = new System.Drawing.Size(150, 22);
            this.luePTStatus.TabIndex = 106;
            // 
            // txtMaPhieuTron
            // 
            this.txtMaPhieuTron.Location = new System.Drawing.Point(112, 105);
            this.txtMaPhieuTron.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaPhieuTron.Name = "txtMaPhieuTron";
            this.txtMaPhieuTron.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPhieuTron.Properties.Appearance.Options.UseFont = true;
            this.txtMaPhieuTron.Size = new System.Drawing.Size(150, 22);
            this.txtMaPhieuTron.TabIndex = 105;
            // 
            // datDenNgay
            // 
            this.datDenNgay.EditValue = null;
            this.datDenNgay.Location = new System.Drawing.Point(112, 75);
            this.datDenNgay.Margin = new System.Windows.Forms.Padding(2);
            this.datDenNgay.Name = "datDenNgay";
            this.datDenNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datDenNgay.Properties.Appearance.Options.UseFont = true;
            this.datDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datDenNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datDenNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datDenNgay.Size = new System.Drawing.Size(150, 22);
            this.datDenNgay.TabIndex = 104;
            // 
            // datTuNgay
            // 
            this.datTuNgay.EditValue = null;
            this.datTuNgay.Location = new System.Drawing.Point(112, 45);
            this.datTuNgay.Margin = new System.Windows.Forms.Padding(2);
            this.datTuNgay.Name = "datTuNgay";
            this.datTuNgay.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datTuNgay.Properties.Appearance.Options.UseFont = true;
            this.datTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTuNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.datTuNgay.Size = new System.Drawing.Size(150, 22);
            this.datTuNgay.TabIndex = 103;
            // 
            // lblFromDate
            // 
            this.lblFromDate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Appearance.Options.UseFont = true;
            this.lblFromDate.Location = new System.Drawing.Point(21, 48);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(73, 16);
            this.lblFromDate.TabIndex = 102;
            this.lblFromDate.Text = "Tạo Từ ngày";
            // 
            // grcMaster
            // 
            this.grcMaster.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcMaster.AppearanceCaption.Options.UseFont = true;
            this.grcMaster.Controls.Add(this.grcPhieuTron);
            this.grcMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcMaster.Location = new System.Drawing.Point(0, 40);
            this.grcMaster.Margin = new System.Windows.Forms.Padding(2);
            this.grcMaster.Name = "grcMaster";
            this.grcMaster.Size = new System.Drawing.Size(492, 448);
            this.grcMaster.TabIndex = 5;
            this.grcMaster.Text = "Dữ liệu";
            // 
            // grcPhieuTron
            // 
            this.grcPhieuTron.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcPhieuTron.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grcPhieuTron.Location = new System.Drawing.Point(2, 23);
            this.grcPhieuTron.MainView = this.grvPhieuTron;
            this.grcPhieuTron.Margin = new System.Windows.Forms.Padding(2);
            this.grcPhieuTron.MenuManager = this.barManager1;
            this.grcPhieuTron.Name = "grcPhieuTron";
            this.grcPhieuTron.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.iluePTStatus,
            this.ilueMaHopDong});
            this.grcPhieuTron.Size = new System.Drawing.Size(488, 423);
            this.grcPhieuTron.TabIndex = 0;
            this.grcPhieuTron.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPhieuTron});
            // 
            // grvPhieuTron
            // 
            this.grvPhieuTron.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMaPhieuTron,
            this.gcNgayPhieuTron,
            this.gcViewMaHopDong,
            this.gcStatus,
            this.gcKLDuTinh,
            this.gcKLThuc,
            this.gcKLDuTinhTungMe,
            this.gcKLBuTruMeCuoi,
            this.gcSLMeDuTinh,
            this.gcSLMeHieuChinh,
            this.gcSLMeDaTron,
            this.gcMoTa});
            this.grvPhieuTron.DetailHeight = 284;
            this.grvPhieuTron.GridControl = this.grcPhieuTron;
            this.grvPhieuTron.Name = "grvPhieuTron";
            this.grvPhieuTron.OptionsView.ShowFooter = true;
            // 
            // gcMaPhieuTron
            // 
            this.gcMaPhieuTron.Caption = "Mã Phiếu";
            this.gcMaPhieuTron.FieldName = "MaPhieuTron";
            this.gcMaPhieuTron.MinWidth = 100;
            this.gcMaPhieuTron.Name = "gcMaPhieuTron";
            this.gcMaPhieuTron.OptionsColumn.AllowEdit = false;
            this.gcMaPhieuTron.Visible = true;
            this.gcMaPhieuTron.VisibleIndex = 0;
            this.gcMaPhieuTron.Width = 100;
            // 
            // gcNgayPhieuTron
            // 
            this.gcNgayPhieuTron.Caption = "Ngày Tạo";
            this.gcNgayPhieuTron.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gcNgayPhieuTron.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcNgayPhieuTron.FieldName = "NgayPhieuTron";
            this.gcNgayPhieuTron.MinWidth = 100;
            this.gcNgayPhieuTron.Name = "gcNgayPhieuTron";
            this.gcNgayPhieuTron.OptionsColumn.AllowEdit = false;
            this.gcNgayPhieuTron.Visible = true;
            this.gcNgayPhieuTron.VisibleIndex = 1;
            this.gcNgayPhieuTron.Width = 100;
            // 
            // gcViewMaHopDong
            // 
            this.gcViewMaHopDong.Caption = "Mã Hợp Đồng";
            this.gcViewMaHopDong.ColumnEdit = this.ilueMaHopDong;
            this.gcViewMaHopDong.FieldName = "HopDongID";
            this.gcViewMaHopDong.MinWidth = 100;
            this.gcViewMaHopDong.Name = "gcViewMaHopDong";
            this.gcViewMaHopDong.OptionsColumn.AllowEdit = false;
            this.gcViewMaHopDong.Visible = true;
            this.gcViewMaHopDong.VisibleIndex = 2;
            this.gcViewMaHopDong.Width = 100;
            // 
            // ilueMaHopDong
            // 
            this.ilueMaHopDong.AutoHeight = false;
            this.ilueMaHopDong.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ilueMaHopDong.DisplayMember = "MaHopDong";
            this.ilueMaHopDong.Name = "ilueMaHopDong";
            this.ilueMaHopDong.ValueMember = "HopDongID";
            // 
            // gcStatus
            // 
            this.gcStatus.Caption = "Trạng Thái";
            this.gcStatus.ColumnEdit = this.iluePTStatus;
            this.gcStatus.FieldName = "Status";
            this.gcStatus.MinWidth = 100;
            this.gcStatus.Name = "gcStatus";
            this.gcStatus.OptionsColumn.AllowEdit = false;
            this.gcStatus.Visible = true;
            this.gcStatus.VisibleIndex = 3;
            this.gcStatus.Width = 100;
            // 
            // iluePTStatus
            // 
            this.iluePTStatus.AutoHeight = false;
            this.iluePTStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.iluePTStatus.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayText", "Trạng Thái")});
            this.iluePTStatus.DisplayMember = "DisplayText";
            this.iluePTStatus.Name = "iluePTStatus";
            this.iluePTStatus.NullText = "";
            this.iluePTStatus.ShowFooter = false;
            this.iluePTStatus.ShowHeader = false;
            this.iluePTStatus.ValueMember = "ID";
            // 
            // gcKLDuTinh
            // 
            this.gcKLDuTinh.Caption = "KL Dự Tính";
            this.gcKLDuTinh.DisplayFormat.FormatString = "n2";
            this.gcKLDuTinh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcKLDuTinh.FieldName = "KLDuTinh";
            this.gcKLDuTinh.MinWidth = 100;
            this.gcKLDuTinh.Name = "gcKLDuTinh";
            this.gcKLDuTinh.OptionsColumn.AllowEdit = false;
            this.gcKLDuTinh.Visible = true;
            this.gcKLDuTinh.VisibleIndex = 4;
            this.gcKLDuTinh.Width = 100;
            // 
            // gcKLThuc
            // 
            this.gcKLThuc.Caption = "Luỹ Kế";
            this.gcKLThuc.DisplayFormat.FormatString = "n2";
            this.gcKLThuc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcKLThuc.FieldName = "KLThuc";
            this.gcKLThuc.MinWidth = 100;
            this.gcKLThuc.Name = "gcKLThuc";
            this.gcKLThuc.OptionsColumn.AllowEdit = false;
            this.gcKLThuc.Visible = true;
            this.gcKLThuc.VisibleIndex = 5;
            this.gcKLThuc.Width = 100;
            // 
            // gcKLDuTinhTungMe
            // 
            this.gcKLDuTinhTungMe.Caption = "KL Dự Tính Từng Mẻ";
            this.gcKLDuTinhTungMe.DisplayFormat.FormatString = "n2";
            this.gcKLDuTinhTungMe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcKLDuTinhTungMe.FieldName = "KLDuTinhCuaTungMe";
            this.gcKLDuTinhTungMe.MinWidth = 100;
            this.gcKLDuTinhTungMe.Name = "gcKLDuTinhTungMe";
            this.gcKLDuTinhTungMe.OptionsColumn.AllowEdit = false;
            this.gcKLDuTinhTungMe.Visible = true;
            this.gcKLDuTinhTungMe.VisibleIndex = 6;
            this.gcKLDuTinhTungMe.Width = 100;
            // 
            // gcKLBuTruMeCuoi
            // 
            this.gcKLBuTruMeCuoi.Caption = "KL Bù Trừ Mẻ Cuối";
            this.gcKLBuTruMeCuoi.DisplayFormat.FormatString = "n2";
            this.gcKLBuTruMeCuoi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcKLBuTruMeCuoi.FieldName = "KLBuTruMeCuoi";
            this.gcKLBuTruMeCuoi.MinWidth = 100;
            this.gcKLBuTruMeCuoi.Name = "gcKLBuTruMeCuoi";
            this.gcKLBuTruMeCuoi.OptionsColumn.AllowEdit = false;
            this.gcKLBuTruMeCuoi.Visible = true;
            this.gcKLBuTruMeCuoi.VisibleIndex = 7;
            this.gcKLBuTruMeCuoi.Width = 100;
            // 
            // gcSLMeDuTinh
            // 
            this.gcSLMeDuTinh.Caption = "SL Mẻ Dự Tính";
            this.gcSLMeDuTinh.DisplayFormat.FormatString = "n2";
            this.gcSLMeDuTinh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcSLMeDuTinh.FieldName = "SLMeDuTinh";
            this.gcSLMeDuTinh.MinWidth = 100;
            this.gcSLMeDuTinh.Name = "gcSLMeDuTinh";
            this.gcSLMeDuTinh.OptionsColumn.AllowEdit = false;
            this.gcSLMeDuTinh.Visible = true;
            this.gcSLMeDuTinh.VisibleIndex = 8;
            this.gcSLMeDuTinh.Width = 100;
            // 
            // gcSLMeHieuChinh
            // 
            this.gcSLMeHieuChinh.Caption = "SL Mẻ Thêm Bớt";
            this.gcSLMeHieuChinh.DisplayFormat.FormatString = "n2";
            this.gcSLMeHieuChinh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcSLMeHieuChinh.FieldName = "SLMeHieuChinh";
            this.gcSLMeHieuChinh.MinWidth = 100;
            this.gcSLMeHieuChinh.Name = "gcSLMeHieuChinh";
            this.gcSLMeHieuChinh.OptionsColumn.AllowEdit = false;
            this.gcSLMeHieuChinh.Width = 80;
            // 
            // gcSLMeDaTron
            // 
            this.gcSLMeDaTron.Caption = "SL Mẻ Đã Trộn";
            this.gcSLMeDaTron.DisplayFormat.FormatString = "n2";
            this.gcSLMeDaTron.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcSLMeDaTron.FieldName = "SLMeDaTron";
            this.gcSLMeDaTron.MinWidth = 100;
            this.gcSLMeDaTron.Name = "gcSLMeDaTron";
            this.gcSLMeDaTron.OptionsColumn.AllowEdit = false;
            this.gcSLMeDaTron.Width = 80;
            // 
            // gcMoTa
            // 
            this.gcMoTa.Caption = "Niêm chì";
            this.gcMoTa.FieldName = "MoTa";
            this.gcMoTa.MinWidth = 100;
            this.gcMoTa.Name = "gcMoTa";
            this.gcMoTa.OptionsColumn.AllowEdit = false;
            this.gcMoTa.Visible = true;
            this.gcMoTa.VisibleIndex = 9;
            this.gcMoTa.Width = 100;
            // 
            // PhieuTronMngView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grcMaster);
            this.Controls.Add(this.grcSearch);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "PhieuTronMngView";
            this.Size = new System.Drawing.Size(772, 488);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSearch)).EndInit();
            this.grcSearch.ResumeLayout(false);
            this.grcSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luePTStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhieuTron.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMaster)).EndInit();
            this.grcMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcPhieuTron)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPhieuTron)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ilueMaHopDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iluePTStatus)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem bbiUpdate;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiView;
        private DevExpress.XtraBars.BarButtonItem bbiSchedule;
        private DevExpress.XtraEditors.GroupControl grcMaster;
        private DevExpress.XtraEditors.GroupControl grcSearch;
        private DevExpress.XtraGrid.GridControl grcPhieuTron;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPhieuTron;
        private DevExpress.XtraGrid.Columns.GridColumn gcMaPhieuTron;
        private DevExpress.XtraGrid.Columns.GridColumn gcNgayPhieuTron;
        private DevExpress.XtraGrid.Columns.GridColumn gcViewMaHopDong;
        private DevExpress.XtraGrid.Columns.GridColumn gcStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit iluePTStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gcKLDuTinh;
        private DevExpress.XtraGrid.Columns.GridColumn gcKLThuc;
        private DevExpress.XtraGrid.Columns.GridColumn gcKLDuTinhTungMe;
        private DevExpress.XtraGrid.Columns.GridColumn gcKLBuTruMeCuoi;
        private DevExpress.XtraGrid.Columns.GridColumn gcSLMeDuTinh;
        private DevExpress.XtraGrid.Columns.GridColumn gcSLMeHieuChinh;
        private DevExpress.XtraGrid.Columns.GridColumn gcSLMeDaTron;
        private DevExpress.XtraGrid.Columns.GridColumn gcMoTa;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.LabelControl lblActive;
        private System.Windows.Forms.Label lblMaPhieuTron;
        private System.Windows.Forms.Label lblToDate;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LookUpEdit luePTStatus;
        private DevExpress.XtraEditors.TextEdit txtMaPhieuTron;
        private DevExpress.XtraEditors.DateEdit datDenNgay;
        private DevExpress.XtraEditors.DateEdit datTuNgay;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ilueMaHopDong;
    }
}

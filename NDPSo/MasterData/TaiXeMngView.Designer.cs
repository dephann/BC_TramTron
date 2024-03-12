
namespace NDPSo.MasterData
{
    partial class TaiXeMngView
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
            this.grcSearch = new DevExpress.XtraEditors.GroupControl();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.lblActive = new DevExpress.XtraEditors.LabelControl();
            this.lblTenTaiXe = new DevExpress.XtraEditors.LabelControl();
            this.lblMaTaiXe = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lueActive = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtTenTX = new DevExpress.XtraEditors.TextEdit();
            this.txtMaTX = new DevExpress.XtraEditors.TextEdit();
            this.datToDate = new DevExpress.XtraEditors.DateEdit();
            this.datFromDate = new DevExpress.XtraEditors.DateEdit();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.grcMaster = new DevExpress.XtraEditors.GroupControl();
            this.grcTaiXe = new DevExpress.XtraGrid.GridControl();
            this.grvTaiXe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMaTaiXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTenTaiXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcActivated = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSearch)).BeginInit();
            this.grcSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMaster)).BeginInit();
            this.grcMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcTaiXe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTaiXe)).BeginInit();
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
            this.bsiCaption.Caption = "Tài xế";
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
            // grcSearch
            // 
            this.grcSearch.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcSearch.AppearanceCaption.Options.UseFont = true;
            this.grcSearch.Controls.Add(this.btnReset);
            this.grcSearch.Controls.Add(this.lblPhone);
            this.grcSearch.Controls.Add(this.lblActive);
            this.grcSearch.Controls.Add(this.lblTenTaiXe);
            this.grcSearch.Controls.Add(this.lblMaTaiXe);
            this.grcSearch.Controls.Add(this.lblToDate);
            this.grcSearch.Controls.Add(this.btnSearch);
            this.grcSearch.Controls.Add(this.lueActive);
            this.grcSearch.Controls.Add(this.txtPhone);
            this.grcSearch.Controls.Add(this.txtTenTX);
            this.grcSearch.Controls.Add(this.txtMaTX);
            this.grcSearch.Controls.Add(this.datToDate);
            this.grcSearch.Controls.Add(this.datFromDate);
            this.grcSearch.Controls.Add(this.lblFromDate);
            this.grcSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.grcSearch.Location = new System.Drawing.Point(568, 40);
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
            this.btnReset.Location = new System.Drawing.Point(13, 215);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(105, 35);
            this.btnReset.TabIndex = 107;
            this.btnReset.Text = "Làm mới";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblPhone
            // 
            this.lblPhone.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Appearance.Options.UseFont = true;
            this.lblPhone.Location = new System.Drawing.Point(13, 168);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(2);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(75, 16);
            this.lblPhone.TabIndex = 106;
            this.lblPhone.Text = "Số điện thoại";
            // 
            // lblActive
            // 
            this.lblActive.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActive.Appearance.Options.UseFont = true;
            this.lblActive.Location = new System.Drawing.Point(24, 278);
            this.lblActive.Margin = new System.Windows.Forms.Padding(2);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(59, 16);
            this.lblActive.TabIndex = 105;
            this.lblActive.Text = "Trạng thái";
            this.lblActive.Visible = false;
            // 
            // lblTenTaiXe
            // 
            this.lblTenTaiXe.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenTaiXe.Appearance.Options.UseFont = true;
            this.lblTenTaiXe.Location = new System.Drawing.Point(13, 138);
            this.lblTenTaiXe.Margin = new System.Windows.Forms.Padding(2);
            this.lblTenTaiXe.Name = "lblTenTaiXe";
            this.lblTenTaiXe.Size = new System.Drawing.Size(57, 16);
            this.lblTenTaiXe.TabIndex = 103;
            this.lblTenTaiXe.Text = "Tên tài xế";
            // 
            // lblMaTaiXe
            // 
            this.lblMaTaiXe.AutoSize = true;
            this.lblMaTaiXe.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaTaiXe.Location = new System.Drawing.Point(10, 108);
            this.lblMaTaiXe.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaTaiXe.Name = "lblMaTaiXe";
            this.lblMaTaiXe.Size = new System.Drawing.Size(60, 16);
            this.lblMaTaiXe.TabIndex = 102;
            this.lblMaTaiXe.Text = "Mã tài xế";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(10, 78);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(62, 16);
            this.lblToDate.TabIndex = 101;
            this.lblToDate.Text = "Đến ngày";
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Location = new System.Drawing.Point(157, 215);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 35);
            this.btnSearch.TabIndex = 100;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lueActive
            // 
            this.lueActive.Location = new System.Drawing.Point(112, 275);
            this.lueActive.Margin = new System.Windows.Forms.Padding(2);
            this.lueActive.MenuManager = this.barManager1;
            this.lueActive.Name = "lueActive";
            this.lueActive.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueActive.Properties.Appearance.Options.UseFont = true;
            this.lueActive.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueActive.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayText", "Trạng thái", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.lueActive.Properties.DisplayMember = "DisplayText";
            this.lueActive.Properties.NullText = "";
            this.lueActive.Properties.ValueMember = "ID";
            this.lueActive.Size = new System.Drawing.Size(150, 22);
            this.lueActive.TabIndex = 99;
            this.lueActive.Visible = false;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(112, 165);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Properties.Appearance.Options.UseFont = true;
            this.txtPhone.Properties.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(150, 22);
            this.txtPhone.TabIndex = 98;
            // 
            // txtTenTX
            // 
            this.txtTenTX.Location = new System.Drawing.Point(112, 135);
            this.txtTenTX.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenTX.Name = "txtTenTX";
            this.txtTenTX.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenTX.Properties.Appearance.Options.UseFont = true;
            this.txtTenTX.Size = new System.Drawing.Size(150, 22);
            this.txtTenTX.TabIndex = 96;
            // 
            // txtMaTX
            // 
            this.txtMaTX.Location = new System.Drawing.Point(112, 105);
            this.txtMaTX.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaTX.Name = "txtMaTX";
            this.txtMaTX.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaTX.Properties.Appearance.Options.UseFont = true;
            this.txtMaTX.Size = new System.Drawing.Size(150, 22);
            this.txtMaTX.TabIndex = 95;
            // 
            // datToDate
            // 
            this.datToDate.EditValue = null;
            this.datToDate.Location = new System.Drawing.Point(112, 75);
            this.datToDate.Margin = new System.Windows.Forms.Padding(2);
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
            this.datToDate.TabIndex = 94;
            // 
            // datFromDate
            // 
            this.datFromDate.EditValue = null;
            this.datFromDate.Location = new System.Drawing.Point(112, 45);
            this.datFromDate.Margin = new System.Windows.Forms.Padding(2);
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
            this.datFromDate.TabIndex = 93;
            // 
            // lblFromDate
            // 
            this.lblFromDate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Appearance.Options.UseFont = true;
            this.lblFromDate.Location = new System.Drawing.Point(13, 48);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(73, 16);
            this.lblFromDate.TabIndex = 92;
            this.lblFromDate.Text = "Tạo Từ ngày";
            // 
            // grcMaster
            // 
            this.grcMaster.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcMaster.AppearanceCaption.Options.UseFont = true;
            this.grcMaster.Controls.Add(this.grcTaiXe);
            this.grcMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcMaster.Location = new System.Drawing.Point(0, 40);
            this.grcMaster.Margin = new System.Windows.Forms.Padding(2);
            this.grcMaster.Name = "grcMaster";
            this.grcMaster.Size = new System.Drawing.Size(568, 448);
            this.grcMaster.TabIndex = 5;
            this.grcMaster.Text = "Dữ liệu";
            // 
            // grcTaiXe
            // 
            this.grcTaiXe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcTaiXe.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grcTaiXe.Location = new System.Drawing.Point(2, 23);
            this.grcTaiXe.MainView = this.grvTaiXe;
            this.grcTaiXe.Margin = new System.Windows.Forms.Padding(2);
            this.grcTaiXe.MenuManager = this.barManager1;
            this.grcTaiXe.Name = "grcTaiXe";
            this.grcTaiXe.Size = new System.Drawing.Size(564, 423);
            this.grcTaiXe.TabIndex = 0;
            this.grcTaiXe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTaiXe});
            // 
            // grvTaiXe
            // 
            this.grvTaiXe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMaTaiXe,
            this.gcTenTaiXe,
            this.gcPhone,
            this.gcGhiChu,
            this.gcActivated});
            this.grvTaiXe.DetailHeight = 284;
            this.grvTaiXe.GridControl = this.grcTaiXe;
            this.grvTaiXe.Name = "grvTaiXe";
            this.grvTaiXe.OptionsView.ShowFooter = true;
            // 
            // gcMaTaiXe
            // 
            this.gcMaTaiXe.Caption = "Mã Tài xế";
            this.gcMaTaiXe.FieldName = "MaTaiXe";
            this.gcMaTaiXe.MinWidth = 22;
            this.gcMaTaiXe.Name = "gcMaTaiXe";
            this.gcMaTaiXe.Visible = true;
            this.gcMaTaiXe.VisibleIndex = 0;
            this.gcMaTaiXe.Width = 80;
            // 
            // gcTenTaiXe
            // 
            this.gcTenTaiXe.Caption = "Tên Tài xế";
            this.gcTenTaiXe.FieldName = "TenTaiXe";
            this.gcTenTaiXe.MinWidth = 22;
            this.gcTenTaiXe.Name = "gcTenTaiXe";
            this.gcTenTaiXe.Visible = true;
            this.gcTenTaiXe.VisibleIndex = 1;
            this.gcTenTaiXe.Width = 80;
            // 
            // gcPhone
            // 
            this.gcPhone.Caption = "Phone";
            this.gcPhone.FieldName = "Phone";
            this.gcPhone.MinWidth = 22;
            this.gcPhone.Name = "gcPhone";
            this.gcPhone.Visible = true;
            this.gcPhone.VisibleIndex = 2;
            this.gcPhone.Width = 80;
            // 
            // gcGhiChu
            // 
            this.gcGhiChu.Caption = "Ghi Chú";
            this.gcGhiChu.FieldName = "GhiChu";
            this.gcGhiChu.MinWidth = 22;
            this.gcGhiChu.Name = "gcGhiChu";
            this.gcGhiChu.Visible = true;
            this.gcGhiChu.VisibleIndex = 3;
            this.gcGhiChu.Width = 80;
            // 
            // gcActivated
            // 
            this.gcActivated.Caption = "Active";
            this.gcActivated.FieldName = "Activated";
            this.gcActivated.MinWidth = 22;
            this.gcActivated.Name = "gcActivated";
            this.gcActivated.Width = 80;
            // 
            // TaiXeMngView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Timer";
            this.Controls.Add(this.grcMaster);
            this.Controls.Add(this.grcSearch);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TaiXeMngView";
            this.Size = new System.Drawing.Size(848, 488);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSearch)).EndInit();
            this.grcSearch.ResumeLayout(false);
            this.grcSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMaster)).EndInit();
            this.grcMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcTaiXe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTaiXe)).EndInit();
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
        private DevExpress.XtraEditors.GroupControl grcSearch;
        private DevExpress.XtraEditors.GroupControl grcMaster;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.LabelControl lblPhone;
        private DevExpress.XtraEditors.LabelControl lblActive;
        private DevExpress.XtraEditors.LabelControl lblTenTaiXe;
        private System.Windows.Forms.Label lblMaTaiXe;
        private System.Windows.Forms.Label lblToDate;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LookUpEdit lueActive;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.TextEdit txtTenTX;
        private DevExpress.XtraEditors.TextEdit txtMaTX;
        private DevExpress.XtraEditors.DateEdit datToDate;
        private DevExpress.XtraEditors.DateEdit datFromDate;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
        private DevExpress.XtraGrid.GridControl grcTaiXe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn gcMaTaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn gcTenTaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn gcPhone;
        private DevExpress.XtraGrid.Columns.GridColumn gcGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn gcActivated;
    }
}

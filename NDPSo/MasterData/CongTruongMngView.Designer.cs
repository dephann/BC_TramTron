
namespace NDPSo.MasterData
{
    partial class CongTruongMngView
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
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.grcSearch = new DevExpress.XtraEditors.GroupControl();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.lblPhone = new DevExpress.XtraEditors.LabelControl();
            this.lblActive = new DevExpress.XtraEditors.LabelControl();
            this.lblAddress = new DevExpress.XtraEditors.LabelControl();
            this.lblTenCongTruong = new DevExpress.XtraEditors.LabelControl();
            this.lblMaCongTruong = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lueActive = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.txtTenCT = new DevExpress.XtraEditors.TextEdit();
            this.txtMaCT = new DevExpress.XtraEditors.TextEdit();
            this.datToDate = new DevExpress.XtraEditors.DateEdit();
            this.datFromDate = new DevExpress.XtraEditors.DateEdit();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.grpMaster = new DevExpress.XtraEditors.GroupControl();
            this.grcCongTruong = new DevExpress.XtraGrid.GridControl();
            this.grvCongTruong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMaCongTruong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTenCongTruong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcActivated = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSearch)).BeginInit();
            this.grcSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenCT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaCT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMaster)).BeginInit();
            this.grpMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcCongTruong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCongTruong)).BeginInit();
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
            this.bsiCaption.Caption = "Công Trường";
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
            this.barDockControlTop.Size = new System.Drawing.Size(981, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 594);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlBottom.Size = new System.Drawing.Size(981, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 554);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(981, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 554);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Khách Hàng";
            this.barStaticItem1.Id = 5;
            this.barStaticItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // grcSearch
            // 
            this.grcSearch.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcSearch.AppearanceCaption.Options.UseFont = true;
            this.grcSearch.Controls.Add(this.btnReset);
            this.grcSearch.Controls.Add(this.lblPhone);
            this.grcSearch.Controls.Add(this.lblActive);
            this.grcSearch.Controls.Add(this.lblAddress);
            this.grcSearch.Controls.Add(this.lblTenCongTruong);
            this.grcSearch.Controls.Add(this.lblMaCongTruong);
            this.grcSearch.Controls.Add(this.lblToDate);
            this.grcSearch.Controls.Add(this.btnSearch);
            this.grcSearch.Controls.Add(this.lueActive);
            this.grcSearch.Controls.Add(this.txtPhone);
            this.grcSearch.Controls.Add(this.txtDiaChi);
            this.grcSearch.Controls.Add(this.txtTenCT);
            this.grcSearch.Controls.Add(this.txtMaCT);
            this.grcSearch.Controls.Add(this.datToDate);
            this.grcSearch.Controls.Add(this.datFromDate);
            this.grcSearch.Controls.Add(this.lblFromDate);
            this.grcSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.grcSearch.Location = new System.Drawing.Point(701, 40);
            this.grcSearch.Margin = new System.Windows.Forms.Padding(2);
            this.grcSearch.Name = "grcSearch";
            this.grcSearch.Size = new System.Drawing.Size(280, 554);
            this.grcSearch.TabIndex = 4;
            this.grcSearch.Text = "Tìm kiếm";
            // 
            // btnReset
            // 
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Appearance.Options.UseFont = true;
            this.btnReset.Location = new System.Drawing.Point(15, 215);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(105, 35);
            this.btnReset.TabIndex = 91;
            this.btnReset.Text = "Làm mới";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblPhone
            // 
            this.lblPhone.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Appearance.Options.UseFont = true;
            this.lblPhone.Location = new System.Drawing.Point(15, 168);
            this.lblPhone.Margin = new System.Windows.Forms.Padding(2);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(75, 16);
            this.lblPhone.TabIndex = 90;
            this.lblPhone.Text = "Số điện thoại";
            // 
            // lblActive
            // 
            this.lblActive.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActive.Appearance.Options.UseFont = true;
            this.lblActive.Location = new System.Drawing.Point(13, 333);
            this.lblActive.Margin = new System.Windows.Forms.Padding(2);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(59, 16);
            this.lblActive.TabIndex = 89;
            this.lblActive.Text = "Trạng thái";
            this.lblActive.Visible = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Appearance.Options.UseFont = true;
            this.lblAddress.Location = new System.Drawing.Point(15, 296);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(2);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(39, 16);
            this.lblAddress.TabIndex = 88;
            this.lblAddress.Text = "Địa chỉ";
            this.lblAddress.Visible = false;
            // 
            // lblTenCongTruong
            // 
            this.lblTenCongTruong.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenCongTruong.Appearance.Options.UseFont = true;
            this.lblTenCongTruong.Location = new System.Drawing.Point(15, 108);
            this.lblTenCongTruong.Margin = new System.Windows.Forms.Padding(2);
            this.lblTenCongTruong.Name = "lblTenCongTruong";
            this.lblTenCongTruong.Size = new System.Drawing.Size(95, 16);
            this.lblTenCongTruong.TabIndex = 87;
            this.lblTenCongTruong.Text = "Tên công trường";
            // 
            // lblMaCongTruong
            // 
            this.lblMaCongTruong.AutoSize = true;
            this.lblMaCongTruong.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaCongTruong.Location = new System.Drawing.Point(12, 138);
            this.lblMaCongTruong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaCongTruong.Name = "lblMaCongTruong";
            this.lblMaCongTruong.Size = new System.Drawing.Size(98, 16);
            this.lblMaCongTruong.TabIndex = 86;
            this.lblMaCongTruong.Text = "Mã công trường";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(12, 78);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(62, 16);
            this.lblToDate.TabIndex = 85;
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
            this.btnSearch.TabIndex = 84;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lueActive
            // 
            this.lueActive.Location = new System.Drawing.Point(112, 330);
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
            this.lueActive.TabIndex = 83;
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
            this.txtPhone.TabIndex = 82;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(112, 293);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Properties.Appearance.Options.UseFont = true;
            this.txtDiaChi.Size = new System.Drawing.Size(150, 22);
            this.txtDiaChi.TabIndex = 81;
            this.txtDiaChi.Visible = false;
            // 
            // txtTenCT
            // 
            this.txtTenCT.Location = new System.Drawing.Point(112, 105);
            this.txtTenCT.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenCT.Name = "txtTenCT";
            this.txtTenCT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenCT.Properties.Appearance.Options.UseFont = true;
            this.txtTenCT.Size = new System.Drawing.Size(150, 22);
            this.txtTenCT.TabIndex = 80;
            // 
            // txtMaCT
            // 
            this.txtMaCT.Location = new System.Drawing.Point(112, 135);
            this.txtMaCT.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaCT.Name = "txtMaCT";
            this.txtMaCT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaCT.Properties.Appearance.Options.UseFont = true;
            this.txtMaCT.Size = new System.Drawing.Size(150, 22);
            this.txtMaCT.TabIndex = 79;
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
            this.datToDate.TabIndex = 78;
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
            this.datFromDate.TabIndex = 77;
            // 
            // lblFromDate
            // 
            this.lblFromDate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Appearance.Options.UseFont = true;
            this.lblFromDate.Location = new System.Drawing.Point(15, 48);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(73, 16);
            this.lblFromDate.TabIndex = 76;
            this.lblFromDate.Text = "Tạo Từ ngày";
            // 
            // grpMaster
            // 
            this.grpMaster.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMaster.AppearanceCaption.Options.UseFont = true;
            this.grpMaster.Controls.Add(this.grcCongTruong);
            this.grpMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMaster.Location = new System.Drawing.Point(0, 40);
            this.grpMaster.Margin = new System.Windows.Forms.Padding(2);
            this.grpMaster.Name = "grpMaster";
            this.grpMaster.Size = new System.Drawing.Size(701, 554);
            this.grpMaster.TabIndex = 9;
            this.grpMaster.Text = "Dữ liệu";
            // 
            // grcCongTruong
            // 
            this.grcCongTruong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcCongTruong.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.grcCongTruong.Location = new System.Drawing.Point(2, 23);
            this.grcCongTruong.MainView = this.grvCongTruong;
            this.grcCongTruong.Margin = new System.Windows.Forms.Padding(2);
            this.grcCongTruong.MenuManager = this.barManager1;
            this.grcCongTruong.Name = "grcCongTruong";
            this.grcCongTruong.Size = new System.Drawing.Size(697, 529);
            this.grcCongTruong.TabIndex = 0;
            this.grcCongTruong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCongTruong});
            // 
            // grvCongTruong
            // 
            this.grvCongTruong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMaCongTruong,
            this.gcTenCongTruong,
            this.gcDiaChi,
            this.gcPhone,
            this.gcGhiChu,
            this.gcActivated});
            this.grvCongTruong.DetailHeight = 284;
            this.grvCongTruong.GridControl = this.grcCongTruong;
            this.grvCongTruong.Name = "grvCongTruong";
            this.grvCongTruong.OptionsView.ShowFooter = true;
            // 
            // gcMaCongTruong
            // 
            this.gcMaCongTruong.Caption = "Mã Công trường";
            this.gcMaCongTruong.FieldName = "MaCongTruong";
            this.gcMaCongTruong.MinWidth = 19;
            this.gcMaCongTruong.Name = "gcMaCongTruong";
            this.gcMaCongTruong.OptionsColumn.AllowEdit = false;
            this.gcMaCongTruong.Visible = true;
            this.gcMaCongTruong.VisibleIndex = 0;
            this.gcMaCongTruong.Width = 70;
            // 
            // gcTenCongTruong
            // 
            this.gcTenCongTruong.Caption = "Tên Công Trường";
            this.gcTenCongTruong.FieldName = "TenCongTruong";
            this.gcTenCongTruong.MinWidth = 19;
            this.gcTenCongTruong.Name = "gcTenCongTruong";
            this.gcTenCongTruong.OptionsColumn.AllowEdit = false;
            this.gcTenCongTruong.Visible = true;
            this.gcTenCongTruong.VisibleIndex = 1;
            this.gcTenCongTruong.Width = 70;
            // 
            // gcDiaChi
            // 
            this.gcDiaChi.Caption = "Địa Chỉ";
            this.gcDiaChi.FieldName = "DiaChi";
            this.gcDiaChi.MinWidth = 19;
            this.gcDiaChi.Name = "gcDiaChi";
            this.gcDiaChi.OptionsColumn.AllowEdit = false;
            this.gcDiaChi.Visible = true;
            this.gcDiaChi.VisibleIndex = 2;
            this.gcDiaChi.Width = 70;
            // 
            // gcPhone
            // 
            this.gcPhone.Caption = "Phone";
            this.gcPhone.FieldName = "Phone";
            this.gcPhone.MinWidth = 19;
            this.gcPhone.Name = "gcPhone";
            this.gcPhone.OptionsColumn.AllowEdit = false;
            this.gcPhone.Visible = true;
            this.gcPhone.VisibleIndex = 3;
            this.gcPhone.Width = 70;
            // 
            // gcGhiChu
            // 
            this.gcGhiChu.Caption = "Ghi Chú";
            this.gcGhiChu.FieldName = "GhiChu";
            this.gcGhiChu.MinWidth = 19;
            this.gcGhiChu.Name = "gcGhiChu";
            this.gcGhiChu.OptionsColumn.AllowEdit = false;
            this.gcGhiChu.Visible = true;
            this.gcGhiChu.VisibleIndex = 4;
            this.gcGhiChu.Width = 70;
            // 
            // gcActivated
            // 
            this.gcActivated.Caption = "Active";
            this.gcActivated.FieldName = "Activated";
            this.gcActivated.MinWidth = 19;
            this.gcActivated.Name = "gcActivated";
            this.gcActivated.OptionsColumn.AllowEdit = false;
            this.gcActivated.Width = 70;
            // 
            // CongTruongMngView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMaster);
            this.Controls.Add(this.grcSearch);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "CongTruongMngView";
            this.Size = new System.Drawing.Size(981, 594);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcSearch)).EndInit();
            this.grcSearch.ResumeLayout(false);
            this.grcSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenCT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaCT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMaster)).EndInit();
            this.grpMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcCongTruong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCongTruong)).EndInit();
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
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem bbiInsert;
        private DevExpress.XtraBars.BarButtonItem bbiUpdate;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiView;
        private DevExpress.XtraEditors.GroupControl grcSearch;
        private DevExpress.XtraEditors.GroupControl grpMaster;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.LabelControl lblPhone;
        private DevExpress.XtraEditors.LabelControl lblActive;
        private DevExpress.XtraEditors.LabelControl lblAddress;
        private DevExpress.XtraEditors.LabelControl lblTenCongTruong;
        private System.Windows.Forms.Label lblMaCongTruong;
        private System.Windows.Forms.Label lblToDate;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LookUpEdit lueActive;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.TextEdit txtTenCT;
        private DevExpress.XtraEditors.TextEdit txtMaCT;
        private DevExpress.XtraEditors.DateEdit datToDate;
        private DevExpress.XtraEditors.DateEdit datFromDate;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
        private DevExpress.XtraGrid.GridControl grcCongTruong;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCongTruong;
        private DevExpress.XtraGrid.Columns.GridColumn gcMaCongTruong;
        private DevExpress.XtraGrid.Columns.GridColumn gcTenCongTruong;
        private DevExpress.XtraGrid.Columns.GridColumn gcDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn gcPhone;
        private DevExpress.XtraGrid.Columns.GridColumn gcGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn gcActivated;
    }
}

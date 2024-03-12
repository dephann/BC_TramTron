
namespace NDPSo.MasterData
{
    partial class WeighMngView
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
            this.grpMaster = new DevExpress.XtraEditors.GroupControl();
            this.grcData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcWeighCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itxtWeigh = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcWeighName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itxtWeighName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itxtDesc = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcZero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnZero = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcMax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnMax = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcOffset = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnOffset = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcKLEmpty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnKLEmpty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcTimeEmpty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnTimeEmpty = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcLimit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnLimit = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcWeiToVib = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnWeiToVib = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcTON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnTON = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcTOFF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnTOFF = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcSpare = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnSpare = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnSTT = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcMarkAsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTilexa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMaster)).BeginInit();
            this.grpMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itxtWeigh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itxtWeighName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itxtDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnKLEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnTimeEmpty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnWeiToVib)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnTON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnTOFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnSpare)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnSTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
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
            this.bsiCaption.Caption = "Thông số Cân";
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
            this.bbiRefresh.Caption = "Làm mơi";
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
            // grpMaster
            // 
            this.grpMaster.Controls.Add(this.grcData);
            this.grpMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMaster.Location = new System.Drawing.Point(0, 40);
            this.grpMaster.Margin = new System.Windows.Forms.Padding(2);
            this.grpMaster.Name = "grpMaster";
            this.grpMaster.Size = new System.Drawing.Size(772, 448);
            this.grpMaster.TabIndex = 4;
            this.grpMaster.Text = "Dữ liệu";
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
            this.itxtWeigh,
            this.itxtWeighName,
            this.itxtDesc,
            this.ispnZero,
            this.ispnMax,
            this.ispnOffset,
            this.ispnKLEmpty,
            this.ispnTimeEmpty,
            this.ispnLimit,
            this.ispnWeiToVib,
            this.ispnTON,
            this.ispnTOFF,
            this.ispnSpare,
            this.ispnSTT,
            this.repositoryItemSpinEdit1});
            this.grcData.Size = new System.Drawing.Size(768, 423);
            this.grcData.TabIndex = 0;
            this.grcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            this.grcData.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grcData_ProcessGridKey);
            // 
            // grvData
            // 
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcWeighCode,
            this.gcWeighName,
            this.gcDesc,
            this.gcZero,
            this.gcMax,
            this.gcOffset,
            this.gcKLEmpty,
            this.gcTimeEmpty,
            this.gcLimit,
            this.gcWeiToVib,
            this.gcTON,
            this.gcTOFF,
            this.gcSpare,
            this.gcSTT,
            this.gcMarkAsDeleted,
            this.gcTilexa});
            this.grvData.DetailHeight = 284;
            this.grvData.GridControl = this.grcData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvData.OptionsView.ShowFooter = true;
            // 
            // gcWeighCode
            // 
            this.gcWeighCode.Caption = "Mã";
            this.gcWeighCode.ColumnEdit = this.itxtWeigh;
            this.gcWeighCode.FieldName = "WeighCode";
            this.gcWeighCode.MinWidth = 22;
            this.gcWeighCode.Name = "gcWeighCode";
            this.gcWeighCode.OptionsColumn.AllowEdit = false;
            this.gcWeighCode.OptionsColumn.AllowMove = false;
            this.gcWeighCode.Visible = true;
            this.gcWeighCode.VisibleIndex = 0;
            this.gcWeighCode.Width = 80;
            // 
            // itxtWeigh
            // 
            this.itxtWeigh.AutoHeight = false;
            this.itxtWeigh.Name = "itxtWeigh";
            // 
            // gcWeighName
            // 
            this.gcWeighName.Caption = "Tên";
            this.gcWeighName.ColumnEdit = this.itxtWeighName;
            this.gcWeighName.FieldName = "WeighName";
            this.gcWeighName.MinWidth = 22;
            this.gcWeighName.Name = "gcWeighName";
            this.gcWeighName.Visible = true;
            this.gcWeighName.VisibleIndex = 1;
            this.gcWeighName.Width = 80;
            // 
            // itxtWeighName
            // 
            this.itxtWeighName.AutoHeight = false;
            this.itxtWeighName.Name = "itxtWeighName";
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Mô tả";
            this.gcDesc.ColumnEdit = this.itxtDesc;
            this.gcDesc.FieldName = "Description";
            this.gcDesc.MinWidth = 22;
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.Width = 80;
            // 
            // itxtDesc
            // 
            this.itxtDesc.AutoHeight = false;
            this.itxtDesc.Name = "itxtDesc";
            // 
            // gcZero
            // 
            this.gcZero.Caption = "TG Trễ Cân";
            this.gcZero.ColumnEdit = this.ispnZero;
            this.gcZero.FieldName = "Zero";
            this.gcZero.MinWidth = 22;
            this.gcZero.Name = "gcZero";
            this.gcZero.Width = 80;
            // 
            // ispnZero
            // 
            this.ispnZero.AutoHeight = false;
            this.ispnZero.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnZero.DisplayFormat.FormatString = "n2";
            this.ispnZero.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ispnZero.EditFormat.FormatString = "n2";
            this.ispnZero.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ispnZero.Mask.EditMask = "n2";
            this.ispnZero.Name = "ispnZero";
            // 
            // gcMax
            // 
            this.gcMax.Caption = "TG Trễ Xả";
            this.gcMax.ColumnEdit = this.ispnMax;
            this.gcMax.FieldName = "Max";
            this.gcMax.MinWidth = 22;
            this.gcMax.Name = "gcMax";
            this.gcMax.Visible = true;
            this.gcMax.VisibleIndex = 8;
            this.gcMax.Width = 80;
            // 
            // ispnMax
            // 
            this.ispnMax.AutoHeight = false;
            this.ispnMax.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnMax.Name = "ispnMax";
            // 
            // gcOffset
            // 
            this.gcOffset.Caption = "TG Trễ Đóng";
            this.gcOffset.ColumnEdit = this.ispnOffset;
            this.gcOffset.FieldName = "Offset";
            this.gcOffset.MinWidth = 22;
            this.gcOffset.Name = "gcOffset";
            this.gcOffset.Visible = true;
            this.gcOffset.VisibleIndex = 7;
            this.gcOffset.Width = 80;
            // 
            // ispnOffset
            // 
            this.ispnOffset.AutoHeight = false;
            this.ispnOffset.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnOffset.Name = "ispnOffset";
            // 
            // gcKLEmpty
            // 
            this.gcKLEmpty.Caption = "KL Báo Cân Rỗng";
            this.gcKLEmpty.ColumnEdit = this.ispnKLEmpty;
            this.gcKLEmpty.FieldName = "KLEmpty";
            this.gcKLEmpty.MinWidth = 22;
            this.gcKLEmpty.Name = "gcKLEmpty";
            this.gcKLEmpty.Visible = true;
            this.gcKLEmpty.VisibleIndex = 2;
            this.gcKLEmpty.Width = 80;
            // 
            // ispnKLEmpty
            // 
            this.ispnKLEmpty.AutoHeight = false;
            this.ispnKLEmpty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnKLEmpty.Name = "ispnKLEmpty";
            // 
            // gcTimeEmpty
            // 
            this.gcTimeEmpty.Caption = "Thời Gian Ổn Định Cân";
            this.gcTimeEmpty.ColumnEdit = this.ispnTimeEmpty;
            this.gcTimeEmpty.FieldName = "TimeEmpty";
            this.gcTimeEmpty.MinWidth = 22;
            this.gcTimeEmpty.Name = "gcTimeEmpty";
            this.gcTimeEmpty.Visible = true;
            this.gcTimeEmpty.VisibleIndex = 3;
            this.gcTimeEmpty.Width = 80;
            // 
            // ispnTimeEmpty
            // 
            this.ispnTimeEmpty.AutoHeight = false;
            this.ispnTimeEmpty.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnTimeEmpty.Name = "ispnTimeEmpty";
            // 
            // gcLimit
            // 
            this.gcLimit.Caption = "Limit";
            this.gcLimit.ColumnEdit = this.ispnLimit;
            this.gcLimit.FieldName = "Limit";
            this.gcLimit.MinWidth = 22;
            this.gcLimit.Name = "gcLimit";
            this.gcLimit.Width = 80;
            // 
            // ispnLimit
            // 
            this.ispnLimit.AutoHeight = false;
            this.ispnLimit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnLimit.Name = "ispnLimit";
            // 
            // gcWeiToVib
            // 
            this.gcWeiToVib.Caption = "KL Rung Cân";
            this.gcWeiToVib.ColumnEdit = this.ispnWeiToVib;
            this.gcWeiToVib.FieldName = "WeiToVib";
            this.gcWeiToVib.MinWidth = 22;
            this.gcWeiToVib.Name = "gcWeiToVib";
            this.gcWeiToVib.Visible = true;
            this.gcWeiToVib.VisibleIndex = 4;
            this.gcWeiToVib.Width = 80;
            // 
            // ispnWeiToVib
            // 
            this.ispnWeiToVib.AutoHeight = false;
            this.ispnWeiToVib.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnWeiToVib.Name = "ispnWeiToVib";
            // 
            // gcTON
            // 
            this.gcTON.Caption = "T ON";
            this.gcTON.ColumnEdit = this.ispnTON;
            this.gcTON.FieldName = "TON";
            this.gcTON.MinWidth = 22;
            this.gcTON.Name = "gcTON";
            this.gcTON.Visible = true;
            this.gcTON.VisibleIndex = 5;
            this.gcTON.Width = 80;
            // 
            // ispnTON
            // 
            this.ispnTON.AutoHeight = false;
            this.ispnTON.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnTON.Name = "ispnTON";
            // 
            // gcTOFF
            // 
            this.gcTOFF.Caption = "T OFF";
            this.gcTOFF.ColumnEdit = this.ispnTOFF;
            this.gcTOFF.FieldName = "TOFF";
            this.gcTOFF.MinWidth = 22;
            this.gcTOFF.Name = "gcTOFF";
            this.gcTOFF.Visible = true;
            this.gcTOFF.VisibleIndex = 6;
            this.gcTOFF.Width = 80;
            // 
            // ispnTOFF
            // 
            this.ispnTOFF.AutoHeight = false;
            this.ispnTOFF.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnTOFF.Name = "ispnTOFF";
            // 
            // gcSpare
            // 
            this.gcSpare.Caption = "Spare";
            this.gcSpare.ColumnEdit = this.ispnSpare;
            this.gcSpare.FieldName = "Spare";
            this.gcSpare.MinWidth = 22;
            this.gcSpare.Name = "gcSpare";
            this.gcSpare.Width = 80;
            // 
            // ispnSpare
            // 
            this.ispnSpare.AutoHeight = false;
            this.ispnSpare.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnSpare.Name = "ispnSpare";
            // 
            // gcSTT
            // 
            this.gcSTT.Caption = "Số TT";
            this.gcSTT.ColumnEdit = this.ispnSTT;
            this.gcSTT.FieldName = "STT";
            this.gcSTT.MinWidth = 22;
            this.gcSTT.Name = "gcSTT";
            this.gcSTT.Width = 80;
            // 
            // ispnSTT
            // 
            this.ispnSTT.AutoHeight = false;
            this.ispnSTT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnSTT.Name = "ispnSTT";
            // 
            // gcMarkAsDeleted
            // 
            this.gcMarkAsDeleted.Caption = "Mark As Deleted";
            this.gcMarkAsDeleted.FieldName = "MarkAsDeleted";
            this.gcMarkAsDeleted.MinWidth = 22;
            this.gcMarkAsDeleted.Name = "gcMarkAsDeleted";
            this.gcMarkAsDeleted.Width = 80;
            // 
            // gcTilexa
            // 
            this.gcTilexa.Caption = "Tỷ lệ xả";
            this.gcTilexa.ColumnEdit = this.repositoryItemSpinEdit1;
            this.gcTilexa.FieldName = "TiLeXa";
            this.gcTilexa.MinWidth = 22;
            this.gcTilexa.Name = "gcTilexa";
            this.gcTilexa.Width = 80;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // WeighMngView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMaster);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "WeighMngView";
            this.Size = new System.Drawing.Size(772, 488);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpMaster)).EndInit();
            this.grpMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itxtWeigh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itxtWeighName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itxtDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnKLEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnTimeEmpty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnWeiToVib)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnTON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnTOFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnSpare)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnSTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarStaticItem bsiCaption;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private DevExpress.XtraEditors.GroupControl grpMaster;
        private DevExpress.XtraGrid.GridControl grcData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn gcWeighCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit itxtWeigh;
        private DevExpress.XtraGrid.Columns.GridColumn gcWeighName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit itxtWeighName;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit itxtDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcZero;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnZero;
        private DevExpress.XtraGrid.Columns.GridColumn gcMax;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnMax;
        private DevExpress.XtraGrid.Columns.GridColumn gcOffset;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnOffset;
        private DevExpress.XtraGrid.Columns.GridColumn gcKLEmpty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnKLEmpty;
        private DevExpress.XtraGrid.Columns.GridColumn gcTimeEmpty;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnTimeEmpty;
        private DevExpress.XtraGrid.Columns.GridColumn gcLimit;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnLimit;
        private DevExpress.XtraGrid.Columns.GridColumn gcWeiToVib;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnWeiToVib;
        private DevExpress.XtraGrid.Columns.GridColumn gcTON;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnTON;
        private DevExpress.XtraGrid.Columns.GridColumn gcTOFF;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnTOFF;
        private DevExpress.XtraGrid.Columns.GridColumn gcSpare;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnSpare;
        private DevExpress.XtraGrid.Columns.GridColumn gcSTT;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnSTT;
        private DevExpress.XtraGrid.Columns.GridColumn gcMarkAsDeleted;
        private DevExpress.XtraGrid.Columns.GridColumn gcTilexa;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
    }
}


namespace NDPSo.MasterData
{
    partial class TimeGTParaMngView
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
            this.bbiSaveTimer = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefreshTimer = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPLCTimer = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.grcMaster = new DevExpress.XtraEditors.GroupControl();
            this.grcData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcTimerParaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itxtTimerPara = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itxtDesc = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcTimerParaValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ispnTimerParatValue = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.gcMarkAsDeleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMaster)).BeginInit();
            this.grcMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itxtTimerPara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itxtDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnTimerParatValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
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
            this.bbiSaveTimer,
            this.bbiRefreshTimer,
            this.bbiPLCTimer});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bsiCaption),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiSaveTimer),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefreshTimer),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPLCTimer)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bsiCaption
            // 
            this.bsiCaption.Caption = "Thông số Gàu tải";
            this.bsiCaption.Id = 0;
            this.bsiCaption.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsiCaption.ItemAppearance.Normal.Options.UseFont = true;
            this.bsiCaption.Name = "bsiCaption";
            // 
            // bbiSaveTimer
            // 
            this.bbiSaveTimer.Caption = "Lưu";
            this.bbiSaveTimer.Id = 1;
            this.bbiSaveTimer.ImageOptions.Image = global::NDPSo.ResourceNDP.Save;
            this.bbiSaveTimer.Name = "bbiSaveTimer";
            this.bbiSaveTimer.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiSaveTimer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveTimer_ItemClick);
            // 
            // bbiRefreshTimer
            // 
            this.bbiRefreshTimer.Caption = "Làm mới";
            this.bbiRefreshTimer.Id = 2;
            this.bbiRefreshTimer.ImageOptions.Image = global::NDPSo.ResourceNDP.refresh;
            this.bbiRefreshTimer.Name = "bbiRefreshTimer";
            this.bbiRefreshTimer.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiRefreshTimer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefreshTimer_ItemClick);
            // 
            // bbiPLCTimer
            // 
            this.bbiPLCTimer.Caption = "PLC";
            this.bbiPLCTimer.Id = 3;
            this.bbiPLCTimer.ImageOptions.Image = global::NDPSo.ResourceNDP.load_plc;
            this.bbiPLCTimer.Name = "bbiPLCTimer";
            this.bbiPLCTimer.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiPLCTimer.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.bbiPLCTimer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPLCTimer_ItemClick);
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
            // grcMaster
            // 
            this.grcMaster.Controls.Add(this.grcData);
            this.grcMaster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcMaster.Location = new System.Drawing.Point(0, 40);
            this.grcMaster.Margin = new System.Windows.Forms.Padding(2);
            this.grcMaster.Name = "grcMaster";
            this.grcMaster.Size = new System.Drawing.Size(772, 448);
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
            this.repositoryItemTimeEdit1,
            this.itxtTimerPara,
            this.itxtDesc,
            this.ispnTimerParatValue});
            this.grcData.Size = new System.Drawing.Size(768, 423);
            this.grcData.TabIndex = 0;
            this.grcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            this.grcData.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.grcData_ProcessGridKey);
            // 
            // grvData
            // 
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcTimerParaCode,
            this.gcDesc,
            this.gcTimerParaValue,
            this.gcMarkAsDeleted});
            this.grvData.DetailHeight = 284;
            this.grvData.GridControl = this.grcData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvData.OptionsView.ShowFooter = true;
            // 
            // gcTimerParaCode
            // 
            this.gcTimerParaCode.Caption = "Mã";
            this.gcTimerParaCode.ColumnEdit = this.itxtTimerPara;
            this.gcTimerParaCode.FieldName = "TimerParaCode";
            this.gcTimerParaCode.MinWidth = 22;
            this.gcTimerParaCode.Name = "gcTimerParaCode";
            this.gcTimerParaCode.Visible = true;
            this.gcTimerParaCode.VisibleIndex = 0;
            this.gcTimerParaCode.Width = 80;
            // 
            // itxtTimerPara
            // 
            this.itxtTimerPara.AllowFocused = false;
            this.itxtTimerPara.AutoHeight = false;
            this.itxtTimerPara.Name = "itxtTimerPara";
            this.itxtTimerPara.ReadOnly = true;
            // 
            // gcDesc
            // 
            this.gcDesc.Caption = "Thông số gàu tải";
            this.gcDesc.ColumnEdit = this.itxtDesc;
            this.gcDesc.FieldName = "Description";
            this.gcDesc.MinWidth = 22;
            this.gcDesc.Name = "gcDesc";
            this.gcDesc.OptionsColumn.ReadOnly = true;
            this.gcDesc.Visible = true;
            this.gcDesc.VisibleIndex = 1;
            this.gcDesc.Width = 80;
            // 
            // itxtDesc
            // 
            this.itxtDesc.AutoHeight = false;
            this.itxtDesc.Name = "itxtDesc";
            this.itxtDesc.ReadOnly = true;
            // 
            // gcTimerParaValue
            // 
            this.gcTimerParaValue.AppearanceCell.Options.UseTextOptions = true;
            this.gcTimerParaValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcTimerParaValue.Caption = "Giá Trị";
            this.gcTimerParaValue.ColumnEdit = this.ispnTimerParatValue;
            this.gcTimerParaValue.DisplayFormat.FormatString = "n2";
            this.gcTimerParaValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcTimerParaValue.FieldName = "TimerParaValue";
            this.gcTimerParaValue.MinWidth = 22;
            this.gcTimerParaValue.Name = "gcTimerParaValue";
            this.gcTimerParaValue.Visible = true;
            this.gcTimerParaValue.VisibleIndex = 2;
            this.gcTimerParaValue.Width = 80;
            // 
            // ispnTimerParatValue
            // 
            this.ispnTimerParatValue.AllowFocused = false;
            this.ispnTimerParatValue.AutoHeight = false;
            this.ispnTimerParatValue.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ispnTimerParatValue.DisplayFormat.FormatString = "n2";
            this.ispnTimerParatValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ispnTimerParatValue.EditFormat.FormatString = "n2";
            this.ispnTimerParatValue.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ispnTimerParatValue.Name = "ispnTimerParatValue";
            // 
            // gcMarkAsDeleted
            // 
            this.gcMarkAsDeleted.Caption = "Mark As Deleted";
            this.gcMarkAsDeleted.FieldName = "MarkAsDeleted";
            this.gcMarkAsDeleted.MinWidth = 22;
            this.gcMarkAsDeleted.Name = "gcMarkAsDeleted";
            this.gcMarkAsDeleted.Width = 80;
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // TimeGTParaMngView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Caption = "Timer";
            this.Controls.Add(this.grcMaster);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "TimeGTParaMngView";
            this.Size = new System.Drawing.Size(772, 488);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcMaster)).EndInit();
            this.grcMaster.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itxtTimerPara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itxtDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ispnTimerParatValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem bbiSaveTimer;
        private DevExpress.XtraBars.BarButtonItem bbiRefreshTimer;
        private DevExpress.XtraBars.BarButtonItem bbiPLCTimer;
        private DevExpress.XtraEditors.GroupControl grcMaster;
        private DevExpress.XtraGrid.GridControl grcData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn gcTimerParaCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit itxtTimerPara;
        private DevExpress.XtraGrid.Columns.GridColumn gcDesc;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit itxtDesc;
        private DevExpress.XtraGrid.Columns.GridColumn gcTimerParaValue;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit ispnTimerParatValue;
        private DevExpress.XtraGrid.Columns.GridColumn gcMarkAsDeleted;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
    }
}

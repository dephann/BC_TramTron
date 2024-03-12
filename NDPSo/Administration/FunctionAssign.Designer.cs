
namespace NDPSo.Administration
{
    partial class FunctionAssign
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.grcFunction = new DevExpress.XtraGrid.GridControl();
            this.grvFunction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ichkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcFunctionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ichkSelectDet = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grvFunctionDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.grcRole = new DevExpress.XtraGrid.GridControl();
            this.grvRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlCommand = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grcFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ichkSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ichkSelectDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFunctionDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommand)).BeginInit();
            this.pnlCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // grcFunction
            // 
            this.grcFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grcFunction.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            gridLevelNode1.RelationName = "Level1";
            this.grcFunction.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grcFunction.Location = new System.Drawing.Point(190, 0);
            this.grcFunction.MainView = this.grvFunction;
            this.grcFunction.Name = "grcFunction";
            this.grcFunction.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ichkSelect,
            this.ichkSelectDet});
            this.grcFunction.Size = new System.Drawing.Size(1052, 510);
            this.grcFunction.TabIndex = 1;
            this.grcFunction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFunction,
            this.grvFunctionDetail});
            // 
            // grvFunction
            // 
            this.grvFunction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSelect,
            this.gcFunctionName});
            this.grvFunction.GridControl = this.grcFunction;
            this.grvFunction.Name = "grvFunction";
            this.grvFunction.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvFunction_CellValueChanging);
            // 
            // gcSelect
            // 
            this.gcSelect.Caption = "Select";
            this.gcSelect.ColumnEdit = this.ichkSelect;
            this.gcSelect.FieldName = "NPSelect";
            this.gcSelect.Name = "gcSelect";
            this.gcSelect.Visible = true;
            this.gcSelect.VisibleIndex = 0;
            this.gcSelect.Width = 163;
            // 
            // ichkSelect
            // 
            this.ichkSelect.AutoHeight = false;
            this.ichkSelect.Name = "ichkSelect";
            // 
            // gcFunctionName
            // 
            this.gcFunctionName.Caption = "Function Name";
            this.gcFunctionName.FieldName = "FunctionName";
            this.gcFunctionName.Name = "gcFunctionName";
            this.gcFunctionName.OptionsColumn.AllowEdit = false;
            this.gcFunctionName.OptionsColumn.AllowFocus = false;
            this.gcFunctionName.Visible = true;
            this.gcFunctionName.VisibleIndex = 1;
            this.gcFunctionName.Width = 864;
            // 
            // ichkSelectDet
            // 
            this.ichkSelectDet.AutoHeight = false;
            this.ichkSelectDet.Name = "ichkSelectDet";
            // 
            // grvFunctionDetail
            // 
            this.grvFunctionDetail.GridControl = this.grcFunction;
            this.grvFunctionDetail.Name = "grvFunctionDetail";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grcFunction);
            this.pnlMain.Controls.Add(this.grcRole);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1256, 566);
            this.pnlMain.TabIndex = 0;
            // 
            // grcRole
            // 
            this.grcRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grcRole.Location = new System.Drawing.Point(0, 0);
            this.grcRole.MainView = this.grvRole;
            this.grcRole.Name = "grcRole";
            this.grcRole.Size = new System.Drawing.Size(193, 510);
            this.grcRole.TabIndex = 0;
            this.grcRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRole});
            // 
            // grvRole
            // 
            this.grvRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcRoleName});
            this.grvRole.GridControl = this.grcRole;
            this.grvRole.Name = "grvRole";
            this.grvRole.OptionsView.ShowGroupPanel = false;
            this.grvRole.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvRole.OptionsView.ShowIndicator = false;
            this.grvRole.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvRole.OptionsView.ShowViewCaption = true;
            this.grvRole.ViewCaption = "Vai trò";
            this.grvRole.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvRole_FocusedRowChanged);
            // 
            // gcRoleName
            // 
            this.gcRoleName.Caption = "Role Name";
            this.gcRoleName.FieldName = "RoleName";
            this.gcRoleName.Name = "gcRoleName";
            this.gcRoleName.OptionsColumn.AllowEdit = false;
            this.gcRoleName.OptionsColumn.AllowFocus = false;
            this.gcRoleName.Visible = true;
            this.gcRoleName.VisibleIndex = 0;
            // 
            // pnlCommand
            // 
            this.pnlCommand.Controls.Add(this.btnClose);
            this.pnlCommand.Controls.Add(this.btnSave);
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommand.Location = new System.Drawing.Point(0, 516);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Size = new System.Drawing.Size(1256, 50);
            this.pnlCommand.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(1110, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Location = new System.Drawing.Point(991, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FunctionAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCommand);
            this.Controls.Add(this.pnlMain);
            this.Name = "FunctionAssign";
            this.Size = new System.Drawing.Size(1256, 566);
            ((System.ComponentModel.ISupportInitialize)(this.grcFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ichkSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ichkSelectDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFunctionDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommand)).EndInit();
            this.pnlCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraGrid.GridControl grcFunction;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ichkSelectDet;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFunction;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ichkSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gcFunctionName;
        private DevExpress.XtraGrid.GridControl grcRole;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRole;
        private DevExpress.XtraGrid.Columns.GridColumn gcRoleName;
        private DevExpress.XtraEditors.PanelControl pnlCommand;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFunctionDetail;
    }
}

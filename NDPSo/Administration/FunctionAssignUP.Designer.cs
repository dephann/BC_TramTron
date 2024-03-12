
namespace NDPSo.Administration
{
    partial class FunctionAssignUP
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
            this.grvFunctionDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSelectDet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ichkSelectDet = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcFunctionNameDet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcFunction = new DevExpress.XtraGrid.GridControl();
            this.grvFunction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ichkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcFunctionName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcRole = new DevExpress.XtraGrid.GridControl();
            this.grvRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grvFunctionDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ichkSelectDet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ichkSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grvFunctionDetail
            // 
            this.grvFunctionDetail.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvFunctionDetail.Appearance.Row.Options.UseFont = true;
            this.grvFunctionDetail.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.grvFunctionDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSelectDet,
            this.gcFunctionNameDet});
            this.grvFunctionDetail.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFunctionDetail.GridControl = this.grcFunction;
            this.grvFunctionDetail.Name = "grvFunctionDetail";
            this.grvFunctionDetail.OptionsView.ShowColumnHeaders = false;
            this.grvFunctionDetail.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFunctionDetail.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.grvFunctionDetail.OptionsView.ShowGroupPanel = false;
            this.grvFunctionDetail.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvFunctionDetail.OptionsView.ShowIndicator = false;
            this.grvFunctionDetail.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvFunctionDetail.ViewCaption = " ";
            this.grvFunctionDetail.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvFunctionDetail_CellValueChanging);
            // 
            // gcSelectDet
            // 
            this.gcSelectDet.Caption = "Select";
            this.gcSelectDet.ColumnEdit = this.ichkSelectDet;
            this.gcSelectDet.FieldName = "NPSelect";
            this.gcSelectDet.Name = "gcSelectDet";
            this.gcSelectDet.Visible = true;
            this.gcSelectDet.VisibleIndex = 0;
            // 
            // ichkSelectDet
            // 
            this.ichkSelectDet.AutoHeight = false;
            this.ichkSelectDet.Name = "ichkSelectDet";
            // 
            // gcFunctionNameDet
            // 
            this.gcFunctionNameDet.Caption = "Detail";
            this.gcFunctionNameDet.FieldName = "FunctionName";
            this.gcFunctionNameDet.Name = "gcFunctionNameDet";
            this.gcFunctionNameDet.OptionsColumn.AllowEdit = false;
            this.gcFunctionNameDet.OptionsColumn.AllowFocus = false;
            this.gcFunctionNameDet.Visible = true;
            this.gcFunctionNameDet.VisibleIndex = 1;
            this.gcFunctionNameDet.Width = 250;
            // 
            // grcFunction
            // 
            this.grcFunction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grcFunction.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            gridLevelNode1.LevelTemplate = this.grvFunctionDetail;
            gridLevelNode1.RelationName = "LstChildFunction";
            this.grcFunction.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grcFunction.Location = new System.Drawing.Point(281, 5);
            this.grcFunction.MainView = this.grvFunction;
            this.grcFunction.Name = "grcFunction";
            this.grcFunction.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ichkSelect,
            this.ichkSelectDet});
            this.grcFunction.ShowOnlyPredefinedDetails = true;
            this.grcFunction.Size = new System.Drawing.Size(400, 576);
            this.grcFunction.TabIndex = 1;
            this.grcFunction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFunction,
            this.grvFunctionDetail});
            // 
            // grvFunction
            // 
            this.grvFunction.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvFunction.Appearance.Row.Options.UseFont = true;
            this.grvFunction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcSelect,
            this.gcFunctionName});
            this.grvFunction.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFunction.GridControl = this.grcFunction;
            this.grvFunction.Name = "grvFunction";
            this.grvFunction.OptionsView.ShowColumnHeaders = false;
            this.grvFunction.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFunction.OptionsView.ShowGroupPanel = false;
            this.grvFunction.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvFunction.OptionsView.ShowIndicator = false;
            this.grvFunction.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvFunction.OptionsView.ShowViewCaption = true;
            this.grvFunction.ViewCaption = "Chức năng";
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
            this.gcSelect.Width = 106;
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
            this.gcFunctionName.Width = 545;
            // 
            // grcRole
            // 
            this.grcRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grcRole.Location = new System.Drawing.Point(5, 5);
            this.grcRole.MainView = this.grvRole;
            this.grcRole.Name = "grcRole";
            this.grcRole.Size = new System.Drawing.Size(270, 576);
            this.grcRole.TabIndex = 0;
            this.grcRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRole});
            // 
            // grvRole
            // 
            this.grvRole.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvRole.Appearance.Row.Options.UseFont = true;
            this.grvRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcRoleName});
            this.grvRole.GridControl = this.grcRole;
            this.grvRole.Name = "grvRole";
            this.grvRole.OptionsView.ShowColumnHeaders = false;
            this.grvRole.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
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
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grcRole);
            this.pnlMain.Controls.Add(this.grcFunction);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(950, 637);
            this.pnlMain.TabIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 587);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(950, 50);
            this.panelControl1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Location = new System.Drawing.Point(791, 10);
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
            this.btnSave.Location = new System.Drawing.Point(672, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FunctionAssignUP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnlMain);
            this.Name = "FunctionAssignUP";
            this.Size = new System.Drawing.Size(950, 637);
            ((System.ComponentModel.ISupportInitialize)(this.grvFunctionDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ichkSelectDet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ichkSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grcRole;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRole;
        private DevExpress.XtraGrid.Columns.GridColumn gcRoleName;
        private DevExpress.XtraGrid.GridControl grcFunction;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFunction;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelect;
        private DevExpress.XtraGrid.Columns.GridColumn gcFunctionName;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ichkSelect;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFunctionDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelectDet;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ichkSelectDet;
        private DevExpress.XtraGrid.Columns.GridColumn gcFunctionNameDet;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}

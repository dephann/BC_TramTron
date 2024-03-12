
namespace NDPSo.Administration
{
    partial class RoleAssign
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
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.grcRole = new DevExpress.XtraGrid.GridControl();
            this.grvRole = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcRoleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ichkSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grcUser = new DevExpress.XtraGrid.GridControl();
            this.grvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlCommand = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ichkSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommand)).BeginInit();
            this.pnlCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.grcRole);
            this.pnlMain.Controls.Add(this.grcUser);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(950, 554);
            this.pnlMain.TabIndex = 0;
            // 
            // grcRole
            // 
            this.grcRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grcRole.Location = new System.Drawing.Point(281, 5);
            this.grcRole.MainView = this.grvRole;
            this.grcRole.Name = "grcRole";
            this.grcRole.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ichkSelect});
            this.grcRole.Size = new System.Drawing.Size(400, 493);
            this.grcRole.TabIndex = 1;
            this.grcRole.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRole});
            // 
            // grvRole
            // 
            this.grvRole.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvRole.Appearance.Row.Options.UseFont = true;
            this.grvRole.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcRoleName,
            this.gcSelect});
            this.grvRole.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRole.GridControl = this.grcRole;
            this.grvRole.Name = "grvRole";
            this.grvRole.OptionsView.ShowColumnHeaders = false;
            this.grvRole.OptionsView.ShowDetailButtons = false;
            this.grvRole.OptionsView.ShowGroupPanel = false;
            this.grvRole.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvRole.OptionsView.ShowIndicator = false;
            this.grvRole.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvRole.OptionsView.ShowViewCaption = true;
            this.grvRole.ViewCaption = "Vai trò";
            this.grvRole.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvRole_CellValueChanging);
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
            // gcSelect
            // 
            this.gcSelect.Caption = "Select";
            this.gcSelect.ColumnEdit = this.ichkSelect;
            this.gcSelect.FieldName = "NPSelect";
            this.gcSelect.Name = "gcSelect";
            this.gcSelect.Visible = true;
            this.gcSelect.VisibleIndex = 1;
            // 
            // ichkSelect
            // 
            this.ichkSelect.AutoHeight = false;
            this.ichkSelect.Name = "ichkSelect";
            // 
            // grcUser
            // 
            this.grcUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grcUser.Location = new System.Drawing.Point(5, 5);
            this.grcUser.MainView = this.grvUser;
            this.grcUser.Name = "grcUser";
            this.grcUser.Size = new System.Drawing.Size(270, 493);
            this.grcUser.TabIndex = 0;
            this.grcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUser});
            // 
            // grvUser
            // 
            this.grvUser.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvUser.Appearance.Row.Options.UseFont = true;
            this.grvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcUserName});
            this.grvUser.GridControl = this.grcUser;
            this.grvUser.Name = "grvUser";
            this.grvUser.OptionsView.ShowColumnHeaders = false;
            this.grvUser.OptionsView.ShowDetailButtons = false;
            this.grvUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvUser.OptionsView.ShowGroupPanel = false;
            this.grvUser.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvUser.OptionsView.ShowIndicator = false;
            this.grvUser.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.grvUser.OptionsView.ShowViewCaption = true;
            this.grvUser.ViewCaption = "Người dùng";
            this.grvUser.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvUser_FocusedRowChanged);
            // 
            // gcUserName
            // 
            this.gcUserName.Caption = "User Name";
            this.gcUserName.FieldName = "UserName";
            this.gcUserName.Name = "gcUserName";
            this.gcUserName.OptionsColumn.AllowEdit = false;
            this.gcUserName.OptionsColumn.AllowFocus = false;
            this.gcUserName.Visible = true;
            this.gcUserName.VisibleIndex = 0;
            // 
            // pnlCommand
            // 
            this.pnlCommand.Controls.Add(this.btnClose);
            this.pnlCommand.Controls.Add(this.btnSave);
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommand.Location = new System.Drawing.Point(0, 504);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Size = new System.Drawing.Size(950, 50);
            this.pnlCommand.TabIndex = 1;
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
            this.btnClose.TabIndex = 3;
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
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // RoleAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCommand);
            this.Controls.Add(this.pnlMain);
            this.Name = "RoleAssign";
            this.Size = new System.Drawing.Size(950, 554);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ichkSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommand)).EndInit();
            this.pnlCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.PanelControl pnlCommand;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl grcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUser;
        private DevExpress.XtraGrid.GridControl grcRole;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRole;
        private DevExpress.XtraGrid.Columns.GridColumn gcUserName;
        private DevExpress.XtraGrid.Columns.GridColumn gcRoleName;
        private DevExpress.XtraGrid.Columns.GridColumn gcSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ichkSelect;
    }
}

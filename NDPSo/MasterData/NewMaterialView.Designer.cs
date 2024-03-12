
namespace NDPSo.MasterData
{
    partial class NewMaterialView
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
            this.spnDonGia = new DevExpress.XtraEditors.SpinEdit();
            this.lueDonVi = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDonGia = new DevExpress.XtraEditors.LabelControl();
            this.lblDonVi = new DevExpress.XtraEditors.LabelControl();
            this.txtNhaCungCap = new DevExpress.XtraEditors.TextEdit();
            this.lblNhaCungCap = new DevExpress.XtraEditors.LabelControl();
            this.txtMaterialName = new DevExpress.XtraEditors.TextEdit();
            this.lblTenVatTu = new DevExpress.XtraEditors.LabelControl();
            this.lblActive = new DevExpress.XtraEditors.LabelControl();
            this.chkActive = new DevExpress.XtraEditors.CheckEdit();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.txtMaterialCode = new DevExpress.XtraEditors.TextEdit();
            this.lblDescritpion = new DevExpress.XtraEditors.LabelControl();
            this.lblMaVatTu = new DevExpress.XtraEditors.LabelControl();
            this.pnlCommand = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveNew = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhaCungCap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommand)).BeginInit();
            this.pnlCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.spnDonGia);
            this.pnlMain.Controls.Add(this.lueDonVi);
            this.pnlMain.Controls.Add(this.lblDonGia);
            this.pnlMain.Controls.Add(this.lblDonVi);
            this.pnlMain.Controls.Add(this.txtNhaCungCap);
            this.pnlMain.Controls.Add(this.lblNhaCungCap);
            this.pnlMain.Controls.Add(this.txtMaterialName);
            this.pnlMain.Controls.Add(this.lblTenVatTu);
            this.pnlMain.Controls.Add(this.lblActive);
            this.pnlMain.Controls.Add(this.chkActive);
            this.pnlMain.Controls.Add(this.txtDescription);
            this.pnlMain.Controls.Add(this.txtMaterialCode);
            this.pnlMain.Controls.Add(this.lblDescritpion);
            this.pnlMain.Controls.Add(this.lblMaVatTu);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(495, 245);
            this.pnlMain.TabIndex = 0;
            // 
            // spnDonGia
            // 
            this.spnDonGia.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spnDonGia.Location = new System.Drawing.Point(200, 160);
            this.spnDonGia.Name = "spnDonGia";
            this.spnDonGia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spnDonGia.Properties.Appearance.Options.UseFont = true;
            this.spnDonGia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spnDonGia.Size = new System.Drawing.Size(200, 22);
            this.spnDonGia.TabIndex = 39;
            this.spnDonGia.EditValueChanged += new System.EventHandler(this.spnDonGia_EditValueChanged);
            // 
            // lueDonVi
            // 
            this.lueDonVi.Location = new System.Drawing.Point(200, 130);
            this.lueDonVi.Name = "lueDonVi";
            this.lueDonVi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueDonVi.Properties.Appearance.Options.UseFont = true;
            this.lueDonVi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueDonVi.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DisplayText", "Đơn vị")});
            this.lueDonVi.Properties.DisplayMember = "DisplayText";
            this.lueDonVi.Properties.NullText = "";
            this.lueDonVi.Properties.ValueMember = "ID";
            this.lueDonVi.Size = new System.Drawing.Size(200, 22);
            this.lueDonVi.TabIndex = 38;
            this.lueDonVi.EditValueChanged += new System.EventHandler(this.lueDonVi_EditValueChanged);
            // 
            // lblDonGia
            // 
            this.lblDonGia.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonGia.Appearance.Options.UseFont = true;
            this.lblDonGia.Location = new System.Drawing.Point(130, 163);
            this.lblDonGia.Margin = new System.Windows.Forms.Padding(2);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(46, 16);
            this.lblDonGia.TabIndex = 36;
            this.lblDonGia.Text = "Đơn giá";
            // 
            // lblDonVi
            // 
            this.lblDonVi.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonVi.Appearance.Options.UseFont = true;
            this.lblDonVi.Location = new System.Drawing.Point(116, 133);
            this.lblDonVi.Margin = new System.Windows.Forms.Padding(2);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(60, 16);
            this.lblDonVi.TabIndex = 34;
            this.lblDonVi.Text = "Đơn vị tính";
            // 
            // txtNhaCungCap
            // 
            this.txtNhaCungCap.Location = new System.Drawing.Point(200, 100);
            this.txtNhaCungCap.Margin = new System.Windows.Forms.Padding(2);
            this.txtNhaCungCap.Name = "txtNhaCungCap";
            this.txtNhaCungCap.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhaCungCap.Properties.Appearance.Options.UseFont = true;
            this.txtNhaCungCap.Size = new System.Drawing.Size(200, 22);
            this.txtNhaCungCap.TabIndex = 33;
            // 
            // lblNhaCungCap
            // 
            this.lblNhaCungCap.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhaCungCap.Appearance.Options.UseFont = true;
            this.lblNhaCungCap.Location = new System.Drawing.Point(93, 103);
            this.lblNhaCungCap.Margin = new System.Windows.Forms.Padding(2);
            this.lblNhaCungCap.Name = "lblNhaCungCap";
            this.lblNhaCungCap.Size = new System.Drawing.Size(83, 16);
            this.lblNhaCungCap.TabIndex = 32;
            this.lblNhaCungCap.Text = "Nhà cung cấp";
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Location = new System.Drawing.Point(200, 70);
            this.txtMaterialName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.txtMaterialName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialName.Properties.Appearance.Options.UseBackColor = true;
            this.txtMaterialName.Properties.Appearance.Options.UseFont = true;
            this.txtMaterialName.Size = new System.Drawing.Size(200, 22);
            this.txtMaterialName.TabIndex = 31;
            // 
            // lblTenVatTu
            // 
            this.lblTenVatTu.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenVatTu.Appearance.Options.UseFont = true;
            this.lblTenVatTu.Location = new System.Drawing.Point(118, 73);
            this.lblTenVatTu.Margin = new System.Windows.Forms.Padding(2);
            this.lblTenVatTu.Name = "lblTenVatTu";
            this.lblTenVatTu.Size = new System.Drawing.Size(58, 16);
            this.lblTenVatTu.TabIndex = 30;
            this.lblTenVatTu.Text = "Tên vật tư";
            // 
            // lblActive
            // 
            this.lblActive.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActive.Appearance.Options.UseFont = true;
            this.lblActive.Location = new System.Drawing.Point(12, 70);
            this.lblActive.Margin = new System.Windows.Forms.Padding(2);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(54, 16);
            this.lblActive.TabIndex = 29;
            this.lblActive.Text = "Kích hoạt";
            this.lblActive.Visible = false;
            // 
            // chkActive
            // 
            this.chkActive.Location = new System.Drawing.Point(76, 68);
            this.chkActive.Margin = new System.Windows.Forms.Padding(2);
            this.chkActive.Name = "chkActive";
            this.chkActive.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActive.Properties.Appearance.Options.UseFont = true;
            this.chkActive.Properties.Caption = "";
            this.chkActive.Size = new System.Drawing.Size(33, 20);
            this.chkActive.TabIndex = 28;
            this.chkActive.Visible = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(50, 38);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Properties.Appearance.Options.UseFont = true;
            this.txtDescription.Size = new System.Drawing.Size(41, 22);
            this.txtDescription.TabIndex = 27;
            this.txtDescription.Visible = false;
            // 
            // txtMaterialCode
            // 
            this.txtMaterialCode.Location = new System.Drawing.Point(200, 40);
            this.txtMaterialCode.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaterialCode.Name = "txtMaterialCode";
            this.txtMaterialCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(233)))), ((int)(((byte)(252)))));
            this.txtMaterialCode.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterialCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtMaterialCode.Properties.Appearance.Options.UseFont = true;
            this.txtMaterialCode.Properties.ReadOnly = true;
            this.txtMaterialCode.Size = new System.Drawing.Size(200, 22);
            this.txtMaterialCode.TabIndex = 25;
            // 
            // lblDescritpion
            // 
            this.lblDescritpion.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescritpion.Appearance.Options.UseFont = true;
            this.lblDescritpion.Location = new System.Drawing.Point(12, 41);
            this.lblDescritpion.Margin = new System.Windows.Forms.Padding(2);
            this.lblDescritpion.Name = "lblDescritpion";
            this.lblDescritpion.Size = new System.Drawing.Size(33, 16);
            this.lblDescritpion.TabIndex = 24;
            this.lblDescritpion.Text = "Mô tả";
            this.lblDescritpion.Visible = false;
            // 
            // lblMaVatTu
            // 
            this.lblMaVatTu.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaVatTu.Appearance.Options.UseFont = true;
            this.lblMaVatTu.Location = new System.Drawing.Point(123, 43);
            this.lblMaVatTu.Margin = new System.Windows.Forms.Padding(2);
            this.lblMaVatTu.Name = "lblMaVatTu";
            this.lblMaVatTu.Size = new System.Drawing.Size(53, 16);
            this.lblMaVatTu.TabIndex = 22;
            this.lblMaVatTu.Text = "Mã vật tư";
            // 
            // pnlCommand
            // 
            this.pnlCommand.Controls.Add(this.btnClose);
            this.pnlCommand.Controls.Add(this.btnSave);
            this.pnlCommand.Controls.Add(this.btnSaveNew);
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCommand.Location = new System.Drawing.Point(0, 198);
            this.pnlCommand.Margin = new System.Windows.Forms.Padding(2);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Size = new System.Drawing.Size(495, 47);
            this.pnlCommand.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(312, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(98, 30);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đóng";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(207, 9);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 30);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveNew
            // 
            this.btnSaveNew.Location = new System.Drawing.Point(74, 9);
            this.btnSaveNew.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveNew.Name = "btnSaveNew";
            this.btnSaveNew.Size = new System.Drawing.Size(126, 30);
            this.btnSaveNew.TabIndex = 6;
            this.btnSaveNew.Text = "Lưu và Thêm Mới";
            this.btnSaveNew.Click += new System.EventHandler(this.btnSaveNew_Click);
            // 
            // NewMaterialView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCommand);
            this.Controls.Add(this.pnlMain);
            this.Name = "NewMaterialView";
            this.Size = new System.Drawing.Size(495, 245);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spnDonGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhaCungCap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaterialCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCommand)).EndInit();
            this.pnlCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.PanelControl pnlCommand;
        private DevExpress.XtraEditors.LabelControl lblActive;
        private DevExpress.XtraEditors.CheckEdit chkActive;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtMaterialCode;
        private DevExpress.XtraEditors.LabelControl lblDescritpion;
        private DevExpress.XtraEditors.LabelControl lblMaVatTu;
        private DevExpress.XtraEditors.TextEdit txtMaterialName;
        private DevExpress.XtraEditors.LabelControl lblTenVatTu;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnSaveNew;
        private DevExpress.XtraEditors.LabelControl lblDonGia;
        private DevExpress.XtraEditors.LabelControl lblDonVi;
        private DevExpress.XtraEditors.TextEdit txtNhaCungCap;
        private DevExpress.XtraEditors.LabelControl lblNhaCungCap;
        private DevExpress.XtraEditors.SpinEdit spnDonGia;
        private DevExpress.XtraEditors.LookUpEdit lueDonVi;
    }
}

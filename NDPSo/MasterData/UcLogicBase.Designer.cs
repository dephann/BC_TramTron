
namespace NDPSo.MasterData
{
    partial class UcLogicBase
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
            this.lueWeigh2 = new DevExpress.XtraEditors.LookUpEdit();
            this.lueWeigh1 = new DevExpress.XtraEditors.LookUpEdit();
            this.btnResetValue = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetUpLogic = new DevExpress.XtraEditors.SimpleButton();
            this.lblLogicName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lueWeigh2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWeigh1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lueWeigh2
            // 
            this.lueWeigh2.Location = new System.Drawing.Point(259, 4);
            this.lueWeigh2.Name = "lueWeigh2";
            this.lueWeigh2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueWeigh2.Properties.Appearance.Options.UseFont = true;
            this.lueWeigh2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueWeigh2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaSilo", "Mã Silo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenSilo", "Tên Silo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SiloID", "SiloID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaterialName", "Tên Vật tư")});
            this.lueWeigh2.Properties.DisplayMember = "MaSilo";
            this.lueWeigh2.Properties.NullText = "";
            this.lueWeigh2.Properties.ValueMember = "SiloID";
            this.lueWeigh2.Size = new System.Drawing.Size(117, 22);
            this.lueWeigh2.TabIndex = 34;
            this.lueWeigh2.EditValueChanged += new System.EventHandler(this.lueWeigh2_EditValueChanged);
            // 
            // lueWeigh1
            // 
            this.lueWeigh1.Location = new System.Drawing.Point(130, 4);
            this.lueWeigh1.Name = "lueWeigh1";
            this.lueWeigh1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueWeigh1.Properties.Appearance.Options.UseFont = true;
            this.lueWeigh1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueWeigh1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaSilo", "Mã Silo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenSilo", "Tên Silo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SiloID", "SiloID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaterialName", "Tên Vật tư")});
            this.lueWeigh1.Properties.DisplayMember = "MaSilo";
            this.lueWeigh1.Properties.NullText = "";
            this.lueWeigh1.Properties.ValueMember = "MaSilo";
            this.lueWeigh1.Size = new System.Drawing.Size(117, 22);
            this.lueWeigh1.TabIndex = 33;
            this.lueWeigh1.EditValueChanged += new System.EventHandler(this.lueWeigh1_EditValueChanged);
            // 
            // btnResetValue
            // 
            this.btnResetValue.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetValue.Appearance.Options.UseFont = true;
            this.btnResetValue.Location = new System.Drawing.Point(505, 2);
            this.btnResetValue.Name = "btnResetValue";
            this.btnResetValue.Size = new System.Drawing.Size(98, 26);
            this.btnResetValue.TabIndex = 32;
            this.btnResetValue.Text = "Làm mới";
            this.btnResetValue.Click += new System.EventHandler(this.btnResetValue_Click);
            // 
            // btnSetUpLogic
            // 
            this.btnSetUpLogic.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetUpLogic.Appearance.Options.UseFont = true;
            this.btnSetUpLogic.Location = new System.Drawing.Point(395, 2);
            this.btnSetUpLogic.Name = "btnSetUpLogic";
            this.btnSetUpLogic.Size = new System.Drawing.Size(98, 26);
            this.btnSetUpLogic.TabIndex = 31;
            this.btnSetUpLogic.Text = "Thiết lập";
            this.btnSetUpLogic.Click += new System.EventHandler(this.btnSetUpLogic_Click);
            // 
            // lblLogicName
            // 
            this.lblLogicName.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogicName.Appearance.Options.UseFont = true;
            this.lblLogicName.Location = new System.Drawing.Point(14, 7);
            this.lblLogicName.Name = "lblLogicName";
            this.lblLogicName.Size = new System.Drawing.Size(63, 16);
            this.lblLogicName.TabIndex = 30;
            this.lblLogicName.Text = "LOGIC CÂN";
            // 
            // UcLogicBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lueWeigh2);
            this.Controls.Add(this.lueWeigh1);
            this.Controls.Add(this.btnResetValue);
            this.Controls.Add(this.btnSetUpLogic);
            this.Controls.Add(this.lblLogicName);
            this.Name = "UcLogicBase";
            this.Size = new System.Drawing.Size(625, 30);
            ((System.ComponentModel.ISupportInitialize)(this.lueWeigh2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWeigh1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnResetValue;
        private DevExpress.XtraEditors.SimpleButton btnSetUpLogic;
        private DevExpress.XtraEditors.LabelControl lblLogicName;
        public DevExpress.XtraEditors.LookUpEdit lueWeigh2;
        public DevExpress.XtraEditors.LookUpEdit lueWeigh1;
    }
}

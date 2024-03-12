
namespace NDPSo.MasterData
{
    partial class UcLogic
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lueFrom = new DevExpress.XtraEditors.LookUpEdit();
            this.lueTo = new DevExpress.XtraEditors.LookUpEdit();
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lueFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(374, 9);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(4, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "/";
            // 
            // lueFrom
            // 
            this.lueFrom.Location = new System.Drawing.Point(9, 6);
            this.lueFrom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lueFrom.Name = "lueFrom";
            this.lueFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueFrom.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaSilo", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenSilo", "Tên")});
            this.lueFrom.Properties.DisplayMember = "MaSilo";
            this.lueFrom.Properties.NullText = "";
            this.lueFrom.Properties.ValueMember = "MaSilo";
            this.lueFrom.Size = new System.Drawing.Size(94, 20);
            this.lueFrom.TabIndex = 1;
            // 
            // lueTo
            // 
            this.lueTo.Location = new System.Drawing.Point(112, 6);
            this.lueTo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lueTo.Name = "lueTo";
            this.lueTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MaSilo", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenSilo", "Tên")});
            this.lueTo.Properties.DisplayMember = "MaSilo";
            this.lueTo.Properties.NullText = "";
            this.lueTo.Properties.ValueMember = "MaSilo";
            this.lueTo.Size = new System.Drawing.Size(94, 20);
            this.lueTo.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(217, 4);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(70, 24);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Thiết lập";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(292, 3);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(70, 24);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Làm mới";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // UcLogic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.lueTo);
            this.Controls.Add(this.lueFrom);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UcLogic";
            this.Size = new System.Drawing.Size(505, 30);
            ((System.ComponentModel.ISupportInitialize)(this.lueFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lueFrom;
        private DevExpress.XtraEditors.LookUpEdit lueTo;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private DevExpress.XtraEditors.SimpleButton btnReset;
    }
}

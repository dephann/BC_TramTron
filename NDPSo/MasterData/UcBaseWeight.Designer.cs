
namespace NDPSo.MasterData
{
    partial class UcBaseWeight
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
        public void InitializeComponent()
        {
            this.picBackground = new DevExpress.XtraEditors.PictureEdit();
            this.lblKhoiLuongCan = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picBackground
            // 
            this.picBackground.BackgroundImage = global::NDPSo.ResourceNDP.Weight_;
            this.picBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.EditValue = "0000";
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBackground.Name = "picBackground";
            this.picBackground.Properties.AllowFocused = false;
            this.picBackground.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picBackground.Properties.Appearance.Options.UseBackColor = true;
            this.picBackground.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picBackground.Properties.NullText = " ";
            this.picBackground.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picBackground.Size = new System.Drawing.Size(103, 71);
            this.picBackground.TabIndex = 0;
            // 
            // lblKhoiLuongCan
            // 
            this.lblKhoiLuongCan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKhoiLuongCan.Appearance.BackColor = System.Drawing.Color.White;
            this.lblKhoiLuongCan.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoiLuongCan.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblKhoiLuongCan.Appearance.Options.UseBackColor = true;
            this.lblKhoiLuongCan.Appearance.Options.UseFont = true;
            this.lblKhoiLuongCan.Appearance.Options.UseForeColor = true;
            this.lblKhoiLuongCan.Appearance.Options.UseTextOptions = true;
            this.lblKhoiLuongCan.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblKhoiLuongCan.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblKhoiLuongCan.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblKhoiLuongCan.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblKhoiLuongCan.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.lblKhoiLuongCan.Location = new System.Drawing.Point(3, 10);
            this.lblKhoiLuongCan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblKhoiLuongCan.Name = "lblKhoiLuongCan";
            this.lblKhoiLuongCan.Size = new System.Drawing.Size(86, 29);
            this.lblKhoiLuongCan.TabIndex = 1;
            this.lblKhoiLuongCan.Text = "9999";
            this.lblKhoiLuongCan.ToolTip = "KL_Cân";
            // 
            // UcBaseWeight
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblKhoiLuongCan);
            this.Controls.Add(this.picBackground);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UcBaseWeight";
            this.Size = new System.Drawing.Size(103, 71);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraEditors.PictureEdit picBackground;
        public DevExpress.XtraEditors.LabelControl lblKhoiLuongCan;
    }
}

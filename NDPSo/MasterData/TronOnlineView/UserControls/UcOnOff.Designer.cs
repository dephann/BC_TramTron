
namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    partial class UcOnOff
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
            this.picOnOff = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picOnOff.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picOnOff
            // 
            this.picOnOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picOnOff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picOnOff.EditValue = global::NDPSo.ResourceNDP.Led_red;
            this.picOnOff.Location = new System.Drawing.Point(0, 0);
            this.picOnOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picOnOff.Name = "picOnOff";
            this.picOnOff.Properties.AllowFocused = false;
            this.picOnOff.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(129)))), ((int)(((byte)(218)))));
            this.picOnOff.Properties.Appearance.Options.UseBackColor = true;
            this.picOnOff.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picOnOff.Properties.NullText = " ";
            this.picOnOff.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picOnOff.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picOnOff.Size = new System.Drawing.Size(26, 24);
            this.picOnOff.TabIndex = 0;
            // 
            // UcOnOff
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picOnOff);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UcOnOff";
            this.Size = new System.Drawing.Size(26, 24);
            ((System.ComponentModel.ISupportInitialize)(this.picOnOff.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picOnOff;
    }
}

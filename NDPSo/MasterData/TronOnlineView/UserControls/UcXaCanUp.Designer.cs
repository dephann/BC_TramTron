
namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    partial class UcXaCanUp
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
            this.picArrowUp = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picArrowUp.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picArrowUp
            // 
            this.picArrowUp.BackgroundImage = global::NDPSo.ResourceNDP.Arrow_Red_Up;
            this.picArrowUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picArrowUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picArrowUp.Location = new System.Drawing.Point(0, 0);
            this.picArrowUp.Name = "picArrowUp";
            this.picArrowUp.Properties.AllowFocused = false;
            this.picArrowUp.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picArrowUp.Properties.Appearance.Options.UseBackColor = true;
            this.picArrowUp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picArrowUp.Properties.NullText = " ";
            this.picArrowUp.Properties.ReadOnly = true;
            this.picArrowUp.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picArrowUp.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picArrowUp.Size = new System.Drawing.Size(30, 40);
            this.picArrowUp.TabIndex = 0;
            // 
            // UcXaCanUp
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picArrowUp);
            this.Name = "UcXaCanUp";
            this.Size = new System.Drawing.Size(30, 40);
            ((System.ComponentModel.ISupportInitialize)(this.picArrowUp.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picArrowUp;
    }
}

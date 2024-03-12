
namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    partial class UcHeThongAuto
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
            this.picBackground = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picBackground
            // 
            this.picBackground.BackgroundImage = global::NDPSo.ResourceNDP.SelectorSwitchRight;
            this.picBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Properties.AllowFocused = false;
            this.picBackground.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picBackground.Properties.Appearance.Options.UseBackColor = true;
            this.picBackground.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picBackground.Properties.NullText = " ";
            this.picBackground.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picBackground.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picBackground.Size = new System.Drawing.Size(70, 70);
            this.picBackground.TabIndex = 0;
            this.picBackground.Click += new System.EventHandler(this.picBackground_Click);
            // 
            // UcHeThongAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picBackground);
            this.Name = "UcHeThongAuto";
            this.Size = new System.Drawing.Size(70, 70);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picBackground;
    }
}

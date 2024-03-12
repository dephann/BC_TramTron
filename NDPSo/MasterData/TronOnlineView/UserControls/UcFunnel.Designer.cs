
namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    partial class UcFunnel
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
            this.picBackground.BackgroundImage = global::NDPSo.ResourceNDP.FunnelBlue;
            this.picBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Margin = new System.Windows.Forms.Padding(2);
            this.picBackground.Name = "picBackground";
            this.picBackground.Properties.AllowFocused = false;
            this.picBackground.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picBackground.Properties.Appearance.Options.UseBackColor = true;
            this.picBackground.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picBackground.Properties.NullText = " ";
            this.picBackground.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picBackground.Size = new System.Drawing.Size(82, 57);
            this.picBackground.TabIndex = 0;
            this.picBackground.Click += new System.EventHandler(this.picBackground_Click);
            // 
            // UcFunnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picBackground);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UcFunnel";
            this.Size = new System.Drawing.Size(82, 57);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picBackground;
    }
}

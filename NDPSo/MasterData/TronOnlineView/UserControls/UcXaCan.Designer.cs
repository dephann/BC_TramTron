
namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    partial class UcXaCan
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
            this.picArrow = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picArrow.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picArrow
            // 
            this.picArrow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picArrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picArrow.EditValue = global::NDPSo.ResourceNDP.Arrow_Blue;
            this.picArrow.Location = new System.Drawing.Point(0, 0);
            this.picArrow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picArrow.Name = "picArrow";
            this.picArrow.Properties.AllowFocused = false;
            this.picArrow.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picArrow.Properties.Appearance.Options.UseBackColor = true;
            this.picArrow.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picArrow.Properties.NullText = " ";
            this.picArrow.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picArrow.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picArrow.Size = new System.Drawing.Size(26, 32);
            this.picArrow.TabIndex = 0;
            // 
            // UcXaCan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picArrow);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UcXaCan";
            this.Size = new System.Drawing.Size(26, 32);
            ((System.ComponentModel.ISupportInitialize)(this.picArrow.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picArrow;
    }
}

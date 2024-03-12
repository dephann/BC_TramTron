
namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    partial class UcBarProcess
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
            this.picBG = new DevExpress.XtraEditors.PictureEdit();
            this.picProcess = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picBG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcess.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picBG
            // 
            this.picBG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBG.Location = new System.Drawing.Point(0, 0);
            this.picBG.Name = "picBG";
            this.picBG.Properties.AllowFocused = false;
            this.picBG.Properties.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.picBG.Properties.Appearance.Options.UseBackColor = true;
            this.picBG.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picBG.Properties.NullText = " ";
            this.picBG.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picBG.Size = new System.Drawing.Size(220, 20);
            this.picBG.TabIndex = 0;
            // 
            // picProcess
            // 
            this.picProcess.Location = new System.Drawing.Point(0, 0);
            this.picProcess.Name = "picProcess";
            this.picProcess.Properties.AllowFocused = false;
            this.picProcess.Properties.Appearance.BackColor = System.Drawing.Color.LimeGreen;
            this.picProcess.Properties.Appearance.Options.UseBackColor = true;
            this.picProcess.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picProcess.Properties.NullText = " ";
            this.picProcess.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picProcess.Size = new System.Drawing.Size(141, 20);
            this.picProcess.TabIndex = 1;
            // 
            // UcBarProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picProcess);
            this.Controls.Add(this.picBG);
            this.Name = "UcBarProcess";
            this.Size = new System.Drawing.Size(220, 20);
            ((System.ComponentModel.ISupportInitialize)(this.picBG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProcess.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picBG;
        private DevExpress.XtraEditors.PictureEdit picProcess;
    }
}

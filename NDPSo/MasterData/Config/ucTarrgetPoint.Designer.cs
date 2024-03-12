
namespace NDPSo.MasterData.Config
{
    partial class ucTarrgetPoint
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
            this.picTargetPoint = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picTargetPoint.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picTargetPoint
            // 
            this.picTargetPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picTargetPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picTargetPoint.EditValue = global::NDPSo.ResourceNDP.pointtarget_print;
            this.picTargetPoint.Location = new System.Drawing.Point(0, 0);
            this.picTargetPoint.Name = "picTargetPoint";
            this.picTargetPoint.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picTargetPoint.Properties.Appearance.Options.UseBackColor = true;
            this.picTargetPoint.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picTargetPoint.Properties.NullText = " ";
            this.picTargetPoint.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picTargetPoint.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picTargetPoint.Size = new System.Drawing.Size(40, 40);
            this.picTargetPoint.TabIndex = 0;
            this.picTargetPoint.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picTargetPoint_MouseClick);
            this.picTargetPoint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picTargetPoint_MouseDown);
            this.picTargetPoint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picTargetPoint_MouseMove);
            this.picTargetPoint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picTargetPoint_MouseUp);
            // 
            // ucTarrgetPoint
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picTargetPoint);
            this.Name = "ucTarrgetPoint";
            this.Size = new System.Drawing.Size(40, 40);
            ((System.ComponentModel.ISupportInitialize)(this.picTargetPoint.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picTargetPoint;
    }
}

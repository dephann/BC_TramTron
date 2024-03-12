
namespace NDPSo.MasterData.Config
{
    partial class ucSilo
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
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.lblCaption = new DevExpress.XtraEditors.LabelControl();
            this.lblToaDoX = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.EditValue = global::NDPSo.ResourceNDP.Tank_Green;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.NullText = " ";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(94, 206);
            this.pictureEdit1.TabIndex = 0;
            this.pictureEdit1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseDown);
            this.pictureEdit1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseMove);
            this.pictureEdit1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureEdit1_MouseUp);
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.BackColor = System.Drawing.Color.Green;
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblCaption.Appearance.Options.UseBackColor = true;
            this.lblCaption.Appearance.Options.UseFont = true;
            this.lblCaption.Appearance.Options.UseForeColor = true;
            this.lblCaption.Appearance.Options.UseTextOptions = true;
            this.lblCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCaption.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCaption.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(94, 22);
            this.lblCaption.TabIndex = 1;
            this.lblCaption.Text = "AGG";
            this.lblCaption.TextChanged += new System.EventHandler(this.lblCaption_TextChanged);
            // 
            // lblToaDoX
            // 
            this.lblToaDoX.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblToaDoX.Appearance.Font = new System.Drawing.Font("Verdana", 10.2F);
            this.lblToaDoX.Appearance.Options.UseBackColor = true;
            this.lblToaDoX.Appearance.Options.UseFont = true;
            this.lblToaDoX.Appearance.Options.UseTextOptions = true;
            this.lblToaDoX.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblToaDoX.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblToaDoX.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblToaDoX.Location = new System.Drawing.Point(0, 22);
            this.lblToaDoX.Name = "lblToaDoX";
            this.lblToaDoX.Size = new System.Drawing.Size(94, 22);
            this.lblToaDoX.TabIndex = 2;
            this.lblToaDoX.Text = "X";
            this.lblToaDoX.TextChanged += new System.EventHandler(this.lblToaDoX_TextChanged);
            // 
            // ucSilo
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblToaDoX);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.pictureEdit1);
            this.Name = "ucSilo";
            this.Size = new System.Drawing.Size(94, 206);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl lblCaption;
        private DevExpress.XtraEditors.LabelControl lblToaDoX;
    }
}

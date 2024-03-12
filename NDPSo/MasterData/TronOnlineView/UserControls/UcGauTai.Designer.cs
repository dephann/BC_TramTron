
namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    partial class UcGauTai
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
            this.lblStatusGAU = new DevExpress.XtraEditors.LabelControl();
            this.ucSoMeDaCan1 = new NDPSo.MasterData.UcSoMeDaCan();
            this.picPheu = new DevExpress.XtraEditors.PictureEdit();
            this.picThanhTruoc = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPheu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThanhTruoc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.NullText = " ";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(244, 262);
            this.pictureEdit1.TabIndex = 0;
            // 
            // lblStatusGAU
            // 
            this.lblStatusGAU.Appearance.BackColor = System.Drawing.Color.White;
            this.lblStatusGAU.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusGAU.Appearance.Options.UseBackColor = true;
            this.lblStatusGAU.Appearance.Options.UseFont = true;
            this.lblStatusGAU.Appearance.Options.UseTextOptions = true;
            this.lblStatusGAU.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStatusGAU.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStatusGAU.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblStatusGAU.Location = new System.Drawing.Point(44, 144);
            this.lblStatusGAU.Name = "lblStatusGAU";
            this.lblStatusGAU.Size = new System.Drawing.Size(30, 18);
            this.lblStatusGAU.TabIndex = 523;
            this.lblStatusGAU.Text = "FU";
            this.lblStatusGAU.Click += new System.EventHandler(this.lblStatusGAU_Click);
            // 
            // ucSoMeDaCan1
            // 
            this.ucSoMeDaCan1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(124)))), ((int)(((byte)(3)))));
            this.ucSoMeDaCan1.Appearance.Options.UseBackColor = true;
            this.ucSoMeDaCan1.Location = new System.Drawing.Point(41, 127);
            this.ucSoMeDaCan1.Margin = new System.Windows.Forms.Padding(2);
            this.ucSoMeDaCan1.Name = "ucSoMeDaCan1";
            this.ucSoMeDaCan1.Size = new System.Drawing.Size(40, 18);
            this.ucSoMeDaCan1.SoLuongMeCanTron = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucSoMeDaCan1.SoLuongMeDaTron = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ucSoMeDaCan1.TabIndex = 590;
            this.ucSoMeDaCan1.TextColor = System.Drawing.Color.White;
            this.ucSoMeDaCan1.Click += new System.EventHandler(this.ucSoMeDaCan1_Click);
            // 
            // picPheu
            // 
            this.picPheu.BackgroundImage = global::NDPSo.ResourceNDP.Gau_Chua;
            this.picPheu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picPheu.Location = new System.Drawing.Point(25, 126);
            this.picPheu.Name = "picPheu";
            this.picPheu.Properties.AllowFocused = false;
            this.picPheu.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picPheu.Properties.Appearance.Options.UseBackColor = true;
            this.picPheu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picPheu.Properties.NullText = " ";
            this.picPheu.Properties.ReadOnly = true;
            this.picPheu.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picPheu.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picPheu.Size = new System.Drawing.Size(68, 42);
            this.picPheu.TabIndex = 4;
            this.picPheu.Click += new System.EventHandler(this.pictureEdit3_Click);
            // 
            // picThanhTruoc
            // 
            this.picThanhTruoc.BackgroundImage = global::NDPSo.ResourceNDP.ThanhTruoc_GauTai;
            this.picThanhTruoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picThanhTruoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picThanhTruoc.Location = new System.Drawing.Point(0, 0);
            this.picThanhTruoc.Name = "picThanhTruoc";
            this.picThanhTruoc.Properties.AllowFocused = false;
            this.picThanhTruoc.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picThanhTruoc.Properties.Appearance.Options.UseBackColor = true;
            this.picThanhTruoc.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picThanhTruoc.Properties.NullText = " ";
            this.picThanhTruoc.Properties.ReadOnly = true;
            this.picThanhTruoc.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picThanhTruoc.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picThanhTruoc.Size = new System.Drawing.Size(244, 262);
            this.picThanhTruoc.TabIndex = 1;
            this.picThanhTruoc.EditValueChanged += new System.EventHandler(this.pictureEdit2_EditValueChanged);
            // 
            // UcGauTai
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucSoMeDaCan1);
            this.Controls.Add(this.lblStatusGAU);
            this.Controls.Add(this.picPheu);
            this.Controls.Add(this.picThanhTruoc);
            this.Controls.Add(this.pictureEdit1);
            this.Name = "UcGauTai";
            this.Size = new System.Drawing.Size(244, 262);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPheu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picThanhTruoc.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.PictureEdit picThanhTruoc;
        private DevExpress.XtraEditors.PictureEdit picPheu;
        private DevExpress.XtraEditors.LabelControl lblStatusGAU;
        private UcSoMeDaCan ucSoMeDaCan1;
    }
}

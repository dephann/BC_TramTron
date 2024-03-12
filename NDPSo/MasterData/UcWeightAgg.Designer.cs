
namespace NDPSo.MasterData
{
    partial class UcWeightAgg
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picBackground
            // 
            this.picBackground.BackgroundImage = global::NDPSo.ResourceNDP.Weight;
            this.picBackground.Dock = System.Windows.Forms.DockStyle.None;
            this.picBackground.Location = new System.Drawing.Point(3, 37);
            this.picBackground.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picBackground.Properties.Appearance.Options.UseBackColor = true;
            this.picBackground.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picBackground.Size = new System.Drawing.Size(117, 68);
            // 
            // lblKhoiLuongCan
            // 
            this.lblKhoiLuongCan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKhoiLuongCan.Appearance.BackColor = System.Drawing.Color.White;
            this.lblKhoiLuongCan.Appearance.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhoiLuongCan.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblKhoiLuongCan.Appearance.Options.UseBackColor = true;
            this.lblKhoiLuongCan.Appearance.Options.UseFont = true;
            this.lblKhoiLuongCan.Appearance.Options.UseForeColor = true;
            this.lblKhoiLuongCan.Appearance.Options.UseTextOptions = true;
            this.lblKhoiLuongCan.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblKhoiLuongCan.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblKhoiLuongCan.Location = new System.Drawing.Point(3, 48);
            this.lblKhoiLuongCan.Size = new System.Drawing.Size(112, 31);
            this.lblKhoiLuongCan.Text = "";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(142, 31);
            this.panelControl1.TabIndex = 2;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImage = global::NDPSo.ResourceNDP.Led_F;
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureEdit1.Location = new System.Drawing.Point(3, 5);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.NullText = " ";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(131, 13);
            this.pictureEdit1.TabIndex = 0;
            // 
            // UcWeightAgg
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Name = "UcWeightAgg";
            this.Size = new System.Drawing.Size(155, 153);
            this.Controls.SetChildIndex(this.picBackground, 0);
            this.Controls.SetChildIndex(this.lblKhoiLuongCan, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}

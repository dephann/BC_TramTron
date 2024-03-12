
namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    public partial class UcWeightB
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
            this.picLebFull = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.picWeigh = new DevExpress.XtraEditors.PictureEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.picLebEmpty = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLebFull.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeigh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLebEmpty.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.picLebFull);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(100, 17);
            this.panelControl1.TabIndex = 0;
            // 
            // picLebFull
            // 
            this.picLebFull.BackgroundImage = global::NDPSo.ResourceNDP.Led_Fu;
            this.picLebFull.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLebFull.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.picLebFull.Location = new System.Drawing.Point(0, 11);
            this.picLebFull.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLebFull.Name = "picLebFull";
            this.picLebFull.Properties.AllowFocused = false;
            this.picLebFull.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picLebFull.Properties.Appearance.Options.UseBackColor = true;
            this.picLebFull.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLebFull.Properties.NullText = " ";
            this.picLebFull.Properties.ReadOnly = true;
            this.picLebFull.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picLebFull.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picLebFull.Size = new System.Drawing.Size(100, 6);
            this.picLebFull.TabIndex = 0;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.spinEdit1);
            this.panelControl2.Controls.Add(this.picWeigh);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 17);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(100, 73);
            this.panelControl2.TabIndex = 1;
            // 
            // spinEdit1
            // 
            this.spinEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(9, 5);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.AllowFocused = false;
            this.spinEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spinEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spinEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.spinEdit1.Properties.Appearance.Options.UseFont = true;
            this.spinEdit1.Properties.Appearance.Options.UseTextOptions = true;
            this.spinEdit1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.spinEdit1.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.spinEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.spinEdit1.Properties.DisplayFormat.FormatString = "n0";
            this.spinEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit1.Properties.EditFormat.FormatString = "n0";
            this.spinEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinEdit1.Properties.Mask.EditMask = "n0";
            this.spinEdit1.Properties.ReadOnly = true;
            this.spinEdit1.Size = new System.Drawing.Size(83, 32);
            this.spinEdit1.TabIndex = 1;
            this.spinEdit1.Click += new System.EventHandler(this.spinEdit1_Click);
            // 
            // picWeigh
            // 
            this.picWeigh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picWeigh.BackgroundImage = global::NDPSo.ResourceNDP.Weight;
            this.picWeigh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picWeigh.Location = new System.Drawing.Point(3, 2);
            this.picWeigh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picWeigh.Name = "picWeigh";
            this.picWeigh.Properties.AllowFocused = false;
            this.picWeigh.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picWeigh.Properties.Appearance.Options.UseBackColor = true;
            this.picWeigh.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picWeigh.Properties.NullText = " ";
            this.picWeigh.Properties.ReadOnly = true;
            this.picWeigh.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picWeigh.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picWeigh.Size = new System.Drawing.Size(94, 55);
            this.picWeigh.TabIndex = 0;
            this.picWeigh.Click += new System.EventHandler(this.picWeigh_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.picLebEmpty);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(0, 75);
            this.panelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(100, 15);
            this.panelControl3.TabIndex = 2;
            // 
            // picLebEmpty
            // 
            this.picLebEmpty.BackgroundImage = global::NDPSo.ResourceNDP.Led_Empty;
            this.picLebEmpty.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLebEmpty.Dock = System.Windows.Forms.DockStyle.Top;
            this.picLebEmpty.Location = new System.Drawing.Point(0, 0);
            this.picLebEmpty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLebEmpty.Name = "picLebEmpty";
            this.picLebEmpty.Properties.AllowFocused = false;
            this.picLebEmpty.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picLebEmpty.Properties.Appearance.Options.UseBackColor = true;
            this.picLebEmpty.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLebEmpty.Properties.NullText = " ";
            this.picLebEmpty.Properties.ReadOnly = true;
            this.picLebEmpty.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picLebEmpty.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picLebEmpty.Size = new System.Drawing.Size(100, 13);
            this.picLebEmpty.TabIndex = 0;
            // 
            // UcWeightB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UcWeightB";
            this.Size = new System.Drawing.Size(100, 90);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLebFull.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWeigh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLebEmpty.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit picLebFull;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        public DevExpress.XtraEditors.PictureEdit picWeigh;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PictureEdit picLebEmpty;
        public DevExpress.XtraEditors.SpinEdit spinEdit1;
    }
}

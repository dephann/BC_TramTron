
using DevExpress.Utils;
using NDPSo.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace NDPSo.MasterData
{
    partial class UcSiloAgg
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
            ((System.ComponentModel.ISupportInitialize)(this.picBackground.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn0.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // picBackground
            // 
            this.picBackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picBackground.EditValue = global::NDPSo.ResourceNDP.Tank_Green;
            this.picBackground.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picBackground.Properties.Appearance.Options.UseBackColor = true;
            this.picBackground.Properties.NullText = " ";
            this.picBackground.Properties.Padding = new System.Windows.Forms.Padding(3);
            this.picBackground.Properties.PictureAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.picBackground.Properties.ReadOnly = true;
            this.picBackground.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picBackground.Size = new System.Drawing.Size(94, 206);
            // 
            // lblCaption
            // 
            this.lblCaption.Appearance.BackColor = System.Drawing.Color.Green;
            this.lblCaption.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.Appearance.ForeColor = System.Drawing.SystemColors.Window;
            this.lblCaption.Appearance.Options.UseBackColor = true;
            this.lblCaption.Appearance.Options.UseFont = true;
            this.lblCaption.Appearance.Options.UseForeColor = true;
            this.lblCaption.Appearance.Options.UseTextOptions = true;
            this.lblCaption.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCaption.Location = new System.Drawing.Point(0, 186);
            this.lblCaption.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblCaption.Size = new System.Drawing.Size(94, 20);
            // 
            // lblDesc
            // 
            this.lblDesc.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblDesc.Appearance.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblDesc.Appearance.Options.UseBackColor = true;
            this.lblDesc.Appearance.Options.UseFont = true;
            this.lblDesc.Appearance.Options.UseForeColor = true;
            this.lblDesc.Appearance.Options.UseTextOptions = true;
            this.lblDesc.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblDesc.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Word;
            this.lblDesc.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblDesc.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblDesc.Size = new System.Drawing.Size(94, 38);
            // 
            // spn0
            // 
            this.spn0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.spn0.Location = new System.Drawing.Point(10, 60);
            this.spn0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spn0.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.spn0.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spn0.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spn0.Properties.Appearance.Options.UseBackColor = true;
            this.spn0.Properties.Appearance.Options.UseFont = true;
            this.spn0.Properties.Appearance.Options.UseForeColor = true;
            this.spn0.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.spn0.Properties.DisplayFormat.FormatString = "n2";
            this.spn0.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spn0.Properties.EditFormat.FormatString = "n2";
            this.spn0.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spn0.Properties.Mask.EditMask = "n2";
            this.spn0.Size = new System.Drawing.Size(76, 22);
            // 
            // spn1
            // 
            this.spn1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.spn1.Location = new System.Drawing.Point(10, 86);
            this.spn1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spn1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.spn1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spn1.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spn1.Properties.Appearance.Options.UseBackColor = true;
            this.spn1.Properties.Appearance.Options.UseFont = true;
            this.spn1.Properties.Appearance.Options.UseForeColor = true;
            this.spn1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.spn1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.spn1.Properties.DisplayFormat.FormatString = "n0";
            this.spn1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spn1.Properties.EditFormat.FormatString = "n0";
            this.spn1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spn1.Properties.Mask.EditMask = "n0";
            this.spn1.Size = new System.Drawing.Size(76, 22);
            // 
            // spn2
            // 
            this.spn2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.spn2.Location = new System.Drawing.Point(10, 112);
            this.spn2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spn2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.spn2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spn2.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spn2.Properties.Appearance.Options.UseBackColor = true;
            this.spn2.Properties.Appearance.Options.UseFont = true;
            this.spn2.Properties.Appearance.Options.UseForeColor = true;
            this.spn2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.spn2.Properties.DisplayFormat.FormatString = "n0";
            this.spn2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spn2.Properties.EditFormat.FormatString = "n0";
            this.spn2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spn2.Properties.Mask.EditMask = "n0";
            this.spn2.Size = new System.Drawing.Size(76, 22);
            // 
            // spn3
            // 
            this.spn3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.spn3.Location = new System.Drawing.Point(10, 138);
            this.spn3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spn3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.spn3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spn3.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.spn3.Properties.Appearance.Options.UseBackColor = true;
            this.spn3.Properties.Appearance.Options.UseFont = true;
            this.spn3.Properties.Appearance.Options.UseForeColor = true;
            this.spn3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.spn3.Properties.DisplayFormat.FormatString = "n0";
            this.spn3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spn3.Properties.EditFormat.FormatString = "n0";
            this.spn3.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spn3.Properties.Mask.EditMask = "n0";
            this.spn3.Size = new System.Drawing.Size(76, 22);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(0, 38);
            this.labelControl1.Size = new System.Drawing.Size(94, 15);
            this.labelControl1.Visible = false;
            // 
            // UcSiloAgg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UcSiloAgg";
            this.Size = new System.Drawing.Size(94, 206);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UcSiloAgg_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UcSiloAgg_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.picBackground.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn0.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spn3.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}

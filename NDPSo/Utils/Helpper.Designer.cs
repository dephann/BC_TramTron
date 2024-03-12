
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using System.ComponentModel;
using System.Drawing.Printing;

namespace NDPSo.Utils
{
    partial class Helpper
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.printingSystem = new PrintingSystem();
            this.printableComponentLink = new PrintableComponentLink();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem)).BeginInit();
            this.printableComponentLink.ImageCollection.BeginInit();
            this.SuspendLayout();
            this.printingSystem.Links.AddRange(new object[1]
      {
        (object) this.printableComponentLink
      });
            this.printableComponentLink.PaperKind = PaperKind.A4;
            this.printableComponentLink.PrintingSystem = this.printingSystem;
            this.printableComponentLink.PrintingSystemBase = (PrintingSystemBase)this.printingSystem;

            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Helpper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 692);
            this.Name = "Helpper";
            this.Text = "Helpper";

            ((ISupportInitialize)this.printingSystem).EndInit();
            this.printableComponentLink.ImageCollection.EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private PrintingSystem printingSystem;
        protected PrintableComponentLink printableComponentLink;

        private System.Windows.Forms.PrintDialog printDialog1;
        private object componentResourceManager;
    }
}
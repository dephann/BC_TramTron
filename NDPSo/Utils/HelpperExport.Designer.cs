
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using System.ComponentModel;
using System.Drawing.Printing;

namespace NDPSo.Utils
{
    partial class HelpperExport
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
            this.components = (IContainer)new System.ComponentModel.Container();
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(HelpperExport));
            this.printingSystem = new PrintingSystem(this.components);
            this.printableComponentLink = new PrintableComponentLink(this.components);
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((ISupportInitialize)this.printingSystem).BeginInit();
            this.printableComponentLink.ImageCollection.BeginInit();
            this.SuspendLayout();
            // 
            // printDialog1
            // 
            this.printingSystem.Links.AddRange(new object[1]
          {
            (object) this.printableComponentLink
          });
            this.printableComponentLink.ImageCollection.ImageStream = (ImageCollectionStreamer)componentResourceManager.GetObject("printableComponentLink.ImageCollection.ImageStream");
            this.printableComponentLink.PaperKind = PaperKind.A4;
            this.printableComponentLink.PrintingSystem = this.printingSystem;
            this.printableComponentLink.PrintingSystemBase = (PrintingSystemBase)this.printingSystem;
            this.printDialog1.UseEXDialog = true;
            // 
            // HelpperExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 692);
            this.Name = "HelpperExport";
            this.Text = "HelpperExport";
            ((ISupportInitialize)this.printingSystem).EndInit();
            this.printableComponentLink.ImageCollection.EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private PrintingSystem printingSystem;
        protected PrintableComponentLink printableComponentLink;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}
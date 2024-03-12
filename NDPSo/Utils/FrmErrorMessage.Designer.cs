
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using NDPSo.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NDPSo.Utils
{
    partial class FrmErrorMessage
    {
        private PictureEdit picIcon;
        private SimpleButton btnOk;
        private PanelControl panelControl1;
        private PanelControl panelControl2;
        private PanelControl pnlException;
        private LabelControl lblErrorMessage;
        private MemoEdit memException;
        private PictureEdit picDown;

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
            this.SuspendLayout();
            // 
            // FrmErrorMessage
            // 
            this.ClientSize = new System.Drawing.Size(346, 260);
            this.Name = "FrmErrorMessage";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
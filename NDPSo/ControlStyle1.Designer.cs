
using DevExpress.XtraEditors;
using System.Drawing;
using System.Windows.Forms;

namespace NDPSo
{
    partial class ControlStyle1
    {
        protected GroupControl groupControl1;
        protected GroupControl groupControl2;
        protected GroupControl grpCommand;
        protected GroupControl grpStatus;
        
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        
        private void InitializeComponent()
        {
            this.groupControl1 = new GroupControl();
            this.groupControl2 = new GroupControl();
            this.grpCommand = new GroupControl();
            this.grpStatus = new GroupControl();
            this.groupControl1.BeginInit();
            this.groupControl2.BeginInit();
            this.grpCommand.BeginInit();
            this.grpStatus.BeginInit();
            this.SuspendLayout();
            this.groupControl1.Dock = DockStyle.Top;
            this.groupControl1.Location = new Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new Size(700, 100);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "grpMaster";
            this.groupControl2.Dock = DockStyle.Fill;
            this.groupControl2.Location = new Point(0, 100);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new Size(700, 326);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "grpDetails";
            this.grpCommand.Dock = DockStyle.Bottom;
            this.grpCommand.Location = new Point(0, 426);
            this.grpCommand.Name = "grpCommand";
            this.grpCommand.ShowCaption = false;
            this.grpCommand.Size = new Size(700, 47);
            this.grpCommand.TabIndex = 2;
            this.grpCommand.Text = "grpCommand";
            this.grpStatus.Dock = DockStyle.Bottom;
            this.grpStatus.Location = new Point(0, 473);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.ShowCaption = false;
            this.grpStatus.Size = new Size(700, 27);
            this.grpStatus.TabIndex = 3;
            this.grpStatus.Text = "groupControl3";
            this.grpStatus.Visible = false;
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add((Control)this.groupControl2);
            this.Controls.Add((Control)this.grpCommand);
            this.Controls.Add((Control)this.groupControl1);
            this.Controls.Add((Control)this.grpStatus);
            this.Name = nameof(ControlStyle1);
            this.Size = new Size(700, 500);
            this.groupControl1.EndInit();
            this.groupControl2.EndInit();
            this.grpCommand.EndInit();
            this.grpStatus.EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}

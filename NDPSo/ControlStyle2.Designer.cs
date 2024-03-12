
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NDPSo
{
    partial class ControlStyle2
    {
        private BarManager barManager1;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        protected GroupControl grpSearch;
        protected SplitContainerControl splitContainerControl1;
        protected GroupControl grpStatus;
        protected GroupControl grpMaster;
        protected GroupControl grpDetail;

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
            this.components = (IContainer)new System.ComponentModel.Container();
            this.barManager1 = new BarManager(this.components);
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.grpSearch = new GroupControl();
            this.splitContainerControl1 = new SplitContainerControl();
            this.grpMaster = new GroupControl();
            this.grpDetail = new GroupControl();
            this.grpStatus = new GroupControl();
            this.barManager1.BeginInit();
            this.grpSearch.BeginInit();
            this.splitContainerControl1.BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.grpMaster.BeginInit();
            this.grpDetail.BeginInit();
            this.grpStatus.BeginInit();
            this.SuspendLayout();
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = (Control)this;
            this.barManager1.MaxItemId = 0;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = DockStyle.Top;
            this.barDockControlTop.Location = new Point(0, 0);
            this.barDockControlTop.Size = new Size(700, 0);
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = DockStyle.Bottom;
            this.barDockControlBottom.Location = new Point(0, 500);
            this.barDockControlBottom.Size = new Size(700, 0);
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = DockStyle.Left;
            this.barDockControlLeft.Location = new Point(0, 0);
            this.barDockControlLeft.Size = new Size(0, 500);
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = DockStyle.Right;
            this.barDockControlRight.Location = new Point(700, 0);
            this.barDockControlRight.Size = new Size(0, 500);
            this.grpSearch.Dock = DockStyle.Top;
            this.grpSearch.Location = new Point(0, 0);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new Size(700, 100);
            this.grpSearch.TabIndex = 4;
            this.grpSearch.Text = "Search";
            this.splitContainerControl1.Dock = DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new Point(0, 100);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add((Control)this.grpMaster);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add((Control)this.grpDetail);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new Size(700, 373);
            this.splitContainerControl1.SplitterPosition = 122;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl1";
            this.grpMaster.Dock = DockStyle.Fill;
            this.grpMaster.Location = new Point(0, 0);
            this.grpMaster.Name = "grpMaster";
            this.grpMaster.Size = new Size(700, 122);
            this.grpMaster.TabIndex = 5;
            this.grpMaster.Text = "Master Infos";
            this.grpDetail.Dock = DockStyle.Fill;
            this.grpDetail.Location = new Point(0, 0);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new Size(700, 246);
            this.grpDetail.TabIndex = 5;
            this.grpDetail.Text = "Detail Infos";
            this.grpStatus.Dock = DockStyle.Bottom;
            this.grpStatus.Location = new Point(0, 473);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.ShowCaption = false;
            this.grpStatus.Size = new Size(700, 27);
            this.grpStatus.TabIndex = 5;
            this.grpStatus.Text = "groupControl2";
            this.AutoScaleDimensions = new SizeF(6f, 13f);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add((Control)this.splitContainerControl1);
            this.Controls.Add((Control)this.grpStatus);
            this.Controls.Add((Control)this.grpSearch);
            this.Controls.Add((Control)this.barDockControlLeft);
            this.Controls.Add((Control)this.barDockControlRight);
            this.Controls.Add((Control)this.barDockControlBottom);
            this.Controls.Add((Control)this.barDockControlTop);
            this.Name = nameof(ControlStyle2);
            this.Size = new Size(700, 500);
            this.barManager1.EndInit();
            this.grpSearch.EndInit();
            this.splitContainerControl1.EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.grpMaster.EndInit();
            this.grpDetail.EndInit();
            this.grpStatus.EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}

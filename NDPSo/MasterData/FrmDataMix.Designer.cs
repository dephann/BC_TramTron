
namespace NDPSo.MasterData
{
    partial class FrmDataMix
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grcDataMix = new DevExpress.XtraGrid.GridControl();
            this.grvDataMix = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMaPhieuTron = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCongTruong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTaiXe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMAC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcKLMe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAgg1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtMaPT = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.datToDate = new DevExpress.XtraEditors.DateEdit();
            this.datFromData = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcDataMix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDataMix)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPT.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromData.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromData.Properties)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grcDataMix);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(3, 82);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(878, 530);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Dữ liệu";
            // 
            // grcDataMix
            // 
            this.grcDataMix.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcDataMix.Location = new System.Drawing.Point(2, 23);
            this.grcDataMix.MainView = this.grvDataMix;
            this.grcDataMix.Name = "grcDataMix";
            this.grcDataMix.Size = new System.Drawing.Size(874, 505);
            this.grcDataMix.TabIndex = 0;
            this.grcDataMix.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDataMix});
            // 
            // grvDataMix
            // 
            this.grvDataMix.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMaPhieuTron,
            this.gcDate,
            this.gcTime,
            this.gcKhachHang,
            this.gcCongTruong,
            this.gcTaiXe,
            this.gcMAC,
            this.gcKLMe,
            this.gcAgg1,
            this.gridColumn5});
            this.grvDataMix.GridControl = this.grcDataMix;
            this.grvDataMix.Name = "grvDataMix";
            this.grvDataMix.OptionsView.ShowFooter = true;
            // 
            // gcMaPhieuTron
            // 
            this.gcMaPhieuTron.Caption = "Mã Phiếu trộn";
            this.gcMaPhieuTron.FieldName = "MaPhieuTron";
            this.gcMaPhieuTron.Name = "gcMaPhieuTron";
            this.gcMaPhieuTron.Visible = true;
            this.gcMaPhieuTron.VisibleIndex = 0;
            // 
            // gcDate
            // 
            this.gcDate.Caption = "Ngày trộn";
            this.gcDate.FieldName = "Ngay";
            this.gcDate.Name = "gcDate";
            this.gcDate.Visible = true;
            this.gcDate.VisibleIndex = 1;
            // 
            // gcTime
            // 
            this.gcTime.Caption = "Giờ";
            this.gcTime.FieldName = "Gio";
            this.gcTime.Name = "gcTime";
            this.gcTime.Visible = true;
            this.gcTime.VisibleIndex = 2;
            // 
            // gcKhachHang
            // 
            this.gcKhachHang.Caption = "Khách hàng";
            this.gcKhachHang.FieldName = "KH";
            this.gcKhachHang.Name = "gcKhachHang";
            this.gcKhachHang.Visible = true;
            this.gcKhachHang.VisibleIndex = 3;
            // 
            // gcCongTruong
            // 
            this.gcCongTruong.Caption = "Công trường";
            this.gcCongTruong.FieldName = "CT";
            this.gcCongTruong.Name = "gcCongTruong";
            this.gcCongTruong.Visible = true;
            this.gcCongTruong.VisibleIndex = 4;
            // 
            // gcTaiXe
            // 
            this.gcTaiXe.Caption = "Tài xế";
            this.gcTaiXe.FieldName = "Name";
            this.gcTaiXe.Name = "gcTaiXe";
            this.gcTaiXe.Visible = true;
            this.gcTaiXe.VisibleIndex = 5;
            // 
            // gcMAC
            // 
            this.gcMAC.Caption = "MAC";
            this.gcMAC.FieldName = "MAC";
            this.gcMAC.Name = "gcMAC";
            this.gcMAC.Visible = true;
            this.gcMAC.VisibleIndex = 6;
            // 
            // gcKLMe
            // 
            this.gcKLMe.Caption = "KL Mẻ";
            this.gcKLMe.FieldName = "KLMe";
            this.gcKLMe.Name = "gcKLMe";
            this.gcKLMe.Visible = true;
            this.gcKLMe.VisibleIndex = 7;
            // 
            // gcAgg1
            // 
            this.gcAgg1.Caption = "Agg 1";
            this.gcAgg1.FieldName = "Agg1";
            this.gcAgg1.Name = "gcAgg1";
            this.gcAgg1.Visible = true;
            this.gcAgg1.VisibleIndex = 8;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "gridColumn5";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.simpleButton1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 615);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lựa chọn";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(61, 361);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(112, 32);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Tìm kiếm";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMaPT);
            this.groupBox3.Controls.Add(this.labelControl3);
            this.groupBox3.Location = new System.Drawing.Point(19, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(228, 182);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bộ lọc";
            // 
            // txtMaPT
            // 
            this.txtMaPT.Location = new System.Drawing.Point(107, 30);
            this.txtMaPT.Name = "txtMaPT";
            this.txtMaPT.Size = new System.Drawing.Size(115, 20);
            this.txtMaPT.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(22, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(66, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Mã phiếu trộn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.datToDate);
            this.groupBox2.Controls.Add(this.datFromData);
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.labelControl1);
            this.groupBox2.Location = new System.Drawing.Point(19, 34);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 88);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Khoảng thời gian";
            // 
            // datToDate
            // 
            this.datToDate.EditValue = null;
            this.datToDate.Location = new System.Drawing.Point(62, 54);
            this.datToDate.Name = "datToDate";
            this.datToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datToDate.Size = new System.Drawing.Size(160, 20);
            this.datToDate.TabIndex = 3;
            // 
            // datFromData
            // 
            this.datFromData.EditValue = null;
            this.datFromData.Location = new System.Drawing.Point(62, 22);
            this.datFromData.Name = "datFromData";
            this.datFromData.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFromData.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.datFromData.Size = new System.Drawing.Size(160, 20);
            this.datFromData.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(20, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Đến";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(13, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Từ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panelControl1);
            this.groupBox4.Controls.Add(this.groupControl1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(253, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(884, 615);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(3, 17);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(878, 59);
            this.panelControl1.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl4.Location = new System.Drawing.Point(158, 10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(532, 45);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "BÁO CÁO CHI TIẾT MẺ TRỘN";
            // 
            // FrmDataMix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 615);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmDataMix";
            this.Text = "FrmDataMix";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcDataMix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDataMix)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPT.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromData.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datFromData.Properties)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl grcDataMix;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDataMix;
        private DevExpress.XtraGrid.Columns.GridColumn gcMaPhieuTron;
        private DevExpress.XtraGrid.Columns.GridColumn gcDate;
        private DevExpress.XtraGrid.Columns.GridColumn gcTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn gcCongTruong;
        private DevExpress.XtraGrid.Columns.GridColumn gcTaiXe;
        private DevExpress.XtraGrid.Columns.GridColumn gcMAC;
        private DevExpress.XtraGrid.Columns.GridColumn gcKLMe;
        private DevExpress.XtraGrid.Columns.GridColumn gcAgg1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevExpress.XtraEditors.TextEdit txtMaPT;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.DateEdit datToDate;
        private DevExpress.XtraEditors.DateEdit datFromData;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}
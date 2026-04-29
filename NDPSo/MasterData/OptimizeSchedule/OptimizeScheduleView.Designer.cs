
namespace NDPSo.MasterData
{
    partial class OptimizeScheduleView
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlFilter = new DevExpress.XtraEditors.GroupControl();
            this.pnlGrid = new DevExpress.XtraEditors.GroupControl();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.datTuNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblToDate = new DevExpress.XtraEditors.LabelControl();
            this.datDenNgay = new DevExpress.XtraEditors.DateEdit();
            this.lblMAC = new DevExpress.XtraEditors.LabelControl();
            this.lueMACFilter = new DevExpress.XtraEditors.LookUpEdit();
            this.lblStartTime = new DevExpress.XtraEditors.LabelControl();
            this.datStartTime = new DevExpress.XtraEditors.DateEdit();
            this.lblMinPerBatch = new DevExpress.XtraEditors.LabelControl();
            this.spnMinutesPerBatch = new DevExpress.XtraEditors.SpinEdit();
            this.lblSwitchCost = new DevExpress.XtraEditors.LabelControl();
            this.spnSwitchCost = new DevExpress.XtraEditors.SpinEdit();
            this.btnLoadOrders = new DevExpress.XtraEditors.SimpleButton();
            this.btnOptimize = new DevExpress.XtraEditors.SimpleButton();
            this.btnPriority = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.lblPendingCount = new DevExpress.XtraEditors.LabelControl();
            this.grcSchedule = new DevExpress.XtraGrid.GridControl();
            this.grvSchedule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMaPhieuTron = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTenKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTenHangMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTenMAC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSLMeDuTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcKLDuTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDuration = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSwitchBefore = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSwitchCostMinutes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcThoiGianGiaoHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCriticalRatio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTienDo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSummary = new DevExpress.XtraEditors.LabelControl();
            this.lblClock = new DevExpress.XtraEditors.LabelControl();

            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).BeginInit();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMACFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datStartTime.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnMinutesPerBatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnSwitchCost.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grcSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSchedule)).BeginInit();
            this.SuspendLayout();

            // pnlFilter - panel lọc bên trái
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFilter.Size = new System.Drawing.Size(265, 560);
            this.pnlFilter.Text = "Tham số";
            this.pnlFilter.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.pnlFilter.AppearanceCaption.Options.UseFont = true;

            int y = 30, labelX = 8, ctrlX = 8, ctrlW = 245, rowH = 32;

            this.lblFromDate.Text = "Từ ngày:";
            this.lblFromDate.Location = new System.Drawing.Point(labelX, y);
            this.lblFromDate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            y += 18;
            this.datTuNgay.Location = new System.Drawing.Point(ctrlX, y);
            this.datTuNgay.Size = new System.Drawing.Size(ctrlW, 22);
            this.datTuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datTuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datTuNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datTuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            y += rowH;

            this.lblToDate.Text = "Đến ngày:";
            this.lblToDate.Location = new System.Drawing.Point(labelX, y);
            this.lblToDate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            y += 18;
            this.datDenNgay.Location = new System.Drawing.Point(ctrlX, y);
            this.datDenNgay.Size = new System.Drawing.Size(ctrlW, 22);
            this.datDenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.datDenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datDenNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.datDenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            y += rowH;

            this.lblMAC.Text = "Máy trộn (MAC):";
            this.lblMAC.Location = new System.Drawing.Point(labelX, y);
            this.lblMAC.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            y += 18;
            this.lueMACFilter.Location = new System.Drawing.Point(ctrlX, y);
            this.lueMACFilter.Size = new System.Drawing.Size(ctrlW, 22);
            this.lueMACFilter.Properties.NullText = "(Tất cả)";
            y += rowH + 8;

            this.lblStartTime.Text = "Giờ bắt đầu sản xuất:";
            this.lblStartTime.Location = new System.Drawing.Point(labelX, y);
            this.lblStartTime.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            y += 18;
            this.datStartTime.Location = new System.Drawing.Point(ctrlX, y);
            this.datStartTime.Size = new System.Drawing.Size(ctrlW, 22);
            this.datStartTime.Properties.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.datStartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datStartTime.Properties.EditFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.datStartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.datStartTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTime;
            this.datStartTime.Properties.Mask.EditMask = "dd/MM/yyyy HH:mm";
            y += rowH + 8;

            this.lblMinPerBatch.Text = "Phút/mẻ trộn:";
            this.lblMinPerBatch.Location = new System.Drawing.Point(labelX, y);
            this.lblMinPerBatch.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            y += 18;
            this.spnMinutesPerBatch.Location = new System.Drawing.Point(ctrlX, y);
            this.spnMinutesPerBatch.Size = new System.Drawing.Size(ctrlW, 22);
            this.spnMinutesPerBatch.Properties.MinValue = 1;
            this.spnMinutesPerBatch.Properties.MaxValue = 60;
            this.spnMinutesPerBatch.EditValue = 5;
            y += rowH;

            this.lblSwitchCost.Text = "Phút vệ sinh khi đổi loại BT:";
            this.lblSwitchCost.Location = new System.Drawing.Point(labelX, y);
            this.lblSwitchCost.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            y += 18;
            this.spnSwitchCost.Location = new System.Drawing.Point(ctrlX, y);
            this.spnSwitchCost.Size = new System.Drawing.Size(ctrlW, 22);
            this.spnSwitchCost.Properties.MinValue = 0;
            this.spnSwitchCost.Properties.MaxValue = 120;
            this.spnSwitchCost.EditValue = 15;
            y += rowH + 12;

            this.btnLoadOrders.Text = "Tải phiếu chờ";
            this.btnLoadOrders.Location = new System.Drawing.Point(ctrlX, y);
            this.btnLoadOrders.Size = new System.Drawing.Size(ctrlW, 32);
            this.btnLoadOrders.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnLoadOrders.Click += new System.EventHandler(this.btnLoadOrders_Click);
            y += 40;

            this.btnOptimize.Text = "▶ Tối Ưu Hóa (Greedy)";
            this.btnOptimize.Location = new System.Drawing.Point(ctrlX, y);
            this.btnOptimize.Size = new System.Drawing.Size(ctrlW, 36);
            this.btnOptimize.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnOptimize.Appearance.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnOptimize.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOptimize.Appearance.Options.UseBackColor = true;
            this.btnOptimize.Appearance.Options.UseForeColor = true;
            this.btnOptimize.Click += new System.EventHandler(this.btnOptimize_Click);
            y += 44;

            this.btnPriority.Text = "⚡ Ưu Tiên Theo Giờ Giao";
            this.btnPriority.Location = new System.Drawing.Point(ctrlX, y);
            this.btnPriority.Size = new System.Drawing.Size(ctrlW, 36);
            this.btnPriority.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPriority.Appearance.BackColor = System.Drawing.Color.FromArgb(180, 95, 6);
            this.btnPriority.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPriority.Appearance.Options.UseBackColor = true;
            this.btnPriority.Appearance.Options.UseForeColor = true;
            this.btnPriority.Click += new System.EventHandler(this.btnPriority_Click);
            y += 44;

            this.btnReset.Text = "Làm mới";
            this.btnReset.Location = new System.Drawing.Point(ctrlX, y);
            this.btnReset.Size = new System.Drawing.Size(ctrlW, 32);
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            y += 44;

            this.lblPendingCount.Text = "Tổng phiếu chờ: 0";
            this.lblPendingCount.Location = new System.Drawing.Point(labelX, y);
            this.lblPendingCount.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic);

            this.pnlFilter.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblFromDate, this.datTuNgay,
                this.lblToDate, this.datDenNgay,
                this.lblMAC, this.lueMACFilter,
                this.lblStartTime, this.datStartTime,
                this.lblMinPerBatch, this.spnMinutesPerBatch,
                this.lblSwitchCost, this.spnSwitchCost,
                this.btnLoadOrders, this.btnOptimize, this.btnPriority, this.btnReset,
                this.lblPendingCount
            });

            // lblClock - hiển thị giờ thực + trạng thái live
            this.lblClock.Text = string.Empty;
            this.lblClock.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblClock.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblClock.Appearance.ForeColor = System.Drawing.Color.FromArgb(0, 140, 0);
            this.lblClock.Padding = new System.Windows.Forms.Padding(4);

            // lblSummary - footer của pnlGrid
            this.lblSummary.Text = string.Empty;
            this.lblSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblSummary.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSummary.Appearance.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblSummary.Padding = new System.Windows.Forms.Padding(4);

            // grvSchedule
            this.grvSchedule.GridControl = this.grcSchedule;
            this.grvSchedule.Name = "grvSchedule";
            this.grvSchedule.OptionsBehavior.Editable = false;
            this.grvSchedule.OptionsView.ShowGroupPanel = false;
            this.grvSchedule.OptionsView.EnableAppearanceEvenRow = true;
            this.grvSchedule.OptionsView.EnableAppearanceOddRow = true;
            this.grvSchedule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                this.gcOrder, this.gcTienDo, this.gcMaPhieuTron, this.gcTenKhachHang,
                this.gcTenHangMuc, this.gcTenMAC,
                this.gcSLMeDuTinh, this.gcKLDuTinh,
                this.gcDuration, this.gcStartTime, this.gcEndTime,
                this.gcThoiGianGiaoHang, this.gcCriticalRatio, this.gcTrangThai,
                this.gcSwitchBefore, this.gcSwitchCostMinutes
            });

            // Columns
            SetCol(this.gcOrder, "ScheduleOrder", "STT", 0, 45);
            SetCol(this.gcTienDo, "TienDo", "Tiến Độ", 1, 100);
            SetCol(this.gcMaPhieuTron, "MaHopDong", "Mã Hợp Đồng", 2, 120);
            SetCol(this.gcTenKhachHang, "TenKhachHang", "Khách Hàng", 3, 160);
            SetCol(this.gcTenHangMuc, "TenHangMuc", "Loại Bê Tông", 4, 120);
            SetCol(this.gcTenMAC, "TenMAC", "Máy Trộn", 5, 100);
            SetCol(this.gcSLMeDuTinh, "SLMeDuTinh", "Số Mẻ", 6, 60);
            SetCol(this.gcKLDuTinh, "KLDuTinh", "KL Dự Tính (kg)", 7, 110);
            SetCol(this.gcDuration, "EstimatedDurationMinutes", "Thời Gian (phút)", 8, 110);
            SetCol(this.gcStartTime, "EstimatedStartTime", "Giờ Bắt Đầu", 9, 130);
            SetCol(this.gcEndTime, "EstimatedEndTime", "Giờ Kết Thúc", 10, 130);
            SetCol(this.gcThoiGianGiaoHang, "ThoiGianGiaoHang", "Giờ Giao Hàng", 11, 130);
            SetCol(this.gcCriticalRatio, "CriticalRatio", "CR", 12, 60);
            SetCol(this.gcTrangThai, "TrangThaiThoiGian", "Trạng Thái Giao", 13, 100);
            SetCol(this.gcSwitchBefore, "HasSwitchBefore", "Cần Vệ Sinh Máy", 14, 110);
            SetCol(this.gcSwitchCostMinutes, "SwitchCostMinutes", "TG Vệ Sinh (phút)", 15, 110);

            this.gcStartTime.DisplayFormat.FormatString = "HH:mm dd/MM";
            this.gcStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcEndTime.DisplayFormat.FormatString = "HH:mm dd/MM";
            this.gcEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcThoiGianGiaoHang.DisplayFormat.FormatString = "HH:mm dd/MM";
            this.gcThoiGianGiaoHang.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcKLDuTinh.DisplayFormat.FormatString = "N0";
            this.gcKLDuTinh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gcCriticalRatio.DisplayFormat.FormatString = "N2";
            this.gcCriticalRatio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;

            // grcSchedule
            this.grcSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcSchedule.MainView = this.grvSchedule;
            this.grcSchedule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.grvSchedule });

            // pnlGrid
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Text = "Lịch Trình Sản Xuất Tối Ưu";
            this.pnlGrid.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.pnlGrid.AppearanceCaption.Options.UseFont = true;
            this.pnlGrid.Controls.Add(this.grcSchedule);
            this.pnlGrid.Controls.Add(this.lblClock);
            this.pnlGrid.Controls.Add(this.lblSummary);

            // pnlMain
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlFilter);

            // OptimizeScheduleView
            this.Controls.Add(this.pnlMain);
            this.Size = new System.Drawing.Size(1060, 600);
            this.Name = "OptimizeScheduleView";

            ((System.ComponentModel.ISupportInitialize)(this.pnlFilter)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datTuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datDenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueMACFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datStartTime.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnMinutesPerBatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spnSwitchCost.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlGrid)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grcSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSchedule)).EndInit();
            this.ResumeLayout(false);
        }

        private static void SetCol(DevExpress.XtraGrid.Columns.GridColumn col,
            string fieldName, string caption, int visIdx, int width)
        {
            col.FieldName = fieldName;
            col.Caption = caption;
            col.Width = width;
            col.VisibleIndex = visIdx;
            col.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            col.AppearanceHeader.Options.UseFont = true;
        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private DevExpress.XtraEditors.GroupControl pnlFilter;
        private DevExpress.XtraEditors.GroupControl pnlGrid;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
        private DevExpress.XtraEditors.DateEdit datTuNgay;
        private DevExpress.XtraEditors.LabelControl lblToDate;
        private DevExpress.XtraEditors.DateEdit datDenNgay;
        private DevExpress.XtraEditors.LabelControl lblMAC;
        private DevExpress.XtraEditors.LookUpEdit lueMACFilter;
        private DevExpress.XtraEditors.LabelControl lblStartTime;
        private DevExpress.XtraEditors.DateEdit datStartTime;
        private DevExpress.XtraEditors.LabelControl lblMinPerBatch;
        private DevExpress.XtraEditors.SpinEdit spnMinutesPerBatch;
        private DevExpress.XtraEditors.LabelControl lblSwitchCost;
        private DevExpress.XtraEditors.SpinEdit spnSwitchCost;
        private DevExpress.XtraEditors.SimpleButton btnLoadOrders;
        private DevExpress.XtraEditors.SimpleButton btnOptimize;
        private DevExpress.XtraEditors.SimpleButton btnPriority;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.XtraEditors.LabelControl lblPendingCount;
        private DevExpress.XtraGrid.GridControl grcSchedule;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSchedule;
        private DevExpress.XtraGrid.Columns.GridColumn gcOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gcMaPhieuTron;
        private DevExpress.XtraGrid.Columns.GridColumn gcTenKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn gcTenHangMuc;
        private DevExpress.XtraGrid.Columns.GridColumn gcTenMAC;
        private DevExpress.XtraGrid.Columns.GridColumn gcSLMeDuTinh;
        private DevExpress.XtraGrid.Columns.GridColumn gcKLDuTinh;
        private DevExpress.XtraGrid.Columns.GridColumn gcDuration;
        private DevExpress.XtraGrid.Columns.GridColumn gcStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcSwitchBefore;
        private DevExpress.XtraGrid.Columns.GridColumn gcSwitchCostMinutes;
        private DevExpress.XtraGrid.Columns.GridColumn gcThoiGianGiaoHang;
        private DevExpress.XtraGrid.Columns.GridColumn gcCriticalRatio;
        private DevExpress.XtraGrid.Columns.GridColumn gcTrangThai;
        private DevExpress.XtraGrid.Columns.GridColumn gcTienDo;
        private DevExpress.XtraEditors.LabelControl lblSummary;
        private DevExpress.XtraEditors.LabelControl lblClock;
    }
}

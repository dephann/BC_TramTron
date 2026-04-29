using DevExpress.XtraGrid.Views.Grid;
using NDPSo.BusinessObject;
using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NDPSo.MasterData
{
    public partial class OptimizeScheduleView : ControlViewBase, IOptimizeScheduleView, IBase
    {
        private OptimizeSchedulePresenter _presenter;
        private List<ObjScheduleItem> _lstScheduleItems = new List<ObjScheduleItem>();
        private List<ObjDuLieuTron> _lstPendingDuLieuTron = new List<ObjDuLieuTron>();

        // Timer cập nhật thời gian thực mỗi 30 giây
        private readonly System.Windows.Forms.Timer _liveTimer = new System.Windows.Forms.Timer { Interval = 30_000 };

        public OptimizeScheduleView()
        {
            InitializeComponent();
            _presenter = new OptimizeSchedulePresenter(this);
            this.Caption = "Lịch Trình Sản Xuất Tối Ưu";
            _liveTimer.Tick += OnLiveTimerTick;
        }

        public OptimizeScheduleView(DateTime filterDate) : this()
        {
            this.datTuNgay.EditValue = filterDate.Date;
            this.datDenNgay.EditValue = filterDate.Date;
        }

        #region IOptimizeScheduleView

        public List<ObjScheduleItem> LstScheduleItems
        {
            set
            {
                _lstScheduleItems = value ?? new List<ObjScheduleItem>();
                this.grcSchedule.DataSource = _lstScheduleItems;
                UpdateSummary();
                UpdateClock();
                ScrollToCurrentItem();
                _liveTimer.Start();
            }
        }

        public List<ObjDuLieuTron> LstPendingDuLieuTron
        {
            set
            {
                _lstPendingDuLieuTron = value ?? new List<ObjDuLieuTron>();
                this.lblPendingCount.Text = $"Tổng phiếu chờ: {_lstPendingDuLieuTron.Count}";
            }
        }

        public List<ObjMAC> LstMAC
        {
            set
            {
                this.lueMACFilter.Properties.DataSource = value;
                this.lueMACFilter.Properties.DisplayMember = "TenMAC";
                this.lueMACFilter.Properties.ValueMember = "MACID";
                this.lueMACFilter.Properties.NullText = "(Tất cả)";
            }
        }

        #endregion

        protected override void PopulateStaticData()
        {
            _presenter.LoadMAC();
            this.datTuNgay.EditValue = DateTime.Now.Date;
            this.datDenNgay.EditValue = DateTime.Now.Date;
            this.datStartTime.EditValue = DateTime.Now;
            this.spnMinutesPerBatch.EditValue = 5;
            this.spnSwitchCost.EditValue = 15;
        }

        protected override void PopulateData()
        {
            LoadOrders();
        }

        private void LoadOrders()
        {
            DateTime fromDate = this.datTuNgay.DateTime.Date;
            DateTime toDate = this.datDenNgay.DateTime.Date.AddDays(1).AddSeconds(-1);
            int? macID = this.lueMACFilter.EditValue as int?;
            _presenter.LoadPendingOrders(fromDate, toDate, macID);
        }

        // true = đang ở chế độ ưu tiên CR, false = Greedy bình thường
        private bool _isPriorityMode = false;

        private void OnLiveTimerTick(object sender, EventArgs e)
        {
            if (_lstScheduleItems == null || _lstScheduleItems.Count == 0) return;
            // Tất cả đã xong → dừng timer
            if (_lstScheduleItems.TrueForAll(s => s.IsDone))
            {
                _liveTimer.Stop();
                UpdateClock();
                this.grcSchedule.RefreshDataSource();
                return;
            }
            this.grcSchedule.RefreshDataSource();
            UpdateSummary();
            UpdateClock();
            ScrollToCurrentItem();
        }

        private void UpdateClock()
        {
            bool isLive = _liveTimer.Enabled;
            string liveTag = isLive ? " ● LIVE" : string.Empty;
            this.lblClock.Text = $"Giờ hiện tại: {DateTime.Now:HH:mm:ss  dd/MM/yyyy}{liveTag}";
        }

        private void ScrollToCurrentItem()
        {
            if (_lstScheduleItems == null || _lstScheduleItems.Count == 0) return;
            // Ưu tiên tìm đơn đang chạy, nếu không thì đơn CHỜ đầu tiên
            int idx = _lstScheduleItems.FindIndex(s => s.IsRunning);
            if (idx < 0)
                idx = _lstScheduleItems.FindIndex(s => !s.IsDone);
            if (idx >= 0)
            {
                this.grvSchedule.FocusedRowHandle = idx;
                this.grvSchedule.MakeRowVisible(idx);
            }
        }

        private void UpdateSummary()
        {
            int totalSwitches = OrderScheduleOptimizer.CountSwitches(_lstScheduleItems);
            int totalMinutes = OrderScheduleOptimizer.TotalMinutes(_lstScheduleItems);
            int lateCount = OrderScheduleOptimizer.CountLateOrders(_lstScheduleItems);
            int hours = totalMinutes / 60;
            int mins = totalMinutes % 60;

            string modeLabel = _isPriorityMode ? " | Chế độ: ⚡ ƯU TIÊN" : " | Chế độ: Greedy";
            this.lblSummary.Text =
                $"Tổng phiếu: {_lstScheduleItems.Count}   |   " +
                $"Số lần đổi loại: {totalSwitches}   |   " +
                $"Tổng thời gian ước tính: {hours}h {mins}m   |   " +
                $"Phiếu trễ hạn: {lateCount}" +
                modeLabel;

            this.grvSchedule.RowCellStyle -= grvSchedule_RowCellStyle;
            this.grvSchedule.RowCellStyle += grvSchedule_RowCellStyle;
        }

        private void grvSchedule_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0 || e.RowHandle >= _lstScheduleItems.Count) return;
            var item = _lstScheduleItems[e.RowHandle];
            if (item == null) return;

            // ── Ưu tiên cao: màu theo tiến độ thực tế ────────────────
            if (item.IsRunning)
            {
                e.Appearance.BackColor = ScheduleColorHelper.ColorRunning;
                e.Appearance.ForeColor = ScheduleColorHelper.ForeRunning;
                e.Appearance.Options.UseForeColor = true;
                return;
            }
            if (item.IsDone)
            {
                e.Appearance.BackColor = ScheduleColorHelper.ColorDone;
                e.Appearance.ForeColor = ScheduleColorHelper.ForeDone;
                e.Appearance.Options.UseForeColor = true;
                return;
            }

            // ── Đơn đang CHỜ: màu theo CR (luôn hiển thị, cả 2 chế độ) ──
            Color crBack = ScheduleColorHelper.BackColorByCR(item.CriticalRatio);
            if (crBack != Color.Empty)
            {
                e.Appearance.BackColor = crBack;
                e.Appearance.ForeColor = ScheduleColorHelper.ForeColorByCR(item.CriticalRatio);
                e.Appearance.Options.UseForeColor = true;
                return;
            }

            // Không có deadline → màu theo switch cost
            if (item.HasSwitchBefore)
            {
                e.Appearance.BackColor  = ScheduleColorHelper.ColorSwitch;
                e.Appearance.BackColor2 = Color.FromArgb(255, 210, 150);
            }
            else if (e.RowHandle % 2 == 0)
            {
                e.Appearance.BackColor = Color.FromArgb(240, 248, 255);
            }
        }

        private void btnLoadOrders_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnOptimize_Click(object sender, EventArgs e)
        {
            if (_lstPendingDuLieuTron == null || _lstPendingDuLieuTron.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Không có dữ liệu trộn nào đang chờ trong khoảng thời gian đã chọn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isPriorityMode = false;
            DateTime startTime = this.datStartTime.DateTime;
            int minutesPerBatch = (int)this.spnMinutesPerBatch.Value;
            int switchCost = (int)this.spnSwitchCost.Value;
            _presenter.RunOptimization(startTime, minutesPerBatch, switchCost, usePriority: false);
        }

        private void btnPriority_Click(object sender, EventArgs e)
        {
            if (_lstPendingDuLieuTron == null || _lstPendingDuLieuTron.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(
                    "Không có dữ liệu trộn nào đang chờ trong khoảng thời gian đã chọn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _isPriorityMode = true;
            DateTime startTime = this.datStartTime.DateTime;
            int minutesPerBatch = (int)this.spnMinutesPerBatch.Value;
            int switchCost = (int)this.spnSwitchCost.Value;
            _presenter.RunOptimization(startTime, minutesPerBatch, switchCost, usePriority: true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _liveTimer.Stop();
            _isPriorityMode = false;
            _lstScheduleItems = new List<ObjScheduleItem>();
            this.datTuNgay.EditValue = DateTime.Now.Date;
            this.datDenNgay.EditValue = DateTime.Now.Date;
            this.datStartTime.EditValue = DateTime.Now;
            this.spnMinutesPerBatch.EditValue = 5;
            this.spnSwitchCost.EditValue = 15;
            this.lueMACFilter.EditValue = null;
            this.grcSchedule.DataSource = null;
            this.lblSummary.Text = string.Empty;
            this.lblClock.Text = string.Empty;
            this.lblPendingCount.Text = "Tổng phiếu chờ: 0";
        }
    }
}

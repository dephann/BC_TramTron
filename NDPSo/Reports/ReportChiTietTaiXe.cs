using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using NDPSo.ClientSetting;
using NDPSo.Data;
using NDPSo.KWS;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.Reports
{
    public partial class ReportChiTietTaiXe : ControlViewBase
    {
        private IServices _ser = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
        //private ObjAggregationResult _objAggregation;
        private BindingList<Objvw_DriverDetailDayWithID> _blstTotalDriver = new BindingList<Objvw_DriverDetailDayWithID>();
        private BindingList<Objvw_DriverDetailDayWithID> _blstDriverDetailDay = new BindingList<Objvw_DriverDetailDayWithID>();
        private BindingList<Objvw_DriverDetailDayWithID> _blstDriverDetailDayID = new BindingList<Objvw_DriverDetailDayWithID>();
        private BindingList<ObjTaiXe> _blstTaiXe = new BindingList<ObjTaiXe>();
        private BindingList<ObjDriverSummary> _blstDriverSummary = new BindingList<ObjDriverSummary>();
        public ReportChiTietTaiXe()
        {
            InitializeComponent();
            this.Caption = "Chi tiết tài xế";
            this._blstTaiXe = Converter.ConvertToBindingList<ObjTaiXe>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTaiXe() as List<ObjTaiXe>);

        }
        protected override void PopulateStaticData()
        {
            this.lueCheDo.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.SimMode>(true);
            this.lueTaiXe.Properties.DataSource = (object)this._blstTaiXe;

            LoadSearchDefaultValues();

        }
        protected override void PopulateData()
        {
            Task.Run(() => LoadData());
            Task.Run(() => LoadData_DetailDay());
        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)DateTime.Now.AddDays(-(double)ConfigManager.TramTronConfig.LatestBaoCaoDays);
            this.datToDate.EditValue = (object)DateTime.Now;
            this.lueTaiXe.EditValue = (object)null;
            this.lueCheDo.EditValue = (object)2;
        }
        private void LoadData()
        {
            bool? active = new bool?();
            if (Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                active = new bool?(false);
            else if (Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                active = new bool?(true);


            _blstTotalDriver = Converter.ConvertToBindingList<Objvw_DriverDetailDayWithID>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTotalDriver_ByCondition((int?)lueTaiXe.EditValue, (bool?)active) as List<Objvw_DriverDetailDayWithID>);

        }

        private void LoadData_DetailDay()
        {
            _blstDriverDetailDay.Clear();
            _blstDriverDetailDayID.Clear();

            bool? active = new bool?();
            if (Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                active = new bool?(false);
            else if (Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                active = new bool?(true);


            for (int i = 1; i <= this._blstTotalDriver.Count; i++)
            {
                _blstDriverDetailDay = Converter.ConvertToBindingList<Objvw_DriverDetailDayWithID>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListDriverDetailDay_ByCondition(null, null, i, null) as List<Objvw_DriverDetailDayWithID>);
                _blstDriverDetailDayID.Add(_blstDriverDetailDay[0]);
            }

            FilterData();
            BindingList<ObjDriverSummary> list = new BindingList<ObjDriverSummary>();
            list.Clear();
            list = Converter.ConvertToBindingList<ObjDriverSummary>(GroupAndSumDriverDetail(_blstDriverDetailDayID));
            Invoke(new Action(() => UpdateUI_ID(list)));
        }
        public void FilterData()
        {
            bool? active = null;
            if (Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                active = new bool?(false);
            else if (Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                active = new bool?(true);

            int? taiXeID = null;
            if (Convert.ToInt32(this.lueTaiXe.EditValue) != 0)
                taiXeID = Convert.ToInt32(this.lueTaiXe.EditValue);

            var startDate = Searching.Build_StartDateTime(this.datFromDate.DateTime.AddDays(-1));
            var endDate = Searching.Build_EndDateTime(this.datToDate.DateTime.AddDays(-1));

            var filteredList = _blstDriverDetailDayID
             .Where(item => item.NgayMeTron >= startDate &&
             item.NgayMeTron <= endDate &&
             (active == null || item.IsManual == active) &&
              (taiXeID == null || item.TaiXeID == taiXeID))
             .ToList();
            _blstDriverDetailDayID.Clear();
            foreach (var item in filteredList)
            {
                _blstDriverDetailDayID.Add(item);
            }
        }
        public List<ObjDriverSummary> GroupAndSumDriverDetail(BindingList<Objvw_DriverDetailDayWithID> driverDetailDays)
        {
            var result = driverDetailDays
                .GroupBy(d => d.TaiXeID)
                .Select(g => new ObjDriverSummary
                {

                    TaiXeID = g.Key,
                    TenTaiXe = g.First().TenTaiXe,
                    Total_Tranfer = g.Sum(x => x.Total_Tranfer),
                    Total_KL = g.Sum(x => (decimal)x.Total_KL)
                })
                .ToList();

            return result;
        }
        private void UpdateUI(BindingList<Objvw_DriverDetailDayWithID> result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(result)));
                return;
            }

            this.grcChiTietTaiXe.DataSource = result;
        }
        private void UpdateUI_ID(BindingList<ObjDriverSummary> result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI_ID(result)));
                return;
            }
            this.grcChiTietTaiXe.DataSource = null;
            this.grcChiTietTaiXe.DataSource = result;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Task.Run(() => LoadData_DetailDay());
        }
        
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadSearchDefaultValues();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "BÁO CÁO CHI TIẾT TÀI XẾ";
                string str = string.Format("Từ ngày: {0} - đến ngày: {1}", (object)FormatToString.DateTimeToString(this.datFromDate.DateTime), (object)FormatToString.DateTimeToString(this.datToDate.DateTime));
                string str2 = string.Format("Tài xế: {0}", (object)this.lueTaiXe.Text);

                List<string> lst = new List<string>();
                lst.Add(str);
                if (this.lueTaiXe.EditValue != (object)null)
                    lst.Add(str2);
                new Helpper().ExportExcelWithHeader(true, (IPrintable)this.grcChiTietTaiXe, true, true, title, lst);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

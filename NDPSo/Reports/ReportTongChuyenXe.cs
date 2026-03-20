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
    public partial class ReportTongChuyenXe : ControlViewBase
    {
        private IServices _ser = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
        //private ObjAggregationResult _objAggregation;
        private BindingList<Objvw_TranferDetailDayWithID> _blstTotalTranfer = new BindingList<Objvw_TranferDetailDayWithID>();
        private BindingList<Objvw_TranferDetailDayWithID> _blstTranferDetailDay = new BindingList<Objvw_TranferDetailDayWithID>();
        private BindingList<Objvw_TranferDetailDayWithID> _blstTranferDetailDayID = new BindingList<Objvw_TranferDetailDayWithID>();
        private BindingList<ObjXe> _blstXe = new BindingList<ObjXe>();
        private BindingList<ObjTranferSummary> _blstTranferSummary = new BindingList<ObjTranferSummary>();
       // private BindingList<ObjVatTu> danhSachDuLieu = new BindingList<ObjVatTu>();

        public ReportTongChuyenXe()
        {
            InitializeComponent();
            this.Caption = "Tổng chuyến xe";
            this._blstXe = Converter.ConvertToBindingList<ObjXe>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListXe() as List<ObjXe>);

        }
        protected override void PopulateStaticData()
        {
            this.lueCheDo.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.SimMode>(true);
            this.lueBienSo.Properties.DataSource = (object)this._blstXe;

            LoadSearchDefaultValues();

        }
        protected override void PopulateData()
        {
            //this.LoadDataMix();
            //LoadData();
            Task.Run(() => LoadData());
            Task.Run(() => LoadData_DetailDay());

        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)DateTime.Now.AddDays(-(double)ConfigManager.TramTronConfig.LatestBaoCaoDays);
            this.datToDate.EditValue = (object)DateTime.Now;
            this.lueBienSo.EditValue = (object)null;
            this.lueCheDo.EditValue = (object)2;
        }
        private void LoadData()
        {
            bool? active = new bool?();
            if (Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                active = new bool?(false);
            else if (Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                active = new bool?(true);


           _blstTotalTranfer = Converter.ConvertToBindingList<Objvw_TranferDetailDayWithID>(this._ser.ListTotalTranfer_ByCondition((int?)lueBienSo.EditValue, (bool?)active) as List<Objvw_TranferDetailDayWithID>);

            //this.grcTongChuyenXe.DataSource = (object)this._blstTotalTranfer;
        }
        private void LoadData_DetailDay()
        {
            _blstTranferDetailDay.Clear();
            _blstTranferDetailDayID.Clear();
            bool? active = new bool?();
            if (Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                active = new bool?(false);
            else if (Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                active = new bool?(true);

            for (int i = 1; i <= this._blstTotalTranfer.Count; i++)
            {
                _blstTranferDetailDay = Converter.ConvertToBindingList<Objvw_TranferDetailDayWithID>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTranferDetailDay_ByCondition(null, null, i, null) as List<Objvw_TranferDetailDayWithID>);
                _blstTranferDetailDayID.Add(_blstTranferDetailDay[0]);
            }

            FilterData();
            BindingList<ObjTranferSummary> list = new BindingList<ObjTranferSummary>();
            list.Clear();
            list = Converter.ConvertToBindingList<ObjTranferSummary>(GroupAndSumTranferDetail(_blstTranferDetailDayID));
            Invoke(new Action(() => UpdateUI_ID(list)));

        }
        public void FilterData()
        {
            bool? active = null;
            if (Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                active = new bool?(false);
            else if (Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                active = new bool?(true);

            int? xeID = null;
            if (Convert.ToInt32(this.lueBienSo.EditValue) != 0)
                xeID = Convert.ToInt32(this.lueBienSo.EditValue);

            var startDate = Searching.Build_StartDateTime(this.datFromDate.DateTime.AddDays(-1));
            var endDate = Searching.Build_EndDateTime(this.datToDate.DateTime.AddDays(-1));

            var filteredList = _blstTranferDetailDayID
             .Where(item => item.NgayMeTron >= startDate &&
             item.NgayMeTron <= endDate &&
             (active == null || item.IsQueued == active) &&
              (xeID == null || item.XeID == xeID))
             .ToList();
            _blstTranferDetailDayID.Clear();
            foreach (var item in filteredList)
            {
                _blstTranferDetailDayID.Add(item);
            }
        }

        public List<ObjTranferSummary> GroupAndSumTranferDetail(BindingList<Objvw_TranferDetailDayWithID>tranferDetailDays)
        {
            var result = tranferDetailDays
                .GroupBy(d => d.XeID)
                .Select(g => new ObjTranferSummary
                {

                    XeID = g.Key,
                    BienSo = g.First().BienSo,
                    Total_Tranfer = g.Sum(x => x.Total_Tranfer),
                    Total_KL = g.Sum(x => (decimal)x.Total_KL)
                })
                .ToList();

            return result;
        }
        private void UpdateUI(BindingList<Objvw_TranferDetailDayWithID> result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(result)));
                return;
            }

            this.grcTongChuyenXe.DataSource = result;
        }
        private void UpdateUI_ID(BindingList<ObjTranferSummary> result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI_ID(result)));
                return;
            }
            this.grcTongChuyenXe.DataSource = null;
            this.grcTongChuyenXe.DataSource = result;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //LoadData();
            //Task.Run(() => LoadData());
            Task.Run(() => LoadData_DetailDay());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadSearchDefaultValues();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "BÁO CÁO TỔNG CHUYẾN XE";
                string str = string.Format("Từ ngày: {0} - đến ngày: {1}", (object)FormatToString.DateTimeToString(this.datFromDate.DateTime), (object)FormatToString.DateTimeToString(this.datToDate.DateTime));
                string str2 = string.Format("Biển số: {0}", (object)this.lueBienSo.Text);
                List<string> lst = new List<string>();
                lst.Add(str);
                if (this.lueBienSo.EditValue != (object)null)
                    lst.Add(str2);
                new Helpper().ExportExcelWithHeader(true, (IPrintable)this.grcTongChuyenXe, true, true, title, lst);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

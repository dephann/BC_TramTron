using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using NDPSo.ClientSetting;
using NDPSo.Data;
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
        private BindingList<Objvw_TotalDriver> _blstTotalDriver = new BindingList<Objvw_TotalDriver>();
        private BindingList<ObjTaiXe> _blstTaiXe = new BindingList<ObjTaiXe>();

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


            _blstTotalDriver = Converter.ConvertToBindingList<Objvw_TotalDriver>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTotalDriver_ByCondition((int?)lueTaiXe.EditValue, (bool?)active) as List<Objvw_TotalDriver>);

            this.grcChiTietTaiXe.DataSource = (object)this._blstTotalDriver;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            Task.Run(() => LoadData());
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

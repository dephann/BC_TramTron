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
    public partial class ReportTongChuyenXe : ControlViewBase
    {
        private IServices _ser = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
        //private ObjAggregationResult _objAggregation;
        private BindingList<Objvw_TotalTranfer> _blstTotalTranfer = new BindingList<Objvw_TotalTranfer>();
        private BindingList<ObjXe> _blstXe = new BindingList<ObjXe>();
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
            LoadData();
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


           _blstTotalTranfer = Converter.ConvertToBindingList<Objvw_TotalTranfer>(this._ser.ListTotalTranfer_ByCondition((int?)lueBienSo.EditValue, (bool?)active) as List<Objvw_TotalTranfer>);

            this.grcTongChuyenXe.DataSource = (object)this._blstTotalTranfer;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
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

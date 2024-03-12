using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using NDPSo.ClientSetting;
using NDPSo.Data;
using NDPSo.EntityModel;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.Reports
{
    public partial class SampleRe : ControlViewBase
    {
        private IServices _ser = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
        private BindingList<Objvw_TranferDetailDay> _blstTotalMaterial = new BindingList<Objvw_TranferDetailDay>();
        private BindingList<ObjMaterial> _blstMaterial = new BindingList<ObjMaterial>();
        private BindingList<ObjVatTu> danhSachDuLieu = new BindingList<ObjVatTu>();

        public SampleRe()
        {
            InitializeComponent();
            this.Caption = "Tổng vật tư";
            this._blstMaterial = Converter.ConvertToBindingList<ObjMaterial>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMaterial() as List<ObjMaterial>);

        }
        protected override void PopulateStaticData()
        {
            this.lueCheDo.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.SimMode>(true);
            this.lueMaterial.Properties.DataSource = (object)this._blstMaterial;

            LoadSearchDefaultValues();

        }
        protected override void PopulateData()
        {
            //this.LoadDataMix();
            LoadData();
        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = string.Empty;
            this.datToDate.EditValue = (object)DateTime.Now;
            this.lueMaterial.EditValue = (object)null;
            this.lueCheDo.EditValue = (object)2;
        }
        private void LoadData()
        {
            bool? active = new bool?();
            if (Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                active = new bool?(false);
            else if (Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                active = new bool?(true);

            // _blstTotalMaterial = Converter.ConvertToBindingList<Objvw_MaterialDetailDay>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMaterialDetailDay_ByCondition(Searching.Build_StartDateTime(this.datFromDate.DateTime), Searching.Build_EndDateTime(this.datToDate.DateTime), (int?)lueMaterial.EditValue, (bool?)active) as List<Objvw_MaterialDetailDay>);
            _blstTotalMaterial =  Converter.ConvertToBindingList<Objvw_TranferDetailDay>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTranferDetailDay_ByCondition(Searching.Build_StartDateTime(this.datFromDate.DateTime), Searching.Build_EndDateTime(this.datToDate.DateTime), (int?)lueMaterial.EditValue, (bool?)active) as List<Objvw_TranferDetailDay>);
            //GetData();
            this.gridControl1.DataSource = (object)this._blstTotalMaterial;
        }

        private void GetData()
        {
            /*using (var dbContext = new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString))
            {
                var query = dbContext.vw_PvTranferDetailDay.GroupBy(v => new { v.NgayMeTron, v.XeID })
                                                     .Select(g => g.FirstOrDefault())
                                                     .ToList();
                // Thực hiện các xử lý với dữ liệu đã lấy được
                query.ToList();
            }*/
            using (var dbContext = new DEPTramTronEntities(ConfigManager.ServiceConfig.ConnectionString))
            {
                

                var ngayMeTrons = dbContext.vw_PvTranferDetailDay
                                        .Select(x => x.NgayMeTron)
                                        .Distinct()
                                        .ToList();
                var xeIDs = dbContext.vw_PvTranferDetailDay
                        .Select(x => x.BienSo)
                        .Distinct()
                        .ToList();
                var allResults = new List<vw_PvTranferDetailDay>();
                foreach (var xeID in xeIDs )
                {
                    foreach (var ngayMeTron in ngayMeTrons)
                    {
                        var result = dbContext.vw_PvTranferDetailDay
                                            .Where(y => DbFunctions.TruncateTime(y.NgayMeTron) == DbFunctions.TruncateTime(ngayMeTron) && y.BienSo.Contains(xeID))
                                            .ToList();
                        // Xử lý kết quả ở đây
                        if (result.Any())
                        {
                            allResults.AddRange(result); // Thêm kết quả vào danh sách allResults nếu có dữ liệu đáp ứng điều kiện
                        }
                    }

                }
               
                //this._blstTotalMaterial =  Converter.ConvertToBindingList<vw_PvTranferDetailDay>(allResults);
            }
            
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadSearchDefaultValues();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "BÁO CÁO TỔNG VẬT TƯ";
                string str = string.Format("Từ ngày: {0} - đến ngày: {1}", (object)FormatToString.DateTimeToString(this.datFromDate.DateTime), (object)FormatToString.DateTimeToString(this.datToDate.DateTime));
                new Helpper().ExportExcelWithHeader(true, (IPrintable)this.gridControl1, true, true, title, new List<string>()
                {
                  str
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

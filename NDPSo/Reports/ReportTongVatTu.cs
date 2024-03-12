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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.Reports
{
    public partial class ReportTongVatTu : ControlViewBase
    {
        private IServices _ser = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
        //private ObjAggregationResult _objAggregation;
        private BindingList<Objvw_TotalMaterial> _blstTotalMaterial = new BindingList<Objvw_TotalMaterial>();
        private BindingList<ObjMaterial> _blstMaterial = new BindingList<ObjMaterial>();
        private BindingList<ObjVatTu> danhSachDuLieu = new BindingList<ObjVatTu>();
        public ReportTongVatTu()
        {
            InitializeComponent();
            this.Caption = "Tổng vật tư";
            //this._blstSilo = Converter.ConvertToBindingList<ObjSilo>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListSilo_ByActivated(true) as List<ObjSilo>);
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
            this.datFromDate.EditValue = (object)DateTime.Now.AddDays(-(double)ConfigManager.TramTronConfig.LatestBaoCaoDays);
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


            /* _objAggregation = this._ser.GetSumForIsQueuedAndTimeRange(Searching.Build_StartDateTime(this.datFromDate.DateTime), Searching.Build_EndDateTime(this.datToDate.DateTime), active);
             this.danhSachDuLieu.Clear();
             if (this.lueMaterial.EditValue != null)
             {
                 string maSilo = this.lueMaterial.EditValue.ToString();
                 string nameMaterial = GetMaterialNameFromBlst(maSilo);
                 AddDataToList(this.danhSachDuLieu, maSilo, nameMaterial, GetAggreTotal(maSilo), GetAggreTotalBat(maSilo));
                this.grcTongVatTu.DataSource = danhSachDuLieu;
             }
             else
             {
                 CreateDataList();
                 this.grcTongVatTu.DataSource = danhSachDuLieu;
             }*/
            //_blstTotalMaterial = Converter.ConvertToBindingList<Objvw_TotalMaterial>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMaterialDetailDay_ByCondition(Searching.Build_StartDateTime(this.datFromDate.DateTime), Searching.Build_EndDateTime(this.datToDate.DateTime), (int?)lueMaterial.EditValue, (bool?)active) as List<Objvw_MaterialDetailDay>);
            _blstTotalMaterial = Converter.ConvertToBindingList<Objvw_TotalMaterial>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTotalMaterial_ByCondition((int?)lueMaterial.EditValue, (bool?)active) as List<Objvw_TotalMaterial>);
            Invoke(new Action(() => UpdateUI(_blstTotalMaterial)));

            //_blstTotalMaterial = (BindingList<Objvw_TotalMaterial>)this._ser.ListTotalMaterial_ByCondition((int?)lueMaterial.EditValue, (bool?)active);
            //this.grcTongVatTu.DataSource = (object)this._blstTotalMaterial;
        }
        private void UpdateUI(BindingList<Objvw_TotalMaterial> result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(result)));
                return;
            }

            this.grcTongVatTu.DataSource = result;
        }
        /* private void CreateDataList1(int siloID)
         {
             *//*danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[0].SiloID, this._blstSilo[0].MaterialName, this._objAggregation.Total_Agg1_Bat, this._objAggregation.Total_Agg1, CalSaiSo(this._objAggregation.Total_Agg1, this._objAggregation.Total_Agg1_Bat), CalPerSaiSo(this._objAggregation.Total_Agg1, this._objAggregation.Total_Agg1_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[1].SiloID, this._blstSilo[1].MaterialName, this._objAggregation.Total_Agg2_Bat, this._objAggregation.Total_Agg2, CalSaiSo(this._objAggregation.Total_Agg2, this._objAggregation.Total_Agg2_Bat), CalPerSaiSo(this._objAggregation.Total_Agg2, this._objAggregation.Total_Agg2_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[2].SiloID, this._blstSilo[2].MaterialName, this._objAggregation.Total_Agg3_Bat, this._objAggregation.Total_Agg3, CalSaiSo(this._objAggregation.Total_Agg3, this._objAggregation.Total_Agg3_Bat), CalPerSaiSo(this._objAggregation.Total_Agg3, this._objAggregation.Total_Agg3_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[3].SiloID, this._blstSilo[3].MaterialName, this._objAggregation.Total_Agg4_Bat, this._objAggregation.Total_Agg4, CalSaiSo(this._objAggregation.Total_Agg4, this._objAggregation.Total_Agg4_Bat), CalPerSaiSo(this._objAggregation.Total_Agg4, this._objAggregation.Total_Agg4_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[4].SiloID, this._blstSilo[4].MaterialName, this._objAggregation.Total_Agg5_Bat, this._objAggregation.Total_Agg5, CalSaiSo(this._objAggregation.Total_Agg5, this._objAggregation.Total_Agg5_Bat), CalPerSaiSo(this._objAggregation.Total_Agg5, this._objAggregation.Total_Agg5_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[5].SiloID, this._blstSilo[5].MaterialName, this._objAggregation.Total_Ce1_Bat, this._objAggregation.Total_Ce1, CalSaiSo(this._objAggregation.Total_Ce1, this._objAggregation.Total_Ce1_Bat), CalPerSaiSo(this._objAggregation.Total_Ce1, this._objAggregation.Total_Ce1_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[6].SiloID, this._blstSilo[6].MaterialName, this._objAggregation.Total_Ce2_Bat, this._objAggregation.Total_Ce2, CalSaiSo(this._objAggregation.Total_Ce2, this._objAggregation.Total_Ce2_Bat), CalPerSaiSo(this._objAggregation.Total_Ce2, this._objAggregation.Total_Ce2_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[7].SiloID, this._blstSilo[7].MaterialName, this._objAggregation.Total_Ce3_Bat, this._objAggregation.Total_Ce3, CalSaiSo(this._objAggregation.Total_Ce3, this._objAggregation.Total_Ce3_Bat), CalPerSaiSo(this._objAggregation.Total_Ce3, this._objAggregation.Total_Ce3_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[8].SiloID, this._blstSilo[8].MaterialName, this._objAggregation.Total_Ce4_Bat, this._objAggregation.Total_Ce4, CalSaiSo(this._objAggregation.Total_Ce4, this._objAggregation.Total_Ce4_Bat), CalPerSaiSo(this._objAggregation.Total_Ce4, this._objAggregation.Total_Ce4_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[9].SiloID, this._blstSilo[9].MaterialName, this._objAggregation.Total_Ce5_Bat, this._objAggregation.Total_Ce5, CalSaiSo(this._objAggregation.Total_Ce5, this._objAggregation.Total_Ce5_Bat), CalPerSaiSo(this._objAggregation.Total_Ce5, this._objAggregation.Total_Ce5_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[10].SiloID, this._blstSilo[10].MaterialName, this._objAggregation.Total_Wa1_Bat, this._objAggregation.Total_Wa1, CalSaiSo(this._objAggregation.Total_Wa1, this._objAggregation.Total_Wa1_Bat), CalPerSaiSo(this._objAggregation.Total_Wa1, this._objAggregation.Total_Wa1_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[11].SiloID, this._blstSilo[11].MaterialName, this._objAggregation.Total_Wa2_Bat, this._objAggregation.Total_Wa2, CalSaiSo(this._objAggregation.Total_Wa2, this._objAggregation.Total_Wa2_Bat), CalPerSaiSo(this._objAggregation.Total_Wa2, this._objAggregation.Total_Wa2_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[12].SiloID, this._blstSilo[12].MaterialName, this._objAggregation.Total_Add1_Bat, this._objAggregation.Total_Add1, CalSaiSo(this._objAggregation.Total_Add1, this._objAggregation.Total_Add1_Bat), CalPerSaiSo(this._objAggregation.Total_Add1, this._objAggregation.Total_Add1_Bat)));
             danhSachDuLieu.Add(new ObjVatTu(this._blstSilo[13].SiloID, this._blstSilo[13].MaterialName, this._objAggregation.Total_Add2_Bat, this._objAggregation.Total_Add2, CalSaiSo(this._objAggregation.Total_Add2, this._objAggregation.Total_Add2_Bat), CalPerSaiSo(this._objAggregation.Total_Add2, this._objAggregation.Total_Add2_Bat)));
             *//*//danhSachDuLieu.Add(new ObjVatTu("Add3", this._objAggregation.Total_Add3_Bat, this._objAggregation.Total_Add3, 0, 0));
             //danhSachDuLieu.Add(new ObjVatTu("Add4", this._objAggregation.Total_Add4_Bat, this._objAggregation.Total_Add4, 0, 0));
             //danhSachDuLieu.Add(new ObjVatTu("Add5", this._objAggregation.Total_Add5_Bat, this._objAggregation.Total_Add5, 0, 0));
             // danhSachDuLieu.Add(new ObjVatTu("Add6", this._objAggregation.Total_Add6_Bat, this._objAggregation.Total_Add6, 0, 0));
         }
         private string GetMaterialNameFromBlst(string maSilo)
         {
             string nameMaterial = "";
             for (int i = 0; i < this._blstSilo.Count; i++)
             {
                 if(this._blstSilo[i].MaSilo == maSilo)
                 {
                     nameMaterial = this._blstSilo[i].MaterialName;
                 }
             }
             return nameMaterial;
         }
         private decimal? GetAggreTotal(string maSilo)
         {
             decimal? dinhMuc = 0M;
             switch (maSilo)
             {
                 case "Agg1":
                     dinhMuc = this._objAggregation.Total_Agg1;
                     break;
                 case "Agg2":
                     dinhMuc = this._objAggregation.Total_Agg2;
                     break;
                 case "Agg3":
                     dinhMuc = this._objAggregation.Total_Agg3;
                     break;
                 case "Agg4":
                     dinhMuc = this._objAggregation.Total_Agg4;
                     break;
                 case "Agg5":
                     dinhMuc = this._objAggregation.Total_Agg5;
                     break;
                 case "Ce1":
                     dinhMuc = this._objAggregation.Total_Ce1;
                     break;
                 case "Ce2":
                     dinhMuc = this._objAggregation.Total_Ce2;
                     break;
                 case "Ce3":
                     dinhMuc = this._objAggregation.Total_Ce3;
                     break;
                 case "Ce4":
                     dinhMuc = this._objAggregation.Total_Ce4;
                     break;
                 case "Ce5":
                     dinhMuc = this._objAggregation.Total_Ce5;
                     break;
                 case "Wa1":
                     dinhMuc = this._objAggregation.Total_Wa1;
                     break;
                 case "Wa2":
                     dinhMuc = this._objAggregation.Total_Wa2;
                     break;
                 case "Add1":
                     dinhMuc = this._objAggregation.Total_Add1;
                     break;
                 case "Add2":
                     dinhMuc = this._objAggregation.Total_Add2;
                     break;
                 case "Add3":
                     dinhMuc = this._objAggregation.Total_Add3;
                     break;
                 case "Add4":
                     dinhMuc = this._objAggregation.Total_Add4;
                     break;
                 case "Add5":
                     dinhMuc = this._objAggregation.Total_Add5;
                     break;
                 case "Add6":
                     dinhMuc = this._objAggregation.Total_Add6;
                     break;
             }
             return dinhMuc;
         }
         private decimal? GetAggreTotalBat(string maSilo)
         {
             decimal? capPhoi = 0M;
             switch (maSilo)
             {
                 case "Agg1":
                     capPhoi = this._objAggregation.Total_Agg1_Bat;
                     break;
                 case "Agg2":
                     capPhoi = this._objAggregation.Total_Agg2_Bat;
                     break;
                 case "Agg3":
                     capPhoi = this._objAggregation.Total_Agg3_Bat;
                     break;
                 case "Agg4":
                     capPhoi = this._objAggregation.Total_Agg4_Bat;
                     break;
                 case "Agg5":
                     capPhoi = this._objAggregation.Total_Agg5_Bat;
                     break;
                 case "Ce1":
                     capPhoi = this._objAggregation.Total_Ce1_Bat;
                     break;
                 case "Ce2":
                     capPhoi = this._objAggregation.Total_Ce2_Bat;
                     break;
                 case "Ce3":
                     capPhoi = this._objAggregation.Total_Ce3_Bat;
                     break;
                 case "Ce4":
                     capPhoi = this._objAggregation.Total_Ce4_Bat;
                     break;
                 case "Ce5":
                     capPhoi = this._objAggregation.Total_Ce5_Bat;
                     break;
                 case "Wa1":
                     capPhoi = this._objAggregation.Total_Wa1_Bat;
                     break;
                 case "Wa2":
                     capPhoi = this._objAggregation.Total_Wa2_Bat;
                     break;
                 case "Add1":
                     capPhoi = this._objAggregation.Total_Add1_Bat;
                     break;
                 case "Add2":
                     capPhoi = this._objAggregation.Total_Add2_Bat;
                     break;
                 case "Add3":
                     capPhoi = this._objAggregation.Total_Add3_Bat;
                     break;
                 case "Add4":
                     capPhoi = this._objAggregation.Total_Add4_Bat;
                     break;
                 case "Add5":
                     capPhoi = this._objAggregation.Total_Add5_Bat;
                     break;
                 case "Add6":
                     capPhoi = this._objAggregation.Total_Add6_Bat;
                     break;
             }
             return capPhoi;
         }
         private void CreateDataList()
         {
             foreach(ObjSilo silo in this._blstSilo)
             {
                 AddDataToList(this.danhSachDuLieu, silo.MaSilo, silo.MaterialName, GetAggreTotal(silo.MaSilo), GetAggreTotalBat(silo.MaSilo));
             }
         }
         private void AddDataToList(BindingList<ObjVatTu> blst, string maSilo, string tenVL, decimal? klThuc, decimal? capPhoi)
         {
             blst.Add(new ObjVatTu(maSilo, tenVL, klThuc, capPhoi, CalSaiSo(capPhoi, klThuc), CalPerSaiSo(capPhoi, klThuc)));
         }
         private decimal? CalSaiSo(decimal? numCP, decimal? numKLThuc)
         {
             decimal? num1;
             num1 = numCP - numKLThuc;

             return num1;
         }
         private decimal? CalPerSaiSo(decimal? numCP, decimal? numKLThuc)
         {
             decimal? num2;
             num2 = (numCP - numKLThuc) / numCP * 100;
             return num2;
         }*/
        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            Task.Run(() => LoadData());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadSearchDefaultValues();
        }
        
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "BÁO CÁO TỔNG VẬT TƯ";
                string str = string.Format("Từ ngày: {0} - đến ngày: {1}", (object)FormatToString.DateTimeToString(this.datFromDate.DateTime), (object)FormatToString.DateTimeToString(this.datToDate.DateTime));
                string str2 = string.Format("Vật tự: {0}", (object)this.lueMaterial.Text);

                List<string> lst = new List<string>();
                lst.Add(str);
                if (this.lueMaterial.EditValue != (object)null)
                    lst.Add(str2);
               
                new Helpper().ExportExcelWithHeader(true, (IPrintable)this.grcTongVatTu, true, true, title, lst);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

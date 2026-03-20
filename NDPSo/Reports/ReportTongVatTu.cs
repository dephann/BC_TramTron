using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DocumentFormat.OpenXml.Wordprocessing;
using NDPSo.ClientSetting;
using NDPSo.Data;
using NDPSo.KWS;
using NDPSo.MasterData;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;

namespace NDPSo.Reports
{
    public partial class ReportTongVatTu : ControlViewBase, IDataMixMngView, IBase, IPermission
    {
        private DataMixMngDataPresenter _presenter;
        private IServices _ser = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
        //private ObjAggregationResult _objAggregation;
        private BindingList<Objvw_MaterialDetailDayWithID> _blstTotalMaterial = new BindingList<Objvw_MaterialDetailDayWithID>();
        private BindingList<ObjMaterial> _blstMaterial = new BindingList<ObjMaterial>();
        private BindingList<Objvw_MaterialDetailDayWithID> _blstMaterialDetailDay = new BindingList<Objvw_MaterialDetailDayWithID>();
        private BindingList<Objvw_MaterialDetailDayWithID> _blstMaterialDetailDayID = new BindingList<Objvw_MaterialDetailDayWithID>();
        private List<Objvw_MaterialDetailDayWithID> filteredList = new List<Objvw_MaterialDetailDayWithID>();
        private BindingList<ObjMaterialSummary> _blstMaterialSummary = new BindingList<ObjMaterialSummary>();
        private BindingList<ObjVatTu> danhSachDuLieu = new BindingList<ObjVatTu>();
        public BindingList<Objvw_DataMix> _blstDataMix = new BindingList<Objvw_DataMix>();
        public BindingList<ObjMAC> _blstMAC = new BindingList<ObjMAC>();
        public BindingList<ObjSilo> _blstSilo = new BindingList<ObjSilo>();
        private int num_silo_Agg;
        private int num_silo_Ce;
        private int num_silo_Wa;
        private int num_silo_Add;
        public BindingList<Objvw_DataMix> BLstDataMix
        {
            set
            {
                this._blstDataMix = value;

            }
        }
        public BindingList<ObjKhachHang> BLstKhachHang { set => throw new NotImplementedException(); }
        public BindingList<ObjCongTruong> BLstCongTruong { set => throw new NotImplementedException(); }
        public BindingList<ObjHangMuc> BLstHangMuc { set => throw new NotImplementedException(); }

        public BindingList<ObjMAC> BLstMAC
        {
            set
            {
                this._blstMAC = value;
            }
        }

        public BindingList<ObjSilo> BLstSilo
        {
            set
            {
                this._blstSilo = value;
            }
        }
        public BindingList<ObjXe> BLstXe { set => throw new NotImplementedException(); }
        public BindingList<ObjTaiXe> BLstTaiXe { set => throw new NotImplementedException(); }
        public BindingList<ObjNhanVien> BLstNhanVien { set => throw new NotImplementedException(); }
        public List<Utils.FieldCode> LstDataMixStatus { set => throw new NotImplementedException(); }

        public ReportTongVatTu()
        {
            InitializeComponent();
            this.Caption = "Tổng vật tư";
            this._presenter = new DataMixMngDataPresenter((IDataMixMngView)this);
            this._presenter.ListSilo();
            //this._blstSilo = Converter.ConvertToBindingList<ObjSilo>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListSilo_ByActivated(true) as List<ObjSilo>);
            this._blstMaterial = Converter.ConvertToBindingList<ObjMaterial>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMaterial() as List<ObjMaterial>);

        }

        protected override void PopulateStaticData()
        {
            this.lueCheDo.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.SimMode>(true);
            this.lueMaterial.Properties.DataSource = (object)this._blstMaterial;
            
            LoadSearchDefaultValues();

            num_silo_Agg = ConfigManager.TramTronConfig.SL_Silo_AGG;
            if (num_silo_Agg == 0)
                num_silo_Agg = 1;
            num_silo_Ce = ConfigManager.TramTronConfig.SL_Silo_CE;
            if (num_silo_Ce == 0)
                num_silo_Ce = 1;
            num_silo_Wa = ConfigManager.TramTronConfig.SL_Silo_WA;
            if (num_silo_Wa == 0)
                num_silo_Wa = 1;
            num_silo_Add = ConfigManager.TramTronConfig.SL_Silo_ADD;
            if (num_silo_Add == 0)
                num_silo_Add = 1;

        }
        protected override void PopulateData()
        {
            //this.LoadDataMix();
            //LoadData();
            // Task.Run(() => LoadData());
            _blstTotalMaterial = Converter.ConvertToBindingList<Objvw_MaterialDetailDayWithID>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTotalMaterial_ByCondition(null, null) as List<Objvw_MaterialDetailDayWithID>);

            //Task.Run(() => LoadData_DetailDay());
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
            _blstTotalMaterial = Converter.ConvertToBindingList<Objvw_MaterialDetailDayWithID>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTotalMaterial_ByCondition(null, null) as List<Objvw_MaterialDetailDayWithID>);
            //Invoke(new Action(() => UpdateUI(_blstTotalMaterial)));

            //_blstTotalMaterial = (BindingList<Objvw_TotalMaterial>)this._ser.ListTotalMaterial_ByCondition((int?)lueMaterial.EditValue, (bool?)active);
            //this.grcTongVatTu.DataSource = (object)this._blstTotalMaterial;
        }

        private async void LoadData_DetailDay()
        {
            _blstMaterialDetailDay.Clear();
            _blstMaterialDetailDayID.Clear();

            bool? GetActiveStatus(int value)
            {
                if (value == 1) return false;
                if (value == 2) return true;
                return null;
            }

            var active = GetActiveStatus(Convert.ToInt32(this.lueCheDo.EditValue));

            var tasks = new List<Task<List<Objvw_MaterialDetailDayWithID>>>();

            for (int i = 1; i <= this._blstTotalMaterial.Count; i++)
            {
                int materialId = i;
                tasks.Add(Task.Run(() => ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode)
                    .ListMaterialDetailDay_ByCondition(Searching.Build_StartDateTime(this.datFromDate.DateTime),
                        Searching.Build_EndDateTime(this.datToDate.DateTime),
                        materialId,
                        active) as List<Objvw_MaterialDetailDayWithID>));
            }

            var results = await Task.WhenAll(tasks);

            foreach (var result in results)
            {
                if (result != null && result.Count > 0)
                {
                    _blstMaterialDetailDayID.Add(result[0]);
                }
            }

            // Lọc dữ liệu
            //FilterData(_blstMaterialDetailDayID);

            // Group and sum the filtered data
            var list = Converter.ConvertToBindingList<ObjMaterialSummary>(GroupAndSumMaterialDetail(_blstMaterialDetailDayID));
            this.grcTongVatTu.DataSource = list;
            //Invoke(new Action(() => UpdateUI_ID(list)));
        }


        public async Task FilterData(BindingList<Objvw_MaterialDetailDayWithID> blstMaterialDetailDayID)
        {
            bool? active = null;
            if (Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                active = new bool?(false);
            else if (Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                active = new bool?(true);

            int? materialID = null;
            if (Convert.ToInt32(this.lueMaterial.EditValue) != 0)
                materialID = Convert.ToInt32(this.lueMaterial.EditValue);

            bool? cheDo = null;
            if(Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                cheDo = new bool?(false);
            else if(Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                cheDo = new bool?(true);

            var startDate = Searching.Build_StartDateTime(this.datFromDate.DateTime.AddDays(-1));
            var endDate = Searching.Build_EndDateTime(this.datToDate.DateTime.AddDays(-1));
            filteredList.Clear();
            filteredList = Converter.ConvertToList<Objvw_MaterialDetailDayWithID>(blstMaterialDetailDayID);

            filteredList.Where(item => item.NgayMeTron >= startDate &&
                                       item.NgayMeTron <= endDate &&
                                       ( active == null || item.IsManual == active) &&
                                       (materialID == null || item.MaterialID == materialID))
             .ToList();
            _blstMaterialDetailDayID.Clear();
            foreach (var item in filteredList)
            {
                _blstMaterialDetailDayID.Add(item);
            }
        }
        public List<ObjMaterialSummary> GroupAndSumMaterialDetail(BindingList<Objvw_MaterialDetailDayWithID> materialDetailDays)
        {
            var result = materialDetailDays
                .GroupBy(d => d.MaterialID)
                .Select(g => new ObjMaterialSummary
                {
                    
                    MaterialID = g.Key,
                    MaterialCode = g.First().MaterialCode, 
                    MaterialName = g.First().MaterialName,
                    Sum_ValueBat = g.Sum(x => (decimal)x.Sum_ValueBat),
                    Sum_ValueBatMan = g.Sum(x => (decimal)x.Sum_ValueBatMan),
                    Sum_ValueCP = g.Sum(x => (decimal)x.Sum_ValueCP),
                    SaiSo = g.Sum(x => (decimal)x.Sum_ValueCP) - g.Sum(x => (decimal)x.Sum_ValueBat),
                    PerSaiSo = ((g.Sum(x => (decimal)x.Sum_ValueCP) - g.Sum(x => (decimal)x.Sum_ValueBat)) * 100) / g.Sum(x => (decimal)x.Sum_ValueCP)
                })
                .ToList();

            return result;
        }

        

        private void SearchDataByCondition()
        {
            bool? active = new bool?();
            if (Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                active = new bool?(false);
            else if (Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                active = new bool?(true);

            _blstTotalMaterial = Converter.ConvertToBindingList<Objvw_MaterialDetailDayWithID>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTotalMaterial_ByCondition((int?)lueMaterial.EditValue, (bool?)active) as List<Objvw_MaterialDetailDayWithID>);
            Invoke(new Action(() => UpdateUI(_blstTotalMaterial)));
        }
        private void UpdateUI(BindingList<Objvw_MaterialDetailDayWithID> result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(result)));
                return;
            }

            this.grcTongVatTu.DataSource = result;
        }
        private void UpdateUI_ID(BindingList<ObjMaterialSummary> result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI_ID(result)));
                return;
            }
            this.grcTongVatTu.DataSource = null;
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
            //_blstTotalMaterial = Converter.ConvertToBindingList<Objvw_MaterialDetailDayWithID>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListTotalMaterial_ByCondition(null, null) as List<Objvw_MaterialDetailDayWithID>);

            //Task.Run(() => LoadData());
            bool? active = null;
            if (Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                active = new bool?(false);
            else if (Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                active = new bool?(true);

            //this._presenter.ListSilo();

            _blstDataMix = this._presenter.ListDataMix_ByCondition_re(
                Searching.BuildNew_StartDateTime(this.datFromDate.DateTime, TimeSpan.Zero),
                //this.datFromDate.DateTime,
                TimeSpan.Zero,
                Searching.BuildNew_EndDateTime(this.datToDate.DateTime, new TimeSpan(23, 59, 59)),
                //this.datToDate.DateTime,
                new TimeSpan(23, 59, 59),
                "",
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                active);

            var dataMix = _blstDataMix;
            var summaryAGG1 = SumMaterialDetail(
                dataMix,
                x => x.Agg1_Bat,
                x => x.Agg1_Man,
                x => x.Agg1);
            var summaryAGG2 = SumMaterialDetail(
                dataMix,
                x => x.Agg2_Bat,
                x => x.Agg2_Man,
                x => x.Agg2);
            var summaryAGG3 = SumMaterialDetail(
                dataMix,
                x => x.Agg3_Bat,
                x => x.Agg3_Man,
                x => x.Agg3);
            var summaryAGG4 = SumMaterialDetail(
                dataMix,
                x => x.Agg4_Bat,
                x => x.Agg4_Man,
                x => x.Agg4);
            var summaryAGG5 = SumMaterialDetail(
                dataMix,
                x => x.Agg5_Bat,
                x => x.Agg5_Man,
                x => x.Agg5);
            var summaryAGG6 = SumMaterialDetail(
                dataMix,
                x => x.Agg6_Bat,
                x => x.Agg6_Man,
                x => x.Agg6);

            var summaryCE1 = SumMaterialDetail(
                dataMix,
                x => x.Ce1_Bat,
                x => x.Ce1_Man,
                x => x.Ce1);
            var summaryCE2 = SumMaterialDetail(
                dataMix,
                x => x.Ce2_Bat,
                x => x.Ce2_Man,
                x => x.Ce2);
            var summaryCE3 = SumMaterialDetail(
                dataMix,
                x => x.Ce3_Bat,
                x => x.Ce3_Man,
                x => x.Ce3);
            var summaryCE4 = SumMaterialDetail(
                dataMix,
                x => x.Ce4_Bat,
                x => x.Ce4_Man,
                x => x.Ce4);
            var summaryCE5 = SumMaterialDetail(
                dataMix,
                x => x.Ce5_Bat,
                x => x.Ce5_Man,
                x => x.Ce5);
            var summaryWA1 = SumMaterialDetail(
                dataMix,
                x => x.Wa1_Bat,
                x => x.Wa1_Man,
                x => x.Wa1);
            var summaryWA2 = SumMaterialDetail(
                dataMix,
                x => x.Wa2_Bat,
                x => x.Wa2_Man,
                x => x.Wa2);
            var summaryADD1 = SumMaterialDetail(
                dataMix,
                x => x.Add1_Bat,
                x => x.Add1_Man,
                x => x.Add1);
            var summaryADD2 = SumMaterialDetail(
                dataMix,
                x => x.Add2_Bat,
                x => x.Add2_Man,
                x => x.Add2);
            var summaryADD3 = SumMaterialDetail(
                dataMix,
                x => x.Add3_Bat,
                x => x.Add3_Man,
                x => x.Add3);
            var summaryADD4 = SumMaterialDetail(
                dataMix,
                x => x.Add4_Bat,
                x => x.Add4_Man,
                x => x.Add4);
            var summaryADD5 = SumMaterialDetail(
                dataMix,
                x => x.Add5_Bat,
                x => x.Add5_Man,
                x => x.Add5);
            var summaryADD6 = SumMaterialDetail(
                dataMix,
                x => x.Add6_Bat,
                x => x.Add6_Man,
                x => x.Add6);

            var sumKhoiLuong = _blstDataMix.Sum(x => x.KLMe);

            decimal perDecimal_AGG1 = 0;
            decimal perDecimal_AGG2 = 0;
            decimal perDecimal_AGG3 = 0;
            decimal perDecimal_AGG4 = 0;
            decimal perDecimal_AGG5 = 0;
            decimal perDecimal_AGG6 = 0;
            decimal perDecimal_CE1 = 0;
            decimal perDecimal_CE2 = 0;
            decimal perDecimal_CE3 = 0;
            decimal perDecimal_CE4 = 0;
            decimal perDecimal_CE5 = 0;
            decimal perDecimal_WA1 = 0;
            decimal perDecimal_WA2 = 0;
            decimal perDecimal_ADD1 = 0;
            decimal perDecimal_ADD2 = 0;
            decimal perDecimal_ADD3 = 0;
            decimal perDecimal_ADD4 = 0;
            decimal perDecimal_ADD5 = 0;
            decimal perDecimal_ADD6 = 0;

            if (summaryAGG1.Sum_ValueCP == 0)
            {
                perDecimal_AGG1 = 0;
            }
            else
            {
                perDecimal_AGG1 = (summaryAGG1.Sum_ValueCP - summaryAGG1.Sum_ValueBat) * 100 / summaryAGG1.Sum_ValueCP;
            }
            if (summaryAGG2.Sum_ValueCP == 0)
            {
                perDecimal_AGG2 = 0;
            }
            else
            {
                perDecimal_AGG2 = (summaryAGG2.Sum_ValueCP - summaryAGG2.Sum_ValueBat) * 100 / summaryAGG2.Sum_ValueCP;
            }
            if (summaryAGG3.Sum_ValueCP == 0)
            {
                perDecimal_AGG3 = 0;
            }
            else
            {
                perDecimal_AGG3 = (summaryAGG3.Sum_ValueCP - summaryAGG3.Sum_ValueBat) * 100 / summaryAGG3.Sum_ValueCP;
            }
            if (summaryAGG4.Sum_ValueCP == 0)
            {
                perDecimal_AGG4 = 0;
            }
            else
            {
                perDecimal_AGG4 = (summaryAGG4.Sum_ValueCP - summaryAGG4.Sum_ValueBat) * 100 / summaryAGG4.Sum_ValueCP;
            }
            if (summaryAGG5.Sum_ValueCP == 0)
            {
                perDecimal_AGG5 = 0;
            }
            else
            {
                perDecimal_AGG5 = (summaryAGG5.Sum_ValueCP - summaryAGG5.Sum_ValueBat) * 100 / summaryAGG5.Sum_ValueCP;
            }
            if (summaryAGG6.Sum_ValueCP == 0)
            {
                perDecimal_AGG6 = 0;
            }
            else
            {
                perDecimal_AGG6 = (summaryAGG6.Sum_ValueCP - summaryAGG6.Sum_ValueBat) * 100 / summaryAGG6.Sum_ValueCP;
            }
            if (summaryCE1.Sum_ValueCP == 0)
            {
                perDecimal_CE1 = 0;
            }
            else
            {
                perDecimal_CE1 = (summaryCE1.Sum_ValueCP - summaryCE1.Sum_ValueBat) * 100 / summaryCE1.Sum_ValueCP;
            }
            if (summaryCE2.Sum_ValueCP == 0)
            {
                perDecimal_CE2 = 0;
            }
            else
            {
                perDecimal_CE2 = (summaryCE2.Sum_ValueCP - summaryCE2.Sum_ValueBat) * 100 / summaryCE2.Sum_ValueCP;
            }
            if (summaryCE3.Sum_ValueCP == 0)
            {
                perDecimal_CE3 = 0;
            }
            else
            {
                perDecimal_CE3 = (summaryCE3.Sum_ValueCP - summaryCE3.Sum_ValueBat) * 100 / summaryCE3.Sum_ValueCP;
            }
            if (summaryCE4.Sum_ValueCP == 0)
            {
                perDecimal_CE4 = 0;
            }
            else
            {
                perDecimal_CE4 = (summaryCE4.Sum_ValueCP - summaryCE4.Sum_ValueBat) * 100 / summaryCE4.Sum_ValueCP;
            }
            if (summaryCE5.Sum_ValueCP == 0)
            {
                perDecimal_CE5 = 0;
            }
            else
            {
                perDecimal_CE5 = (summaryCE5.Sum_ValueCP - summaryCE5.Sum_ValueBat) * 100 / summaryCE5.Sum_ValueCP;
            }
            if (summaryWA1.Sum_ValueCP == 0)
            {
                perDecimal_WA1 = 0;
            }
            else
            {
                perDecimal_WA1 = (summaryWA1.Sum_ValueCP - summaryWA1.Sum_ValueBat) * 100 / summaryWA1.Sum_ValueCP;
            }
            if (summaryWA2.Sum_ValueCP == 0)
            {
                perDecimal_WA2 = 0;
            }
            else
            {
                perDecimal_WA2 = (summaryWA2.Sum_ValueCP - summaryWA2.Sum_ValueBat) * 100 / summaryWA2.Sum_ValueCP;
            }
            if (summaryADD1.Sum_ValueCP == 0)
            {
                perDecimal_ADD1 = 0;
            }
            else
            {
                perDecimal_ADD1 = (summaryADD1.Sum_ValueCP - summaryADD1.Sum_ValueBat) * 100 / summaryADD1.Sum_ValueCP;
            }
            if (summaryADD2.Sum_ValueCP == 0)
            {
                perDecimal_ADD2 = 0;
            }
            else
            {
                perDecimal_ADD2 = (summaryADD2.Sum_ValueCP - summaryADD2.Sum_ValueBat) * 100 / summaryADD2.Sum_ValueCP;
            }
            if (summaryADD3.Sum_ValueCP == 0)
            {
                perDecimal_ADD3 = 0;
            }
            else
            {
                perDecimal_ADD3 = (summaryADD3.Sum_ValueCP - summaryADD3.Sum_ValueBat) * 100 / summaryADD3.Sum_ValueCP;
            }
            if (summaryADD4.Sum_ValueCP == 0)
            {
                perDecimal_ADD4 = 0;
            }
            else
            {
                perDecimal_ADD4 = (summaryADD4.Sum_ValueCP - summaryADD4.Sum_ValueBat) * 100 / summaryADD4.Sum_ValueCP;
            }
            if (summaryADD5.Sum_ValueCP == 0)
            {
                perDecimal_ADD5 = 0;
            }
            else
            {
                perDecimal_ADD5 = (summaryADD5.Sum_ValueCP - summaryADD5.Sum_ValueBat) * 100 / summaryADD5.Sum_ValueCP;
            }
            if (summaryADD6.Sum_ValueCP == 0)
            {
                perDecimal_ADD6 = 0;
            }
            else
            {
                perDecimal_ADD6 = (summaryADD6.Sum_ValueCP - summaryADD6.Sum_ValueBat) * 100 / summaryADD6.Sum_ValueCP;
            }
            var list_Agg = new List<ObjMaterialSummary>();
            switch (num_silo_Agg)
            {
                case 1:
                    list_Agg.Add(CreateMaterialSummary(1, GetMaterialCode("Agg1"), GetMaterialName("Agg1"), summaryAGG1,
                        perDecimal_AGG1, false));
                   
                    break;
                case 2:
                    list_Agg.Add(CreateMaterialSummary(1, GetMaterialCode("Agg1"), GetMaterialName("Agg1"), summaryAGG1,
                        perDecimal_AGG1, false));
                    list_Agg.Add(CreateMaterialSummary(2, GetMaterialCode("Agg2"), GetMaterialName("Agg2"), summaryAGG2,
                        perDecimal_AGG2, false));
                    break;
                case 3:
                    list_Agg.Add(CreateMaterialSummary(1, GetMaterialCode("Agg1"), GetMaterialName("Agg1"), summaryAGG1,
                        perDecimal_AGG1, false));
                    list_Agg.Add(CreateMaterialSummary(2, GetMaterialCode("Agg2"), GetMaterialName("Agg2"), summaryAGG2,
                        perDecimal_AGG2, false));
                    list_Agg.Add(CreateMaterialSummary(3, GetMaterialCode("Agg3"), GetMaterialName("Agg3"), summaryAGG3,
                        perDecimal_AGG3, false));
                    break;
                case 4:
                    list_Agg.Add(CreateMaterialSummary(1, GetMaterialCode("Agg1"), GetMaterialName("Agg1"), summaryAGG1,
                        perDecimal_AGG1, false));
                    list_Agg.Add(CreateMaterialSummary(2, GetMaterialCode("Agg2"), GetMaterialName("Agg2"), summaryAGG2,
                        perDecimal_AGG2, false));
                    list_Agg.Add(CreateMaterialSummary(3, GetMaterialCode("Agg3"), GetMaterialName("Agg3"), summaryAGG3,
                        perDecimal_AGG3, false));
                    list_Agg.Add(CreateMaterialSummary(4, GetMaterialCode("Agg4"), GetMaterialName("Agg4"), summaryAGG4,
                        perDecimal_AGG4, false));
                    break;
                case 5:
                    list_Agg.Add(CreateMaterialSummary(1, GetMaterialCode("Agg1"), GetMaterialName("Agg1"), summaryAGG1,
                        perDecimal_AGG1, false));
                    list_Agg.Add(CreateMaterialSummary(2, GetMaterialCode("Agg2"), GetMaterialName("Agg2"), summaryAGG2,
                        perDecimal_AGG2, false));
                    list_Agg.Add(CreateMaterialSummary(3, GetMaterialCode("Agg3"), GetMaterialName("Agg3"), summaryAGG3,
                        perDecimal_AGG3, false));
                    list_Agg.Add(CreateMaterialSummary(4, GetMaterialCode("Agg4"), GetMaterialName("Agg4"), summaryAGG4,
                        perDecimal_AGG4, false));
                    list_Agg.Add(CreateMaterialSummary(5, GetMaterialCode("Agg5"), GetMaterialName("Agg5"), summaryAGG5,
                        perDecimal_AGG5, false));

                    break;
                case 6:
                    list_Agg.Add(CreateMaterialSummary(1, GetMaterialCode("Agg1"), GetMaterialName("Agg1"), summaryAGG1, perDecimal_AGG1, false));
                    list_Agg.Add(CreateMaterialSummary(2, GetMaterialCode("Agg2"), GetMaterialName("Agg2"), summaryAGG2, perDecimal_AGG2, false));
                    list_Agg.Add(CreateMaterialSummary(3, GetMaterialCode("Agg3"), GetMaterialName("Agg3"), summaryAGG3, perDecimal_AGG3, false));
                    list_Agg.Add(CreateMaterialSummary(4, GetMaterialCode("Agg4"), GetMaterialName("Agg4"), summaryAGG4, perDecimal_AGG4, false));
                    list_Agg.Add(CreateMaterialSummary(5, GetMaterialCode("Agg5"),  GetMaterialName("Agg5"), summaryAGG5,  perDecimal_AGG5, false));
                    list_Agg.Add(CreateMaterialSummary(6, GetMaterialCode("Agg6"), GetMaterialName("Agg6"), summaryAGG6, perDecimal_AGG6, false));

                    break;
            }
            var list_Ce = new List<ObjMaterialSummary>();
            switch (num_silo_Ce)
            {
                case 1:
                    list_Ce.Add(CreateMaterialSummary(7, GetMaterialCode("Ce1"), GetMaterialName("Ce1"), summaryCE1, perDecimal_CE1, false));
                    break;
                case 2:
                    list_Ce.Add(CreateMaterialSummary(7, GetMaterialCode("Ce1"), GetMaterialName("Ce1"), summaryCE1, perDecimal_CE1, false));
                    list_Ce.Add(CreateMaterialSummary(8, GetMaterialCode("Ce2"), GetMaterialName("Ce2"), summaryCE2, perDecimal_CE2, false));

                    break;
                case 3:
                    list_Ce.Add(CreateMaterialSummary(7, GetMaterialCode("Ce1"), GetMaterialName("Ce1"), summaryCE1, perDecimal_CE1, false));
                    list_Ce.Add(CreateMaterialSummary(8, GetMaterialCode("Ce2"), GetMaterialName("Ce2"), summaryCE2, perDecimal_CE2, false));
                    list_Ce.Add(CreateMaterialSummary(9, GetMaterialCode("Ce3"), GetMaterialName("Ce3"), summaryCE3, perDecimal_CE3, false));

                    break;
                case 4:
                    list_Ce.Add(CreateMaterialSummary(7, GetMaterialCode("Ce1"), GetMaterialName("Ce1"), summaryCE1, perDecimal_CE1, false));
                    list_Ce.Add(CreateMaterialSummary(8, GetMaterialCode("Ce2"), GetMaterialName("Ce2"), summaryCE2, perDecimal_CE2, false));
                    list_Ce.Add(CreateMaterialSummary(9, GetMaterialCode("Ce3"), GetMaterialName("Ce3"), summaryCE3, perDecimal_CE3, false));
                    list_Ce.Add(CreateMaterialSummary(10,GetMaterialCode("Ce4"), GetMaterialName("Ce4"), summaryCE4,perDecimal_CE4,  false));

                    break;
                case 5:
                    list_Ce.Add(CreateMaterialSummary(7, GetMaterialCode("Ce1"), GetMaterialName("Ce1"), summaryCE1, perDecimal_CE1, false));
                    list_Ce.Add(CreateMaterialSummary(8, GetMaterialCode("Ce2"), GetMaterialName("Ce2"), summaryCE2, perDecimal_CE2, false));
                    list_Ce.Add(CreateMaterialSummary(9, GetMaterialCode("Ce3"), GetMaterialName("Ce3"), summaryCE3, perDecimal_CE3, false));
                    list_Ce.Add(CreateMaterialSummary(10,GetMaterialCode("Ce4"), GetMaterialName("Ce4"), summaryCE4,perDecimal_CE4,  false));
                    list_Ce.Add(CreateMaterialSummary(11,GetMaterialCode("Ce5"), GetMaterialName("Ce5"), summaryCE5, perDecimal_CE5, false));

                    break;
            }

            var list_Wa = new List<ObjMaterialSummary>();
            switch (num_silo_Wa)
            {
                case 1:
                    list_Wa.Add(CreateMaterialSummary(12, GetMaterialCode("Wa1"), GetMaterialName("Wa1"), summaryWA1, perDecimal_WA1, false));
                    break;
                case 2:
                    list_Wa.Add(CreateMaterialSummary(12, GetMaterialCode("Wa1"), GetMaterialName("Wa1"), summaryWA1, perDecimal_WA1, false));
                    list_Wa.Add(CreateMaterialSummary(13, GetMaterialCode("Wa2"), GetMaterialName("Wa2"), summaryWA2, perDecimal_WA2, false));
                    break;
                
            }
            var list_Add = new List<ObjMaterialSummary>();
            switch (num_silo_Add)
            {
                case 1:
                    list_Add.Add(CreateMaterialSummary(14, GetMaterialCode("Add1"), GetMaterialName("Add1"), summaryADD1, perDecimal_ADD1, false));
                    break;
                case 2:
                    list_Add.Add(CreateMaterialSummary(14, GetMaterialCode("Add1"), GetMaterialName("Add1"), summaryADD1, perDecimal_ADD1, false));
                    list_Add.Add(CreateMaterialSummary(15, GetMaterialCode("Add2"), GetMaterialName("Add2"), summaryADD2, perDecimal_ADD2, false));

                    break;
                case 3:
                    list_Add.Add(CreateMaterialSummary(14, GetMaterialCode("Add1"), GetMaterialName("Add1"), summaryADD1, perDecimal_ADD1, false));
                    list_Add.Add(CreateMaterialSummary(15, GetMaterialCode("Add2"), GetMaterialName("Add2"), summaryADD2, perDecimal_ADD2, false));
                    list_Add.Add(CreateMaterialSummary(16, GetMaterialCode("Add3"), GetMaterialName("Add3"), summaryADD3, perDecimal_ADD3, false));

                    break;
                case 4:
                    list_Add.Add(CreateMaterialSummary(14, GetMaterialCode("Add1"), GetMaterialName("Add1"), summaryADD1, perDecimal_ADD1, false));
                    list_Add.Add(CreateMaterialSummary(15, GetMaterialCode("Add2"), GetMaterialName("Add2"), summaryADD2, perDecimal_ADD2, false));
                    list_Add.Add(CreateMaterialSummary(16, GetMaterialCode("Add3"), GetMaterialName("Add3"), summaryADD3, perDecimal_ADD3, false));
                    list_Add.Add(CreateMaterialSummary(17, GetMaterialCode("Add4"), GetMaterialName("Add4"), summaryADD4, perDecimal_ADD4, false));

                    break;
                case 5:
                    list_Add.Add(CreateMaterialSummary(14, GetMaterialCode("Add1"), GetMaterialName("Add1"), summaryADD1, perDecimal_ADD1, false));
                    list_Add.Add(CreateMaterialSummary(15, GetMaterialCode("Add2"), GetMaterialName("Add2"), summaryADD2, perDecimal_ADD2, false));
                    list_Add.Add(CreateMaterialSummary(16, GetMaterialCode("Add3"), GetMaterialName("Add3"), summaryADD3, perDecimal_ADD3, false));
                    list_Add.Add(CreateMaterialSummary(17, GetMaterialCode("Add4"), GetMaterialName("Add4"), summaryADD4, perDecimal_ADD4, false));
                    list_Add.Add(CreateMaterialSummary(18, GetMaterialCode("Add5"), GetMaterialName("Add5"), summaryADD5, perDecimal_ADD5, false));

                    break;
                case 6:
                    list_Add.Add(CreateMaterialSummary(14, GetMaterialCode("Add1"), GetMaterialName("Add1"), summaryADD1, perDecimal_ADD1, false));
                    list_Add.Add(CreateMaterialSummary(15, GetMaterialCode("Add2"), GetMaterialName("Add2"), summaryADD2, perDecimal_ADD2, false));
                    list_Add.Add(CreateMaterialSummary(16, GetMaterialCode("Add3"), GetMaterialName("Add3"), summaryADD3, perDecimal_ADD3, false));
                    list_Add.Add(CreateMaterialSummary(17, GetMaterialCode("Add4"), GetMaterialName("Add4"), summaryADD4, perDecimal_ADD4, false));
                    list_Add.Add(CreateMaterialSummary(18, GetMaterialCode("Add5"), GetMaterialName("Add5"), summaryADD5, perDecimal_ADD5, false));
                    list_Add.Add(CreateMaterialSummary(19, GetMaterialCode("Add6"), GetMaterialName("Add6"), summaryADD6, perDecimal_ADD6, false));

                    break;
            }

            var materialSummaries = new List<ObjMaterialSummary>();
            foreach (var obj in list_Agg)
            {
                materialSummaries.Add(obj);
            }
            foreach (var obj in list_Ce)
            {
                materialSummaries.Add(obj);
            }
            foreach (var obj in list_Wa)
            {
                materialSummaries.Add(obj);
            }
            foreach (var obj in list_Add)
            {
                materialSummaries.Add(obj);
            }

            this.txtSoKhoi.Text = sumKhoiLuong.ToString();
            this.grcTongVatTu.DataSource = materialSummaries;
            //Console.WriteLine(list);
            // Task.Run(() => LoadData_DetailDay());
        }

       
        private string GetMaterialName(string maSilo)
        {
            string name = "";
            foreach (ObjSilo objSilo in this._blstSilo)
            {
                if (objSilo.MaSilo == maSilo)
                {
                    switch (objSilo.MaSilo)
                    {
                        case "Agg1":
                            name = objSilo.MaterialName;
                            break;
                        case "Agg2":
                            name = objSilo.MaterialName;
                            break;
                        case "Agg3":
                            name = objSilo.MaterialName;
                            break;
                        case "Agg4":
                            name = objSilo.MaterialName;
                            break;
                        case "Agg5":
                            name = objSilo.MaterialName;
                            break;
                        case "Agg6":
                            name = objSilo.MaterialName;
                            break;
                        case "Ce1":
                            name = objSilo.MaterialName;
                            break;
                        case "Ce2":
                            name = objSilo.MaterialName;
                            break;
                        case "Ce3":
                            name = objSilo.MaterialName;
                            break;
                        case "Ce4":
                            name = objSilo.MaterialName;
                            break;
                        case "Ce5":
                            name = objSilo.MaterialName;
                            break;
                        case "Wa1":
                            name = objSilo.MaterialName;
                            break;
                        case "Wa2":
                            name = objSilo.MaterialName;
                            break;
                        case "Add1":
                            name = objSilo.MaterialName;
                            break;
                        case "Add2":
                            name = objSilo.MaterialName;
                            break;
                        case "Add3":
                            name = objSilo.MaterialName;
                            break;
                        case "Add4":
                            name = objSilo.MaterialName;
                            break;
                        case "Add5":
                            name = objSilo.MaterialName;
                            break;
                        case "Add6":
                            name = objSilo.MaterialName;
                            break;

                    }
                }
               
            }

            return name;
        }
        private string GetMaterialCode(string maSilo)
        {
            string name = "";
            foreach (ObjSilo objSilo in this._blstSilo)
            {
                if (objSilo.MaSilo == maSilo)
                {
                    switch (objSilo.MaSilo)
                    {
                        case "Agg1":
                            name = objSilo.MaterialCode;
                            break;
                        case "Agg2":
                            name = objSilo.MaterialCode;
                            break;
                        case "Agg3":
                            name = objSilo.MaterialCode;
                            break;
                        case "Agg4":
                            name = objSilo.MaterialCode;
                            break;
                        case "Agg5":
                            name = objSilo.MaterialCode;
                            break;
                        case "Agg6":
                            name = objSilo.MaterialCode;
                            break;
                        case "Ce1":
                            name = objSilo.MaterialCode;
                            break;
                        case "Ce2":
                            name = objSilo.MaterialCode;
                            break;
                        case "Ce3":
                            name = objSilo.MaterialCode;
                            break;
                        case "Ce4":
                            name = objSilo.MaterialCode;
                            break;
                        case "Ce5":
                            name = objSilo.MaterialCode;
                            break;
                        case "Wa1":
                            name = objSilo.MaterialCode;
                            break;
                        case "Wa2":
                            name = objSilo.MaterialCode;
                            break;
                        case "Add1":
                            name = objSilo.MaterialCode;
                            break;
                        case "Add2":
                            name = objSilo.MaterialCode;
                            break;
                        case "Add3":
                            name = objSilo.MaterialCode;
                            break;
                        case "Add4":
                            name = objSilo.MaterialCode;
                            break;
                        case "Add5":
                            name = objSilo.MaterialCode;
                            break;
                        case "Add6":
                            name = objSilo.MaterialCode;
                            break;

                    }
                }
               
            }

            return name;
        }
        public ObjMaterialSummary CreateMaterialSummary(
            int materialID,
            string materialCode,
            string materialName,
            ObjMaterialDetailSumary detailSummary,
            decimal perDecimal,
            bool isManual)
        {
            return new ObjMaterialSummary
            {
                MaterialID = materialID,
                MaterialCode = materialCode,
                MaterialName = materialName,
                Sum_ValueCP = detailSummary.Sum_ValueCP,
                Sum_ValueBat = detailSummary.Sum_ValueBat,
                Sum_ValueBatMan = detailSummary.Sum_ValueBatMan,
                SaiSo = detailSummary.Sum_ValueCP - detailSummary.Sum_ValueBat,
                //SaiSo = 0,
                //PerSaiSo = (detailSummary.Sum_ValueCP - detailSummary.Sum_ValueBat)*100/ detailSummary.Sum_ValueCP,
                PerSaiSo = perDecimal,
                IsManual = isManual
            };
        }
        public ObjMaterialDetailSumary SumMaterialDetail(
            BindingList<Objvw_DataMix> dataMix,
            Func<Objvw_DataMix, decimal?> valueBatSelector,
            Func<Objvw_DataMix, decimal?> valueBatManSelector,
            Func<Objvw_DataMix, decimal?> valueCPSelector)
        {
            var summary = new ObjMaterialDetailSumary
            {
                Sum_ValueBat = dataMix.Sum(x => valueBatSelector(x) ?? 0),
                Sum_ValueBatMan = dataMix.Sum(x => valueBatManSelector(x) ?? 0),
                Sum_ValueCP = dataMix.Sum(x => valueCPSelector(x) ?? 0)
            };

            return summary;
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

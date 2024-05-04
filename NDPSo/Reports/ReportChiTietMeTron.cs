using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using NDPSo.ClientSetting;
using NDPSo.Data;
using NDPSo.MasterData;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.Reports
{
    public partial class ReportChiTietMeTron : ControlViewBase, IDataMixMngView, IBase, IPermission
    {
        private DataMixMngDataPresenter _presenter;
        public BindingList<Objvw_DataMix> _blstDataMix = new BindingList<Objvw_DataMix>();
        public BindingList<ObjKhachHang> _blstKH = new BindingList<ObjKhachHang>();
        public BindingList<ObjCongTruong> _blstCT = new BindingList<ObjCongTruong>();
        public BindingList<ObjHangMuc> _blstHM = new BindingList<ObjHangMuc>();
        public BindingList<ObjMAC> _blstMAC = new BindingList<ObjMAC>();
        public BindingList<ObjSilo> _blstSilo = new BindingList<ObjSilo>();
        public BindingList<ObjXe> _blstXe = new BindingList<ObjXe>();
        public BindingList<ObjTaiXe> _blstTX = new BindingList<ObjTaiXe>();
        public BindingList<ObjNhanVien> _blstNV = new BindingList<ObjNhanVien>();
        public BindingList<ObjSEC_User> _blstUser = new BindingList<ObjSEC_User>();
        private List<FieldCode> _lstDataMixStatus = new List<FieldCode>();

        public BindingList<Objvw_DataMix> BLstDataMix
        {
            set
            {
                this._blstDataMix = value;
                //this.gridControl1.DataSource = (object)this._blstDataMix;
            }
        }

        private void UpdateUI(BindingList<Objvw_DataMix> result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(result)));
                return;
            }

            this.gridControl1.DataSource = result;
        }


        public BindingList<ObjKhachHang> BLstKhachHang
        {
            set
            {
                this._blstKH = value;
                this.lueKhachHang.Properties.DataSource = (object)this._blstKH;
            }
        }
        public BindingList<ObjCongTruong> BLstCongTruong
        {
            set
            {
                this._blstCT = value;
                this.lueCongTruong.Properties.DataSource = (object)this._blstCT;
            }
        }
        public BindingList<ObjHangMuc> BLstHangMuc
        {
            set
            {
                this._blstHM = value;
                this.lueHangMuc.Properties.DataSource = (object)this._blstHM;
            }
        }
        public BindingList<ObjMAC> BLstMAC
        {
            set
            {
                this._blstMAC = value;
                this.lueMAC.Properties.DataSource = (object)this._blstMAC;
            }
        }
        public BindingList<ObjXe> BLstXe
        {
            set
            {
                this._blstXe = value;
                this.lueBienSo.Properties.DataSource = (object)this._blstXe;
            }
        }
        public BindingList<ObjTaiXe> BLstTaiXe
        {
            set
            {
                this._blstTX = value;
                this.lueTaiXe.Properties.DataSource = (object)this._blstTX;
            }
        }
        public BindingList<ObjNhanVien> BLstNhanVien
        {
            set
            {
                this._blstNV = value;
                //this.lueNhanVien.Properties.DataSource = (object)this._blstNV;
            }
        }

        public List<FieldCode> LstDataMixStatus 
        { 
            set
            {
                _lstDataMixStatus = value;
                this.ilueDMStatus.DataSource = (object)this._lstDataMixStatus;
                this.iicbStatus.Items.Clear();
                this.iicbStatus.Items.Add(new ImageComboBoxItem(((DisplayAttribute)Attribute.GetCustomAttribute(typeof(Enums.SimMode).GetField(Enums.SimMode.Normal.ToString()), typeof(DisplayAttribute)))?.Name, (object)true, 0));
                this.iicbStatus.Items.Add(new ImageComboBoxItem(((DisplayAttribute)Attribute.GetCustomAttribute(typeof(Enums.SimMode).GetField(Enums.SimMode.Sim.ToString()), typeof(DisplayAttribute)))?.Name, (object)false, 1));
            }
        }

        public BindingList<ObjSilo> BLstSilo 
        {
            set
            {
                this._blstSilo = value;
            }
        }

        public ReportChiTietMeTron()
        {
            InitializeComponent();
            this.Caption = "Chi tiết mẻ trộn";
            this._presenter = new DataMixMngDataPresenter((IDataMixMngView)this);
            this._presenter.ListKhachHang();
            this._presenter.ListCongTruong();
            this._presenter.ListHangMuc();
            this._presenter.ListMAC();
            this._presenter.ListSilo();
            this._presenter.ListXe();
            this._presenter.ListTaiXe();
            this._presenter.ListNhanVien();
            this._presenter.ListDataMixStatus();

            IServices factory = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
            List<ObjSEC_User> lstT = factory.ListSEC_User() as List<ObjSEC_User>;
            this.lueNhanVien.Properties.DataSource = (object)Converter.ConvertToBindingList<ObjSEC_User>(lstT);
        }


       
        protected override void PopulateStaticData()
        {
            this.lueCheDo.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.SimMode>(true);
            int num_silo_Agg;
            num_silo_Agg = ConfigManager.TramTronConfig.SL_Silo_AGG;
            if (num_silo_Agg == 0)
                num_silo_Agg = 1;
            int num_silo_Ce;
            num_silo_Ce = ConfigManager.TramTronConfig.SL_Silo_CE;
            if (num_silo_Ce == 0)
                num_silo_Ce = 1;
            int num_silo_Wa;
            num_silo_Wa = ConfigManager.TramTronConfig.SL_Silo_WA;
            if (num_silo_Wa == 0)
                num_silo_Wa = 1;
            int num_silo_Add;
            num_silo_Add = ConfigManager.TramTronConfig.SL_Silo_ADD;
            if (num_silo_Add == 0)
                num_silo_Add = 0;
            CreateTaableData(num_silo_Agg, num_silo_Ce, num_silo_Wa, num_silo_Add);
            LoadSearchDefaultValues();

        }
        private void CreateTaableData(int numAgg, int numCe, int numWa, int numAdd)
        {
            try
            {
                foreach(ObjSilo objSilo in this._blstSilo)
                {
                    switch (objSilo.MaSilo)
                    {
                        case "Agg1":
                            this.bandedGridView1.Bands["Agg1"].Caption = objSilo.MaterialName;
                            break;
                        case "Agg2":
                            this.bandedGridView1.Bands["Agg2"].Caption = objSilo.MaterialName;
                            break;
                        case "Agg3":
                            this.bandedGridView1.Bands["Agg3"].Caption = objSilo.MaterialName;
                            break;
                        case "Agg4":
                            this.bandedGridView1.Bands["Agg4"].Caption = objSilo.MaterialName;
                            break;
                        case "Agg5":
                            this.bandedGridView1.Bands["Agg5"].Caption = objSilo.MaterialName;
                            break;
                        case "Agg6":
                            this.bandedGridView1.Bands["Agg6"].Caption = objSilo.MaterialName;
                            break;
                        case "Ce1":
                            this.bandedGridView1.Bands["Ce1"].Caption = objSilo.MaterialName;
                            break;
                        case "Ce2":
                            this.bandedGridView1.Bands["Ce2"].Caption = objSilo.MaterialName;
                            break;
                        case "Ce3":
                            this.bandedGridView1.Bands["Ce3"].Caption = objSilo.MaterialName;
                            break;
                        case "Ce4":
                            this.bandedGridView1.Bands["Ce4"].Caption = objSilo.MaterialName;
                            break;
                        case "Ce5":
                            this.bandedGridView1.Bands["Ce5"].Caption = objSilo.MaterialName;
                            break;
                        case "Wa1":
                            this.bandedGridView1.Bands["Wa1"].Caption = objSilo.MaterialName;
                            break;
                        case "Wa2":
                            this.bandedGridView1.Bands["Wa2"].Caption = objSilo.MaterialName;
                            break;
                        case "Add1":
                            this.bandedGridView1.Bands["Add1"].Caption = objSilo.MaterialName;
                            break;
                        case "Add2":
                            this.bandedGridView1.Bands["Add2"].Caption = objSilo.MaterialName;
                            break;
                        case "Add3":
                            this.bandedGridView1.Bands["Add3"].Caption = objSilo.MaterialName;
                            break;
                        case "Add4":
                            this.bandedGridView1.Bands["Add4"].Caption = objSilo.MaterialName;
                            break;
                        case "Add5":
                            this.bandedGridView1.Bands["Add5"].Caption = objSilo.MaterialName;
                            break;
                        case "Add6":
                            this.bandedGridView1.Bands["Add6"].Caption = objSilo.MaterialName;
                            break;

                    }
                }

            }
            catch(Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }

            List<DevExpress.XtraGrid.Views.BandedGrid.GridBand> bandListAgg = new List<DevExpress.XtraGrid.Views.BandedGrid.GridBand>();
            bandListAgg.Add(this.bandedGridView1.Bands["Agg1"]);
            bandListAgg.Add(this.bandedGridView1.Bands["Agg2"]);
            bandListAgg.Add(this.bandedGridView1.Bands["Agg3"]);
            bandListAgg.Add(this.bandedGridView1.Bands["Agg4"]);
            bandListAgg.Add(this.bandedGridView1.Bands["Agg5"]);
            bandListAgg.Add(this.bandedGridView1.Bands["Agg6"]);
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in bandListAgg)
            {
                band.Visible = false;
            }
            for (int i = 0; i < numAgg; i++)
            {
                bandListAgg[i].Visible = true;
            }

            List<DevExpress.XtraGrid.Views.BandedGrid.GridBand> bandListCe = new List<DevExpress.XtraGrid.Views.BandedGrid.GridBand>();
            bandListCe.Add(this.bandedGridView1.Bands["Ce1"]);
            bandListCe.Add(this.bandedGridView1.Bands["Ce2"]);
            bandListCe.Add(this.bandedGridView1.Bands["Ce3"]);
            bandListCe.Add(this.bandedGridView1.Bands["Ce4"]);
            bandListCe.Add(this.bandedGridView1.Bands["Ce5"]);
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in bandListCe)
            {
                band.Visible = false;
            }
            for (int i = 0; i < numCe; i++)
            {
                bandListCe[i].Visible = true;
            }

            List<DevExpress.XtraGrid.Views.BandedGrid.GridBand> bandListWa = new List<DevExpress.XtraGrid.Views.BandedGrid.GridBand>();
            bandListWa.Add(this.bandedGridView1.Bands["Wa1"]);
            bandListWa.Add(this.bandedGridView1.Bands["Wa2"]);
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in bandListWa)
            {
                band.Visible = false;
            }
            for (int i = 0; i < numWa; i++)
            {
                bandListWa[i].Visible = true;
            }

            List<DevExpress.XtraGrid.Views.BandedGrid.GridBand> bandListAdd = new List<DevExpress.XtraGrid.Views.BandedGrid.GridBand>();
            bandListAdd.Add(this.bandedGridView1.Bands["Add1"]);
            bandListAdd.Add(this.bandedGridView1.Bands["Add2"]);
            bandListAdd.Add(this.bandedGridView1.Bands["Add3"]);
            bandListAdd.Add(this.bandedGridView1.Bands["Add4"]);
            bandListAdd.Add(this.bandedGridView1.Bands["Add5"]);
            bandListAdd.Add(this.bandedGridView1.Bands["Add6"]);
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in bandListAdd)
            {
                band.Visible = false;
            }
            for (int i = 0; i < numAdd; i++)
            {
                bandListAdd[i].Visible = true;
            }

        }

        private void LoadDataMix()
        {
            try
            {
                //SplashScreenManager.ShowForm(typeof(NDPWaitForm));
                //SplashScreenManager.Default.SetWaitFormCaption(GlobalValues.Messages.WAIT_CAPTION);
                //SplashScreenManager.Default.SetWaitFormDescription(GlobalValues.Messages.WAIT_LOADING);
                bool? active = new bool?();
                if (Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                    active = new bool?(false);
                else if (Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                    active = new bool?(true);

                /*this._presenter.ListDataMix_ByCondition(
                    Searching.BuildNew_StartDateTime(this.datFromDate.DateTime, this.tseFromTime.TimeSpan),
                    //this.datFromDate.DateTime,
                    this.tseFromTime.TimeSpan,
                    Searching.BuildNew_EndDateTime(this.datToDate.DateTime, this.tseToTime.TimeSpan),
                    //this.datToDate.DateTime,
                    this.tseToTime.TimeSpan,
                    this.txtMaPhieuTron.Text,
                    (int?)this.lueKhachHang.EditValue,
                    (int?)this.lueCongTruong.EditValue,
                    (int?)this.lueHangMuc.EditValue,
                    (int?)this.lueMAC.EditValue,
                    (int?)this.lueBienSo.EditValue,
                    (int?)this.lueTaiXe.EditValue,
                    (int?)this.lueNhanVien.EditValue,
                active);*/
                _blstDataMix = this._presenter.ListDataMix_ByCondition_re(
                    Searching.BuildNew_StartDateTime(this.datFromDate.DateTime, this.tseFromTime.TimeSpan),
                    //this.datFromDate.DateTime,
                    this.tseFromTime.TimeSpan,
                    Searching.BuildNew_EndDateTime(this.datToDate.DateTime, this.tseToTime.TimeSpan),
                    //this.datToDate.DateTime,
                    this.tseToTime.TimeSpan,
                    this.txtMaPhieuTron.Text,
                    (int?)this.lueKhachHang.EditValue,
                    (int?)this.lueCongTruong.EditValue,
                    (int?)this.lueHangMuc.EditValue,
                    (int?)this.lueMAC.EditValue,
                    (int?)this.lueBienSo.EditValue,
                    (int?)this.lueTaiXe.EditValue,
                    (int?)this.lueNhanVien.EditValue,
                active);
                Invoke(new Action(() => UpdateUI(_blstDataMix)));
            
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message);
                TramTromMessageBox.ShowMessageDialog(ex.Message);
            }
            finally
            {
                //SplashScreenManager.CloseForm();
            }

        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)DateTime.Now.AddDays(-(double)ConfigManager.TramTronConfig.LatestBaoCaoDays);
            this.datToDate.EditValue = (object)DateTime.Now;
            this.tseFromTime.EditValue = TimeSpan.Zero;
            this.tseToTime.EditValue = new TimeSpan(23, 59, 59);
            this.txtMaPhieuTron.Text = string.Empty;
            this.lueKhachHang.EditValue = (object)null;
            this.lueCongTruong.EditValue = (object)null;
            this.lueHangMuc.EditValue = (object)null;
            this.lueMAC.EditValue = (object)null;
            this.lueBienSo.EditValue = (object)null;
            this.lueTaiXe.EditValue = (object)null;
            this.lueNhanVien.EditValue = (object)null;
            this.lueCheDo.EditValue = (object)-1;
        }
        protected override void PopulateData()
        {
            //this.LoadDataMix();
            //LoadDataMix();
            Task.Run(() => LoadDataMix());
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadSearchDefaultValues();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Task.Run(() => LoadDataMix());
        }
        
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "BÁO CÁO CHI TIẾT MẺ TRỘN";
                string str = string.Format("Từ ngày: {0} - đến ngày: {1}", (object)FormatToString.DateTimeToString(this.datFromDate.DateTime), (object)FormatToString.DateTimeToString(this.datToDate.DateTime));
                string str2 = string.Format("Khách hàng: {0}", (object)this.lueKhachHang.Text);
                string str3 = string.Format("Công trường: {0}", (object)this.lueCongTruong.Text );
                string str4 = string.Format("Hạng mục: {0}", (object)this.lueHangMuc.Text );
                string str5 = string.Format("MAC: {0}", (object)this.lueMAC.Text );
                string str6 = string.Format("Tài xế: {0}", (object)this.lueTaiXe.Text );
                string str7 = string.Format("Biển số: {0}", (object)this.lueBienSo.Text );
                string str8 = string.Format("Nhân viên: {0}", (object)this.lueNhanVien.Text );
                
                List<string> lst = new List<string>();
                lst.Add(str);
                if(this.lueKhachHang.EditValue != (object)null)
                    lst.Add(str2);
                if(this.lueCongTruong.EditValue != (object)null)
                    lst.Add(str3);
                if(this.lueHangMuc.EditValue != (object)null)
                    lst.Add(str4);
                if (this.lueMAC.EditValue != (object)null)
                    lst.Add(str5);
                if (this.lueTaiXe.EditValue != (object)null)
                    lst.Add(str6);
                if (this.lueBienSo.EditValue != (object)null)
                    lst.Add(str7);
                if (this.lueNhanVien.EditValue != (object)null)
                    lst.Add(str8);

                new Helpper().ExportExcelWithHeader(true, (IPrintable)this.gridControl1, true, true, title, lst);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bandedGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            //SplashScreenManager.CloseForm();
        }
    }
}

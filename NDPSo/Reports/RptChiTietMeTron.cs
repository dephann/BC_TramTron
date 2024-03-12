using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraSplashScreen;
using NDPSo.ClientSetting;
using NDPSo.Data;
using NDPSo.MasterData;
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
    public partial class RptChiTietMeTron : ControlViewBase, IDataMixMngView, IBase, IPermission
    {
        private IServices _ser = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
        private DataMixMngDataPresenter _presenter;
        public BindingList<Objvw_DataMix> _blstDataMix = new BindingList<Objvw_DataMix>();
        public BindingList<ObjKhachHang> _blstKH = new BindingList<ObjKhachHang>();
        public BindingList<ObjCongTruong> _blstCT = new BindingList<ObjCongTruong>();
        public BindingList<ObjHangMuc> _blstHM = new BindingList<ObjHangMuc>();
        public BindingList<ObjMAC> _blstMAC = new BindingList<ObjMAC>();
        public BindingList<ObjXe> _blstXe = new BindingList<ObjXe>();
        public BindingList<ObjTaiXe> _blstTX = new BindingList<ObjTaiXe>();
        public BindingList<ObjNhanVien> _blstNV = new BindingList<ObjNhanVien>();

        public BindingList<Objvw_DataMix> BLstDataMix
        {
            set
            {
                this._blstDataMix = value;
                this.gridControl1.DataSource = (object)this._blstDataMix;
            }
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
                this.lueNhanVien.Properties.DataSource = (object)this._blstNV;
            }
        }

        public List<FieldCode> LstDataMixStatus { set => throw new NotImplementedException(); }
        public BindingList<ObjSilo> BLstSilo { set => throw new NotImplementedException(); }

        public RptChiTietMeTron()
        {
            InitializeComponent();
            this._presenter = new DataMixMngDataPresenter((IDataMixMngView)this);
            
            this.Caption = "Mẻ trộn chi tiết";
            this._presenter.ListKhachHang();
            this._presenter.ListCongTruong();
            this._presenter.ListHangMuc();
            this._presenter.ListMAC();
            this._presenter.ListXe();
            this._presenter.ListTaiXe();
            this._presenter.ListNhanVien();
            

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

        private void CreateTaableData(int numAgg, int numCe, int numWa,  int numAdd )
        {
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
            for(int i = 0; i < numAgg; i++)
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
               /* SplashScreenManager.ShowForm(typeof(NDPWaitForm));
                SplashScreenManager.Default.SetWaitFormCaption(GlobalValues.Messages.WAIT_CAPTION);
                SplashScreenManager.Default.SetWaitFormDescription(GlobalValues.Messages.WAIT_LOADING);*/
                bool? active = new bool?();
                if (Convert.ToInt32(this.lueCheDo.EditValue) == 1)
                    active = new bool?(false);
                else if (Convert.ToInt32(this.lueCheDo.EditValue) == 2)
                    active = new bool?(true);
                /*this._presenter.ListDataMix_ByCondition(
                    Searching.Build_StartDateTime(this.datFromDate.DateTime),
                    Searching.Build_EndDateTime(this.datToDate.DateTime),
                    this.txtMaPhieuTron.Text,
                    (int?)this.lueKhachHang.EditValue,
                    (int?)this.lueCongTruong.EditValue,
                    (int?)this.lueHangMuc.EditValue,
                    (int?)this.lueMAC.EditValue,
                    (int?)this.lueBienSo.EditValue,
                    (int?)this.lueTaiXe.EditValue,
                    (int?)this.lueNhanVien.EditValue,
                active);*/
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //SplashScreenManager.CloseForm();
            }

        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = string.Empty;
            this.datToDate.EditValue = (object)DateTime.Now;
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
            LoadDataMix();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadDataMix();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadSearchDefaultValues();
        }
    }
}

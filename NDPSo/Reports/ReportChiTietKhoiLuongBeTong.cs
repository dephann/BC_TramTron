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
    public partial class ReportChiTietKhoiLuongBeTong : ControlViewBase, ISumWeightMngView, IBase, IPermission
    {
        private ReportChiTietKhoiLuongBeTongDataPresenter _presenter;
        public BindingList<Objvw_SumWeight> _blstSumWeight = new BindingList<Objvw_SumWeight>();
        public BindingList<ObjKhachHang> _blstKH = new BindingList<ObjKhachHang>();
        public BindingList<ObjCongTruong> _blstCT = new BindingList<ObjCongTruong>();
        public BindingList<ObjHangMuc> _blstHM = new BindingList<ObjHangMuc>();
        public BindingList<ObjMAC> _blstMAC = new BindingList<ObjMAC>();
        public BindingList<ObjXe> _blstXe = new BindingList<ObjXe>();
        public BindingList<ObjTaiXe> _blstTX = new BindingList<ObjTaiXe>();
        public BindingList<ObjNhanVien> _blstNV = new BindingList<ObjNhanVien>();

        public BindingList<Objvw_SumWeight> BLstSumWeight 
        {
            set 
            {
                this._blstSumWeight = value;
                this.grcChiTietKhoiLuongBeTong.DataSource = (object)this._blstSumWeight;
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
                //this.lueNhanVien.Properties.DataSource = (object)this._blstNV;
            }
        }

        public ReportChiTietKhoiLuongBeTong()
        {
            InitializeComponent();
            this._presenter = new ReportChiTietKhoiLuongBeTongDataPresenter((ISumWeightMngView)this);
            this.Caption = "Chi tiết khối lượng bê tông";

            this._presenter.ListKhachHang();
            this._presenter.ListCongTruong();
            this._presenter.ListHangMuc();
            this._presenter.ListMAC();
            this._presenter.ListXe();
            this._presenter.ListTaiXe();
            this._presenter.ListNhanVien();

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
            LoadSearchDefaultValues();


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
                /*this._presenter.ListSumWeight_ByCondition(
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

                this._blstSumWeight = this._presenter.ListSumWeight_ByCondition_re(
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
                active);
                Invoke(new Action(() => UpdateUI(_blstSumWeight)));

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
        private void UpdateUI(BindingList<Objvw_SumWeight> result)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(result)));
                return;
            }

            this.grcChiTietKhoiLuongBeTong.DataSource = result;
        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)DateTime.Now.AddDays(-(double)ConfigManager.TramTronConfig.LatestBaoCaoDays);
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
            Task.Run(() => LoadDataMix());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Task.Run(() => LoadDataMix());
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadSearchDefaultValues();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "BÁO CÁO CHI TIẾT KHỐI LƯỢNG BÊ TÔNG";
                string str = string.Format("Từ ngày: {0} - đến ngày: {1}", (object)FormatToString.DateTimeToString(this.datFromDate.DateTime), (object)FormatToString.DateTimeToString(this.datToDate.DateTime));
                string str2 = string.Format("Khách hàng: {0}", (object)this.lueKhachHang.Text);
                string str3 = string.Format("Công trường: {0}", (object)this.lueCongTruong.Text);
                string str4 = string.Format("Hạng mục: {0}", (object)this.lueHangMuc.Text);
                string str5 = string.Format("MAC: {0}", (object)this.lueMAC.Text);
                string str6 = string.Format("Tài xế: {0}", (object)this.lueTaiXe.Text);
                string str7 = string.Format("Biển số: {0}", (object)this.lueBienSo.Text);
                string str8 = string.Format("Nhân viên: {0}", (object)this.lueNhanVien.Text);
                
                List<string> lst = new List<string>();
                lst.Add(str);
                if (this.lueKhachHang.EditValue != (object)null)
                    lst.Add(str2);
                if (this.lueCongTruong.EditValue != (object)null)
                    lst.Add(str3);
                if (this.lueHangMuc.EditValue != (object)null)
                    lst.Add(str4);
                if (this.lueMAC.EditValue != (object)null)
                    lst.Add(str5);
                if (this.lueTaiXe.EditValue != (object)null)
                    lst.Add(str6);
                if (this.lueBienSo.EditValue != (object)null)
                    lst.Add(str7);
                if (this.lueNhanVien.EditValue != (object)null)
                    lst.Add(str8);
                new Helpper().ExportExcelWithHeader(true, (IPrintable)this.grcChiTietKhoiLuongBeTong, true, true, title, lst);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
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
    public partial class ReportTongKhoiLuong : ControlViewBase, ISumWeightMngView, IBase, IPermission
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
                this.grcTongKhoiLuong.DataSource = (object)this._blstSumWeight;
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
        public BindingList<ObjMAC> BLstMAC
        {
            set
            {
                this._blstMAC = value;
                this.lueMAC.Properties.DataSource = (object)this._blstMAC;
            }
        }
        public BindingList<ObjHangMuc> BLstHangMuc
        {
            set
            {
                this._blstHM = value;
            }
        }
        public BindingList<ObjXe> BLstXe
        {
            set
            {
                this._blstXe = value;

            }
        }
        public BindingList<ObjTaiXe> BLstTaiXe
        {
            set
            {
                this._blstTX = value;
            }
        }
        public BindingList<ObjNhanVien> BLstNhanVien
        {
            set
            {
                this._blstNV = value;
            }
        }
        public ReportTongKhoiLuong()
        {
            InitializeComponent();
            this._presenter = new ReportChiTietKhoiLuongBeTongDataPresenter((ISumWeightMngView)this);
            this.Caption = "Tổng khối lương";

            this._presenter.ListKhachHang();
            this._presenter.ListCongTruong();
            this._presenter.ListMAC();

        }
        protected override void PopulateStaticData()
        {
            this.lueCheDo.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.SimMode>(true);
            
            LoadSearchDefaultValues();

        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)DateTime.Now.AddDays(-(double)ConfigManager.TramTronConfig.LatestBaoCaoDays);
            this.datToDate.EditValue = (object)DateTime.Now;
            this.lueKhachHang.EditValue = (object)null;
            this.lueCongTruong.EditValue = (object)null;
            this.lueMAC.EditValue = (object)null;
            this.lueCheDo.EditValue = (object)-1;
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

                this._blstSumWeight = this._presenter.ListSumWeight_ByCondition_re(
                    Searching.Build_StartDateTime(this.datFromDate.DateTime),
                    Searching.Build_EndDateTime(this.datToDate.DateTime),
                    this.txtMaPhieuTron.Text,
                    (int?)this.lueKhachHang.EditValue,
                    (int?)this.lueCongTruong.EditValue,
                    null,
                    (int?)this.lueMAC.EditValue,
                    null,
                    null,
                    null,
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

            this.grcTongKhoiLuong.DataSource = result;
        }
        protected override void PopulateData()
        {
            //this.LoadDataMix();
            Task.Run(() => LoadDataMix());
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadDataMix();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            LoadSearchDefaultValues();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                string title = "BÁO CÁO TỔNG KHỐI LƯỢNG BÊ TÔNG";
                string str = string.Format("Từ ngày: {0} - đến ngày: {1}", (object)FormatToString.DateTimeToString(this.datFromDate.DateTime), (object)FormatToString.DateTimeToString(this.datToDate.DateTime));
                string str2 = string.Format("Khách hàng: {0}", (object)this.lueKhachHang.Text);
                string str3 = string.Format("Công trường: {0}", (object)this.lueCongTruong.Text);
                string str4 = string.Format("MAC: {0}", (object)this.lueMAC.Text);
                List<string> lst = new List<string>();
                lst.Add(str);
                if (this.lueKhachHang.EditValue != (object)null)
                    lst.Add(str2);
                if (this.lueCongTruong.EditValue != (object)null)
                    lst.Add(str3);
                if (this.lueMAC.EditValue != (object)null)
                    lst.Add(str4);
                new Helpper().ExportExcelWithHeader(true, (IPrintable)this.grcTongKhoiLuong, true, true, title, lst);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

using DevExpress.XtraEditors;
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

namespace NDPSo.MasterData
{
    public partial class DataMixMngView : ControlViewBase, IDataMixMngView, IBase, IPermission
    {
        private IServices _ser = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
        private DataMixMngDataPresenter _presenter;
        public BindingList<Objvw_DataMix> _blstDataMix = new BindingList<Objvw_DataMix>();

        
        public BindingList<Objvw_DataMix> BLstDataMix 
        {
            set
            {
                this._blstDataMix = value;
                //this.grcDataMix.DataSource = (object)this._blstDataMix;
                this.grcDataMix.DataSource = this._ser.ListDataMix();
            }
        }

        public BindingList<ObjKhachHang> BLstKhachHang { set => throw new NotImplementedException(); }
        public BindingList<ObjCongTruong> BLstCongTruong { set => throw new NotImplementedException(); }
        public BindingList<ObjHangMuc> BLstHangMuc { set => throw new NotImplementedException(); }
        public BindingList<ObjMAC> BLstMAC { set => throw new NotImplementedException(); }
        public BindingList<ObjXe> BLstXe { set => throw new NotImplementedException(); }
        public BindingList<ObjTaiXe> BLstTaiXe { set => throw new NotImplementedException(); }
        public BindingList<ObjNhanVien> BLstNhanVien { set => throw new NotImplementedException(); }
        public List<FieldCode> LstDataMixStatus { set => throw new NotImplementedException(); }
        public BindingList<ObjSilo> BLstSilo { set => throw new NotImplementedException(); }

        public DataMixMngView()
        {
            InitializeComponent();
            this._presenter = new DataMixMngDataPresenter((IDataMixMngView)this);
            this._presenter.ListDataMix();
            //this._presenter.ListDataMix_ByCondition(Searching.Build_StartDateTime(this.datFromDate.DateTime), Searching.Build_StartDateTime(this.datToDate.DateTime), txtMaPT.ToString(), null, null, null, null, null, null, null);
            //IList<Objvw_DataMix> lstPhieu = this._ser.ListDataMix();
            this.Caption = "Data Mix";
        }

        protected override void PopulateStaticData()
        {
            //this._presenter.ListDataMix();
            LoadSearchDefaultValues();
            gcMaPhieuTron.Visible = false;

        }
        protected override void PopulateData()
        {
            //this.LoadDataMix();
        }

        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)null;
            this.datToDate.EditValue = (object)Searching.Build_EndDateTime(DateTime.Now);
            this.txtMaPT.Text = string.Empty;
        }
        private void LoadDataMix()
        {
            DateTime? fromDate = Searching.Build_StartDateTime(this.datFromDate.DateTime);
            DateTime? toDate = Searching.Build_StartDateTime(this.datToDate.DateTime);
            this.grcDataMix.DataSource = this._ser.ListDataMix_ByCondition(fromDate, toDate, this.txtMaPT.Text, "Nam Dai Phat", string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty);
            //this._presenter.ListDataMix_ByCondition(Searching.Build_StartDateTime(this.datFromDate.DateTime), Searching.Build_StartDateTime(this.datToDate.DateTime), txtMaPT.ToString());
        }

        
        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            LoadDataMix();

        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            LoadSearchDefaultValues();
        }
    }
}

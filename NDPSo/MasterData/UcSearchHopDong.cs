using DevExpress.XtraEditors;
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
    public partial class UcSearchHopDong : ControlViewBase, IHopDongMngView, IBase, IPermission
    {

        private HopDongMngDataPresenter _presenter;
        
        private BindingList<ObjHopDong> _blstHopDong = new BindingList<ObjHopDong>();
        private BindingList<ObjKhachHang> _blstKhachHang = new BindingList<ObjKhachHang>();
        private BindingList<ObjCongTruong> _blstCongTruong = new BindingList<ObjCongTruong>();
        private BindingList<ObjMAC> _blstMAC = new BindingList<ObjMAC>();
        private List<FieldCode> _lstHopDongStatus = new List<FieldCode>();
        private ObjHopDong _hd;
        private int? _searchStatus = new int?(-1);
        public ObjHopDong HopDongSelected 
        {
            set
            {
                this._hd = value;
            }
        }
        public UcSearchHopDong()
        {
            InitializeComponent();
            this._presenter = new HopDongMngDataPresenter((IHopDongMngView)this);
            this.Caption = "Tìm Hợp đồng đã tạo";
        }
        public BindingList<ObjHopDong> BLstHopDong
        {
            set
            {
                this._blstHopDong = value;
                this.grcHopDong.DataSource = (object)this._blstHopDong;
            }
        }

        public BindingList<ObjKhachHang> BLstKhachHang
        {
            set
            {
                this._blstKhachHang = value;
                this.lueKhachHang.Properties.DataSource = (object)this._blstKhachHang;
                this.illueKhachHang.DataSource = (object)this._blstKhachHang;

            }
        }

        public BindingList<ObjCongTruong> BLstCongTruong
        {
            set
            {
                this._blstCongTruong = value;
                this.lueCongTruong.Properties.DataSource = (object)this._blstCongTruong;
                this.ilueCongTruong.DataSource = (object)this._blstCongTruong;
            }
        }

        public BindingList<ObjMAC> BLstMAC
        {
            set
            {
                this._blstMAC = value;
                this.lueMAC.Properties.DataSource = (object)this._blstMAC;
                this.ilueMAC.DataSource = (object)this._blstMAC;
            }
        }
        public int? SearchStatus
        {
            set
            {
                if (!value.HasValue)
                    value = new int?(-1);
                this._searchStatus = value;
                this.lueHDStatus.EditValue = (object)value;
            }
        }
        public List<FieldCode> LstHopDongStatus
        {
            set
            {
                this._lstHopDongStatus = value;
                this.ilueHDStatus.DataSource = (object)this._lstHopDongStatus;
                this.lueHDStatus.Properties.DataSource = (object)this._lstHopDongStatus;
            }
        }

        public bool IsSuccessfulSaved { set => throw new NotImplementedException(); }

        protected override void PopulateStaticData()
        {
            this._presenter.ListKhachHang();
            this._presenter.ListCongTruong();
            this._presenter.ListMAC();
            this.LoadHDStatus();
            this.LoadSearchDefaultValues();
        }
        protected override void PopulateData()
        {
            this.LoadHopDong();
        }
        public ObjHopDong GetSelectedObjects()
        {
            ObjHopDong item = this._hd;
            return item;
        }
        private void LoadHopDong() => this._presenter.ListHopDong(this.txtMaHopDong.Text, Searching.Build_StartDateTime(this.datTuNgay.DateTime), Searching.Build_EndDateTime(this.datDenNgay.DateTime), 0, (int?)this.lueKhachHang.EditValue, (int?)this.lueCongTruong.EditValue, (int?)this.lueMAC.EditValue);

        private void LoadSearchDefaultValues()
        {
            this.datTuNgay.EditValue = string.Empty;
            this.datDenNgay.EditValue = (object)DateTime.Now;
            this.txtMaHopDong.Text = string.Empty;
            this.lueHDStatus.EditValue = (object)null;
            this.lueKhachHang.EditValue = (object)null;
            this.lueCongTruong.EditValue = (object)null;
            this.lueMAC.EditValue = (object)null;
        }
        private void LoadHDStatus() => this._presenter.ListHopDongStatus();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadHopDong();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.LoadSearchDefaultValues();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this._dlgRes = DialogResult.OK;
            this.Close();
        }

        private void grvHopDong_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                HopDongSelected = this.grvHopDong.GetRow(this.grvHopDong.FocusedRowHandle) as ObjHopDong;
                
            }
        }
    }
}

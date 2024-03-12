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
    public partial class FrmDataMix : DialogViewBase, IDataMixMngView, IBase
    {
        private DataMixMngDataPresenter _presenter;
        public BindingList<Objvw_DataMix> _blstDataMix = new BindingList<Objvw_DataMix>();

        public BindingList<Objvw_DataMix> BLstDataMix 
        {
            set
            {
                this._blstDataMix = value;
                this.grcDataMix.DataSource = (object)this._blstDataMix;
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

        public FrmDataMix()
        {
            InitializeComponent();
            this._presenter = new DataMixMngDataPresenter((IDataMixMngView)this);
        }

        protected override void PopulateStaticData()
        {
            this._presenter.ListDataMix();

        }
    }
}
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NDPSo.MasterData
{
    public partial class HopDongMngView : ControlViewBase, IHopDongMngView, IBase, IPermission
    {
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        private HopDongMngDataPresenter _presenter;
        private int? _searchStatus = new int?(-1);
        private bool _useAsSearching;
        private BindingList<ObjHopDong> _blstHopDong = new BindingList<ObjHopDong>();
        private BindingList<ObjKhachHang> _blstKhachHang = new BindingList<ObjKhachHang>();
        private BindingList<ObjCongTruong> _blstCongTruong = new BindingList<ObjCongTruong>();
        private BindingList<ObjMAC> _blstMAC = new BindingList<ObjMAC>();
        private List<FieldCode> _lstHopDongStatus = new List<FieldCode>();

        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }
        public HopDongMngView()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(NDPWaitForm));
                SplashScreenManager.Default.SetWaitFormCaption(GlobalValues.Messages.WAIT_CAPTION);
                SplashScreenManager.Default.SetWaitFormDescription(GlobalValues.Messages.WAIT_LOADING);

                InitializeComponent();
                this._presenter = new HopDongMngDataPresenter((IHopDongMngView)this);
                this.Caption = this.bsiCaption.Caption;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SplashScreenManager.CloseForm();
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

        public bool UseAsSearching
        {
            set
            {
                this._useAsSearching = value;
                this.barButtons.Visible = !this._useAsSearching;
            }
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

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
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
        protected override void AdjustCulture()
        {
            try
            {
                /*base.Caption = (this.bsiCaption.Caption = FrmMain.ResMng.GetString("HopDongMngView.bsiCaption", FrmMain.Culture));
                this.bbiInsert.Caption = FrmMain.ResMng.GetString("HopDongMngView.bbiInsert", FrmMain.Culture);
                this.bbiUpdate.Caption = FrmMain.ResMng.GetString("HopDongMngView.bbiUpdate", FrmMain.Culture);
                this.bbiDelete.Caption = FrmMain.ResMng.GetString("HopDongMngView.bbiDelete", FrmMain.Culture);
                this.bbiView.Caption = FrmMain.ResMng.GetString("HopDongMngView.bbiView", FrmMain.Culture);
                this.grcSearch.Text = FrmMain.ResMng.GetString("HopDongMngView.grpSearch", FrmMain.Culture);
                this.grcMaster.Text = FrmMain.ResMng.GetString("HopDongMngView.grpMaster", FrmMain.Culture);
                this.btnSearch.Text = FrmMain.ResMng.GetString("HopDongMngView.btnSearch", FrmMain.Culture);
                this.btnReset.Text = FrmMain.ResMng.GetString("HopDongMngView.btnReset", FrmMain.Culture);
                this.lblFromDate.Text = FrmMain.ResMng.GetString("HopDongMngView.lblFromDate", FrmMain.Culture);
                this.lblToDate.Text = FrmMain.ResMng.GetString("HopDongMngView.lblToDate", FrmMain.Culture);
                this.lblMaHopDong.Text = (this.gcMaHopDong.Caption = FrmMain.ResMng.GetString("HopDongMngView.lblMaHopDong", FrmMain.Culture));
                this.gcTenHopDong.Caption = FrmMain.ResMng.GetString("HopDongMngView.gcTenHopDong", FrmMain.Culture);
                this.gcNgayHopDong.Caption = FrmMain.ResMng.GetString("HopDongMngView.gcNgayHopDong", FrmMain.Culture);
                this.lblKhachHang.Text = (this.gcKhachHang.Caption = FrmMain.ResMng.GetString("HopDongMngView.lblKhachHang", FrmMain.Culture));
                this.lblCongTruong.Text = (this.gcCongTruong.Caption = FrmMain.ResMng.GetString("HopDongMngView.lblCongTruong", FrmMain.Culture));
                this.lblMAC.Text = (this.gcMAC.Caption = FrmMain.ResMng.GetString("HopDongMngView.lblMAC", FrmMain.Culture));
                this.gcMoTa.Caption = FrmMain.ResMng.GetString("HopDongMngView.gcMoTa", FrmMain.Culture);
                this.gcKLDatHang.Caption = FrmMain.ResMng.GetString("HopDongMngView.gcKLDatHang", FrmMain.Culture);
                this.gcKLDaGiao.Caption = FrmMain.ResMng.GetString("HopDongMngView.gcKLDaGiao", FrmMain.Culture);
                this.gcKLTaoPhieuTron.Caption = FrmMain.ResMng.GetString("HopDongMngView.gcKLTaoPhieuTron", FrmMain.Culture);
                this.lueKhachHang.Properties.Columns["MaKhachHang"].Caption = FrmMain.ResMng.GetString("HopDongMngView.lueMaKhachHang", FrmMain.Culture);
                this.lueKhachHang.Properties.Columns["TenKhachHang"].Caption = FrmMain.ResMng.GetString("HopDongMngView.lueTenKhachHang", FrmMain.Culture);
                this.lueCongTruong.Properties.Columns["MaCongTruong"].Caption = FrmMain.ResMng.GetString("HopDongMngView.lueMaCongTruong", FrmMain.Culture);
                this.lueCongTruong.Properties.Columns["TenCongTruong"].Caption = FrmMain.ResMng.GetString("HopDongMngView.lueTenCongTruong", FrmMain.Culture);
                this.lueMAC.Properties.Columns["MaMAC"].Caption = FrmMain.ResMng.GetString("HopDongMngView.lueMaMAC", FrmMain.Culture);
                this.lueMAC.Properties.Columns["TenMAC"].Caption = FrmMain.ResMng.GetString("HopDongMngView.lueTenMAC", FrmMain.Culture);
                this.grvHopDong.Columns[1].Caption = "HopKKK";*/
            }
            catch
            {
            }
        }

        public override List<T> GetSelectedObjects<T>()
        {
            List<T> list = new List<T>();
            foreach (int rowHandle in this.grvHopDong.GetSelectedRows())
            {
                T item = (T)((object)this.grvHopDong.GetRow(rowHandle));
                list.Add(item);
            }
            return list;
        }

        private void LoadHopDong() => this._presenter.ListHopDong(this.txtMaHopDong.Text, Searching.Build_StartDateTime(this.datTuNgay.DateTime), Searching.Build_EndDateTime(this.datDenNgay.DateTime), (int?)this.lueHDStatus.EditValue, (int?)this.lueKhachHang.EditValue, (int?)this.lueCongTruong.EditValue, (int?)this.lueMAC.EditValue);

        private void LoadSearchDefaultValues()
        {
            this.datTuNgay.EditValue = (object)DateTime.Now.AddDays(-(double)ConfigManager.TramTronConfig.LatestHopDongDays);
            this.datDenNgay.EditValue = (object)DateTime.Now;
            this.txtMaHopDong.Text = string.Empty;
            this.lueHDStatus.EditValue = (object)this._searchStatus;
            this.lueKhachHang.EditValue = (object)null;
            this.lueCongTruong.EditValue = (object)null;
            this.lueMAC.EditValue = (object)null;
        }

        private void LoadHDStatus() => this._presenter.ListHopDongStatus();

        private void SuccessfullySave(bool isSuccess)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadHopDong();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.LoadSearchDefaultValues();
            //this.LoadHopDong();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewHopDongView ctrView = new NewHopDongView((ObjHopDong)null, Enums.FormAction.New);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListHopDong();
            this.FocusRow(this.grvHopDong, this.grvHopDong.RowCount);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvHopDong.RowCount == 0)
                return;
            int focusedRowHandle = this.grvHopDong.FocusedRowHandle;
            NewHopDongView ctrView = new NewHopDongView(this.grvHopDong.GetRow(focusedRowHandle) as ObjHopDong, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListHopDong();
            this.FocusRow(this.grvHopDong, focusedRowHandle);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BindingList<ObjHopDong> blstCT = new BindingList<ObjHopDong>();
            foreach (int selectedRow in this.grvHopDong.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjHopDong row = this.grvHopDong.GetRow(selectedRow) as ObjHopDong;
                    row.MarkAsDeleted = true;
                    blstCT.Add(row);
                }
            }
            foreach (ObjHopDong objHopDong in (Collection<ObjHopDong>)blstCT)
                this._blstHopDong.Remove(objHopDong);
            this.FocusRow(this.grvHopDong, this.grvHopDong.RowCount);
            this._presenter.SaveHopDong(blstCT);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvHopDong.RowCount == 0)
                return;
            ViewManager.ShowViewDialog((ControlViewBase)new NewHopDongView(this.grvHopDong.GetRow(this.grvHopDong.FocusedRowHandle) as ObjHopDong, Enums.FormAction.View));

        }
        private void BindPermission()
        {
            this.bbiInsert.Enabled = this.CheckHasPermission(this.bbiInsert.Name);
            this.bbiUpdate.Enabled = this.CheckHasPermission(this.bbiUpdate.Name);
            this.bbiDelete.Enabled = this.CheckHasPermission(this.bbiDelete.Name);
            this.bbiView.Enabled = this.CheckHasPermission(this.bbiView.Name);
        }
        private bool CheckHasPermission(string funcName)
        {
            foreach (ObjSEC_Function current in this._lstFunction)
            {
                if (current.MenuName == funcName)
                {
                    return true;
                }
            }
            return false;
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvHopDong.RowCount == 0)
            {
                return;
            }
            int focusedRowHandle = this.grvHopDong.FocusedRowHandle;
            ObjHopDong hd = this.grvHopDong.GetRow(focusedRowHandle) as ObjHopDong;
            NewPhieuTronView newPhieuTronView = new NewPhieuTronView(hd, Enums.FormAction.New);
            ViewManager.ShowViewDialog(newPhieuTronView);
            if (newPhieuTronView.GetDialogResult() == DialogResult.OK)
            {
                this._presenter.ListHopDong();
                base.FocusRow(this.grvHopDong, focusedRowHandle);
            }
        }
    }
}

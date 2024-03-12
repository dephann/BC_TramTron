using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
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
    public partial class KhachHangMngView : ControlViewBase, IKhachHangMngView, IBase, IPermission
    {
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        private KhachHangMngDataPresenter _presenter;
        private BindingList<ObjKhachHang> _blstKhachHang = new BindingList<ObjKhachHang>();
        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }
        public KhachHangMngView()
        {
            InitializeComponent();
            this._presenter = new KhachHangMngDataPresenter((IKhachHangMngView)this);
            this.Caption = "Khách hàng";

        }

        public BindingList<ObjKhachHang> BLstKhachHang 
        {
            set
            {
                this._blstKhachHang = value;
                this.grcKhachHang.DataSource = (object)this._blstKhachHang;
            }
        }
        protected override void PopulateStaticData()
        {
            this.lueActive.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.ActiveEnum>(true);
            this.LoadSearchDefaultValues();
        }
        
        public bool IsSuccessfulSaved { set => this.SuccessfullySave(value); }
        private void SuccessfullySave(bool isSuccess)
        {
            if (isSuccess)
                this.LoadKhachHang();
            else
                TramTromMessageBox.ShowErrorDialog(GlobalValues.Messages.UnsuccessProceed);
        }
        private void bbiInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewKhachHangView ctrView = new NewKhachHangView((ObjKhachHang)null, Enums.FormAction.New);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadKhachHang();
            this.FocusRow(this.grvKhachHang, this.grvKhachHang.RowCount);
        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)null;
            this.datToDate.EditValue = (object)Searching.Build_EndDateTime(DateTime.Now);
            this.txtMaKH.Text = this.txtTenKH.Text = this.txtDiaChi.Text = this.txtPhone.Text = string.Empty;
            this.lueActive.EditValue = (object)-1;
        }
        private void LoadKhachHang()
        {
            try
            {
                SplashScreenManager.ShowForm(typeof(NDPWaitForm));
                SplashScreenManager.Default.SetWaitFormCaption(GlobalValues.Messages.WAIT_CAPTION);
                SplashScreenManager.Default.SetWaitFormDescription(GlobalValues.Messages.WAIT_LOADING);
                bool? active = new bool?();
                if (Convert.ToInt32(this.lueActive.EditValue) == 1)
                    active = new bool?(true);
                else if (Convert.ToInt32(this.lueActive.EditValue) == 2)
                    active = new bool?(false);
                this._presenter.ListKhachHang_ByCondition(new DateTime?(this.datFromDate.DateTime), new DateTime?(this.datToDate.DateTime), this.txtMaKH.Text, this.txtTenKH.Text, this.txtDiaChi.Text, this.txtPhone.Text, true);
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadKhachHang();
        }

       

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.LoadSearchDefaultValues();
        }

        private void bbiUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvKhachHang.RowCount == 0)
                return;
            int focusedRowHandle = this.grvKhachHang.FocusedRowHandle;
            NewKhachHangView ctrView = new NewKhachHangView(this.grvKhachHang.GetRow(focusedRowHandle) as ObjKhachHang, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadKhachHang();
            this.FocusRow(this.grvKhachHang, focusedRowHandle);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TramTromMessageBox.ShowYesNoDialog(GlobalValues.Messages.ConfirmDeleteSelectedData) != DialogResult.Yes)
                return;
            BindingList<ObjKhachHang> blstCT = new BindingList<ObjKhachHang>();
            foreach (int selectedRow in this.grvKhachHang.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjKhachHang row = this.grvKhachHang.GetRow(selectedRow) as ObjKhachHang;
                    row.Activated = false;
                    blstCT.Add(row);
                    LoadKhachHang();
                }
            }
            this._presenter.SaveKhachHang(blstCT);
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvKhachHang.RowCount == 0)
                return;
            ViewManager.ShowViewDialog((ControlViewBase)new NewKhachHangView(this.grvKhachHang.GetRow(this.grvKhachHang.FocusedRowHandle) as ObjKhachHang, Enums.FormAction.View));
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
    }
}
    
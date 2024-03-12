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
    public partial class NhanVienMngView : ControlViewBase, INhanVienMngView, IBase, IPermission
    {
        private NhanVienMngDataPresenter _presenter;
        private BindingList<ObjNhanVien> _blstNhanVien = new BindingList<ObjNhanVien>();
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();

        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }

       
        public NhanVienMngView()
        {
            InitializeComponent();
            this._presenter = new NhanVienMngDataPresenter((INhanVienMngView)this);
            this.Caption = this.bsiCaption.Caption;
        }


        public BindingList<ObjNhanVien> BLstNhanVien 
        {
            set
            {
                this._blstNhanVien = value;
                this.grcNhanVien.DataSource = (object)this._blstNhanVien;
            }
        }
        public bool IsSuccessfulSaved { set => this.SuccessfullySave(value); }

        protected override void PopulateStaticData()
        {
            this.lueActive.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.ActiveEnum>(true);
            this.LoadSearchDefaultValues();
        }
        private void SuccessfullySave(bool isSuccess)
        {
            if (isSuccess)
                this.LoadNhanVien();
            else
                TramTromMessageBox.ShowErrorDialog(GlobalValues.Messages.UnsuccessProceed);
        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)null;
            this.datToDate.EditValue = (object)Searching.Build_EndDateTime(DateTime.Now);
            this.txtMaNV.Text = this.txtTenNV.Text = this.txtPhone.Text = string.Empty;
            this.lueActive.EditValue = (object)-1;
        }
        private void LoadNhanVien()
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
                this._presenter.ListNhanVien_ByCondition(new DateTime?(this.datFromDate.DateTime), new DateTime?(this.datToDate.DateTime), this.txtMaNV.Text, this.txtTenNV.Text, this.txtPhone.Text, true);
            }
            catch (System.Exception ex)
            {
                TramTromMessageBox.ShowDEPErrorDialog(ex);
                TramTronLogger.WriteError(ex);
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }

        private void bbiInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewNhanVienView ctrView = new NewNhanVienView((ObjNhanVien)null, Enums.FormAction.New);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadNhanVien();
            this.FocusRow(this.grvNhanVien, this.grvNhanVien.RowCount);
        }

        private void bbiUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvNhanVien.RowCount == 0)
                return;
            int focusedRowHandle = this.grvNhanVien.FocusedRowHandle;
            NewNhanVienView ctrView = new NewNhanVienView(this.grvNhanVien.GetRow(focusedRowHandle) as ObjNhanVien, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadNhanVien();
            this.FocusRow(this.grvNhanVien, focusedRowHandle);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TramTromMessageBox.ShowYesNoDialog(GlobalValues.Messages.ConfirmDeleteSelectedData) != DialogResult.Yes)
                return;
            BindingList<ObjNhanVien> blstCT = new BindingList<ObjNhanVien>();
            foreach (int selectedRow in this.grvNhanVien.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjNhanVien row = this.grvNhanVien.GetRow(selectedRow) as ObjNhanVien;
                    row.Activated = false;
                    blstCT.Add(row);
                    LoadNhanVien();
                }
            }
            this._presenter.SaveNhanVien(blstCT);
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvNhanVien.RowCount == 0)
                return;
            ViewManager.ShowViewDialog((ControlViewBase)new NewNhanVienView(this.grvNhanVien.GetRow(this.grvNhanVien.FocusedRowHandle) as ObjNhanVien, Enums.FormAction.View));

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadNhanVien();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.LoadSearchDefaultValues();
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

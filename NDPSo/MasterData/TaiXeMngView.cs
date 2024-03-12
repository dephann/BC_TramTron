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
    public partial class TaiXeMngView : ControlViewBase, ITaiXeMngView, IBase, IPermission
    {
        private TaiXeMngDataPresenter _presenter;
        private BindingList<ObjTaiXe> _blstTaiXe = new BindingList<ObjTaiXe>();
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }
        public TaiXeMngView()
        {
            InitializeComponent();
            this._presenter = new TaiXeMngDataPresenter((ITaiXeMngView)this);
            this.Caption = this.bsiCaption.Caption;
        }

        public BindingList<ObjTaiXe> BLstTaiXe {
            set
            {
                this._blstTaiXe = value;
                this.grcTaiXe.DataSource = (object)this._blstTaiXe;
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
                this.LoadTaiXe();
            else
                TramTromMessageBox.ShowErrorDialog(GlobalValues.Messages.UnsuccessProceed);
        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)null;
            this.datToDate.EditValue = (object)Searching.Build_EndDateTime(DateTime.Now);
            this.txtMaTX.Text = this.txtTenTX.Text = this.txtPhone.Text = string.Empty;
            this.lueActive.EditValue = (object)-1;
        }
        private void LoadTaiXe()
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
                this._presenter.ListTaiXe_ByCondition(new DateTime?(this.datFromDate.DateTime), new DateTime?(this.datToDate.DateTime), this.txtMaTX.Text, this.txtTenTX.Text, this.txtPhone.Text, true);
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadTaiXe();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.LoadSearchDefaultValues();
        }

        private void bbiInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewTaiXeView ctrView = new NewTaiXeView((ObjTaiXe)null, Enums.FormAction.New);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadTaiXe();
            this.FocusRow(this.grvTaiXe, this.grvTaiXe.RowCount);
        }

        private void bbiUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvTaiXe.RowCount == 0)
                return;
            int focusedRowHandle = this.grvTaiXe.FocusedRowHandle;
            NewTaiXeView ctrView = new NewTaiXeView(this.grvTaiXe.GetRow(focusedRowHandle) as ObjTaiXe, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadTaiXe();
            this.FocusRow(this.grvTaiXe, focusedRowHandle);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TramTromMessageBox.ShowYesNoDialog(GlobalValues.Messages.ConfirmDeleteSelectedData) != DialogResult.Yes)
                return;
            BindingList<ObjTaiXe> blstCT = new BindingList<ObjTaiXe>();
            foreach (int selectedRow in this.grvTaiXe.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjTaiXe row = this.grvTaiXe.GetRow(selectedRow) as ObjTaiXe;
                    row.Activated = false;
                    blstCT.Add(row);
                    LoadTaiXe();
                }
            }
            this._presenter.SaveTaiXe(blstCT);
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvTaiXe.RowCount == 0)
                return;
            ViewManager.ShowViewDialog((ControlViewBase)new NewTaiXeView(this.grvTaiXe.GetRow(this.grvTaiXe.FocusedRowHandle) as ObjTaiXe, Enums.FormAction.View));

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

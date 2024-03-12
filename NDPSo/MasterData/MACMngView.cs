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
    public partial class MACMngView : ControlViewBase, IMACMngView, IBase, IPermission
    {
        private MACMngDataPresenter _presenter;
        private BindingList<ObjMAC> _blstMAC = new BindingList<ObjMAC>();
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }
        public MACMngView()
        {
            InitializeComponent();
            this._presenter = new MACMngDataPresenter((IMACMngView)this);
            this.Caption = this.bsiCaption.Caption;

        }

        public BindingList<ObjMAC> BLstMAC
        {
            set
            {
                this._blstMAC = value;
                this.grcMAC.DataSource = (object)this._blstMAC;
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }

        protected override void PopulateStaticData()
        {
            this.lueActive.Properties.DataSource = (object) Converter.EnumToListFieldCode<Enums.ActiveEnum>(true);
            this.LoadSearchDefaultValues();
        }
        private void SuccessfullySave(bool isSuccess)
        {
            if (isSuccess)
                this.LoadMAC();
            else
                TramTromMessageBox.ShowErrorDialog(GlobalValues.Messages.UnsuccessProceed);
        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)null;
            this.datToDate.EditValue = (object)Searching.Build_EndDateTime(DateTime.Now);
            this.txtMaMAC.Text = this.txtTenMAC.Text = string.Empty;
            this.lueActive.EditValue = (object)-1;
        }
        private void LoadMAC()
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
                this._presenter.ListMAC_ByCondition(new DateTime?(this.datFromDate.DateTime), new DateTime?(this.datToDate.DateTime), this.txtMaMAC.Text, this.txtTenMAC.Text, true);
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
            this.LoadMAC();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.LoadSearchDefaultValues();
        }

        private void bbiInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewMACView ctrView = new NewMACView((ObjMAC)null, Enums.FormAction.New);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadMAC();
            this.FocusRow(this.grvMAC, this.grvMAC.RowCount);
        }

        private void bbiUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvMAC.RowCount == 0)
                return;
            int focusedRowHandle = this.grvMAC.FocusedRowHandle;
            NewMACView ctrView = new NewMACView(this.grvMAC.GetRow(focusedRowHandle) as ObjMAC, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadMAC();
            this.FocusRow(this.grvMAC, focusedRowHandle);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TramTromMessageBox.ShowYesNoDialog(GlobalValues.Messages.ConfirmDeleteSelectedData) != DialogResult.Yes)
                return;
            BindingList<ObjMAC> blstCT = new BindingList<ObjMAC>();
            foreach (int selectedRow in this.grvMAC.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjMAC row = this.grvMAC.GetRow(selectedRow) as ObjMAC;
                    row.Activated = false;
                    blstCT.Add(row);
                    LoadMAC();
                }
            }
            this._presenter.SaveMAC(blstCT);
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvMAC.RowCount == 0)
                return;
            ViewManager.ShowViewDialog((ControlViewBase)new NewMACView(this.grvMAC.GetRow(this.grvMAC.FocusedRowHandle) as ObjMAC, Enums.FormAction.View));
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

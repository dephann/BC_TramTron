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
    public partial class HangMucMngView : ControlViewBase, IHangMucMngView, IBase, IPermission
    {
        private HangMucMngDataPresenter _presenter;
        private BindingList<ObjHangMuc> _blstHangMuc = new BindingList<ObjHangMuc>();
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();

        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }


        public HangMucMngView()
        {
            InitializeComponent();
            this._presenter = new HangMucMngDataPresenter((IHangMucMngView)this);
            this.Caption = this.bsiCaption.Caption;
        }


        public BindingList<ObjHangMuc> BLstHangMuc
        {
            set
            {
                this._blstHangMuc = value;
                this.grcHangMuc.DataSource = (object)this._blstHangMuc;
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
                this.LoadHangMuc();
            else
                TramTromMessageBox.ShowErrorDialog(GlobalValues.Messages.UnsuccessProceed);
        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)null;
            this.datToDate.EditValue = (object)Searching.Build_EndDateTime(DateTime.Now);
            this.txtMaHM.Text = this.txtTenHM.Text = string.Empty;
            this.lueActive.EditValue = (object)-1;
        }
        private void LoadHangMuc()
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
                this._presenter.ListHangMuc_ByCondition(new DateTime?(this.datFromDate.DateTime), new DateTime?(this.datToDate.DateTime), this.txtMaHM.Text, this.txtTenHM.Text, null);
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
            NewHangMucView ctrView = new NewHangMucView((ObjHangMuc)null, Enums.FormAction.New);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadHangMuc();
            this.FocusRow(this.grvHangMuc, this.grvHangMuc.RowCount);

        }

        private void bbiUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvHangMuc.RowCount == 0)
                return;
            int focusedRowHandle = this.grvHangMuc.FocusedRowHandle;
            NewHangMucView ctrView = new NewHangMucView(this.grvHangMuc.GetRow(focusedRowHandle) as ObjHangMuc, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadHangMuc();
            this.FocusRow(this.grvHangMuc, focusedRowHandle);

        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TramTromMessageBox.ShowYesNoDialog(GlobalValues.Messages.ConfirmDeleteSelectedData) != DialogResult.Yes)
                return;
            BindingList<ObjHangMuc> blstCT = new BindingList<ObjHangMuc>();
            foreach (int selectedRow in this.grvHangMuc.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjHangMuc row = this.grvHangMuc.GetRow(selectedRow) as ObjHangMuc;
                    row.Activated = false;
                    blstCT.Add(row);
                    LoadHangMuc();
                }
            }
            this._presenter.SaveHangMuc(blstCT);
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvHangMuc.RowCount == 0)
                return;
            ViewManager.ShowViewDialog((ControlViewBase)new NewHangMucView(this.grvHangMuc.GetRow(this.grvHangMuc.FocusedRowHandle) as ObjHangMuc, Enums.FormAction.View));

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadHangMuc();
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

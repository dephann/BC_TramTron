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
    public partial class XeMngView : ControlViewBase, IXeMngView, IBase, IPermission
    {
        private XeMngDataPresenter _presenter;
        private BindingList<ObjXe> _blstXe = new BindingList<ObjXe>();
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }
        public XeMngView()
        {
            InitializeComponent();
            this._presenter = new XeMngDataPresenter((IXeMngView)this);
            this.Caption = this.bsiCaption.Caption;

        }

        public BindingList<ObjXe> BLstXe
        {
            set
            {
                this._blstXe = value;
                this.grcXe.DataSource = (object)this._blstXe;
            }
        }
        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        protected override void PopulateStaticData()
        {
            this.lueActive.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.ActiveEnum>(true);
            this.LoadSearchDefaultValues();
        }
        private void SuccessfullySave(bool isSuccess)
        {
            if (isSuccess)
                this.LoadXe();
            else
                TramTromMessageBox.ShowErrorDialog(GlobalValues.Messages.UnsuccessProceed);
        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)null;
            this.datToDate.EditValue = (object)Searching.Build_EndDateTime(DateTime.Now);
            this.txtBienSo.Text = string.Empty;
            this.lueActive.EditValue = (object)-1;
        }
        private void LoadXe()
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
                this._presenter.ListXe_ByCondition(new DateTime?(this.datFromDate.DateTime), new DateTime?(this.datToDate.DateTime), this.txtBienSo.Text, true);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadXe();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.LoadSearchDefaultValues();
        }

        private void bbiInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewXeView ctrView = new NewXeView((ObjXe)null, Enums.FormAction.New);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadXe();
            this.FocusRow(this.grvXe, this.grvXe.RowCount);
        }

        private void bbiUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvXe.RowCount == 0)
                return;
            int focusedRowHandle = this.grvXe.FocusedRowHandle;
            NewXeView ctrView = new NewXeView(this.grvXe.GetRow(focusedRowHandle) as ObjXe, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadXe();
            this.FocusRow(this.grvXe, focusedRowHandle);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TramTromMessageBox.ShowYesNoDialog(GlobalValues.Messages.ConfirmDeleteSelectedData) != DialogResult.Yes)
                return;
            BindingList<ObjXe> blstCT = new BindingList<ObjXe>();
            foreach (int selectedRow in this.grvXe.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjXe row = this.grvXe.GetRow(selectedRow) as ObjXe;
                    row.Activated = false;
                    blstCT.Add(row);
                    LoadXe();
                }
            }
            this._presenter.SaveXe(blstCT);
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvXe.RowCount == 0)
                return;
            ViewManager.ShowViewDialog((ControlViewBase)new NewXeView(this.grvXe.GetRow(this.grvXe.FocusedRowHandle) as ObjXe, Enums.FormAction.View));

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

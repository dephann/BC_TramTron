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
    public partial class CongTruongMngView : ControlViewBase, ICongTruongMngView, IBase, IPermission
    {
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        private CongTruongMngDataPresenter _presenter;
        public BindingList<ObjCongTruong> _blstCongTruong = new BindingList<ObjCongTruong>();
        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }
        public BindingList<ObjCongTruong> BLstCongTruong    
        {
            set
            {
                this._blstCongTruong = value;
                this.grcCongTruong.DataSource = (object)this._blstCongTruong;
            }
        }

        public bool IsSuccessfulSaved { set => this.SuccessfullySave(value); }
        public CongTruongMngView()
        {
            InitializeComponent();
            this._presenter = new CongTruongMngDataPresenter((ICongTruongMngView)this);
            this.Caption = this.bsiCaption.Caption;
            
            
        }
        protected override void PopulateStaticData()
        {
            this.lueActive.Properties.DataSource = (object)Converter.EnumToListFieldCode<Enums.ActiveEnum>(true);
            this.LoadSearchDefaultValues();
        }

        
        private void SuccessfullySave(bool isSuccess)
        {
            if (isSuccess)
                this.LoadCongTruong();
            else
                TramTromMessageBox.ShowErrorDialog(GlobalValues.Messages.UnsuccessProceed);
        }
        private void LoadSearchDefaultValues()
        {
            this.datFromDate.EditValue = (object)null;
            this.datToDate.EditValue = (object)Searching.Build_EndDateTime(DateTime.Now);
            this.txtMaCT.Text = this.txtTenCT.Text = this.txtDiaChi.Text = this.txtPhone.Text = string.Empty;
            this.lueActive.EditValue = (object)-1;
        }
        private void LoadCongTruong()
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
                this._presenter.ListCongTruong_ByCondition(new DateTime?(this.datFromDate.DateTime), new DateTime?(this.datToDate.DateTime), this.txtMaCT.Text, this.txtTenCT.Text, this.txtDiaChi.Text, this.txtPhone.Text, true);
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
            NewCongTruongView ctrView = new NewCongTruongView((ObjCongTruong)null, Enums.FormAction.New);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadCongTruong();
            this.FocusRow(this.grvCongTruong, this.grvCongTruong.RowCount);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.LoadCongTruong();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.LoadSearchDefaultValues();
        }

        private void bbiUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvCongTruong.RowCount == 0)
                return;
            int focusedRowHandle = this.grvCongTruong.FocusedRowHandle;
            NewCongTruongView ctrView = new NewCongTruongView(this.grvCongTruong.GetRow(focusedRowHandle) as ObjCongTruong, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this.LoadCongTruong();
            this.FocusRow(this.grvCongTruong, focusedRowHandle);
        }
        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (TramTromMessageBox.ShowYesNoDialog(GlobalValues.Messages.ConfirmDeleteSelectedData) != DialogResult.Yes)
                return;
            BindingList<ObjCongTruong> blstCT = new BindingList<ObjCongTruong>();
            foreach (int selectedRow in this.grvCongTruong.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjCongTruong row = this.grvCongTruong.GetRow(selectedRow) as ObjCongTruong;
                    row.Activated = false;
                    
                    blstCT.Add(row);
                    LoadCongTruong();
                }
            }
            this._presenter.SaveCongTruong(blstCT);
        }
        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvCongTruong.RowCount == 0)
                return;
            ViewManager.ShowViewDialog((ControlViewBase)new NewCongTruongView(this.grvCongTruong.GetRow(this.grvCongTruong.FocusedRowHandle) as ObjCongTruong, Enums.FormAction.View));
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

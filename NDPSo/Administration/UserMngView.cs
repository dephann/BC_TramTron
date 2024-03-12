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

namespace NDPSo.Administration
{
    public partial class UserMngView : ControlViewBase, IBase, IPermission, IUserMngView
    {
        private UserMngDataPresenter _presenter;
		private BindingList<ObjSEC_User> _blstUser = new BindingList<ObjSEC_User>();
		private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
		public List<ObjSEC_Function> LstFunction
		{
			set
			{
				this._lstFunction = value;
				this.BindPermission();
			}
		}
		public UserMngView()
        {
            InitializeComponent();
            this._presenter = new UserMngDataPresenter(this);
            base.Caption = this.bsiCaption.Caption;
        }

		protected override void PopulateData()
		{
			//this._presenter.ListUser();
			LoadUser();
		}

		private void SuccessfullySave(bool isSuccess)
		{
		}

		public BindingList<ObjSEC_User> BLstUser
		{
			set
			{
				this._blstUser = value;
				this.grcUser.DataSource = this._blstUser;
			}
		}

		public bool IsSuccessfulSaved
		{
			set
			{
				this.SuccessfullySave(value);
			}
		}
		private void LoadUser()
		{
			try
			{
				
				bool? active = new bool?();
				active = new bool?(true);
				this._presenter.ListUser_ByActive(active);
			}
			catch (System.Exception ex)
			{
				TramTromMessageBox.ShowDEPErrorDialog(ex);
				TramTronLogger.WriteError(ex);
			}
			finally
			{
			}
		}
		private void bbiInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
			NewUserView ctrView = new NewUserView((ObjSEC_User)null, Enums.FormAction.New);
			ViewManager.ShowViewDialog((ControlViewBase)ctrView);
			if (ctrView.GetDialogResult() != DialogResult.OK)
				return;
			this._presenter.ListUser();
			this.FocusRow(this.grvUser, this.grvUser.RowCount);
		}

        private void bbiUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
			if (this.grvUser.RowCount == 0)
				return;
			int focusedRowHandle = this.grvUser.FocusedRowHandle;
			NewUserView ctrView = new NewUserView(this.grvUser.GetRow(focusedRowHandle) as ObjSEC_User, Enums.FormAction.Edit);
			ViewManager.ShowViewDialog((ControlViewBase)ctrView);
			if (ctrView.GetDialogResult() != DialogResult.OK)
				return;
			this._presenter.ListUser();
			this.FocusRow(this.grvUser, focusedRowHandle);
		}

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
			if (TramTromMessageBox.ShowYesNoDialog(GlobalValues.Messages.ConfirmDeleteSelectedData) != DialogResult.Yes)
				return;
			BindingList<ObjSEC_User> blstCT = new BindingList<ObjSEC_User>();
			foreach (int selectedRow in this.grvUser.GetSelectedRows())
			{
				if (selectedRow >= 0)
				{
					ObjSEC_User row = this.grvUser.GetRow(selectedRow) as ObjSEC_User;
					row.IsActived = false;
					blstCT.Add(row);
				}
			}
			foreach (ObjSEC_User objSecUser in (Collection<ObjSEC_User>)blstCT)
				this._blstUser.Remove(objSecUser);
			this.FocusRow(this.grvUser, this.grvUser.RowCount);
			this._presenter.SaveUser(blstCT);
		}

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
			if (this.grvUser.RowCount == 0)
				return;
			ViewManager.ShowViewDialog((ControlViewBase)new NewUserView(this.grvUser.GetRow(this.grvUser.FocusedRowHandle) as ObjSEC_User, Enums.FormAction.View));

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

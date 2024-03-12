using DevExpress.XtraEditors;
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
    public partial class TinhDoHutNuocMngView : ControlViewBase, ITinhDoHutNuocMngView, IBase, IPermission
    {
        private TinhDoHutNuocMngDataPresenter _presenter;
        private bool _useAsSearching;
        private ObjTinhDoHutNuoc _SelectedTinhDoHutNuoc;
        private bool _choosed;
        private BindingList<ObjTinhDoHutNuoc> _blstTinhDoHutNuoc = new BindingList<ObjTinhDoHutNuoc>();
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        private BindingList<ObjNhomSilo> _blstNhomSilo = new BindingList<ObjNhomSilo>();
        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }
        public TinhDoHutNuocMngView()
        {
            InitializeComponent();
            this._presenter = new TinhDoHutNuocMngDataPresenter((ITinhDoHutNuocMngView)this);
            this.Caption = this.bsiCaption.Caption;
        }

        public bool ShowGroupStatus
        {
            set => this.grpStatus.Visible = value;
        }

        public bool UseAsSearching
        {
            set
            {
                this._useAsSearching = value;
                this.barButtons.Visible = !this._useAsSearching;
            }
        }

        public ObjTinhDoHutNuoc SelectedTinhDoHutNuoc => this._SelectedTinhDoHutNuoc;

        public bool Choosed => this._choosed;

        public BindingList<ObjTinhDoHutNuoc> BLstTinhDoHutNuoc
        {
            set
            {
                this._blstTinhDoHutNuoc = value;
                this.grcTinhDoHutNuoc.DataSource = (object)this._blstTinhDoHutNuoc;
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        public BindingList<ObjNhomSilo> BLstNhomSilo
        {
            set
            {
                this._blstNhomSilo = value;
                this.ilueNhomSilo.DataSource = (object)this._blstNhomSilo;
            }
        }
        protected override void PopulateData() => this._presenter.ListTinhDoHutNuoc();
        protected override void PopulateStaticData() => this._presenter.ListNhomSilo();
        private void SuccessfullySave(bool isSuccess)
        {
        }

        private void grvTinhDoHutNuoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
                this._SelectedTinhDoHutNuoc = (ObjTinhDoHutNuoc)null;
            else
                this._SelectedTinhDoHutNuoc = this.grvTinhDoHutNuoc.GetRow(e.FocusedRowHandle) as ObjTinhDoHutNuoc;
        }

        private void bbiInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewTinhDoHutNuocView ctrView = new NewTinhDoHutNuocView((ObjTinhDoHutNuoc)null, Enums.FormAction.New);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListTinhDoHutNuoc();
            this.FocusRow(this.grvTinhDoHutNuoc, this.grvTinhDoHutNuoc.RowCount);
        }

        private void bbiUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvTinhDoHutNuoc.RowCount == 0)
                return;
            int focusedRowHandle = this.grvTinhDoHutNuoc.FocusedRowHandle;
            NewTinhDoHutNuocView ctrView = new NewTinhDoHutNuocView(this.grvTinhDoHutNuoc.GetRow(focusedRowHandle) as ObjTinhDoHutNuoc, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListTinhDoHutNuoc();
            this.FocusRow(this.grvTinhDoHutNuoc, focusedRowHandle);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BindingList<ObjTinhDoHutNuoc> blstCT = new BindingList<ObjTinhDoHutNuoc>();
            foreach (int selectedRow in this.grvTinhDoHutNuoc.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjTinhDoHutNuoc row = this.grvTinhDoHutNuoc.GetRow(selectedRow) as ObjTinhDoHutNuoc;
                    row.MarkAsDeleted = true;
                    blstCT.Add(row);
                }
            }
            foreach (ObjTinhDoHutNuoc objTinhDoHutNuoc in (Collection<ObjTinhDoHutNuoc>)blstCT)
                this._blstTinhDoHutNuoc.Remove(objTinhDoHutNuoc);
            this.FocusRow(this.grvTinhDoHutNuoc, this.grvTinhDoHutNuoc.RowCount);
            this._presenter.SaveTinhDoHutNuoc(blstCT);
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvTinhDoHutNuoc.RowCount == 0)
                return;
            ViewManager.ShowViewDialog((ControlViewBase)new NewTinhDoHutNuocView(this.grvTinhDoHutNuoc.GetRow(this.grvTinhDoHutNuoc.FocusedRowHandle) as ObjTinhDoHutNuoc, Enums.FormAction.View));

        }

        private void btnSelete_Click(object sender, EventArgs e)
        {
            if (this._SelectedTinhDoHutNuoc == null)
            {
                TramTromMessageBox.ShowWarningDialog("Không có công thức nào được chọn!");
            }
            else
            {
                this._choosed = true;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BindPermission()
        {
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

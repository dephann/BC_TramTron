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
    public partial class NhomSiloMngView : ControlViewBase, INhomSiloMngView, IBase, IPermission
    {
        private NhomSiloMngDataPresenter _presenter;
        private BindingList<ObjNhomSilo> _blstNhomSilo = new BindingList<ObjNhomSilo>();
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }
        public NhomSiloMngView()
        {
            InitializeComponent();
            this._presenter = new NhomSiloMngDataPresenter((INhomSiloMngView)this);
            this.Caption = this.bsiCaption.Caption;
        }

        public BindingList<ObjNhomSilo> BLstNhomSilo
        {
            set
            {
                this._blstNhomSilo = value;
                this.grcNhomSilo.DataSource = (object)this._blstNhomSilo;
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        private void SuccessfullySave(bool isSuccess)
        {

        }
        protected override void PopulateData() => this._presenter.ListNhomSilo();

        private void bbiInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewNhomSiloView ctrView = new NewNhomSiloView((ObjNhomSilo)null, Enums.FormAction.New);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListNhomSilo();
            this.FocusRow(this.grvNhomSilo, this.grvNhomSilo.RowCount);
        }

        private void bbiUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvNhomSilo.RowCount == 0)
                return;
            int focusedRowHandle = this.grvNhomSilo.FocusedRowHandle;
            NewNhomSiloView ctrView = new NewNhomSiloView(this.grvNhomSilo.GetRow(focusedRowHandle) as ObjNhomSilo, Enums.FormAction.Edit);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListNhomSilo();
            this.FocusRow(this.grvNhomSilo, focusedRowHandle);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BindingList<ObjNhomSilo> blstCT = new BindingList<ObjNhomSilo>();
            foreach (int selectedRow in this.grvNhomSilo.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjNhomSilo row = this.grvNhomSilo.GetRow(selectedRow) as ObjNhomSilo;
                    row.MarkAsDeleted = true;
                    blstCT.Add(row);
                }
            }
            foreach (ObjNhomSilo objNhomSilo in (Collection<ObjNhomSilo>)blstCT)
                this._blstNhomSilo.Remove(objNhomSilo);
            this.FocusRow(this.grvNhomSilo, this.grvNhomSilo.RowCount);
            this._presenter.SaveNhomSilo(blstCT);
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.grvNhomSilo.RowCount == 0)
                return;
            ViewManager.ShowViewDialog((ControlViewBase)new NewNhomSiloView(this.grvNhomSilo.GetRow(this.grvNhomSilo.FocusedRowHandle) as ObjNhomSilo, Enums.FormAction.View));

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

using DevExpress.XtraEditors;
using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.MasterData
{
    public partial class SiloMngView : ControlViewBase, ISiloMngView, IBase, IPermission
    {
        private SiloMngDataPresenter _presenter;
        private SerialPort _sPort;
        private BindingList<ObjSilo> _blstSilo = new BindingList<ObjSilo>();
        private BindingList<ObjNhomSilo> _blstNhomSilo = new BindingList<ObjNhomSilo>();
        private bool _showDoAm;
        private bool _showKLCanMinMax;
        private bool _showMaterial;
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }
        public SiloMngView(SerialPort sPort)
        {
            InitializeComponent();
            this._presenter = new SiloMngDataPresenter((ISiloMngView)this);
            this._sPort = sPort;
            this.Caption = this.bsiCaption.Caption;
            
        }

        public BindingList<ObjSilo> BLstSilo
        {
            set
            {
                this._blstSilo = value;
                this.grcSilo.DataSource = (object)this._blstSilo;
                this.graSilo.ExpandAllGroups();
            }
        }

        public BindingList<ObjNhomSilo> BLstNhomSilo
        {
            set
            {
                this._blstNhomSilo = value;
                this.ilueNhomSilo.DataSource = (object)this._blstNhomSilo;
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        protected override void PopulateStaticData() => this._presenter.ListNhomSilo();
        protected override void PopulateData() => this._presenter.ListSilo();
        private void SuccessfullySave(bool isSuccess)
        {
        }

        private void bbiInsert_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            NewSiloView ctrView = new NewSiloView((ObjSilo)null, Enums.FormAction.New, false, true, this._showKLCanMinMax);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListSilo();
            this.FocusRow(this.graSilo, this.graSilo.RowCount);
        }

        private void bbiUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.graSilo.RowCount == 0)
                return;
            int focusedRowHandle = this.graSilo.FocusedRowHandle;
            ObjSilo objSilo = (from o in this._blstSilo
                               where o.MaSilo == (this.graSilo.GetRow(focusedRowHandle) as ObjSilo).MaSilo
                               select o).First<ObjSilo>();
            _showDoAm = false;
            if ((this.graSilo.GetRow(focusedRowHandle) as ObjSilo).MaSilo.Contains("Agg"))
            {
                _showDoAm = true;
            }
            NewSiloView ctrView = new NewSiloView(this.graSilo.GetRow(focusedRowHandle) as ObjSilo, Enums.FormAction.Edit, true, _showDoAm, this._showKLCanMinMax);
            ViewManager.ShowViewDialog((ControlViewBase)ctrView);
            if (ctrView.GetDialogResult() != DialogResult.OK)
                return;
            this._presenter.ListSilo();
            this.FocusRow(this.graSilo, focusedRowHandle);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BindingList<ObjSilo> blstCT = new BindingList<ObjSilo>();
            foreach (int selectedRow in this.graSilo.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjSilo row = this.graSilo.GetRow(selectedRow) as ObjSilo;
                    row.MarkAsDeleted = true;
                    blstCT.Add(row);
                }
            }
            foreach (ObjSilo objSilo in (Collection<ObjSilo>)blstCT)
                this._blstSilo.Remove(objSilo);
            this.FocusRow(this.graSilo, this.graSilo.RowCount);
            this._presenter.SaveSilo(blstCT);
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.graSilo.RowCount == 0)
                return;
            ObjSilo objSilo = (from o in this._blstSilo
                               where o.MaSilo == (this.graSilo.GetRow(this.graSilo.FocusedRowHandle) as ObjSilo).MaSilo
                               select o).First<ObjSilo>();
            _showDoAm = false;
            if ((this.graSilo.GetRow(this.graSilo.FocusedRowHandle) as ObjSilo).MaSilo.Contains("Agg"))
            {
                _showDoAm = true;
            }
            ViewManager.ShowViewDialog((ControlViewBase)new NewSiloView(this.graSilo.GetRow(this.graSilo.FocusedRowHandle) as ObjSilo, Enums.FormAction.View, true, _showDoAm, this._showKLCanMinMax));

        }
        private void BindPermission()
        {
            this.bbiInsert.Enabled = this.CheckHasPermission(this.bbiInsert.Name);
            this.bbiUpdate.Enabled = this.CheckHasPermission(this.bbiUpdate.Name);
            this.bbiDelete.Enabled = this.CheckHasPermission(this.bbiDelete.Name);
            this.bbiView.Enabled = this.CheckHasPermission(this.bbiView.Name);
            this._showKLCanMinMax = this.CheckHasPermission("ShowKLCanMinMax");
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

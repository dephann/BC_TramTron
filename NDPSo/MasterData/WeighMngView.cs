using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
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
    public partial class WeighMngView : ControlViewBase, IWeighMngView, IBase, IPermission
    {
        private BindingList<ObjWeigh> _blstWeigh = new BindingList<ObjWeigh>();
        private WeighMngDataPresenter _presenter;
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }
        public WeighMngView()
        {
            InitializeComponent();
            this._presenter = new WeighMngDataPresenter((IWeighMngView)this);
            //this._sPort = sPort;
            this.Caption = this.bsiCaption.Caption;
        }
        public BindingList<ObjWeigh> BLstWeigh
        {
            set
            {
                this._blstWeigh = value;
                this.grcData.DataSource = (object)this._blstWeigh;
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        protected override void InitLayout() => this.grvData.ActiveFilterCriteria = (CriteriaOperator)new BinaryOperator("MarkAsDeleted", false);

        protected override void PopulateData() => this._presenter.ListWeigh();
        private void SuccessfullySave(bool isSuccess)
        {
            if (isSuccess)
            {
                TramTromMessageBox.ShowMessageDialog(GlobalValues.Messages.SuccessSavingData);
                //this.bbiPLC_ItemClick((object)null, (ItemClickEventArgs)null);
            }
            else
                TramTromMessageBox.ShowErrorDialog(GlobalValues.Messages.ErrorSavingData);
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.grvData.PostEditor();
            this._presenter.SaveWeigh(this._blstWeigh);
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this._presenter.ListWeigh();
        }
        private void grcData_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (!e.Control || e.KeyCode != Keys.Delete)
                return;
            foreach (int selectedRow in this.grvData.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjWeigh row = this.grvData.GetRow(selectedRow) as ObjWeigh;
                    if (row.IsNewObject)
                        this._blstWeigh.Remove(row);
                    else
                        row.MarkAsDeleted = true;
                }
            }
            this.grvData.RefreshData();
        }
        private void BindPermission()
        {
            this.bbiSave.Enabled = ((from o in this._lstFunction
                                     where o.FunctionCode == "SaveWeigh"
                                     select o).FirstOrDefault<ObjSEC_Function>() != null);
            this.bbiRefresh.Enabled = ((from o in this._lstFunction
                                        where o.FunctionCode == "RefreshWeigh"
                                        select o).FirstOrDefault<ObjSEC_Function>() != null);
            /*this.bbiPLC.Enabled = ((from o in this._lstFunction
                                    where o.FunctionCode == "SendPLCWeigh"
                                    select o).FirstOrDefault<ObjSEC_Function>() != null);*/
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

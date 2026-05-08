using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using NDPSo.Data;
using NDPSo.PLCMapping;
using NDPSo.PLCModule;
using NDPSo.Utils;
using S7.Net;
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
    public partial class TimerParaMngView : ControlViewBase, ITimerParaMngView, IBase, IPermission
    {
        private TimerParaMngDataPresenter _presenter;
        private BindingList<ObjTimerPara> _blstTimerPara = new BindingList<ObjTimerPara>();
        private List<ObjTimerPara> _listTimer = new List<ObjTimerPara>();
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }

        public TimerParaMngView()
        {
            InitializeComponent();
            this._presenter = new TimerParaMngDataPresenter((ITimerParaMngView)this);
            this.Caption = this.bsiCaption.Caption;
        }

        public BindingList<ObjTimerPara> BLstTimerPara
        {
            set
            {
                this._blstTimerPara = value;
                this._listTimer.Add(this._blstTimerPara[0]);
                this._listTimer.Add(this._blstTimerPara[1]);
                this._listTimer.Add(this._blstTimerPara[2]);
                this._listTimer.Add(this._blstTimerPara[4]);
                this._listTimer.Add(this._blstTimerPara[5]);
                this._listTimer.Add(this._blstTimerPara[6]);
                this._listTimer.Add(this._blstTimerPara[11]);
                this._listTimer.Add(this._blstTimerPara[12]);
                this._listTimer.Add(this._blstTimerPara[13]);
                this._listTimer.Add(this._blstTimerPara[14]);
                this._listTimer.Add(this._blstTimerPara[15]);
                this._listTimer.Add(this._blstTimerPara[16]);
                this._listTimer.Add(this._blstTimerPara[17]);
                this._listTimer.Add(this._blstTimerPara[18]);
                this._listTimer.Add(this._blstTimerPara[19]);
                this._listTimer.Add(this._blstTimerPara[24]);
                this._listTimer.Add(this._blstTimerPara[25]);
                this._listTimer.Add(this._blstTimerPara[26]);
                this._listTimer.Add(this._blstTimerPara[27]);
                this._listTimer.Add(this._blstTimerPara[28]);
                this._listTimer.Add(this._blstTimerPara[29]);
                this._listTimer.Add(this._blstTimerPara[30]);
                this._listTimer.Add(this._blstTimerPara[31]);
                this._listTimer.Add(this._blstTimerPara[32]);
                this._listTimer.Add(this._blstTimerPara[33]);
                this._listTimer.Add(this._blstTimerPara[34]);
                this._listTimer.Add(this._blstTimerPara[35]);
                this._listTimer.Add(this._blstTimerPara[36]);
                this._listTimer.Add(this._blstTimerPara[37]);
                this._listTimer.Add(this._blstTimerPara[38]);

                this.grcData.DataSource = (object)this._listTimer;
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        protected override void InitLayout() => this.grvData.ActiveFilterCriteria = (CriteriaOperator)new BinaryOperator("MarkAsDeleted", false);

        protected override void PopulateData() => this._presenter.ListTimerPara();

        private void SuccessfullySave(bool isSuccess)
        {
            if (isSuccess)
            {
                TramTromMessageBox.ShowMessageDialog(GlobalValues.Messages.SuccessSavingData);
                //this.bbiPLC_ItemClick((object)null, (ItemClickEventArgs)null);
                this._dlgRes = DialogResult.OK;
                this.Close();
            }
            else
                TramTromMessageBox.ShowErrorDialog(GlobalValues.Messages.ErrorSavingData);
        }

        private void grcData_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (!e.Control || e.KeyCode != Keys.Delete)
                return;
            foreach (int selectedRow in this.grvData.GetSelectedRows())
            {
                if (selectedRow >= 0)
                {
                    ObjTimerPara row = this.grvData.GetRow(selectedRow) as ObjTimerPara;
                    if (row.IsNewObject)
                        this._blstTimerPara.Remove(row);
                    else
                        row.MarkAsDeleted = true;
                }
            }
            this.grvData.RefreshData();
        }

        private void bbiSaveTimer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (ObjTimerPara objTimerPara in (Collection<ObjTimerPara>)this._blstTimerPara)
            {
                if (string.IsNullOrEmpty(objTimerPara.TimerParaCode))
                {
                    TramTromMessageBox.ShowDEPErrorDialog(GlobalValues.Messages.ThieuMaThongSoThoiGian);
                    return;
                }
            }
            this.grvData.PostEditor();
            this._presenter.SaveTimerPara(this._blstTimerPara);
            
            
        }
        private void bbiRefreshTimer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this._presenter.ListTimerPara();
        }
        private void bbiPLCTimer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void BindPermission()
        {
            this.bbiSaveTimer.Enabled = this.CheckHasPermission(this.bbiSaveTimer.Name);
            this.bbiRefreshTimer.Enabled = this.CheckHasPermission(this.bbiRefreshTimer.Name);
            this.bbiPLCTimer.Enabled = this.CheckHasPermission(this.bbiPLCTimer.Name);
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

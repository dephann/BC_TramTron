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
    public partial class SimParaMngView : ControlViewBase, ITimerParaMngView, IBase, IPermission
    {
        private TimerParaMngDataPresenter _presenter;
        private BindingList<ObjTimerPara> _blstTimerPara = new BindingList<ObjTimerPara>();
        private List<ObjTimerPara> _listTimer = new List<ObjTimerPara>();
        public SimParaMngView()
        {
            InitializeComponent();
            this._presenter = new TimerParaMngDataPresenter((ITimerParaMngView)this);
            //this._sPort = sPort;
        }

        public BindingList<ObjTimerPara> BLstTimerPara
        {
            set
            {
                this._blstTimerPara = value;
                this._listTimer.Add(value[38]);
                this._listTimer.Add(value[39]);
                this._listTimer.Add(value[40]);
                this._listTimer.Add(value[41]);
                this._listTimer.Add(value[42]);
                this._listTimer.Add(value[43]);
                this._listTimer.Add(value[44]);
                this._listTimer.Add(value[45]);
                this._listTimer.Add(value[46]);
                this._listTimer.Add(value[47]);
                this._listTimer.Add(value[48]);
                this._listTimer.Add(value[49]);
                this._listTimer.Add(value[50]);
                this._listTimer.Add(value[51]);
                this._listTimer.Add(value[52]);
                this._listTimer.Add(value[53]);
                this._listTimer.Add(value[54]);
                this._listTimer.Add(value[55]);
                this._listTimer.Add(value[56]);
                this._listTimer.Add(value[57]);
                this._listTimer.Add(value[58]);
                this._listTimer.Add(value[59]);
                this._listTimer.Add(value[60]);
                this._listTimer.Add(value[61]);
                this._listTimer.Add(value[62]);
                this._listTimer.Add(value[63]);
                this._listTimer.Add(value[64]);
                this._listTimer.Add(value[65]);
                this._listTimer.Add(value[66]);
                this._listTimer.Add(value[67]);
                this._listTimer.Add(value[68]);
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
    }
}

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
    public partial class TimerPCMngView : ControlViewBase, ITimerParaMngView, IBase, IPermission
    {
        private TimerParaMngDataPresenter _presenter;
        private BindingList<ObjTimerPara> _blstTimerPara = new BindingList<ObjTimerPara>();
        private List<ObjTimerPara> _listTimer = new List<ObjTimerPara>();
        public TimerPCMngView()
        {
            InitializeComponent();
            this._presenter = new TimerParaMngDataPresenter((ITimerParaMngView)this);
        }

        public BindingList<ObjTimerPara> BLstTimerPara
        {
            set
            {
                this._blstTimerPara = value;
                this._listTimer.Add(value[3]);
                this._listTimer.Add(value[7]);
                this._listTimer.Add(value[8]);
                this._listTimer.Add(value[9]);
                this._listTimer.Add(value[10]);
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

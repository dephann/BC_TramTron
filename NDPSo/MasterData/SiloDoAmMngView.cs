using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
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
    public partial class SiloDoAmMngView : ControlViewBase, ISiloDoAmMngView, IBase, IPermission
    {
        private SiloDoAmMngDataPresenter _presenter;
        private BindingList<ObjSilo> _blstSiloDoAm = new BindingList<ObjSilo>();
        private List<ObjSEC_Function> _lstFunction = new List<ObjSEC_Function>();
        public List<ObjSEC_Function> LstFunction
        {
            set
            {
                this._lstFunction = value;
                this.BindPermission();
            }
        }
        public SiloDoAmMngView()
        {
            InitializeComponent();
            this._presenter = new SiloDoAmMngDataPresenter((ISiloDoAmMngView)this);
            this.Caption = this.bsiCaption.Caption;
        }
        public BindingList<ObjSilo> BLstSiloDoAm
        {
            set
            {
                this._blstSiloDoAm = value;
                this.grcData.DataSource = (object)this._blstSiloDoAm;
                this.ilueSoiTrongCat_TruVaoSilo.DataSource = (object)this._blstSiloDoAm;
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        protected override void InitLayout() => this.grvData.ActiveFilterCriteria = (CriteriaOperator)new BinaryOperator("MarkAsDeleted", false);

        protected override void PopulateData() => this._presenter.ListSiloDoAm();
        private void SuccessfullySave(bool isSuccess)
        {
            if (!isSuccess)
                return;
            TramTromMessageBox.ShowMessageDialog(GlobalValues.Messages.SuccessProceed);
        }
        private void ibtnTinhDoHutNuoc_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                TinhDoHutNuocMngView ctrView = new TinhDoHutNuocMngView();
                ctrView.ShowGroupStatus = true;
                ViewManager.ShowViewDialog((ControlViewBase)ctrView);
                if (!ctrView.Choosed || ctrView.SelectedTinhDoHutNuoc == null)
                    return;
                ObjSilo row = this.grvData.GetRow(this.grvData.FocusedRowHandle) as ObjSilo;
                row.TinhDoHutNuocName = ctrView.SelectedTinhDoHutNuoc.Name;
                row.TinhDoHutNuocID = new int?(ctrView.SelectedTinhDoHutNuoc.TinhDoHutNuocID);
                row.DoHutNuoc_NhomSiloAgg = new Decimal?(ctrView.SelectedTinhDoHutNuoc.DoHutNuoc);
                this.grvData.RefreshRow(this.grvData.FocusedRowHandle);
            }
            else
            {
                if (e.Button.Kind != ButtonPredefines.Delete || TramTromMessageBox.ShowYesNoDialog("Không sử dụng công thức tính độ hút nước?") != DialogResult.Yes)
                    return;
                ObjSilo row = this.grvData.GetRow(this.grvData.FocusedRowHandle) as ObjSilo;
                row.TinhDoHutNuocName = (string)null;
                row.TinhDoHutNuocID = new int?();
                row.DoHutNuoc_NhomSiloAgg = new Decimal?(0M);
                this.grvData.RefreshRow(this.grvData.FocusedRowHandle);
            }
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.grvData.PostEditor();
            this._presenter.SaveSiloDoAm(this._blstSiloDoAm);
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this._presenter.ListSiloDoAm();
        }
        private void BindPermission()
        {
            this.bbiSave.Enabled = this.CheckHasPermission(this.bbiSave.Name);
            this.bbiRefresh.Enabled = this.CheckHasPermission(this.bbiRefresh.Name);
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

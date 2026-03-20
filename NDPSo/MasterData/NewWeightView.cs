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
    public partial class NewWeightView : ControlViewBase, INewWeightView, IBase
    {
        private NewWeightDataPresenter _presenter;
        private bool _CanSuaTenSilo = true;
        private string _NewWeiCaption = "Thêm Cân";
        private string _EditWeiCaption = "Sửa Cân";
        private string _ViewWeiCaption = "Xem Cân";
        private ObjWeigh _wei;
        private BindingList<ObjWeigh> _blst = new BindingList<ObjWeigh>();
        private bool IsSaveClose { get; set; }
        public ObjWeigh Wei
        {
            set => this._wei = value;
        }
        public NewWeightView()
        {
            InitializeComponent();
            this._presenter = new NewWeightDataPresenter((INewWeightView)this);
        }

        public NewWeightView(ObjWeigh wei, Enums.FormAction action): this()
        {
            this._wei = wei;
            this.FormAction = action;
            this.SetCaption();
        }

        protected override void SetupLayout() => this.DisableConstrol();

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        public ObjWeigh Weight { set => this._wei = value; }

        protected override void PopulateData()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.Edit:
                    this._presenter.GetWeiByKey(this._wei.WeighID);
                    break;
            }
        }
        protected override void BindData()
        {
            this.txtMaWei.DataBindings.Clear();
            this.txtMaWei.DataBindings.Add("Text", (object)this._wei, "WeighCode");
            this.txtTenWei.DataBindings.Clear();
            this.txtTenWei.DataBindings.Add("Text", (object)this._wei, "WeighName");
            this.spnTON.DataBindings.Clear();
            this.spnTON.DataBindings.Add("EditValue", (object)this._wei, "TON");
            this.spnTOFF.DataBindings.Clear();
            this.spnTOFF.DataBindings.Add("EditValue", (object)this._wei, "TOFF");
            this.spnKLBaoCanRong.DataBindings.Clear();
            this.spnKLBaoCanRong.DataBindings.Add("EditValue", (object)this._wei, "KLEmpty");
            this.spnKLRungCan.DataBindings.Clear();
            this.spnKLRungCan.DataBindings.Add("EditValue", (object)this._wei, "WeiToVib");
            this.spnTGOnDinhCan.DataBindings.Clear();
            this.spnTGOnDinhCan.DataBindings.Add("EditValue", (object)this._wei, "TimeEmpty");
            this.spnTGTreCan.DataBindings.Clear();
            this.spnTGTreCan.DataBindings.Add("EditValue", (object)this._wei, "Zero");
            this.spnTGTreXa.DataBindings.Clear();
            this.spnTGTreXa.DataBindings.Add("EditValue", (object)this._wei, "Max");
            this.spnTGTreDong.DataBindings.Clear();
            this.spnTGTreDong.DataBindings.Add("EditValue", (object)this._wei, "Offset");
            this.chkGiuKL.DataBindings.Add("Checked", (object)this._wei, "GiuKLTC");

        }
        private void SetCaption()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this.Caption = this._NewWeiCaption;
                    break;
                case Enums.FormAction.Edit:
                    this.Caption = this._EditWeiCaption;
                    break;
                case Enums.FormAction.View:
                    this.Caption = this._ViewWeiCaption;
                    break;
            }
        }
        private bool ValidateData()
        {
            bool flag = true;
            
            return flag;
        }
        private void DisableConstrol()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    if (this._CanSuaTenSilo)
                        break;
                    this.txtMaWei.Properties.ReadOnly = true;
                    this.txtTenWei.Properties.ReadOnly = true;
                    break;
                case Enums.FormAction.Edit:
                    if (!this._CanSuaTenSilo)
                    {
                        this.txtMaWei.Properties.ReadOnly = true;
                        this.txtTenWei.Properties.ReadOnly = true;
                    }
                    break;
                case Enums.FormAction.View:
                    this.txtMaWei.Properties.ReadOnly = true;
                    this.txtTenWei.Properties.ReadOnly = true;
                    this.spnTON.ReadOnly = true;
                    this.spnTOFF.ReadOnly = true;
                    this.spnKLBaoCanRong.ReadOnly = true;
                    this.spnKLRungCan.ReadOnly = true;
                    this.spnTGTreCan.ReadOnly = true;
                    this.spnTGOnDinhCan.ReadOnly = true;
                    this.spnTGTreXa.ReadOnly = true;
                    this.btnSave.Visible = false;
                    break;
            }
        }
        private void SaveData()
        {
            if (!this.ValidateData())
                return;
            BindingList<ObjWeigh> blstWei = new BindingList<ObjWeigh>();
            blstWei.Add(this._wei);
            this._presenter.SaveWei(blstWei);
        }

        private void SuccessfullySave(bool isSuccess)
        {
            if (!isSuccess)
                return;
            TramTromMessageBox.ShowMessageDialog(GlobalValues.Messages.SuccessProceed);
            this._dlgRes = DialogResult.OK;
            if (this.IsSaveClose)
            {
                this.Close();
            }
            else
            {
                
                this.BindData();
            }
        }

        private void spnTON_EditValueChanged(object sender, EventArgs e)
        {
            Support.SetValueSpinZero(this.spnTON);
            this._wei.TON = new Decimal?(this.spnTON.Value);
        }
        private void spnTOFF_EditValueChanged(object sender, EventArgs e)
        {
            Support.SetValueSpinZero(this.spnTOFF);
            this._wei.TOFF = new Decimal?(this.spnTOFF.Value);
        }
        private void spnKLBaoCanRong_EditValueChanged(object sender, EventArgs e)
        {
            Support.SetValueSpinZero(this.spnKLBaoCanRong);
            this._wei.KLEmpty = new Decimal?(this.spnKLBaoCanRong.Value);
        }
        private void spnKLRungCan_EditValueChanged(object sender, EventArgs e)
        {
            Support.SetValueSpinZero(this.spnKLRungCan);
            this._wei.WeiToVib = new Decimal?(this.spnKLRungCan.Value);
        }
        private void spnTGTreCan_EditValueChanged(object sender, EventArgs e)
        {
            Support.SetValueSpinZero(this.spnTGTreCan);
            this._wei.Zero = new Decimal?(this.spnTGTreCan.Value);
        }
        private void spnTGOnDinhCan_EditValueChanged(object sender, EventArgs e)
        {
            Support.SetValueSpinZero(this.spnTGOnDinhCan);
            this._wei.TimeEmpty = new Decimal?(this.spnTGOnDinhCan.Value);
        }
        private void spnTGTreXa_EditValueChanged(object sender, EventArgs e)
        {
            Support.SetValueSpinZero(this.spnTGTreXa);
            this._wei.Max = new Decimal?(this.spnTGTreXa.Value);
        }
        private void spnTGTreDong_EditValueChanged(object sender, EventArgs e)
        {
            Support.SetValueSpinZero(this.spnTGTreDong);
            this._wei.Offset = new Decimal?(this.spnTGTreDong.Value);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            this.IsSaveClose = true;
            this.SaveData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkGiuKL_CheckedChanged(object sender, EventArgs e) => this._wei.GiuKLTC = new bool?(this.chkGiuKL.Checked);
    }
}

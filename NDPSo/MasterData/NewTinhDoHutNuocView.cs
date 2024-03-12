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
    public partial class NewTinhDoHutNuocView : ControlViewBase, INewTinhDoHutNuocView, IBase
    {
        private NewTinhDoHutNuocDataPresenter _presenter;
        private ObjTinhDoHutNuoc _ct;
        private BindingList<ObjNhomSilo> _blstNhomSilo = new BindingList<ObjNhomSilo>();
        private bool IsSaveClose { get; set; }
        public ObjTinhDoHutNuoc TinhDoHutNuoc
        {
            set
            {
                this._ct = value;
                //this.grcDHNChiTiet.DataSource = (object)this._ct.BLstTinhDoHutNuocChiTiet;
            }
        }

        public BindingList<ObjNhomSilo> BLstNhomSilo
        {
            set
            {
                this._blstNhomSilo = value;
                this.lueNhomSilo.Properties.DataSource = (object)this._blstNhomSilo;
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }

        public NewTinhDoHutNuocView()
        {
            InitializeComponent();
            this._presenter = new NewTinhDoHutNuocDataPresenter((INewTinhDoHutNuocView)this);
        }
        public NewTinhDoHutNuocView(ObjTinhDoHutNuoc ct, Enums.FormAction action)
      : this()
        {
            this._ct = ct;
            this.FormAction = action;
            this.SetCaption();
        }

        protected override void SetupLayout() => this.DisableConstrol();

        protected override void PopulateStaticData() => this._presenter.ListNhomSilo();

        protected override void PopulateData()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this._presenter.BuildNewTinhDoHutNuoc();
                    break;
                case Enums.FormAction.Edit:
                    this._presenter.GetTinhDoHutNuocByKey(this._ct.TinhDoHutNuocID);
                    break;
            }
        }
        protected override void BindData()
        {
            this.txtMaTinhDoHutNuoc.DataBindings.Clear();
            this.txtMaTinhDoHutNuoc.DataBindings.Add("Text", (object)this._ct, "MaTinhDoHutNuoc");
            this.datNgayTinhDoHut.DataBindings.Clear();
            this.datNgayTinhDoHut.DataBindings.Add("DateTime", (object)this._ct, "NgayTinhDoHut");
            //this.txtName.DataBindings.Clear();
            //this.txtName.DataBindings.Add("Text", (object)this._ct, "Name");
            this.lueNhomSilo.DataBindings.Clear();
            this.lueNhomSilo.DataBindings.Add("EditValue", (object)this._ct, "NhomSiloID");
            this.spnDHN.DataBindings.Clear();
            this.spnDHN.DataBindings.Add("EditValue", (object)this._ct, "DoHutNuoc");
            this.txtDesc.DataBindings.Clear();
            this.txtDesc.DataBindings.Add("Text", (object)this._ct, "Description");
            //this.grcDHNChiTiet.DataSource = (object)this._ct.BLstTinhDoHutNuocChiTiet;
        }

        private void SetCaption()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this.Caption = "Thêm Độ Hút Nước";
                    break;
                case Enums.FormAction.Edit:
                    this.Caption = "Sửa Độ Hút Nước";
                    break;
                case Enums.FormAction.View:
                    this.Caption = "Độ Hút Nước";
                    break;
            }
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtMaTinhDoHutNuoc.Text == string.Empty)
            {
                this.txtMaTinhDoHutNuoc.ErrorText = "Vui lòng nhập [Mã tính ĐHN].";
                flag = false;
            }
            if (this._ct.NhomSiloID <= 0)
            {
                this.lueNhomSilo.ErrorText = "Vui lòng chọn [NVL].";
                flag = false;
            }
            /*if (this.txtName.Text == string.Empty)
            {
                this.txtName.ErrorText = "Vui lòng nhập [diễn giải].";
                flag = false;
            }*/
            return flag;
        }

        private void DisableConstrol()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.Edit:
                    this.btnSaveNew.Visible = false;
                    break;
                case Enums.FormAction.View:
                    //this.txtName.Properties.ReadOnly = true;
                    this.lueNhomSilo.Properties.ReadOnly = true;
                    this.txtDesc.Properties.ReadOnly = true;
                    //this.grvDHNChiTiet.OptionsBehavior.ReadOnly = true;
                    this.btnSaveNew.Visible = false;
                    this.btnSave.Visible = false;
                    break;
            }
        }

        private void SaveData()
        {
            if (!this.ValidateData())
                return;
            BindingList<ObjTinhDoHutNuoc> blstCT = new BindingList<ObjTinhDoHutNuoc>();
            blstCT.Add(this._ct);
            this._presenter.SaveTinhDoHutNuoc(blstCT);
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
                this._presenter.BuildNewTinhDoHutNuoc();
                this.BindData();
            }
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            this.IsSaveClose = false;
            this.SaveData();
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
    }
}

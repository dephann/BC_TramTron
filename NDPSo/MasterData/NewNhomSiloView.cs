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
    public partial class NewNhomSiloView : ControlViewBase, INewNhomSiloView, IBase
    {
        private NewNhomSiloDataPresenter _presenter;
        private ObjNhomSilo _nhomSl;
        private bool IsSaveClose { get; set; }
        public ObjNhomSilo NhomSilo
        {
            set => this._nhomSl = value;
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }
        public NewNhomSiloView()
        {
            InitializeComponent();
            this._presenter = new NewNhomSiloDataPresenter((INewNhomSiloView)this);
        }
        public NewNhomSiloView(ObjNhomSilo nhomSl, Enums.FormAction action)
      : this()
        {
            this._nhomSl = nhomSl;
            this.FormAction = action;
            this.SetCaption();
        }
        protected override void SetupLayout() => this.DisableConstrol();
        protected override void PopulateData()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this._presenter.BuildNewNhomSilo();
                    break;
                case Enums.FormAction.Edit:
                    this._presenter.GetNhomSiloByKey(this._nhomSl.NhomSiloID);
                    break;
            }
        }

        protected override void BindData()
        {
            this.txtMaNhomSilo.DataBindings.Clear();
            this.txtMaNhomSilo.DataBindings.Add("Text", (object)this._nhomSl, "MaNhomSilo");
            this.txtTenNhomSilo.DataBindings.Clear();
            this.txtTenNhomSilo.DataBindings.Add("Text", (object)this._nhomSl, "TenNhomSilo");
            this.txtGhiChu.DataBindings.Clear();
            this.txtGhiChu.DataBindings.Add("Text", (object)this._nhomSl, "GhiChu");
        }

        private void SetCaption()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this.Caption = "Thêm Nhóm Silo";
                    break;
                case Enums.FormAction.Edit:
                    this.Caption = "Sửa Nhóm Silo";
                    break;
                case Enums.FormAction.View:
                    this.Caption = "Xem Nhóm Silo";
                    break;
            }
        }

        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtMaNhomSilo.Text == string.Empty)
            {
                this.txtMaNhomSilo.ErrorText = "Mã Nhóm Silo is required.";
                flag = false;
            }
            if (this.txtTenNhomSilo.Text == string.Empty)
            {
                this.txtTenNhomSilo.ErrorText = "Tên Nhóm Silo is required.";
                flag = false;
            }
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
                    this.txtMaNhomSilo.Properties.ReadOnly = true;
                    this.txtTenNhomSilo.Properties.ReadOnly = true;
                    this.txtGhiChu.Properties.ReadOnly = true;
                    this.btnSaveNew.Visible = false;
                    this.btnSave.Visible = false;
                    break;
            }
        }

        private void SaveData()
        {
            if (!this.ValidateData())
                return;
            BindingList<ObjNhomSilo> blstCT = new BindingList<ObjNhomSilo>();
            blstCT.Add(this._nhomSl);
            this._presenter.SaveNhomSilo(blstCT);
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
                this._presenter.BuildNewNhomSilo();
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

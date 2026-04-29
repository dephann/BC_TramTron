using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections;
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
    public partial class NewPhieuTronView : ControlViewBase, INewPhieuTronView, IBase
    {
        private NewPhieuTronDataPresenter _presenter;
        private ObjPhieuTron _pt;
        private ObjHopDong _hd;
        private BindingList<ObjMeTron> _blstMeTron = new BindingList<ObjMeTron>();
        private BindingList<ObjMeTronChiTiet> _blstMeTronChiTiet = new BindingList<ObjMeTronChiTiet>();
        private BindingList<ObjTaiXe> _blstTaiXe = new BindingList<ObjTaiXe>();
        private BindingList<ObjXe> _blstXe = new BindingList<ObjXe>();
        private bool IsSaveClose { get; set; }
        public NewPhieuTronView()
        {
            InitializeComponent();
            this._presenter = new NewPhieuTronDataPresenter((INewPhieuTronView)this);
        }
        public NewPhieuTronView(ObjPhieuTron pt, Enums.FormAction action): this()
        {
            this._pt = pt;
            this.FormAction = action;
            this.SetCaption();
            if (this._pt != null)
            {
                int? status = this._pt.Status;
                int num = 0;
                if (!(status.GetValueOrDefault() == num & status.HasValue))
                    return;
            }
            //this.Height = this.Height - this.grpMeTron.Height - 1;
        }

        public NewPhieuTronView(ObjHopDong hd, Enums.FormAction action): this()
        {
            this._hd = hd;
            this.FormAction = action;
            this.SetCaption();
            //this.Height = this.Height - this.grpMeTron.Height - 1;
        }

        public NewPhieuTronView(int hdID, Enums.FormAction action): this()
        {
            this._hd = new ObjHopDong();
            this._hd.HopDongID = hdID;
            this.FormAction = action;
            this.SetCaption();
            //this.Height = this.Height - this.grpMeTron.Height - 1;
        }

        public ObjPhieuTron PhieuTron
        {
            get => this._pt;
            set => this._pt = value;
        }

        public ObjHopDong HopDong
        {
            get => this._hd;
            set => this._hd = value;
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
        }

        public BindingList<ObjMeTron> BLstMeTron
        {
            set => this._blstMeTron = value;
        }

        public BindingList<ObjMeTronChiTiet> BLstMeTronChiTiet
        {
            set => this._blstMeTronChiTiet = value;
        }

        public BindingList<ObjTaiXe> BLstTaiXe
        {
            set
            {
                this._blstTaiXe = value;
                this.lueTaiXe.Properties.DataSource = (object)this._blstTaiXe;
            }
        }

        public BindingList<ObjXe> BLstXe
        {
            set
            {
                this._blstXe = value;
                this.lueXe.Properties.DataSource = (object)this._blstXe;
            }
        }

        public int SLMeDuTinh
        {
            set => this.spnMTQty.Value = (Decimal)value;
        }

        public Decimal KLDuTinhMeTron
        {
            set
            {
                this.spnKLDTMeTron.Value = value;
                ObjPhieuTron pt = this._pt;
                Decimal? klDuTinh = this._pt.KLDuTinh;
                Decimal num = Math.Round(this._pt.KLDuTinhCuaTungMe.Value, 2);
                Decimal? slMeDuTinh = this._pt.SLMeDuTinh;
                Decimal? nullable1 = slMeDuTinh.HasValue ? new Decimal?(num * slMeDuTinh.GetValueOrDefault()) : new Decimal?();
                Decimal? nullable2 = klDuTinh.HasValue & nullable1.HasValue ? new Decimal?(klDuTinh.GetValueOrDefault() - nullable1.GetValueOrDefault()) : new Decimal?();
                pt.KLBuTruMeCuoi = nullable2;
            }
        }

        protected override void SetupLayout() => this.DisableConstrol();

        protected override void PopulateStaticData()
        {
            this._presenter.ListTaiXe();
            this._presenter.ListXe();
        }

        protected override void PopulateData()
        {
            try
            {
                switch (this.FormAction)
                {
                    case Enums.FormAction.New:
                        this._presenter.GetHopDongByKey(this._hd.HopDongID);
                        this._presenter.BuildNewPhieuTron(this._hd);
                        break;
                    case Enums.FormAction.Edit:
                        this._presenter.GetHopDongByKey(this._pt.HopDongID.Value);
                        this._presenter.GetPhieuTronByKey(this._pt.PhieuTronID);
                        this._presenter.ListMeTron(this._pt.PhieuTronID);
                        this._presenter.ListMeTronChiTiet(this._pt.PhieuTronID);
                        //this.BindGridMeTron();
                        break;
                    case Enums.FormAction.View:
                        this._presenter.GetHopDongByKey(this._pt.HopDongID.Value);
                        this._presenter.GetPhieuTronByKey(this._pt.PhieuTronID);
                        this._presenter.ListMeTron(this._pt.PhieuTronID);
                        this._presenter.ListMeTronChiTiet(this._pt.PhieuTronID);
                        //this.BindGridMeTron();
                        break;
                }
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowDEPErrorDialog(ex);
            }
        }

        protected override void BindData()
        {
            try
            {
                this.bteMaHopDong.DataBindings.Clear();
                this.bteMaHopDong.DataBindings.Add("Text", (object)this._hd, "MaHopDong");
                this.spnKLLyThuyetCL.DataBindings.Clear();
                this.spnKLLyThuyetCL.DataBindings.Add("EditValue", (object)this._hd, "KLLyThuyetCoTheTaoPT");
                this.txtMaPhieuTron.DataBindings.Clear();
                this.txtMaPhieuTron.DataBindings.Add("Text", (object)this._pt, "MaPhieuTron");
                this.datNgayPhieuTron.DataBindings.Clear();
                this.datNgayPhieuTron.DataBindings.Add("DateTime", (object)this._pt, "NgayPhieuTron");
                this.datThoiGianGiaoHang.DataBindings.Clear();
                this.datThoiGianGiaoHang.DataBindings.Add("EditValue", (object)this._pt, "ThoiGianGiaoHang");
                this.lueTaiXe.DataBindings.Clear();
                this.lueTaiXe.DataBindings.Add("EditValue", (object)this._pt, "TaiXeID");
                this.lueXe.DataBindings.Clear();
                this.lueXe.DataBindings.Add("EditValue", (object)this._pt, "XeID");
                this.txtMoTa.DataBindings.Clear();
                this.txtMoTa.DataBindings.Add("Text", (object)this._pt, "MoTa");
                this.spnKLDTPhieuTron.DataBindings.Clear();
                this.spnKLDTPhieuTron.DataBindings.Add("EditValue", (object)this._pt, "KLDuTinh");
                this.spnKLTTPhieuTron.DataBindings.Clear();
                this.spnKLTTPhieuTron.DataBindings.Add("EditValue", (object)this._pt, "KLThuc");
                this.spnKLDTMeTron.DataBindings.Clear();
                this.spnKLDTMeTron.DataBindings.Add("EditValue", (object)this._pt, "KLDuTinhCuaTungMe");
                this.spnMTQty.DataBindings.Clear();
                this.spnMTQty.DataBindings.Add("EditValue", (object)this._pt, "SLMeDuTinh");
                this.spnMTHieuChinhQty.DataBindings.Clear();
                this.spnMTHieuChinhQty.DataBindings.Add("EditValue", (object)this._pt, "SLMeHieuChinh");
                this.spnMTCommitedQty.DataBindings.Clear();
                this.spnMTCommitedQty.DataBindings.Add("EditValue", (object)this._pt, "SLMeDaTron");
                this.spnMinKLTron.DataBindings.Clear();
                this.spnMinKLTron.DataBindings.Add("EditValue", (object)this._pt, "MinKLTron");
                this.spnMaxKLTron.DataBindings.Clear();
                this.spnMaxKLTron.DataBindings.Add("EditValue", (object)this._pt, "MaxKLTron");
                this.spnMaxKLXeCho.DataBindings.Clear();
                this.spnMaxKLXeCho.DataBindings.Add("EditValue", (object)this._pt, "MaxKLXeCho");
            }
            catch (System.Exception ex)
            {
                TramTronLogger.WriteError(ex);
                TramTromMessageBox.ShowDEPErrorDialog(ex);
            }
        }

        private void SetCaption()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this.Caption = "Thêm Phiếu Trộn";
                    break;
                case Enums.FormAction.Edit:
                    this.Caption = "Sửa Phiếu Trộn";
                    break;
                case Enums.FormAction.View:
                    this.Caption = "Xem Phiếu Trộn";
                    break;
            }
        }
        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtMaPhieuTron.Text == string.Empty)
            {
                this.txtMaPhieuTron.ErrorText = "Mã Phiếu Trộn is required.";
                flag = false;
            }
            if (this.lueTaiXe.ItemIndex < 0)
            {
                this.lueTaiXe.ErrorText = "Tài Xế is required.";
                flag = false;
            }
            if (this.lueXe.ItemIndex < 0)
            {
                this.lueXe.ErrorText = "Xe is required.";
                flag = false;
            }
            return flag;
        }

        private void DisableConstrol()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.Edit:
                    this.bteMaHopDong.Properties.Buttons[0].Enabled = false;
                    this.btnSaveNew.Visible = false;
                    break;
                case Enums.FormAction.View:
                    this.bteMaHopDong.Enabled = false;
                    this.bteMaHopDong.Properties.Buttons[0].Enabled = false;
                    this.btnSaveNew.Visible = false;
                    this.btnSave.Visible = false;
                    break;
            }
        }

        private void SaveData()
        {
            if (!this.ValidateData())
                return;
            BindingList<ObjPhieuTron> blstCT = new BindingList<ObjPhieuTron>();
            blstCT.Add(this._pt);
            this._presenter.SavePhieuTron(blstCT);
        }

        private void SuccessfullySave(bool isSuccess)
        {
            if (!isSuccess)
                return;
            TramTromMessageBox.ShowMessageDialog(GlobalValues.Messages.SuccessProceed);
            this._dlgRes = DialogResult.OK;
            this._presenter.GetPhieuTronByCode(this._pt.MaPhieuTron);
            if (!this.IsSaveClose)
                return;
            this.Close();
        }

        //private void BindGridMeTron() => this.grcMeTron.DataSource = (object)new NewPhieuTronView.RelObjMeTronLst(this._blstMeTron, this._blstMeTronChiTiet);

        private void spnKLDTPhieuTron_EditValueChanged(object sender, EventArgs e)
        {
            this._pt.KLDuTinh = new Decimal?(this.spnKLDTPhieuTron.Value);
            NewPhieuTronDataPresenter presenter1 = this._presenter;
            Decimal? nullable1 = this._pt.KLDuTinh;
            Decimal klDuTinhPhieuTron1 = nullable1.Value;
            nullable1 = this._pt.MaxKLTron;
            Decimal maxKLTron = nullable1.Value;
            presenter1.GetSLMeDuTinh(klDuTinhPhieuTron1, maxKLTron);
            NewPhieuTronDataPresenter presenter2 = this._presenter;
            Decimal? nullable2 = this._pt.KLDuTinh;
            Decimal klDuTinhPhieuTron2 = nullable2.Value;
            nullable2 = this._pt.SLMeDuTinh;
            int slMeDuTinh = (int)nullable2.Value;
            presenter2.GetKLDuTinhMeTron(klDuTinhPhieuTron2, slMeDuTinh);
        }

        private void spnKLTTPhieuTron_EditValueChanged(object sender, EventArgs e) => this._pt.KLThuc = new Decimal?(this.spnKLTTPhieuTron.Value);

        private void spnKLDTMeTron_EditValueChanged(object sender, EventArgs e) => this._pt.KLDuTinhCuaTungMe = new Decimal?(this.spnKLDTMeTron.Value);

        private void spnMTQty_EditValueChanged(object sender, EventArgs e) => this._pt.SLMeDuTinh = new Decimal?(this.spnMTQty.Value);

        private void spnMTHieuChinhQty_EditValueChanged(object sender, EventArgs e) => this._pt.SLMeHieuChinh = new Decimal?(this.spnMTHieuChinhQty.Value);

        private void spnMTCommitedQty_EditValueChanged(object sender, EventArgs e) => this._pt.SLMeDaTron = new Decimal?(this.spnMTCommitedQty.Value);

        private void lueTaiXe_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lueTaiXe.ItemIndex < 0)
                return;
            this._pt.TaiXeID = new int?(Convert.ToInt32(this.lueTaiXe.EditValue));
        }

        private void lueXe_EditValueChanged(object sender, EventArgs e)
        {
            if (this.lueXe.ItemIndex < 0)
                return;
            this._pt.XeID = new int?(Convert.ToInt32(this.lueXe.EditValue));
        }

        

        private void bteMaHopDong_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind != ButtonPredefines.Ellipsis)
                return;
            
            UcSearchHopDong ucSearchHD = new UcSearchHopDong();
            ucSearchHD.SearchStatus = 0;
            ViewManager.ShowViewDialog(ucSearchHD);
            if (ucSearchHD.GetDialogResult() != DialogResult.OK)
                return;
            this._hd = ucSearchHD.GetSelectedObjects();
            this._presenter.GetHopDongByKey(this._hd.HopDongID);
            this._presenter.BuildNewPhieuTron(this._hd);
            this.BindData();
        }

        private class RelObjMeTronLst : ArrayList
        {
            public virtual NewPhieuTronView.RelObjMeTron this[int index] => (NewPhieuTronView.RelObjMeTron)base[index];

            public RelObjMeTronLst(BindingList<ObjMeTron> mtLst, BindingList<ObjMeTronChiTiet> mtctLst)
            {
                foreach (ObjMeTron mt in (Collection<ObjMeTron>)mtLst)
                {
                    BindingList<ObjMeTronChiTiet> mtctLst1 = new BindingList<ObjMeTronChiTiet>();
                    foreach (ObjMeTronChiTiet objMeTronChiTiet in (Collection<ObjMeTronChiTiet>)mtctLst)
                    {
                        if (objMeTronChiTiet.MeTronID == mt.MeTronID)
                            mtctLst1.Add(objMeTronChiTiet);
                    }
                    this.Add((object)new NewPhieuTronView.RelObjMeTron(mt, mtctLst1));
                }
            }
        }

        private class RelObjMeTron : ObjMeTron
        {
            private BindingList<ObjMeTronChiTiet> _mtctLst;

            public BindingList<ObjMeTronChiTiet> MtctLst
            {
                get => this._mtctLst;
                set => this._mtctLst = value;
            }

            public RelObjMeTron(ObjMeTron mt, BindingList<ObjMeTronChiTiet> mtctLst)
            {
                this.MeTronID = mt.MeTronID;
                this.LnNo = mt.LnNo;
                this.NgayMeTron = mt.NgayMeTron;
                this.KhoiLuong = mt.KhoiLuong;
                this.PhieuTronID = mt.PhieuTronID;
                this.MoTa = mt.MoTa;
                this.Status = mt.Status;
                this.IsManual = mt.IsManual;
                this.IsDeleted = mt.IsDeleted;
                this.DeletedBy = mt.DeletedBy;
                this.DeleteReason = mt.DeleteReason;
                this.CreationDate = mt.CreationDate;
                this.CreatedBy = mt.CreatedBy;
                this.LatestUpdateDate = mt.LatestUpdateDate;
                this.LatestUpdatedBy = mt.LatestUpdatedBy;
                this._mtctLst = mtctLst;
            }
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            this.IsSaveClose = false;
            this.SaveData();
            this._dlgRes = DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.IsSaveClose = true;
            this.SaveData();
            this._dlgRes = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class NewDuLieuTronView : ControlViewBase, INewHopDongView, IBase
    {
        private NewHopDongDataPresenter _presenter;
        private bool _editKLOnly;
        private bool _CanAddMAC;
        private bool _CanEditMAC;
        private bool _CanViewMAC;
        private string _NewDLTCaption = "Thêm Dữ liệu trộn";
        private string _EditDLTCaption = "Sửa Dữ liệu trộn";
        private string _ViewDLTCaption = "Xem Dữ liệu trộn";
        private ObjHopDong _hd;
        private BindingList<ObjKhachHang> _blstKhachHang = new BindingList<ObjKhachHang>();
        private BindingList<ObjCongTruong> _blstCongTruong = new BindingList<ObjCongTruong>();
        private BindingList<ObjMAC> _blstMAC = new BindingList<ObjMAC>();
        private BindingList<ObjHangMuc> _blstHangMuc = new BindingList<ObjHangMuc>();
        private bool IsSaveClose { get; set; }
        public bool CanAddMAC
        {
            get => this._CanAddMAC;
            set => this._CanAddMAC = value;
        }

        public bool CanEditMAC
        {
            get => this._CanEditMAC;
            set => this._CanEditMAC = value;
        }

        public bool CanViewMAC
        {
            get => this._CanViewMAC;
            set => this._CanViewMAC = value;
        }

        public ObjHopDong HopDong
        {
            set => this._hd = value;
        }

        public BindingList<ObjKhachHang> BLstKhachHang
        {
            set
            {
                this._blstKhachHang = value;
                this.gluKhachHang.Properties.DataSource = (object)this._blstKhachHang;
            }
        }

        public BindingList<ObjCongTruong> BLstCongTruong
        {
            set
            {
                this._blstCongTruong = value;
                this.gluCongTruong.Properties.DataSource = (object)this._blstCongTruong;
            }
        }

        public BindingList<ObjMAC> BLstMAC
        {
            set
            {
                this._blstMAC = value;
                this.gluMAC.Properties.DataSource = (object)this._blstMAC;
            }
        }
        public BindingList<ObjHangMuc> BLstHangMuc
        {
            set
            {
                this._blstHangMuc = value;
                this.gluHangMuc.Properties.DataSource = (object)this._blstHangMuc;
            }
        }

        public bool IsSuccessfulSaved
        {
            set => this.SuccessfullySave(value);
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
                //SpinEdit spnKlBuTru = this.spnKLBuTru;
                Decimal? dltKlDuTinh = this._hd.DLT_KLDuTinh;
                Decimal num1 = Math.Round(this._hd.DLT_KLDuTinhCuaTungMe.Value, 2);
                Decimal? dltSlMeDuTinh = this._hd.DLT_SLMeDuTinh;
                Decimal? nullable = dltSlMeDuTinh.HasValue ? new Decimal?(num1 * dltSlMeDuTinh.GetValueOrDefault()) : new Decimal?();
                Decimal num2 = (dltKlDuTinh.HasValue & nullable.HasValue ? new Decimal?(dltKlDuTinh.GetValueOrDefault() - nullable.GetValueOrDefault()) : new Decimal?()).Value;
                //spnKlBuTru.Value = num2;
            }
        }   
        public NewDuLieuTronView()
        {
            InitializeComponent();
            this._presenter = new NewHopDongDataPresenter((INewHopDongView)this);
        }
        public NewDuLieuTronView(ObjHopDong ct, Enums.FormAction action, bool editKLOnly = false): this()
        {
            this._hd = ct;
            this._editKLOnly = editKLOnly;
            this.FormAction = action;
            this.SetCaption();
        }
        protected override void PopulateStaticData()
        {
            this._presenter.ListKhachHang();
            this._presenter.ListCongTruong();
            this._presenter.ListMAC();
            this._presenter.ListHangMuc();
        }

        protected override void PopulateData()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this._presenter.BuildNewHopDong();
                    break;
                case Enums.FormAction.View:
                    gluKhachHang.Properties.ReadOnly = true;
                    gluCongTruong.Properties.ReadOnly = true;
                    gluMAC.Properties.ReadOnly = true;
                    gluHangMuc.Properties.ReadOnly = true;
                    spnMaxKLTron.Properties.ReadOnly = true;
                    spnKLDuTinh.Properties.ReadOnly = true;
                    txtMoTaDLT.Properties.ReadOnly = true;
                    spnNoPhieu.Properties.ReadOnly = true;
                    btnSave.Enabled = false;
                    this._presenter.GetHopDongByKey(this._hd.HopDongID);
                    break;
                case Enums.FormAction.Edit:
                    this._presenter.GetHopDongByKey(this._hd.HopDongID);
                    break;
            }
        }
        protected override void BindData()
        {
            try
            {
                this.txtMaDLT.DataBindings.Clear();
                this.txtMaDLT.DataBindings.Add("Text", (object)this._hd, "MaHopDong");
                this.txtMoTaDLT.DataBindings.Clear();
                this.txtMoTaDLT.DataBindings.Add("Text", (object)this._hd, "TenHopDong");
                this.datNgayDLT.DataBindings.Clear();
                this.datNgayDLT.DataBindings.Add("DateTime", (object)this._hd, "NgayHopDong");
                if (this._hd.HopDongID > 0)
                {
                    if (!this._hd.LatestUpdateDate.HasValue)
                    {
                        this.datLatestUpdateDate.DataBindings.Clear();
                        this.datLatestUpdateDate.EditValue = DateTime.MinValue;
                    }
                    else
                    {
                        this.datLatestUpdateDate.DataBindings.Clear();
                        this.datLatestUpdateDate.DataBindings.Add("DateTime", (object)this._hd, "LatestUpdateDate");

                    }
                }
                this.gluKhachHang.DataBindings.Clear();
                this.gluKhachHang.DataBindings.Add("EditValue", (object)this._hd, "KhachHangID");
                this.gluCongTruong.DataBindings.Clear();
                this.gluCongTruong.DataBindings.Add("EditValue", (object)this._hd, "CongTruongID");
                this.gluMAC.DataBindings.Clear();
                this.gluMAC.DataBindings.Add("EditValue", (object)this._hd, "MACID");
                this.gluHangMuc.DataBindings.Clear();
                this.gluHangMuc.DataBindings.Add("EditValue", (object)this._hd, "HangMucID");
                this.spnKLDuTinh.DataBindings.Clear();
                this.spnKLDuTinh.DataBindings.Add("EditValue", (object)this._hd, "DLT_KLDuTinh");
                this.spnKLDTMeTron.DataBindings.Clear();
                this.spnKLDTMeTron.DataBindings.Add("EditValue", (object)this._hd, "DLT_KLDuTinhCuaTungMe");
                this.spnMTQty.DataBindings.Clear();
                this.spnMTQty.DataBindings.Add("EditValue", (object)this._hd, "DLT_SLMeDuTinh");
                this.spnMinKLTron.DataBindings.Clear();
                this.spnMinKLTron.DataBindings.Add("EditValue", (object)this._hd, "DLT_KLTronNhoNhat");
                this.spnMaxKLTron.DataBindings.Clear();
                this.spnMaxKLTron.DataBindings.Add("EditValue", (object)this._hd, "DLT_KLTronLonNhat");
                this.spnNoPhieu.DataBindings.Clear();
                this.spnNoPhieu.DataBindings.Add("EditValue", (object)this._hd, "NoPhieu");
                //this.spnKLBuTru.DataBindings.Clear();
                //this.spnKLBuTru.DataBindings.Add("EditValue", (object)this._hd, "DLT_KLBuTruMeCuoi");
                this.spnMACSUMSiloValueCalc.DataBindings.Clear();
                this.spnMACSUMSiloValueCalc.DataBindings.Add("EditValue", (object)this._hd, "DLT_MACSUMSiloValueCalc");
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
                    this.Caption = this._NewDLTCaption;
                    break;
                case Enums.FormAction.Edit:
                    this.Caption = this._EditDLTCaption;
                    break;
                case Enums.FormAction.View:
                    this.Caption = this._ViewDLTCaption;
                    break;
            }
        }
        private bool ValidateData()
        {
            bool flag = true;
            if (this.txtMaDLT.Text == string.Empty)
            {
                this.txtMaDLT.ErrorText = "Mã Hợp Đồng is required.";
                flag = false;
            }
            if (this.txtMoTaDLT.Text == string.Empty)
            {
                this.txtMoTaDLT.ErrorText = "Tên Hợp Đồng is required.";
                flag = false;
            }
            if (this.gluKhachHang.EditValue == DBNull.Value)
            {
                this.gluKhachHang.ErrorText = "Khách Hàng is required.";
                flag = false;
            }
            if (this.gluCongTruong.EditValue == DBNull.Value)
            {
                this.gluCongTruong.ErrorText = "Công Trường is required.";
                flag = false;
            }
            if (this.gluMAC.EditValue == DBNull.Value)
            {
                this.gluMAC.ErrorText = "MAC is required.";
                flag = false;
            }
            /*if (this.gluHangMuc.EditValue == DBNull.Value)
            {
                this.gluHangMuc.ErrorText = "Hạng mục is required.";
                flag = false;
            }*/
            if (this.spnKLDuTinh.Value <= 0M)
            {
                this.spnKLDuTinh.ErrorText = "Nhập khối lượng cần trộn.";
                flag = false;
            }
            
            return flag;
        }
        private void DisableConstrol()
        {
            switch (this.FormAction)
            {
                case Enums.FormAction.New:
                    this.btnSave.Visible = true;
                    break;
                case Enums.FormAction.Edit:
                    this.btnSave.Visible = true;
                    //if (!this._editKLOnly)
                    //    break;
                    //this.gluKhachHang.Properties.ReadOnly = true;
                    //this.gluKhachHang.Properties.Buttons.Clear();
                    //this.gluCongTruong.Properties.ReadOnly = true;
                    //this.gluCongTruong.Properties.Buttons.Clear();
                    //this.gluMAC.Properties.ReadOnly = true;
                    //this.gluMAC.Properties.Buttons.Clear();
                    //this.spnMaxKLTron.Properties.ReadOnly = true;
                    break;
                case Enums.FormAction.View:
                    this.gluKhachHang.Properties.ReadOnly = true;
                    this.gluKhachHang.Properties.Buttons.Clear();
                    this.gluCongTruong.Properties.ReadOnly = true;
                    this.gluCongTruong.Properties.Buttons.Clear();
                    this.gluMAC.Properties.ReadOnly = true;
                    this.gluMAC.Properties.Buttons.Clear();
                    this.gluHangMuc.Properties.ReadOnly = true;
                    this.gluHangMuc.Properties.Buttons.Clear();
                    this.spnMaxKLTron.Properties.ReadOnly = true;
                    this.spnNoPhieu.Properties.ReadOnly = true;
                    this.btnSave.Visible = false;
                    break;
            }
        }
        private void SaveData()
        {
            if (!this.ValidateData())
                return;
            this._presenter.SaveHopDong(this._hd);
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
                this._presenter.BuildNewHopDong();
                this.BindData();
            }
        }
        private void GenerateDienGiai()
        {
            string str1 = " - ";
            string str2 = string.Empty;
            if (this._hd.KhachHangID.HasValue)
                str2 = str2 + str1 + this.gluKhachHang.Text;
            int? nullable = this._hd.CongTruongID;
            if (nullable.HasValue)
                str2 = str2 + str1 + this.gluCongTruong.Text;
            nullable = this._hd.MACID;
            if (nullable.HasValue)
                str2 = str2 + str1 + this.gluMAC.Text;
            nullable = this._hd.HangMucID;
            if (nullable.HasValue)
                str2 = str2 + str1 + this.gluHangMuc.Text;
            if (str2 != string.Empty)
                str2 = str2.Substring(str1.Length, str2.Length - str1.Length);
            this._hd.TenHopDong = this.txtMoTaDLT.Text = str2;
        }

        public ObjHopDong GetSavedHopDong() => this._hd;

        private void gluKhachHang_EditValueChanged(object sender, EventArgs e)
        {
            if (this.gluKhachHang.EditValue != DBNull.Value)
                this._hd.KhachHangID = new int?(Convert.ToInt32(this.gluKhachHang.EditValue));
            this.GenerateDienGiai();
        }

        private void gluCongTruong_EditValueChanged(object sender, EventArgs e)
        {
            if (this.gluCongTruong.EditValue != DBNull.Value)
                this._hd.CongTruongID = new int?(Convert.ToInt32(this.gluCongTruong.EditValue));
            this.GenerateDienGiai();
        }
        private void spnMaxKLTron_EditValueChanged(object sender, EventArgs e)
        {
            this._hd.DLT_KLTronLonNhat = new Decimal?(this.spnMaxKLTron.Value);
            NewHopDongDataPresenter presenter1 = this._presenter;
            Decimal? nullable1 = this._hd.DLT_KLDuTinh;
            Decimal klDuTinh1 = nullable1.Value;
            nullable1 = this._hd.DLT_KLTronLonNhat;
            Decimal maxKLTron = nullable1.Value;
            presenter1.GetSLMeDuTinh(klDuTinh1, maxKLTron);
            NewHopDongDataPresenter presenter2 = this._presenter;
            Decimal? nullable2 = this._hd.DLT_KLDuTinh;
            Decimal klDuTinh2 = nullable2.Value;
            nullable2 = this._hd.DLT_SLMeDuTinh;
            int slMeDuTinh = (int)nullable2.Value;
            presenter2.GetKLDuTinhMeTron(klDuTinh2, slMeDuTinh);
        }
        private void spnKLDuTinh_EditValueChanged(object sender, EventArgs e)
        {
            this._hd.DLT_KLDuTinh = new Decimal?(this.spnKLDuTinh.Value);
            NewHopDongDataPresenter presenter1 = this._presenter;
            Decimal? nullable1 = this._hd.DLT_KLDuTinh;
            Decimal klDuTinh1 = nullable1.Value;
            nullable1 = this._hd.DLT_KLTronLonNhat;
            Decimal maxKLTron = nullable1.Value;
            presenter1.GetSLMeDuTinh(klDuTinh1, maxKLTron);
            NewHopDongDataPresenter presenter2 = this._presenter;
            Decimal? nullable2 = this._hd.DLT_KLDuTinh;
            Decimal klDuTinh2 = nullable2.Value;
            nullable2 = this._hd.DLT_SLMeDuTinh;
            int slMeDuTinh = (int)nullable2.Value;
            presenter2.GetKLDuTinhMeTron(klDuTinh2, slMeDuTinh);
            this.CalcMACSUMSiloValue();
        }

        private void CalcMACSUMSiloValue()
        {
            ObjMAC objMac = this._blstMAC.Where<ObjMAC>((Func<ObjMAC, bool>)(o =>
            {
                int macid1 = o.MACID;
                int? macid2 = this._hd.MACID;
                int valueOrDefault = macid2.GetValueOrDefault();
                return macid1 == valueOrDefault & macid2.HasValue;
            })).FirstOrDefault<ObjMAC>();
            if (objMac != null)
            {
                this._hd.DLT_MACSUMSiloValue = objMac.NPSUMSiloValue;
                ObjHopDong hd = this._hd;
                Decimal? dltKlDuTinh = this._hd.DLT_KLDuTinh;
                Decimal? npsumSiloValue = objMac.NPSUMSiloValue;
                Decimal? nullable = dltKlDuTinh.HasValue & npsumSiloValue.HasValue ? new Decimal?(dltKlDuTinh.GetValueOrDefault() * npsumSiloValue.GetValueOrDefault()) : new Decimal?();
                hd.DLT_MACSUMSiloValueCalc = nullable;
                this.spnMACSUMSiloValueCalc.EditValue = (object)this._hd.DLT_MACSUMSiloValueCalc;
            }
            else
            {
                this._hd.DLT_MACSUMSiloValue = new Decimal?(0M);
                this._hd.DLT_MACSUMSiloValueCalc = new Decimal?(0M);
                this.spnMACSUMSiloValueCalc.EditValue = (object)0;
            }
        }
        private void spnMTQty_EditValueChanged(object sender, EventArgs e) => this._hd.DLT_SLMeDuTinh = new Decimal?(this.spnMTQty.Value);

        private void spnKLDTMeTron_EditValueChanged(object sender, EventArgs e) => this._hd.DLT_KLDuTinhCuaTungMe = new Decimal?(this.spnKLDTMeTron.Value);

        private void spnKLBuTru_EditValueChanged(object sender, EventArgs e) => this._hd.DLT_KLBuTruMeCuoi = new Decimal?(this.spnNoPhieu.Value);

        private void gluMAC_EditValueChanged(object sender, EventArgs e)
        {
            if (this.gluMAC.EditValue != DBNull.Value)
                this._hd.MACID = new int?(Convert.ToInt32(this.gluMAC.EditValue));
            this.GenerateDienGiai();
            this.CalcMACSUMSiloValue();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.IsSaveClose = true;
            this.SaveData();
            TramTronLogger.WriteInfo(sender.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gluKhachHang_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Kind == ButtonPredefines.Plus)
            {
                NewKhachHangView newKhachHangView = new NewKhachHangView(null, Enums.FormAction.New);
                ViewManager.ShowViewDialog(newKhachHangView);
                if(newKhachHangView.GetDialogResult() == DialogResult.OK)
                {
                    this._presenter.ListKhachHang();
                    this.gluKhachHang.EditValue = null;
                }

            }
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                if (this.gluKhachHang.EditValue != DBNull.Value)
                {
                    ObjKhachHang _kh = this._presenter.GetKhachHangByKey(Convert.ToInt32(this.gluKhachHang.EditValue));
                    NewKhachHangView newKhachHangView = new NewKhachHangView(_kh, Enums.FormAction.Edit);
                    ViewManager.ShowViewDialog(newKhachHangView);
                    if (newKhachHangView.GetDialogResult() == DialogResult.OK)
                    {
                        this._presenter.ListKhachHang();
                    }
                }

            }
        }

        private void gluCongTruong_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                NewCongTruongView newCongTruongView = new NewCongTruongView(null, Enums.FormAction.New);
                ViewManager.ShowViewDialog(newCongTruongView);
                if (newCongTruongView.GetDialogResult() == DialogResult.OK)
                {
                    this._presenter.ListCongTruong();
                    this.gluCongTruong.EditValue = null;
                }

            }
            if(e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                if (this.gluCongTruong.EditValue != DBNull.Value)
                {
                    ObjCongTruong _ct = this._presenter.GetCongTruongByKey(Convert.ToInt32(this.gluCongTruong.EditValue));
                    NewCongTruongView newCongTruongView = new NewCongTruongView(_ct, Enums.FormAction.Edit);
                    ViewManager.ShowViewDialog(newCongTruongView);
                    if (newCongTruongView.GetDialogResult() == DialogResult.OK)
                    {
                        this._presenter.ListCongTruong();
                    }
                }
                
            }
        }

        private void gluMAC_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                NewMACView newMACView = new NewMACView(null, Enums.FormAction.New);
                ViewManager.ShowViewDialog(newMACView);
                if (newMACView.GetDialogResult() == DialogResult.OK)
                {
                    this._presenter.ListMAC();
                    this.gluMAC.EditValue = null;
                }

            }
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                if (this.gluMAC.EditValue != DBNull.Value)
                {
                    ObjMAC _mac = this._presenter.GetMACByKey(Convert.ToInt32(this.gluMAC.EditValue));
                    NewMACView newMACView = new NewMACView(_mac, Enums.FormAction.Edit);
                    ViewManager.ShowViewDialog(newMACView);
                    if (newMACView.GetDialogResult() == DialogResult.OK)
                    {
                        this._presenter.ListMAC();
                    }
                }

            }
        }

        private void gluHangMuc_EditValueChanged(object sender, EventArgs e)
        {
            if (this.gluHangMuc.EditValue != DBNull.Value)
                this._hd.HangMucID = new int?(Convert.ToInt32(this.gluHangMuc.EditValue));
            this.GenerateDienGiai();
        }

        private void gluHangMuc_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Plus)
            {
                NewHangMucView newHangMucView = new NewHangMucView(null, Enums.FormAction.New);
                ViewManager.ShowViewDialog(newHangMucView);
                if (newHangMucView.GetDialogResult() == DialogResult.OK)
                {
                    this._presenter.ListHangMuc();
                    this.gluHangMuc.EditValue = null;
                }

            }
            if (e.Button.Kind == ButtonPredefines.Ellipsis)
            {
                if (this.gluHangMuc.EditValue != DBNull.Value)
                {
                    ObjHangMuc _hm = this._presenter.GetHangMucByKey(Convert.ToInt32(this.gluHangMuc.EditValue));
                    NewHangMucView newHangMucView = new NewHangMucView(_hm, Enums.FormAction.Edit);
                    ViewManager.ShowViewDialog(newHangMucView);
                    if (newHangMucView.GetDialogResult() == DialogResult.OK)
                    {
                        this._presenter.ListHangMuc();
                    }
                }

            }
        }

        private void spnNoPhieu_EditValueChanged(object sender, EventArgs e)
        {
            this._hd.TongPhieu = new int?((int)this.spnNoPhieu.Value);
        }
    }
}

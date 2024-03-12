using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit;
using NDPSo.ClientSetting;
using NDPSo.Data;
using NDPSo.MasterData;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Diagnostics;
using DevExpress.Pdf;
using System.Drawing.Printing;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using Microsoft.Office.Interop.Word;
using Document = Microsoft.Office.Interop.Word.Document;
using DataTable = System.Data.DataTable;
using System.Runtime.InteropServices;

namespace NDPSo.KWS
{
    public partial class PrinterPheuTronChiTiet : ControlViewBase, IPhieuTronMngView, IBase, IPermission
    {
        private PhieuTronMngDataPresenter _presenter;
        private IServices _ser = ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode);
        private BindingList<ObjPhieuTron> _blstPhieuTron = new BindingList<ObjPhieuTron>();
        private BindingList<ObjHopDong> _blstHopDong = new BindingList<ObjHopDong>();
        private BindingList<ObjMeTron> _blstMeTron = new BindingList<ObjMeTron>();
        private BindingList<ObjMeTronChiTiet> _blstMeTronChiTiet = new BindingList<ObjMeTronChiTiet>();
        private BindingList<Objvw_DataMix> _lstDataMix = new BindingList<Objvw_DataMix>();
        private int num_silo_Agg;
        private int num_silo_Ce;
        private int num_silo_Wa;
        private int num_silo_Add;
        private bool _error;
        private int userID;
        private List<string> _paramListTong = new List<string>();
        private System.Data.DataTable _tablePTCT = new System.Data.DataTable();
        private System.Data.DataTable dataTableMaterial = new System.Data.DataTable();
        private string head_Agg1;
        private string head_Agg2;
        private string head_Agg3;
        private string head_Agg4;
        private string head_Agg5;
        private string head_Agg6;
        private string head_Ce1;
        private string head_Ce2;
        private string head_Ce3;
        private string head_Ce4;
        private string head_Ce5;
        private string head_Wa1;
        private string head_Wa2;
        private string head_Add1;
        private string head_Add2;
        private string head_Add3;
        private string head_Add4;
        private string head_Add5;
        private string head_Add6;
        private decimal sum_Agg1;
        private decimal sum_Agg2;
        private decimal sum_Agg3;
        private decimal sum_Agg4;
        private decimal sum_Agg5;
        private decimal sum_Agg6;
        private decimal sum_Ce1;
        private decimal sum_Ce2;
        private decimal sum_Ce3;
        private decimal sum_Ce4;
        private decimal sum_Ce5;
        private decimal sum_Wa1;
        private decimal sum_Wa2;
        private decimal sum_Add1;
        private decimal sum_Add2;
        private decimal sum_Add3;
        private decimal sum_Add4;
        private decimal sum_Add5;
        private decimal sum_Add6;
        private decimal sum_KL;
        private decimal sum_CP;
        
        public BindingList<ObjPhieuTron> BLstPhieuTron 
        {
            set
            {
                this._blstPhieuTron = value;
                this.grcPhieuTron.DataSource = (object)this._blstPhieuTron;
            }
        }
        public BindingList<ObjHopDong> BLstHopDong 
        {
            set
            {
                this._blstHopDong = value;
            }
        }
        public BindingList<ObjMeTron> BLstMeTron 
        {
            set
            {
                this._blstMeTron = value;
            }
        }
        public BindingList<ObjMeTronChiTiet> BLstMeTronChiTiet 
        {
            set
            {
                this._blstMeTronChiTiet = value;
            }
        }
        public bool IsSuccessfulSaved { set => throw new NotImplementedException(); }
        public List<FieldCode> LstPhieuTronStatus { set => throw new NotImplementedException(); }
        

        public PrinterPheuTronChiTiet()
        {
            InitializeComponent();
             _presenter = new PhieuTronMngDataPresenter((IPhieuTronMngView)this);
            this.Caption = "Phiếu chi tiết xe trộn";
        }

        private void ClearDataPhieuTron()
        {
            this.datNgayTron.EditValue = "";
            this.txtGioTron.Text = "";
            this.txtGioKTTron.Text = "";
            this.txtMaPhieuTron.Text = string.Empty;
            this.txtSoPhieu.Text = string.Empty;
            this.txtTenMAC.Text = string.Empty;
            this.txtCuongDo.Text = string.Empty;
            this.txtDoSut.Text = string.Empty;
            this.txtTheTich.Text = string.Empty;
            this.txtKhoiLuongDatHang.Text = string.Empty;
            this.txtLuyKe.Text = string.Empty;
            this.txtTenKhachHang.Text = string.Empty;
            this.txtTenCongTruong.Text = string.Empty;
            this.txtDiaDiem.Text = string.Empty;
            this.txtNiemChi.Text = string.Empty;
            this.txtNguoiTron.Text = string.Empty;
            this.txtTaiXe.Text = string.Empty;
            this.txtXe.Text = string.Empty;

        }
        protected override void PopulateStaticData()
        {
            this.LoadSearchDefaultValues();
            
            num_silo_Agg = ConfigManager.TramTronConfig.SL_Silo_AGG;
            if (num_silo_Agg == 0)
                num_silo_Agg = 1;
            num_silo_Ce = ConfigManager.TramTronConfig.SL_Silo_CE;
            if (num_silo_Ce == 0)
                num_silo_Ce = 1;
            num_silo_Wa = ConfigManager.TramTronConfig.SL_Silo_WA;
            if (num_silo_Wa == 0)
                num_silo_Wa = 1;
            num_silo_Add = ConfigManager.TramTronConfig.SL_Silo_ADD;
            if (num_silo_Add == 0)
                num_silo_Add = 0;
        }
        protected override void PopulateData() => this.LoadPhieuTron();

        private void LoadSearchDefaultValues()
        {
            this.datTuNgay.EditValue = (object)DateTime.Now.AddDays(-(double)ConfigManager.TramTronConfig.LatestPhieuTronDays);
            this.datDenNgay.EditValue = (object)DateTime.Now;

            DateTime endTime = DateTime.Now.Date.Add(new TimeSpan(23, 59, 59));
            tseToTime.EditValue = endTime.TimeOfDay;
        }

        private void DoFocusPhieuTron()
        {
            ClearDataPhieuTron();
            ObjPhieuTron objPhieuTron = this.grvPhieuTron.GetRow(this.grvPhieuTron.FocusedRowHandle) as ObjPhieuTron;
            if (objPhieuTron != null && objPhieuTron.PhieuTronID != null)
            {
                int? phieuTronID = objPhieuTron.PhieuTronID;
                int num = 0;
                if (!(phieuTronID.GetValueOrDefault() == num & phieuTronID != null))
                {
                    ObjPhieuTron phieuTronByKey = this._presenter.GetPhieuTronByKey(objPhieuTron.PhieuTronID);
                    if (phieuTronByKey == null)
                    {
                        return;
                    }
                    if (phieuTronByKey.CreatedBy.HasValue)
                    {
                        this.userID = (int)phieuTronByKey.CreatedBy;
                        ObjSEC_User user = _ser.GetSEC_UserByKey(userID);
                        txtNguoiTron.Text = user.FullName;
                    }
                    
                    datNgayTron.EditValue = phieuTronByKey.NgayPhieuTron;
                    txtGioTron.Text = phieuTronByKey.NgayPhieuTron.Value.ToString("HH:mm:ss");
                    if (phieuTronByKey.LatestUpdateDate.HasValue)
                    {
                        txtGioKTTron.Text = phieuTronByKey.LatestUpdateDate.Value.ToString("HH:mm:ss");
                    }
                    txtMaPhieuTron.Text = phieuTronByKey.MaPhieuTron;
                    txtSoPhieu.Text = phieuTronByKey.NoPhieu.ToString();
                    txtTenMAC.Text = phieuTronByKey.NPMACTenMAC;
                    txtCuongDo.Text = phieuTronByKey.NPMACCuongDo;
                    txtDoSut.Text = phieuTronByKey.NPMACDoSut;
                    txtTenKhachHang.Text = phieuTronByKey.NPKhachHangTenKhachHang;
                    txtTenCongTruong.Text = phieuTronByKey.NPCongTruongTenCongTruong;
                    txtDiaDiem.Text = phieuTronByKey.NPCongTruongDiaChi;
                    txtHangMuc.Text = phieuTronByKey.NPHangMucTenHangMuc;
                    txtTaiXe.Text = phieuTronByKey.NPTaiXeTenTaiXe;
                    txtXe.Text = phieuTronByKey.NPXeBienSo;
                    txtNiemChi.Text = phieuTronByKey.MoTa;
                    txtTheTich.Text = phieuTronByKey.KLDuTinh.ToString();
                    txtLuyKe.Text = phieuTronByKey.KLThuc.ToString();
                    txtKhoiLuongDatHang.Text = phieuTronByKey.NPHopDongKLDatHang.ToString();

                    this._blstMeTron = Converter.ConvertToBindingList<ObjMeTron>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMeTronByPhieuTronID(phieuTronByKey.PhieuTronID) as List<ObjMeTron>);
                    int LnNO = this._blstMeTron.Count;
                    this._blstMeTronChiTiet = Converter.ConvertToBindingList<ObjMeTronChiTiet>(ServiceFactories.GetFactory(ConfigManager.TramTronConfig.RunningMode).ListMeTronChiTietByPhieuTronID(phieuTronByKey.PhieuTronID) as List<ObjMeTronChiTiet>);
                    BindingList<ObjMTCTFullPrinter> _lstFullPrinter = new BindingList<ObjMTCTFullPrinter>();

                    sum_KL = 0;
                    foreach (ObjMeTron mt in this._blstMeTron)
                    {
                        sum_KL += (decimal)mt.KhoiLuong;
                        ObjMTCTFullPrinter mtctPrinter = new ObjMTCTFullPrinter();                 
                        
                        foreach (ObjMeTronChiTiet mtct in this._blstMeTronChiTiet)
                        {
                            if(mt.MeTronID == mtct.MeTronID)
                            {
                                mtctPrinter.LnNo = mt.LnNo.ToString();
                                mtctPrinter.KLTungMe = mt.KhoiLuong.ToString();
                                
                                switch (mtct.MaSilo)
                                {
                                    case "Agg1":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Agg1 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Agg1 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Agg1 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Agg1 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Agg1 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Agg1 = (decimal)mtct.ValuePerTol;
                                        mtctPrinter.DoAm_Agg1 = (decimal)mtct.DoAm_NhomSlioAgg;
                                        if (mtct.MaterialName != null)
                                            mtctPrinter.MaterialName_Agg1 = mtct.MaterialName;
                                        else
                                            mtctPrinter.MaterialName_Agg1 = "Agg1";
                                        break;
                                    case "Agg2":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Agg2 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Agg2 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Agg2 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Agg2 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Agg2 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Agg2 = (decimal)mtct.ValuePerTol;
                                        mtctPrinter.DoAm_Agg2 = (decimal)mtct.DoAm_NhomSlioAgg;
                                        if (mtct.MaterialName != null)
                                            mtctPrinter.MaterialName_Agg2 = mtct.MaterialName;
                                        else
                                            mtctPrinter.MaterialName_Agg2 = "Agg2";
                                        break;
                                    case "Agg3":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Agg3 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Agg3 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Agg3 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Agg3 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Agg3 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Agg3 = (decimal)mtct.ValuePerTol;
                                        mtctPrinter.DoAm_Agg3 = (decimal)mtct.DoAm_NhomSlioAgg;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Agg3 = "Agg3";
                                        else 
                                            mtctPrinter.MaterialName_Agg3 = mtct.MaterialName;
                                        break;
                                    case "Agg4":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Agg4 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Agg4 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Agg4 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Agg4 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Agg4 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Agg4 = (decimal)mtct.ValuePerTol;
                                        mtctPrinter.DoAm_Agg4 = (decimal)mtct.DoAm_NhomSlioAgg;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Agg4 = "Agg4";
                                        else 
                                            mtctPrinter.MaterialName_Agg4 = mtct.MaterialName;
                                        break;
                                    case "Agg5":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Agg5 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Agg5 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Agg5 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Agg5 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Agg5 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Agg5 = (decimal)mtct.ValuePerTol;
                                        mtctPrinter.DoAm_Agg5 = (decimal)mtct.DoAm_NhomSlioAgg;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Agg5 = "Agg5";
                                        else
                                            mtctPrinter.MaterialName_Agg5 = mtct.MaterialName;
                                        break;
                                    case "Agg6":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Agg6 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Agg6 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Agg6 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Agg6 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Agg6 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Agg6 = (decimal)mtct.ValuePerTol;
                                        mtctPrinter.DoAm_Agg6 = (decimal)mtct.DoAm_NhomSlioAgg;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Agg6 = "Agg6";
                                        else 
                                            mtctPrinter.MaterialName_Agg6 = mtct.MaterialName;
                                        break;
                                    case "Ce1":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Ce1 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Ce1 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Ce1 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Ce1 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Ce1 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Ce1 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Ce1 = "Ce1";
                                        else 
                                            mtctPrinter.MaterialName_Ce1 = mtct.MaterialName;
                                        break;
                                    case "Ce2":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Ce2 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Ce2 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Ce2 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Ce2 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Ce2 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Ce2 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName != null)
                                            mtctPrinter.MaterialName_Ce2 = mtct.MaterialName;
                                        else
                                            mtctPrinter.MaterialName_Ce2 = "Ce2";
                                        
                                        break;
                                    case "Ce3":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Ce3 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Ce3 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Ce3 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Ce3 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Ce3 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Ce3 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Ce3 = "Ce3";
                                        else
                                            mtctPrinter.MaterialName_Ce3 = mtct.MaterialName;
                                        break;
                                    case "Ce4":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Ce4 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Ce4 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Ce4 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Ce4 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Ce4 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Ce4 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Ce4 = "Ce4";
                                        else
                                            mtctPrinter.MaterialName_Ce4 = mtct.MaterialName;
                                        break;
                                    case "Ce5":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Ce5 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Ce5 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Ce5 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Ce5 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Ce5 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Ce5 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Ce5 = "Ce5";
                                        else 
                                            mtctPrinter.MaterialName_Ce5 = mtct.MaterialName;
                                        break;
                                    case "Wa1":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Wa1 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Wa1 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Wa1 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Wa1 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Wa1 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Wa1 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Wa1 = "Wa1";
                                        else
                                            mtctPrinter.MaterialName_Wa1 = mtct.MaterialName;
                                        break;
                                    case "Wa2":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;     
                                        mtctPrinter.SiloValue_Wa2 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Wa2 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Wa2 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Wa2 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Wa2 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Wa2 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Wa2 = "Wa2";
                                        else
                                            mtctPrinter.MaterialName_Wa2 = mtct.MaterialName;

                                        break;
                                    case "Add1":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Add1 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Add1 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Add1 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Add1 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Add1 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Add1 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Add1 = "Add1";
                                        else
                                            mtctPrinter.MaterialName_Add1 = mtct.MaterialName;

                                        break;
                                    case "Add2":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Add2 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Add2 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Add2 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Add2 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Add2 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Add2 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Add2 = "Add2";
                                        else
                                            mtctPrinter.MaterialName_Add2 = mtct.MaterialName;

                                        break;
                                    case "Add3":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Add3 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Add3 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Add3 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Add3 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Add3 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Add3 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Add3 = "Add3";
                                        else
                                            mtctPrinter.MaterialName_Add3 = mtct.MaterialName;

                                        break;
                                    case "Add4":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Add4 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Add4 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Add4 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Add4 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Add4 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Add4 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Add4 = "Add4";
                                        else 
                                            mtctPrinter.MaterialName_Add4 = mtct.MaterialName;

                                        break;
                                    case "Add5":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Add5 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Add5 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Add5 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Add5 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Add5 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Add5 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Add5 = "Add5";
                                        else
                                            mtctPrinter.MaterialName_Add5 = mtct.MaterialName;

                                        break;
                                    case "Add6":
                                        if (mtct.SiloValue == null)
                                            mtct.SiloValue = 0;
                                        mtctPrinter.SiloValue_Add6 = (decimal)mtct.SiloValue;
                                        mtctPrinter.CP_Add6 = (decimal)mtct.Value;
                                        mtctPrinter.PV_Add6 = (decimal)mtct.ValueBat;
                                        mtctPrinter.PVM_Add6 = (decimal)mtct.ValueBatMan;
                                        mtctPrinter.SaiSo_Add6 = (decimal)mtct.ValueTol;
                                        mtctPrinter.PerSaiSo_Add6 = (decimal)mtct.ValuePerTol;
                                        if (mtct.MaterialName == null)
                                            mtctPrinter.MaterialName_Add6 = "Add6";
                                        else
                                            mtctPrinter.MaterialName_Add6 = mtct.MaterialName;

                                        break;

                                }
                            }
                        }
                        _lstFullPrinter.Add(mtctPrinter);

                    }
                    if(_lstFullPrinter.Count != 0)
                    {
                        BindingList<ObjMTCTPrinter> _lstPrinter = new BindingList<ObjMTCTPrinter>();
                        CopyLstFullToLis(_lstFullPrinter, _lstPrinter);

                        // DataTable
                        System.Data.DataTable dataTable = ToDataTable(_lstPrinter);
                        //Row 1
                        DataRow newRow1 = dataTable.NewRow();
                        newRow1["LnNo"] = "KL 1m³";
                        newRow1["KLTungMe"] = "1";
                        newRow1["PV_Agg1"] = _lstFullPrinter.FirstOrDefault().SiloValue_Agg1.ToString();
                        newRow1["PV_Agg1_Manual"] = "0";
                        newRow1["PV_Agg2"] = _lstFullPrinter.FirstOrDefault().SiloValue_Agg2.ToString();
                        newRow1["PV_Agg2_Manual"] = "0";
                        newRow1["PV_Agg3"] = _lstFullPrinter.FirstOrDefault().SiloValue_Agg3.ToString();
                        newRow1["PV_Agg3_Manual"] = "0";
                        newRow1["PV_Agg4"] = _lstFullPrinter.FirstOrDefault().SiloValue_Agg4.ToString();
                        newRow1["PV_Agg4_Manual"] = "0";
                        newRow1["PV_Agg5"] = _lstFullPrinter.FirstOrDefault().SiloValue_Agg5.ToString();
                        newRow1["PV_Agg5_Manual"] = "0";
                        newRow1["PV_Agg6"] = _lstFullPrinter.FirstOrDefault().SiloValue_Agg6.ToString();
                        newRow1["PV_Agg6_Manual"] = "0";
                        newRow1["PV_Ce1"] = _lstFullPrinter.FirstOrDefault().SiloValue_Ce1.ToString();
                        newRow1["PV_Ce1_Manual"] = "0";
                        newRow1["PV_Ce2"] = _lstFullPrinter.FirstOrDefault().SiloValue_Ce2.ToString();
                        newRow1["PV_Ce2_Manual"] = "0";
                        newRow1["PV_Ce3"] = _lstFullPrinter.FirstOrDefault().SiloValue_Ce3.ToString();
                        newRow1["PV_Ce3_Manual"] = "0";
                        newRow1["PV_Ce4"] = _lstFullPrinter.FirstOrDefault().SiloValue_Ce4.ToString();
                        newRow1["PV_Ce4_Manual"] = "0";
                        newRow1["PV_Ce5"] = _lstFullPrinter.FirstOrDefault().SiloValue_Ce5.ToString();
                        newRow1["PV_Ce5_Manual"] = "0";
                        newRow1["PV_Wa1"] = _lstFullPrinter.FirstOrDefault().SiloValue_Wa1.ToString();
                        newRow1["PV_Wa1_Manual"] = "0";
                        newRow1["PV_Wa2"] = _lstFullPrinter.FirstOrDefault().SiloValue_Wa2.ToString();
                        newRow1["PV_Wa2_Manual"] = "0";
                        newRow1["PV_Add1"] = _lstFullPrinter.FirstOrDefault().SiloValue_Add1.ToString();
                        newRow1["PV_Add1_Manual"] = "0";
                        newRow1["PV_Add2"] = _lstFullPrinter.FirstOrDefault().SiloValue_Add2.ToString();
                        newRow1["PV_Add2_Manual"] = "0";
                        newRow1["PV_Add3"] = _lstFullPrinter.FirstOrDefault().SiloValue_Add3.ToString();
                        newRow1["PV_Add3_Manual"] = "0";
                        newRow1["PV_Add4"] = _lstFullPrinter.FirstOrDefault().SiloValue_Add4.ToString();
                        newRow1["PV_Add4_Manual"] = "0";
                        newRow1["PV_Add5"] = _lstFullPrinter.FirstOrDefault().SiloValue_Add5.ToString();
                        newRow1["PV_Add5_Manual"] = "0";
                        newRow1["PV_Add6"] = _lstFullPrinter.FirstOrDefault().SiloValue_Add6.ToString();
                        newRow1["PV_Add6_Manual"] = "0";

                        dataTable.Rows.InsertAt(newRow1, 0);

                        //Row 2
                        DataRow newRow2 = dataTable.NewRow();
                        newRow2["LnNo"] = "Độ ẩm";
                        newRow2["KLTungMe"] = "";
                        newRow2["PV_Agg1"] = _lstFullPrinter.FirstOrDefault().DoAm_Agg1.ToString();
                        newRow2["PV_Agg1_Manual"] = "0";
                        newRow2["PV_Agg2"] = _lstFullPrinter.FirstOrDefault().DoAm_Agg2.ToString();
                        newRow2["PV_Agg2_Manual"] = "0";
                        newRow2["PV_Agg3"] = _lstFullPrinter.FirstOrDefault().DoAm_Agg3.ToString();
                        newRow2["PV_Agg3_Manual"] = "0";
                        newRow2["PV_Agg4"] = _lstFullPrinter.FirstOrDefault().DoAm_Agg4.ToString();
                        newRow2["PV_Agg4_Manual"] = "0";
                        newRow2["PV_Agg5"] = _lstFullPrinter.FirstOrDefault().DoAm_Agg5.ToString();
                        newRow2["PV_Agg5_Manual"] = "0";
                        newRow2["PV_Agg6"] = _lstFullPrinter.FirstOrDefault().DoAm_Agg6.ToString();
                        newRow2["PV_Agg6_Manual"] = "0";
                        newRow2["PV_Ce1"] = _lstFullPrinter.FirstOrDefault().DoAm_Ce1.ToString();
                        newRow2["PV_Ce1_Manual"] = "0";
                        newRow2["PV_Ce2"] = _lstFullPrinter.FirstOrDefault().DoAm_Ce2.ToString();
                        newRow2["PV_Ce2_Manual"] = "0";
                        newRow2["PV_Ce3"] = _lstFullPrinter.FirstOrDefault().DoAm_Ce3.ToString();
                        newRow2["PV_Ce3_Manual"] = "0";
                        newRow2["PV_Ce4"] = _lstFullPrinter.FirstOrDefault().DoAm_Ce4.ToString();
                        newRow2["PV_Ce4_Manual"] = "0";
                        newRow2["PV_Ce5"] = _lstFullPrinter.FirstOrDefault().DoAm_Ce5.ToString();
                        newRow2["PV_Ce5_Manual"] = "0";
                        newRow2["PV_Wa1"] = _lstFullPrinter.FirstOrDefault().DoAm_Wa1.ToString();
                        newRow2["PV_Wa1_Manual"] = "0";
                        newRow2["PV_Wa2"] = _lstFullPrinter.FirstOrDefault().DoAm_Wa2.ToString();
                        newRow2["PV_Wa2_Manual"] = "0";
                        newRow2["PV_Add1"] = _lstFullPrinter.FirstOrDefault().DoAm_Add1.ToString();
                        newRow2["PV_Add1_Manual"] = "0";
                        newRow2["PV_Add2"] = _lstFullPrinter.FirstOrDefault().DoAm_Add2.ToString();
                        newRow2["PV_Add2_Manual"] = "0";
                        newRow2["PV_Add3"] = _lstFullPrinter.FirstOrDefault().DoAm_Add3.ToString();
                        newRow2["PV_Add3_Manual"] = "0";
                        newRow2["PV_Add4"] = _lstFullPrinter.FirstOrDefault().DoAm_Add4.ToString();
                        newRow2["PV_Add4_Manual"] = "0";
                        newRow2["PV_Add5"] = _lstFullPrinter.FirstOrDefault().DoAm_Add5.ToString();
                        newRow2["PV_Add5_Manual"] = "0";
                        newRow2["PV_Add6"] = _lstFullPrinter.FirstOrDefault().DoAm_Add6.ToString();
                        newRow2["PV_Add6_Manual"] = "0";

                        dataTable.Rows.InsertAt(newRow2, 1);

                        //Row 3
                        DataRow newRow3 = dataTable.NewRow();
                        newRow3["LnNo"] = "Khối lượng";
                        newRow3["KLTungMe"] = _lstFullPrinter[0].KLTungMe.ToString();
                        newRow3["PV_Agg1"] = _lstFullPrinter[0].CP_Agg1.ToString();
                        newRow3["PV_Agg1_Manual"] = "0";
                        newRow3["PV_Agg2"] = _lstFullPrinter[0].CP_Agg2.ToString();
                        newRow3["PV_Agg2_Manual"] = "0";
                        newRow3["PV_Agg3"] = _lstFullPrinter[0].CP_Agg3.ToString();
                        newRow3["PV_Agg3_Manual"] = "0";
                        newRow3["PV_Agg4"] = _lstFullPrinter[0].CP_Agg4.ToString();
                        newRow3["PV_Agg4_Manual"] = "0";
                        newRow3["PV_Agg5"] = _lstFullPrinter[0].CP_Agg5.ToString();
                        newRow3["PV_Agg5_Manual"] = "0";
                        newRow3["PV_Agg6"] = _lstFullPrinter[0].CP_Agg6.ToString();
                        newRow3["PV_Agg6_Manual"] = "0";
                        newRow3["PV_Ce1"] = _lstFullPrinter[0].CP_Ce1.ToString();
                        newRow3["PV_Ce1_Manual"] = "0";
                        newRow3["PV_Ce2"] = _lstFullPrinter[0].CP_Ce2.ToString();
                        newRow3["PV_Ce2_Manual"] = "0";
                        newRow3["PV_Ce3"] = _lstFullPrinter[0].CP_Ce3.ToString();
                        newRow3["PV_Ce3_Manual"] = "0";
                        newRow3["PV_Ce4"] = _lstFullPrinter[0].CP_Ce4.ToString();
                        newRow3["PV_Ce4_Manual"] = "0";
                        newRow3["PV_Ce5"] = _lstFullPrinter[0].CP_Ce5.ToString();
                        newRow3["PV_Ce5_Manual"] = "0";
                        newRow3["PV_Wa1"] = _lstFullPrinter[0].CP_Wa1.ToString();
                        newRow3["PV_Wa1_Manual"] = "0";
                        newRow3["PV_Wa2"] = _lstFullPrinter[0].CP_Wa2.ToString();
                        newRow3["PV_Wa2_Manual"] = "0";
                        newRow3["PV_Add1"] = _lstFullPrinter[0].CP_Add1.ToString();
                        newRow3["PV_Add1_Manual"] = "0";
                        newRow3["PV_Add2"] = _lstFullPrinter[0].CP_Add2.ToString();
                        newRow3["PV_Add2_Manual"] = "0";
                        newRow3["PV_Add3"] = _lstFullPrinter[0].CP_Add3.ToString();
                        newRow3["PV_Add3_Manual"] = "0";
                        newRow3["PV_Add4"] = _lstFullPrinter[0].CP_Add4.ToString();
                        newRow3["PV_Add4_Manual"] = "0";
                        newRow3["PV_Add5"] = _lstFullPrinter[0].CP_Add5.ToString();
                        newRow3["PV_Add5_Manual"] = "0";
                        newRow3["PV_Add6"] = _lstFullPrinter[0].CP_Add6.ToString();
                        newRow3["PV_Add6_Manual"] = "0";

                        dataTable.Rows.InsertAt(newRow3, 2);

                        /*foreach (DataRow row in dataTable.Rows)
                        {
                            foreach (DataColumn column in dataTable.Columns)
                            {
                                Console.Write(row[column] + "\t");
                            }
                            Console.WriteLine();
                        }*/

                        this.grcPhieuTronChiTiet.DataSource = (object)dataTable;
                        this._tablePTCT = dataTable.Copy();
                        CreateTaableData(num_silo_Agg, num_silo_Ce, num_silo_Wa, num_silo_Add, _lstFullPrinter);
                        bandedGridView1.FocusedRowHandle = 3;

                        // Total Material
                        BindingList<ObjTotalMaterialPrinter> _lstTotalMaterial = new BindingList<ObjTotalMaterialPrinter>();
                        CopyLstFullToLstMaterial(_lstFullPrinter, _lstTotalMaterial);

                        // Get Sum
                        this.sum_Agg1 = _lstTotalMaterial.FirstOrDefault().Total_PV_Agg1;
                        this.sum_Agg2 = _lstTotalMaterial.FirstOrDefault().Total_PV_Agg2;
                        this.sum_Agg3 = _lstTotalMaterial.FirstOrDefault().Total_PV_Agg3;
                        this.sum_Ce1 = _lstTotalMaterial.FirstOrDefault().Total_PV_Ce1;
                        this.sum_Ce2 = _lstTotalMaterial.FirstOrDefault().Total_PV_Ce2;
                        this.sum_Ce3 = _lstTotalMaterial.FirstOrDefault().Total_PV_Ce3;
                        this.sum_Ce4 = _lstTotalMaterial.FirstOrDefault().Total_PV_Ce4;
                        this.sum_Ce5 = _lstTotalMaterial.FirstOrDefault().Total_PV_Ce5;
                        this.sum_Wa1 = _lstTotalMaterial.FirstOrDefault().Total_PV_Wa1;
                        this.sum_Wa2 = _lstTotalMaterial.FirstOrDefault().Total_PV_Wa2;
                        this.sum_Add1 = _lstTotalMaterial.FirstOrDefault().Total_PV_Add1;
                        this.sum_Add2 = _lstTotalMaterial.FirstOrDefault().Total_PV_Add2;
                        this.sum_Add3 = _lstTotalMaterial.FirstOrDefault().Total_PV_Add3;
                        this.sum_Add4 = _lstTotalMaterial.FirstOrDefault().Total_PV_Add4;
                        this.sum_Add5 = _lstTotalMaterial.FirstOrDefault().Total_PV_Add5;
                        this.sum_Add6 = _lstTotalMaterial.FirstOrDefault().Total_PV_Add6;

                        dataTableMaterial = ToDataTableMaterial(_lstTotalMaterial);
                        this.grcTotalMaterial.DataSource = (object)dataTableMaterial;
                        CreateTableTotalMaterial(num_silo_Agg, num_silo_Ce, num_silo_Wa, num_silo_Add, _lstFullPrinter);
                        decimal totalMaterial = 0M;
                        totalMaterial = _lstTotalMaterial[0].Total_PV_Agg1
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Agg2
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Agg3
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Agg4
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Agg5
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Agg6
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Ce1
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Ce2
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Ce3
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Ce4
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Ce5
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Wa1
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Wa2
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Add1
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Add2
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Add3
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Add4
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Add5
                                                + _lstTotalMaterial.FirstOrDefault().Total_PV_Add6;
                        this.sum_CP = totalMaterial;
                        this.gcTotal_Agg1.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
                        this.gcTotal_Agg1.SummaryItem.DisplayFormat = string.Format("Tổng: {0}", totalMaterial);
                    }
                }
            }
        }
        private void CreateTableTotalMaterial(int numAgg, int numCe, int numWa, int numAdd, BindingList<ObjMTCTFullPrinter> _lstFullPrinter)
        {
            this.bandedGridView2.Bands["Total_Agg1"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Agg1;
            this.bandedGridView2.Bands["Total_Agg2"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Agg2;
            this.bandedGridView2.Bands["Total_Agg3"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Agg3;
            this.bandedGridView2.Bands["Total_Agg4"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Agg4;
            this.bandedGridView2.Bands["Total_Agg5"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Agg5;
            this.bandedGridView2.Bands["Total_Agg6"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Agg6;
            this.bandedGridView2.Bands["Total_Ce1"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Ce1;
            this.bandedGridView2.Bands["Total_Ce2"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Ce2;
            this.bandedGridView2.Bands["Total_Ce3"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Ce3;
            this.bandedGridView2.Bands["Total_Ce4"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Ce4;
            this.bandedGridView2.Bands["Total_Ce5"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Ce5;
            this.bandedGridView2.Bands["Total_Wa1"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Wa1;
            this.bandedGridView2.Bands["Total_Wa2"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Wa2;
            this.bandedGridView2.Bands["Total_Add1"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Add1;
            this.bandedGridView2.Bands["Total_Add2"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Add2;
            this.bandedGridView2.Bands["Total_Add3"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Add3;
            this.bandedGridView2.Bands["Total_Add4"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Add4;
            this.bandedGridView2.Bands["Total_Add5"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Add5;
            this.bandedGridView2.Bands["Total_Add6"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Add6;
            
            List<GridBand> bandListAgg = new List<GridBand>();
            bandListAgg.Add(this.bandedGridView2.Bands["Total_Agg1"]);
            bandListAgg.Add(this.bandedGridView2.Bands["Total_Agg2"]);
            bandListAgg.Add(this.bandedGridView2.Bands["Total_Agg3"]);
            bandListAgg.Add(this.bandedGridView2.Bands["Total_Agg4"]);
            bandListAgg.Add(this.bandedGridView2.Bands["Total_Agg5"]);
            bandListAgg.Add(this.bandedGridView2.Bands["Total_Agg6"]);

            foreach (GridBand band in bandListAgg)
            {
                band.Visible = false;
            }
            for (int i = 0; i < numAgg; i++)
            {
                bandListAgg[i].Visible = true;
            }

            List<GridBand> bandListCe = new List<GridBand>();
            bandListCe.Add(this.bandedGridView2.Bands["Total_Ce1"]);
            bandListCe.Add(this.bandedGridView2.Bands["Total_Ce2"]);
            bandListCe.Add(this.bandedGridView2.Bands["Total_Ce3"]);
            bandListCe.Add(this.bandedGridView2.Bands["Total_Ce4"]);
            bandListCe.Add(this.bandedGridView2.Bands["Total_Ce5"]);

            foreach (GridBand band in bandListCe)
            {
                band.Visible = false;
            }
            for (int i = 0; i < numCe; i++)
            {
                bandListCe[i].Visible = true;
            }

            List<GridBand> bandListWa = new List<GridBand>();
            bandListWa.Add(this.bandedGridView2.Bands["Total_Wa1"]);
            bandListWa.Add(this.bandedGridView2.Bands["Total_Wa2"]);
            foreach (GridBand band in bandListWa)
            {
                band.Visible = false;
            }
            for (int i = 0; i < numWa; i++)
            {
                bandListWa[i].Visible = true;
            }

            List<GridBand> bandListAdd = new List<GridBand>(); 
            bandListAdd.Add(this.bandedGridView2.Bands["Total_Add1"]);
            bandListAdd.Add(this.bandedGridView2.Bands["Total_Add2"]);
            bandListAdd.Add(this.bandedGridView2.Bands["Total_Add3"]);
            bandListAdd.Add(this.bandedGridView2.Bands["Total_Add4"]);
            bandListAdd.Add(this.bandedGridView2.Bands["Total_Add5"]);
            bandListAdd.Add(this.bandedGridView2.Bands["Total_Add6"]);
            foreach (GridBand band in bandListAdd)
            {
                band.Visible = false;
            }
            for (int i = 0; i < numAdd; i++)
            {
                bandListAdd[i].Visible = true;
            }
        }

        private void CopyLstFullToLis(BindingList<ObjMTCTFullPrinter> fromLst, BindingList<ObjMTCTPrinter>toLst)
        {
            foreach(ObjMTCTFullPrinter obj in fromLst)
            {
                ObjMTCTPrinter objMTCTPrinter = new ObjMTCTPrinter();
                CopyFullMTCTToMTCT(obj, objMTCTPrinter);
                toLst.Add(objMTCTPrinter);
            }
        }
        private void CopyFullMTCTToMTCT(ObjMTCTFullPrinter from, ObjMTCTPrinter to)
        {
            to.LnNo = from.LnNo;
            to.KLTungMe = from.KLTungMe;
            to.PV_Agg1 = from.PV_Agg1;
            to.PV_Agg1_Manual = from.PVM_Agg1;
            to.PV_Agg2 = from.PV_Agg2;
            to.PV_Agg2_Manual = from.PVM_Agg2;
            to.PV_Agg3 = from.PV_Agg3;
            to.PV_Agg3_Manual = from.PVM_Agg3;
            to.PV_Agg4 = from.PV_Agg4;
            to.PV_Agg4_Manual = from.PVM_Agg4;
            to.PV_Agg5 = from.PV_Agg5;
            to.PV_Agg5_Manual = from.PVM_Agg5;
            to.PV_Agg6 = from.PV_Agg6;
            to.PV_Agg6_Manual = from.PVM_Agg6;
            to.PV_Ce1 = from.PV_Ce1;
            to.PV_Ce1_Manual = from.PVM_Ce1;
            to.PV_Ce2 = from.PV_Ce2;
            to.PV_Ce2_Manual = from.PVM_Ce2;
            to.PV_Ce3 = from.PV_Ce3;
            to.PV_Ce3_Manual = from.PVM_Ce3;
            to.PV_Ce4 = from.PV_Ce4;
            to.PV_Ce4_Manual = from.PVM_Ce4;
            to.PV_Ce5 = from.PV_Ce5;
            to.PV_Ce5_Manual = from.PVM_Ce5;
            to.PV_Wa1 = from.PV_Wa1;
            to.PV_Wa1_Manual = from.PVM_Wa1;
            to.PV_Wa2 = from.PV_Wa2;
            to.PV_Wa2_Manual = from.PVM_Wa2;
            to.PV_Add1 = from.PV_Add1;
            to.PV_Add1_Manual = from.PVM_Add1;
            to.PV_Add2 = from.PV_Add2;
            to.PV_Add2_Manual = from.PVM_Add2;
            to.PV_Add3 = from.PV_Add3;
            to.PV_Add3_Manual = from.PVM_Add3;
            to.PV_Add4 = from.PV_Add4;
            to.PV_Add4_Manual = from.PVM_Add4;
            to.PV_Add5 = from.PV_Add5;
            to.PV_Add5_Manual = from.PVM_Add5;
            to.PV_Add6 = from.PV_Add6;
            to.PV_Add6_Manual = from.PVM_Add6;
        }
        static DataTable ToDataTable(BindingList<ObjMTCTPrinter> objects)
        {
            DataTable dataTable = new DataTable();

            foreach (var property in typeof(ObjMTCTPrinter).GetProperties())
            {
                dataTable.Columns.Add(property.Name, property.PropertyType);
            }

            foreach (ObjMTCTPrinter obj in objects)
            {
                DataRow row = dataTable.NewRow();
                foreach (DataColumn column in dataTable.Columns)
                {
                    row[column.ColumnName] = typeof(ObjMTCTPrinter).GetProperty(column.ColumnName).GetValue(obj);
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        static DataTable ToDataTableMaterial(BindingList<ObjTotalMaterialPrinter> objects)
        {
            DataTable dataTable = new DataTable();

            foreach (var property in typeof(ObjTotalMaterialPrinter).GetProperties())
            {
                dataTable.Columns.Add(property.Name, property.PropertyType);
            }

            foreach (ObjTotalMaterialPrinter obj in objects)
            {
                DataRow row = dataTable.NewRow();
                foreach (DataColumn column in dataTable.Columns)
                {
                    row[column.ColumnName] = typeof(ObjTotalMaterialPrinter).GetProperty(column.ColumnName).GetValue(obj);
                }
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        private void CopyLstFullToLstMaterial(BindingList<ObjMTCTFullPrinter> fromLst, BindingList<ObjTotalMaterialPrinter> toLst)
        {
            ObjTotalMaterialPrinter objTotalMaterial = new ObjTotalMaterialPrinter();
            objTotalMaterial.Total_PV_Agg1
                = objTotalMaterial.Total_PV_Agg2
                = objTotalMaterial.Total_PV_Agg3
                = objTotalMaterial.Total_PV_Agg4
                = objTotalMaterial.Total_PV_Agg5
                = objTotalMaterial.Total_PV_Agg6
                = objTotalMaterial.Total_PV_Ce1
                = objTotalMaterial.Total_PV_Ce2
                = objTotalMaterial.Total_PV_Ce3
                = objTotalMaterial.Total_PV_Ce4
                = objTotalMaterial.Total_PV_Ce5
                = objTotalMaterial.Total_PV_Wa1
                = objTotalMaterial.Total_PV_Wa2
                = objTotalMaterial.Total_PV_Add1
                = objTotalMaterial.Total_PV_Add2
                = objTotalMaterial.Total_PV_Add3
                = objTotalMaterial.Total_PV_Add4
                = objTotalMaterial.Total_PV_Add5
                = objTotalMaterial.Total_PV_Add6 = 0;
            foreach (ObjMTCTFullPrinter obj in fromLst)
            {
                objTotalMaterial.Total_PV_Agg1 += obj.PV_Agg1;
                objTotalMaterial.Total_PV_Agg2 += obj.PV_Agg2;
                objTotalMaterial.Total_PV_Agg3 += obj.PV_Agg3;
                objTotalMaterial.Total_PV_Agg4 += obj.PV_Agg4;
                objTotalMaterial.Total_PV_Agg5 += obj.PV_Agg5;
                objTotalMaterial.Total_PV_Agg6 += obj.PV_Agg6;
                objTotalMaterial.Total_PV_Ce1 += obj.PV_Ce1;
                objTotalMaterial.Total_PV_Ce2 += obj.PV_Ce2;
                objTotalMaterial.Total_PV_Ce3 += obj.PV_Ce3;
                objTotalMaterial.Total_PV_Ce4 += obj.PV_Ce4;
                objTotalMaterial.Total_PV_Ce5 += obj.PV_Ce5;
                objTotalMaterial.Total_PV_Wa1 += obj.PV_Wa1;
                objTotalMaterial.Total_PV_Wa2 += obj.PV_Wa2;
                objTotalMaterial.Total_PV_Add1 += obj.PV_Add1;
                objTotalMaterial.Total_PV_Add2 += obj.PV_Add2;
                objTotalMaterial.Total_PV_Add3 += obj.PV_Add3;
                objTotalMaterial.Total_PV_Add4 += obj.PV_Add4;
                objTotalMaterial.Total_PV_Add5 += obj.PV_Add5;
                objTotalMaterial.Total_PV_Add6 += obj.PV_Add6;
                objTotalMaterial.Name_AGG1 = obj.MaterialName_Agg1;
                objTotalMaterial.Name_AGG2 = obj.MaterialName_Agg2;
                objTotalMaterial.Name_AGG3 = obj.MaterialName_Agg3;
                objTotalMaterial.Name_AGG4 = obj.MaterialName_Agg4;
                objTotalMaterial.Name_AGG5 = obj.MaterialName_Agg5;
                objTotalMaterial.Name_AGG6 = obj.MaterialName_Agg6;
                objTotalMaterial.Name_CE1 = obj.MaterialName_Ce1;
                objTotalMaterial.Name_CE2 = obj.MaterialName_Ce2;
                objTotalMaterial.Name_CE3 = obj.MaterialName_Ce3;
                objTotalMaterial.Name_CE4 = obj.MaterialName_Ce4;
                objTotalMaterial.Name_CE5 = obj.MaterialName_Ce5;
                objTotalMaterial.Name_WA1 = obj.MaterialName_Wa1;
                objTotalMaterial.Name_WA2 = obj.MaterialName_Wa2;
                objTotalMaterial.Name_ADD1 = obj.MaterialName_Add1;
                objTotalMaterial.Name_ADD2 = obj.MaterialName_Add2;
                objTotalMaterial.Name_ADD3 = obj.MaterialName_Add3;
                objTotalMaterial.Name_ADD4 = obj.MaterialName_Add4;
                objTotalMaterial.Name_ADD5 = obj.MaterialName_Add5;
                objTotalMaterial.Name_ADD6 = obj.MaterialName_Add6;

            }
            toLst.Add(objTotalMaterial);
        }


        private void CreateTaableData(int numAgg, int numCe, int numWa, int numAdd, BindingList<ObjMTCTFullPrinter> _lstFullPrinter)
        {
            this.bandedGridView1.Bands["Agg1"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Agg1;
            this.bandedGridView1.Bands["Agg2"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Agg2;
            this.bandedGridView1.Bands["Agg3"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Agg3;
            this.bandedGridView1.Bands["Agg4"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Agg4;
            this.bandedGridView1.Bands["Agg5"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Agg5;
            this.bandedGridView1.Bands["Agg6"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Agg6;
            this.bandedGridView1.Bands["Ce1"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Ce1;
            this.bandedGridView1.Bands["Ce2"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Ce2;
            this.bandedGridView1.Bands["Ce3"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Ce3;
            this.bandedGridView1.Bands["Ce4"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Ce4;
            this.bandedGridView1.Bands["Ce5"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Ce5;
            this.bandedGridView1.Bands["Wa1"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Wa1;
            this.bandedGridView1.Bands["Wa2"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Wa2;
            this.bandedGridView1.Bands["Add1"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Add1;
            this.bandedGridView1.Bands["Add2"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Add2;
            this.bandedGridView1.Bands["Add3"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Add3;
            this.bandedGridView1.Bands["Add4"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Add4;
            this.bandedGridView1.Bands["Add5"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Add5;
            this.bandedGridView1.Bands["Add6"].Caption = _lstFullPrinter.FirstOrDefault().MaterialName_Add6;

            this.head_Agg1 = _lstFullPrinter.FirstOrDefault().MaterialName_Agg1;
            this.head_Agg2 = _lstFullPrinter.FirstOrDefault().MaterialName_Agg2;
            this.head_Agg3 = _lstFullPrinter.FirstOrDefault().MaterialName_Agg3;
            this.head_Agg4 = _lstFullPrinter.FirstOrDefault().MaterialName_Agg4;
            this.head_Agg5 = _lstFullPrinter.FirstOrDefault().MaterialName_Agg5;
            this.head_Agg6 = _lstFullPrinter.FirstOrDefault().MaterialName_Agg6;
            this.head_Ce1 = _lstFullPrinter.FirstOrDefault().MaterialName_Ce1;
            this.head_Ce2 = _lstFullPrinter.FirstOrDefault().MaterialName_Ce2;
            this.head_Ce3 = _lstFullPrinter.FirstOrDefault().MaterialName_Ce3;
            this.head_Ce4 = _lstFullPrinter.FirstOrDefault().MaterialName_Ce4;
            this.head_Ce5 = _lstFullPrinter.FirstOrDefault().MaterialName_Ce5;
            this.head_Wa1 = _lstFullPrinter.FirstOrDefault().MaterialName_Wa1;
            this.head_Wa2 = _lstFullPrinter.FirstOrDefault().MaterialName_Wa2;
            this.head_Add1 = _lstFullPrinter.FirstOrDefault().MaterialName_Add1;
            this.head_Add2 = _lstFullPrinter.FirstOrDefault().MaterialName_Add2;
            this.head_Add3 = _lstFullPrinter.FirstOrDefault().MaterialName_Add3;
            this.head_Add4 = _lstFullPrinter.FirstOrDefault().MaterialName_Add4;
            this.head_Add5 = _lstFullPrinter.FirstOrDefault().MaterialName_Add5;
            this.head_Add6 = _lstFullPrinter.FirstOrDefault().MaterialName_Add6;

            List<DevExpress.XtraGrid.Views.BandedGrid.GridBand> bandListAgg = new List<DevExpress.XtraGrid.Views.BandedGrid.GridBand>();
            bandListAgg.Add(this.bandedGridView1.Bands["Agg1"]);
            bandListAgg.Add(this.bandedGridView1.Bands["Agg2"]);
            bandListAgg.Add(this.bandedGridView1.Bands["Agg3"]);
            bandListAgg.Add(this.bandedGridView1.Bands["Agg4"]);
            bandListAgg.Add(this.bandedGridView1.Bands["Agg5"]);
            bandListAgg.Add(this.bandedGridView1.Bands["Agg6"]);
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in bandListAgg)
            {
                band.Visible = false;
            }
            for (int i = 0; i < numAgg; i++)
            {
                bandListAgg[i].Visible = true;
            }

            List<DevExpress.XtraGrid.Views.BandedGrid.GridBand> bandListCe = new List<DevExpress.XtraGrid.Views.BandedGrid.GridBand>();
            bandListCe.Add(this.bandedGridView1.Bands["Ce1"]);
            bandListCe.Add(this.bandedGridView1.Bands["Ce2"]);
            bandListCe.Add(this.bandedGridView1.Bands["Ce3"]);
            bandListCe.Add(this.bandedGridView1.Bands["Ce4"]);
            bandListCe.Add(this.bandedGridView1.Bands["Ce5"]);
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in bandListCe)
            {
                band.Visible = false;
            }
            for (int i = 0; i < numCe; i++)
            {
                bandListCe[i].Visible = true;
            }

            List<DevExpress.XtraGrid.Views.BandedGrid.GridBand> bandListWa = new List<DevExpress.XtraGrid.Views.BandedGrid.GridBand>();
            bandListWa.Add(this.bandedGridView1.Bands["Wa1"]);
            bandListWa.Add(this.bandedGridView1.Bands["Wa2"]);
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in bandListWa)
            {
                band.Visible = false;
            }
            for (int i = 0; i < numWa; i++)
            {
                bandListWa[i].Visible = true;
            }

            List<DevExpress.XtraGrid.Views.BandedGrid.GridBand> bandListAdd = new List<DevExpress.XtraGrid.Views.BandedGrid.GridBand>();
            bandListAdd.Add(this.bandedGridView1.Bands["Add1"]);
            bandListAdd.Add(this.bandedGridView1.Bands["Add2"]);
            bandListAdd.Add(this.bandedGridView1.Bands["Add3"]);
            bandListAdd.Add(this.bandedGridView1.Bands["Add4"]);
            bandListAdd.Add(this.bandedGridView1.Bands["Add5"]);
            bandListAdd.Add(this.bandedGridView1.Bands["Add6"]);
            foreach (DevExpress.XtraGrid.Views.BandedGrid.GridBand band in bandListAdd)
            {
                band.Visible = false;
            }
            for (int i = 0; i < numAdd; i++)
            {
                bandListAdd[i].Visible = true;
            }

        }

        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            ClearDataPhieuTron();
            LoadPhieuTron();
        }

        private void LoadPhieuTron() => this._presenter.ListPhieuTron(string.Empty, Searching.BuildNew_StartDateTime(this.datTuNgay.DateTime, this.tseFromTime.TimeSpan), Searching.BuildNew_EndDateTime(this.datDenNgay.DateTime, this.tseToTime.TimeSpan), -1, new bool?());

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadSearchDefaultValues();
        }

        private void grvPhieuTron_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DoFocusPhieuTron();
        }

        private void bandedGridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle == 0)
            {
                e.Appearance.BackColor = Color.OrangeRed;
                e.Appearance.BackColor2 = Color.MistyRose;
            }
            if (e.RowHandle == 1)
            {
                e.Appearance.BackColor = Color.Orange;
                e.Appearance.BackColor2 = Color.SeaShell;
            }
            if (e.RowHandle == 2)
            {
                e.Appearance.BackColor = Color.Yellow;
                e.Appearance.BackColor2 = Color.LightYellow;
            }
        }

        private void grvTotalMaterial_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            {
                if (e.Item is GridColumnSummaryItem summaryItem && summaryItem.FieldName == "Total_PV_Agg2")
                {
                    double total = 123 + 123;
                    e.TotalValue = total;
                    e.TotalValueReady = true;
                }
            }
        }

        private void GetParam()
        {
            this._paramListTong = new List<string>();
            this._paramListTong.Add(ConfigManager.TramTronConfig.TenCty);
            this._paramListTong.Add(this.datNgayTron.Text);
            this._paramListTong.Add(this.txtTenCongTruong.Text);
            this._paramListTong.Add(this.txtTenKhachHang.Text);
            this._paramListTong.Add(this.txtTenMAC.Text);
            this._paramListTong.Add(this.txtCuongDo.Text);
            this._paramListTong.Add(this.txtSoPhieu.Text);
            this._paramListTong.Add("Max 200");
            this._paramListTong.Add(this.txtDoSut.Text);
            this._paramListTong.Add(this.txtTaiXe.Text);
            this._paramListTong.Add(this.txtTheTich.Text);
            this._paramListTong.Add(this.txtKhoiLuongDatHang.Text);
            this._paramListTong.Add(this.txtLuyKe.Text);
            this._paramListTong.Add(this.txtXe.Text);
            this._paramListTong.Add(this.txtGioTron.Text);
            this._paramListTong.Add(this.txtDiaDiem.Text);
            this._paramListTong.Add(this.txtMaPhieuTron.Text);
            this._paramListTong.Add("1.5");
            this._paramListTong.Add(this.txtHangMuc.Text);
            this._paramListTong.Add(this.txtNiemChi.Text);
            this._paramListTong.Add(this.txtNguoiTron.Text);
            this._paramListTong.Add(this.txtGioKTTron.Text);
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<int> targetColumn = new List<int>();
            List<string> headerText = new List<string>();
            List<decimal> totalText = new List<decimal>();
            this.GetParam();
            this.GetBandSiloActive(targetColumn, headerText, totalText);
            int[] targetColumnIndexes = Array.Empty<int>();
            targetColumnIndexes = targetColumn.ToArray();
            List<string> headerTextList = new List<string>();
            headerTextList = headerText;
            List<decimal> totalTextList = new List<decimal>();
            totalTextList = totalText;
            PhieuTronChiTietRP1 rptphieutronchitiet = new PhieuTronChiTietRP1(this._paramListTong, totalTextList, headerTextList, this._tablePTCT, sum_CP, targetColumnIndexes);
            PdfExportOptions pdfOptions = rptphieutronchitiet.ExportOptions.Pdf;
            pdfOptions.Compressed = false;
            pdfOptions.ConvertImagesToJpeg = false;

            string fileName = "RptMTCT.pdf";
            string folderMauPhieuPath = ConfigManager.TramTronConfig.ReportPath;
            //string folderMauPhieuPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SourceFolder");
            string pdfFilePath = Path.Combine(folderMauPhieuPath, fileName);
            
            if (!File.Exists(pdfFilePath))
            {
                rptphieutronchitiet.ExportToPdf(pdfFilePath);
                System.Diagnostics.Process.Start(pdfFilePath);
            }
            else
            {
                if (IsFileOpen(pdfFilePath))
                {
                    TramTromMessageBox.ShowWarningDialog(string.Format("{0} đang mở bởi một chương trình khác \n Vui lòng tắt {0} đang mở.", pdfFilePath));
                }
                else
                {
                    File.Delete(pdfFilePath);
                    rptphieutronchitiet.ExportToPdf(pdfFilePath);
                    System.Diagnostics.Process.Start(pdfFilePath);
                }
            }
        }

        private void GetBandSiloActive(List<int> targetColumn, List<string> headerText, List<decimal> totalText)
        {
            targetColumn.Add(0);
            targetColumn.Add(1);
            headerText.Add("LnNo");
            headerText.Add("Thể tích");
            totalText.Add(0);
            totalText.Add(sum_KL);
            if (this.bandedGridView1.Bands["Agg1"].ReallyVisible)
            {
                targetColumn.Add(2);
                headerText.Add(head_Agg1);
                totalText.Add(sum_Agg1);
            }
            if (this.bandedGridView1.Bands["Agg2"].ReallyVisible)
            {
                targetColumn.Add(4);
                headerText.Add(head_Agg2);
                totalText.Add(sum_Agg2);
            }
            if (this.bandedGridView1.Bands["Agg3"].ReallyVisible)
            {
                targetColumn.Add(6);
                headerText.Add(head_Agg3);
                totalText.Add(sum_Agg3);
            }
            if (this.bandedGridView1.Bands["Agg4"].ReallyVisible)
            {
                targetColumn.Add(8);
                headerText.Add(head_Agg4);
                totalText.Add(sum_Agg4);
            }
            if (this.bandedGridView1.Bands["Agg5"].ReallyVisible)
            {
                targetColumn.Add(10);
                headerText.Add(head_Agg5);
                totalText.Add(sum_Agg5);
            }
            if (this.bandedGridView1.Bands["Agg6"].ReallyVisible)
            {
                targetColumn.Add(12);
                headerText.Add(head_Agg6);
                totalText.Add(sum_Agg6);
            }
            if (this.bandedGridView1.Bands["Ce1"].ReallyVisible)
            {
                targetColumn.Add(14);
                headerText.Add(head_Ce1);
                totalText.Add(sum_Ce1);
            }
            if (this.bandedGridView1.Bands["Ce2"].ReallyVisible)
            {
                targetColumn.Add(16);
                headerText.Add(head_Ce2);
                totalText.Add(sum_Ce2);
            }
            if (this.bandedGridView1.Bands["Ce3"].ReallyVisible)
            {
                targetColumn.Add(18);
                headerText.Add(head_Ce3);
                totalText.Add(sum_Ce3);
            }
            if (this.bandedGridView1.Bands["Ce4"].ReallyVisible)
            {
                targetColumn.Add(20);
                headerText.Add(head_Ce4);
                totalText.Add(sum_Ce4);
            }
            if (this.bandedGridView1.Bands["Ce5"].ReallyVisible)
            {
                targetColumn.Add(22);
                headerText.Add(head_Ce5);
                totalText.Add(sum_Ce5);
            }
            if (this.bandedGridView1.Bands["Wa1"].ReallyVisible)
            {
                targetColumn.Add(24);
                headerText.Add(head_Wa1);
                totalText.Add(sum_Wa1);
            }
            if (this.bandedGridView1.Bands["Wa2"].ReallyVisible)
            {
                targetColumn.Add(26);
                headerText.Add(head_Wa2);
                totalText.Add(sum_Wa2);
            }
            if (this.bandedGridView1.Bands["Add1"].ReallyVisible)
            {
                targetColumn.Add(28);
                headerText.Add(head_Add1);
                totalText.Add(sum_Add1);
            }
            if (this.bandedGridView1.Bands["Add2"].ReallyVisible)
            {
                targetColumn.Add(30);
                headerText.Add(head_Add2);
                totalText.Add(sum_Add2);
            }
            if (this.bandedGridView1.Bands["Add3"].ReallyVisible)
            {
                targetColumn.Add(32);
                headerText.Add(head_Add3);
                totalText.Add(sum_Add3);
            }
            if (this.bandedGridView1.Bands["Add4"].ReallyVisible)
            {
                targetColumn.Add(34);
                headerText.Add(head_Add4);
                totalText.Add(sum_Add4);
            }
            if (this.bandedGridView1.Bands["Add5"].ReallyVisible)
            {
                targetColumn.Add(36);
                headerText.Add(head_Add5);
                totalText.Add(sum_Add5);
            }
            if (this.bandedGridView1.Bands["Add6"].ReallyVisible)
            {
                targetColumn.Add(38);
                headerText.Add(head_Add6);
                totalText.Add(sum_Add6);
            }


        }
        static bool IsFileOpen(string filePath)
        {
            try
            {
                using (System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite, System.IO.FileShare.None))
                {
                    fs.Close();
                }

                return false;
            }
            catch (System.IO.IOException)
            {
                return true;
            }
        }


        private void DataTableToDataTable(DataTable fromTable, DataTable toTable)
        {
            toTable = new DataTable();

            // Sao chép cấu trúc cột từ DataTable có sẵn
            foreach (DataColumn column in fromTable.Columns)
            {
                toTable.Columns.Add(new DataColumn(column.ColumnName, column.DataType));
            }

            // Sao chép dữ liệu từ DataTable có sẵn
            foreach (DataRow row in fromTable.Rows)
            {
                DataRow newRow = toTable.NewRow();
                newRow.ItemArray = row.ItemArray;
                toTable.Rows.Add(newRow);
            }
        }

        private void WriteDetailInvoice(List<string> param, DataTable dataTable, DataTable dataTable2, DataTable dataTable3)
        {
            try
            {
                if (CopyTempFile() && !this._error)
                {
                    string sourceFileName = ConfigManager.TramTronConfig.PICTPath;

                    string fileName = "";
                    string filePathMau = ConfigManager.TramTronConfig.PICTPath;
                    if (filePathMau != string.Empty)
                    {
                        fileName = Path.GetFileName(filePathMau);
                    }
                    string folderDesPhieuPath = ConfigManager.TramTronConfig.ReportPath;

                    string filePath = Path.Combine(folderDesPhieuPath, fileName);

                    Application wordProcessor = new Application();

                    Document document = wordProcessor.Documents.Open(filePath);

                    for (int index = 0; index < param.Count; ++index)
                    {
                        string findText = "{" + index + "}";
                        ReplaceText(wordProcessor, findText, param[index]);
                    }

                    //managerLoadDataToTable(wordProcessor, dataTable);

                    CreateTablePICT(document, dataTable, dataTable2, dataTable3);

                    wordProcessor.ActiveDocument.SaveAs(filePath, 12);
                    wordProcessor.Quit();
                }
            }
            catch (Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }
        private void ReplaceText(Microsoft.Office.Interop.Word.Application word, string searchText, string replacementText)
        {
            Microsoft.Office.Interop.Word.Selection selection = word.Selection;

            Microsoft.Office.Interop.Word.Find find = selection.Find;
            find.ClearFormatting();
            find.Text = searchText;

            Microsoft.Office.Interop.Word.Replacement replacement = find.Replacement;
            replacement.ClearFormatting();
            replacement.Text = replacementText;

            object missing = System.Reflection.Missing.Value;
            object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

            find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref replaceAll, ref missing, ref missing, ref missing, ref missing);
        }
        private bool CopyTempFile()
        {
            string sourceFileName = ConfigManager.TramTronConfig.PICTPath;

            string fileName = "";
            string filePath = ConfigManager.TramTronConfig.PICTPath;
            if (filePath != string.Empty)
            {
                fileName = Path.GetFileName(filePath);
            }

            string folderDesPhieuPath = ConfigManager.TramTronConfig.ReportPath;

            string str = Path.Combine(folderDesPhieuPath, fileName);

            try
            {
                if (!File.Exists(str))
                    File.Copy(sourceFileName, str, true);
                this._error = false;
            }
            catch (Exception ex)
            {
                this._error = true;
                TramTromMessageBox.ShowErrorDialog(ex.ToString());

            }
            return true;
        }

        private void btnInPCT_Click(object sender, EventArgs e)
        {

            /*foreach (DataRow row in taable.Rows)
            {
                foreach (DataColumn column in taable.Columns)
                {
                    Console.WriteLine(column.ColumnName + ": " + row[column]);
                    TramTromMessageBox.ShowMessageDialog(column.ColumnName + ": " + row[column]);
                }
            }*/
            DataTable dataTableNameMaterial = CreateTableNameMaterial(this.dataTableMaterial);
            DataTable dataTableSumMaterial = CreateTableSumMaterial(this.dataTableMaterial);
            this.GetParam();
            WriteDetailInvoice(this._paramListTong, this._tablePTCT, dataTableNameMaterial, dataTableSumMaterial);
            PrintPTFromFile();
            
        }
        private DataTable CreateTableNameMaterial(DataTable yourSourceDataTable)
        {
            List<string> columnNamesSumCol_Agg = GetNameMaterialSumCol();

            DataTable newDataTable = new DataTable();

            newDataTable.Columns.Add("LnNo", typeof(string)); // Đổi kiểu dữ liệu nếu cần
            newDataTable.Columns.Add("KLTungMe", typeof(string));
            // Thêm cột vào bảng mới
            foreach (string columnName in columnNamesSumCol_Agg)
            {
                if (yourSourceDataTable.Columns.Contains(columnName))
                {
                    // Nếu cột tồn tại trong bảng nguồn, thêm cột mới vào bảng mới
                    newDataTable.Columns.Add(columnName, yourSourceDataTable.Columns[columnName].DataType);
                }
                else
                {
                    // Xử lý trường hợp cột không tồn tại trong bảng nguồn
                    // (Bạn có thể gán giá trị mặc định hoặc thực hiện xử lý phù hợp tùy thuộc vào yêu cầu của bạn)
                    newDataTable.Columns.Add(columnName, typeof(string)); // Ví dụ: Giả sử kiểu dữ liệu là string
                }
            }

            // Sao chép dữ liệu từ bảng nguồn sang bảng mới
            foreach (DataRow sourceRow in yourSourceDataTable.Rows)
            {
                DataRow newRow = newDataTable.NewRow();
                newRow["LnNo"] = "LnNo";
                newRow["KLTungMe"] = "Thể tích";

                // Duyệt qua từng cột và sao chép giá trị dựa vào tên cột
                foreach (string columnName in columnNamesSumCol_Agg)
                {
                    // Kiểm tra xem cột có tồn tại trong bảng nguồn hay không
                    if (yourSourceDataTable.Columns.Contains(columnName))
                    {
                        // Lấy index của cột trong bảng nguồn và truy xuất giá trị từ hàng nguồn
                        int columnIndex = yourSourceDataTable.Columns.IndexOf(columnName);
                        newRow[columnName] = sourceRow[columnIndex];
                    }
                    else
                    {
                        // Xử lý trường hợp cột không tồn tại trong bảng nguồn
                        // (Bạn có thể gán giá trị mặc định hoặc thực hiện xử lý phù hợp tùy thuộc vào yêu cầu của bạn)
                        newRow[columnName] = "N/A";
                    }
                }

                newDataTable.Rows.Add(newRow);
            }
            return newDataTable;
        }

        private DataTable CreateTableSumMaterial(DataTable yourSourceDataTable)
        {
            List<string> columnNamesSumCol_Agg = GetSumMaterial();

            DataTable newDataTable = new DataTable();

            newDataTable.Columns.Add("LnNo", typeof(string));
            newDataTable.Columns.Add("KLTungMe", typeof(string));
            // Thêm cột vào bảng mới
            foreach (string columnName in columnNamesSumCol_Agg)
            {
                if (yourSourceDataTable.Columns.Contains(columnName))
                {
                    // Nếu cột tồn tại trong bảng nguồn, thêm cột mới vào bảng mới
                    newDataTable.Columns.Add(columnName, yourSourceDataTable.Columns[columnName].DataType);
                }
                else
                {
                    // Xử lý trường hợp cột không tồn tại trong bảng nguồn
                    // (Bạn có thể gán giá trị mặc định hoặc thực hiện xử lý phù hợp tùy thuộc vào yêu cầu của bạn)
                    newDataTable.Columns.Add(columnName, typeof(string)); // Ví dụ: Giả sử kiểu dữ liệu là string
                }
            }

            // Sao chép dữ liệu từ bảng nguồn sang bảng mới
            foreach (DataRow sourceRow in yourSourceDataTable.Rows)
            {
                DataRow newRow = newDataTable.NewRow();
                newRow["LnNo"] = "N/A";
                newRow["KLTungMe"] = sum_KL;
                

                // Duyệt qua từng cột và sao chép giá trị dựa vào tên cột
                foreach (string columnName in columnNamesSumCol_Agg)
                {
                    // Kiểm tra xem cột có tồn tại trong bảng nguồn hay không
                    if (yourSourceDataTable.Columns.Contains(columnName))
                    {
                        // Lấy index của cột trong bảng nguồn và truy xuất giá trị từ hàng nguồn
                        int columnIndex = yourSourceDataTable.Columns.IndexOf(columnName);
                        newRow[columnName] = sourceRow[columnIndex];
                    }
                    else
                    {
                        // Xử lý trường hợp cột không tồn tại trong bảng nguồn
                        // (Bạn có thể gán giá trị mặc định hoặc thực hiện xử lý phù hợp tùy thuộc vào yêu cầu của bạn)
                        newRow[columnName] = "N/A";
                    }
                }

                newDataTable.Rows.Add(newRow);
            }
            return newDataTable;
        }
        private List<string> GetNameMaterialSumCol()
        {
            string[] columnNamesSumCol_Agg = new string[] {"Name_AGG1", "Name_AGG2", "Name_AGG3", "Name_AGG4", "Name_AGG5", "Name_AGG6"};
            string[] columnNamesSumCol_Ce = new string[] {"Name_CE1", "Name_CE2", "Name_CE3", "Name_CE4", "Name_CE5"};
            string[] columnNamesSumCol_Wa = new string[] {"Name_WA1", "Name_WA2"};
            string[] columnNamesSumCol_Add = new string[] {"Name_ADD1", "Name_ADD2", "Name_ADD3", "Name_ADD4", "Name_ADD5", "Name_ADD6"};

            //this.num_silo_Agg
            List<string> newStringNameMaterial = new List<string>();
            for (int i = 0; i < this.num_silo_Agg; i++)
            {
                newStringNameMaterial.Add(columnNamesSumCol_Agg[i]);
            }
            for (int i = 0; i < this.num_silo_Ce; i++)
            {
                newStringNameMaterial.Add(columnNamesSumCol_Ce[i]);
            }
            for (int i = 0; i < this.num_silo_Wa; i++)
            {
                newStringNameMaterial.Add(columnNamesSumCol_Wa[i]);
            }
            for (int i = 0; i < this.num_silo_Add; i++)
            {
                newStringNameMaterial.Add(columnNamesSumCol_Add[i]);
            }
            return newStringNameMaterial;
        }
        private List<string> GetSumMaterial()
        {
            string[] columnNamesSumCol_Agg = new string[] { "Total_PV_Agg1", "Total_PV_Agg2", "Total_PV_Agg3", "Total_PV_Agg4", "Total_PV_Agg5", "Total_PV_Agg6" };
            string[] columnNamesSumCol_Ce = new string[] { "Total_PV_Ce1", "Total_PV_Ce2", "Total_PV_Ce3", "Total_PV_Ce4", "Total_PV_Ce5" };
            string[] columnNamesSumCol_Wa = new string[] { "Total_PV_Wa1", "Total_PV_Wa2" };
            string[] columnNamesSumCol_Add = new string[] { "Total_PV_Add1", "Total_PV_Add2", "Total_PV_Add3", "Total_PV_Add4", "Total_PV_Add5", "Total_PV_Add6" };

            //this.num_silo_Agg
            List<string> newStringNameMaterial = new List<string>();
            for (int i = 0; i < this.num_silo_Agg; i++)
            {
                newStringNameMaterial.Add(columnNamesSumCol_Agg[i]);
            }
            for (int i = 0; i < this.num_silo_Ce; i++)
            {
                newStringNameMaterial.Add(columnNamesSumCol_Ce[i]);
            }
            for (int i = 0; i < this.num_silo_Wa; i++)
            {
                newStringNameMaterial.Add(columnNamesSumCol_Wa[i]);
            }
            for (int i = 0; i < this.num_silo_Add; i++)
            {
                newStringNameMaterial.Add(columnNamesSumCol_Add[i]);
            }
            return newStringNameMaterial;
        }
        private void PrintPTFromFile()
        {
            try
            {
                string sourceFileName = ConfigManager.TramTronConfig.PICTPath;

                string fileName = "";
                string filePathMau = ConfigManager.TramTronConfig.PICTPath;
                if (filePathMau != string.Empty)
                {
                    fileName = Path.GetFileName(filePathMau);
                }
                string folderDesPhieuPath = ConfigManager.TramTronConfig.ReportPath;
                string wordFilePath = Path.Combine(folderDesPhieuPath, fileName);
                string pdfFilePath = Path.ChangeExtension(wordFilePath, ".pdf");

                var wordApp = new Application();

                // Export Word document as PDF
                var wordDoc = wordApp.Documents.Add(wordFilePath);
                wordApp.ActiveDocument.ExportAsFixedFormat(pdfFilePath, WdExportFormat.wdExportFormatPDF);

                // Close and release Word document
                wordDoc.Close(false);
                Marshal.ReleaseComObject(wordDoc);

                // Delete the Word document
                if (File.Exists(wordFilePath))
                {
                    try
                    {
                        File.Delete(wordFilePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Lỗi khi xóa tệp tin Word: {ex.Message}");
                        TramTronLogger.WriteError(ex);
                    }
                }

                if (File.Exists(pdfFilePath))
                {
                    // In file PDF vừa tạo
                    PrintPDF(pdfFilePath);
                }
                else
                {
                    TramTromMessageBox.ShowMessageDialog("Không tìm thấy file PDF để in");
                }

                wordApp.Quit();
            }
            catch (Exception ex)
            {
                TramTromMessageBox.ShowErrorDialog(ex.ToString());
            }
        }

        private void PrintPDF(string pdfFilePath)
        {
            try
            {
                // Hiển thị hộp thoại chọn máy in
                string printerName = ConfigManager.TramTronConfig.MayInPICT;

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Verb = "printto",
                    FileName = pdfFilePath,
                    UseShellExecute = true,
                    Arguments = $"\"{printerName}\""
                };

                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    process.WaitForExit(); // Chờ đến khi quá trình in kết thúc
                    TramTromMessageBox.ShowMessageDialog("In file hoàn tất");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi in file PDF: {ex.Message}");
                TramTronLogger.WriteError(ex);
            }
        }
        private void LoadDataToTable(Application word, DataTable dataTable)
        {
            if (word.Documents.Count > 0)
            {
                Document document = word.ActiveDocument;

                if (document.Tables.Count > 0)
                {
                    Table table = document.Tables[1]; // Tables trong Word bắt đầu từ 1, không phải 0

                    //table.Delete();

                    int rowCount = dataTable.Rows.Count;
                    int columnCount = dataTable.Columns.Count;

                    // Thêm dòng mới cho mỗi hàng trong DataTable
                    for (int i = 0; i < rowCount; i++)
                    {
                        table.Rows.Add();

                        // Thêm dữ liệu từ DataTable vào các ô trong dòng mới
                        for (int j = 0; j < columnCount; j++)
                        {
                            //table.Cell(i + 1, j + 1).Range.Text = dataTable.Rows[i][j].ToString();
                        }
                    }
                }
            }
        }

        private void CreateTablePICT(Document doc, DataTable dataTable, DataTable dataTable2, DataTable dataTable3)
        {
            List<string> stringList = new List<string>();
            int Index = 0;

            for (int index = 0; index < dataTable.Columns.Count; ++index)
            {
                if (index < 2)
                {
                    stringList.Add(dataTable.Columns[index].ColumnName);
                    ++Index;
                }
                else if (Convert.ToDouble(dataTable.Rows[0][index]) != 0.0)
                {
                    stringList.Add(dataTable.Columns[index].ColumnName);
                    ++Index;
                }
            }

           

            Microsoft.Office.Interop.Word.Table table = doc.Tables[2];

            Cell cell1 = table.Cell(1, 1);
            object obj1 = 1;
            ref object local1 = ref obj1;
            object obj2 = Index;
            ref object local2 = ref obj2;
            cell1.Split(ref local1, ref local2);

            Cell cell2 = table.Cell(2, 1);
            obj1 = 1;
            ref object local3 = ref obj1;
            obj2 = Index;
            ref object local4 = ref obj2;
            cell2.Split(ref local3, ref local4);

            Cell cell3 = table.Cell(3, 1);
            obj1 = 1;
            ref object local5 = ref obj1;
            obj2 = Index;
            ref object local6 = ref obj2;
            cell3.Split(ref local5, ref local6);

            Cell cell4 = table.Cell(4, 1);
            obj1 = 1;
            ref object local7 = ref obj1;
            obj2 = Index;
            ref object local8 = ref obj2;
            cell4.Split(ref local7, ref local8);

            table.AutoFitBehavior(WdAutoFitBehavior.wdAutoFitFixed);
            table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            table.Range.Font.Size = 9f;
            table.Range.Font.Name = "Times New Roman";
            object obj3 = "Table Grid";
            object missing = System.Type.Missing;
            table.set_Style(ref obj3);

            for (int index = 0; index < Index; ++index)
            {
                table.Cell(1, index + 1).Range.Text = dataTable2.Rows[0][index].ToString();
                table.Cell(1, index + 1).Range.Bold = 1;

                table.Cell(2, index + 1).Range.Text = dataTable.Rows[0][stringList[index]].ToString();
                table.Cell(2, 1).Range.Bold = 1;

                table.Cell(3, index + 1).Range.Text = dataTable.Rows[1][stringList[index]].ToString();
                table.Cell(3, 1).Range.Bold = 1;

                table.Cell(4, index + 1).Range.Text = dataTable.Rows[2][stringList[index]].ToString();
                table.Cell(4, 1).Range.Bold = 1;
            }

            int num1 = 4;
            table.Rows.Add(ref missing);
            int num2 = num1 + 1;
            table.Rows.Add(ref missing);
            int Row = num2 + 1;
            float columnSum = 0.0f;


            for (int rowHandle = 3; rowHandle < dataTable.Rows.Count; ++rowHandle)
            {
                for (int index = 0; index < Index; ++index)
                {
                    table.Cell(Row, index + 1).Range.Text = dataTable.Rows[rowHandle][stringList[index]].ToString();
                    //columnSum += Convert.ToSingle(dataTable.Rows[rowHandle][stringList[index]]);
                }

                table.Rows.Add(ref missing);
                ++Row;
            }

            dataTable.Rows.Remove(dataTable.Rows[0]);
            dataTable.Rows.Remove(dataTable.Rows[0]);
            dataTable.Rows.Remove(dataTable.Rows[0]);

            float num3 = 0.0f;

            for (int index = 1; index < Index; ++index)
            {
                table.Cell(Row, index + 1).Range.Text = dataTable3.Rows[0][index].ToString();
                //TramTromMessageBox.ShowMessageDialog(dataTable3.Rows[0][index].ToString());
                
                table.Cell(Row, index + 1).Range.Bold = 1;

                if (index > 1)
                    num3 += Convert.ToSingle(dataTable.Compute($"SUM([{stringList[index]}])", ""));
            }

            table.Cell(Row, 1).Range.Text = "Tổng";
            table.Rows.Add(ref missing);
            int num4 = Row + 1;
            table.Rows[num4].Cells[1].Merge(table.Rows[num4].Cells[Index]);
            table.Cell(num4, 1).Range.Text = num3.ToString();
            table.Cell(num4, 1).Range.Bold = 1;
            table.Cell(num4, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            table.Rows[5].Cells[1].Merge(table.Rows[5].Cells[Index]);
            table.Cell(5, 1).Range.Text = "CHI TIẾT MẺ TRỘN (DETAIL)";
            table.Cell(5, 1).Range.Bold = 1;
            table.Cell(5, 1).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            table.Rows[5].Alignment = WdRowAlignment.wdAlignRowLeft;
        }

        private float ConvertToFloat(object value)
        {
            if (value == null || DBNull.Value.Equals(value))
            {
                return 0.0f;
            }

            float result;
            if (float.TryParse(value.ToString(), out result))
            {
                return result;
            }

            return 0.0f;
        }
    }
}

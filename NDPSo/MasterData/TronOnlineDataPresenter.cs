using NDPSo.Data;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class TronOnlineDataPresenter : MasterDataPresenter<ITronOnlineView>
    {
        public TronOnlineDataPresenter(ITronOnlineView view) : base(view)
        {
        }

        public ObjDuLieuTron GetDLTByKey(int id) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetDuLieuTronByKey(id);

        public ObjHopDong GetHopDongByKey(int hdID) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetHopDongByKey(hdID);

        public ObjPhieuTron CreateAndSaveNewPhieuTron(ObjHopDong objHD, bool isManual)
        {
            ObjPhieuTron saveNewPhieuTron = new ObjPhieuTron();
            saveNewPhieuTron.MaPhieuTron = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetNextCode("PhieuTron");
            saveNewPhieuTron.Status = new int?(3);
            saveNewPhieuTron.HopDongID = new int?(objHD.HopDongID);
            saveNewPhieuTron.KhachHangID = objHD.KhachHangID;
            saveNewPhieuTron.CongTruongID = objHD.CongTruongID;
            saveNewPhieuTron.MACID = objHD.MACID;
            saveNewPhieuTron.HangMucID = objHD.HangMucID;
            saveNewPhieuTron.NgayPhieuTron = new DateTime?(DateTime.Now);
            saveNewPhieuTron.KLDuTinh = objHD.DLT_KLDuTinh;
            saveNewPhieuTron.MinKLTron = objHD.DLT_KLTronNhoNhat;
            saveNewPhieuTron.MaxKLTron = objHD.DLT_KLTronLonNhat;
            saveNewPhieuTron.SLMeDuTinh = objHD.DLT_SLMeDuTinh;
            saveNewPhieuTron.KLDuTinhCuaTungMe = objHD.DLT_KLDuTinhCuaTungMe;
            saveNewPhieuTron.KLBuTruMeCuoi = objHD.DLT_KLBuTruMeCuoi;
            saveNewPhieuTron.IsQueued = new bool?(isManual);
            saveNewPhieuTron.CreatedBy = new int?(GlobalValues.UserID);
            saveNewPhieuTron.CreationDate = new DateTime?(DateTime.Now);
            if (objHD.TongPhieu == 0)
            {
                saveNewPhieuTron.NoPhieu = 1;
            }
            else
            {
                saveNewPhieuTron.NoPhieu = objHD.TongPhieu + 1;
            }
            BindingList<ObjPhieuTron> blstCT = new BindingList<ObjPhieuTron>();
            blstCT.Add(saveNewPhieuTron);
            if (MasterDataPresenter<ITronOnlineView>._iMasterDataModel.SavePhieuTron(blstCT))
                saveNewPhieuTron = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetPhieuTronByCode(saveNewPhieuTron.MaPhieuTron);
            return saveNewPhieuTron;
        }

        public void ListPhieuTron_ForTronOnline() => this._iView.BLstPhieuTron = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListPhieuTron_ForTronOnline();

        public void ListPhieuTron_ByIsQueued(bool isQueued) => this._iView.BLstPhieuTron = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListPhieuTron_ByIsQueued(isQueued);

        public void ListMAC() => this._iView.BLstMAC = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListMAC();
        public void ListMACSilo_ByPhieuTronID(int ptID) => this._iView.BLstMACSilo = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListMACSilo_ByPhieuTronID(ptID);

        public void ListMACSilo_ByHopDongID(int hdID) => this._iView.BLstMACSilo = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListMACSilo_ByHopDongID(hdID);

        public void ListSilo() => this._iView.BLstSilo = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListSilo_ByActivated(true);

        public void ListSiloLogicAgg() => this._iView.BLstSiloLogicAG = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListSilo_ByActivated_ByMaNhomSilo(true, "Agg");
        public void ListSiloLogicAdd() => this._iView.BLstSiloLogicAD = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListSilo_ByActivated_ByMaNhomSilo(true, "Add");
        public void ListSiloLogicCE() => this._iView.BLstSiloLogicCE = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListSilo_ByActivated_ByMaNhomSilo(true, "Ce");
        public void ListSilo_DoAmHutAgg() => this._iView.BLstSilo_DoAmHutAgg = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListSilo_ByActivated_ByMaNhomSilo(true, "Agg");

        public void ListNhanVien() => this._iView.BLstNhanVien = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListNhanVien_ByCondition(new DateTime?(DateTime.MinValue), new DateTime?(DateTime.MinValue), string.Empty, string.Empty, string.Empty, new bool?(true));
        public void ListTaiXe() => this._iView.BLstTaiXe = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListTaiXe_ByCondition(new DateTime?(DateTime.MinValue), new DateTime?(DateTime.MinValue), string.Empty, string.Empty, string.Empty, new bool?(true));

        public void ListXe() => this._iView.BLstXe = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListXe_ByCondition(new DateTime?(DateTime.MinValue), new DateTime?(DateTime.MinValue), string.Empty, new bool?(true));
        public void ListWei() => this._iView.BLstWeigh = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListWeigh();
        public void ListPhieuTronStatus() => this._iView.LstPhieuTronStatus = Converter.EnumToListFieldCode<Enums.PhieuTronStatus>(true);

        public void ListDuLieuTronStatus() => this._iView.LstDuLieuTronStatus = Converter.EnumToListFieldCode<Enums.DuLieuTronStatus>(true);

        public void ListWeiSiloSaving() => this._iView.BLstWeiSiloSaving = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListWeiSiloSaving();

        public void ListWeiSiloVisible() => this._iView.BLstWeiSiloVisible = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListWeiSiloVisible();

        public void ListTimerPara() => this._iView.BLstTimerPara = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListTimerPara();

        public void ListDuLieuTron() => this._iView.BLstDuLieuTron = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ListDuLieuTron(true);

        public void BuildNewMeTron1(ObjPhieuTron objPT) => this._iView.CurMeTron = new ObjMeTron()
        {
            PhieuTronID = objPT.PhieuTronID,
            NgayMeTron = new DateTime?(DateTime.Now),
            KhoiLuong = new Decimal?(0M),
            LstMeTronChiTiet = new List<ObjMeTronChiTiet>()
        };

        public void GetLatestPhieuTron()
        {
        }

        public void BuildNewMeTronChiTiet(
          string maSilo,
          ObjMACSilo objMS,
          ObjSilo objSilo,
          SiloOnline objSiloOnline,
          int sttSiloPLC,
          bool isManualPLC,
          int trangThaiAutoMan,
          int phieuTronID,
          int valueBat,
          int valueBatAuto,
          int valueBatMan,
          int plcSaveId)
        {
            int? nullable1 = new int?();
            Decimal? nullable2 = new Decimal?();
            bool? nullable3 = new bool?();
            switch (trangThaiAutoMan)
            {
                case 0:
                    nullable3 = new bool?(true);
                    break;
                case 1:
                    nullable3 = new bool?(false);
                    break;
            }
            if (objMS != null)
            {
                nullable1 = new int?(objMS.MACSiloID);
                nullable2 = objMS.SiloValue;
            }
            decimal numTol = 0;
            decimal numPerTol = 0;
            ObjMeTronChiTiet objMTCT;
            if (objSilo != null && objSiloOnline != null)
            {
                numTol = objSiloOnline.KLCanCan - valueBat;
                numPerTol = numTol/ objSiloOnline.KLCanCan * 100M;
                objMTCT = new ObjMeTronChiTiet()
                {
                    MACSiloID = nullable1,
                    Value = new Decimal?(objSiloOnline.KLCanCan),
                    ValueBat = new Decimal?((Decimal)valueBat),
                    ValueBatAuto = new Decimal?((Decimal)valueBatAuto),
                    ValueBatMan = new Decimal?((Decimal)valueBatMan),
                    ValueTol = new Decimal?((Decimal)numTol),
                    ValuePerTol = new Decimal?((Decimal)numPerTol),
                    SiloValue = nullable2,
                    SaiSoDuoi = objSilo.SaiSoDuoi,
                    SaiSoTren = objSilo.SaiSoTren,
                    KLCanNhoNhat = objSilo.KLCanNhoNhat,
                    KLCanLonNhat = objSilo.KLCanLonNhat,
                    TGNhapNhaOn = objSilo.TGNhapNhaOn,
                    TGNhapNhaOff = objSilo.TGNhapNhaOff,
                    TGKiemTraVatLieuRoi = objSilo.TGKiemTraVatLieuRoi,
                    KLRoi = objSilo.KLRoi,
                    KLDT_Tu1 = objSilo.KLDT_Tu1,
                    KLDT_Tu2 = objSilo.KLDT_Tu2,
                    KLDT_Tu3 = objSilo.KLDT_Tu3,
                    KLDT_Den1 = objSilo.KLDT_Den1,
                    KLDT_Den2 = objSilo.KLDT_Den2,
                    KLDT_Den3 = objSilo.KLDT_Den3,
                    DoAm_NhomSlioAgg = objSilo.DoAm_NhomSlioAgg,
                    DoHutNuoc_NhomSiloAgg = objSilo.DoHutNuoc_NhomSiloAgg,
                    SoiTrongCat_Percent_NhomSiloAgg = objSilo.SoiTrongCat_NhomSiloAgg,
                    SoiTrongCat_SiloId_NhomSiloAgg = objSilo.SoiTrongCat_TruVaoSilo_NhomSiloAgg,
                    MaterialID = objSilo.MaterialID,
                    MaterialCode = objSilo.MaterialCode,
                    MaterialName = objSilo.MaterialName,
                    MaSilo = maSilo,
                    STTSiloPLC = new int?(sttSiloPLC),
                    IsManual = nullable3,
                    NgayMTCT = new DateTime?(DateTime.Now),
                    PLCSaveId = new int?(plcSaveId),
                    CreatedBy = new int?(GlobalValues.UserID),
                    CreationDate = new DateTime?(DateTime.Now)
                };
            }
                
            else
                objMTCT = new ObjMeTronChiTiet()
                {
                    Value = new Decimal?(0M),
                    ValueBat = new Decimal?((Decimal)valueBat),
                    ValueBatAuto = new Decimal?((Decimal)valueBatAuto),
                    ValueBatMan = new Decimal?((Decimal)valueBatMan),
                    ValueTol = new Decimal?(0M),
                    ValuePerTol = new Decimal?(0M),
                    SiloValue = new Decimal?(0M),
                    SaiSoDuoi = new Decimal?(0M),
                    SaiSoTren = new Decimal?(0M),
                    KLCanNhoNhat = new Decimal?(0M),
                    KLCanLonNhat = new Decimal?(0M),
                    TGNhapNhaOn = new Decimal?(0M),
                    TGNhapNhaOff = new Decimal?(0M),
                    TGKiemTraVatLieuRoi = new Decimal?(0M),
                    KLRoi = new Decimal?(0M),
                    KLDT_Tu1 = new Decimal?(0M),
                    KLDT_Tu2 = new Decimal?(0M),
                    KLDT_Tu3 = new Decimal?(0M),
                    KLDT_Den1 = new Decimal?(0M),
                    KLDT_Den2 = new Decimal?(0M),
                    KLDT_Den3 = new Decimal?(0M),
                    DoAm_NhomSlioAgg = new Decimal?(0M),
                    DoHutNuoc_NhomSiloAgg = new Decimal?(0M),
                    MaSilo = maSilo,
                    STTSiloPLC = new int?(sttSiloPLC),

                    IsManual = nullable3,
                    NgayMTCT = new DateTime?(DateTime.Now),
                    CreatedBy = new int?(GlobalValues.UserID),
                    CreationDate = new DateTime?(DateTime.Now)
                };
            this._iView.CurMeTronChiTiet = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.SaveMeTronChiTiet(objMTCT, phieuTronID);
        }


        /*private void CalcSoiTrongCat_TruRa(string maSiloTruRa, Decimal soiTrongDaValue)
        {
            switch (maSiloTruRa)
            {
                case "Agg1":
                    this._caiDat_Agg1_SoiTrongCat_TruRa += soiTrongDaValue;
                    break;
                case "Agg2":
                    this._caiDat_Agg2_SoiTrongCat_TruRa += soiTrongDaValue;
                    break;
                case "Agg3":
                    this._caiDat_Agg3_SoiTrongCat_TruRa += soiTrongDaValue;
                    break;
                case "Agg4":
                    this._caiDat_Agg4_SoiTrongCat_TruRa += soiTrongDaValue;
                    break;
                case "Agg5":
                    this._caiDat_Agg5_SoiTrongCat_TruRa += soiTrongDaValue;
                    break;
                case "Agg6":
                    this._caiDat_Agg6_SoiTrongCat_TruRa += soiTrongDaValue;
                    break;
            }
        }*/

       /* private void CalcSoiTrongCat_ThemVao(
          BindingList<ObjSilo> blstSilo,
          BindingList<ObjMACSilo> blstMACSilo)
        {
            foreach (ObjSilo objSilo1 in (Collection<ObjSilo>)blstSilo)
            {
                ObjSilo s = objSilo1;
                Decimal? nullable = s.SoiTrongCat_NhomSiloAgg;
                if (nullable.HasValue)
                {
                    nullable = s.SoiTrongCat_NhomSiloAgg;
                    Decimal num = 0M;
                    if (!(nullable.GetValueOrDefault() <= num & nullable.HasValue))
                    {
                        ObjSilo objSilo2 = blstSilo.Where<ObjSilo>((Func<ObjSilo, bool>)(o =>
                        {
                            int siloId = o.SiloID;
                            int? vaoSiloNhomSiloAgg = s.SoiTrongCat_TruVaoSilo_NhomSiloAgg;
                            int valueOrDefault = vaoSiloNhomSiloAgg.GetValueOrDefault();
                            return siloId == valueOrDefault & vaoSiloNhomSiloAgg.HasValue;
                        })).FirstOrDefault<ObjSilo>();
                        switch (s.MaSilo)
                        {
                            case "Agg1":
                                nullable = blstMACSilo.Where<ObjMACSilo>((Func<ObjMACSilo, bool>)(o => o.SiloID == s.SiloID)).First<ObjMACSilo>().SiloValue;
                                Decimal klCaiDat1 = nullable.Value;
                                nullable = s.SoiTrongCat_NhomSiloAgg;
                                Decimal soiTrongCat_percent1 = nullable.Value;
                                Decimal catValueByFormula1 = this.GetSoiTrongCatValue_ByFormula(klCaiDat1, soiTrongCat_percent1);
                                //this._caiDat_Agg1_SoiTrongCat_ThemVao += catValueByFormula1;
                                if (objSilo2 != null)
                                {
                                    //this.CalcSoiTrongCat_TruRa(objSilo2.MaSilo, catValueByFormula1);
                                    continue;
                                }
                                continue;
                            case "Agg2":
                                nullable = blstMACSilo.Where<ObjMACSilo>((Func<ObjMACSilo, bool>)(o => o.SiloID == s.SiloID)).First<ObjMACSilo>().SiloValue;
                                Decimal klCaiDat2 = nullable.Value;
                                nullable = s.SoiTrongCat_NhomSiloAgg;
                                Decimal soiTrongCat_percent2 = nullable.Value;
                                Decimal catValueByFormula2 = this.GetSoiTrongCatValue_ByFormula(klCaiDat2, soiTrongCat_percent2);
                                //this._caiDat_Agg2_SoiTrongCat_ThemVao += catValueByFormula2;
                                if (objSilo2 != null)
                                {
                                    //this.CalcSoiTrongCat_TruRa(objSilo2.MaSilo, catValueByFormula2);
                                    continue;
                                }
                                continue;
                            case "Agg3":
                                nullable = blstMACSilo.Where<ObjMACSilo>((Func<ObjMACSilo, bool>)(o => o.SiloID == s.SiloID)).First<ObjMACSilo>().SiloValue;
                                Decimal klCaiDat3 = nullable.Value;
                                nullable = s.SoiTrongCat_NhomSiloAgg;
                                Decimal soiTrongCat_percent3 = nullable.Value;
                                Decimal catValueByFormula3 = this.GetSoiTrongCatValue_ByFormula(klCaiDat3, soiTrongCat_percent3);
                                //this._caiDat_Agg3_SoiTrongCat_ThemVao += catValueByFormula3;
                                if (objSilo2 != null)
                                {
                                    //this.CalcSoiTrongCat_TruRa(objSilo2.MaSilo, catValueByFormula3);
                                    continue;
                                }
                                continue;
                            case "Agg4":
                                nullable = blstMACSilo.Where<ObjMACSilo>((Func<ObjMACSilo, bool>)(o => o.SiloID == s.SiloID)).First<ObjMACSilo>().SiloValue;
                                Decimal klCaiDat4 = nullable.Value;
                                nullable = s.SoiTrongCat_NhomSiloAgg;
                                Decimal soiTrongCat_percent4 = nullable.Value;
                                Decimal catValueByFormula4 = this.GetSoiTrongCatValue_ByFormula(klCaiDat4, soiTrongCat_percent4);
                                //this._caiDat_Agg4_SoiTrongCat_ThemVao += catValueByFormula4;
                                if (objSilo2 != null)
                                {
                                    //this.CalcSoiTrongCat_TruRa(objSilo2.MaSilo, catValueByFormula4);
                                    continue;
                                }
                                continue;
                            case "Agg5":
                                nullable = blstMACSilo.Where<ObjMACSilo>((Func<ObjMACSilo, bool>)(o => o.SiloID == s.SiloID)).First<ObjMACSilo>().SiloValue;
                                Decimal klCaiDat5 = nullable.Value;
                                nullable = s.SoiTrongCat_NhomSiloAgg;
                                Decimal soiTrongCat_percent5 = nullable.Value;
                                Decimal catValueByFormula5 = this.GetSoiTrongCatValue_ByFormula(klCaiDat5, soiTrongCat_percent5);
                                //this._caiDat_Agg5_SoiTrongCat_ThemVao += catValueByFormula5;
                                if (objSilo2 != null)
                                {
                                    //this.CalcSoiTrongCat_TruRa(objSilo2.MaSilo, catValueByFormula5);
                                    continue;
                                }
                                continue;
                            case "Agg6":
                                nullable = blstMACSilo.Where<ObjMACSilo>((Func<ObjMACSilo, bool>)(o => o.SiloID == s.SiloID)).First<ObjMACSilo>().SiloValue;
                                Decimal klCaiDat6 = nullable.Value;
                                nullable = s.SoiTrongCat_NhomSiloAgg;
                                Decimal soiTrongCat_percent6 = nullable.Value;
                                Decimal catValueByFormula6 = this.GetSoiTrongCatValue_ByFormula(klCaiDat6, soiTrongCat_percent6);
                                //this._caiDat_Agg6_SoiTrongCat_ThemVao += catValueByFormula6;
                                if (objSilo2 != null)
                                {
                                    //this.CalcSoiTrongCat_TruRa(objSilo2.MaSilo, catValueByFormula6);
                                    continue;
                                }
                                continue;
                            default:
                                continue;
                        }
                    }
                }
            }
        }
*/
        public void BuildSetPoint(
          ObjHopDong objHD,
          BindingList<ObjMACSilo> blstMACSilo,
          BindingList<ObjWeigh> blstWei,
          BindingList<ObjSilo> blstSilo,
          Decimal doDoAm1,
          Decimal doDoAm2,
          Decimal doDoAm3,
          Decimal themBotNuoc,
          Decimal giuNuocTenCan,
          bool canUpdateWhenRunning)
        {
            SetPoint setPoint1 = new SetPoint();
            setPoint1.ThemBotNuoc = objHD.NPMACThemBotNuoc1;
            Decimal num1 = objHD.DLT_KLDuTinhCuaTungMe.Value;
            Decimal num2 = 0;
            Decimal? siloValue;
            foreach(ObjWeigh objWei in (Collection<ObjWeigh>)blstWei)
            {
                switch (objWei.WeighCode)
                {
                    case "Agg1":
                        SetPoint setPoint30 = setPoint1;
                        setPoint30.ThoiGianTreCan_Agg1 = (double)objWei.TimeEmpty;
                        setPoint30.ThoiGianTreXa_Agg1 = (double)objWei.Max;
                        setPoint30.ThoiGianTreDongCan_Agg1 = (double)objWei.Offset;
                        setPoint30.KhoiLuongBaoRong_Agg1 = (double)objWei.KLEmpty;
                        setPoint30.KhoiLuongRungCan_Agg1 = (double)objWei.WeiToVib;
                        setPoint30.ThoiGianBatRung_Agg1 = (double)objWei.TON;
                        setPoint30.ThoiGianTatRung_Agg1 = (double)objWei.TOFF;
                        continue;
                    case "Agg2":
                        SetPoint setPoint31 = setPoint1;
                        setPoint31.ThoiGianTreCan_Agg2 = (double)objWei.TimeEmpty;
                        setPoint31.ThoiGianTreXa_Agg2 = (double)objWei.Max;
                        setPoint31.ThoiGianTreDongCan_Agg2 = (double)objWei.Offset;
                        setPoint31.KhoiLuongBaoRong_Agg2 = (double)objWei.KLEmpty;
                        setPoint31.KhoiLuongRungCan_Agg2 = (double)objWei.WeiToVib;
                        setPoint31.ThoiGianBatRung_Agg2 = (double)objWei.TON;
                        setPoint31.ThoiGianTatRung_Agg2 = (double)objWei.TOFF;
                        continue;
                    case "Agg3":
                        SetPoint setPoint32 = setPoint1;
                        setPoint32.ThoiGianTreCan_Agg3 = (double)objWei.TimeEmpty;
                        setPoint32.ThoiGianTreXa_Agg3 = (double)objWei.Max;
                        setPoint32.ThoiGianTreDongCan_Agg3 = (double)objWei.Offset;
                        setPoint32.KhoiLuongBaoRong_Agg3 = (double)objWei.KLEmpty;
                        setPoint32.KhoiLuongRungCan_Agg3 = (double)objWei.WeiToVib;
                        setPoint32.ThoiGianBatRung_Agg3 = (double)objWei.TON;
                        setPoint32.ThoiGianTatRung_Agg3 = (double)objWei.TOFF;
                        continue;
                    case "Agg4":
                        SetPoint setPoint33 = setPoint1;
                        setPoint33.ThoiGianTreCan_Agg4 = (double)objWei.TimeEmpty;
                        setPoint33.ThoiGianTreXa_Agg4 = (double)objWei.Max;
                        setPoint33.ThoiGianTreDongCan_Agg4 = (double)objWei.Offset;
                        setPoint33.KhoiLuongBaoRong_Agg4 = (double)objWei.KLEmpty;
                        setPoint33.KhoiLuongRungCan_Agg4 = (double)objWei.WeiToVib;
                        setPoint33.ThoiGianBatRung_Agg4 = (double)objWei.TON;
                        setPoint33.ThoiGianTatRung_Agg4 = (double)objWei.TOFF;
                        continue;
                    case "Agg5":
                        SetPoint setPoint34 = setPoint1;
                        setPoint34.ThoiGianTreCan_Agg5 = (double)objWei.TimeEmpty;
                        setPoint34.ThoiGianTreXa_Agg5 = (double)objWei.Max;
                        setPoint34.ThoiGianTreDongCan_Agg5 = (double)objWei.Offset;
                        setPoint34.KhoiLuongBaoRong_Agg5 = (double)objWei.KLEmpty;
                        setPoint34.KhoiLuongRungCan_Agg5 = (double)objWei.WeiToVib;
                        setPoint34.ThoiGianBatRung_Agg5 = (double)objWei.TON;
                        setPoint34.ThoiGianTatRung_Agg5 = (double)objWei.TOFF;
                        continue;
                    case "Agg6":
                        SetPoint setPoint35 = setPoint1;
                        setPoint35.ThoiGianTreCan_Agg6 = (double)objWei.TimeEmpty;
                        setPoint35.ThoiGianTreXa_Agg6 = (double)objWei.Max;
                        setPoint35.ThoiGianTreDongCan_Agg6 = (double)objWei.Offset;
                        setPoint35.KhoiLuongBaoRong_Agg6 = (double)objWei.KLEmpty;
                        setPoint35.KhoiLuongRungCan_Agg6 = (double)objWei.WeiToVib;
                        setPoint35.ThoiGianBatRung_Agg6 = (double)objWei.TON;
                        setPoint35.ThoiGianTatRung_Agg6 = (double)objWei.TOFF;
                        continue;

                    case "Ce1":
                        SetPoint setPoint36 = setPoint1;
                        setPoint36.ThoiGianTreCan_Ce1 = (double)objWei.TimeEmpty;
                        setPoint36.ThoiGianTreXa_Ce1 = (double)objWei.Max;
                        setPoint36.ThoiGianTreDongCan_Ce1 = (double)objWei.Offset;
                        setPoint36.KhoiLuongBaoRong_Ce1 = (double)objWei.KLEmpty;
                        setPoint36.KhoiLuongRungCan_Ce1 = (double)objWei.WeiToVib;
                        setPoint36.ThoiGianBatRung_Ce1 = (double)objWei.TON;
                        setPoint36.ThoiGianTatRung_Ce1 = (double)objWei.TOFF;
                        continue;
                    case "Ce2":
                        SetPoint setPoint37 = setPoint1;
                        setPoint37.ThoiGianTreCan_Ce2 = (double)objWei.TimeEmpty;
                        setPoint37.ThoiGianTreXa_Ce2 = (double)objWei.Max;
                        setPoint37.ThoiGianTreDongCan_Ce2 = (double)objWei.Offset;
                        setPoint37.KhoiLuongBaoRong_Ce2 = (double)objWei.KLEmpty;
                        setPoint37.KhoiLuongRungCan_Ce2 = (double)objWei.WeiToVib;
                        setPoint37.ThoiGianBatRung_Ce2 = (double)objWei.TON;
                        setPoint37.ThoiGianTatRung_Ce2 = (double)objWei.TOFF;
                        continue;
                    
                    case "Wa1":
                        SetPoint setPoint38 = setPoint1;
                        setPoint38.ThoiGianTreCan_Wa1 = (double)objWei.TimeEmpty;
                        setPoint38.ThoiGianTreXa_Wa1 = (double)objWei.Max;
                        setPoint38.ThoiGianTreDongCan_Wa1 = (double)objWei.Offset;
                        decimal? numWa1 = objWei.KLEmpty;
                        numWa1 = numWa1.Value + giuNuocTenCan;
                        setPoint38.KhoiLuongBaoRong_Wa1 = (double)numWa1;
                        
                        continue;
                    case "Wa2":
                        SetPoint setPoint39 = setPoint1;
                        setPoint39.ThoiGianTreCan_Wa2 = (double)objWei.TimeEmpty;
                        setPoint39.ThoiGianTreXa_Wa2 = (double)objWei.Max;
                        setPoint39.ThoiGianTreDongCan_Wa2 = (double)objWei.Offset;
                        setPoint39.KhoiLuongBaoRong_Wa2 = (double)objWei.KLEmpty;
                        
                        continue;
                    case "Add1":
                        SetPoint setPoint40 = setPoint1;
                        setPoint40.ThoiGianTreCan_Add1 = (double)objWei.TimeEmpty;
                        setPoint40.ThoiGianTreXa_Add1 = (double)objWei.Max;
                        setPoint40.ThoiGianTreDongCan_Add1 = (double)objWei.Offset;
                        setPoint40.KhoiLuongBaoRong_Add1 = (double)objWei.KLEmpty;
                        
                        continue;
                    case "Add2":
                        SetPoint setPoint41 = setPoint1;
                        setPoint41.ThoiGianTreCan_Add2 = (double)objWei.TimeEmpty;
                        setPoint41.ThoiGianTreXa_Add2 = (double)objWei.Max;
                        setPoint41.ThoiGianTreDongCan_Add2 = (double)objWei.Offset;
                        setPoint41.KhoiLuongBaoRong_Add2 = (double)objWei.KLEmpty;
                        
                        continue;
                }
            }
            foreach (ObjMACSilo objMacSilo in (Collection<ObjMACSilo>)blstMACSilo)
            {

                string npSiloMaSilo;
                switch (npSiloMaSilo = objMacSilo.NPSiloMaSilo)
                {
                    case "Add1":
                        SetPoint setPoint2 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num3 = siloValue.Value;
                        //setPoint2.CaiDat_Add1 = num3;
                        //setPoint1.SP_Add1 = setPoint1.CaiDat_Add1 * num1;
                        setPoint2.KL_CaiDat_Add1 = (double)num3;
                        setPoint1.KL_CanCan_Add1 = setPoint1.KL_CaiDat_Add1 * (double)num1;
                        continue;
                    case "Add2":
                        SetPoint setPoint3 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num4 = siloValue.Value;
                        //setPoint3.CaiDat_Add2 = num4;
                        //setPoint1.SP_Add2 = setPoint1.CaiDat_Add2 * num1;
                        setPoint3.KL_CaiDat_Add2 = (double)num4;
                        setPoint1.KL_CanCan_Add2 = setPoint1.KL_CaiDat_Add2 * (double)num1;
                        continue;
                    case "Add3":
                        SetPoint setPoint4 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num5 = siloValue.Value;
                        
                        setPoint4.KL_CaiDat_Add3 = (double)num5;
                        setPoint1.KL_CanCan_Add3 = setPoint1.KL_CaiDat_Add3 * (double)num1;
                        continue;
                    case "Add4":
                        SetPoint setPoint5 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num6 = siloValue.Value;
                        
                        setPoint5.KL_CaiDat_Add4 = (double)num6;
                        setPoint1.KL_CanCan_Add4 = setPoint1.KL_CaiDat_Add4 * (double)num1;
                        continue;
                    case "Add5":
                        SetPoint setPoint6 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num7 = siloValue.Value;
                        
                        setPoint6.KL_CaiDat_Add5 = (double)num7;
                        setPoint1.KL_CanCan_Add5 = setPoint1.KL_CaiDat_Add5 * (double)num1;
                        continue;
                    case "Add6":
                        SetPoint setPoint7 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num8 = siloValue.Value;
                        
                        setPoint7.KL_CaiDat_Add6 = (double)num8;
                        setPoint1.KL_CanCan_Add6 = setPoint1.KL_CaiDat_Add6 * (double)num1;
                        continue;
                    case "Add7":
                        SetPoint setPoint8 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num9 = siloValue.Value;
                        //setPoint8.CaiDat_Add7 = num9;
                        //setPoint1.SP_Add7 = setPoint1.CaiDat_Add7 * num1;
                        continue;
                    case "Add8":
                        SetPoint setPoint9 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num10 = siloValue.Value;
                        //setPoint9.CaiDat_Add8 = num10;
                        //setPoint1.SP_Add8 = setPoint1.CaiDat_Add8 * num1;
                        continue;
                    case "Agg1":
                        SetPoint setPoint10 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num11 = siloValue.Value;
                        //setPoint10.CaiDat_Agg1 = num11;
                        //setPoint1.SP_Agg1 = (setPoint1.CaiDat_Agg1 + this._caiDat_Agg1_SoiTrongCat_ThemVao - this._caiDat_Agg1_SoiTrongCat_TruRa) * num1;
                        setPoint10.KL_CaiDat_Agg1 = (double) num11;
                        setPoint1.KL_CanCan_Agg1 =  setPoint1.KL_CaiDat_Agg1 * (double)num1;

                        continue;
                    case "Agg2":
                        SetPoint setPoint11 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num12 = siloValue.Value;
                        //setPoint11.CaiDat_Agg2 = num12;
                        //setPoint1.SP_Agg2 = (setPoint1.CaiDat_Agg2 + this._caiDat_Agg2_SoiTrongCat_ThemVao - this._caiDat_Agg2_SoiTrongCat_TruRa) * num1;
                        setPoint11.KL_CaiDat_Agg2 = (double)num12;
                        setPoint1.KL_CanCan_Agg2 = setPoint1.KL_CaiDat_Agg2 * (double)num1;
                        continue;
                    case "Agg3":
                        SetPoint setPoint12 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num13 = siloValue.Value;
                        //setPoint12.CaiDat_Agg3 = num13;
                        //setPoint1.SP_Agg3 = (setPoint1.CaiDat_Agg3 + this._caiDat_Agg3_SoiTrongCat_ThemVao - this._caiDat_Agg3_SoiTrongCat_TruRa) * num1;
                        setPoint12.KL_CaiDat_Agg3 = (double)num13;
                        setPoint1.KL_CanCan_Agg3 = setPoint1.KL_CaiDat_Agg3 * (double)num1;
                        continue;
                    case "Agg4":
                        SetPoint setPoint13 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num14 = siloValue.Value;
                        //setPoint13.CaiDat_Agg4 = num14;
                        //setPoint1.SP_Agg4 = (setPoint1.CaiDat_Agg4 + this._caiDat_Agg4_SoiTrongCat_ThemVao - this._caiDat_Agg4_SoiTrongCat_TruRa) * num1;
                        setPoint13.KL_CaiDat_Agg4 = (double)num14;
                        setPoint1.KL_CanCan_Agg4 = setPoint1.KL_CaiDat_Agg4 * (double)num1;
                        continue;
                    case "Agg5":
                        SetPoint setPoint14 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num15 = siloValue.Value;
                        // setPoint14.CaiDat_Agg5 = num15;
                        //setPoint1.SP_Agg5 = (setPoint1.CaiDat_Agg5 + this._caiDat_Agg5_SoiTrongCat_ThemVao - this._caiDat_Agg5_SoiTrongCat_TruRa) * num1;
                        setPoint14.KL_CaiDat_Agg5 = (double)num15;
                        setPoint1.KL_CanCan_Agg5 = setPoint1.KL_CaiDat_Agg5 * (double)num1;
                        continue;
                    case "Agg6":
                        SetPoint setPoint15 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num16 = siloValue.Value;
                        //setPoint15.CaiDat_Agg6 = num16;
                        //setPoint1.SP_Agg6 = (setPoint1.CaiDat_Agg6 + this._caiDat_Agg6_SoiTrongCat_ThemVao - this._caiDat_Agg6_SoiTrongCat_TruRa) * num1;
                        setPoint15.KL_CaiDat_Agg6 = (double)num16;
                        setPoint1.KL_CanCan_Agg6 = setPoint1.KL_CaiDat_Agg6 * (double)num1;
                        continue;
                    case "Ce1":
                        SetPoint setPoint16 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num17 = siloValue.Value;
                        //setPoint16.CaiDat_Ce1 = num17;
                        // setPoint1.SP_Ce1 = setPoint1.CaiDat_Ce1 * num1;
                        setPoint16.KL_CaiDat_Ce1 = (double)num17;
                        setPoint1.KL_CanCan_Ce1 = setPoint1.KL_CaiDat_Ce1 * (double)num1;
                        //========================
                        foreach (ObjSilo objSilo in (Collection<ObjSilo>)blstSilo)
                        {
                            if (objSilo.MaSilo == "Ce1")
                            {
                                setPoint16.SaiSoTren_Ce1 = (double)objSilo.SaiSoTren;
                                setPoint16.SaiSoDuoi_Ce1 = (double)objSilo.SaiSoDuoi;
                                setPoint16.RoiTuDo_Ce1 = (double)objSilo.KLRoi;
                                setPoint16.ThoiGianMoCan_Ce1 = (double)objSilo.TGNhapNhaOn;
                                setPoint16.ThoiGianDongCan_Ce1 = (double)objSilo.TGNhapNhaOff;
                                setPoint16.ThoiGianTinhLuongRoiThem_Ce1 = (double)objSilo.TGKiemTraVatLieuRoi;
                            }
                        }
                            
                        continue;
                    case "Ce2":
                        SetPoint setPoint17 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num18 = siloValue.Value;
                        setPoint17.KL_CaiDat_Ce2 = (double)num18;
                        setPoint1.KL_CanCan_Ce2 = setPoint1.KL_CaiDat_Ce2 * (double)num1;
                        //setPoint17.CaiDat_Ce2 = num18;
                        //setPoint1.SP_Ce2 = setPoint1.CaiDat_Ce2 * num1;
                        continue;
                    case "Ce3":
                        SetPoint setPoint18 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num19 = siloValue.Value;
                        setPoint18.KL_CaiDat_Ce3 = (double)num19;
                        setPoint1.KL_CanCan_Ce3 = setPoint1.KL_CaiDat_Ce3 * (double)num1;
                        //setPoint18.CaiDat_Ce3 = num19;
                        //setPoint1.SP_Ce3 = setPoint1.CaiDat_Ce3 * num1;
                        /*if (objHD.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed)
                        {
                            setPoint1.SP_Ce3 = setPoint1.CaiDat_Ce3 * num2;
                            continue;
                        }*/
                        continue;
                    case "Ce4":
                        SetPoint setPoint19 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num20 = siloValue.Value;
                        setPoint19.KL_CaiDat_Ce4 = (double)num20;
                        setPoint1.KL_CanCan_Ce4 = setPoint1.KL_CaiDat_Ce4 * (double)num1;
                        //setPoint19.CaiDat_Ce4 = num20;
                        //setPoint1.SP_Ce4 = setPoint1.CaiDat_Ce4 * num1;
                        /*if (objHD.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed)
                        {
                            setPoint1.SP_Ce4 = setPoint1.CaiDat_Ce4 * num2;
                            continue;
                        }*/
                        continue;
                    case "Ce5":
                        SetPoint setPoint20 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num21 = siloValue.Value;
                        setPoint20.KL_CaiDat_Ce5 = (double)num21;
                        setPoint1.KL_CanCan_Ce5 = setPoint1.KL_CaiDat_Ce5 * (double)num1;
                        //setPoint20.CaiDat_Ce5 = num21;
                        //setPoint1.SP_Ce5 = setPoint1.CaiDat_Ce5 * num1;
                        continue;
                    case "Ce6":
                        SetPoint setPoint21 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num22 = siloValue.Value;
                        //setPoint21.CaiDat_Ce6 = num22;
                        //setPoint1.SP_Ce6 = setPoint1.CaiDat_Ce6 * num1;
                        continue;
                    case "Wa1":
                        SetPoint setPoint22 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num23 = siloValue.Value;
                        //setPoint22.CaiDat_Wa1 = num23;
                        //setPoint1.SP_Wa1 = setPoint1.CaiDat_Wa1 * num1;
                        //========================
                        setPoint22.KL_CaiDat_Wa1 = (double)num23;
                        setPoint1.KL_CanCan_Wa1 = setPoint1.KL_CaiDat_Wa1 * (double)num1;
                        foreach (ObjSilo objSilo in (Collection<ObjSilo>)blstSilo)
                        {
                            if (objSilo.MaSilo == "Wa1")
                            {
                                setPoint22.SaiSoTren_Wa1 = (double)objSilo.SaiSoTren;
                                setPoint22.SaiSoDuoi_Wa1 = (double)objSilo.SaiSoDuoi;
                                setPoint22.RoiTuDo_Wa1 = (double)objSilo.KLRoi;
                                setPoint22.ThoiGianMoCan_Wa1 = (double)objSilo.TGNhapNhaOn;
                                setPoint22.ThoiGianDongCan_Wa1 = (double)objSilo.TGNhapNhaOff;
                                setPoint22.ThoiGianTinhLuongRoiThem_Wa1 = (double)objSilo.TGKiemTraVatLieuRoi;
                            }
                        }
                        continue;
                    case "Wa2":
                        SetPoint setPoint23 = setPoint1;
                        siloValue = objMacSilo.SiloValue;
                        Decimal num24 = siloValue.Value;
                        setPoint23.KL_CaiDat_Wa2 = (double)num24;
                        setPoint1.KL_CanCan_Wa2 = setPoint1.KL_CaiDat_Wa2 * (double)num1;
                        //setPoint23.CaiDat_Wa2 = num24;
                        //setPoint1.SP_Wa2 = setPoint1.CaiDat_Wa2 * num1;
                        /*if (objHD.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed)
                        {
                            setPoint1.SP_Wa2 = setPoint1.CaiDat_Wa2 * num2;
                            continue;
                        }*/
                        continue;
                    default:
                        continue;
                }

                int npMacID = 0;
                npMacID = objMacSilo.MACID;
            }
            Decimal? nullable;
            foreach (ObjSilo objSilo in (Collection<ObjSilo>)blstSilo)
            {
                switch (objSilo.MaSilo)
                {
                    case "Agg1":
                        nullable = objSilo.DoAm_NhomSlioAgg;
                        Decimal num25 = nullable.Value;
                        /*if (ConfigManager.TramTronConfig.DoDoAm1PLC && ConfigManager.TramTronConfig.DoDoAm1AGG_Mapping == "Agg1")
                        {
                            num25 = doDoAm1;
                            objSilo.DoAm_NhomSlioAgg = new Decimal?(doDoAm1);
                        }
                        else if (ConfigManager.TramTronConfig.DoDoAm2PLC && ConfigManager.TramTronConfig.DoDoAm2AGG_Mapping == "Agg1")
                        {
                            num25 = doDoAm2;
                            objSilo.DoAm_NhomSlioAgg = new Decimal?(doDoAm2);
                        }*/
                        
                        setPoint1.DoAm_Agg1 = num25;
                        SetPoint setPoint24 = setPoint1;
                        nullable = objSilo.DoHutNuoc_NhomSiloAgg;
                        Decimal num26 = nullable.Value;
                        setPoint24.DoHut_Agg1 = num26;
                        SetPoint setPoint25 = setPoint1;
                        Decimal spAgg1 = (Decimal)setPoint1.KL_CanCan_Agg1;
                        Decimal doAm1 = num25;
                        nullable = objSilo.DoHutNuoc_NhomSiloAgg;
                        Decimal doHut1 = nullable.Value;
                        Decimal num27 = this.CalcKLAggCanCan(spAgg1, doAm1, doHut1, 0M);
                        setPoint25.KL_CanCan_Agg1 = (Double)num27;
                        //====
                        setPoint24.SaiSoTren_Agg1 = (double)objSilo.SaiSoTren;
                        setPoint24.SaiSoDuoi_Agg1 = (double)objSilo.SaiSoDuoi;
                        setPoint24.RoiTuDo_Agg1 = (double)objSilo.KLRoi;
                        setPoint24.ThoiGianMoCan_Agg1 = (double)objSilo.TGNhapNhaOn;
                        setPoint24.ThoiGianDongCan_Agg1 = (double)objSilo.TGNhapNhaOff;
                        setPoint24.ThoiGianTinhLuongRoiThem_Agg1 = (double)objSilo.TGKiemTraVatLieuRoi;
                        continue;
                    case "Agg2":
                        nullable = objSilo.DoAm_NhomSlioAgg;
                        Decimal num28 = nullable.Value;
                        /*if (ConfigManager.TramTronConfig.DoDoAm1PLC && ConfigManager.TramTronConfig.DoDoAm1AGG_Mapping == "Agg2")
                        {
                            num28 = doDoAm2;
                            objSilo.DoAm_NhomSlioAgg = new Decimal?(doDoAm1);
                        }
                        else if (ConfigManager.TramTronConfig.DoDoAm2PLC && ConfigManager.TramTronConfig.DoDoAm2AGG_Mapping == "Agg2")
                        {
                            num28 = doDoAm2;
                            objSilo.DoAm_NhomSlioAgg = new Decimal?(doDoAm2);
                        }*/
                        setPoint1.DoAm_Agg2 = num28;
                        SetPoint setPoint26 = setPoint1;
                        nullable = objSilo.DoHutNuoc_NhomSiloAgg;
                        Decimal num29 = nullable.Value;
                        setPoint26.DoHut_Agg2 = num29;
                        SetPoint setPoint27 = setPoint1;
                        Decimal spAgg2 = (decimal)setPoint1.KL_CanCan_Agg2;
                        Decimal doAm2 = num28;
                        nullable = objSilo.DoHutNuoc_NhomSiloAgg;
                        Decimal doHut2 = nullable.Value;
                        Decimal num30 = this.CalcKLAggCanCan(spAgg2, doAm2, doHut2, 0M);
                        setPoint27.KL_CanCan_Agg2 = (Double)num30;
                        //====
                        setPoint26.SaiSoTren_Agg2 = (double)objSilo.SaiSoTren;
                        setPoint26.SaiSoDuoi_Agg2 = (double)objSilo.SaiSoDuoi;
                        setPoint26.RoiTuDo_Agg2 = (double)objSilo.KLRoi;
                        setPoint26.ThoiGianMoCan_Agg2 = (double)objSilo.TGNhapNhaOn;
                        setPoint26.ThoiGianDongCan_Agg2 = (double)objSilo.TGNhapNhaOff;
                        setPoint26.ThoiGianTinhLuongRoiThem_Agg2 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Agg3":
                        nullable = objSilo.DoAm_NhomSlioAgg;
                        Decimal num31 = nullable.Value;
                        /*if (ConfigManager.TramTronConfig.DoDoAm1PLC && ConfigManager.TramTronConfig.DoDoAm1AGG_Mapping == "Agg3")
                        {
                            num31 = doDoAm3;
                            objSilo.DoAm_NhomSlioAgg = new Decimal?(doDoAm1);
                        }
                        else if (ConfigManager.TramTronConfig.DoDoAm2PLC && ConfigManager.TramTronConfig.DoDoAm2AGG_Mapping == "Agg3")
                        {
                            num31 = doDoAm2;
                            objSilo.DoAm_NhomSlioAgg = new Decimal?(doDoAm2);
                        }*/
                        setPoint1.DoAm_Agg3 = num31;
                        SetPoint setPoint28 = setPoint1;
                        nullable = objSilo.DoHutNuoc_NhomSiloAgg;
                        Decimal num32 = nullable.Value;
                        setPoint28.DoHut_Agg3 = num32;
                        SetPoint setPoint29 = setPoint1;
                        Decimal spAgg3 = (Decimal)setPoint1.KL_CanCan_Agg3;
                        Decimal doAm3 = num31;
                        nullable = objSilo.DoHutNuoc_NhomSiloAgg;
                        Decimal doHut3 = nullable.Value;
                        Decimal num33 = this.CalcKLAggCanCan(spAgg3, doAm3, doHut3, 0M);
                        setPoint29.KL_CanCan_Agg3 = (double)num33;
                        //====
                        setPoint28.SaiSoTren_Agg3 = (double)objSilo.SaiSoTren;
                        setPoint28.SaiSoDuoi_Agg3 = (double)objSilo.SaiSoDuoi;
                        setPoint28.RoiTuDo_Agg3 = (double)objSilo.KLRoi;
                        setPoint28.ThoiGianMoCan_Agg3 = (double)objSilo.TGNhapNhaOn;
                        setPoint28.ThoiGianDongCan_Agg3 = (double)objSilo.TGNhapNhaOff;
                        setPoint28.ThoiGianTinhLuongRoiThem_Agg3 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Agg4":
                        nullable = objSilo.DoAm_NhomSlioAgg;
                        Decimal num34 = nullable.Value;
                        /*if (ConfigManager.TramTronConfig.DoDoAm1PLC && ConfigManager.TramTronConfig.DoDoAm1AGG_Mapping == "Agg4")
                        {
                            num34 = doDoAm1;
                            objSilo.DoAm_NhomSlioAgg = new Decimal?(doDoAm1);
                        }
                        else if (ConfigManager.TramTronConfig.DoDoAm2PLC && ConfigManager.TramTronConfig.DoDoAm2AGG_Mapping == "Agg4")
                        {
                            num34 = doDoAm2;
                            objSilo.DoAm_NhomSlioAgg = new Decimal?(doDoAm2);
                        }*/
                        setPoint1.DoAm_Agg4 = num34;
                        SetPoint setPoint30 = setPoint1;
                        nullable = objSilo.DoHutNuoc_NhomSiloAgg;
                        Decimal num35 = nullable.Value;
                        setPoint30.DoHut_Agg4 = num35;
                        SetPoint setPoint31 = setPoint1;
                        Decimal spAgg4 = (Decimal)setPoint1.KL_CanCan_Agg4;
                        Decimal doAm4 = num34;
                        nullable = objSilo.DoHutNuoc_NhomSiloAgg;
                        Decimal doHut4 = nullable.Value;
                        Decimal num36 = this.CalcKLAggCanCan(spAgg4, doAm4, doHut4, 0M);
                        setPoint31.KL_CanCan_Agg4 = (double)num36;

                        //====
                        setPoint30.SaiSoTren_Agg4 = (double)objSilo.SaiSoTren;
                        setPoint30.SaiSoDuoi_Agg4 = (double)objSilo.SaiSoDuoi;
                        setPoint30.RoiTuDo_Agg4= (double)objSilo.KLRoi;
                        setPoint30.ThoiGianMoCan_Agg4 = (double)objSilo.TGNhapNhaOn;
                        setPoint30.ThoiGianDongCan_Agg4 = (double)objSilo.TGNhapNhaOff;
                        setPoint30.ThoiGianTinhLuongRoiThem_Agg4 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Agg5":
                        nullable = objSilo.DoAm_NhomSlioAgg;
                        Decimal num37 = nullable.Value;
                        /*if (ConfigManager.TramTronConfig.DoDoAm1PLC && ConfigManager.TramTronConfig.DoDoAm1AGG_Mapping == "Agg5")
                        {
                            num37 = doDoAm1;
                            objSilo.DoAm_NhomSlioAgg = new Decimal?(doDoAm1);
                        }
                        else if (ConfigManager.TramTronConfig.DoDoAm2PLC && ConfigManager.TramTronConfig.DoDoAm2AGG_Mapping == "Agg5")
                        {
                            num37 = doDoAm2;
                            objSilo.DoAm_NhomSlioAgg = new Decimal?(doDoAm2);
                        }*/
                        //setPoint1.DoAm_Agg5 = num37;
                        //if (ConfigManager.DNTramTronConfig.DoDoAm1PLC && objHD.DLT_KLDuTinhCuaTungMe_NoiB_IsUsed)
                            //setPoint1.DoAm_Agg5 = setPoint1.DoAm_Agg1;
                        SetPoint setPoint32 = setPoint1;
                        nullable = objSilo.DoHutNuoc_NhomSiloAgg;
                        Decimal num38 = nullable.Value;
                        setPoint32.DoHut_Agg5 = num38;
                        SetPoint setPoint33 = setPoint1;
                        Decimal spAgg5 = (Decimal)setPoint1.KL_CanCan_Agg5;
                        Decimal doAm5 = num37;
                        nullable = objSilo.DoHutNuoc_NhomSiloAgg;
                        Decimal doHut5 = nullable.Value;
                        Decimal num39 = this.CalcKLAggCanCan(spAgg5, doAm5, doHut5, 0M);
                        setPoint33.KL_CanCan_Agg5 = (double)num39;
                        //====
                        setPoint32.SaiSoTren_Agg5 = (double)objSilo.SaiSoTren;
                        setPoint32.SaiSoDuoi_Agg5 = (double)objSilo.SaiSoDuoi;
                        setPoint32.RoiTuDo_Agg5 = (double)objSilo.KLRoi;
                        setPoint32.ThoiGianMoCan_Agg5 = (double)objSilo.TGNhapNhaOn;
                        setPoint32.ThoiGianDongCan_Agg5 = (double)objSilo.TGNhapNhaOff;
                        setPoint32.ThoiGianTinhLuongRoiThem_Agg5 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Agg6":
                        nullable = objSilo.DoAm_NhomSlioAgg;
                        Decimal num40 = nullable.Value;
                        /*if (ConfigManager.TramTronConfig.DoDoAm1PLC && ConfigManager.TramTronConfig.DoDoAm1AGG_Mapping == "Agg6")
                        {
                            num40 = doDoAm1;
                            objSilo.DoAm_NhomSlioAgg = new Decimal?(doDoAm1);
                        }
                        else if (ConfigManager.TramTronConfig.DoDoAm2PLC && ConfigManager.TramTronConfig.DoDoAm2AGG_Mapping == "Agg6")
                        {
                            num40 = doDoAm2;
                            objSilo.DoAm_NhomSlioAgg = new Decimal?(doDoAm2);
                        }*/
                        setPoint1.DoAm_Agg6 = num40;
                        SetPoint setPoint34 = setPoint1;
                        nullable = objSilo.DoHutNuoc_NhomSiloAgg;
                        Decimal num41 = nullable.Value;
                        setPoint34.DoHut_Agg6 = num41;
                        SetPoint setPoint35 = setPoint1;
                        Decimal spAgg6 = (Decimal)setPoint1.KL_CanCan_Agg6;
                        Decimal doAm6 = num40;
                        nullable = objSilo.DoHutNuoc_NhomSiloAgg;
                        Decimal doHut6 = nullable.Value;
                        Decimal num42 = this.CalcKLAggCanCan(spAgg6, doAm6, doHut6, 0M);
                        setPoint35.KL_CanCan_Agg6 = (double)num42;
                        //====
                        setPoint34.SaiSoTren_Agg6 = (double)objSilo.SaiSoTren;
                        setPoint34.SaiSoDuoi_Agg6 = (double)objSilo.SaiSoDuoi;
                        setPoint34.RoiTuDo_Agg6 = (double)objSilo.KLRoi;
                        setPoint34.ThoiGianMoCan_Agg6 = (double)objSilo.TGNhapNhaOn;
                        setPoint34.ThoiGianDongCan_Agg6 = (double)objSilo.TGNhapNhaOff;
                        setPoint34.ThoiGianTinhLuongRoiThem_Agg6 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Ce1":
                        SetPoint setPoint36 = setPoint1;
                        //====
                        setPoint36.SaiSoTren_Ce1 = (double)objSilo.SaiSoTren;
                        setPoint36.SaiSoDuoi_Ce1 = (double)objSilo.SaiSoDuoi;
                        setPoint36.RoiTuDo_Ce1 = (double)objSilo.KLRoi;
                        setPoint36.ThoiGianMoCan_Ce1 = (double)objSilo.TGNhapNhaOn;
                        setPoint36.ThoiGianDongCan_Ce1 = (double)objSilo.TGNhapNhaOff;
                        setPoint36.ThoiGianTinhLuongRoiThem_Ce1 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Ce2":
                        SetPoint setPoint37 = setPoint1;
                        //====
                        setPoint37.SaiSoTren_Ce2 = (double)objSilo.SaiSoTren;
                        setPoint37.SaiSoDuoi_Ce2 = (double)objSilo.SaiSoDuoi;
                        setPoint37.RoiTuDo_Ce2 = (double)objSilo.KLRoi;
                        setPoint37.ThoiGianMoCan_Ce2 = (double)objSilo.TGNhapNhaOn;
                        setPoint37.ThoiGianDongCan_Ce2 = (double)objSilo.TGNhapNhaOff;
                        setPoint37.ThoiGianTinhLuongRoiThem_Ce2 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Ce3":
                        SetPoint setPoint38 = setPoint1;
                        //====
                        setPoint38.SaiSoTren_Ce3 = (double)objSilo.SaiSoTren;
                        setPoint38.SaiSoDuoi_Ce3 = (double)objSilo.SaiSoDuoi;
                        setPoint38.RoiTuDo_Ce3 = (double)objSilo.KLRoi;
                        setPoint38.ThoiGianMoCan_Ce3 = (double)objSilo.TGNhapNhaOn;
                        setPoint38.ThoiGianDongCan_Ce3 = (double)objSilo.TGNhapNhaOff;
                        setPoint38.ThoiGianTinhLuongRoiThem_Ce3 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Ce4":
                        SetPoint setPoint39 = setPoint1;
                        //====
                        setPoint39.SaiSoTren_Ce4 = (double)objSilo.SaiSoTren;
                        setPoint39.SaiSoDuoi_Ce4 = (double)objSilo.SaiSoDuoi;
                        setPoint39.RoiTuDo_Ce4 = (double)objSilo.KLRoi;
                        setPoint39.ThoiGianMoCan_Ce4 = (double)objSilo.TGNhapNhaOn;
                        setPoint39.ThoiGianDongCan_Ce4 = (double)objSilo.TGNhapNhaOff;
                        setPoint39.ThoiGianTinhLuongRoiThem_Ce4 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Ce5":
                        SetPoint setPoint40 = setPoint1;
                        //====
                        setPoint40.SaiSoTren_Ce5 = (double)objSilo.SaiSoTren;
                        setPoint40.SaiSoDuoi_Ce5 = (double)objSilo.SaiSoDuoi;
                        setPoint40.RoiTuDo_Ce5 = (double)objSilo.KLRoi;
                        setPoint40.ThoiGianMoCan_Ce5 = (double)objSilo.TGNhapNhaOn;
                        setPoint40.ThoiGianDongCan_Ce5 = (double)objSilo.TGNhapNhaOff;
                        setPoint40.ThoiGianTinhLuongRoiThem_Ce5 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Wa1":
                        SetPoint setPoint41 = setPoint1;
                        //====
                        setPoint41.SaiSoTren_Wa1 = (double)objSilo.SaiSoTren;
                        setPoint41.SaiSoDuoi_Wa1 = (double)objSilo.SaiSoDuoi;
                        setPoint41.RoiTuDo_Wa1 = (double)objSilo.KLRoi;
                        setPoint41.ThoiGianMoCan_Wa1 = (double)objSilo.TGNhapNhaOn;
                        setPoint41.ThoiGianDongCan_Wa1 = (double)objSilo.TGNhapNhaOff;
                        setPoint41.ThoiGianTinhLuongRoiThem_Wa1 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Wa2":
                        SetPoint setPoint42 = setPoint1;
                        //====
                        setPoint42.SaiSoTren_Wa2 = (double)objSilo.SaiSoTren;
                        setPoint42.SaiSoDuoi_Wa2 = (double)objSilo.SaiSoDuoi;
                        setPoint42.RoiTuDo_Wa2 = (double)objSilo.KLRoi;
                        setPoint42.ThoiGianMoCan_Wa2 = (double)objSilo.TGNhapNhaOn;
                        setPoint42.ThoiGianDongCan_Wa2 = (double)objSilo.TGNhapNhaOff;
                        setPoint42.ThoiGianTinhLuongRoiThem_Wa2 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Add1":
                        SetPoint setPoint43 = setPoint1;
                        //====
                        setPoint43.SaiSoTren_Add1 = (double)objSilo.SaiSoTren;
                        setPoint43.SaiSoDuoi_Add1 = (double)objSilo.SaiSoDuoi;
                        setPoint43.RoiTuDo_Add1 = (double)objSilo.KLRoi;
                        setPoint43.ThoiGianMoCan_Add1 = (double)objSilo.TGNhapNhaOn;
                        setPoint43.ThoiGianDongCan_Add1 = (double)objSilo.TGNhapNhaOff;
                        setPoint43.ThoiGianTinhLuongRoiThem_Add1 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Add2":
                        SetPoint setPoint44 = setPoint1;
                        //====
                        setPoint44.SaiSoTren_Add2 = (double)objSilo.SaiSoTren;
                        setPoint44.SaiSoDuoi_Add2 = (double)objSilo.SaiSoDuoi;
                        setPoint44.RoiTuDo_Add2 = (double)objSilo.KLRoi;
                        setPoint44.ThoiGianMoCan_Add2 = (double)objSilo.TGNhapNhaOn;
                        setPoint44.ThoiGianDongCan_Add2 = (double)objSilo.TGNhapNhaOff;
                        setPoint44.ThoiGianTinhLuongRoiThem_Add2 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Add3":
                        SetPoint setPoint45 = setPoint1;
                        //====
                        setPoint45.SaiSoTren_Add3 = (double)objSilo.SaiSoTren;
                        setPoint45.SaiSoDuoi_Add3 = (double)objSilo.SaiSoDuoi;
                        setPoint45.RoiTuDo_Add3 = (double)objSilo.KLRoi;
                        setPoint45.ThoiGianMoCan_Add3 = (double)objSilo.TGNhapNhaOn;
                        setPoint45.ThoiGianDongCan_Add3 = (double)objSilo.TGNhapNhaOff;
                        setPoint45.ThoiGianTinhLuongRoiThem_Add3 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Add4":
                        SetPoint setPoint46 = setPoint1;
                        //====
                        setPoint46.SaiSoTren_Add4 = (double)objSilo.SaiSoTren;
                        setPoint46.SaiSoDuoi_Add4 = (double)objSilo.SaiSoDuoi;
                        setPoint46.RoiTuDo_Add4 = (double)objSilo.KLRoi;
                        setPoint46.ThoiGianMoCan_Add4 = (double)objSilo.TGNhapNhaOn;
                        setPoint46.ThoiGianDongCan_Add4 = (double)objSilo.TGNhapNhaOff;
                        setPoint46.ThoiGianTinhLuongRoiThem_Add4 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Add5":
                        SetPoint setPoint47 = setPoint1;
                        //====
                        setPoint47.SaiSoTren_Add5 = (double)objSilo.SaiSoTren;
                        setPoint47.SaiSoDuoi_Add5 = (double)objSilo.SaiSoDuoi;
                        setPoint47.RoiTuDo_Add5 = (double)objSilo.KLRoi;
                        setPoint47.ThoiGianMoCan_Add5 = (double)objSilo.TGNhapNhaOn;
                        setPoint47.ThoiGianDongCan_Add5 = (double)objSilo.TGNhapNhaOff;
                        setPoint47.ThoiGianTinhLuongRoiThem_Add5 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Add6":
                        SetPoint setPoint48 = setPoint1;
                        //====
                        setPoint48.SaiSoTren_Add6 = (double)objSilo.SaiSoTren;
                        setPoint48.SaiSoDuoi_Add6 = (double)objSilo.SaiSoDuoi;
                        setPoint48.RoiTuDo_Add6 = (double)objSilo.KLRoi;
                        setPoint48.ThoiGianMoCan_Add6 = (double)objSilo.TGNhapNhaOn;
                        setPoint48.ThoiGianDongCan_Add6 = (double)objSilo.TGNhapNhaOff;
                        setPoint48.ThoiGianTinhLuongRoiThem_Add6 = (double)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    /* case "Wa1":
                         Decimal spWa11 = (Decimal)setPoint1.KL_CanCan_Wa1;
                         SetPoint setPoint111 = setPoint1;
                         Decimal numWa = this.CalcKLWaCanCan_(spWa11,
                                                         (Decimal)setPoint1.KL_CaiDat_Agg1,
                                                         (Decimal)setPoint1.KL_CaiDat_Agg2,
                                                         (Decimal)setPoint1.KL_CaiDat_Agg3,
                                                         (Decimal)setPoint1.KL_CaiDat_Agg4,
                                                         (Decimal)setPoint1.KL_CaiDat_Agg5,
                                                         (Decimal)setPoint1.KL_CaiDat_Agg6,
                                                         setPoint1.DoAm_Agg1,
                                                         setPoint1.DoAm_Agg2,
                                                         setPoint1.DoAm_Agg3,
                                                         setPoint1.DoAm_Agg4,
                                                         setPoint1.DoAm_Agg5,
                                                         setPoint1.DoAm_Agg6,
                                                         setPoint1.DoHut_Agg1,
                                                         setPoint1.DoHut_Agg2,
                                                         setPoint1.DoHut_Agg3,
                                                         setPoint1.DoHut_Agg4,
                                                         setPoint1.DoHut_Agg5,
                                                         setPoint1.DoHut_Agg6,
                                                         setPoint1.ThemBotNuoc);

                         setPoint111.KL_CanCan_Wa1 = (double)numWa;

                         continue;*/
                    default:
                        continue;
                }
            }
            Decimal spWa1 = (Decimal)setPoint1.KL_CanCan_Wa1;  //Chú ý phần này 24-10-2023
            //Decimal spWa2 = setPoint1.SP_Wa2;
            Decimal numm = 0;
            setPoint1.KL_CanCan_Wa1 = (double)this.CalcKLWaCanCan_(
                                                        spWa1, 
                                                        (Decimal)setPoint1.KL_CaiDat_Agg1, 
                                                        (Decimal)setPoint1.KL_CaiDat_Agg2, 
                                                        (Decimal)setPoint1.KL_CaiDat_Agg3, 
                                                        (Decimal)setPoint1.KL_CaiDat_Agg4, 
                                                        (Decimal)setPoint1.KL_CaiDat_Agg5, 
                                                        (Decimal)setPoint1.KL_CaiDat_Agg6, 
                                                        setPoint1.DoAm_Agg1, 
                                                        setPoint1.DoAm_Agg2, 
                                                        setPoint1.DoAm_Agg3, 
                                                        setPoint1.DoAm_Agg4, 
                                                        setPoint1.DoAm_Agg5, 
                                                        setPoint1.DoAm_Agg6, 
                                                        setPoint1.DoHut_Agg1, 
                                                        setPoint1.DoHut_Agg2, 
                                                        setPoint1.DoHut_Agg3, 
                                                        setPoint1.DoHut_Agg4, 
                                                        setPoint1.DoHut_Agg5, 
                                                        setPoint1.DoHut_Agg6,
                                                        themBotNuoc);
            Decimal num43 = 0M;
            if (setPoint1.KL_CanCan_Wa1 < 0)
            {
                num43 = (decimal)setPoint1.KL_CanCan_Wa1;
                setPoint1.KL_CanCan_Wa1 = 0;
            }
            setPoint1.KL_CanCan_Wa2 += (double)num43;
            if(setPoint1.KL_CanCan_Wa2 < 0)
            {
                setPoint1.KL_CanCan_Wa2 = 0;
            }

            setPoint1.SoMeTron = (double)objHD.DLT_SLMeDuTinh.Value;
            setPoint1.KLTrenTungMe = (double)objHD.DLT_KLDuTinhCuaTungMe;
            setPoint1.CanUpdateWhenRunning = canUpdateWhenRunning;
            this._iView.SP = setPoint1;
        }

        public void BuildNullSetPoint() => this._iView.SP = new SetPoint();

        public void BuildNullInitOnline() => this._iView.IO = new InitOnline();
        //Decimal klAggCaiDat,Decimal doAm,Decimal doHut, Decimal klBuTru
        private Decimal CalcKLAggCanCan(
          Decimal klAggCaiDat,
          Decimal doAm,
          Decimal doHut,
          Decimal klBuTru)
        {
            return klAggCaiDat + klAggCaiDat * (doAm - doHut) / 100M + klBuTru;
        }
        private Decimal CalcKLBuTruMeCuoi(
            Decimal klAggCaiDat,
            Decimal klBuTru)
        {
            return klAggCaiDat + klBuTru;
        }

        private Decimal CalcKLWaCanCan_(
          Decimal klWaCaiDat,
          Decimal klAgg1CaiDat,
          Decimal klAgg2CaiDat,
          Decimal klAgg3CaiDat,
          Decimal klAgg4CaiDat,
          Decimal klAgg5CaiDat,
          Decimal klAgg6CaiDat,
          Decimal doAm1,
          Decimal doAm2,
          Decimal doAm3,
          Decimal doAm4,
          Decimal doAm5,
          Decimal doAm6,
          Decimal doHut1,
          Decimal doHut2,
          Decimal doHut3,
          Decimal doHut4,
          Decimal doHut5,
          Decimal doHut6,
          Decimal themBotNuoc)
        {
            return klWaCaiDat + themBotNuoc- (klAgg1CaiDat * (doAm1 - doHut1) / 100M + klAgg2CaiDat * (doAm2 - doHut2) / 100M + klAgg3CaiDat * (doAm3 - doHut3) / 100M + klAgg4CaiDat * (doAm4 - doHut4) / 100M + klAgg5CaiDat * (doAm5 - doHut5) / 100M + klAgg6CaiDat * (doAm6 - doHut6) / 100M);
        }

        public void UpdatePT(BindingList<ObjPhieuTron> blstCT) => this._iView.IsSuccessfulUpdatePT = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.SavePhieuTron(blstCT);

        public bool ResolveUnfinishPhieuTron() => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.ResolveUnfinishPhieuTron();
        public void SaveTronOnline(ObjPhieuTron objPT, BindingList<ObjMeTron> blstMT) => this._iView.SavingPhieuTron = MasterDataPresenter<ITronOnlineView>._iMasterDataModel.SaveTronOnline(objPT, blstMT);

        public void SaveThemBotNuoc1(int macID, Decimal themBotNuoc1) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.SaveMacThemBotNuoc1(macID, themBotNuoc1);

        public void SaveThemBotNuoc2(int macID, Decimal themBotNuoc2) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.SaveMacThemBotNuoc2(macID, themBotNuoc2);

        public ObjMAC GetMACByKey(int macId) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetMACByKey(macId);
        public ObjKhachHang GetKhachHangByKey(int khachHangId) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetKhachHangByKey(khachHangId);
        public ObjCongTruong GetCongTruongByKey(int congTruongId) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetCongTruongByKey(congTruongId);
        public ObjHangMuc GetHangMucByKey(int HangMucId) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.GetHangMucByKey(HangMucId);

        public void SaveMacThemBotNuoc1(int macId, Decimal themBotNuoc1)
        {
            
        }

        public void SaveMacThemBotNuoc2(int macId, Decimal themBotNuoc2)
        {
        }

        public void SaveDuLieuTron(BindingList<ObjDuLieuTron> blstDLT) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.SaveDuLieuTron(blstDLT);

        public ObjDuLieuTron AddDuLieuTron(ObjDuLieuTron objDLT) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.AddDuLieuTron(objDLT);

        public ObjDuLieuTron UpdateDuLieuTron(ObjDuLieuTron objDLT) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.UpdateDuLieuTron(objDLT);

        public bool DeleteDulieuTron(int id) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.DeleteDulieuTron(id);
        public ObjHopDong SaveHopDong(ObjHopDong objHD, ObjDuLieuTron objDLT) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.SaveHopDong(objHD, objDLT);
        public ObjHopDong SaveHopDong(ObjHopDong objHD) => MasterDataPresenter<ITronOnlineView>._iMasterDataModel.SaveHopDong(objHD);
        
    }
}

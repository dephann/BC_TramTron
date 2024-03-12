using NDPSo.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    class ReceivingFromPLC
    {
        private byte _statusIO_00;
        private byte _statusIO_01;
        private byte _statusIO_02;
        private byte _statusIO_03;
        private byte _statusIO_04;
        private byte _statusIO_05;
        private byte _statusIO_06;
        private byte _statusIO_07;
        private byte _statusIO_08;
        private byte _statusIO_09;
        private byte _statusIO_10;
        private byte _statusIO_11;
        private byte _statusIO_12;
        private byte _statusIO_13;
        private byte _statusIO_14;
        private byte _statusIO_SAVE;

       //==========================================================================
        
        private Double _ThoiGianTreCan_Ce; //28.0
        private Double _ThoiGianTreXa_Ce; //32.0
        private Double _ThoiGianTreDongCan_Ce; //36.0
        private Double _KhoiLuongBaoRong_Ce; //40.0
        private Double _KhoiLuongRungCan_Ce; //44.0
        private Double _ThoiGianBatRung_Ce; //48.0
        private Double _ThoiGianTatRung_Ce; //52.0

        private Double _ThoiGianTreCan_Wa; //56.0
        private Double _ThoiGianTreXa_Wa; //60.0
        private Double _ThoiGianTreDongCan_Wa; //64.0
        private Double _KhoiLuongBaoRong_Wa; //68.0

        private Double _XungCan_Agg; //72.0
        private Double _KL_Chinh_0_Agg; //76.0
        private Double _KL_ChinhTai_Agg; //80.0
        private Double _KL_Thuc_Agg; //84.0

        private Double _XungCan_Ce; //88.0
        private Double _KL_Chinh_0_Ce; //92.0
        private Double _KL_ChinhTai_Ce; //96.0
        private Double _KL_Thuc_Ce; //100.0

        private Double _XungCan_Wa; //104.0
        private Double _KL_Chinh_0_Wa; //108.0
        private Double _KL_ChinhTai_Wa; //112.0
        private Double _KL_Thuc_Wa; //116.0

        private Double _Per_KL_AGG; //144.0
        private Double _Per_KL_CE; //148.0
        private Double _Per_KL_WA; //152.0

        //================================================================================

        private Double _SoMeTron; //0.0
        private Double _SoMeCan_Agg1; //4.0
        private Double _SoMeCan_Agg2; //8.0
        private Double _SoMeCan_Agg3; //12.0
        private Double _SoMeCan_Agg; //16.0
        private Double _SoMeXa_Agg; //20.0

        private Double _SoMeCan_Ce1; //24.0
        private Double _SoMeXa_Ce; //28.0

        private Double _SoMeCan_Wa1; //32.0
        private Double _SoMeXa_Wa; //36.0

        private Double _SoMeCan_NoiTron; //40.0
        private Double _SoMeXa_NoiTron; //44.0

        private Double _CapPhoi_Agg1; //48.0
        private Double _CapPhoi_Agg2; //52.0
        private Double _CapPhoi_Agg3; //56.0

        private Double _CapPhoi_Ce1; //60.0
        private Double _CapPhoi_Wa1; //64.0

        private Double _KL_CanCan_Agg1; //68.0
        private Double _KL_CanCan_Agg2; //72.0
        private Double _KL_CanCan_Agg3; //76.0

        private Double _KL_CanCan_Ce1; //80.0
        private Double _KL_CanCan_Wa1; //84.0

        private Double _KL_ThucCan_Agg1; //88.0
        private Double _KL_ThucCan_Agg2; //92.0
        private Double _KL_ThucCan_Agg3; //96.0

        private Double _KL_ThucCan_Ce1; //100.0
        private Double _KL_ThucCan_Wa1; //104.0
        //================================================================================DB8
        ////======================================Byte 0=====================================
        private bool _Save_Report; //Bit 0.0

        //================================================================================DB1
        ////======================================Byte 0=====================================
        private bool _Op_TinHieu_NoiTron; //Bit 0.0
        private bool _Op_TinHieu_BangTaiXien; //Bit 0.1
        private bool _Op_TinHieu_BangTaiCan; //Bit 0.2
        private bool _Op_TinHieu_GauLen; //Bit 0.3
        private bool _Op_TinHieu_GauXuong; //Bit 0.4
        private bool _Op_TinHieu_GauTren; //Bit 0.5
        private bool _Op_TinHieu_GauCho; //Bit 0.6
        private bool _Op_TinHieu_GauDuoi; //Bit 0.7
        ////======================================Byte 1=====================================
        private bool _Op_TinHieu_GauAnToan; //Bit 1.0
        private bool _Op_TinHieu_CuaNoiDong; //Bit 1.1
        private bool _Op_TinHieu_CuaNoi_1p2; //Bit 1.2
        private bool _Op_TinHieu_CuaNoiMo; //Bit 1.3
        private bool _Op_TinHieu_PheuChoDong; //Bit 1.4
        private bool _Op_TinHieu_PheuChoMo; //Bit 1.5
        private bool _Op_Van_MoCuaNoi; //Bit 1.6
        private bool _Op_Van_DongCuaNoi; //Bit 1.7
        ////======================================Byte 2=====================================
        private bool _Op_Van_XaPheuCho; //Bit 2.0
        private bool _Op_VanCan_XiMang_1; //Bit 2.1
        private bool _Op_VanCan_XiMang_2; //Bit 2.2
        private bool _Op_VanCan_XiMang_3; //Bit 2.3
        private bool _Op_VanXa_PheuCan_XiMang_1; //Bit 2.4
        private bool _Op_VanCan_XiMang_4; //Bit 2.5
        private bool _Op_VanCan_XiMang_5; //Bit 2.6
        private bool _Op_VanXa_PheuCan_XiMang_2; //Bit 2.7
        ////======================================Byte 3=====================================
        private bool _Op_VanCan_Nuoc_1; //Bit 3.0
        private bool _Op_VanXa_PheuCan_Nuoc_1; //Bit 3.1
        private bool _Op_VanCan_Nuoc_2; //Bit 3.2
        private bool _Op_VanXa_PheuCan_Nuoc_2; //Bit 3.3
        private bool _Op_VanCan_PhuGia_1; //Bit 3.4
        private bool _Op_VanCan_PhuGia_2; //Bit 3.5
        private bool _Op_VanCan_PhuGia_3; //Bit 3.6
        private bool _Op_VanXa_PheuCan_PhuGia_1; //Bit 3.7
        ////======================================Byte 4=====================================
        private bool _Op_VanCan_PhuGia_4; //Bit 4.0
        private bool _Op_VanCan_PhuGia_5; //Bit 4.1
        private bool _Op_VanCan_PhuGia_6; //Bit 4.2
        private bool _Op_VanXa_PheuCan_PhuGia_2; //Bit 4.3
        private bool _Op_VanCan_Agg_1_1; //Bit 4.4
        private bool _Op_VanCan_Agg_1_2; //Bit 4.5
        private bool _Op_VanXa_PheuCan_Agg_1; //Bit 4.6
        private bool _Op_VanCan_Agg_2_1; //Bit 4.7
        ////======================================Byte 5=====================================
        private bool _Op_VanCan_Agg_2_2; //Bit 5.0
        private bool _Op_VanXa_PheuCan_Agg_2; //Bit 5.1
        private bool _Op_VanCan_Agg_3_1; //Bit 5.2
        private bool _Op_VanCan_Agg_3_2; //Bit 5.3
        private bool _Op_VanXa_PheuCan_Agg_3; //Bit 5.4
        private bool _Op_VanCan_Agg_4_1; //Bit 5.5
        private bool _Op_VanCan_Agg_4_2; //Bit 5.6
        private bool _Op_VanXa_PheuCan_Agg_4; //Bit 5.7
        ////======================================Byte 6=====================================
        private bool _Op_VanCan_Agg_5_1; //Bit 6.0

        private bool _Op_VanCan_Agg_5_2; //Bit 6.1
        private bool _Op_VanXa_PheuCan_Agg_5; //Bit 6.2
        private bool _Op_VanCan_Agg_6_1; //Bit 6.3
        private bool _Op_VanCan_Agg_6_2; //Bit 6.4
        private bool _Op_VanXa_PheuCan_Agg_6; //Bit 6.5

        private bool _Op_RungPheuCho; //Bit 6.6
        private bool _Op_RungPheuCan_XiMang_1; //Bit 6.7
        ////======================================Byte 7=====================================
        private bool _Op_RungPheuCan_XiMang_2; //Bit 7.0

        private bool _Op_RungPheuCan_CotLieu_3; //Bit 7.1
        private bool _Op_RungPheuCan_CotLieu_4; //Bit 7.2
        private bool _Op_RungPheuCan_CotLieu_5; //Bit 7.3
        private bool _Op_RungPheuCan_CotLieu_6; //Bit 7.4

        private bool _Op_VanSutKhi_Silo_1; //Bit 7.5
        private bool _Op_VanSutKhi_Silo_2; //Bit 7.6
        private bool _Op_VanSutKhi_Silo_3; //Bit 7.7
        ////======================================Byte 8=====================================
        private bool _Op_VanSutKhi_Silo_4; //Bit 8.0
        private bool _Op_VanSutKhi_Silo_5; //Bit 8.1
        private bool _Op_RungPheuCan_CotLieu_1; //Bit 8.2
        private bool _Op_RungPheuCan_CotLieu_2; //Bit 8.3
        private bool _Temple; //Bit 8.3
        private bool _Temple2; //Bit 8.4
        private bool _Temple3; //Bit 8.5
        private bool _Temple4; //Bit 8.6
        private bool _Op_RUNNING; //Bit 8.7
        ////======================================Byte 9=====================================
        private bool _Op_SIMULATION; //Bit 9.0
        private bool _Op_MIXER_FULL; //Bit 9.1
        private bool _Op_TTC_AGG1; //Bit 9.2
        private bool _Op_TTC_AGG2; //Bit 9.3
        private bool _Op_TTC_AGG3; //Bit 9.4
        private bool _Op_TTC_AGG4; //Bit 9.5
        private bool _Op_TTC_AGG5; //Bit 9.6
        private bool _Op_TTC_AGG6; //Bit 9.7
        private bool _Op_TTC_SILO1; //Bit 10.0
        private bool _Op_TTC_SILO2; //Bit 10.1
        private bool _Op_TTC_SILO3; //Bit 10.2
        private bool _Op_TTC_SILO4; //Bit 10.3
        private bool _Op_TTC_SILO5; //Bit 10.4
        private bool _Op_TTC_WA1; //Bit 10.5
        private bool _Op_TTC_WA2; //Bit 10.6
        private bool _Op_TTC_ADD1; //Bit 10.7
        private bool _Op_TTC_ADD2; //Bit 11.0
        private bool _Op_TTC_ADD3; //Bit 11.1
        private bool _Op_TTC_ADD4; //Bit 11.2
        private bool _Op_TTC_ADD5; //Bit 11.3
        private bool _Op_TTC_ADD6; //Bit 11.4
        private bool _Op_THDC_WAGG1; //Bit 11.5
        private bool _Op_THDC_WAGG2; //Bit 11.6
        private bool _Op_THDC_WAGG3; //Bit 11.7
        private bool _Op_THDC_WAGG4; //Bit 12.0
        private bool _Op_THDC_WAGG5; //Bit 12.1
        private bool _Op_THDC_WAGG6; //Bit 12.2
        private bool _Op_THDC_WCE1; //Bit 12.3
        private bool _Op_THDC_WCE2; //Bit 12.4
        private bool _Op_THDC_WWA1; //Bit 12.5
        private bool _Op_THDC_WWA2; //Bit 12.6
        private bool _Op_THDC_WADD1; //Bit 12.7
        private bool _Op_THDC_WADD2; //Bit 13.0
        private bool _STT_MAN_AUT; //Bit 13.1
        private bool _STT_PAUSE; //Bit 13.2
        private bool _STT_CANCEL; //Bit 13.3

        //================================================================================
        ////======================================Byte 0=====================================
        private bool _Op_F1_Chay; //Bit 0.0
        private bool _Op_F2_TamDung; //Bit 0.1
        private bool _Op_F3_HuyMe; //Bit 0.2
        private bool _Op_F4_MoPhong; //Bit 0.3
        private bool _Op_SW_ChayTay_TuDong; //Bit 0.4
        private bool _Op_SW_XaCan_CotLieu; //Bit 0.5
        private bool _Op_SW_NapLieu_NoiTron; //Bit 0.6
        private bool _Op_SW_XaBeTong; //Bit 0.7

        ////======================================Byte 1=====================================
        private bool _Op_SW_RuaNoiTron; //Bit 1.0
        private bool _Op_NN_BatTat_NoiTron; //Bit 1.1
        private bool _Op_SW_Xa_PheuCho; //Bit 1.2
        private bool _Op_NN_DongCuaNoi; //Bit 1.3
        private bool _Op_NN_MoCuaNoi; //Bit 1.4
        private bool _Op_NN_DongKep; //Bit 1.5
        private bool _Op_NN_MoKep; //Bit 1.6
        private bool _Op_NN_RungKep; //Bit 1.7

        ////======================================Byte 2=====================================
        private bool _Op_NN_BatTat_BangTaiXien; //Bit 2.0
        private bool _Op_NN_BatTat_BangTaiCan; //Bit 2.1
        private bool _Op_TAM; //Bit 2.2
        private bool _Op_NN_Dung_Gau; //Bit 2.3
        private bool _Op_NN_GauXuong; //Bit 2.4
        private bool _Op_BoCan_Agg_1; //Bit 2.5
        private bool _Op_TamDungCan_Agg_1; //Bit 2.6
        private bool _Op_NN_Can_Agg_1_1; //Bit 2.7

        ////======================================Byte 3=====================================
        private bool _Op_NN_Can_Agg_1_2; //Bit 3.0
        private bool _Op_SW_XaPheuCan_Agg_1; //Bit 3.1
        private bool _Op_BoCan_Agg_2; //Bit 3.2
        private bool _Op_TamDungCan_Agg2; //Bit 3.3
        private bool _Op_NN_Can_Agg_2_1; //Bit 3.4
        private bool _Op_NN_Can_Agg_2_2; //Bit 3.5
        private bool _Op_SW_XaPheuCan_Agg_2; //Bit 3.6
        private bool _Op_BoCan_Agg_3; //Bit 3.7

        ////======================================Byte 4=====================================
        private bool _Op_TamDungCan_Agg_3; //Bit 4.0
        private bool _Op_NN_Can_Agg_3_1; //Bit 4.1
        private bool _Op_NN_Can_Agg_3_2; //Bit 4.2
        private bool _Op_SW_XaPheuCan_Agg_3; //Bit 4.3
        private bool _Op_BoCan_Agg4; //Bit 4.4
        private bool _Op_TamDungCan_Agg_4; //Bit 4.5
        private bool _Op_NN_Can_Agg_4_1; //Bit 4.6
        private bool _Op_NN_Can_Agg_4_2; //Bit 4.7

        ////======================================Byte 5=====================================
        private bool _Op_SW_XaPheuCan_Agg_4; //Bit 5.0
        private bool _Op_BoCan_Agg_5; //Bit 5.1
        private bool _Op_TamDungCan_Agg_5; //Bit 5.2
        private bool _Op_NN_Can_Agg_5_1; //Bit 5.3
        private bool _Op_NN_Can_Agg_5_2; //Bit 5.4
        private bool _Op_SW_XaPhauCan_Agg_5; //Bit 5.5
        private bool _Op_BoCan_Agg_6; //Bit 5.6
        private bool _Op_TamDungCan_Agg_6; //Bit 5.7

        ////======================================Byte 6=====================================
        private bool _Op_NN_Can_Agg_6_1; //Bit 6.0
        private bool _Op_NN_Can_Agg_6_2; //Bit 6.1
        private bool _Op_SW_XaPheuCan_Agg_6; //Bit 6.2
        private bool _Op_BoCan_Ce_1; //Bit 6.3
        private bool _Op_TamDungCan_Ce_1; //Bit 6.4
        private bool _Op_NN_Can_Ce_1; //Bit 6.5
        private bool _Op_NN_SutKhi_Silo_1; //Bit 6.6
        private bool _Op_BoCan_Ce_2; //Bit 6.7

        ////======================================Byte 7=====================================
        private bool _Op_TamDungCan_Ce_2; //Bit 7.0
        private bool _Op_NN_Can_Ce_2; //Bit 7.1
        private bool _Op_NN_SutKhi_Silo_2; //Bit 7.2
        private bool _Op_BoCan_Ce_3; //Bit 7.3
        private bool _Op_TamDungCan_Ce_3; //Bit 7.4
        private bool _Op_NN_Can_Ce_3; //Bit 7.5
        private bool _Op_NN_SutKhi_Silo_3; //Bit 7.6
        private bool _Op_SW_XaPheuCan_Cem_1; //Bit 7.7

        ////======================================Byte 8=====================================
        private bool _Op_BoCan_Ce_4; //Bit 8.0
        private bool _Op_TamDungCan_Ce_4; //Bit 8.1
        private bool _Op_NN_Can_Ce_4; //Bit 8.2
        private bool _Op_NN_SutKhi_Slio_4; //Bit 8.3
        private bool _Op_BoCan_Ce_5; //Bit 8.4
        private bool _Op_TamDungCan_Ce_5; //Bit 8.5
        private bool _Op_NN_Can_Ce_5; //Bit 8.6
        private bool _Op_NN_SutKhi_Silo_5; //Bit 8.7

        ////======================================Byte 9=====================================
        private bool _Op_SW_XaPheuCan_Cem_2; //Bit 9.0
        private bool _Op_BoCan_Wa_1; //Bit 9.1
        private bool _Op_TamDungCan_Wa_1; //Bit 9.2
        private bool _Op_NN_Can_Wa_1; //Bit 9.3
        private bool _Op_SW_XaPheuCan_Wa_1; //Bit 9.4
        private bool _Op_BoCan_Wa_2; //Bit 9.5
        private bool _Op_TamDungCan_Wa_2; //Bit 9.6
        private bool _Op_NN_Can_Wa_2; //Bit 9.7

        ////======================================Byte 10=====================================
        private bool _Op_SW_XaPheuCan_Wa_2; //Bit 10.0
        private bool _Op_BoCan_Add_1; //Bit 10.1
        private bool _Op_TamDungCan_Add_1; //Bit 10.2
        private bool _Op_NN_Can_Add_1; //Bit 10.3
        private bool _Op_BoCan_Add_2; //Bit 10.4
        private bool _Op_TamDungCan_Add_2; //Bit 10.5
        private bool _Op_NN_Can_Add_2; //Bit 10.6
        private bool _Op_BoCan_Add_3; //Bit 10.7

        ////======================================Byte 11=====================================
        private bool _Op_TamDungCan_Add_3; //Bit 11.0
        private bool _Op_NN_Can_Add_3; //Bit 11.1
        private bool _Op_SW_XaPheuCan_Add_1; //Bit 11.2
        private bool _Op_BoCan_Add_4; //Bit 11.3
        private bool _Op_TamDungCan_Add_4; //Bit 11.4
        private bool _Op_NN_Can_Add_4; //Bit 11.5
        private bool _Op_BoCan_Add_5; //Bit 11.6
        private bool _Op_TamDungCan_Add_5; //Bit 11.7

        ////======================================Byte 12=====================================
        private bool _Op_NN_Can_Add_5; //Bit 12.0
        private bool _Op_BoCan_Add_6; //Bit 12.1
        private bool _Op_TamDung_Can_Add_6; //Bit 12.2
        private bool _Op_NN_Can_Add_6; //Bit 12.3
        private bool _Op_SW_XaPheuCan_Add_2; //Bit 12.4
        private bool _Op_NN_Chinh_0_Can_Agg_1; //Bit 12.5
        private bool _Op_NN_Chinh_Tai_Can_Agg_1; //Bit 12.6
        private bool _Op_NN_Chinh_0_Can_Agg_2; //Bit 12.7

        ////======================================Byte 13=====================================
        private bool _Op_NN_Chinh_Tai_Can_Agg_2; //Bit 13.0
        private bool _Op_NN_Chinh_0_Can_Agg_3; //Bit 13.1
        private bool _Op_NN_Chinh_Tai_Can_Agg_3; //Bit 13.2
        private bool _Op_NN_Chinh_0_Can_Agg_4; //Bit 13.3
        private bool _Op_NN_Chinh_Tai_Can_Agg_4; //Bit 13.4
        private bool _Op_NN_Chinh_0_Can_Agg_5; //Bit 13.5
        private bool _Op_NN_Chinh_Tai_Can_Agg_5; //Bit 13.6
        private bool _Op_NN_Chinh_0_Can_Agg_6; //Bit 13.7

        ////======================================Byte 14=====================================
        private bool _Op_NN_Chinh_Tai_Can_Agg_6; //Bit 14.0
        private bool _Op_NN_Chinh_0_Can_Cem_1; //Bit 14.1
        private bool _Op_NN_Chinh_Tai_Can_Cem_1; //Bit 14.2
        private bool _Op_NN_Chinh_0_Can_Cem_2; //Bit 14.3
        private bool _Op_NN_Chinh_Tai_Can_Cem_2; //Bit 14.4
        private bool _Op_NN_Chinh_0_Can_Wa_1; //Bit 14.5
        private bool _Op_NN_Chinh_Tai_Can_Wa_1; //Bit 14.6
        private bool _Op_NN_Chinh_0_Can_Wa_2; //Bit 14.7

        ////======================================Byte 15=====================================
        private bool _Op_NN_Chinh_Tai_Can_Wa_2; //Bit 15.0
        private bool _Op_NN_Chinh_0_Can_Add_1; //Bit 15.1
        private bool _Op_NN_Chinh_Tai_Can_Add_1; //Bit 15.2
        private bool _Op_NN_Chinh_0_Can_Add_2; //Bit 15.3
        private bool _Op_NN_Chinh_Tai_Can_Add_2; //Bit 15.4

        //================================================================================DB3
        private Double _SaiSoTren_Agg1; //0
        private Double _SaiSoDuoi_Agg1; //4
        private Double _RoiTuDo_Agg1; //8
        private Double _ThoiGianBatCan_Agg1; //12
        private Double _ThoiGianTatCan_Agg1; //16
        private Double _ThoiGianTinhLuongRoiThem_Agg1; //20

        private Double _SaiSoTren_Agg2; //24
        private Double _SaiSoDuoi_Agg2; //28
        private Double _RoiTuDo_Agg2; //32
        private Double _ThoiGianBatCan_Agg2; //36
        private Double _ThoiGianTatCan_Agg2; //40
        private Double _ThoiGianTinhLuongRoiThem_Agg2; //44

        private Double _SaiSoTren_Agg3; //48
        private Double _SaiSoDuoi_Agg3; //52
        private Double _RoiTuDo_Agg3; //56
        private Double _ThoiGianBatCan_Agg3; //60
        private Double _ThoiGianTatCan_Agg3; //64
        private Double _ThoiGianTinhLuongRoiThem_Agg3; //68

        private Double _SaiSoTren_Agg4; //72
        private Double _SaiSoDuoi_Agg4; //76
        private Double _RoiTuDo_Agg4; //80
        private Double _ThoiGianBatCan_Agg4; //84
        private Double _ThoiGianTatCan_Agg4; //88
        private Double _ThoiGianTinhLuongRoiThem_Agg4; //92

        private Double _SaiSoTren_Agg5; //96
        private Double _SaiSoDuoi_Agg5; //100
        private Double _RoiTuDo_Agg5; //104
        private Double _ThoiGianBatCan_Agg5; //108
        private Double _ThoiGianTatCan_Agg5; //112
        private Double _ThoiGianTinhLuongRoiThem_Agg5; //116

        private Double _SaiSoTren_Agg6; //120
        private Double _SaiSoDuoi_Agg6; //124
        private Double _RoiTuDo_Agg6; //128
        private Double _ThoiGianBatCan_Agg6; //132
        private Double _ThoiGianTatCan_Agg6; //136
        private Double _ThoiGianTinhLuongRoiThem_Agg6; //140

        private Double _SaiSoTren_Ce1; //144
        private Double _SaiSoDuoi_Ce1; //148
        private Double _RoiTuDo_Ce1; //152
        private Double _ThoiGianBatCan_Ce1; //156
        private Double _ThoiGianTatCan_Ce1; //160
        private Double _ThoiGianTinhLuongRoiThem_Ce1; //164

        private Double _SaiSoTren_Ce2; //168
        private Double _SaiSoDuoi_Ce2; //172
        private Double _RoiTuDo_Ce2; //176
        private Double _ThoiGianBatCan_Ce2; //180
        private Double _ThoiGianTatCan_Ce2; //184
        private Double _ThoiGianTinhLuongRoiThem_Ce2; //188

        private Double _SaiSoTren_Ce3; //192
        private Double _SaiSoDuoi_Ce3; //196
        private Double _RoiTuDo_Ce3; //200
        private Double _ThoiGianBatCan_Ce3; //204
        private Double _ThoiGianTatCan_Ce3; //208
        private Double _ThoiGianTinhLuongRoiThem_Ce3; //212

        private Double _SaiSoTren_Ce4; //216
        private Double _SaiSoDuoi_Ce4; //220
        private Double _RoiTuDo_Ce4; //224
        private Double _ThoiGianBatCan_Ce4; //228
        private Double _ThoiGianTatCan_Ce4; //232
        private Double _ThoiGianTinhLuongRoiThem_Ce4; //236

        private Double _SaiSoTren_Ce5; //240
        private Double _SaiSoDuoi_Ce5; //244
        private Double _RoiTuDo_Ce5; //248
        private Double _ThoiGianBatCan_Ce5; //252
        private Double _ThoiGianTatCan_Ce5; //256
        private Double _ThoiGianTinhLuongRoiThem_Ce5; //260

        private Double _SaiSoTren_Wa1; //264
        private Double _SaiSoDuoi_Wa1; //268
        private Double _RoiTuDo_Wa1; //272
        private Double _ThoiGianBatCan_Wa1; //276
        private Double _ThoiGianTatCan_Wa1; //280
        private Double _ThoiGianTinhLuongRoiThem_Wa1; //284

        private Double _SaiSoTren_Wa2; //288
        private Double _SaiSoDuoi_Wa2; //292
        private Double _RoiTuDo_Wa2; //296
        private Double _ThoiGianBatCan_Wa2; //300
        private Double _ThoiGianTatCan_Wa2; //304
        private Double _ThoiGianTinhLuongRoiThem_Wa2; //308

        private Double _SaiSoTren_Add1; //312
        private Double _SaiSoDuoi_Add1; //316
        private Double _RoiTuDo_Add1; //320
        private Double _ThoiGianBatCan_Add1; //324
        private Double _ThoiGianTatCan_Add1; //328
        private Double _ThoiGianTinhLuongRoiThem_Add1; //332

        private Double _SaiSoTren_Add2; //336
        private Double _SaiSoDuoi_Add2; //340
        private Double _RoiTuDo_Add2; //344
        private Double _ThoiGianBatCan_Add2; //348
        private Double _ThoiGianTatCan_Add2; //352
        private Double _ThoiGianTinhLuongRoiThem_Add2; //356

        private Double _SaiSoTren_Add3; //360
        private Double _SaiSoDuoi_Add3; //364
        private Double _RoiTuDo_Add3; //368
        private Double _ThoiGianBatCan_Add3; //372
        private Double _ThoiGianTatCan_Add3; //376
        private Double _ThoiGianTinhLuongRoiThem_Add3; //380

        private Double _SaiSoTren_Add4; //384
        private Double _SaiSoDuoi_Add4; //388
        private Double _RoiTuDo_Add4; //392
        private Double _ThoiGianBatCan_Add4; //396
        private Double _ThoiGianTatCan_Add4; //400
        private Double _ThoiGianTinhLuongRoiThem_Add4; //404

        private Double _SaiSoTren_Add5; //408
        private Double _SaiSoDuoi_Add5; //412
        private Double _RoiTuDo_Add5; //416
        private Double _ThoiGianBatCan_Add5; //420
        private Double _ThoiGianTatCan_Add5; //424
        private Double _ThoiGianTinhLuongRoiThem_Add5; //428

        private Double _SaiSoTren_Add6; //432
        private Double _SaiSoDuoi_Add6; //436
        private Double _RoiTuDo_Add6; //440
        private Double _ThoiGianBatCan_Add6; //444
        private Double _ThoiGianTatCan_Add6; //448
        private Double _ThoiGianTinhLuongRoiThem_Add6; //452

        //================================================================================DB4
        ////======================================Agg1=====================================
        private Double _ThoiGianTreCan_Agg_1; //0
        private Double _ThoiGianTreXa_Agg_1; //4
        private Double _ThoiGianTreDongCan_Agg_1; //8
        private Double _KhoiLuongBaoRong_Agg_1; //12
        private Double _KhoiLuongRungCan_Agg_1; //16
        private Double _ThoiGianBatRung_Agg_1; //20
        private Double _ThoiGianTatRung_Agg_1; //24

        ////======================================Agg2=====================================
        private Double _ThoiGianTreCan_Agg_2; //28
        private Double _ThoiGianTreXa_Agg_2; //32
        private Double _ThoiGianTreDongCan_Agg_2; //36
        private Double _KhoiLuongBaoRong_Agg_2; //40
        private Double _KhoiLuongRungCan_Agg_2; //44
        private Double _ThoiGianBatRung_Agg_2; //48
        private Double _ThoiGianTatRung_Agg_2; //52

        ////======================================Agg3=====================================
        private Double _ThoiGianTreCan_Agg_3; //56
        private Double _ThoiGianTreXa_Agg_3; //60
        private Double _ThoiGianTreDongCan_Agg_3; //64
        private Double _KhoiLuongBaoRong_Agg_3; //68
        private Double _KhoiLuongRungCan_Agg_3; //72
        private Double _ThoiGianBatRung_Agg_3; //76
        private Double _ThoiGianTatRung_Agg_3; //80

        ////======================================Agg4=====================================
        private Double _ThoiGianTreCan_Agg_4; //84
        private Double _ThoiGianTreXa_Agg_4; //88
        private Double _ThoiGianTreDongCan_Agg_4; //92
        private Double _KhoiLuongBaoRong_Agg_4; //96
        private Double _KhoiLuongRungCan_Agg_4; //100
        private Double _ThoiGianBatRung_Agg_4; //104
        private Double _ThoiGianTatRung_Agg_4; //108

        ////======================================Agg5=====================================
        private Double _ThoiGianTreCan_Agg_5; //112
        private Double _ThoiGianTreXa_Agg_5; //116
        private Double _ThoiGianTreDongCan_Agg_5; //120
        private Double _KhoiLuongBaoRong_Agg_5; //124
        private Double _KhoiLuongRungCan_Agg_5; //128
        private Double _ThoiGianBatRung_Agg_5; //132
        private Double _ThoiGianTatRung_Agg_5; //136

        ////======================================Agg6=====================================
        private Double _ThoiGianTreCan_Agg_6; //140
        private Double _ThoiGianTreXa_Agg_6; //144
        private Double _ThoiGianTreDongCan_Agg_6; //148
        private Double _KhoiLuongBaoRong_Agg_6; //152
        private Double _KhoiLuongRungCan_Agg_6; //156
        private Double _ThoiGianBatRung_Agg_6; //160
        private Double _ThoiGianTatRung_Agg_6; //164

        ////======================================Ce1=====================================
        private Double _ThoiGianTreCan_Ce_1; //168
        private Double _ThoiGianTreXa_Ce_1; //172
        private Double _ThoiGianTreDongCan_Ce_1; //176
        private Double _KhoiLuongBaoRong_Ce_1; //180
        private Double _KhoiLuongRungCan_Ce_1; //184
        private Double _ThoiGianBatRung_Ce_1; //188
        private Double _ThoiGianTatRung_Ce_1; //192

        ////======================================Ce2=====================================
        private Double _ThoiGianTreCan_Ce_2; //196
        private Double _ThoiGianTreXa_Ce_2; //200
        private Double _ThoiGianTreDongCan_Ce_2; //204
        private Double _KhoiLuongBaoRong_Ce_2; //208
        private Double _KhoiLuongRungCan_Ce_2; //212
        private Double _ThoiGianBatRung_Ce_2; //216
        private Double _ThoiGianTatRung_Ce_2; //220

        ////======================================Wa1=====================================
        private Double _ThoiGianTreCan_Wa_1; //224
        private Double _ThoiGianTreXa_Wa_1; //228
        private Double _ThoiGianTreDongCan_Wa_1; //232
        private Double _KhoiLuongBaoRong_Wa_1; //236

        ////======================================Wa2=====================================
        private Double _ThoiGianTreCan_Wa_2; //240
        private Double _ThoiGianTreXa_Wa_2; //244
        private Double _ThoiGianTreDongCan_Wa_2; //248
        private Double _KhoiLuongBaoRong_Wa_2; //252

        ////======================================Add1=====================================
        private Double _ThoiGianTreCan_Add_1; //256
        private Double _ThoiGianTreXa_Add_1; //260
        private Double _ThoiGianTreDongCan_Add_1; //264
        private Double _KhoiLuongBaoRong_Add_1; //268

        ////======================================Add2=====================================
        private Double _ThoiGianTreCan_Add_2; //272
        private Double _ThoiGianTreXa_Add_2; //276
        private Double _ThoiGianTreDongCan_Add_2; //280
        private Double _KhoiLuongBaoRong_Add_2; //284

        //================================================================================
       

        //================================================================================DB6 READ DATA CALIB WEIGHT
        private Double _Xung_Agg_1; //0
        private Double _Xung_Agg_2; //4
        private Double _Xung_Agg_3; //8
        private Double _Xung_Agg_4; //12
        private Double _Xung_Agg_5; //16
        private Double _Xung_Agg_6; //20
        private Double _Xung_Cem_1; //24
        private Double _Xung_Cem_2; //28
        private Double _Xung_Wa_1; //32
        private Double _Xung_Wa_2; //36
        private Double _Xung_Add_1; //40
        private Double _Xung_Add_2; //44

        private Double _Zero_Agg1; //48
        private Double _Span_Agg1; //52
        private Double _Zero_Agg2; //56
        private Double _Span_Agg2; //60
        private Double _Zero_Agg3; //64
        private Double _Span_Agg3; //68
        private Double _Zero_Agg4; //72
        private Double _Span_Agg4; //76
        private Double _Zero_Agg5; //80
        private Double _Span_Agg5; //84
        private Double _Zero_Agg6; //88
        private Double _Span_Agg6; //92

        private Double _Zero_Ce1; //96
        private Double _Span_Ce1; //100
        private Double _Zero_Ce2; //104
        private Double _Span_Ce2; //108

        private Double _Zero_Wa1; //112
        private Double _Span_Wa1; //116
        private Double _Zero_Wa2; //120
        private Double _Span_Wa2; //124

        private Double _Zero_Add1; //128
        private Double _Span_Add1; //132
        private Double _Zero_Add2; //136
        private Double _Span_Add2; //140

        private Double _HS_Xung_PG1; //144
        private Double _HS_Xung_PG2; //148
        private Double _HS_Xung_PG3; //152
        private Double _HS_Xung_PG4; //156
        private Double _HS_Xung_PG5; //160
        private Double _HS_Xung_PG6; //164

        private Double _KL_Xung_PG1; //168
        private Double _KL_Xung_PG2; //172
        private Double _KL_Xung_PG3; //176
        private Double _KL_Xung_PG4; //180
        private Double _KL_Xung_PG5; //184
        private Double _KL_Xung_PG6; //188

        private Double _KLT_AGG1; //220
        private Double _KLT_AGG2; //224
        private Double _KLT_AGG3; //228
        private Double _KLT_AGG4; //232
        private Double _KLT_AGG5; //236
        private Double _KLT_AGG6; //240
        private Double _KLT_WCE1; //244
        private Double _KLT_WCE2; //248
        private Double _KLT_WA1; //252
        private Double _KLT_WA2; //256
        private Double _KLT_ADD1; //260
        private Double _KLT_ADD2; //264

        private Double _KLX_ADD1; //268
        private Double _KLX_ADD2; //272
        private Double _KLX_ADD3; //276
        private Double _KLX_ADD4; //280
        private Double _KLX_ADD5; //284
        private Double _KLX_ADD6; //288

        //================================================================================DB7 READ DATA
        //===============================AGG1
        private Double _PV_AGG_1; //0
        private Double _Per_WAGG_1; //4
        private Double _WE_AGG_1; //8
        private Double _SMC_AGG_1; //12
        private Double _SMX_AGG_1; //16
        //===============================AGG2
        private Double _PV_AGG_2; //20
        private Double _Per_WAGG_2; //24
        private Double _WE_AGG_2; //28
        private Double _SMC_AGG_2; //32
        private Double _SMX_AGG_2; //36
        //===============================AGG3
        private Double _PV_AGG_3; //40
        private Double _Per_WAGG_3; //44
        private Double _WE_AGG_3; //48
        private Double _SMC_AGG_3; //52
        private Double _SMX_AGG_3; //56
        //===============================AGG4
        private Double _PV_AGG_4; //60
        private Double _Per_WAGG_4; //64
        private Double _WE_AGG_4; //68
        private Double _SMC_AGG_4; //72
        private Double _SMX_AGG_4; //76
        //===============================AGG5
        private Double _PV_AGG_5; //80
        private Double _Per_WAGG_5; //84
        private Double _WE_AGG_5; //88
        private Double _SMC_AGG_5; //92
        private Double _SMX_AGG_5; //96
        //===============================AGG6
        private Double _PV_AGG_6; //100
        private Double _Per_WAGG_6; //104
        private Double _WE_AGG_6; //108
        private Double _SMC_AGG_6; //112
        private Double _SMX_AGG_6; //116
        //===============================SILO
        private Double _PV_SILO_1; //120
        private Double _PV_SILO_2; //124
        private Double _PV_SILO_3; //128
        private Double _Per_WCEM_1; //132
        private Double _WE_CEM_1; //136
        private Double _SMC_CEM_1; //140
        private Double _SMX_CEM_1; //144
        private Double _PV_SILO_4; //148
        private Double _PV_SILO_5; //152
        private Double _Per_WCEM_2; //156
        private Double _WE_CEM_2; //160
        private Double _SMC_CEM_2; //164
        private Double _SMX_CEM_2; //168
        //===============================WA1
        private Double _PV_WA_1; //172
        private Double _Per_WWA_1; //176
        private Double _WE_WA_1; //180
        private Double _SMC_WA_1; //184
        private Double _SMX_WA_1; //188
        //===============================WA2
        private Double _PV_WA_2; //192
        private Double _Per_WWA_2; //196
        private Double _WE_WA_2; //190
        private Double _SMC_WA_2; //204
        private Double _SMX_WA_2; //208
        //===============================ADD
        private Double _PV_ADD_1; //212
        private Double _PV_ADD_2; //216
        private Double _PV_ADD_3; //220
        private Double _Per_WADD_1; //224
        private Double _WE_ADD_1; //228
        private Double _SMC_ADD_1; //232
        private Double _SMX_ADD_1; //236
        private Double _PV_ADD_4; //240
        private Double _PV_ADD_5; //244
        private Double _PV_ADD_6; //248
        private Double _Per_WADD_2; //252
        private Double _WE_ADD_2; //256
        private Double _SMC_ADD_2; //260
        private Double _SMX_ADD_2; //264
        private Double _SMC_SKIP; //268
        private Double _SMX_SKIP; //272
        private Double _SMC_PTG; //276
        private Double _SMX_PTG; //280
        //=================================Noi Tron
        private Double _SMC_MIXER; //284
        private Double _SMX_MIXER; //288
        private Double _ThoiGianThucTron; //292
        private Double _ThoiGianThucXa; //296
        //=================================Pheu Cho
        private Double _PheuChoStatus; //300

        //================================================================================DB8 READ DATA REPORT
        //=====================================AGG
        private Double _RE_PV_AGG1; //4
        private Double _RE_PVM_AGG1; //8
        private Double _RE_PV_AGG2; //12
        private Double _RE_PVM_AGG2; //16
        private Double _RE_PV_AGG3; //20
        private Double _RE_PVM_AGG3; //24
        private Double _RE_PV_AGG4; //28
        private Double _RE_PVM_AGG4; //32
        private Double _RE_PV_AGG5; //36
        private Double _RE_PVM_AGG5; //40
        private Double _RE_PV_AGG6; //44
        private Double _RE_PVM_AGG6; //48
        //=====================================CE
        private Double _RE_PV_CE1; //52
        private Double _RE_PVM_CE1; //56
        private Double _RE_PV_CE2; //60
        private Double _RE_PVM_CE2; //64
        private Double _RE_PV_CE3; //68
        private Double _RE_PVM_CE3; //72
        private Double _RE_PV_CE4; //76
        private Double _RE_PVM_CE4; //80
        private Double _RE_PV_CE5; //84
        private Double _RE_PVM_CE5; //88
        //=====================================WA
        private Double _RE_PV_WA1; //92
        private Double _RE_PVM_WA1; //96
        private Double _RE_PV_WA2; //100
        private Double _RE_PVM_WA2; //104
        //=====================================ADD
        private Double _RE_PV_PG1; //108
        private Double _RE_PVM_PG1; //112
        private Double _RE_PV_PG2; //116
        private Double _RE_PVM_PG2; //120
        private Double _RE_PV_PG3; //124
        private Double _RE_PVM_PG3; //128
        private Double _RE_PV_PG4; //132
        private Double _RE_PVM_PG4; //136
        private Double _RE_PV_PG5; //140
        private Double _RE_PVM_PG5; //144
        private Double _RE_PV_PG6; //148
        private Double _RE_PVM_PG6; //152

        //---------------------------------------------------------------------
        public Double SaiSoTren_Agg1
        {
            get
            {
                return this._SaiSoTren_Agg1;
            }
            set
            {
                this._SaiSoTren_Agg1 = value;
            }
        }
        public Double SaiSoDuoi_Agg1
        {
            get
            {
                return this._SaiSoDuoi_Agg1;
            }
            set
            {
                this._SaiSoDuoi_Agg1 = value;
            }
        }
        public Double RoiTuDo_Agg1
        {
            get
            {
                return this._RoiTuDo_Agg1;
            }
            set
            {
                this._RoiTuDo_Agg1 = value;
            }
        }
        public Double ThoiGianBatCan_Agg1
        {
            get
            {
                return this._ThoiGianBatCan_Agg1;
            }
            set
            {
                this._ThoiGianBatCan_Agg1 = value;
            }
        }
        public Double ThoiGianTatCan_Agg1
        {
            get
            {
                return this._ThoiGianTatCan_Agg1;
            }
            set
            {
                this._ThoiGianTatCan_Agg1 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Agg1
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Agg1;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Agg1 = value;
            }
        }
        public Double SaiSoTren_Agg2
        {
            get
            {
                return this._SaiSoTren_Agg2;
            }
            set
            {
                this._SaiSoTren_Agg2 = value;
            }
        }
        public Double SaiSoDuoi_Agg2
        {
            get
            {
                return this._SaiSoDuoi_Agg2;
            }
            set
            {
                this._SaiSoDuoi_Agg2 = value;
            }
        }
        public Double RoiTuDo_Agg2
        {
            get
            {
                return this._RoiTuDo_Agg2;
            }
            set
            {
                this._RoiTuDo_Agg2 = value;
            }
        }
        public Double ThoiGianBatCan_Agg2
        {
            get
            {
                return this._ThoiGianBatCan_Agg2;
            }
            set
            {
                this._ThoiGianBatCan_Agg2 = value;
            }
        }
        public Double ThoiGianTatCan_Agg2
        {
            get
            {
                return this._ThoiGianTatCan_Agg2;
            }
            set
            {
                this._ThoiGianTatCan_Agg2 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Agg2
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Agg2;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Agg2 = value;
            }
        }
        public Double SaiSoTren_Agg3
        {
            get
            {
                return this._SaiSoTren_Agg3;
            }
            set
            {
                this._SaiSoTren_Agg3 = value;
            }
        }
        public Double SaiSoDuoi_Agg3
        {
            get
            {
                return this._SaiSoDuoi_Agg3;
            }
            set
            {
                this._SaiSoDuoi_Agg3 = value;
            }
        }
        public Double RoiTuDo_Agg3
        {
            get
            {
                return this._RoiTuDo_Agg3;
            }
            set
            {
                this._RoiTuDo_Agg3 = value;
            }
        }
        public Double ThoiGianBatCan_Agg3
        {
            get
            {
                return this._ThoiGianBatCan_Agg3;
            }
            set
            {
                this._ThoiGianBatCan_Agg3 = value;
            }
        }
        public Double ThoiGianTatCan_Agg3
        {
            get
            {
                return this._ThoiGianTatCan_Agg3;
            }
            set
            {
                this._ThoiGianTatCan_Agg3 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Agg3
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Agg3;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Agg3 = value;
            }
        }
        //Agg4
        public Double SaiSoTren_Agg4
        {
            get
            {
                return this._SaiSoTren_Agg4;
            }
            set
            {
                this._SaiSoTren_Agg4 = value;
            }
        }
        public Double SaiSoDuoi_Agg4
        {
            get
            {
                return this._SaiSoDuoi_Agg4;
            }
            set
            {
                this._SaiSoDuoi_Agg4 = value;
            }
        }
        public Double RoiTuDo_Agg4
        {
            get
            {
                return this._RoiTuDo_Agg4;
            }
            set
            {
                this._RoiTuDo_Agg4 = value;
            }
        }
        public Double ThoiGianBatCan_Agg4
        {
            get
            {
                return this._ThoiGianBatCan_Agg4;
            }
            set
            {
                this._ThoiGianBatCan_Agg4 = value;
            }
        }
        public Double ThoiGianTatCan_Agg4
        {
            get
            {
                return this._ThoiGianTatCan_Agg4;
            }
            set
            {
                this._ThoiGianTatCan_Agg4 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Agg4
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Agg4;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Agg4 = value;
            }
        }
        //AGG5
        public Double SaiSoTren_Agg5
        {
            get
            {
                return this._SaiSoTren_Agg5;
            }
            set
            {
                this._SaiSoTren_Agg5 = value;
            }
        }
        public Double SaiSoDuoi_Agg5
        {
            get
            {
                return this._SaiSoDuoi_Agg5;
            }
            set
            {
                this._SaiSoDuoi_Agg5 = value;
            }
        }
        public Double RoiTuDo_Agg5
        {
            get
            {
                return this._RoiTuDo_Agg5;
            }
            set
            {
                this._RoiTuDo_Agg5 = value;
            }
        }
        public Double ThoiGianBatCan_Agg5
        {
            get
            {
                return this._ThoiGianBatCan_Agg5;
            }
            set
            {
                this._ThoiGianBatCan_Agg5 = value;
            }
        }
        public Double ThoiGianTatCan_Agg5
        {
            get
            {
                return this._ThoiGianTatCan_Agg5;
            }
            set
            {
                this._ThoiGianTatCan_Agg5 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Agg5
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Agg5;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Agg5 = value;
            }
        }
        //AGG6
        public Double SaiSoTren_Agg6
        {
            get
            {
                return this._SaiSoTren_Agg6;
            }
            set
            {
                this._SaiSoTren_Agg6 = value;
            }
        }
        public Double SaiSoDuoi_Agg6
        {
            get
            {
                return this._SaiSoDuoi_Agg6;
            }
            set
            {
                this._SaiSoDuoi_Agg6 = value;
            }
        }
        public Double RoiTuDo_Agg6
        {
            get
            {
                return this._RoiTuDo_Agg6;
            }
            set
            {
                this._RoiTuDo_Agg6 = value;
            }
        }
        public Double ThoiGianBatCan_Agg6
        {
            get
            {
                return this._ThoiGianBatCan_Agg6;
            }
            set
            {
                this._ThoiGianBatCan_Agg6 = value;
            }
        }
        public Double ThoiGianTatCan_Agg6
        {
            get
            {
                return this._ThoiGianTatCan_Agg6;
            }
            set
            {
                this._ThoiGianTatCan_Agg6 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Agg6
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Agg6;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Agg6 = value;
            }
        }
        //CE1
        public Double SaiSoTren_Ce1
        {
            get
            {
                return this._SaiSoTren_Ce1;
            }
            set
            {
                this._SaiSoTren_Ce1 = value;
            }
        }
        public Double SaiSoDuoi_Ce1
        {
            get
            {
                return this._SaiSoDuoi_Ce1;
            }
            set
            {
                this._SaiSoDuoi_Ce1 = value;
            }
        }
        public Double RoiTuDo_Ce1
        {
            get
            {
                return this._RoiTuDo_Ce1;
            }
            set
            {
                this._RoiTuDo_Ce1 = value;
            }
        }
        public Double ThoiGianBatCan_Ce1
        {
            get
            {
                return this._ThoiGianBatCan_Ce1;
            }
            set
            {
                this._ThoiGianBatCan_Ce1 = value;
            }
        }
        public Double ThoiGianTatCan_Ce1
        {
            get
            {
                return this._ThoiGianTatCan_Ce1;
            }
            set
            {
                this._ThoiGianTatCan_Ce1 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Ce1
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Ce1;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Ce1 = value;
            }
        }
        //CE2
        public Double SaiSoTren_Ce2
        {
            get
            {
                return this._SaiSoTren_Ce2;
            }
            set
            {
                this._SaiSoTren_Ce2 = value;
            }
        }
        public Double SaiSoDuoi_Ce2
        {
            get
            {
                return this._SaiSoDuoi_Ce2;
            }
            set
            {
                this._SaiSoDuoi_Ce2 = value;
            }
        }
        public Double RoiTuDo_Ce2
        {
            get
            {
                return this._RoiTuDo_Ce2;
            }
            set
            {
                this._RoiTuDo_Ce2 = value;
            }
        }
        public Double ThoiGianBatCan_Ce2
        {
            get
            {
                return this._ThoiGianBatCan_Ce2;
            }
            set
            {
                this._ThoiGianBatCan_Ce2 = value;
            }
        }
        public Double ThoiGianTatCan_Ce2
        {
            get
            {
                return this._ThoiGianTatCan_Ce2;
            }
            set
            {
                this._ThoiGianTatCan_Ce2 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Ce2
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Ce2;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Ce2 = value;
            }
        }
        //CE3
        public Double SaiSoTren_Ce3
        {
            get
            {
                return this._SaiSoTren_Ce3;
            }
            set
            {
                this._SaiSoTren_Ce3 = value;
            }
        }
        public Double SaiSoDuoi_Ce3
        {
            get
            {
                return this._SaiSoDuoi_Ce3;
            }
            set
            {
                this._SaiSoDuoi_Ce3 = value;
            }
        }
        public Double RoiTuDo_Ce3
        {
            get
            {
                return this._RoiTuDo_Ce3;
            }
            set
            {
                this._RoiTuDo_Ce3 = value;
            }
        }
        public Double ThoiGianBatCan_Ce3
        {
            get
            {
                return this._ThoiGianBatCan_Ce3;
            }
            set
            {
                this._ThoiGianBatCan_Ce3 = value;
            }
        }
        public Double ThoiGianTatCan_Ce3
        {
            get
            {
                return this._ThoiGianTatCan_Ce3;
            }
            set
            {
                this._ThoiGianTatCan_Ce3 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Ce3
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Ce3;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Ce3 = value;
            }
        }
        //CE4
        public Double SaiSoTren_Ce4
        {
            get
            {
                return this._SaiSoTren_Ce4;
            }
            set
            {
                this._SaiSoTren_Ce4 = value;
            }
        }
        public Double SaiSoDuoi_Ce4
        {
            get
            {
                return this._SaiSoDuoi_Ce4;
            }
            set
            {
                this._SaiSoDuoi_Ce4 = value;
            }
        }
        public Double RoiTuDo_Ce4
        {
            get
            {
                return this._RoiTuDo_Ce4;
            }
            set
            {
                this._RoiTuDo_Ce4 = value;
            }
        }
        public Double ThoiGianBatCan_Ce4
        {
            get
            {
                return this._ThoiGianBatCan_Ce4;
            }
            set
            {
                this._ThoiGianBatCan_Ce4 = value;
            }
        }
        public Double ThoiGianTatCan_Ce4
        {
            get
            {
                return this._ThoiGianTatCan_Ce4;
            }
            set
            {
                this._ThoiGianTatCan_Ce4 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Ce4
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Ce4;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Ce4 = value;
            }
        }
        //CE5
        public Double SaiSoTren_Ce5
        {
            get
            {
                return this._SaiSoTren_Ce5;
            }
            set
            {
                this._SaiSoTren_Ce5 = value;
            }
        }
        public Double SaiSoDuoi_Ce5
        {
            get
            {
                return this._SaiSoDuoi_Ce5;
            }
            set
            {
                this._SaiSoDuoi_Ce5 = value;
            }
        }
        public Double RoiTuDo_Ce5
        {
            get
            {
                return this._RoiTuDo_Ce5;
            }
            set
            {
                this._RoiTuDo_Ce5 = value;
            }
        }
        public Double ThoiGianBatCan_Ce5
        {
            get
            {
                return this._ThoiGianBatCan_Ce5;
            }
            set
            {
                this._ThoiGianBatCan_Ce5 = value;
            }
        }
        public Double ThoiGianTatCan_Ce5
        {
            get
            {
                return this._ThoiGianTatCan_Ce5;
            }
            set
            {
                this._ThoiGianTatCan_Ce5 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Ce5
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Ce5;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Ce5 = value;
            }
        }
        //WA1
        public Double SaiSoTren_Wa1
        {
            get
            {
                return this._SaiSoTren_Wa1;
            }
            set
            {
                this._SaiSoTren_Wa1 = value;
            }
        }
        public Double SaiSoDuoi_Wa1
        {
            get
            {
                return this._SaiSoDuoi_Wa1;
            }
            set
            {
                this._SaiSoDuoi_Wa1 = value;
            }
        }
        public Double RoiTuDo_Wa1
        {
            get
            {
                return this._RoiTuDo_Wa1;
            }
            set
            {
                this._RoiTuDo_Wa1 = value;
            }
        }
        public Double ThoiGianBatCan_Wa1
        {
            get
            {
                return this._ThoiGianBatCan_Wa1;
            }
            set
            {
                this._ThoiGianBatCan_Wa1 = value;
            }
        }
        public Double ThoiGianTatCan_Wa1
        {
            get
            {
                return this._ThoiGianTatCan_Wa1;
            }
            set
            {
                this._ThoiGianTatCan_Wa1 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Wa1
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Wa1;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Wa1 = value;
            }
        }
        //WA2
        public Double SaiSoTren_Wa2
        {
            get
            {
                return this._SaiSoTren_Wa2;
            }
            set
            {
                this._SaiSoTren_Wa2 = value;
            }
        }
        public Double SaiSoDuoi_Wa2
        {
            get
            {
                return this._SaiSoDuoi_Wa2;
            }
            set
            {
                this._SaiSoDuoi_Wa2 = value;
            }
        }
        public Double RoiTuDo_Wa2
        {
            get
            {
                return this._RoiTuDo_Wa2;
            }
            set
            {
                this._RoiTuDo_Wa2 = value;
            }
        }
        public Double ThoiGianBatCan_Wa2
        {
            get
            {
                return this._ThoiGianBatCan_Wa2;
            }
            set
            {
                this._ThoiGianBatCan_Wa2 = value;
            }
        }
        public Double ThoiGianTatCan_Wa2
        {
            get
            {
                return this._ThoiGianTatCan_Wa2;
            }
            set
            {
                this._ThoiGianTatCan_Wa2 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Wa2
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Wa2;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Wa2 = value;
            }
        }
        //ADD1
        public Double SaiSoTren_Add1
        {
            get
            {
                return this._SaiSoTren_Add1;
            }
            set
            {
                this._SaiSoTren_Add1 = value;
            }
        }
        public Double SaiSoDuoi_Add1
        {
            get
            {
                return this._SaiSoDuoi_Add1;
            }
            set
            {
                this._SaiSoDuoi_Add1 = value;
            }
        }
        public Double RoiTuDo_Add1
        {
            get
            {
                return this._RoiTuDo_Add1;
            }
            set
            {
                this._RoiTuDo_Add1 = value;
            }
        }
        public Double ThoiGianBatCan_Add1
        {
            get
            {
                return this._ThoiGianBatCan_Add1;
            }
            set
            {
                this._ThoiGianBatCan_Add1 = value;
            }
        }
        public Double ThoiGianTatCan_Add1
        {
            get
            {
                return this._ThoiGianTatCan_Add1;
            }
            set
            {
                this._ThoiGianTatCan_Add1 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Add1
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Add1;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Add1 = value;
            }
        }
        //ADD2
        public Double SaiSoTren_Add2
        {
            get
            {
                return this._SaiSoTren_Add2;
            }
            set
            {
                this._SaiSoTren_Add2 = value;
            }
        }
        public Double SaiSoDuoi_Add2
        {
            get
            {
                return this._SaiSoDuoi_Add2;
            }
            set
            {
                this._SaiSoDuoi_Add2 = value;
            }
        }
        public Double RoiTuDo_Add2
        {
            get
            {
                return this._RoiTuDo_Add2;
            }
            set
            {
                this._RoiTuDo_Add2 = value;
            }
        }
        public Double ThoiGianBatCan_Add2
        {
            get
            {
                return this._ThoiGianBatCan_Add2;
            }
            set
            {
                this._ThoiGianBatCan_Add2 = value;
            }
        }
        public Double ThoiGianTatCan_Add2
        {
            get
            {
                return this._ThoiGianTatCan_Add2;
            }
            set
            {
                this._ThoiGianTatCan_Add2 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Add2
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Add2;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Add2 = value;
            }
        }
        //ADD3
        public Double SaiSoTren_Add3
        {
            get
            {
                return this._SaiSoTren_Add3;
            }
            set
            {
                this._SaiSoTren_Add3 = value;
            }
        }
        public Double SaiSoDuoi_Add3
        {
            get
            {
                return this._SaiSoDuoi_Add3;
            }
            set
            {
                this._SaiSoDuoi_Add3 = value;
            }
        }
        public Double RoiTuDo_Add3
        {
            get
            {
                return this._RoiTuDo_Add3;
            }
            set
            {
                this._RoiTuDo_Add3 = value;
            }
        }
        public Double ThoiGianBatCan_Add3
        {
            get
            {
                return this._ThoiGianBatCan_Add3;
            }
            set
            {
                this._ThoiGianBatCan_Add3 = value;
            }
        }
        public Double ThoiGianTatCan_Add3
        {
            get
            {
                return this._ThoiGianTatCan_Add3;
            }
            set
            {
                this._ThoiGianTatCan_Add3 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Add3
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Add3;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Add3 = value;
            }
        }
        //ADD4
        public Double SaiSoTren_Add4
        {
            get
            {
                return this._SaiSoTren_Add4;
            }
            set
            {
                this._SaiSoTren_Add4 = value;
            }
        }
        public Double SaiSoDuoi_Add4
        {
            get
            {
                return this._SaiSoDuoi_Add4;
            }
            set
            {
                this._SaiSoDuoi_Add4 = value;
            }
        }
        public Double RoiTuDo_Add4
        {
            get
            {
                return this._RoiTuDo_Add4;
            }
            set
            {
                this._RoiTuDo_Add4 = value;
            }
        }
        public Double ThoiGianBatCan_Add4
        {
            get
            {
                return this._ThoiGianBatCan_Add4;
            }
            set
            {
                this._ThoiGianBatCan_Add4 = value;
            }
        }
        public Double ThoiGianTatCan_Add4
        {
            get
            {
                return this._ThoiGianTatCan_Add4;
            }
            set
            {
                this._ThoiGianTatCan_Add4 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Add4
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Add4;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Add4 = value;
            }
        }
        //ADD5
        public Double SaiSoTren_Add5
        {
            get
            {
                return this._SaiSoTren_Add5;
            }
            set
            {
                this._SaiSoTren_Add5 = value;
            }
        }
        public Double SaiSoDuoi_Add5
        {
            get
            {
                return this._SaiSoDuoi_Add5;
            }
            set
            {
                this._SaiSoDuoi_Add5 = value;
            }
        }
        public Double RoiTuDo_Add5
        {
            get
            {
                return this._RoiTuDo_Add5;
            }
            set
            {
                this._RoiTuDo_Add5 = value;
            }
        }
        public Double ThoiGianBatCan_Add5
        {
            get
            {
                return this._ThoiGianBatCan_Add5;
            }
            set
            {
                this._ThoiGianBatCan_Add5 = value;
            }
        }
        public Double ThoiGianTatCan_Add5
        {
            get
            {
                return this._ThoiGianTatCan_Add5;
            }
            set
            {
                this._ThoiGianTatCan_Add5 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Add5
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Add5;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Add5 = value;
            }
        }
        //ADD6
        public Double SaiSoTren_Add6
        {
            get
            {
                return this._SaiSoTren_Add6;
            }
            set
            {
                this._SaiSoTren_Add6 = value;
            }
        }
        public Double SaiSoDuoi_Add6
        {
            get
            {
                return this._SaiSoDuoi_Add6;
            }
            set
            {
                this._SaiSoDuoi_Add6 = value;
            }
        }
        public Double RoiTuDo_Add6
        {
            get
            {
                return this._RoiTuDo_Add6;
            }
            set
            {
                this._RoiTuDo_Add6 = value;
            }
        }
        public Double ThoiGianBatCan_Add6
        {
            get
            {
                return this._ThoiGianBatCan_Add6;
            }
            set
            {
                this._ThoiGianBatCan_Add6 = value;
            }
        }
        public Double ThoiGianTatCan_Add6
        {
            get
            {
                return this._ThoiGianTatCan_Add6;
            }
            set
            {
                this._ThoiGianTatCan_Add6 = value;
            }
        }
        public Double ThoiGianTinhLuongRoiThem_Add6
        {
            get
            {
                return this._ThoiGianTinhLuongRoiThem_Add6;
            }
            set
            {
                this._ThoiGianTinhLuongRoiThem_Add6 = value;
            }
        }

        //=============================================================DB2
        
        public Double ThoiGianTreCan_Ce
        {
            get
            {
                return this._ThoiGianTreCan_Ce;
            }
            set
            {
                this._ThoiGianTreCan_Ce = value;
            }
        }
        public Double ThoiGianTreXa_Ce
        {
            get
            {
                return this._ThoiGianTreXa_Ce;
            }
            set
            {
                this._ThoiGianTreXa_Ce = value;
            }
        }
        public Double ThoiGianTreDongCan_Ce
        {
            get
            {
                return this._ThoiGianTreDongCan_Ce;
            }
            set
            {
                this._ThoiGianTreDongCan_Ce = value;
            }
        }
        public Double KhoiLuongBaoRong_Ce
        {
            get
            {
                return this._KhoiLuongBaoRong_Ce;
            }
            set
            {
                this._KhoiLuongBaoRong_Ce = value;
            }
        }
        public Double KhoiLuongRungCan_Ce
        {
            get
            {
                return this._KhoiLuongRungCan_Ce;
            }
            set
            {
                this._KhoiLuongRungCan_Ce = value;
            }
        }
        public Double ThoiGianBatRung_Ce
        {
            get
            {
                return this._ThoiGianBatRung_Ce;
            }
            set
            {
                this._ThoiGianBatRung_Ce = value;
            }
        }
        public Double ThoiGianTatRung_Ce
        {
            get
            {
                return this._ThoiGianTatRung_Ce;
            }
            set
            {
                this._ThoiGianTatRung_Ce = value;
            }
        }
        public Double ThoiGianTreCan_Wa
        {
            get
            {
                return this._ThoiGianTreCan_Wa;
            }
            set
            {
                this._ThoiGianTreCan_Wa = value;
            }
        }
        public Double ThoiGianTreXa_Wa
        {
            get
            {
                return this._ThoiGianTreXa_Wa;
            }
            set
            {
                this._ThoiGianTreXa_Wa = value;
            }
        }
        public Double ThoiGianTreDongCan_Wa
        {
            get
            {
                return this._ThoiGianTreDongCan_Wa;
            }
            set
            {
                this._ThoiGianTreDongCan_Wa = value;
            }
        }
        public Double KhoiLuongBaoRong_Wa
        {
            get
            {
                return this._KhoiLuongBaoRong_Wa;
            }
            set
            {
                this._KhoiLuongBaoRong_Wa = value;
            }
        }
        public Double XungCan_Agg
        {
            get
            {
                return this._XungCan_Agg;
            }
            set
            {
                this._XungCan_Agg = value;
            }
        }
        public Double KL_Chinh_0_Agg
        {
            get
            {
                return this._KL_Chinh_0_Agg;
            }
            set
            {
                this._KL_Chinh_0_Agg = value;
            }
        }
        public Double KL_ChinhTai_Agg
        {
            get
            {
                return this._KL_ChinhTai_Agg;
            }
            set
            {
                this._KL_ChinhTai_Agg = value;
            }
        }
        public Double KL_Thuc_Agg
        {
            get
            {
                return this._KL_Thuc_Agg;
            }
            set
            {
                this._KL_Thuc_Agg = value;
            }
        }
        public Double XungCan_Ce
        {
            get
            {
                return this._XungCan_Ce;
            }
            set
            {
                this._XungCan_Ce = value;
            }
        }
        public Double KL_Chinh_0_Ce
        {
            get
            {
                return this._KL_Chinh_0_Ce;
            }
            set
            {
                this._KL_Chinh_0_Ce = value;
            }
        }
        public Double KL_ChinhTai_Ce
        {
            get
            {
                return this._KL_ChinhTai_Ce;
            }
            set
            {
                this._KL_ChinhTai_Ce = value;
            }
        }
        public Double KL_Thuc_Ce
        {
            get
            {
                return this._KL_Thuc_Ce;
            }
            set
            {
                this._KL_Thuc_Ce = value;
            }
        }
        public Double XungCan_Wa
        {
            get
            {
                return this._XungCan_Wa;
            }
            set
            {
                this._XungCan_Wa = value;
            }
        }
        public Double KL_Chinh_0_Wa
        {
            get
            {
                return this._KL_Chinh_0_Wa;
            }
            set
            {
                this._KL_Chinh_0_Wa = value;
            }
        }
        public Double KL_ChinhTai_Wa
        {
            get
            {
                return this._KL_ChinhTai_Wa;
            }
            set
            {
                this._KL_ChinhTai_Wa = value;
            }
        }
        public Double KL_Thuc_Wa
        {
            get
            {
                return this._KL_Thuc_Wa;
            }
            set
            {
                this._KL_Thuc_Wa = value;
            }
        }
        public Double Per_KL_AGG
        {
            get
            {
                return this._Per_KL_AGG;
            }
            set
            {
                this._Per_KL_AGG = value;
            }
        }
        public Double Per_KL_CE
        {
            get
            {
                return this._Per_KL_CE;
            }
            set
            {
                this._Per_KL_CE = value;
            }
        }
        public Double Per_KL_WA
        {
            get
            {
                return this._Per_KL_WA;
            }
            set
            {
                this._Per_KL_WA = value;
            }
        }


        //=================================================DB8 READ DATA
        public bool Save_Report
        {
            get
            {
                return this._Save_Report;
            }
            set
            {
                this._Save_Report = value;
            }
        }

        //=================================================DB1 READ DATA
        public bool Op_TinHieu_NoiTron
        {
            get
            {
                return this._Op_TinHieu_NoiTron;
            }
            set
            {
                this._Op_TinHieu_NoiTron = value;
            }
        }

        
        public bool Op_TinHieu_BangTaiXien
        {
            get
            {
                return this._Op_TinHieu_BangTaiXien;
            }
            set
            {
                this._Op_TinHieu_BangTaiXien = value;
            }
        }

        public bool Op_TinHieu_BangTaiCan
        {
            get
            {
                return this._Op_TinHieu_BangTaiCan;
            }
            set
            {
                this._Op_TinHieu_BangTaiCan = value;
            }
        }

        public bool Op_TinHieu_GauLen
        {
            get
            {
                return this._Op_TinHieu_GauLen;
            }
            set
            {
                this._Op_TinHieu_GauLen = value;
            }
        }

        public bool Op_TinHieu_GauXuong
        {
            get
            {
                return this._Op_TinHieu_GauXuong;
            }
            set
            {
                this._Op_TinHieu_GauXuong = value;
            }
        }

        public bool Op_TinHieu_GauTren
        {
            get
            {
                return this._Op_TinHieu_GauTren;
            }
            set
            {
                this._Op_TinHieu_GauTren = value;
            }
        }

        public bool Op_TinHieu_GauCho
        {
            get
            {
                return this._Op_TinHieu_GauCho;
            }
            set
            {
                this._Op_TinHieu_GauCho = value;
            }
        }

        public bool Op_TinHieu_GauDuoi
        {
            get
            {
                return this._Op_TinHieu_GauDuoi;
            }
            set
            {
                this._Op_TinHieu_GauDuoi = value;
            }
        }
        // BYTE 1
        public bool Op_TinHieu_GauAnToan
        {
            get
            {
                return this._Op_TinHieu_GauAnToan;
            }
            set
            {
                this._Op_TinHieu_GauAnToan = value;
            }
        }

        public bool Op_TinHieu_CuaNoiDong
        {
            get
            {
                return this._Op_TinHieu_CuaNoiDong;
            }
            set
            {
                this._Op_TinHieu_CuaNoiDong = value;
            }
        }

        public bool Op_TinHieu_CuaNoi_1p2
        {
            get
            {
                return this._Op_TinHieu_CuaNoi_1p2;
            }
            set
            {
                this._Op_TinHieu_CuaNoi_1p2 = value;
            }
        }

        public bool Op_TinHieu_CuaNoiMo
        {
            get
            {
                return this._Op_TinHieu_CuaNoiMo;
            }
            set
            {
                this._Op_TinHieu_CuaNoiMo = value;
            }
        }

        public bool Op_TinHieu_PheuChoDong
        {
            get
            {
                return this._Op_TinHieu_PheuChoDong;
            }
            set
            {
                this._Op_TinHieu_PheuChoDong = value;
            }
        }

        public bool Op_TinHieu_PheuChoMo
        {
            get
            {
                return this._Op_TinHieu_PheuChoMo;
            }
            set
            {
                this._Op_TinHieu_PheuChoMo = value;
            }
        }

        public bool Op_Van_MoCuaNoi
        {
            get
            {
                return this._Op_Van_MoCuaNoi;
            }
            set
            {
                this._Op_Van_MoCuaNoi = value;
            }
        }

        public bool Op_Van_DongCuaNoi
        {
            get
            {
                return this._Op_Van_DongCuaNoi;
            }
            set
            {
                this._Op_Van_DongCuaNoi = value;
            }
        }

        // BYTE 2
        public bool Op_Van_XaPheuCho
        {
            get
            {
                return this._Op_Van_XaPheuCho;
            }
            set
            {
                this._Op_Van_XaPheuCho = value;
            }
        }

        public bool Op_VanCan_XiMang_1
        {
            get
            {
                return this._Op_VanCan_XiMang_1;
            }
            set
            {
                this._Op_VanCan_XiMang_1 = value;
            }
        }

        public bool Op_VanCan_XiMang_2
        {
            get
            {
                return this._Op_VanCan_XiMang_2;
            }
            set
            {
                this._Op_VanCan_XiMang_2 = value;
            }
        }

        public bool Op_VanCan_XiMang_3
        {
            get
            {
                return this._Op_VanCan_XiMang_3;
            }
            set
            {
                this._Op_VanCan_XiMang_3 = value;
            }
        }

        public bool Op_VanXa_PheuCan_XiMang_1
        {
            get
            {
                return this._Op_VanXa_PheuCan_XiMang_1;
            }
            set
            {
                this._Op_VanXa_PheuCan_XiMang_1 = value;
            }
        }

        public bool Op_VanCan_XiMang_4
        {
            get
            {
                return this._Op_VanCan_XiMang_4;
            }
            set
            {
                this._Op_VanCan_XiMang_4 = value;
            }
        }

        public bool Op_VanCan_XiMang_5
        {
            get
            {
                return this._Op_VanCan_XiMang_5;
            }
            set
            {
                this._Op_VanCan_XiMang_5 = value;
            }
        }

        public bool Op_VanXa_PheuCan_XiMang_2
        {
            get
            {
                return this._Op_VanXa_PheuCan_XiMang_2;
            }
            set
            {
                this._Op_VanXa_PheuCan_XiMang_2 = value;
            }
        }
        // BYTE 3
        public bool Op_VanCan_Nuoc_1
        {
            get
            {
                return this._Op_VanCan_Nuoc_1;
            }
            set
            {
                this._Op_VanCan_Nuoc_1 = value;
            }
        }

        public bool Op_VanXa_PheuCan_Nuoc_1
        {
            get
            {
                return this._Op_VanXa_PheuCan_Nuoc_1;
            }
            set
            {
                this._Op_VanXa_PheuCan_Nuoc_1 = value;
            }
        }

        public bool Op_VanCan_Nuoc_2
        {
            get
            {
                return this._Op_VanCan_Nuoc_2;
            }
            set
            {
                this._Op_VanCan_Nuoc_2 = value;
            }
        }

        public bool Op_VanXa_PheuCan_Nuoc_2
        {
            get
            {
                return this._Op_VanXa_PheuCan_Nuoc_2;
            }
            set
            {
                this._Op_VanXa_PheuCan_Nuoc_2 = value;
            }
        }

        public bool Op_VanCan_PhuGia_1
        {
            get
            {
                return this._Op_VanCan_PhuGia_1;
            }
            set
            {
                this._Op_VanCan_PhuGia_1 = value;
            }
        }

        public bool Op_VanCan_PhuGia_2
        {
            get
            {
                return this._Op_VanCan_PhuGia_2;
            }
            set
            {
                this._Op_VanCan_PhuGia_2 = value;
            }
        }

        public bool Op_VanCan_PhuGia_3
        {
            get
            {
                return this._Op_VanCan_PhuGia_3;
            }
            set
            {
                this._Op_VanCan_PhuGia_3 = value;
            }
        }

        public bool Op_VanXa_PheuCan_PhuGia_1
        {
            get
            {
                return this._Op_VanXa_PheuCan_PhuGia_1;
            }
            set
            {
                this._Op_VanXa_PheuCan_PhuGia_1 = value;
            }
        }
        // BYTE 4
        public bool Op_VanCan_PhuGia_4
        {
            get
            {
                return this._Op_VanCan_PhuGia_4;
            }
            set
            {
                this._Op_VanCan_PhuGia_4 = value;
            }
        }

        public bool Op_VanCan_PhuGia_5
        {
            get
            {
                return this._Op_VanCan_PhuGia_5;
            }
            set
            {
                this._Op_VanCan_PhuGia_5 = value;
            }
        }

        public bool Op_VanCan_PhuGia_6
        {
            get
            {
                return this._Op_VanCan_PhuGia_6;
            }
            set
            {
                this._Op_VanCan_PhuGia_6 = value;
            }
        }

        public bool Op_VanXa_PheuCan_PhuGia_2
        {
            get
            {
                return this._Op_VanXa_PheuCan_PhuGia_2;
            }
            set
            {
                this._Op_VanXa_PheuCan_PhuGia_2 = value;
            }
        }

        public bool Op_VanCan_Agg_1_1
        {
            get
            {
                return this._Op_VanCan_Agg_1_1;
            }
            set
            {
                this._Op_VanCan_Agg_1_1 = value;
            }
        }

        public bool Op_VanCan_Agg_1_2
        {
            get
            {
                return this._Op_VanCan_Agg_1_2;
            }
            set
            {
                this._Op_VanCan_Agg_1_2 = value;
            }
        }

        public bool Op_VanXa_PheuCan_Agg_1
        {
            get
            {
                return this._Op_VanXa_PheuCan_Agg_1;
            }
            set
            {
                this._Op_VanXa_PheuCan_Agg_1 = value;
            }
        }

        public bool Op_VanCan_Agg_2_1
        {
            get
            {
                return this._Op_VanCan_Agg_2_1;
            }
            set
            {
                this._Op_VanCan_Agg_2_1 = value;
            }
        }
        // BYTE 5
        public bool Op_VanCan_Agg_2_2
        {
            get
            {
                return this._Op_VanCan_Agg_2_2;
            }
            set
            {
                this._Op_VanCan_Agg_2_2 = value;
            }
        }

        public bool Op_VanXa_PheuCan_Agg_2
        {
            get
            {
                return this._Op_VanXa_PheuCan_Agg_2;
            }
            set
            {
                this._Op_VanXa_PheuCan_Agg_2 = value;
            }
        }

        public bool Op_VanCan_Agg_3_1
        {
            get
            {
                return this._Op_VanCan_Agg_3_1;
            }
            set
            {
                this._Op_VanCan_Agg_3_1 = value;
            }
        }

        public bool Op_VanCan_Agg_3_2
        {
            get
            {
                return this._Op_VanCan_Agg_3_2;
            }
            set
            {
                this._Op_VanCan_Agg_3_2 = value;
            }
        }

        public bool Op_VanXa_PheuCan_Agg_3
        {
            get
            {
                return this._Op_VanXa_PheuCan_Agg_3;
            }
            set
            {
                this._Op_VanXa_PheuCan_Agg_3 = value;
            }
        }

        public bool Op_VanCan_Agg_4_1
        {
            get
            {
                return this._Op_VanCan_Agg_4_1;
            }
            set
            {
                this._Op_VanCan_Agg_4_1 = value;
            }
        }

        public bool Op_VanCan_Agg_4_2
        {
            get
            {
                return this._Op_VanCan_Agg_4_2;
            }
            set
            {
                this._Op_VanCan_Agg_4_2 = value;
            }
        }

        public bool Op_VanXa_PheuCan_Agg_4
        {
            get
            {
                return this._Op_VanXa_PheuCan_Agg_4;
            }
            set
            {
                this._Op_VanXa_PheuCan_Agg_4 = value;
            }
        }
        // BYTE 6
        public bool Op_VanCan_Agg_5_1
        {
            get
            {
                return this._Op_VanCan_Agg_5_1;
            }
            set
            {
                this._Op_VanCan_Agg_5_1 = value;
            }
        }

        public bool Op_VanCan_Agg_5_2
        {
            get
            {
                return this._Op_VanCan_Agg_5_2;
            }
            set
            {
                this._Op_VanCan_Agg_5_2 = value;
            }
        }

        public bool Op_VanXa_PheuCan_Agg_5
        {
            get
            {
                return this._Op_VanXa_PheuCan_Agg_5;
            }
            set
            {
                this._Op_VanXa_PheuCan_Agg_5 = value;
            }
        }

        public bool Op_VanCan_Agg_6_1
        {
            get
            {
                return this._Op_VanCan_Agg_6_1;
            }
            set
            {
                this._Op_VanCan_Agg_6_1 = value;
            }
        }

        public bool Op_VanCan_Agg_6_2
        {
            get
            {
                return this._Op_VanCan_Agg_6_2;
            }
            set
            {
                this._Op_VanCan_Agg_6_2 = value;
            }
        }

        public bool Op_VanXa_PheuCan_Agg_6
        {
            get
            {
                return this._Op_VanXa_PheuCan_Agg_6;
            }
            set
            {
                this._Op_VanXa_PheuCan_Agg_6 = value;
            }
        }

        public bool Op_RungPheuCho
        {
            get
            {
                return this._Op_RungPheuCho;
            }
            set
            {
                this._Op_RungPheuCho = value;
            }
        }

        public bool Op_RungPheuCan_XiMang_1
        {
            get
            {
                return this._Op_RungPheuCan_XiMang_1;
            }
            set
            {
                this._Op_RungPheuCan_XiMang_1 = value;
            }
        }
        // BYTE 7
        public bool Op_RungPheuCan_XiMang_2
        {
            get
            {
                return this._Op_RungPheuCan_XiMang_2;
            }
            set
            {
                this._Op_RungPheuCan_XiMang_2 = value;
            }
        }
        public bool Op_RungPheuCan_CotLieu_1
        {
            get
            {
                return this._Op_RungPheuCan_CotLieu_1;
            }
            set
            {
                this._Op_RungPheuCan_CotLieu_1 = value;
            }
        }
        public bool Op_RungPheuCan_CotLieu_2
        {
            get
            {
                return this._Op_RungPheuCan_CotLieu_2;
            }
            set
            {
                this._Op_RungPheuCan_CotLieu_2 = value;
            }
        }
        public bool Op_RungPheuCan_CotLieu_3
        {
            get
            {
                return this._Op_RungPheuCan_CotLieu_3;
            }
            set
            {
                this._Op_RungPheuCan_CotLieu_3 = value;
            }
        }

        public bool Op_RungPheuCan_CotLieu_4
        {
            get
            {
                return this._Op_RungPheuCan_CotLieu_4;
            }
            set
            {
                this._Op_RungPheuCan_CotLieu_4 = value;
            }
        }

        public bool Op_RungPheuCan_CotLieu_5
        {
            get
            {
                return this._Op_RungPheuCan_CotLieu_5;
            }
            set
            {
                this._Op_RungPheuCan_CotLieu_5 = value;
            }
        }

        public bool Op_RungPheuCan_CotLieu_6
        {
            get
            {
                return this._Op_RungPheuCan_CotLieu_6;
            }
            set
            {
                this._Op_RungPheuCan_CotLieu_6 = value;
            }
        }

        public bool Op_VanSutKhi_Silo_1
        {
            get
            {
                return this._Op_VanSutKhi_Silo_1;
            }
            set
            {
                this._Op_VanSutKhi_Silo_1 = value;
            }
        }

        public bool Op_VanSutKhi_Silo_2
        {
            get
            {
                return this._Op_VanSutKhi_Silo_2;
            }
            set
            {
                this._Op_VanSutKhi_Silo_2 = value;
            }
        }

        public bool Op_VanSutKhi_Silo_3
        {
            get
            {
                return this._Op_VanSutKhi_Silo_3;
            }
            set
            {
                this._Op_VanSutKhi_Silo_3 = value;
            }
        }
        // BYTE 8
        public bool Op_VanSutKhi_Silo_4
        {
            get
            {
                return this._Op_VanSutKhi_Silo_4;
            }
            set
            {
                this._Op_VanSutKhi_Silo_4 = value;
            }
        }

        public bool Op_VanSutKhi_Silo_5
        {
            get
            {
                return this._Op_VanSutKhi_Silo_5;
            }
            set
            {
                this._Op_VanSutKhi_Silo_5 = value;
            }
        }
        public bool Temple
        {
            get
            {
                return this._Temple;
            }
            set
            {
                this._Temple = value;
            }
        }
        //BYTE 9
        public bool Op_RUNNING
        {
            get
            {
                return this._Op_RUNNING;
            }
            set
            {
                this._Op_RUNNING = value;
            }
        }
        public bool Op_SIMULATION
        {
            get
            {
                return this._Op_SIMULATION;
            }
            set
            {
                this._Op_SIMULATION = value;
            }
        }
        public bool Op_MIXER_FULL
        {
            get
            {
                return this._Op_MIXER_FULL;
            }
            set
            {
                this._Op_MIXER_FULL = value;
            }
        }
        public bool Op_TTC_AGG1
        {
            get
            {
                return this._Op_TTC_AGG1;
            }
            set
            {
                this._Op_TTC_AGG1 = value;
            }
        }
        public bool Op_TTC_AGG2
        {
            get
            {
                return this._Op_TTC_AGG2;
            }
            set
            {
                this._Op_TTC_AGG2 = value;
            }
        }
        public bool Op_TTC_AGG3
        {
            get
            {
                return this._Op_TTC_AGG3;
            }
            set
            {
                this._Op_TTC_AGG3 = value;
            }
        }
        public bool Op_TTC_AGG4
        {
            get
            {
                return this._Op_TTC_AGG4;
            }
            set
            {
                this._Op_TTC_AGG4 = value;
            }
        }
        public bool Op_TTC_AGG5
        {
            get
            {
                return this._Op_TTC_AGG5;
            }
            set
            {
                this._Op_TTC_AGG5 = value;
            }
        }
        public bool Op_TTC_AGG6
        {
            get
            {
                return this._Op_TTC_AGG6;
            }
            set
            {
                this._Op_TTC_AGG6 = value;
            }
        }
        public bool Op_TTC_SILO1
        {
            get
            {
                return this._Op_TTC_SILO1;
            }
            set
            {
                this._Op_TTC_SILO1 = value;
            }
        }
        public bool Op_TTC_SILO2
        {
            get
            {
                return this._Op_TTC_SILO2;
            }
            set
            {
                this._Op_TTC_SILO2 = value;
            }
        }
        public bool Op_TTC_SILO3
        {
            get
            {
                return this._Op_TTC_SILO3;
            }
            set
            {
                this._Op_TTC_SILO3 = value;
            }
        }
        public bool Op_TTC_SILO4
        {
            get
            {
                return this._Op_TTC_SILO4;
            }
            set
            {
                this._Op_TTC_SILO4 = value;
            }
        }
        public bool Op_TTC_SILO5
        {
            get
            {
                return this._Op_TTC_SILO5;
            }
            set
            {
                this._Op_TTC_SILO5 = value;
            }
        }
        public bool Op_TTC_WA1
        {
            get
            {
                return this._Op_TTC_WA1;
            }
            set
            {
                this._Op_TTC_WA1 = value;
            }
        }
        public bool Op_TTC_WA2
        {
            get
            {
                return this._Op_TTC_WA2;
            }
            set
            {
                this._Op_TTC_WA2 = value;
            }
        }
        public bool Op_TTC_ADD1
        {
            get
            {
                return this._Op_TTC_ADD1;
            }
            set
            {
                this._Op_TTC_ADD1 = value;
            }
        }
        public bool Op_TTC_ADD2
        {
            get
            {
                return this._Op_TTC_ADD2;
            }
            set
            {
                this._Op_TTC_ADD2 = value;
            }
        }
        public bool Op_TTC_ADD3
        {
            get
            {
                return this._Op_TTC_ADD3;
            }
            set
            {
                this._Op_TTC_ADD3 = value;
            }
        }
        public bool Op_TTC_ADD4
        {
            get
            {
                return this._Op_TTC_ADD4;
            }
            set
            {
                this._Op_TTC_ADD4 = value;
            }
        }
        public bool Op_TTC_ADD5
        {
            get
            {
                return this._Op_TTC_ADD5;
            }
            set
            {
                this._Op_TTC_ADD5 = value;
            }
        }
        public bool Op_TTC_ADD6
        {
            get
            {
                return this._Op_TTC_ADD6;
            }
            set
            {
                this._Op_TTC_ADD6 = value;
            }
        }
        public bool Op_THDC_WAGG1
        {
            get
            {
                return this._Op_THDC_WAGG1;
            }
            set
            {
                this._Op_THDC_WAGG1 = value;
            }
        }
        public bool Op_THDC_WAGG2
        {
            get
            {
                return this._Op_THDC_WAGG2;
            }
            set
            {
                this._Op_THDC_WAGG2 = value;
            }
        }
        public bool Op_THDC_WAGG3
        {
            get
            {
                return this._Op_THDC_WAGG3;
            }
            set
            {
                this._Op_THDC_WAGG3 = value;
            }
        }
        public bool Op_THDC_WAGG4
        {
            get
            {
                return this._Op_THDC_WAGG4;
            }
            set
            {
                this._Op_THDC_WAGG4 = value;
            }
        }
        public bool Op_THDC_WAGG5
        {
            get
            {
                return this._Op_THDC_WAGG5;
            }
            set
            {
                this._Op_THDC_WAGG5 = value;
            }
        }
        public bool Op_THDC_WAGG6
        {
            get
            {
                return this._Op_THDC_WAGG6;
            }
            set
            {
                this._Op_THDC_WAGG6 = value;
            }
        }
        public bool Op_THDC_WCE1
        {
            get
            {
                return this._Op_THDC_WCE1;
            }
            set
            {
                this._Op_THDC_WCE1 = value;
            }
        }
        public bool Op_THDC_WCE2
        {
            get
            {
                return this._Op_THDC_WCE2;
            }
            set
            {
                this._Op_THDC_WCE2 = value;
            }
        }
        public bool Op_THDC_WWA1
        {
            get
            {
                return this._Op_THDC_WWA1;
            }
            set
            {
                this._Op_THDC_WWA1 = value;
            }
        }
        public bool Op_THDC_WWA2
        {
            get
            {
                return this._Op_THDC_WWA2;
            }
            set
            {
                this._Op_THDC_WWA2 = value;
            }
        }
        public bool Op_THDC_WADD1
        {
            get
            {
                return this._Op_THDC_WADD1;
            }
            set
            {
                this._Op_THDC_WADD1 = value;
            }
        }
        public bool Op_THDC_WADD2
        {
            get
            {
                return this._Op_THDC_WADD2;
            }
            set
            {
                this._Op_THDC_WADD2 = value;
            }
        }
        public bool STT_MAN_AUT
        {
            get
            {
                return this._STT_MAN_AUT;
            }
            set
            {
                this._STT_MAN_AUT = value;
            }
        }
        public bool STT_PAUSE
        {
            get
            {
                return this._STT_PAUSE;
            }
            set
            {
                this._STT_PAUSE = value;
            }
        }
        public bool STT_CANCEL
        {
            get
            {
                return this._STT_CANCEL;
            }
            set
            {
                this._STT_CANCEL = value;
            }
        }

        //============================================================DB6 READCALIB WEIGHT

        public Double Xung_Agg_1
        {
            get
            {
                return this._Xung_Agg_1;
            }
            set
            {
                this._Xung_Agg_1 = value;
            }
        }

        public Double Xung_Agg_2
        {
            get
            {
                return this._Xung_Agg_2;
            }
            set
            {
                this._Xung_Agg_2 = value;
            }
        }

        public Double Xung_Agg_3
        {
            get
            {
                return this._Xung_Agg_3;
            }
            set
            {
                this._Xung_Agg_3 = value;
            }
        }

        public Double Xung_Agg_4
        {
            get
            {
                return this._Xung_Agg_4;
            }
            set
            {
                this._Xung_Agg_4 = value;
            }
        }

        public Double Xung_Agg_5
        {
            get
            {
                return this._Xung_Agg_5;
            }
            set
            {
                this._Xung_Agg_5 = value;
            }
        }

        public Double Xung_Agg_6
        {
            get
            {
                return this._Xung_Agg_6;
            }
            set
            {
                this._Xung_Agg_6 = value;
            }
        }

        public Double Xung_Cem_1
        {
            get
            {
                return this._Xung_Cem_1;
            }
            set
            {
                this._Xung_Cem_1 = value;
            }
        }

        public Double Xung_Cem_2
        {
            get
            {
                return this._Xung_Cem_2;
            }
            set
            {
                this._Xung_Cem_2 = value;
            }
        }

        public Double Xung_Wa_1
        {
            get
            {
                return this._Xung_Wa_1;
            }
            set
            {
                this._Xung_Wa_1 = value;
            }
        }

        public Double Xung_Wa_2
        {
            get
            {
                return this._Xung_Wa_2;
            }
            set
            {
                this._Xung_Wa_2 = value;
            }
        }

        public Double Xung_Add_1
        {
            get
            {
                return this._Xung_Add_1;
            }
            set
            {
                this._Xung_Add_1 = value;
            }
        }

        public Double Xung_Add_2
        {
            get
            {
                return this._Xung_Add_2;
            }
            set
            {
                this._Xung_Add_2 = value;
            }
        }

        public Double Zero_Agg1
        {
            get
            {
                return this._Zero_Agg1;
            }
            set
            {
                this._Zero_Agg1 = value;
            }
        }

        public Double Span_Agg1
        {
            get
            {
                return this._Span_Agg1;
            }
            set
            {
                this._Span_Agg1 = value;
            }
        }

        public Double Zero_Agg2
        {
            get
            {
                return this._Zero_Agg2;
            }
            set
            {
                this._Zero_Agg2 = value;
            }
        }

        public Double Span_Agg2
        {
            get
            {
                return this._Span_Agg2;
            }
            set
            {
                this._Span_Agg2 = value;
            }
        }

        public Double Zero_Agg3
        {
            get
            {
                return this._Zero_Agg3;
            }
            set
            {
                this._Zero_Agg3 = value;
            }
        }

        public Double Span_Agg3
        {
            get
            {
                return this._Span_Agg3;
            }
            set
            {
                this._Span_Agg3 = value;
            }
        }

        public Double Zero_Agg4
        {
            get
            {
                return this._Zero_Agg4;
            }
            set
            {
                this._Zero_Agg4 = value;
            }
        }

        public Double Span_Agg4
        {
            get
            {
                return this._Span_Agg4;
            }
            set
            {
                this._Span_Agg4 = value;
            }
        }

        public Double Zero_Agg5
        {
            get
            {
                return this._Zero_Agg5;
            }
            set
            {
                this._Zero_Agg5 = value;
            }
        }

        public Double Span_Agg5
        {
            get
            {
                return this._Span_Agg5;
            }
            set
            {
                this._Span_Agg5 = value;
            }
        }

        public Double Zero_Agg6
        {
            get
            {
                return this._Zero_Agg6;
            }
            set
            {
                this._Zero_Agg6 = value;
            }
        }

        public Double Span_Agg6
        {
            get
            {
                return this._Span_Agg6;
            }
            set
            {
                this._Span_Agg6 = value;
            }
        }

        public Double Zero_Ce1
        {
            get
            {
                return this._Zero_Ce1;
            }
            set
            {
                this._Zero_Ce1 = value;
            }
        }

        public Double Span_Ce1
        {
            get
            {
                return this._Span_Ce1;
            }
            set
            {
                this._Span_Ce1 = value;
            }
        }

        public Double Zero_Ce2
        {
            get
            {
                return this._Zero_Ce2;
            }
            set
            {
                this._Zero_Ce2 = value;
            }
        }

        public Double Span_Ce2
        {
            get
            {
                return this._Span_Ce2;
            }
            set
            {
                this._Span_Ce2 = value;
            }
        }

        public Double Zero_Wa1
        {
            get
            {
                return this._Zero_Wa1;
            }
            set
            {
                this._Zero_Wa1 = value;
            }
        }

        public Double Span_Wa1
        {
            get
            {
                return this._Span_Wa1;
            }
            set
            {
                this._Span_Wa1 = value;
            }
        }

        public Double Zero_Wa2
        {
            get
            {
                return this._Zero_Wa2;
            }
            set
            {
                this._Zero_Wa2 = value;
            }
        }
        
        public Double Span_Wa2
        {
            get
            {
                return this._Span_Wa2;
            }
            set
            {
                this._Span_Wa2 = value;
            }
        }

        public Double Zero_Add1
        {
            get
            {
                return this._Zero_Add1;
            }
            set
            {
                this._Zero_Add1 = value;
            }
        }

        public Double Span_Add1
        {
            get
            {
                return this._Span_Add1;
            }
            set
            {
                this._Span_Add1 = value;
            }
        }

        public Double Zero_Add2
        {
            get
            {
                return this._Zero_Add2;
            }
            set
            {
                this._Zero_Add2 = value;
            }
        }

        public Double Span_Add2
        {
            get
            {
                return this._Span_Add2;
            }
            set
            {
                this._Span_Add2 = value;
            }
        }

        public Double HS_Xung_PG1
        {
            get
            {
                return this._HS_Xung_PG1;
            }
            set
            {
                this._HS_Xung_PG1 = value;
            }
        }

        public Double HS_Xung_PG2
        {
            get
            {
                return this._HS_Xung_PG2;
            }
            set
            {
                this._HS_Xung_PG2 = value;
            }
        }

        public Double HS_Xung_PG3
        {
            get
            {
                return this._HS_Xung_PG3;
            }
            set
            {
                this._HS_Xung_PG3 = value;
            }
        }

        public Double HS_Xung_PG4
        {
            get
            {
                return this._HS_Xung_PG4;
            }
            set
            {
                this._HS_Xung_PG4 = value;
            }
        }

        public Double HS_Xung_PG5
        {
            get
            {
                return this._HS_Xung_PG5;
            }
            set
            {
                this._HS_Xung_PG5 = value;
            }
        }

        public Double HS_Xung_PG6
        {
            get
            {
                return this._HS_Xung_PG6;
            }
            set
            {
                this._HS_Xung_PG6 = value;
            }
        }

        public Double KL_Xung_PG1
        {
            get
            {
                return this._KL_Xung_PG1;
            }
            set
            {
                this._KL_Xung_PG1 = value;
            }
        }

        public Double KL_Xung_PG2
        {
            get
            {
                return this._KL_Xung_PG2;
            }
            set
            {
                this._KL_Xung_PG2 = value;
            }
        }

        public Double KL_Xung_PG3
        {
            get
            {
                return this._KL_Xung_PG3;
            }
            set
            {
                this._KL_Xung_PG3 = value;
            }
        }

        public Double KL_Xung_PG4
        {
            get
            {
                return this._KL_Xung_PG4;
            }
            set
            {
                this._KL_Xung_PG4 = value;
            }
        }

        public Double KL_Xung_PG5
        {
            get
            {
                return this._KL_Xung_PG5;
            }
            set
            {
                this._KL_Xung_PG5 = value;
            }
        }

        public Double KL_Xung_PG6
        {
            get
            {
                return this._KL_Xung_PG6;
            }
            set
            {
                this._KL_Xung_PG6 = value;
            }
        }
        public Double KLT_AGG1
        {
            get
            {
                return this._KLT_AGG1;
            }
            set
            {
                this._KLT_AGG1 = value;
            }
        }
        public Double KLT_AGG2
        {
            get
            {
                return this._KLT_AGG2;
            }
            set
            {
                this._KLT_AGG2 = value;
            }
        }
        public Double KLT_AGG3
        {
            get
            {
                return this._KLT_AGG3;
            }
            set
            {
                this._KLT_AGG3 = value;
            }
        }
        public Double KLT_AGG4
        {
            get
            {
                return this._KLT_AGG4;
            }
            set
            {
                this._KLT_AGG4 = value;
            }
        }
        public Double KLT_AGG5
        {
            get
            {
                return this._KLT_AGG5;
            }
            set
            {
                this._KLT_AGG5 = value;
            }
        }
        public Double KLT_AGG6
        {
            get
            {
                return this._KLT_AGG6;
            }
            set
            {
                this._KLT_AGG6 = value;
            }
        }
        public Double KLT_WCE1
        {
            get
            {
                return this._KLT_WCE1;
            }
            set
            {
                this._KLT_WCE1 = value;
            }
        }
        public Double KLT_WCE2
        {
            get
            {
                return this._KLT_WCE2;
            }
            set
            {
                this._KLT_WCE2 = value;
            }
        }
        public Double KLT_WA1
        {
            get
            {
                return this._KLT_WA1;
            }
            set
            {
                this._KLT_WA1 = value;
            }
        }
        public Double KLT_WA2
        {
            get
            {
                return this._KLT_WA2;
            }
            set
            {
                this._KLT_WA2 = value;
            }
        }
        public Double KLT_ADD1
        {
            get
            {
                return this._KLT_ADD1;
            }
            set
            {
                this._KLT_ADD1 = value;
            }
        }
        public Double KLT_ADD2
        {
            get
            {
                return this._KLT_ADD2;
            }
            set
            {
                this._KLT_ADD2 = value;
            }
        }

        public Double KLX_ADD1
        {
            get
            {
                return this._KLX_ADD1;
            }
            set
            {
                this._KLX_ADD1 = value;
            }
        }

        public Double KLX_ADD2
        {
            get
            {
                return this._KLX_ADD2;
            }
            set
            {
                this._KLX_ADD2 = value;
            }
        }

        public Double KLX_ADD3
        {
            get
            {
                return this._KLX_ADD3;
            }
            set
            {
                this._KLX_ADD3 = value;
            }
        }

        public Double KLX_ADD4
        {
            get
            {
                return this._KLX_ADD4;
            }
            set
            {
                this._KLX_ADD4 = value;
            }
        }

        public Double KLX_ADD5
        {
            get
            {
                return this._KLX_ADD5;
            }
            set
            {
                this._KLX_ADD5 = value;
            }
        }

        public Double KLX_ADD6
        {
            get
            {
                return this._KLX_ADD6;
            }
            set
            {
                this._KLX_ADD6 = value;
            }
        }


        //============================================================DB7 READ DATA
        //============================================AGG1
        public Double PV_AGG_1
        {
            get
            {
                return this._PV_AGG_1;
            }
            set
            {
                this._PV_AGG_1 = value;
            }
        }

        public Double Per_WAGG_1
        {
            get
            {
                return this._Per_WAGG_1;
            }
            set
            {
                this._Per_WAGG_1 = value;
            }
        }

        public Double WE_AGG_1
        {
            get
            {
                return this._WE_AGG_1;
            }
            set
            {
                this._WE_AGG_1 = value;
            }
        }

        public Double SMC_AGG_1
        {
            get
            {
                return this._SMC_AGG_1;
            }
            set
            {
                this._SMC_AGG_1 = value;
            }
        }

        public Double SMX_AGG_1
        {
            get
            {
                return this._SMX_AGG_1;
            }
            set
            {
                this._SMX_AGG_1 = value;
            }
        }
        //============================================AGG2
        public Double PV_AGG_2
        {
            get
            {
                return this._PV_AGG_2;
            }
            set
            {
                this._PV_AGG_2 = value;
            }
        }

        public Double Per_WAGG_2
        {
            get
            {
                return this._Per_WAGG_2;
            }
            set
            {
                this._Per_WAGG_2 = value;
            }
        }

        public Double WE_AGG_2
        {
            get
            {
                return this._WE_AGG_2;
            }
            set
            {
                this._WE_AGG_2 = value;
            }
        }

        public Double SMC_AGG_2
        {
            get
            {
                return this._SMC_AGG_2;
            }
            set
            {
                this._SMC_AGG_2 = value;
            }
        }

        public Double SMX_AGG_2
        {
            get
            {
                return this._SMX_AGG_2;
            }
            set
            {
                this._SMX_AGG_2 = value;
            }
        }
        //================================================AGG3
        public Double PV_AGG_3
        {
            get
            {
                return this._PV_AGG_3;
            }
            set
            {
                this._PV_AGG_3 = value;
            }
        }

        public Double Per_WAGG_3
        {
            get
            {
                return this._Per_WAGG_3;
            }
            set
            {
                this._Per_WAGG_3 = value;
            }
        }

        public Double WE_AGG_3
        {
            get
            {
                return this._WE_AGG_3;
            }
            set
            {
                this._WE_AGG_3 = value;
            }
        }

        public Double SMC_AGG_3
        {
            get
            {
                return this._SMC_AGG_3;
            }
            set
            {
                this._SMC_AGG_3 = value;
            }
        }

        public Double SMX_AGG_3
        {
            get
            {
                return this._SMX_AGG_3;
            }
            set
            {
                this._SMX_AGG_3 = value;
            }
        }
        //==========================================AGG4
        public Double PV_AGG_4
        {
            get
            {
                return this._PV_AGG_4;
            }
            set
            {
                this._PV_AGG_4 = value;
            }
        }

        public Double Per_WAGG_4
        {
            get
            {
                return this._Per_WAGG_4;
            }
            set
            {
                this._Per_WAGG_4 = value;
            }
        }

        public Double WE_AGG_4
        {
            get
            {
                return this._WE_AGG_4;
            }
            set
            {
                this._WE_AGG_4 = value;
            }
        }

        public Double SMC_AGG_4
        {
            get
            {
                return this._SMC_AGG_4;
            }
            set
            {
                this._SMC_AGG_4 = value;
            }
        }

        public Double SMX_AGG_4
        {
            get
            {
                return this._SMX_AGG_4;
            }
            set
            {
                this._SMX_AGG_4 = value;
            }
        }
        //===========================================AGG5
        public Double PV_AGG_5
        {
            get
            {
                return this._PV_AGG_5;
            }
            set
            {
                this._PV_AGG_5 = value;
            }
        }

        public Double Per_WAGG_5
        {
            get
            {
                return this._Per_WAGG_5;
            }
            set
            {
                this._Per_WAGG_5 = value;
            }
        }

        public Double WE_AGG_5
        {
            get
            {
                return this._WE_AGG_5;
            }
            set
            {
                this._WE_AGG_5 = value;
            }
        }

        public Double SMC_AGG_5
        {
            get
            {
                return this._SMC_AGG_5;
            }
            set
            {
                this._SMC_AGG_5 = value;
            }
        }

        public Double SMX_AGG_5
        {
            get
            {
                return this._SMX_AGG_5;
            }
            set
            {
                this._SMX_AGG_5 = value;
            }
        }
        //==============================================AGG6
        public Double PV_AGG_6
        {
            get
            {
                return this._PV_AGG_6;
            }
            set
            {
                this._PV_AGG_6 = value;
            }
        }

        public Double Per_WAGG_6
        {
            get
            {
                return this._Per_WAGG_6;
            }
            set
            {
                this._Per_WAGG_6 = value;
            }
        }

        public Double WE_AGG_6
        {
            get
            {
                return this._WE_AGG_6;
            }
            set
            {
                this._WE_AGG_6 = value;
            }
        }

        public Double SMC_AGG_6
        {
            get
            {
                return this._SMC_AGG_6;
            }
            set
            {
                this._SMC_AGG_6 = value;
            }
        }

        public Double SMX_AGG_6
        {
            get
            {
                return this._SMX_AGG_6;
            }
            set
            {
                this._SMX_AGG_6 = value;
            }
        }
        //=============================================SILO
        public Double PV_SILO_1
        {
            get
            {
                return this._PV_SILO_1;
            }
            set
            {
                this._PV_SILO_1 = value;
            }
        }

        public Double PV_SILO_2
        {
            get
            {
                return this._PV_SILO_2;
            }
            set
            {
                this._PV_SILO_2 = value;
            }
        }

        public Double PV_SILO_3
        {
            get
            {
                return this._PV_SILO_3;
            }
            set
            {
                this._PV_SILO_3 = value;
            }
        }

        public Double Per_WCEM_1
        {
            get
            {
                return this._Per_WCEM_1;
            }
            set
            {
                this._Per_WCEM_1 = value;
            }
        }

        public Double WE_CEM_1
        {
            get
            {
                return this._WE_CEM_1;
            }
            set
            {
                this._WE_CEM_1 = value;
            }
        }

        public Double SMC_CEM_1
        {
            get
            {
                return this._SMC_CEM_1;
            }
            set
            {
                this._SMC_CEM_1 = value;
            }
        }

        public Double SMX_CEM_1
        {
            get
            {
                return this._SMX_CEM_1;
            }
            set
            {
                this._SMX_CEM_1 = value;
            }
        }

        public Double PV_SILO_4
        {
            get
            {
                return this._PV_SILO_4;
            }
            set
            {
                this._PV_SILO_4 = value;
            }
        }

        public Double PV_SILO_5
        {
            get
            {
                return this._PV_SILO_5;
            }
            set
            {
                this._PV_SILO_5 = value;
            }
        }

        public Double Per_WCEM_2
        {
            get
            {
                return this._Per_WCEM_2;
            }
            set
            {
                this._Per_WCEM_2 = value;
            }
        }

        public Double WE_CEM_2
        {
            get
            {
                return this._WE_CEM_2;
            }
            set
            {
                this._WE_CEM_2 = value;
            }
        }

        public Double SMC_CEM_2
        {
            get
            {
                return this._SMC_CEM_2;
            }
            set
            {
                this._SMC_CEM_2 = value;
            }
        }

        public Double SMX_CEM_2
        {
            get
            {
                return this._SMX_CEM_2;
            }
            set
            {
                this._SMX_CEM_2 = value;
            }
        }
        //===================================================WA1
        public Double PV_WA_1
        {
            get
            {
                return this._PV_WA_1;
            }
            set
            {
                this._PV_WA_1 = value;
            }
        }

        public Double Per_WWA_1
        {
            get
            {
                return this._Per_WWA_1;
            }
            set
            {
                this._Per_WWA_1 = value;
            }
        }

        public Double WE_WA_1
        {
            get
            {
                return this._WE_WA_1;
            }
            set
            {
                this._WE_WA_1 = value;
            }
        }

        public Double SMC_WA_1
        {
            get
            {
                return this._SMC_WA_1;
            }
            set
            {
                this._SMC_WA_1 = value;
            }
        }

        public Double SMX_WA_1
        {
            get
            {
                return this._SMX_WA_1;
            }
            set
            {
                this._SMX_WA_1 = value;
            }
        }

        //===================================================WA2
        public Double PV_WA_2
        {
            get
            {
                return this._PV_WA_2;
            }
            set
            {
                this._PV_WA_2 = value;
            }
        }

        public Double Per_WWA_2
        {
            get
            {
                return this._Per_WWA_2;
            }
            set
            {
                this._Per_WWA_2 = value;
            }
        }

        public Double WE_WA_2
        {
            get
            {
                return this._WE_WA_2;
            }
            set
            {
                this._WE_WA_2 = value;
            }
        }

        public Double SMC_WA_2
        {
            get
            {
                return this._SMC_WA_2;
            }
            set
            {
                this._SMC_WA_2 = value;
            }
        }

        public Double SMX_WA_2
        {
            get
            {
                return this._SMX_WA_2;
            }
            set
            {
                this._SMX_WA_2 = value;
            }
        }
        //=========================================ADD
        public Double PV_ADD_1
        {
            get
            {
                return this._PV_ADD_1;
            }
            set
            {
                this._PV_ADD_1 = value;
            }
        }

        public Double PV_ADD_2
        {
            get
            {
                return this._PV_ADD_2;
            }
            set
            {
                this._PV_ADD_2 = value;
            }
        }

        public Double PV_ADD_3
        {
            get
            {
                return this._PV_ADD_3;
            }
            set
            {
                this._PV_ADD_3 = value;
            }
        }

        public Double Per_WADD_1
        {
            get
            {
                return this._Per_WADD_1;
            }
            set
            {
                this._Per_WADD_1 = value;
            }
        }

        public Double WE_ADD_1
        {
            get
            {
                return this._WE_ADD_1;
            }
            set
            {
                this._WE_ADD_1 = value;
            }
        }

        public Double SMC_ADD_1
        {
            get
            {
                return this._SMC_ADD_1;
            }
            set
            {
                this._SMC_ADD_1 = value;
            }
        }

        public Double SMX_ADD_1
        {
            get
            {
                return this._SMX_ADD_1;
            }
            set
            {
                this._SMX_ADD_1 = value;
            }
        }

        public Double PV_ADD_4
        {
            get
            {
                return this._PV_ADD_4;
            }
            set
            {
                this._PV_ADD_4 = value;
            }
        }

        public Double PV_ADD_5
        {
            get
            {
                return this._PV_ADD_5;
            }
            set
            {
                this._PV_ADD_5 = value;
            }
        }

        public Double PV_ADD_6
        {
            get
            {
                return this._PV_ADD_6;
            }
            set
            {
                this._PV_ADD_6 = value;
            }
        }

        public Double Per_WADD_2
        {
            get
            {
                return this._Per_WADD_2;
            }
            set
            {
                this._Per_WADD_2 = value;
            }
        }

        public Double WE_ADD_2
        {
            get
            {
                return this._WE_ADD_2;
            }
            set
            {
                this._WE_ADD_2 = value;
            }
        }

        public Double SMC_ADD_2
        {
            get
            {
                return this._SMC_ADD_2;
            }
            set
            {
                this._SMC_ADD_2 = value;
            }
        }

        public Double SMX_ADD_2
        {
            get
            {
                return this._SMX_ADD_2;
            }
            set
            {
                this._SMX_ADD_2 = value;
            }
        }

        public Double SMC_SKIP
        {
            get
            {
                return this._SMC_SKIP;
            }
            set
            {
                this._SMC_SKIP = value;
            }
        }

        public Double SMX_SKIP
        {
            get
            {
                return this._SMX_SKIP;
            }
            set
            {
                this._SMX_SKIP = value;
            }
        }

        public Double SMC_PTG
        {
            get
            {
                return this._SMC_PTG;
            }
            set
            {
                this._SMC_PTG = value;
            }
        }

        public Double SMX_PTG
        {
            get
            {
                return this._SMX_PTG;
            }
            set
            {
                this._SMX_PTG = value;
            }
        }

        public Double SMC_MIXER
        {
            get
            {
                return this._SMC_MIXER;
            }
            set
            {
                this._SMC_MIXER = value;
            }
        }

        public Double SMX_MIXER
        {
            get
            {
                return this._SMX_MIXER;
            }
            set
            {
                this._SMX_MIXER = value;
            }
        }
        public Double ThoiGianThucTron
        {
            get
            {
                return this._ThoiGianThucTron;
            }
            set
            {
                this._ThoiGianThucTron = value;
            }
        }
        public Double ThoiGianThucXa
        {
            get
            {
                return this._ThoiGianThucXa;
            }
            set
            {
                this._ThoiGianThucXa = value;
            }
        }

        public Double PheuChoStatus
        {
            get
            {
                return this._PheuChoStatus;
            }
            set
            {
                this._PheuChoStatus = value;
            }
        }

        //================================================================DB8

        public Double RE_PV_AGG1
        {
            get
            {
                return this._RE_PV_AGG1;
            }
            set
            {
                this._RE_PV_AGG1 = value;
            }
        }

        public Double RE_PVM_AGG1
        {
            get
            {
                return this._RE_PVM_AGG1;
            }
            set
            {
                this._RE_PVM_AGG1 = value;
            }
        }
        public Double RE_PV_AGG2
        {
            get
            {
                return this._RE_PV_AGG2;
            }
            set
            {
                this._RE_PV_AGG2 = value;
            }
        }
        public Double RE_PVM_AGG2
        {
            get
            {
                return this._RE_PVM_AGG2;
            }
            set
            {
                this._RE_PVM_AGG2 = value;
            }
        }
        public Double RE_PV_AGG3
        {
            get
            {
                return this._RE_PV_AGG3;
            }
            set
            {
                this._RE_PV_AGG3 = value;
            }
        }
        public Double RE_PVM_AGG3
        {
            get
            {
                return this._RE_PVM_AGG3;
            }
            set
            {
                this._RE_PVM_AGG3 = value;
            }
        }
        public Double RE_PV_AGG4
        {
            get
            {
                return this._RE_PV_AGG4;
            }
            set
            {
                this._RE_PV_AGG4 = value;
            }
        }
        public Double RE_PVM_AGG4
        {
            get
            {
                return this._RE_PVM_AGG4;
            }
            set
            {
                this._RE_PVM_AGG4 = value;
            }
        }
        public Double RE_PV_AGG5
        {
            get
            {
                return this._RE_PV_AGG5;
            }
            set
            {
                this._RE_PV_AGG5 = value;
            }
        }
        public Double RE_PVM_AGG5
        {
            get
            {
                return this._RE_PVM_AGG5;
            }
            set
            {
                this._RE_PVM_AGG5 = value;
            }
        }

        public Double RE_PV_AGG6
        {
            get
            {
                return this._RE_PV_AGG6;
            }
            set
            {
                this._RE_PV_AGG6 = value;
            }
        }

        public Double RE_PVM_AGG6
        {
            get
            {
                return this._RE_PVM_AGG6;
            }
            set
            {
                this._RE_PVM_AGG6 = value;
            }
        }
        //============================================CE

        public Double RE_PV_CE1
        {
            get
            {
                return this._RE_PV_CE1;
            }
            set
            {
                this._RE_PV_CE1 = value;
            }
        }

        public Double RE_PVM_CE1
        {
            get
            {
                return this._RE_PVM_CE1;
            }
            set
            {
                this._RE_PVM_CE1 = value;
            }
        }

        public Double RE_PV_CE2
        {
            get
            {
                return this._RE_PV_CE2;
            }
            set
            {
                this._RE_PV_CE2 = value;
            }
        }

        public Double RE_PVM_CE2
        {
            get
            {
                return this._RE_PVM_CE2;
            }
            set
            {
                this._RE_PVM_CE2 = value;
            }
        }

        public Double RE_PV_CE3
        {
            get
            {
                return this._RE_PV_CE3;
            }
            set
            {
                this._RE_PV_CE3 = value;
            }
        }

        public Double RE_PVM_CE3
        {
            get
            {
                return this._RE_PVM_CE3;
            }
            set
            {
                this._RE_PVM_CE3 = value;
            }
        }

        public Double RE_PV_CE4
        {
            get
            {
                return this._RE_PV_CE4;
            }
            set
            {
                this._RE_PV_CE4 = value;
            }
        }

        public Double RE_PVM_CE4
        {
            get
            {
                return this._RE_PVM_CE4;
            }
            set
            {
                this._RE_PVM_CE4 = value;
            }
        }

        public Double RE_PV_CE5
        {
            get
            {
                return this._RE_PV_CE5;
            }
            set
            {
                this._RE_PV_CE5 = value;
            }
        }

        public Double RE_PVM_CE5
        {
            get
            {
                return this._RE_PVM_CE5;
            }
            set
            {
                this._RE_PVM_CE5 = value;
            }
        }
        //=============================================WA

        public Double RE_PV_WA1
        {
            get
            {
                return this._RE_PV_WA1;
            }
            set
            {
                this._RE_PV_WA1 = value;
            }
        }

        public Double RE_PVM_WA1
        {
            get
            {
                return this._RE_PVM_WA1;
            }
            set
            {
                this._RE_PVM_WA1 = value;
            }
        }

        public Double RE_PV_WA2
        {
            get
            {
                return this._RE_PV_WA2;
            }
            set
            {
                this._RE_PV_WA2 = value;
            }
        }

        public Double RE_PVM_WA2
        {
            get
            {
                return this._RE_PVM_WA2;
            }
            set
            {
                this._RE_PVM_WA2 = value;
            }
        }
        //=========================================ADD
        public Double RE_PV_PG1
        {
            get
            {
                return this._RE_PV_PG1;
            }
            set
            {
                this._RE_PV_PG1 = value;
            }
        }

        public Double RE_PVM_PG1
        {
            get
            {
                return this._RE_PVM_PG1;
            }
            set
            {
                this._RE_PVM_PG1 = value;
            }
        }

        public Double RE_PV_PG2
        {
            get
            {
                return this._RE_PV_PG2;
            }
            set
            {
                this._RE_PV_PG2 = value;
            }
        }

        public Double RE_PVM_PG2
        {
            get
            {
                return this._RE_PVM_PG2;
            }
            set
            {
                this._RE_PVM_PG2 = value;
            }
        }

        public Double RE_PV_PG3
        {
            get
            {
                return this._RE_PV_PG3;
            }
            set
            {
                this._RE_PV_PG3 = value;
            }
        }

        public Double RE_PVM_PG3
        {
            get
            {
                return this._RE_PVM_PG3;
            }
            set
            {
                this._RE_PVM_PG3 = value;
            }
        }

        public Double RE_PV_PG4
        {
            get
            {
                return this._RE_PV_PG4;
            }
            set
            {
                this._RE_PV_PG4 = value;
            }
        }

        public Double RE_PVM_PG4
        {
            get
            {
                return this._RE_PVM_PG4;
            }
            set
            {
                this._RE_PVM_PG4 = value;
            }
        }

        public Double RE_PV_PG5
        {
            get
            {
                return this._RE_PV_PG5;
            }
            set
            {
                this._RE_PV_PG5 = value;
            }
        }

        public Double RE_PVM_PG5
        {
            get
            {
                return this._RE_PVM_PG5;
            }
            set
            {
                this._RE_PVM_PG5 = value;
            }
        }

        public Double RE_PV_PG6
        {
            get
            {
                return this._RE_PV_PG6;
            }
            set
            {
                this._RE_PV_PG6 = value;
            }
        }

        public Double RE_PVM_PG6
        {
            get
            {
                return this._RE_PVM_PG6;
            }
            set
            {
                this._RE_PVM_PG6 = value;
            }
        }


        //==== Read Bit DB1 DATA
        public byte StatusIO_00
        {
            set
            {
                this._statusIO_00 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_00);
                Op_TinHieu_NoiTron = bitArray[0];
                Op_TinHieu_BangTaiXien = bitArray[1];
                Op_TinHieu_BangTaiCan = bitArray[2];
                Op_TinHieu_GauLen = bitArray[3];
                Op_TinHieu_GauXuong = bitArray[4];
                Op_TinHieu_GauTren = bitArray[5];
                Op_TinHieu_GauCho = bitArray[6];
                Op_TinHieu_GauDuoi = bitArray[7];
            }
        }


        public byte StatusIO_01
        {
            set
            {
                this._statusIO_01 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_01);
                Op_TinHieu_GauAnToan = bitArray[0];
                Op_TinHieu_CuaNoiDong = bitArray[1];
                Op_TinHieu_CuaNoi_1p2 = bitArray[2];
                Op_TinHieu_CuaNoiMo = bitArray[3];
                Op_TinHieu_PheuChoDong = bitArray[4];
                Op_TinHieu_PheuChoMo = bitArray[5];
                Op_Van_MoCuaNoi = bitArray[6];
                Op_Van_DongCuaNoi = bitArray[7];
            }
        }

        public byte StatusIO_02
        {
            set
            {
                this._statusIO_02 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_02);
                Op_Van_XaPheuCho = bitArray[0];
                Op_VanCan_XiMang_1 = bitArray[1];
                Op_VanCan_XiMang_2 = bitArray[2];
                Op_VanCan_XiMang_3 = bitArray[3];
                Op_VanXa_PheuCan_XiMang_1 = bitArray[4];
                Op_VanCan_XiMang_4 = bitArray[5];
                Op_VanCan_XiMang_5 = bitArray[6];
                Op_VanXa_PheuCan_XiMang_2 = bitArray[7];
            }
        }
        public byte StatusIO_03
        {
            set
            {
                this._statusIO_03 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_03);
                Op_VanCan_Nuoc_1 = bitArray[0];
                Op_VanXa_PheuCan_Nuoc_1 = bitArray[1];
                Op_VanCan_Nuoc_2 = bitArray[2];
                Op_VanXa_PheuCan_Nuoc_2 = bitArray[3];
                Op_VanCan_PhuGia_1 = bitArray[4];
                Op_VanCan_PhuGia_2 = bitArray[5];
                Op_VanCan_PhuGia_3 = bitArray[6];
                Op_VanXa_PheuCan_PhuGia_1 = bitArray[7];
            }
        }
        public byte StatusIO_04
        {
            set
            {
                this._statusIO_04 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_04);
                Op_VanCan_PhuGia_4 = bitArray[0];
                Op_VanCan_PhuGia_5 = bitArray[1];
                Op_VanCan_PhuGia_6 = bitArray[2];
                Op_VanXa_PheuCan_PhuGia_2 = bitArray[3];
                Op_VanCan_Agg_1_1 = bitArray[4];
                Op_VanCan_Agg_1_2 = bitArray[5];
                Op_VanXa_PheuCan_Agg_1 = bitArray[6];
                Op_VanCan_Agg_2_1 = bitArray[7];
            }
        }
        public byte StatusIO_05
        {
            set
            {
                this._statusIO_05 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_05);
                Op_VanCan_Agg_2_2 = bitArray[0];
                Op_VanXa_PheuCan_Agg_2 = bitArray[1];
                Op_VanCan_Agg_3_1 = bitArray[2];
                Op_VanCan_Agg_3_2 = bitArray[3];
                Op_VanXa_PheuCan_Agg_3 = bitArray[4];
                Op_VanCan_Agg_4_1 = bitArray[5];
                Op_VanCan_Agg_4_2 = bitArray[6];
                Op_VanXa_PheuCan_Agg_4 = bitArray[7];
            }
        }
        public byte StatusIO_06
        {
            set
            {
                this._statusIO_06 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_06);
                Op_VanCan_Agg_5_1 = bitArray[0];
                Op_VanCan_Agg_5_2 = bitArray[1];
                _Op_VanXa_PheuCan_Agg_5 = bitArray[2];
                Op_VanCan_Agg_6_1 = bitArray[3];
                Op_VanCan_Agg_6_2 = bitArray[4];
                Op_VanXa_PheuCan_Agg_6 = bitArray[5];
                Op_RungPheuCho = bitArray[6];
                Op_RungPheuCan_XiMang_1 = bitArray[7];
            }
        }
        public byte StatusIO_07
        {
            set
            {
                this._statusIO_07 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_07);
                Op_RungPheuCan_XiMang_2 = bitArray[0];
                Op_RungPheuCan_CotLieu_3 = bitArray[1];
                Op_RungPheuCan_CotLieu_4 = bitArray[2];
                Op_RungPheuCan_CotLieu_5 = bitArray[3];
                Op_RungPheuCan_CotLieu_6 = bitArray[4];
                Op_VanSutKhi_Silo_1 = bitArray[5];
                Op_VanSutKhi_Silo_2 = bitArray[6];
                Op_VanSutKhi_Silo_3 = bitArray[7];
            }
        }
        public byte StatusIO_08
        {
            set
            {
                this._statusIO_08 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_08);
                Op_VanSutKhi_Silo_4 = bitArray[0];
                Op_VanSutKhi_Silo_5 = bitArray[1];
                Op_RungPheuCan_CotLieu_1 = bitArray[2];
                Op_RungPheuCan_CotLieu_2 = bitArray[3];
                Temple = bitArray[4];
                Temple = bitArray[5];
                Temple = bitArray[6];
                Op_RUNNING = bitArray[7];
            }
        }

        public byte StatusIO_09
        {
            set
            {
                this._statusIO_09 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_09);
                Op_SIMULATION = bitArray[0];
                Op_MIXER_FULL = bitArray[1];
                Op_TTC_AGG1 = bitArray[2];
                Op_TTC_AGG2 = bitArray[3];
                Op_TTC_AGG3 = bitArray[4];
                Op_TTC_AGG4 = bitArray[5];
                Op_TTC_AGG5 = bitArray[6];
                Op_TTC_AGG6 = bitArray[7];
            }
        }
        public byte StatusIO_10
        {
            set
            {
                this._statusIO_10 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_10);
                Op_TTC_SILO1 = bitArray[0];
                Op_TTC_SILO2 = bitArray[1];
                Op_TTC_SILO3 = bitArray[2];
                Op_TTC_SILO4 = bitArray[3];
                Op_TTC_SILO5 = bitArray[4];
                Op_TTC_WA1 = bitArray[5];
                Op_TTC_WA2 = bitArray[6];
                Op_TTC_ADD1 = bitArray[7];
            }
        }
        public byte StatusIO_11
        {
            set
            {
                this._statusIO_11 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_11);
                Op_TTC_ADD2 = bitArray[0];
                Op_TTC_ADD3 = bitArray[1];
                Op_TTC_ADD4 = bitArray[2];
                Op_TTC_ADD5 = bitArray[3];
                Op_TTC_ADD6 = bitArray[4];
                Op_THDC_WAGG1 = bitArray[5];
                Op_THDC_WAGG2 = bitArray[6];
                Op_THDC_WAGG3 = bitArray[7];
            }
        }

        public byte StatusIO_12
        {
            set
            {
                this._statusIO_12 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_12);
                Op_THDC_WAGG4 = bitArray[0];
                Op_THDC_WAGG5 = bitArray[1];
                Op_THDC_WAGG6 = bitArray[2];
                Op_THDC_WCE1 = bitArray[3];
                Op_THDC_WCE2 = bitArray[4];
                Op_THDC_WWA1 = bitArray[5];
                Op_THDC_WWA2 = bitArray[6];
                Op_THDC_WADD1 = bitArray[7];
            }
        }
        public byte StatusIO_13
        {
            set
            {
                this._statusIO_13 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_13);
                Op_THDC_WADD2 = bitArray[0];
                STT_MAN_AUT = bitArray[1];
                STT_PAUSE = bitArray[2];
                STT_CANCEL = bitArray[3];
                Temple = bitArray[4];
                Temple = bitArray[5];
                Temple = bitArray[6];
                Temple = bitArray[7];
            }
        }
        public byte StatusIO_14
        {
            set
            {
                this._statusIO_14 = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_14);
                Temple = bitArray[0];
                Temple = bitArray[1];
                Temple = bitArray[2];
                Temple = bitArray[3];
                Temple = bitArray[4];
                Temple = bitArray[5];
                Temple = bitArray[6];
                Temple = bitArray[7];
            }
        }

        public byte StatusIO_SAVE
        {
            set
            {
                this._statusIO_SAVE = value;
                BitArray bitArray = Converter.ConvertByteToBitArray(this._statusIO_SAVE);
                Save_Report = bitArray[0];
                Temple = bitArray[1];
                Temple = bitArray[2];
                Temple = bitArray[3];
                Temple = bitArray[4];
                Temple = bitArray[5];
                Temple = bitArray[6];
                Temple = bitArray[7];
            }
        }
    }
}

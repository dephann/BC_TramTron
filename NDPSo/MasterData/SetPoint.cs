using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class SetPoint
    {
        public int PhieuTronID { get; set; }

        public string MaPhieuTron { get; set; }

        public bool CanUpdateWhenRunning { get; set; }


        public Decimal DoAm_Agg1 { get; set; }

        public Decimal DoHut_Agg1 { get; set; }

        public Decimal DoAm_Agg2 { get; set; }

        public Decimal DoHut_Agg2 { get; set; }

        public Decimal DoAm_Agg3 { get; set; }

        public Decimal DoHut_Agg3 { get; set; }

        public Decimal DoAm_Agg4 { get; set; }

        public Decimal DoHut_Agg4 { get; set; }

        public Decimal DoAm_Agg5 { get; set; }

        public Decimal DoHut_Agg5 { get; set; }

        public Decimal DoAm_Agg6 { get; set; }

        public Decimal DoHut_Agg6 { get; set; }

        public Decimal ThemBotNuoc { get; set; }

        //================================================= DB3 WRITE DATA SILO

        public Double SaiSoTren_Agg1 { get; set; } //0
        public Double SaiSoDuoi_Agg1 { get; set; } //4
        public Double RoiTuDo_Agg1 { get; set; } //8
        public Double ThoiGianMoCan_Agg1 { get; set; } //12
        public Double ThoiGianDongCan_Agg1 { get; set; } //16
        public Double ThoiGianTinhLuongRoiThem_Agg1 { get; set; } //20
        public Double SaiSoTren_Agg2 { get; set; } //24
        public Double SaiSoDuoi_Agg2 { get; set; } //28
        public Double RoiTuDo_Agg2 { get; set; } //32
        public Double ThoiGianMoCan_Agg2 { get; set; } //36
        public Double ThoiGianDongCan_Agg2 { get; set; } //40
        public Double ThoiGianTinhLuongRoiThem_Agg2 { get; set; } //44
        public Double SaiSoTren_Agg3 { get; set; } //48
        public Double SaiSoDuoi_Agg3 { get; set; } //52
        public Double RoiTuDo_Agg3 { get; set; } //56
        public Double ThoiGianMoCan_Agg3 { get; set; } //60
        public Double ThoiGianDongCan_Agg3 { get; set; } //64
        public Double ThoiGianTinhLuongRoiThem_Agg3 { get; set; } //68
        public Double SaiSoTren_Agg4 { get; set; } //72
        public Double SaiSoDuoi_Agg4 { get; set; } //76
        public Double RoiTuDo_Agg4 { get; set; } //80
        public Double ThoiGianMoCan_Agg4 { get; set; } //84
        public Double ThoiGianDongCan_Agg4 { get; set; } //88
        public Double ThoiGianTinhLuongRoiThem_Agg4 { get; set; } //92
        public Double SaiSoTren_Agg5 { get; set; } //96
        public Double SaiSoDuoi_Agg5 { get; set; } //100
        public Double RoiTuDo_Agg5 { get; set; } //104
        public Double ThoiGianMoCan_Agg5 { get; set; } //108
        public Double ThoiGianDongCan_Agg5 { get; set; } //112
        public Double ThoiGianTinhLuongRoiThem_Agg5 { get; set; } //116
        public Double SaiSoTren_Agg6 { get; set; } //120
        public Double SaiSoDuoi_Agg6 { get; set; } //124
        public Double RoiTuDo_Agg6 { get; set; } //128
        public Double ThoiGianMoCan_Agg6 { get; set; } //132
        public Double ThoiGianDongCan_Agg6 { get; set; } //136
        public Double ThoiGianTinhLuongRoiThem_Agg6 { get; set; } //140
        public Double SaiSoTren_Ce1 { get; set; } //144
        public Double SaiSoDuoi_Ce1 { get; set; } //148
        public Double RoiTuDo_Ce1 { get; set; } //152
        public Double ThoiGianMoCan_Ce1 { get; set; } //156
        public Double ThoiGianDongCan_Ce1 { get; set; } //160
        public Double ThoiGianTinhLuongRoiThem_Ce1 { get; set; } //164
        public Double SaiSoTren_Ce2 { get; set; } //168
        public Double SaiSoDuoi_Ce2 { get; set; } //172
        public Double RoiTuDo_Ce2 { get; set; } //176
        public Double ThoiGianMoCan_Ce2 { get; set; } //180
        public Double ThoiGianDongCan_Ce2 { get; set; } //184
        public Double ThoiGianTinhLuongRoiThem_Ce2 { get; set; } //188
        public Double SaiSoTren_Ce3 { get; set; } //192
        public Double SaiSoDuoi_Ce3 { get; set; } //196
        public Double RoiTuDo_Ce3 { get; set; } //200
        public Double ThoiGianMoCan_Ce3 { get; set; } //204
        public Double ThoiGianDongCan_Ce3 { get; set; } //208
        public Double ThoiGianTinhLuongRoiThem_Ce3 { get; set; } //212
        public Double SaiSoTren_Ce4 { get; set; } //216
        public Double SaiSoDuoi_Ce4 { get; set; } //220
        public Double RoiTuDo_Ce4 { get; set; } //224
        public Double ThoiGianMoCan_Ce4 { get; set; } //228
        public Double ThoiGianDongCan_Ce4 { get; set; } //232
        public Double ThoiGianTinhLuongRoiThem_Ce4 { get; set; } //236
        public Double SaiSoTren_Ce5 { get; set; } //240
        public Double SaiSoDuoi_Ce5 { get; set; } //244
        public Double RoiTuDo_Ce5 { get; set; } //248
        public Double ThoiGianMoCan_Ce5 { get; set; } //252
        public Double ThoiGianDongCan_Ce5 { get; set; } //256
        public Double ThoiGianTinhLuongRoiThem_Ce5 { get; set; } //260
        public Double SaiSoTren_Wa1 { get; set; } //264
        public Double SaiSoDuoi_Wa1 { get; set; } //268
        public Double RoiTuDo_Wa1 { get; set; } //272
        public Double ThoiGianMoCan_Wa1 { get; set; } //276
        public Double ThoiGianDongCan_Wa1 { get; set; } //280
        public Double ThoiGianTinhLuongRoiThem_Wa1 { get; set; } //284
        public Double SaiSoTren_Wa2 { get; set; } //288
        public Double SaiSoDuoi_Wa2 { get; set; } //292
        public Double RoiTuDo_Wa2 { get; set; } //296
        public Double ThoiGianMoCan_Wa2 { get; set; } //300
        public Double ThoiGianDongCan_Wa2 { get; set; } //304
        public Double ThoiGianTinhLuongRoiThem_Wa2 { get; set; } //308
        public Double SaiSoTren_Add1 { get; set; } //312
        public Double SaiSoDuoi_Add1 { get; set; } //316
        public Double RoiTuDo_Add1 { get; set; } //320
        public Double ThoiGianMoCan_Add1 { get; set; } //324
        public Double ThoiGianDongCan_Add1 { get; set; } //328
        public Double ThoiGianTinhLuongRoiThem_Add1 { get; set; } //332
        public Double SaiSoTren_Add2 { get; set; } //336
        public Double SaiSoDuoi_Add2 { get; set; } //340
        public Double RoiTuDo_Add2 { get; set; } //344
        public Double ThoiGianMoCan_Add2 { get; set; } //348
        public Double ThoiGianDongCan_Add2 { get; set; } //352
        public Double ThoiGianTinhLuongRoiThem_Add2 { get; set; } //356
        public Double SaiSoTren_Add3 { get; set; } //360
        public Double SaiSoDuoi_Add3 { get; set; } //364
        public Double RoiTuDo_Add3 { get; set; } //368
        public Double ThoiGianMoCan_Add3 { get; set; } //372
        public Double ThoiGianDongCan_Add3 { get; set; } //276
        public Double ThoiGianTinhLuongRoiThem_Add3 { get; set; } //380
        public Double SaiSoTren_Add4 { get; set; } //384
        public Double SaiSoDuoi_Add4 { get; set; } //388
        public Double RoiTuDo_Add4 { get; set; } //392
        public Double ThoiGianMoCan_Add4 { get; set; } //396
        public Double ThoiGianDongCan_Add4 { get; set; } //400
        public Double ThoiGianTinhLuongRoiThem_Add4 { get; set; } //404
        public Double SaiSoTren_Add5 { get; set; } //408
        public Double SaiSoDuoi_Add5 { get; set; } //412
        public Double RoiTuDo_Add5 { get; set; } //416
        public Double ThoiGianMoCan_Add5 { get; set; } //420
        public Double ThoiGianDongCan_Add5 { get; set; } //424
        public Double ThoiGianTinhLuongRoiThem_Add5 { get; set; } //428
        public Double SaiSoTren_Add6 { get; set; } //432
        public Double SaiSoDuoi_Add6 { get; set; } //436
        public Double RoiTuDo_Add6 { get; set; } //440
        public Double ThoiGianMoCan_Add6 { get; set; } //444
        public Double ThoiGianDongCan_Add6 { get; set; } //448
        public Double ThoiGianTinhLuongRoiThem_Add6 { get; set; } //452


        //================================================= DB4 WRITE DATA WEIGHT
        //=================================================AGG1
        public Double ThoiGianTreCan_Agg1 { get; set; } //0
        public Double ThoiGianTreXa_Agg1 { get; set; } //4
        public Double ThoiGianTreDongCan_Agg1 { get; set; } //8
        public Double KhoiLuongBaoRong_Agg1 { get; set; } //12
        public Double KhoiLuongRungCan_Agg1 { get; set; } //16
        public Double ThoiGianBatRung_Agg1 { get; set; } //20
        public Double ThoiGianTatRung_Agg1 { get; set; } //24
        //=================================================AGG2
        public Double ThoiGianTreCan_Agg2 { get; set; } //28
        public Double ThoiGianTreXa_Agg2 { get; set; } //32
        public Double ThoiGianTreDongCan_Agg2 { get; set; } //36
        public Double KhoiLuongBaoRong_Agg2 { get; set; } //40
        public Double KhoiLuongRungCan_Agg2 { get; set; } //44
        public Double ThoiGianBatRung_Agg2 { get; set; } //48
        public Double ThoiGianTatRung_Agg2 { get; set; } //52
        //=================================================AGG3
        public Double ThoiGianTreCan_Agg3 { get; set; } //56
        public Double ThoiGianTreXa_Agg3 { get; set; } //60
        public Double ThoiGianTreDongCan_Agg3 { get; set; } //64
        public Double KhoiLuongBaoRong_Agg3 { get; set; } //68
        public Double KhoiLuongRungCan_Agg3 { get; set; } //72
        public Double ThoiGianBatRung_Agg3 { get; set; } //76
        public Double ThoiGianTatRung_Agg3 { get; set; } //80
        //=================================================AGG4
        public Double ThoiGianTreCan_Agg4 { get; set; } //84
        public Double ThoiGianTreXa_Agg4 { get; set; } //88
        public Double ThoiGianTreDongCan_Agg4 { get; set; } //92
        public Double KhoiLuongBaoRong_Agg4 { get; set; } //96
        public Double KhoiLuongRungCan_Agg4 { get; set; } //100
        public Double ThoiGianBatRung_Agg4 { get; set; } //104
        public Double ThoiGianTatRung_Agg4 { get; set; } //108
        //=================================================AGG5
        public Double ThoiGianTreCan_Agg5 { get; set; } //112
        public Double ThoiGianTreXa_Agg5 { get; set; } //116
        public Double ThoiGianTreDongCan_Agg5 { get; set; } //120
        public Double KhoiLuongBaoRong_Agg5 { get; set; } //124
        public Double KhoiLuongRungCan_Agg5 { get; set; } //128
        public Double ThoiGianBatRung_Agg5 { get; set; } //132
        public Double ThoiGianTatRung_Agg5 { get; set; } //136
        //=================================================AGG6
        public Double ThoiGianTreCan_Agg6 { get; set; } //140
        public Double ThoiGianTreXa_Agg6 { get; set; } //144
        public Double ThoiGianTreDongCan_Agg6 { get; set; } //148
        public Double KhoiLuongBaoRong_Agg6 { get; set; } //152
        public Double KhoiLuongRungCan_Agg6 { get; set; } //156
        public Double ThoiGianBatRung_Agg6 { get; set; } //160
        public Double ThoiGianTatRung_Agg6 { get; set; } //164
        //=================================================CE1
        public Double ThoiGianTreCan_Ce1 { get; set; } //168
        public Double ThoiGianTreXa_Ce1 { get; set; } //172
        public Double ThoiGianTreDongCan_Ce1 { get; set; } //176
        public Double KhoiLuongBaoRong_Ce1 { get; set; } //180
        public Double KhoiLuongRungCan_Ce1 { get; set; } //184
        public Double ThoiGianBatRung_Ce1 { get; set; } //188
        public Double ThoiGianTatRung_Ce1 { get; set; } //192
        //=================================================CE2
        public Double ThoiGianTreCan_Ce2 { get; set; } //196
        public Double ThoiGianTreXa_Ce2 { get; set; } //200
        public Double ThoiGianTreDongCan_Ce2 { get; set; } //204
        public Double KhoiLuongBaoRong_Ce2 { get; set; } //208
        public Double KhoiLuongRungCan_Ce2 { get; set; } //212
        public Double ThoiGianBatRung_Ce2 { get; set; } //216
        public Double ThoiGianTatRung_Ce2 { get; set; } //220
        //=================================================WA1
        public Double ThoiGianTreCan_Wa1 { get; set; } //224
        public Double ThoiGianTreXa_Wa1 { get; set; } //228
        public Double ThoiGianTreDongCan_Wa1 { get; set; } //232
        public Double KhoiLuongBaoRong_Wa1 { get; set; } //236
        //=================================================WA2
        public Double ThoiGianTreCan_Wa2 { get; set; } //240
        public Double ThoiGianTreXa_Wa2 { get; set; } //244
        public Double ThoiGianTreDongCan_Wa2 { get; set; } //248
        public Double KhoiLuongBaoRong_Wa2 { get; set; } //252
        //=================================================ADD1
        public Double ThoiGianTreCan_Add1 { get; set; } //256
        public Double ThoiGianTreXa_Add1 { get; set; } //260
        public Double ThoiGianTreDongCan_Add1 { get; set; } //264
        public Double KhoiLuongBaoRong_Add1 { get; set; } //268
        //=================================================ADD2
        public Double ThoiGianTreCan_Add2 { get; set; } //272
        public Double ThoiGianTreXa_Add2 { get; set; } //276
        public Double ThoiGianTreDongCan_Add2 { get; set; } //280
        public Double KhoiLuongBaoRong_Add2 { get; set; } //284

        //================================================DU LIEU TRON
        public Double SO_ME_TRON { get; set; } //288
        public Double SV_AGG1 { get; set; } //292
        public Double SV_AGG2 { get; set; } //296
        public Double SV_AGG3 { get; set; } //300
        public Double SV_AGG4 { get; set; } //304
        public Double SV_AGG5 { get; set; } //308
        public Double SV_AGG6 { get; set; } //312
        public Double SV_CE1 { get; set; } //316
        public Double SV_CE2 { get; set; } //320
        public Double SV_CE3 { get; set; } //324
        public Double SV_CE4 { get; set; } //328
        public Double SV_CE5 { get; set; } //332
        public Double SV_WA1 { get; set; } //336
        public Double SV_WA2 { get; set; } //340
        public Double SV_ADD1 { get; set; } //344
        public Double SV_ADD2 { get; set; } //348
        public Double SV_ADD3 { get; set; } //352
        public Double SV_ADD4 { get; set; } //356
        public Double SV_ADD5 { get; set; } //360
        public Double SV_ADD6 { get; set; } //364


        //================================================= DB5 TIMER   
        public Double ThoiGian_Tron { get; set; } //0
        public Double ThoiGian_Xa50 { get; set; } //4
        public Double ThoiGian_Xa100 { get; set; } //8
        public Double ThoiGian_PheuChoDay { get; set; } //12
        public Double ThoiGian_XaCe1SauPC { get; set; } //16
        public Double ThoiGian_XaCe2SauPC { get; set; } //20
        public Double ThoiGian_XaNuocSauPC { get; set; } //24
        public Double ThoiGian_XaPC { get; set; } //28
        public Double ThoiGian_PC_ChoPhepRung { get; set; } //32
        public Double ThoiGian_Rung_PC_ON { get; set; } //36
        public Double ThoiGian_Rung_PC_OFF { get; set; } //40
        public Double ThoiGian_XaCan_Agg1 { get; set; } //44
        public Double ThoiGian_XaCan_Agg2 { get; set; } //48
        public Double ThoiGian_XaCan_Agg3 { get; set; } //52
        public Double ThoiGian_XaCan_Agg4 { get; set; } //56
        public Double ThoiGian_XaCan_Agg5 { get; set; } //60
        public Double ThoiGian_XaCan_Agg6 { get; set; } //64
        public Double ThoiGian_XaWa2_PC { get; set; } //68
        public Double ThoiGian_XaAdd1_PC { get; set; } //72
        public Double ThoiGian_XaAdd2_PC { get; set; } //76
        public Double ThoiGian_AnToanGau { get; set; } //80
        public Double ThoiGian_DL_GauLen { get; set; } //84
        public Double ThoiGian_DL_GauDuoi { get; set; } //88
        public Double ThoiGian_DL_XaGau { get; set; } //92
        public Double KL_XaTruoc_Agg1 { get; set; } //96
        public Double KL_XaTruoc_Agg2 { get; set; } //100
        public Double KL_XaTruoc_Agg3 { get; set; } //104
        public Double KL_XaTruoc_Agg4 { get; set; } //108
        public Double KL_XaTruoc_Agg5 { get; set; } //112
        public Double KL_XaTruoc_Agg6 { get; set; } //116
        public Double TG_TRE_TAT_VTX { get; set; } //120
        public Double TG_BAT_RUNG_WAGG { get; set; } //124
        public Double TG_TAT_RUNG_WAGG { get; set; } //128
        public Double TG_BAT_RUNG_WCE { get; set; } //132
        public Double TG_TAT_RUNG_WCE { get; set; } //136
        public Double TG_BAT_SKSL { get; set; } //140
        public Double TG_TAT_SKSL { get; set; } //144
        public Double TG_TRE_MO_VAN_CE { get; set; } //148
        public Double HSN_AGG1 { get; set; } //152
        public Double HSX_AGG1 { get; set; } //156
        public Double HSN_AGG2 { get; set; } //160
        public Double HSX_AGG2 { get; set; } //164
        public Double HSN_AGG3 { get; set; } //168
        public Double HSX_AGG3 { get; set; } //172
        public Double HSN_AGG4 { get; set; } //176
        public Double HSX_AGG4 { get; set; } //180
        public Double HSN_AGG5 { get; set; } //184
        public Double HSX_AGG5 { get; set; } //188
        public Double HSN_AGG6 { get; set; } //192
        public Double HSX_AGG6 { get; set; } //196
        public Double HSN_CE1 { get; set; } //200
        public Double HSX_CE1 { get; set; } //204
        public Double HSN_CE2 { get; set; } //208
        public Double HSX_CE2 { get; set; } //212
        public Double HSN_CE3 { get; set; } //216
        public Double HSN_CE4 { get; set; } //220
        public Double HSN_CE5 { get; set; } //224
        public Double HSN_WA1 { get; set; } //228
        public Double HSX_WA1 { get; set; } //232
        public Double HSN_WA2 { get; set; } //236
        public Double HSX_WA2 { get; set; } //240
        public Double HSN_ADD1 { get; set; } //244
        public Double HSX_ADD1 { get; set; } //248
        public Double HSN_ADD2 { get; set; } //252
        public Double HSX_ADD2 { get; set; } //256
        public Double HSN_ADD3 { get; set; } //260
        public Double HSN_ADD4 { get; set; } //264
        public Double HSN_ADD5 { get; set; } //268
        public Double HSN_ADD6 { get; set; } //272



        //================================================= DB6_WRITE_DATA_CALIB_WEIGHT
        public Double KL_TEMPLE { get; set; } //48
        public Double KL_ZERO_AGG1 { get; set; } //48
        public Double KL_SPAN_AGG1 { get; set; } //52
        public Double KL_ZERO_AGG2 { get; set; } //56
        public Double KL_SPAN_AGG2 { get; set; } //60
        public Double KL_ZERO_AGG3 { get; set; } //64
        public Double KL_SPAN_AGG3 { get; set; } //68
        public Double KL_ZERO_AGG4 { get; set; } //72
        public Double KL_SPAN_AGG4 { get; set; } //76
        public Double KL_ZERO_AGG5 { get; set; } //80
        public Double KL_SPAN_AGG5 { get; set; } //84
        public Double KL_ZERO_AGG6 { get; set; } //88
        public Double KL_SPAN_AGG6 { get; set; } //92
        public Double KL_ZERO_CEM1 { get; set; } //96
        public Double KL_SPAN_CEM1 { get; set; } //100
        public Double KL_ZERO_CEM2 { get; set; } //104
        public Double KL_SPAN_CEM2 { get; set; } //108
        public Double KL_ZERO_WAT1 { get; set; } //112
        public Double KL_SPAN_WAT1 { get; set; } //116
        public Double KL_ZERO_WAT2 { get; set; } //120
        public Double KL_SPAN_WAT2 { get; set; } //124
        public Double KL_ZERO_ADD1 { get; set; } //128
        public Double KL_SPAN_ADD1 { get; set; } //132
        public Double KL_ZERO_ADD2 { get; set; } //136
        public Double KL_SPAN_ADD2 { get; set; } //140
        public Double HS_XUNG_PG1 { get; set; } //144
        public Double HS_XUNG_PG2 { get; set; } //148
        public Double HS_XUNG_PG3 { get; set; } //152
        public Double HS_XUNG_PG4 { get; set; } //156
        public Double HS_XUNG_PG5 { get; set; } //160
        public Double HS_XUNG_PG6 { get; set; } //164
        public Double KL_XUNG_PG1 { get; set; } //168
        public Double KL_XUNG_PG2 { get; set; } //172
        public Double KL_XUNG_PG3 { get; set; } //176
        public Double KL_XUNG_PG4 { get; set; } //180
        public Double KL_XUNG_PG5 { get; set; } //184
        public Double KL_XUNG_PG6 { get; set; } //188
        public Double LG1_AGG { get; set; } //192
        public Double LG2_AGG { get; set; } //196
        public Double LG3_AGG { get; set; } //200
        public Double LG4_CE { get; set; } //204
        public Double LG5_CE { get; set; } //208
        public Double LG6_ADD { get; set; } //212
        public Double LG7_ADD { get; set; } //216

        //=================================================================
        public Double ThoiGianTreCan_Ce { get; set; } //28.0
        public Double ThoiGianTreXa_Ce { get; set; } //32.0
        public Double ThoiGianTreDongCan_Ce { get; set; } //36.0
        public Double KhoiLuongBaoRong_Ce { get; set; } //40.0
        public Double KhoiLuongRungCan_Ce { get; set; } //44.0
        public Double ThoiGianBatRung_Ce { get; set; } //48.0
        public Double ThoiGianTatRung_Ce { get; set; } //52.0
        public Double ThoiGianTreCan_Wa { get; set; } //56.0
        public Double ThoiGianTreXa_Wa { get; set; } //60.0
        public Double ThoiGianTreDongCan_Wa { get; set; } //64.0
        public Double KhoiLuongBaoRong_Wa { get; set; } //68.0
        public Double XungCan_Agg { get; set; } //72.0
        public Double KL_Chinh_0_Agg { get; set; } //76.0
        public Double KL_ChinhTai_Agg { get; set; } //80.0
        public Double KL_Thuc_Agg { get; set; } //84.0
        public Double XungCan_Ce { get; set; } //88.0
        public Double KL_Chinh_0_Ce { get; set; } //92.0
        public Double KL_ChinhTai_Ce { get; set; } //96.0
        public Double KL_Thuc_Ce { get; set; } //100.0
        public Double XungCan_Wa { get; set; } //104.0
        public Double KL_Chinh_0_Wa { get; set; } //108.0
        public Double KL_ChinhTai_Wa { get; set; } //112.0
        public Double KL_Thuc_Wa { get; set; } //116.0
        public Double Per_KL_AGG { get; set; } //144.0
        public Double Per_KL_CE { get; set; } //148.0
        public Double Per_KL_ADD { get; set; } //152.0

        //=====================================================
        
       
        //================================================= DB_4 WRITE DATA UPDATE
        public Double KLTrenTungMe { get; set; }
        public Double SoMeTron { get; set; } //288
        
        public Double KL_CanCan_Agg1 { get; set; } // 292
        public Double KL_CanCan_Agg2 { get; set; } // 296
        public Double KL_CanCan_Agg3 { get; set; } // 300
        public Double KL_CanCan_Agg4 { get; set; } // 304
        public Double KL_CanCan_Agg5 { get; set; } // 308
        public Double KL_CanCan_Agg6 { get; set; } // 312
        public Double KL_CanCan_Ce1 { get; set; } // 316
        public Double KL_CanCan_Ce2 { get; set; } // 320
        public Double KL_CanCan_Ce3 { get; set; } // 324
        public Double KL_CanCan_Ce4 { get; set; } // 328
        public Double KL_CanCan_Ce5 { get; set; } // 332
        public Double KL_CanCan_Wa1 { get; set; } // 336
        public Double KL_CanCan_Wa2 { get; set; } // 340
        public Double KL_CanCan_Add1 { get; set; } // 344
        public Double KL_CanCan_Add2 { get; set; } // 348
        public Double KL_CanCan_Add3 { get; set; } // 352
        public Double KL_CanCan_Add4 { get; set; } // 356
        public Double KL_CanCan_Add5 { get; set; } // 360
        public Double KL_CanCan_Add6 { get; set; } // 360

        public Double KL_CaiDat_Agg1 { get; set; }
        public Double KL_CaiDat_Agg2 { get; set; }
        public Double KL_CaiDat_Agg3 { get; set; }
        public Double KL_CaiDat_Agg4 { get; set; }
        public Double KL_CaiDat_Agg5 { get; set; }
        public Double KL_CaiDat_Agg6 { get; set; }
        public Double KL_CaiDat_Ce1 { get; set; }
        public Double KL_CaiDat_Ce2 { get; set; }
        public Double KL_CaiDat_Ce3 { get; set; }
        public Double KL_CaiDat_Ce4 { get; set; }
        public Double KL_CaiDat_Ce5 { get; set; }
        public Double KL_CaiDat_Wa1 { get; set; }
        public Double KL_CaiDat_Wa2 { get; set; }
        public Double KL_CaiDat_Add1 { get; set; }
        public Double KL_CaiDat_Add2 { get; set; }
        public Double KL_CaiDat_Add3 { get; set; }
        public Double KL_CaiDat_Add4 { get; set; }
        public Double KL_CaiDat_Add5 { get; set; }
        public Double KL_CaiDat_Add6 { get; set; }
        public void ResetValues()
        {
            
        }
    }
}

using NDPSo.MasterData.Config;
using NDPSo.PLCMapping;
using NDPSo.PLCModule;
using NDPSo.Data;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using DataType = S7.Net.DataType;

namespace NDPSo.MasterData
{
    public partial class VanHanh
    {
        #region PLC Communication (DB2-DB6 Send, Thread Wrappers)

        private void Send_Data_DB_3_To_PLC() //WRITE DATA TO PLC
        {
            List<byte> list_00 = new List<byte>();
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Agg1));// 0
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Agg1));// 4
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Agg1));// 8
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Agg1));// 12
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Agg1));// 16
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Agg1));// 20
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Agg2));// 24
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Agg2));// 28
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Agg2));// 32
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Agg2));// 36
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Agg2));// 40
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Agg2));// 44
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Agg3));// 48
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Agg3));// 52
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Agg3));// 56
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Agg3));// 60
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Agg3));// 64
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Agg3));// 68
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Agg4));// 72
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Agg4));// 76
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Agg4));// 80
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Agg4));// 84
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Agg4));// 88
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Agg4));// 92
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Agg5));// 96
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Agg5));// 100
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Agg5));// 104
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Agg5));// 108
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Agg5));// 112
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Agg5));// 116
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Agg6));// 120
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Agg6));// 124
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Agg6));// 128
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Agg6));// 132
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Agg6));// 136
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Agg6));// 140
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Ce1));// 144
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Ce1));// 148
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Ce1));// 152
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Ce1));// 156
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Ce1));//160
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Ce1));// 164
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Ce2));// 168
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Ce2));// 172
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Ce2));// 176
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Ce2));// 180
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Ce2));//184
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Ce2));// 188
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Ce3));// 192
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Ce3));// 196
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Ce3));// 200
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Ce3));// 204
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Ce3));//208
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Ce3));// 212
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Ce4));// 216
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Ce4));// 220
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Ce4));// 224
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Ce4));// 228
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Ce4));//232
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Ce4));// 236
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Ce5));// 240
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Ce5));// 244
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Ce5));// 248
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Ce5));// 252
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Ce5));//256
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Ce5));// 260
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Wa1));// 264
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Wa1));// 268
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Wa1));// 272
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Wa1));// 276
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Wa1));//280
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Wa1));// 284
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Wa2));// 288
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Wa2));// 292
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Wa2));// 296
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Wa2));// 300
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Wa2));//304
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Wa2));// 308
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Add1));// 312
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Add1));// 316
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Add1));// 320
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Add1));// 324
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Add1));//328
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Add1));// 332
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Add2));// 336
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Add2));// 340
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Add2));// 344
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Add2));// 348
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Add2));//352
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Add2));// 356
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Add3));// 360
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Add3));// 364
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Add3));// 368
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Add3));// 372
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Add3));//376
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Add3));// 380
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Add4));// 384
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Add4));// 388
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Add4));// 392
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Add4));// 396
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Add4));//400
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Add4));// 404
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Add5));// 408
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Add5));// 412
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Add5));// 416
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Add5));// 420
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Add5));//424
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Add5));// 428
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoTren_Add6));// 432
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SaiSoDuoi_Add6));// 436
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.RoiTuDo_Add6));// 440
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianMoCan_Add6));// 444
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianDongCan_Add6));//448
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTinhLuongRoiThem_Add6));// 452

            byte[] value = list_00.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 3, 0, value);
        }
        private void Send_Data_DB_4_To_PLC() // WRITE DATA TO PLC
        {
            List<byte> list_00 = new List<byte>();
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Agg1));// 0
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Agg1));// 4
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Agg1));// 8
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Agg1));// 12
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongRungCan_Agg1));// 16
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianBatRung_Agg1));// 20
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTatRung_Agg1));// 24
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Ce1));// 28
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Ce1));// 32
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Ce1));// 36
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Ce1));// 40
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongRungCan_Ce1));// 44
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianBatRung_Ce1));// 48
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTatRung_Ce1));// 52
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Wa1));// 56
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Wa1));// 60
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Wa1));// 64
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Wa1));// 68
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreCan_Add1));// 72
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreXa_Add1));// 76
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGianTreDongCan_Add1));// 80
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KhoiLuongBaoRong_Add1));// 84
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.SoMeTron));// 88
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg1));// 92
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce1));// 96
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Wa1));// 100
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add1));// 104


            byte[] value = list_00.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 23, 0, value);
        }
        private void Send_Data_DB_4_To_PLC_Update()
        {
            List<byte> list_00 = new List<byte>();
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg1 + 10));// 292
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg2 + 10));// 296
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg3 + 10));// 300
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg4));// 304
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg5));// 308
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Agg6));// 312
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce1));// 316
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce2));// 320
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce3));// 324
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce4));// 328
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Ce5));// 332
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Wa1));// 336
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Wa2));// 340
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add1));// 344
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add2));// 348
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add3));// 352
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add4));// 356
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add5));// 360
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_CanCan_Add6));// 364

            byte[] value = list_00.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 4, 292, value);
        }
        private void Send_Data_DB_5_To_PLC() //WRITE DATA TO PLC 5 to 24
        {
            List<byte> list_00 = new List<byte>();
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_Tron));// 0
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_Xa50));// 4
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_Xa100));// 8
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_PheuChoDay));// 12
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCe1SauPC));// 16
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaNuocSauPC));// 20
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaPC));// 24
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaPC));// 28
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_Rung_PC_ON));// 32
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_Rung_PC_OFF));// 36
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCan_Agg1));// 40
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaWa2_PC));// 44
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaAdd1_PC));// 48
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_AnToanGau));// 52
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCan_Agg4));// 56
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCan_Agg5));// 60
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaCan_Agg6));// 64
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaWa2_PC));// 68
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaAdd1_PC));// 72
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_XaAdd2_PC));// 76
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_AnToanGau));// 80
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_DL_GauLen));// 84
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_DL_GauDuoi));// 88
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.ThoiGian_DL_XaGau));// 92
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XaTruoc_Agg1));// 96
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XaTruoc_Agg2));// 100
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XaTruoc_Agg3));// 104
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XaTruoc_Agg4));// 108
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XaTruoc_Agg5));// 112
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XaTruoc_Agg6));// 116
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.TG_TRE_TAT_VTX));// 120
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.TG_BAT_RUNG_WAGG));// 124
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSN_ADD1));// 128
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HSX_ADD1));// 132
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.TG_TRON_UOT));// 136

            byte[] value = list_00.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 24, 0, value);
        }
        private void Send_Data_DB_6_To_PLC()   //WRITE DATA TO PLC
        {
            List<byte> list_00 = new List<byte>();
            /*list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 0
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 4
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 8
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 12
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 16
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 20
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 24
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 28
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 32
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 36
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 40
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_TEMPLE));// 44*/
            /*list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG1));// 48
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_AGG1));// 52
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG2));// 56
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_AGG2));// 60
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG3));// 64
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_AGG3));// 68
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG4));// 72
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_AGG4));// 76
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG5));// 80
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_AGG5));// 84
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_AGG6));// 88
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_AGG6));// 92
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_CEM1));// 96
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_CEM1));// 100
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_CEM2));// 104
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_CEM2));// 108
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_WAT1));// 112
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_WAT1));// 116
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_WAT2));// 120
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_WAT2));// 124
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_ADD1));// 128
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_ADD1));// 132
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_ZERO_ADD2));// 136
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_SPAN_ADD2));// 140
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HS_XUNG_PG1));// 144
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HS_XUNG_PG2));// 148
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HS_XUNG_PG3));// 152
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HS_XUNG_PG4));// 156
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HS_XUNG_PG5));// 160
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.HS_XUNG_PG6));// 164
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG1));// 168
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG2));// 172
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG3));// 176
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG4));// 180
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG5));// 184
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.KL_XUNG_PG6));// 188*/
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG1_AGG));// 192
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG2_AGG));// 196
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG3_AGG));// 200
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG4_CE));// 204
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG5_CE));// 208
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG6_ADD));// 212
            list_00.AddRange(MappingHelper.SeparateFloatTo4Bytes((double)this._sp.LG7_ADD));// 216

            byte[] value = list_00.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 6, 192, value);
        }

        public void BuildSetPointNotHD(BindingList<ObjWeigh> blstWei, BindingList<ObjSilo> blstSilo , Decimal giuNuocTenCan, SetPoint setPoint1)
        {
            foreach (ObjWeigh objWei in (Collection<ObjWeigh>)blstWei)
            {
                switch (objWei.WeighCode)
                {
                    case "Agg1":
                        SetPoint setPoint30 = setPoint1;
                        setPoint30.ThoiGianTreCan_Agg1 = (decimal)objWei.TimeEmpty;
                        setPoint30.ThoiGianTreXa_Agg1 = (decimal)objWei.Max;
                        setPoint30.ThoiGianTreDongCan_Agg1 = (decimal)objWei.Offset;
                        setPoint30.KhoiLuongBaoRong_Agg1 = (decimal)objWei.KLEmpty;
                        setPoint30.KhoiLuongRungCan_Agg1 = (decimal)objWei.WeiToVib;
                        setPoint30.ThoiGianBatRung_Agg1 = (decimal)objWei.TON;
                        setPoint30.ThoiGianTatRung_Agg1 = (decimal)objWei.TOFF;
                        setPoint30.GIU_LAI_CAN_AGG1 = (bool)objWei.GiuKLTC;
                        continue;
                    case "Agg2":
                        SetPoint setPoint31 = setPoint1;
                        setPoint31.ThoiGianTreCan_Agg2 = (decimal)objWei.TimeEmpty;
                        setPoint31.ThoiGianTreXa_Agg2 = (decimal)objWei.Max;
                        setPoint31.ThoiGianTreDongCan_Agg2 = (decimal)objWei.Offset;
                        setPoint31.KhoiLuongBaoRong_Agg2 = (decimal)objWei.KLEmpty;
                        setPoint31.KhoiLuongRungCan_Agg2 = (decimal)objWei.WeiToVib;
                        setPoint31.ThoiGianBatRung_Agg2 = (decimal)objWei.TON;
                        setPoint31.ThoiGianTatRung_Agg2 = (decimal)objWei.TOFF;
                        setPoint31.GIU_LAI_CAN_AGG2 = (bool)objWei.GiuKLTC;
                        continue;
                    case "Agg3":
                        SetPoint setPoint32 = setPoint1;
                        setPoint32.ThoiGianTreCan_Agg3 = (decimal)objWei.TimeEmpty;
                        setPoint32.ThoiGianTreXa_Agg3 = (decimal)objWei.Max;
                        setPoint32.ThoiGianTreDongCan_Agg3 = (decimal)objWei.Offset;
                        setPoint32.KhoiLuongBaoRong_Agg3 = (decimal)objWei.KLEmpty;
                        setPoint32.KhoiLuongRungCan_Agg3 = (decimal)objWei.WeiToVib;
                        setPoint32.ThoiGianBatRung_Agg3 = (decimal)objWei.TON;
                        setPoint32.ThoiGianTatRung_Agg3 = (decimal)objWei.TOFF;
                        setPoint32.GIU_LAI_CAN_AGG3 = (bool)objWei.GiuKLTC;
                        continue;
                    case "Agg4":
                        SetPoint setPoint33 = setPoint1;
                        setPoint33.ThoiGianTreCan_Agg4 = (decimal)objWei.TimeEmpty;
                        setPoint33.ThoiGianTreXa_Agg4 = (decimal)objWei.Max;
                        setPoint33.ThoiGianTreDongCan_Agg4 = (decimal)objWei.Offset;
                        setPoint33.KhoiLuongBaoRong_Agg4 = (decimal)objWei.KLEmpty;
                        setPoint33.KhoiLuongRungCan_Agg4 = (decimal)objWei.WeiToVib;
                        setPoint33.ThoiGianBatRung_Agg4 = (decimal)objWei.TON;
                        setPoint33.ThoiGianTatRung_Agg4 = (decimal)objWei.TOFF;
                        setPoint33.GIU_LAI_CAN_AGG4 = (bool)objWei.GiuKLTC;
                        continue;
                    case "Agg5":
                        SetPoint setPoint34 = setPoint1;
                        setPoint34.ThoiGianTreCan_Agg5 = (decimal)objWei.TimeEmpty;
                        setPoint34.ThoiGianTreXa_Agg5 = (decimal)objWei.Max;
                        setPoint34.ThoiGianTreDongCan_Agg5 = (decimal)objWei.Offset;
                        setPoint34.KhoiLuongBaoRong_Agg5 = (decimal)objWei.KLEmpty;
                        setPoint34.KhoiLuongRungCan_Agg5 = (decimal)objWei.WeiToVib;
                        setPoint34.ThoiGianBatRung_Agg5 = (decimal)objWei.TON;
                        setPoint34.ThoiGianTatRung_Agg5 = (decimal)objWei.TOFF;
                        setPoint34.GIU_LAI_CAN_AGG5 = (bool)objWei.GiuKLTC;
                        continue;
                    case "Agg6":
                        SetPoint setPoint35 = setPoint1;
                        setPoint35.ThoiGianTreCan_Agg6 = (decimal)objWei.TimeEmpty;
                        setPoint35.ThoiGianTreXa_Agg6 = (decimal)objWei.Max;
                        setPoint35.ThoiGianTreDongCan_Agg6 = (decimal)objWei.Offset;
                        setPoint35.KhoiLuongBaoRong_Agg6 = (decimal)objWei.KLEmpty;
                        setPoint35.KhoiLuongRungCan_Agg6 = (decimal)objWei.WeiToVib;
                        setPoint35.ThoiGianBatRung_Agg6 = (decimal)objWei.TON;
                        setPoint35.ThoiGianTatRung_Agg6 = (decimal)objWei.TOFF;
                        setPoint35.GIU_LAI_CAN_AGG6 = (bool)objWei.GiuKLTC;
                        continue;

                    case "Ce1":
                        SetPoint setPoint36 = setPoint1;
                        setPoint36.ThoiGianTreCan_Ce1 = (decimal)objWei.TimeEmpty;
                        setPoint36.ThoiGianTreXa_Ce1 = (decimal)objWei.Max;
                        setPoint36.ThoiGianTreDongCan_Ce1 = (decimal)objWei.Offset;
                        setPoint36.KhoiLuongBaoRong_Ce1 = (decimal)objWei.KLEmpty;
                        setPoint36.KhoiLuongRungCan_Ce1 = (decimal)objWei.WeiToVib;
                        setPoint36.ThoiGianBatRung_Ce1 = (decimal)objWei.TON;
                        setPoint36.ThoiGianTatRung_Ce1 = (decimal)objWei.TOFF;
                        setPoint36.GIU_LAI_CAN_CE1 = (bool)objWei.GiuKLTC;
                        continue;
                    case "Ce2":
                        SetPoint setPoint37 = setPoint1;
                        setPoint37.ThoiGianTreCan_Ce2 = (decimal)objWei.TimeEmpty;
                        setPoint37.ThoiGianTreXa_Ce2 = (decimal)objWei.Max;
                        setPoint37.ThoiGianTreDongCan_Ce2 = (decimal)objWei.Offset;
                        setPoint37.KhoiLuongBaoRong_Ce2 = (decimal)objWei.KLEmpty;
                        setPoint37.KhoiLuongRungCan_Ce2 = (decimal)objWei.WeiToVib;
                        setPoint37.ThoiGianBatRung_Ce2 = (decimal)objWei.TON;
                        setPoint37.ThoiGianTatRung_Ce2 = (decimal)objWei.TOFF;
                        setPoint37.GIU_LAI_CAN_CE2 = (bool)objWei.GiuKLTC;
                        continue;

                    case "Wa1":
                        SetPoint setPoint38 = setPoint1;
                        setPoint38.ThoiGianTreCan_Wa1 = (decimal)objWei.TimeEmpty;
                        setPoint38.ThoiGianTreXa_Wa1 = (decimal)objWei.Max;
                        setPoint38.ThoiGianTreDongCan_Wa1 = (decimal)objWei.Offset;
                        decimal? numWa1 = objWei.KLEmpty;
                        numWa1 = numWa1.Value + giuNuocTenCan;
                        setPoint38.KhoiLuongBaoRong_Wa1 = (decimal)numWa1;
                        setPoint38.GIU_LAI_CAN_WA1 = (bool)objWei.GiuKLTC;
                        continue;
                    case "Wa2":
                        SetPoint setPoint39 = setPoint1;
                        setPoint39.ThoiGianTreCan_Wa2 = (decimal)objWei.TimeEmpty;
                        setPoint39.ThoiGianTreXa_Wa2 = (decimal)objWei.Max;
                        setPoint39.ThoiGianTreDongCan_Wa2 = (decimal)objWei.Offset;
                        setPoint39.KhoiLuongBaoRong_Wa2 = (decimal)objWei.KLEmpty;
                        setPoint39.GIU_LAI_CAN_WA2 = (bool)objWei.GiuKLTC;
                        continue;
                    case "Add1":
                        SetPoint setPoint40 = setPoint1;
                        setPoint40.ThoiGianTreCan_Add1 = (decimal)objWei.TimeEmpty;
                        setPoint40.ThoiGianTreXa_Add1 = (decimal)objWei.Max;
                        setPoint40.ThoiGianTreDongCan_Add1 = (decimal)objWei.Offset;
                        setPoint40.KhoiLuongBaoRong_Add1 = (decimal)objWei.KLEmpty;
                        setPoint40.GIU_LAI_CAN_ADD1 = (bool)objWei.GiuKLTC;
                        continue;
                    case "Add2":
                        SetPoint setPoint41 = setPoint1;
                        setPoint41.ThoiGianTreCan_Add2 = (decimal)objWei.TimeEmpty;
                        setPoint41.ThoiGianTreXa_Add2 = (decimal)objWei.Max;
                        setPoint41.ThoiGianTreDongCan_Add2 = (decimal)objWei.Offset;
                        setPoint41.KhoiLuongBaoRong_Add2 = (decimal)objWei.KLEmpty;
                        setPoint41.GIU_LAI_CAN_ADD2 = (bool)objWei.GiuKLTC;
                        continue;
                }
            }

            Decimal? nullable;
            foreach (ObjSilo objSilo in (Collection<ObjSilo>)blstSilo)
            {
                switch (objSilo.MaSilo)
                {
                    case "Agg1":

                        SetPoint setPoint24 = setPoint1;

                        //====
                        setPoint24.SaiSoTren_Agg1 = (decimal)objSilo.SaiSoTren;
                        setPoint24.SaiSoDuoi_Agg1 = (decimal)objSilo.SaiSoDuoi;
                        setPoint24.RoiTuDo_Agg1 = (decimal)objSilo.KLRoi;
                        setPoint24.ThoiGianMoCan_Agg1 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint24.ThoiGianDongCan_Agg1 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint24.ThoiGianTinhLuongRoiThem_Agg1 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint24.BuTruKLMT_Agg1 = (bool)objSilo.BuTruKLMT;
                        setPoint24.TuDongXNCD_Agg1 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Agg2":

                        SetPoint setPoint26 = setPoint1;

                        //====
                        setPoint26.SaiSoTren_Agg2 = (decimal)objSilo.SaiSoTren;
                        setPoint26.SaiSoDuoi_Agg2 = (decimal)objSilo.SaiSoDuoi;
                        setPoint26.RoiTuDo_Agg2 = (decimal)objSilo.KLRoi;
                        setPoint26.ThoiGianMoCan_Agg2 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint26.ThoiGianDongCan_Agg2 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint26.ThoiGianTinhLuongRoiThem_Agg2 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint26.BuTruKLMT_Agg2 = (bool)objSilo.BuTruKLMT;
                        setPoint26.TuDongXNCD_Agg2 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Agg3":

                        SetPoint setPoint28 = setPoint1;

                        //====
                        setPoint28.SaiSoTren_Agg3 = (decimal)objSilo.SaiSoTren;
                        setPoint28.SaiSoDuoi_Agg3 = (decimal)objSilo.SaiSoDuoi;
                        setPoint28.RoiTuDo_Agg3 = (decimal)objSilo.KLRoi;
                        setPoint28.ThoiGianMoCan_Agg3 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint28.ThoiGianDongCan_Agg3 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint28.ThoiGianTinhLuongRoiThem_Agg3 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint28.BuTruKLMT_Agg3 = (bool)objSilo.BuTruKLMT;
                        setPoint28.TuDongXNCD_Agg3 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Agg4":

                        SetPoint setPoint30 = setPoint1;

                        //====
                        setPoint30.SaiSoTren_Agg4 = (decimal)objSilo.SaiSoTren;
                        setPoint30.SaiSoDuoi_Agg4 = (decimal)objSilo.SaiSoDuoi;
                        setPoint30.RoiTuDo_Agg4 = (decimal)objSilo.KLRoi;
                        setPoint30.ThoiGianMoCan_Agg4 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint30.ThoiGianDongCan_Agg4 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint30.ThoiGianTinhLuongRoiThem_Agg4 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint30.BuTruKLMT_Agg4 = (bool)objSilo.BuTruKLMT;
                        setPoint30.TuDongXNCD_Agg4 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Agg5":

                        SetPoint setPoint32 = setPoint1;

                        //====
                        setPoint32.SaiSoTren_Agg5 = (decimal)objSilo.SaiSoTren;
                        setPoint32.SaiSoDuoi_Agg5 = (decimal)objSilo.SaiSoDuoi;
                        setPoint32.RoiTuDo_Agg5 = (decimal)objSilo.KLRoi;
                        setPoint32.ThoiGianMoCan_Agg5 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint32.ThoiGianDongCan_Agg5 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint32.ThoiGianTinhLuongRoiThem_Agg5 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint32.BuTruKLMT_Agg5 = (bool)objSilo.BuTruKLMT;
                        setPoint32.TuDongXNCD_Agg5 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Agg6":

                        SetPoint setPoint34 = setPoint1;

                        //====
                        setPoint34.SaiSoTren_Agg6 = (decimal)objSilo.SaiSoTren;
                        setPoint34.SaiSoDuoi_Agg6 = (decimal)objSilo.SaiSoDuoi;
                        setPoint34.RoiTuDo_Agg6 = (decimal)objSilo.KLRoi;
                        setPoint34.ThoiGianMoCan_Agg6 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint34.ThoiGianDongCan_Agg6 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint34.ThoiGianTinhLuongRoiThem_Agg6 = (decimal)objSilo.TGKiemTraVatLieuRoi;

                        continue;
                    case "Ce1":
                        SetPoint setPoint36 = setPoint1;
                        //====
                        setPoint36.SaiSoTren_Ce1 = (decimal)objSilo.SaiSoTren;
                        setPoint36.SaiSoDuoi_Ce1 = (decimal)objSilo.SaiSoDuoi;
                        setPoint36.RoiTuDo_Ce1 = (decimal)objSilo.KLRoi;
                        setPoint36.ThoiGianMoCan_Ce1 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint36.ThoiGianDongCan_Ce1 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint36.ThoiGianTinhLuongRoiThem_Ce1 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint36.BuTruKLMT_Ce1 = (bool)objSilo.BuTruKLMT;
                        setPoint36.TuDongXNCD_Ce1 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Ce2":
                        SetPoint setPoint37 = setPoint1;
                        //====
                        setPoint37.SaiSoTren_Ce2 = (decimal)objSilo.SaiSoTren;
                        setPoint37.SaiSoDuoi_Ce2 = (decimal)objSilo.SaiSoDuoi;
                        setPoint37.RoiTuDo_Ce2 = (decimal)objSilo.KLRoi;
                        setPoint37.ThoiGianMoCan_Ce2 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint37.ThoiGianDongCan_Ce2 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint37.ThoiGianTinhLuongRoiThem_Ce2 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint37.BuTruKLMT_Ce2 = (bool)objSilo.BuTruKLMT;
                        setPoint37.TuDongXNCD_Ce2 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Ce3":
                        SetPoint setPoint38 = setPoint1;
                        //====
                        setPoint38.SaiSoTren_Ce3 = (decimal)objSilo.SaiSoTren;
                        setPoint38.SaiSoDuoi_Ce3 = (decimal)objSilo.SaiSoDuoi;
                        setPoint38.RoiTuDo_Ce3 = (decimal)objSilo.KLRoi;
                        setPoint38.ThoiGianMoCan_Ce3 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint38.ThoiGianDongCan_Ce3 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint38.ThoiGianTinhLuongRoiThem_Ce3 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint38.BuTruKLMT_Ce3 = (bool)objSilo.BuTruKLMT;
                        setPoint38.TuDongXNCD_Ce3 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Ce4":
                        SetPoint setPoint39 = setPoint1;
                        //====
                        setPoint39.SaiSoTren_Ce4 = (decimal)objSilo.SaiSoTren;
                        setPoint39.SaiSoDuoi_Ce4 = (decimal)objSilo.SaiSoDuoi;
                        setPoint39.RoiTuDo_Ce4 = (decimal)objSilo.KLRoi;
                        setPoint39.ThoiGianMoCan_Ce4 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint39.ThoiGianDongCan_Ce4 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint39.ThoiGianTinhLuongRoiThem_Ce4 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint39.BuTruKLMT_Ce4 = (bool)objSilo.BuTruKLMT;
                        setPoint39.TuDongXNCD_Ce4 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Ce5":
                        SetPoint setPoint40 = setPoint1;
                        //====
                        setPoint40.SaiSoTren_Ce5 = (decimal)objSilo.SaiSoTren;
                        setPoint40.SaiSoDuoi_Ce5 = (decimal)objSilo.SaiSoDuoi;
                        setPoint40.RoiTuDo_Ce5 = (decimal)objSilo.KLRoi;
                        setPoint40.ThoiGianMoCan_Ce5 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint40.ThoiGianDongCan_Ce5 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint40.ThoiGianTinhLuongRoiThem_Ce5 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint40.BuTruKLMT_Ce5 = (bool)objSilo.BuTruKLMT;
                        setPoint40.TuDongXNCD_Ce5 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Wa1":
                        SetPoint setPoint41 = setPoint1;
                        //====
                        setPoint41.SaiSoTren_Wa1 = (decimal)objSilo.SaiSoTren;
                        setPoint41.SaiSoDuoi_Wa1 = (decimal)objSilo.SaiSoDuoi;
                        setPoint41.RoiTuDo_Wa1 = (decimal)objSilo.KLRoi;
                        setPoint41.ThoiGianMoCan_Wa1 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint41.ThoiGianDongCan_Wa1 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint41.ThoiGianTinhLuongRoiThem_Wa1 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint41.BuTruKLMT_Wa1 = (bool)objSilo.BuTruKLMT;
                        setPoint41.TuDongXNCD_Wa1 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Wa2":
                        SetPoint setPoint42 = setPoint1;
                        //====
                        setPoint42.SaiSoTren_Wa2 = (decimal)objSilo.SaiSoTren;
                        setPoint42.SaiSoDuoi_Wa2 = (decimal)objSilo.SaiSoDuoi;
                        setPoint42.RoiTuDo_Wa2 = (decimal)objSilo.KLRoi;
                        setPoint42.ThoiGianMoCan_Wa2 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint42.ThoiGianDongCan_Wa2 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint42.ThoiGianTinhLuongRoiThem_Wa2 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint42.BuTruKLMT_Wa2 = (bool)objSilo.BuTruKLMT;
                        setPoint42.TuDongXNCD_Wa2 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Add1":
                        SetPoint setPoint43 = setPoint1;
                        //====
                        setPoint43.SaiSoTren_Add1 = (decimal)objSilo.SaiSoTren;
                        setPoint43.SaiSoDuoi_Add1 = (decimal)objSilo.SaiSoDuoi;
                        setPoint43.RoiTuDo_Add1 = (decimal)objSilo.KLRoi;
                        setPoint43.ThoiGianMoCan_Add1 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint43.ThoiGianDongCan_Add1 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint43.ThoiGianTinhLuongRoiThem_Add1 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint43.BuTruKLMT_Add1 = (bool)objSilo.BuTruKLMT;
                        setPoint43.TuDongXNCD_Add1 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Add2":
                        SetPoint setPoint44 = setPoint1;
                        //====
                        setPoint44.SaiSoTren_Add2 = (decimal)objSilo.SaiSoTren;
                        setPoint44.SaiSoDuoi_Add2 = (decimal)objSilo.SaiSoDuoi;
                        setPoint44.RoiTuDo_Add2 = (decimal)objSilo.KLRoi;
                        setPoint44.ThoiGianMoCan_Add2 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint44.ThoiGianDongCan_Add2 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint44.ThoiGianTinhLuongRoiThem_Add2 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint44.BuTruKLMT_Add2 = (bool)objSilo.BuTruKLMT;
                        setPoint44.TuDongXNCD_Add2 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Add3":
                        SetPoint setPoint45 = setPoint1;
                        //====
                        setPoint45.SaiSoTren_Add3 = (decimal)objSilo.SaiSoTren;
                        setPoint45.SaiSoDuoi_Add3 = (decimal)objSilo.SaiSoDuoi;
                        setPoint45.RoiTuDo_Add3 = (decimal)objSilo.KLRoi;
                        setPoint45.ThoiGianMoCan_Add3 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint45.ThoiGianDongCan_Add3 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint45.ThoiGianTinhLuongRoiThem_Add3 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint45.BuTruKLMT_Add3 = (bool)objSilo.BuTruKLMT;
                        setPoint45.TuDongXNCD_Add3 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Add4":
                        SetPoint setPoint46 = setPoint1;
                        //====
                        setPoint46.SaiSoTren_Add4 = (decimal)objSilo.SaiSoTren;
                        setPoint46.SaiSoDuoi_Add4 = (decimal)objSilo.SaiSoDuoi;
                        setPoint46.RoiTuDo_Add4 = (decimal)objSilo.KLRoi;
                        setPoint46.ThoiGianMoCan_Add4 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint46.ThoiGianDongCan_Add4 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint46.ThoiGianTinhLuongRoiThem_Add4 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint46.BuTruKLMT_Add4 = (bool)objSilo.BuTruKLMT;
                        setPoint46.TuDongXNCD_Add4 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Add5":
                        SetPoint setPoint47 = setPoint1;
                        //====
                        setPoint47.SaiSoTren_Add5 = (decimal)objSilo.SaiSoTren;
                        setPoint47.SaiSoDuoi_Add5 = (decimal)objSilo.SaiSoDuoi;
                        setPoint47.RoiTuDo_Add5 = (decimal)objSilo.KLRoi;
                        setPoint47.ThoiGianMoCan_Add5 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint47.ThoiGianDongCan_Add5 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint47.ThoiGianTinhLuongRoiThem_Add5 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint47.BuTruKLMT_Add5 = (bool)objSilo.BuTruKLMT;
                        setPoint47.TuDongXNCD_Add5 = (bool)objSilo.TuDongXNCD;
                        continue;
                    case "Add6":
                        SetPoint setPoint48 = setPoint1;
                        //====
                        setPoint48.SaiSoTren_Add6 = (decimal)objSilo.SaiSoTren;
                        setPoint48.SaiSoDuoi_Add6 = (decimal)objSilo.SaiSoDuoi;
                        setPoint48.RoiTuDo_Add6 = (decimal)objSilo.KLRoi;
                        setPoint48.ThoiGianMoCan_Add6 = (decimal)objSilo.TGNhapNhaOn;
                        setPoint48.ThoiGianDongCan_Add6 = (decimal)objSilo.TGNhapNhaOff;
                        setPoint48.ThoiGianTinhLuongRoiThem_Add6 = (decimal)objSilo.TGKiemTraVatLieuRoi;
                        setPoint48.BuTruKLMT_Add6 = (bool)objSilo.BuTruKLMT;
                        setPoint48.TuDongXNCD_Add6 = (bool)objSilo.TuDongXNCD;
                        continue;

                    default:
                        continue;
                }
            }

        }


        private void SetPointToSendCom(SetPoint _sp, SendingCommand _so)
        {
            _so.XNC_AUT_AGG1 = _sp.TuDongXNCD_Agg1;
            _so.XNC_AUT_AGG2 = _sp.TuDongXNCD_Agg2;
            _so.XNC_AUT_AGG3 = _sp.TuDongXNCD_Agg3;
            _so.XNC_AUT_AGG4 = _sp.TuDongXNCD_Agg4;
            _so.XNC_AUT_AGG5 = _sp.TuDongXNCD_Agg5;
            _so.XNC_AUT_AGG6 = _sp.TuDongXNCD_Agg6;
            _so.XNC_AUT_CE1 = _sp.TuDongXNCD_Ce1;
            _so.XNC_AUT_CE2 = _sp.TuDongXNCD_Ce2;
            _so.XNC_AUT_CE3 = _sp.TuDongXNCD_Ce3;
            _so.XNC_AUT_CE4 = _sp.TuDongXNCD_Ce4;
            _so.XNC_AUT_CE5 = _sp.TuDongXNCD_Ce5;
            _so.XNC_AUT_WA1 = _sp.TuDongXNCD_Wa1;
            _so.XNC_AUT_WA2 = _sp.TuDongXNCD_Wa2;
            _so.XNC_AUT_ADD1 = _sp.TuDongXNCD_Add1;
            _so.XNC_AUT_ADD2 = _sp.TuDongXNCD_Add2;
            _so.XNC_AUT_ADD3 = _sp.TuDongXNCD_Add3;
            _so.XNC_AUT_ADD4 = _sp.TuDongXNCD_Add4;
            _so.XNC_AUT_ADD5 = _sp.TuDongXNCD_Add5;
            _so.XNC_AUT_ADD6 = _sp.TuDongXNCD_Add6;
            _so.GIU_LAI_CAN_AGG1 = _sp.GIU_LAI_CAN_AGG1;
            _so.GIU_LAI_CAN_AGG2 = _sp.GIU_LAI_CAN_AGG2;
            _so.GIU_LAI_CAN_AGG3 = _sp.GIU_LAI_CAN_AGG3;
            _so.GIU_LAI_CAN_AGG4 = _sp.GIU_LAI_CAN_AGG4;
            _so.GIU_LAI_CAN_AGG5 = _sp.GIU_LAI_CAN_AGG5;
            _so.GIU_LAI_CAN_AGG6 = _sp.GIU_LAI_CAN_AGG6;
            _so.GIU_LAI_CAN_CE1 = _sp.GIU_LAI_CAN_CE1;
            _so.GIU_LAI_CAN_CE2 = _sp.GIU_LAI_CAN_CE2;
            _so.GIU_LAI_CAN_WA1 = _sp.GIU_LAI_CAN_WA1;
            _so.GIU_LAI_CAN_WA2 = _sp.GIU_LAI_CAN_WA2;
            _so.GIU_LAI_CAN_ADD1 = _sp.GIU_LAI_CAN_ADD1;
            _so.GIU_LAI_CAN_ADD2 = _sp.GIU_LAI_CAN_ADD2;
            _so.BUTRU_AGG1 = _sp.BuTruKLMT_Agg1;
            _so.BUTRU_AGG2 = _sp.BuTruKLMT_Agg2;
            _so.BUTRU_AGG3 = _sp.BuTruKLMT_Agg3;
            _so.BUTRU_AGG4 = _sp.BuTruKLMT_Agg4;
            _so.BUTRU_AGG5 = _sp.BuTruKLMT_Agg5;
            _so.BUTRU_AGG6 = _sp.BuTruKLMT_Agg6;
            _so.BUTRU_CE1 = _sp.BuTruKLMT_Ce1;
            _so.BUTRU_CE2 = _sp.BuTruKLMT_Ce2;
            _so.BUTRU_CE3 = _sp.BuTruKLMT_Ce3;
            _so.BUTRU_CE4 = _sp.BuTruKLMT_Ce4;
            _so.BUTRU_CE5 = _sp.BuTruKLMT_Ce5;
            _so.BUTRU_WA1 = _sp.BuTruKLMT_Wa1;
            _so.BUTRU_WA2 = _sp.BuTruKLMT_Wa2;
            _so.BUTRU_ADD1 = _sp.BuTruKLMT_Add1;
            _so.BUTRU_ADD2 = _sp.BuTruKLMT_Add2;
            _so.BUTRU_ADD3 = _sp.BuTruKLMT_Add3;
            _so.BUTRU_ADD4 = _sp.BuTruKLMT_Add4;
            _so.BUTRU_ADD5 = _sp.BuTruKLMT_Add5;
            _so.BUTRU_ADD6 = _sp.BuTruKLMT_Add6;
        }
        private void Send_Data_DB_2_To_PLC() // WRITE DATA TO PLC
        {
            List<byte> list = new List<byte>();
            list.Add(this._so.Byte_0);
            list.Add(this._so.Byte_1);
            list.Add(this._so.Byte_2);
            list.Add(this._so.Byte_3);
            list.Add(this._so.Byte_4);
            list.Add(this._so.Byte_5);
            list.Add(this._so.Byte_6);
            byte[] value = list.ToArray();
            this._plcController.WriteBytes(DataType.DataBlock, 21, 0, value);

        }
        private void SendData_DB2_NewTread() //BIT
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_2_To_PLC));
            thread.Name = "DB_2";
            thread.Start();
        }
        private void SendData_DB3_NewTread() //SILO
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_3_To_PLC));
           // thread.Name = "DB_3";
            thread.Start();
        }
        private void SendData_DB4_NewTread() //WEIGH
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_4_To_PLC));
            thread.Name = "DB_4";
            thread.Start();
        }
        //private void SendData_DB4_Update_NewTread() //Bu Tru Me Cuoi
        //{
        //    Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_4_To_PLC_Update));
        //    thread.Name = "DB_4_Update";
        //    thread.Start();
        //}
        private void SendData_DB5_NewTread() //TIMER -SIM -GAUTAI -PC -MIXER
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_5_To_PLC));
            thread.Name = "DB_5";
            thread.Start();
        }
        private void SendData_DB6_NewTread() //BIT
        {
            Thread thread = new Thread(new ThreadStart(this.Send_Data_DB_6_To_PLC));
            thread.Start();
        }

        #endregion
    }
}
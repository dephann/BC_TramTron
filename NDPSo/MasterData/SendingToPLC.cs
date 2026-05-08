using NDPSo.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{

    public class SendingToPLC
    {
        private byte _Byte_0;
        private byte _Byte_1;
        private byte _Byte_2;
        private byte _Byte_3;
        private byte _Byte_4;
        private byte _Byte_5;
        private byte _Byte_6;
        private byte _Byte_7;
        private byte _Byte_8;
        private byte _Byte_9;
        private byte _Byte_10;
        private byte _Byte_11;
        private byte _Byte_12;
        private byte _Byte_13;
        private byte _Byte_14;
        private byte _Byte_15;
        private byte _Byte_16;
        private byte _Byte_17;
        private byte _Byte_18;
        private byte _Byte_19;
        private byte _Byte_20;
        private byte _Byte_21;
        private byte _Byte_22;
        private byte _Byte_23;
        private byte _Byte_24;
        
        private SendingCommand _objSC = new SendingCommand();
        //========================================================DB2 WRITE  BIT
        public byte Byte_0
        {
            get
            {
                this._Byte_0 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.F1_Run,
                    [1] = this._objSC.F2_Pause,
                    [2] = this._objSC.F3_Cancel,
                    [3] = this._objSC.F4_MoPhong,
                    [4] = this._objSC.SW_MAN_AUTO,
                    [5] = this._objSC.SW_XA_COT_LIEU,
                    [6] = this._objSC.SW_NAP_NOI_TRON,
                    [7] = this._objSC.SW_XA_NOI_TRON
                    
                });
                return this._Byte_0;
            }
            set => this._Byte_0 = value;
        }

        public byte Byte_1
        {
            get
            {
                this._Byte_1 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.SW_RUA_NOI_TRON,
                    [1] = this._objSC.NN_BAT_TAT_NOI_TRON,
                    [2] = this._objSC.SW_XA_PHEU_CHO,
                    [3] = this._objSC.NN_DCN,
                    [4] = this._objSC.NN_MCN,
                    [5] = this._objSC.NN_DONG_KEP,
                    [6] = this._objSC.NN_MO_KEP,
                    [7] = this._objSC.NN_RUNG_KEP
                });
                return this._Byte_1;
            }
            set => this._Byte_1 = value;
        }

        public byte Byte_2
        {
            get
            {
                this._Byte_2 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.NN_BAT_TAT_BTX,
                    [1] = this._objSC.NN_BAT_TAT_BTC,
                    [2] = this._objSC.NN_BAT_TAT_VTX,
                    [3] = this._objSC.NN_RUNG_BTC,
                    [4] = this._objSC.FU_AGG1,
                    [5] = this._objSC.PA_AGG1,
                    [6] = this._objSC.NN_AGG1_1,
                    [7] = this._objSC.NN_AGG1_2
                });
                return this._Byte_2;
            }
            set => this._Byte_2 = value;
        }

        public byte Byte_3
        {
            get
            {
                this._Byte_3 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.SW_XA_WAGG1,
                    [1] = this._objSC.FU_AGG2,
                    [2] = this._objSC.PA_AGG2,
                    [3] = this._objSC.NN_AGG2_1,
                    [4] = this._objSC.NN_AGG2_2,
                    [5] = this._objSC.SW_XA_WAGG2,
                    [6] = this._objSC.FU_AGG3,
                    [7] = this._objSC.PA_AGG3
                }); ;
                return this._Byte_3;
            }
            set => this._Byte_3 = value;
        }

        public byte Byte_4
        {
            get
            {
                this._Byte_4 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.NN_AGG3_1,
                    [1] = this._objSC.NN_AGG3_2,
                    [2] = this._objSC.SW_XA_WAGG3,
                    [3] = this._objSC.FU_AGG4,
                    [4] = this._objSC.PA_AGG4,
                    [5] = this._objSC.NN_AGG4_1,
                    [6] = this._objSC.NN_AGG4_2,
                    [7] = this._objSC.SW_XA_WAGG4
                });
                return this._Byte_4;
            }
            set => this._Byte_4 = value;
        }

        public byte Byte_5
        {
            get
            {
                this._Byte_5 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.FU_AGG5,
                    [1] = this._objSC.PA_AGG5,
                    [2] = this._objSC.NN_AGG5_1,
                    [3] = this._objSC.NN_AGG5_2,
                    [4] = this._objSC.SW_XA_WAGG5,
                    [5] = this._objSC.FU_AGG6,
                    [6] = this._objSC.PA_AGG6,
                    [7] = this._objSC.NN_AGG6_1
                });
                return this._Byte_5;
            }
            set => this._Byte_5 = value;
        }

        public byte Byte_6
        {
            get
            {
                this._Byte_6 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.NN_AGG6_2,
                    [1] = this._objSC.SW_XA_WAGG6,
                    [2] = this._objSC.FU_CE1,
                    [3] = this._objSC.F5_RETURN,
                    [4] = this._objSC.SAVED,
                    [5] = this._objSC.ENOUGH_BATCH,
                    [6] = this._objSC.UPDATED,
                    [7] = this._objSC.PA_CE2
                });
                return this._Byte_6;
            }
            set => this._Byte_6 = value;
        }

        public byte Byte_7
        {
            get
            {
                this._Byte_7 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.NN_CE2,
                    [1] = this._objSC.NN_SKSL2,
                    [2] = this._objSC.FU_CE3,
                    [3] = this._objSC.PA_CE3,
                    [4] = this._objSC.NN_CE3,
                    [5] = this._objSC.NN_SKSL3,
                    [6] = this._objSC.SW_XA_WCEM1,
                    [7] = this._objSC.FU_CE4
                });
                return this._Byte_7;
            }
            set => this._Byte_7 = value;
        }

        public byte Byte_8
        {
            get
            {
                this._Byte_8 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.PA_CE4,
                    [1] = this._objSC.NN_CE4,
                    [2] = this._objSC.NN_SKSL4,
                    [3] = this._objSC.FU_CE5,
                    [4] = this._objSC.PA_CE5,
                    [5] = this._objSC.NN_CE5,
                    [6] = this._objSC.NN_SKSL5,
                    [7] = this._objSC.SW_XA_WCEM2
                });
                return this._Byte_8;
            }
            set => this._Byte_8 = value;
        }

        public byte Byte_9
        {
            get
            {
                this._Byte_9 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.FU_WA1,
                    [1] = this._objSC.PA_WA1,
                    [2] = this._objSC.NN_WA1,
                    [3] = this._objSC.SW_XA_WWA1,
                    [4] = this._objSC.FU_WA2,
                    [5] = this._objSC.PA_WA2,
                    [6] = this._objSC.NN_WA2,
                    [7] = this._objSC.SW_XA_WWA2

                });

                return this._Byte_9;
            }
            set => this._Byte_9 = value;
        }
        public byte Byte_10
        {
            get
            {
                this._Byte_10 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.FU_PG1,
                    [1] = this._objSC.PA_PG1,
                    [2] = this._objSC.NN_PG1,
                    [3] = this._objSC.FU_PG2,
                    [4] = this._objSC.PA_PG2,
                    [5] = this._objSC.NN_PG2,
                    [6] = this._objSC.FU_PG3,
                    [7] = this._objSC.PA_PG3

                });

                return this._Byte_10;
            }
            set => this._Byte_10 = value;
        }
        public byte Byte_11
        {
            get
            {
                this._Byte_11 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.NN_PG3,
                    [1] = this._objSC.SW_XA_WADD1,
                    [2] = this._objSC.FU_PG4,
                    [3] = this._objSC.PA_PG4,
                    [4] = this._objSC.NN_PG4,
                    [5] = this._objSC.FU_PG5,
                    [6] = this._objSC.PA_PG5,
                    [7] = this._objSC.NN_PG5

                });

                return this._Byte_11;
            }
            set => this._Byte_11 = value;
        }
        public byte Byte_12
        {
            get
            {
                this._Byte_12 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.FU_PG6,
                    [1] = this._objSC.PA_PG6,
                    [2] = this._objSC.NN_PG6,
                    [3] = this._objSC.SW_XA_WADD2,
                    [4] = this._objSC.NN_ZERO_AGG1,
                    [5] = this._objSC.NN_SPAN_AGG1,
                    [6] = this._objSC.NN_ZERO_AGG2,
                    [7] = this._objSC.NN_SPAN_AGG2

                });

                return this._Byte_12;
            }
            set => this._Byte_12 = value;
        }
        public byte Byte_13
        {
            get
            {
                this._Byte_13 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.NN_ZERO_AGG3,
                    [1] = this._objSC.NN_SPAN_AGG3,
                    [2] = this._objSC.NN_ZERO_AGG4,
                    [3] = this._objSC.NN_SPAN_AGG4,
                    [4] = this._objSC.NN_ZERO_AGG5,
                    [5] = this._objSC.NN_SPAN_AGG5,
                    [6] = this._objSC.NN_ZERO_AGG6,
                    [7] = this._objSC.NN_SPAN_AGG6

                });

                return this._Byte_13;
            }
            set => this._Byte_13 = value;
        }
        public byte Byte_14
        {
            get
            {
                this._Byte_14 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.NN_ZERO_CEM1,
                    [1] = this._objSC.NN_SPAN_CEM1,
                    [2] = this._objSC.NN_ZERO_CEM2,
                    [3] = this._objSC.NN_SPAN_CEM2,
                    [4] = this._objSC.NN_ZERO_WAT1,
                    [5] = this._objSC.NN_SPAN_WAT1,
                    [6] = this._objSC.NN_ZERO_WAT2,
                    [7] = this._objSC.NN_SPAN_WAT2

                });

                return this._Byte_14;
            }
            set => this._Byte_14 = value;
        }
        public byte Byte_15
        {
            get
            {
                this._Byte_15 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.NN_ZERO_ADD1,
                    [1] = this._objSC.NN_SPAN_ADD1,
                    [2] = this._objSC.NN_ZERO_ADD2,
                    [3] = this._objSC.NN_SPAN_ADD2,
                    [4] = this._objSC.SPAN_ADD1,
                    [5] = this._objSC.SPAN_ADD2,
                    [6] = this._objSC.SPAN_ADD3,
                    [7] = this._objSC.SPAN_ADD4,

                });

                return this._Byte_15;
            }
            set => this._Byte_15 = value;
        }
        public byte Byte_16
        {
            get
            {
                this._Byte_16 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.SPAN_ADD5,
                    [1] = this._objSC.SPAN_ADD6,
                    [2] = this._objSC.NN_RUNG_PC,
                    [3] = this._objSC.NN_RUNG_AGG1,
                    [4] = this._objSC.NN_RUNG_AGG2,
                    [5] = this._objSC.NN_RUNG_AGG3,
                    [6] = this._objSC.NN_RUNG_AGG4,
                    [7] = this._objSC.NN_RUNG_AGG5,
                    

                });

                return this._Byte_16;
            }
            set => this._Byte_16 = value;
        }

        public byte Byte_17
        {
            get
            {
                this._Byte_17 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.NN_RUNG_AGG6,
                    [1] = this._objSC.NN_RUNG_CE1,
                    [2] = this._objSC.NN_RUNG_CE2,
                    [3] = this._objSC.SW_SK_SILO1,
                    [4] = this._objSC.SW_SK_SILO2,
                    [5] = this._objSC.SW_SK_SILO3,
                    [6] = this._objSC.SW_SK_SILO4,
                    [7] = this._objSC.SW_SK_SILO5


                });

                return this._Byte_17;
            }
            set => this._Byte_17 = value;
        }
        public byte Byte_18
        {
            get
            {
                this._Byte_18 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.NN_GAU_LEN,
                    [1] = this._objSC.NN_DUNG_GAU,
                    [2] = this._objSC.NN_GAU_XUONG,
                    [3] = this._objSC.SW_BAT_PG_NGOAI,
                   /* [4] = this._objSC.XAC_NHAN_CAN_DU,
                    [5] = this._objSC.XNC_AUT_AGG1,
                    [6] = this._objSC.XNC_AUT_AGG2,
                    [7] = this._objSC.XNC_AUT_AGG3*/

                });

                return this._Byte_18;
            }
            set => this._Byte_18 = value;
        }
        public byte Byte_19
        {
            get
            {
                this._Byte_19 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.XNC_AUT_AGG4,
                    [1] = this._objSC.XNC_AUT_AGG5,
                    [2] = this._objSC.XNC_AUT_AGG6,
                    [3] = this._objSC.XNC_AUT_CE1,
                    [4] = this._objSC.XNC_AUT_CE2,
                    [5] = this._objSC.XNC_AUT_CE3,
                    [6] = this._objSC.XNC_AUT_CE4,
                    [7] = this._objSC.XNC_AUT_CE5,

                });

                return this._Byte_19;
            }
            set => this._Byte_19 = value;
        }
        public byte Byte_20
        {
            get
            {
                this._Byte_20 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.XNC_AUT_WA1,
                    [1] = this._objSC.XNC_AUT_WA2,
                    [2] = this._objSC.XNC_AUT_ADD1,
                    [3] = this._objSC.XNC_AUT_ADD2,
                    [4] = this._objSC.XNC_AUT_ADD3,
                    [5] = this._objSC.XNC_AUT_ADD4,
                    [6] = this._objSC.XNC_AUT_ADD5,
                    [7] = this._objSC.XNC_AUT_ADD6,

                });

                return this._Byte_20;
            }
            set => this._Byte_20 = value;
        }
        public byte Byte_21
        {
            get
            {
                this._Byte_21 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.GIU_LAI_CAN_AGG1,
                    [1] = this._objSC.GIU_LAI_CAN_AGG2,
                    [2] = this._objSC.GIU_LAI_CAN_AGG3,
                    [3] = this._objSC.GIU_LAI_CAN_AGG4,
                    [4] = this._objSC.GIU_LAI_CAN_AGG5,
                    [5] = this._objSC.GIU_LAI_CAN_AGG6,
                    [6] = this._objSC.GIU_LAI_CAN_CE1,
                    [7] = this._objSC.GIU_LAI_CAN_CE2,

                });

                return this._Byte_21;
            }
            set => this._Byte_21 = value;
        }
        public byte Byte_22
        {
            get
            {
                this._Byte_22 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.GIU_LAI_CAN_WA1,
                    [1] = this._objSC.GIU_LAI_CAN_WA2,
                    [2] = this._objSC.GIU_LAI_CAN_ADD1,
                    [3] = this._objSC.GIU_LAI_CAN_ADD2,
                    [4] = this._objSC.BUTRU_AGG1,
                    [5] = this._objSC.BUTRU_AGG2,
                    [6] = this._objSC.BUTRU_AGG3,
                    [7] = this._objSC.BUTRU_AGG4,

                });

                return this._Byte_22;
            }
            set => this._Byte_22 = value;
        }
        public byte Byte_23
        {
            get
            {
                this._Byte_23 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.BUTRU_AGG5,
                    [1] = this._objSC.BUTRU_AGG6,
                    [2] = this._objSC.BUTRU_CE1,
                    [3] = this._objSC.BUTRU_CE2,
                    [4] = this._objSC.BUTRU_CE3,
                    [5] = this._objSC.BUTRU_CE4,
                    [6] = this._objSC.BUTRU_CE5,
                    [7] = this._objSC.BUTRU_WA1,

                });

                return this._Byte_23;
            }
            set => this._Byte_23 = value;
        }
        public byte Byte_24
        {
            get
            {
                this._Byte_24 = Converter.ConvertBitArrayToByte(new BitArray(8)
                {
                    [0] = this._objSC.BUTRU_WA2,
                    [1] = this._objSC.BUTRU_ADD1,
                    [2] = this._objSC.BUTRU_ADD2,
                    [3] = this._objSC.BUTRU_ADD3,
                    [4] = this._objSC.BUTRU_ADD4,
                    [5] = this._objSC.BUTRU_ADD5,
                    [6] = this._objSC.BUTRU_ADD6
                    

                });

                return this._Byte_24;
            }
            set => this._Byte_24 = value;
        }
        public int SIM_WeiAgg1 { get; set; }

        public int SIM_WeiAgg2 { get; set; }

        public int SIM_WeiAgg3 { get; set; }

        public int SIM_WeiAgg4 { get; set; }

        public int SIM_WeiAgg5 { get; set; }

        public int SIM_WeiCe1 { get; set; }

        public int SIM_WeiCe2 { get; set; }

        public int SIM_WeiWa1 { get; set; }

        public int SIM_WeiWa2 { get; set; }

        public int SIM_WeiAdd1 { get; set; }

        public int SIM_WeiAdd2 { get; set; }

        public int ThemBotNuoc { get; set; }

        public int DeNuocTrenCan { get; set; }

        public int SoMeDis { get; set; }

        public int ThemBotNuoc2 { get; set; }

        public int DeNuocTrenCan2 { get; set; }

        public int LogicCanCe1 { get; set; }

        public int LogicCanCe2 { get; set; }

        public int LogicCanAdd1 { get; set; }

       
        public int TiLeNoiTron1 { get; set; }

        public int TiLeNoiTron2 { get; set; }
        //================================================
        
        public Double KL_Chinh0_Agg { get; set; }
        public Double KL_ChinhTai_Agg { get; set; }
        public Double KL_Chinh0_Ce { get; set; }
        public Double KL_ChinhTai_Ce { get; set; }
        public Double KL_Chinh0_Wa { get; set; }
        public Double KL_ChinhTai_Wa { get; set; }

        public SendingCommand SendingCommand
        {
            get => this._objSC;
            set => this._objSC = value;
        }

        public void ResetValues() => this._objSC.ResetValues();
    }
}

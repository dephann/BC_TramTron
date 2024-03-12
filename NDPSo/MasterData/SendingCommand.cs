using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class SendingCommand
    {
        public bool F1_Run { get; set; } //0.0

        public bool F2_Pause { get; set; } //0.1

        public bool F3_Cancel { get; set; } //0.2

        public bool F4_MoPhong { get; set; } //0.3

        public bool F5_TangMe { get; set; }

        public bool F6_GiamMe { get; set; }

        //==============================================================DB2 WRITE BIT

        public bool SW_MAN_AUTO { get; set; } //0.4
        public bool SW_XA_COT_LIEU { get; set; } //0.5
        public bool SW_NAP_NOI_TRON { get; set; } //0.6
        public bool SW_XA_NOI_TRON { get; set; } //0.7
        public bool SW_RUA_NOI_TRON { get; set; } //1.0
        public bool NN_BAT_TAT_NOI_TRON { get; set; } //1.1
        public bool SW_XA_PHEU_CHO { get; set; } //1.2
        public bool NN_DCN { get; set; } //1.3
        public bool NN_MCN { get; set; } //1.4
        public bool NN_DONG_KEP { get; set; } //1.5
        public bool NN_MO_KEP { get; set; } //1.6
        public bool NN_RUNG_KEP { get; set; } //1.7
        public bool NN_BAT_TAT_BTX { get; set; } //2.0
        public bool NN_BAT_TAT_BTC { get; set; } //2.1
        public bool NN_BAT_TAT_VTX { get; set; } //2.2
        public bool NN_RUNG_BTC { get; set; } //2.3
        public bool FU_AGG1 { get; set; } //2.4
        public bool PA_AGG1 { get; set; } //2.5
        public bool NN_AGG1_1 { get; set; } //2.6
        public bool NN_AGG1_2 { get; set; } //2.7
        public bool SW_XA_WAGG1 { get; set; } //3.0
        public bool FU_AGG2 { get; set; } //3.1
        public bool PA_AGG2 { get; set; } //3.2
        public bool NN_AGG2_1 { get; set; } //3.3
        public bool NN_AGG2_2 { get; set; } //3.4
        public bool SW_XA_WAGG2 { get; set; } //3.5
        public bool FU_AGG3 { get; set; } //3.6
        public bool PA_AGG3 { get; set; } //3.7
        public bool NN_AGG3_1 { get; set; } //4.0
        public bool NN_AGG3_2 { get; set; } //4.1
        public bool SW_XA_WAGG3 { get; set; } //4.2
        public bool FU_AGG4 { get; set; } //4.3
        public bool PA_AGG4 { get; set; } //4.4
        public bool NN_AGG4_1 { get; set; } //4.5
        public bool NN_AGG4_2 { get; set; } //4.6
        public bool SW_XA_WAGG4 { get; set; } //4.7
        public bool FU_AGG5 { get; set; } //5.0
        public bool PA_AGG5 { get; set; } //5.1
        public bool NN_AGG5_1 { get; set; } //5.2
        public bool NN_AGG5_2 { get; set; } //5.3
        public bool SW_XA_WAGG5 { get; set; } //5.4
        public bool FU_AGG6 { get; set; } //5.5
        public bool PA_AGG6 { get; set; } //5.6
        public bool NN_AGG6_1 { get; set; } //5.7
        public bool NN_AGG6_2 { get; set; } //6.0
        public bool SW_XA_WAGG6 { get; set; } //6.1
        public bool FU_CE1 { get; set; } //6.2
        public bool PA_CE1 { get; set; } //6.3
        public bool NN_CE1 { get; set; } //6.4
        public bool NN_SKSL1 { get; set; } //6.5
        public bool FU_CE2 { get; set; } //6.6
        public bool PA_CE2 { get; set; } //6.7
        public bool NN_CE2 { get; set; } //7.0
        public bool NN_SKSL2 { get; set; } //7.1
        public bool FU_CE3 { get; set; } //7.2
        public bool PA_CE3 { get; set; } //7.3
        public bool NN_CE3 { get; set; } //7.4
        public bool NN_SKSL3 { get; set; } //7.5
        public bool SW_XA_WCEM1 { get; set; } //7.6
        public bool FU_CE4 { get; set; } //7.7
        public bool PA_CE4 { get; set; } //8.0
        public bool NN_CE4 { get; set; } //8.1
        public bool NN_SKSL4 { get; set; } //8.2
        public bool FU_CE5 { get; set; } //8.3
        public bool PA_CE5 { get; set; } //8.4
        public bool NN_CE5 { get; set; } //8.5
        public bool NN_SKSL5 { get; set; } //8.6
        public bool SW_XA_WCEM2 { get; set; } //8.7
        public bool FU_WA1 { get; set; } //9.0
        public bool PA_WA1 { get; set; } //9.1
        public bool NN_WA1 { get; set; } //9.2
        public bool SW_XA_WWA1 { get; set; } //9.3
        public bool FU_WA2 { get; set; } //9.4
        public bool PA_WA2 { get; set; } //9.5
        public bool NN_WA2 { get; set; } //9.6
        public bool SW_XA_WWA2 { get; set; } //9.7
        public bool FU_PG1 { get; set; } //10.0
        public bool PA_PG1 { get; set; } //10.1
        public bool NN_PG1 { get; set; } //10.2
        public bool FU_PG2 { get; set; } //10.3
        public bool PA_PG2 { get; set; } //10.4
        public bool NN_PG2 { get; set; } //10.5
        public bool FU_PG3 { get; set; } //10.6
        public bool PA_PG3 { get; set; } //10.7
        public bool NN_PG3 { get; set; } //11.0
        public bool SW_XA_WADD1 { get; set; } //11.1
        public bool FU_PG4 { get; set; } //11.2
        public bool PA_PG4 { get; set; } //11.3
        public bool NN_PG4 { get; set; } //11.4
        public bool FU_PG5 { get; set; } //11.5
        public bool PA_PG5 { get; set; } //11.6
        public bool NN_PG5 { get; set; } //11.7
        public bool FU_PG6 { get; set; } //12.0
        public bool PA_PG6 { get; set; } //12.1
        public bool NN_PG6 { get; set; } //12.2
        public bool SW_XA_WADD2 { get; set; } //12.3
        public bool NN_ZERO_AGG1 { get; set; } //12.4
        public bool NN_SPAN_AGG1 { get; set; } //12.5
        public bool NN_ZERO_AGG2 { get; set; } //12.6
        public bool NN_SPAN_AGG2 { get; set; } //12.7
        public bool NN_ZERO_AGG3 { get; set; } //13.0
        public bool NN_SPAN_AGG3 { get; set; } //13.1
        public bool NN_ZERO_AGG4 { get; set; } //13.2
        public bool NN_SPAN_AGG4 { get; set; } //13.3
        public bool NN_ZERO_AGG5 { get; set; } //13.4
        public bool NN_SPAN_AGG5 { get; set; } //13.5
        public bool NN_ZERO_AGG6 { get; set; } //13.6
        public bool NN_SPAN_AGG6 { get; set; } //13.7
        public bool NN_ZERO_CEM1 { get; set; } //14.0
        public bool NN_SPAN_CEM1 { get; set; } //14.1
        public bool NN_ZERO_CEM2 { get; set; } //14.2
        public bool NN_SPAN_CEM2 { get; set; } //14.3
        public bool NN_ZERO_WAT1 { get; set; } //14.4
        public bool NN_SPAN_WAT1 { get; set; } //14.5
        public bool NN_ZERO_WAT2 { get; set; } //14.6
        public bool NN_SPAN_WAT2 { get; set; } //14.7
        public bool NN_ZERO_ADD1 { get; set; } //15.0
        public bool NN_SPAN_ADD1 { get; set; } //15.1
        public bool NN_ZERO_ADD2 { get; set; } //15.2
        public bool NN_SPAN_ADD2 { get; set; } //15.3
        public bool SPAN_ADD1 { get; set; } //15.4
        public bool SPAN_ADD2 { get; set; } //15.5
        public bool SPAN_ADD3 { get; set; } //15.6
        public bool SPAN_ADD4 { get; set; } //15.7
        public bool SPAN_ADD5 { get; set; } //16.0
        public bool SPAN_ADD6 { get; set; } //16.1
        public bool NN_RUNG_PC { get; set; } //16.2
        public bool NN_RUNG_AGG1 { get; set; } //16.3
        public bool NN_RUNG_AGG2 { get; set; } //16.4
        public bool NN_RUNG_AGG3 { get; set; } //16.5
        public bool NN_RUNG_AGG4 { get; set; } //16.6
        public bool NN_RUNG_AGG5 { get; set; } //16.7
        public bool NN_RUNG_AGG6 { get; set; } //17.0
        public bool NN_RUNG_CE1 { get; set; } //17.1
        public bool NN_RUNG_CE2 { get; set; } //17.2
        public bool SW_SK_SILO1 { get; set; } //17.3
        public bool SW_SK_SILO2 { get; set; } //17.4
        public bool SW_SK_SILO3 { get; set; } //17.5
        public bool SW_SK_SILO4 { get; set; } //17.6
        public bool SW_SK_SILO5 { get; set; } //17.7
        public bool NN_GAU_LEN { get; set; } //18.0
        public bool NN_DUNG_GAU { get; set; } //18.1
        public bool NN_GAU_XUONG { get; set; } //18.2

        //==============================================================
        //==============================================================DB8 WRITE BIT REPORT
        public bool SAVE_REPORT { get; set; } //DB8 0.0

        //public SendingCommand() => this.ResetValues();

        public void ResetValues()
        {
            this.F1_Run = false;
            this.F2_Pause = false;
            this.F3_Cancel = false;
            this.F4_MoPhong = false;
            //=======================================
            //this.SW_CheDoHeThong = false;


        }
    }
}

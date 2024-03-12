using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.MasterData
{
    public class InitOnline
    {
        public int PhieuTronID { get; set; }

        public string MaPhieuTron { get; set; }

        public Decimal SLMeDuTinh { get; set; }

        public Decimal SLMeDaTron { get; set; }

        public Decimal SiloAgg1_KLCaiDat { get; set; }

        public Decimal SiloAgg1_KLCanCan { get; set; }

        public Decimal SiloAgg1_DoAm { get; set; }

        public Decimal SiloAgg1_DoHut { get; set; }

        public Decimal SiloAgg2_KLCaiDat { get; set; }

        public Decimal SiloAgg2_KLCanCan { get; set; }

        public Decimal SiloAgg2_DoAm { get; set; }

        public Decimal SiloAgg2_DoHut { get; set; }

        public Decimal SiloAgg3_KLCaiDat { get; set; }

        public Decimal SiloAgg3_KLCanCan { get; set; }

        public Decimal SiloAgg3_DoAm { get; set; }

        public Decimal SiloAgg3_DoHut { get; set; }

        public Decimal SiloAgg4_KLCaiDat { get; set; }

        public Decimal SiloAgg4_KLCanCan { get; set; }

        public Decimal SiloAgg4_DoAm { get; set; }

        public Decimal SiloAgg4_DoHut { get; set; }

        public Decimal SiloAgg5_KLCaiDat { get; set; }

        public Decimal SiloAgg5_KLCanCan { get; set; }

        public Decimal SiloAgg5_DoAm { get; set; }

        public Decimal SiloAgg5_DoHut { get; set; }

        public Decimal SiloCe1_KLCaiDat { get; set; }

        public Decimal SiloCe1_KLCanCan { get; set; }

        public Decimal SiloCe2_KLCaiDat { get; set; }

        public Decimal SiloCe2_KLCanCan { get; set; }

        public Decimal SiloCe3_KLCaiDat { get; set; }

        public Decimal SiloCe3_KLCanCan { get; set; }

        public Decimal SiloCe4_KLCaiDat { get; set; }

        public Decimal SiloCe4_KLCanCan { get; set; }

        public Decimal SiloCe5_KLCaiDat { get; set; }

        public Decimal SiloCe5_KLCanCan { get; set; }

        public Decimal SiloCe6_KLCaiDat { get; set; }

        public Decimal SiloCe6_KLCanCan { get; set; }

        public Decimal SiloWa1_KLCaiDat { get; set; }

        public Decimal SiloWa1_KLCanCan { get; set; }

        public Decimal SiloWa2_KLCaiDat { get; set; }

        public Decimal SiloWa2_KLCanCan { get; set; }

        public Decimal SiloAdd1_KLCaiDat { get; set; }

        public Decimal SiloAdd1_KLCanCan { get; set; }

        public Decimal SiloAdd2_KLCaiDat { get; set; }

        public Decimal SiloAdd2_KLCanCan { get; set; }

        public Decimal SiloAdd3_KLCaiDat { get; set; }

        public Decimal SiloAdd3_KLCanCan { get; set; }

        public Decimal SiloAdd4_KLCaiDat { get; set; }

        public Decimal SiloAdd4_KLCanCan { get; set; }

        public Decimal SiloAdd5_KLCaiDat { get; set; }

        public Decimal SiloAdd5_KLCanCan { get; set; }

        public Decimal SiloAdd6_KLCaiDat { get; set; }

        public Decimal SiloAdd6_KLCanCan { get; set; }

        public Decimal SiloAdd7_KLCaiDat { get; set; }

        public Decimal SiloAdd7_KLCanCan { get; set; }

        public Decimal SiloAdd8_KLCaiDat { get; set; }

        public Decimal SiloAdd8_KLCanCan { get; set; }

        public void ResetData()
        {
            this.PhieuTronID = 0;
            this.MaPhieuTron = string.Empty;
            this.SLMeDuTinh = 0M;
            this.SLMeDaTron = 0M;
            this.SiloAgg1_KLCaiDat = 0M;
            this.SiloAgg1_KLCanCan = 0M;
            this.SiloAgg1_DoAm = 0M;
            this.SiloAgg1_DoHut = 0M;
            this.SiloAgg2_KLCaiDat = 0M;
            this.SiloAgg2_KLCanCan = 0M;
            this.SiloAgg2_DoAm = 0M;
            this.SiloAgg2_DoHut = 0M;
            this.SiloAgg3_KLCaiDat = 0M;
            this.SiloAgg3_KLCanCan = 0M;
            this.SiloAgg3_DoAm = 0M;
            this.SiloAgg3_DoHut = 0M;
            this.SiloAgg4_KLCaiDat = 0M;
            this.SiloAgg4_KLCanCan = 0M;
            this.SiloAgg4_DoAm = 0M;
            this.SiloAgg4_DoHut = 0M;
            this.SiloAgg5_KLCaiDat = 0M;
            this.SiloAgg5_KLCanCan = 0M;
            this.SiloAgg5_DoAm = 0M;
            this.SiloAgg5_DoHut = 0M;
            this.SiloCe1_KLCaiDat = 0M;
            this.SiloCe1_KLCanCan = 0M;
            this.SiloCe2_KLCaiDat = 0M;
            this.SiloCe2_KLCanCan = 0M;
            this.SiloCe3_KLCaiDat = 0M;
            this.SiloCe3_KLCanCan = 0M;
            this.SiloCe4_KLCaiDat = 0M;
            this.SiloCe4_KLCanCan = 0M;
            this.SiloCe5_KLCaiDat = 0M;
            this.SiloCe5_KLCanCan = 0M;
            this.SiloCe6_KLCaiDat = 0M;
            this.SiloCe6_KLCanCan = 0M;
            this.SiloWa1_KLCaiDat = 0M;
            this.SiloWa1_KLCanCan = 0M;
            this.SiloWa2_KLCaiDat = 0M;
            this.SiloWa2_KLCanCan = 0M;
            this.SiloAdd1_KLCaiDat = 0M;
            this.SiloAdd1_KLCanCan = 0M;
            this.SiloAdd2_KLCaiDat = 0M;
            this.SiloAdd2_KLCanCan = 0M;
            this.SiloAdd3_KLCaiDat = 0M;
            this.SiloAdd3_KLCanCan = 0M;
            this.SiloAdd4_KLCaiDat = 0M;
            this.SiloAdd4_KLCanCan = 0M;
            this.SiloAdd5_KLCaiDat = 0M;
            this.SiloAdd5_KLCanCan = 0M;
            this.SiloAdd6_KLCaiDat = 0M;
            this.SiloAdd6_KLCanCan = 0M;
            this.SiloAdd7_KLCaiDat = 0M;
            this.SiloAdd7_KLCanCan = 0M;
            this.SiloAdd8_KLCaiDat = 0M;
            this.SiloAdd8_KLCanCan = 0M;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    class ObjVatTu
    {
        public string MaSilo { get; set; }
        public string TenVatTu { get; set; }
        public decimal? KLThuc { get; set; }
        public decimal? DinhMuc { get; set; }
        public decimal? SaiSo { get; set; }
        public decimal? PerSaiSo { get; set; }

        public ObjVatTu (string maSilo, string ten, decimal? klthucte, decimal? dinhmuc, decimal? saiso, decimal? persaiso)
        {
            MaSilo = maSilo;
            TenVatTu = ten;
            KLThuc = klthucte;
            DinhMuc = dinhmuc;
            SaiSo = saiso;
            PerSaiSo = persaiso;
        }
    }
}

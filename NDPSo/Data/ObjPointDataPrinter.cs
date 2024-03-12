using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Data
{
    [DataContract]
    class ObjPointDataPrinter : ObjectBase
    {
        [DataMember]
        public string NameDataPrinter { get; set; }
        [DataMember]
        public string DataPrinter_Stus { get; set; }
        [DataMember]
        public int DataPrinter_X { get; set; }
        [DataMember]
        public int DataPrinter_y { get; set; }

    }
}

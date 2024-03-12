using NDPSo.Utils;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.PLCModule
{
    public class PLCSingleIns
    {
        private static Plc instance;
        private static readonly object lockObject = new object();
        private PLCSingleIns() { }
        public static Plc Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        // Thay đổi các tham số kết nối phù hợp với PLC của bạn
                        instance = new Plc(CpuType.S71200, ConfigManager.TramTronConfig.LANIP, 0, 1);
                        instance.Open();
                    }
                    return instance;
                }
            }
        }
    }   
}

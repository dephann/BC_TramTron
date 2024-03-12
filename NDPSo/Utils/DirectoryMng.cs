using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Utils
{
    public class DirectoryMng
    {
        public static void CreateDirectoryWithCheckExist(string strPath)
        {
            if (Directory.Exists(strPath))
                return;
            Directory.CreateDirectory(strPath);
        }
    }
}

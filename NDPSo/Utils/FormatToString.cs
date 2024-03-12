using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Utils
{
    public class FormatToString
    {
        public static string DateTimeToString(DateTime dateTime)
        {
            try
            {
                return dateTime.Day.ToString() + "/" + dateTime.Month.ToString() + "/" + dateTime.Year.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

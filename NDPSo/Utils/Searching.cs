using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NDPSo.Utils
{
    public class Searching
    {
        public static DateTime Build_StartDateTime(DateTime datValue)
        {
            if (datValue == DateTime.MinValue)
                return SqlDateTime.MinValue.Value;
            datValue = datValue.AddSeconds(-(double)datValue.Second);
            datValue = datValue.AddMinutes(-(double)datValue.Minute);
            datValue = datValue.AddHours(-(double)datValue.Hour);
            return datValue;
        }
        public static DateTime BuildNew_StartDateTime(DateTime datValue, TimeSpan timeValue)
        {
            if (datValue == DateTime.MinValue)
                return SqlDateTime.MinValue.Value;

            datValue = datValue.Date;
            datValue = datValue.Add(timeValue);
            return datValue;
        }

        public static DateTime Build_EndDateTime(DateTime datValue)
        {
            if (datValue == DateTime.MinValue)
                return SqlDateTime.MaxValue.Value;
            datValue = datValue.AddSeconds((double)(60 - datValue.Second));
            datValue = datValue.AddMinutes((double)(60 - datValue.Minute));
            datValue = datValue.AddHours((double)(24 - datValue.Hour));
            return datValue;
        }
        public static DateTime BuildNew_EndDateTime(DateTime datValue, TimeSpan timeValue)
        {
            if (datValue == DateTime.MinValue)
                return SqlDateTime.MaxValue.Value;
            datValue = datValue.Date;
            datValue = datValue.Add(timeValue);
            return datValue;
        }
    }
}

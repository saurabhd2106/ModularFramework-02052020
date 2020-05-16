using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs.Utils
{
    public static class DatetTimeUtils
    {
        public static string GetCurrentDateAndTime()
        {
            return DateTime.Now.ToString("yyyy’-‘MM’-‘dd’T’HH’-’mm’-’ss");

        }

        public static string GetCurrentDateAndTime(string dateFormat)
        {
            return DateTime.Now.ToString(dateFormat);

        }

    }
}

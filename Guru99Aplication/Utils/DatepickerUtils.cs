using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99Aplication.Utils
{
    public class DatepickerUtils
    {
        public void SelectDateFromDatepicker()
        {
            string date = "05-15-2020";

            string[] dateArray = date.Split('-');

            string month = dateArray[0];
            string day = dateArray[1];
            string year = dateArray[2];



        }
    }
}

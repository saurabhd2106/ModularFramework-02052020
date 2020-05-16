using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Utils;
using NUnit.Framework;

namespace Guru99ApplicationTest.Utils
{
    public class TestDataFromExcel
    {

        public static IEnumerable VerifyDataFromExcelsheet()
        {
            DataTable testData = ExcelDriverUtils.ReadDataFromExcel("C:/Users/Saurabh Dhingra/source/repos/Modular Framework 02052020/Guru99ApplicationTest/TestData/TestData.xlsx", "TestData");

            foreach (DataRow row in testData.Rows)
            {
                yield return new TestCaseData(row.ItemArray);

            }

        }
    }
}

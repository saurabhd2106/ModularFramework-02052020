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
    public class TestDataFromDatabase
    {

        public static IEnumerable VerifyDataFromDatabase()
        {
            DatabaseUtils dbConnector = new DatabaseUtils("localhost", "testdata", "root", "Gurgaon21!!");
            dbConnector.OpenConnection();

            string sqlQuery = "select * from userData";

            DataTable testData = dbConnector.ExecuteSelectSqlQuery(sqlQuery);

            dbConnector.CloseConnection();

            foreach (DataRow row in testData.Rows)
            {
                yield return new TestCaseData(row.ItemArray);

            }

        }

    }
}

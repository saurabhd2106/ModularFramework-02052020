using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;

namespace CommonLibs.Utils
{
    public class ExcelDriverUtils
    {
        public static DataTable ReadDataFromExcel(string filename, string sheetname)
        {
            _ = filename.Trim();

            //Read Excel sheet as a stream
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);


            //Loads the stream in an Excel Reader
            IExcelDataReader excelReader;

            if (filename.EndsWith(".xls") || filename.EndsWith(".xlsx") || filename.EndsWith(".csv"))
            {
                excelReader = ExcelReaderFactory.CreateReader(stream);

            }
            else
            {
                throw new Exception("Invalid File Type");
            }


            //Load the data in the excel reader as Dataset
            DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });

            DataTableCollection allTables = result.Tables;

            //Get the data in a DataTable
            DataTable dataTable = allTables[sheetname];

            return dataTable;
        }
    }
}

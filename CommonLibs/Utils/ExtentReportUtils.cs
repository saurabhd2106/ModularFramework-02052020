using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace CommonLibs.Utils
{

    public class ExtentReportUtils
    {
        private ExtentHtmlReporter htmlReporter;
        private ExtentReports extentReports;

        private ExtentTest extentTest;

        public ExtentReportUtils(string htmlReportPath)
        {
            htmlReporter = new ExtentHtmlReporter(htmlReportPath);
            extentReports = new ExtentReports();

            extentReports.AttachReporter(htmlReporter);
        }

        public void CreateATestcase(string testcaseName)
        {

            extentTest = extentReports.CreateTest(testcaseName);

        }

        public void AddTestLog(Status status, string comments)
        {
            extentTest.Log(status, comments);

        }

        public void AddScreenshotInReport(string filename)
        {
            extentTest.AddScreenCaptureFromPath(filename);
        }

        public void FlushTheReport()
        {
            extentReports.Flush();
        }

    }
}

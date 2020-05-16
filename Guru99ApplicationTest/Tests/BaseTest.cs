using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using CommonLibs.Implementations;
using CommonLibs.Utils;
using Guru99Aplication.Pages;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Guru99ApplicationTest.Tests
{
    public class BaseTest
    {
        public CommonDriver cmnDriver;

        public LoginPage loginPage;
        public HomePage homePage;

        IWebDriver driver;
        public string BaseUrl;

        public ExtentReportUtils ExtentReport;

        public ScreenshotControl screenshotControl;
        public string currentWorkingDirectory;
        public string executionStartTime;

        [OneTimeSetUp]
        public void PreSetup()
        {
            currentWorkingDirectory = ConfigurationManager.AppSettings["currentWorkingDirectory"];
            executionStartTime = DatetTimeUtils.GetCurrentDateAndTime();
            string reportPath = $"{currentWorkingDirectory}{ConfigurationManager.AppSettings["reportPath"]}/{executionStartTime}/";
            ExtentReport = new ExtentReportUtils(reportPath);

            

        }


        [SetUp]
        public void Setup()
        {
            ExtentReport.CreateATestcase("Setup - Invoke the browser and navigate to base URL");

            string browserType = ConfigurationManager.AppSettings["browserType"];
            ExtentReport.AddTestLog(Status.Info ,"Browser Type initialized - " + browserType);

            BaseUrl = ConfigurationManager.AppSettings["baseUrl"];
            ExtentReport.AddTestLog(Status.Info, "Base URL - " + BaseUrl);


            cmnDriver = new CommonDriver(browserType);

            ExtentReport.AddTestLog(Status.Info, "Browser invoked");

            cmnDriver.ElementDetectionTimeout = Int32.Parse(ConfigurationManager.AppSettings["elementDetectionTimeout"]);
            ExtentReport.AddTestLog(Status.Info, "Implicit Wait Defined - "+ Int32.Parse(ConfigurationManager.AppSettings["elementDetectionTimeout"]));

            cmnDriver.PageLoadTimeout = Int32.Parse(ConfigurationManager.AppSettings["pageLoadTimeout"]);
            ExtentReport.AddTestLog(Status.Info, "Implicit Wait Defined - " + Int32.Parse(ConfigurationManager.AppSettings["pageLoadTimeout"]));

            cmnDriver.NavigateToFirstUrl(BaseUrl);
            driver = cmnDriver.Driver;
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);

            screenshotControl = new ScreenshotControl(driver);
        }

        [TearDown]
        public void CleanUp()
        {
            
            try
            {
                if(TestContext.CurrentContext.Result.Outcome ==  ResultState.Failure)
                {
                    ExtentReport.AddTestLog(Status.Fail, "Test case failed because one or more test step failed");

                    string screenshotFolder = ConfigurationManager.AppSettings["screenshotFolder"];

                    string screenshotExecutionTime = DatetTimeUtils.GetCurrentDateAndTime() ;
                    string screenshotFilename = $"{currentWorkingDirectory}{screenshotFolder}/test-{screenshotExecutionTime}.jpeg";

                    screenshotControl.CaptureAndSaveScreenshot(screenshotFilename);

                    ExtentReport.AddScreenshotInReport(screenshotFilename);
                }

                else if (TestContext.CurrentContext.Result.Outcome == ResultState.Skipped)
                {
                    ExtentReport.AddTestLog(Status.Skip, "Test case skipped because one or more test step not executed");
                }

            } catch(Exception ex)
            {
                ExtentReport.AddTestLog(Status.Error, ex.StackTrace);
            }



            ExtentReport.CreateATestcase("Clean Up");
            cmnDriver.CloseAllBrowsers();
            ExtentReport.AddTestLog(Status.Info, "Closeing all Browsers");
        }

        [OneTimeTearDown]
        public void PostClean()
        {
            ExtentReport.FlushTheReport();
        }
    }
}

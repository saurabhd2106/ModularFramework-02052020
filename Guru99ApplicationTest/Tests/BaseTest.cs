using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Implementations;
using Guru99Aplication.Pages;
using NUnit.Framework;
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

        [SetUp]
        public void Setup()
        {

            string browserType = ConfigurationManager.AppSettings["browserType"];
            BaseUrl = ConfigurationManager.AppSettings["baseUrl"]; ;

            cmnDriver = new CommonDriver(browserType);


            cmnDriver.ElementDetectionTimeout = Int32.Parse(ConfigurationManager.AppSettings["elementDetectionTimeout"]);

            cmnDriver.PageLoadTimeout = Int32.Parse(ConfigurationManager.AppSettings["pageLoadTimeout"]);


            cmnDriver.NavigateToFirstUrl(BaseUrl);
            driver = cmnDriver.Driver;
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
        }

        [TearDown]

        public void CleanUp()
        {
             cmnDriver.CloseAllBrowsers();
        }
    }
}

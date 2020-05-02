using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Implementations;
using Guru99Aplication.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Guru99ApplicationTest.Tests
{
    public class Guru99ApplicationTestcases
    {
        CommonDriver cmnDriver;

        LoginPage loginPage;

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {

            string browserType = "chrome";
            string baseUrl = "http://demo.guru99.com/v4";

            cmnDriver = new CommonDriver(browserType);
            cmnDriver.NavigateToFirstUrl(baseUrl);

            driver = cmnDriver.Driver;
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void VerifyTitleOfThePage()
        {
            string expectedTitle = "Guru99 Bank Home Page";

            string actualTitle = cmnDriver.GetTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle));

        }

        [Test]
        public void VerifyLoginTest()
        {
            string userEmail = "mngr258859";
            string userPassword = "ehYvUby";

            loginPage.Login(userEmail, userPassword);

            string expectedPageUrlAfterLogin = "http://demo.guru99.com/v4/manager/Managerhomepage.php";

            string actualPageUrlAfterLogn = cmnDriver.GetCurrentUrl();

            Assert.That(actualPageUrlAfterLogn, Is.EqualTo(expectedPageUrlAfterLogin));

        }

        [TearDown]
        public void CleanUp()
        {
            cmnDriver.CloseAllBrowsers();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using CommonLibs.Implementations;
using CommonLibs.Utils;
using Guru99Aplication.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Guru99ApplicationTest.Tests
{
    public class Guru99ApplicationTestcases : BaseTest
    {


        [Test]
        public void VerifyTitleOfThePage()
        {
            ExtentReport.CreateATestcase("TC-001 - Verify Title of the page");

            
            string expectedTitle = "Guru99 Bank Home Page 1";
            ExtentReport.AddTestLog(Status.Info, "Expected Title "+ expectedTitle);
            string actualTitle = cmnDriver.GetTitle();
            ExtentReport.AddTestLog(Status.Info, "Actual Title " + actualTitle);

            Assert.That(actualTitle, Is.EqualTo(expectedTitle));

        }

        [Test]
        [TestCase("mngr258859", "ehYvUby")]
        [TestCase("mngr261129", "UmanasA")]
        [TestCase("mngr261132", "nasUjah")]
        public void VerifyLoginTest(string userEmail, string userPassword)
        {
            ExtentReport.CreateATestcase("TC-001 - Verify Login to the application");

            loginPage.Login(userEmail, userPassword);


            string expectedPageUrlAfterLogin = $"{BaseUrl}/manager/Managerhomepage.php";

            string actualPageUrlAfterLogn = cmnDriver.GetCurrentUrl();

            Assert.That(actualPageUrlAfterLogn, Is.EqualTo(expectedPageUrlAfterLogin));

        }

        [Test]
        public void VerifyLogoutTest()
        {
            ExtentReport.CreateATestcase("TC-001 - Verify logout from the application");
            string userEmail = "mngr258859";
            string userPassword = "ehYvUby";
            loginPage.Login(userEmail, userPassword);

            homePage.LogOut();

            String expectTitle = "Guru99 Bank Home Page";

            String actualTitle = cmnDriver.GetTitle();

            Assert.That(actualTitle, Is.EqualTo(expectTitle));

        }

        [Test]
        public void VerifyAddCustomerTest()
        {
            ExtentReport.CreateATestcase("TC-001 - Verify add customer");
            string userEmail = "mngr258859";
            string userPassword = "ehYvUby";
            loginPage.Login(userEmail, userPassword);

            homePage.AddNewCustomer();

            string actualPageUrlAfterAddNewCustomer = cmnDriver.GetCurrentUrl();

            string actualCustomerId = homePage.GetCustomerId();

            string expectedPageUrlAfterAddNewCustomer = $"{BaseUrl}/manager/CustomerRegMsg.php?cid={actualCustomerId}";

            Assert.That(actualPageUrlAfterAddNewCustomer, Is.EqualTo(expectedPageUrlAfterAddNewCustomer));
            
           // Compare this actalCustomerId with Id in database.

        }

        [Test]
        public void VerifyAddNewAccount()
        {
            ExtentReport.CreateATestcase("TC-001 - Verify Add Account");
            string userEmail = "mngr258859";
            string userPassword = "ehYvUby";
            loginPage.Login(userEmail, userPassword);

            homePage.AddNewCustomer();

            WaitUtils.WaitForSeconds(3);

            string customerId = homePage.GetCustomerId();

            homePage.AddNewAccount(customerId, "Current", "5000");
        }


    }
}

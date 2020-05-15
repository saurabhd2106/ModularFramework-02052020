using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonLibs.Implementations;
using CommonLibs.Utils;
using Guru99Aplication.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Guru99ApplicationTest.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class Guru99ApplicationTestcases : BaseTest
    {


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


            string expectedPageUrlAfterLogin = $"{BaseUrl}/manager/Managerhomepage.php";

            string actualPageUrlAfterLogn = cmnDriver.GetCurrentUrl();

            Assert.That(actualPageUrlAfterLogn, Is.EqualTo(expectedPageUrlAfterLogin));

        }

        [Test]
        public void VerifyLogoutTest()
        {
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

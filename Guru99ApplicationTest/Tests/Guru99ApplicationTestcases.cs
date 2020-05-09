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
        public void verifyLogoutTest()
        {
            string userEmail = "mngr258859";
            string userPassword = "ehYvUby";
            loginPage.Login(userEmail, userPassword);

            homePage.LogOut();

            String expectTitle = "Guru99 Bank Home Page";

            String actualTitle = cmnDriver.GetTitle();

            Assert.That(actualTitle, Is.EqualTo(expectTitle));

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Implementations;
using Guru99Aplication.Pages;
using OpenQA.Selenium;

namespace Guru99Aplication.Demo
{
    public class DemoGuru99Homepage
    {

        static void Main(string[] args)
        {
            CommonDriver cmnDriver = new CommonDriver("chrome");

            cmnDriver.PageLoadTimeout = 90;

            cmnDriver.NavigateToFirstUrl("http://demo.guru99.com/v4");

            IWebDriver driver = cmnDriver.Driver;

            LoginPage loginPage = new LoginPage(driver);

            loginPage.Login("mngr258859", "ehYvUby");

            string title = cmnDriver.GetTitle();

            Console.Write(title);

            cmnDriver.CloseAllBrowsers();
        }

        
    }
}

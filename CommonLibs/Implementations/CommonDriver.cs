using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace CommonLibs.Implementations
{
    public class CommonDriver : IDriver
    {
        private IWebDriver driver;

        public IWebDriver Driver
        {
            get;
            private set;
        }

        private int pageLoadTimeout;

        public int PageLoadTimeout
        {
            get { return pageLoadTimeout; }
            set { if (value >= 0) { pageLoadTimeout = value; } }
        }


        private int elementDetectionTimeout;

        public int ElementDetectionTimeout
        {
            get { return elementDetectionTimeout; }
            set { if (value >= 0) { elementDetectionTimeout = value; } }
        }

        public CommonDriver(string browserType)
        {
            pageLoadTimeout = 60;
            elementDetectionTimeout = 10;

            if (browserType.Equals("chrome"))
            {
                Driver = new ChromeDriver();
            }
            else if (browserType.Equals("edge"))
            {
                Driver = new EdgeDriver();
            }

            Driver.Manage().Cookies.DeleteAllCookies();

            Driver.Manage().Window.Maximize();
        }

        public void CloseAllBrowsers() => Driver?.Quit();

        public void CloseBrowser() => Driver?.Close();


        public string GetCurrentUrl() => Driver.Url;



        public string GetPageSource() => Driver.PageSource;

        public string GetTitle() => Driver.Title;

        public void NavigateBackward() => Driver.Navigate().Back();


        public void NavigateForward() => Driver.Navigate().Forward();


        public void NavigateToFirstUrl(string url)
        {
            _ = url.Trim();

            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadTimeout);

            Driver.Url = url;
        }

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }


        public void Refresh() => Driver.Navigate().Refresh();

    }
}

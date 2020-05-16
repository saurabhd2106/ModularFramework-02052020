using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;

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
            else if (browserType.Equals("chrome-headless"))
            {
                ChromeOptions chromeOptions = new ChromeOptions();

                chromeOptions.AddArguments("headless");

                Driver = new ChromeDriver(chromeOptions);
            }
            else if (browserType.Equals("edge"))
            {
                Driver = new EdgeDriver();
            }
            else if (browserType.Equals("remote-chrome"))
            {
                ChromeOptions chromeOptions = new ChromeOptions();

                Uri uri = new Uri("http://192.168.1.9:4444/wd/hub");

                Driver = new RemoteWebDriver(uri, chromeOptions);

            }

            else if (browserType.Equals("remote-edge"))
            {
                EdgeOptions edgeOptions = new EdgeOptions();

                Uri uri = new Uri("http://192.168.1.9:4444/wd/hub");

                Driver = new RemoteWebDriver(uri, edgeOptions);

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

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(elementDetectionTimeout);

            Driver.Url = url;
        }

        public void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }


        public void Refresh() => Driver.Navigate().Refresh();

    }
}

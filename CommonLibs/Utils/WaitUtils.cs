using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CommonLibs.Utils
{
    public static class WaitUtils
    {
        public static void WaitForSeconds(int timeoutInSeconds)
        {
            Thread.Sleep(timeoutInSeconds * 1000);
        }

        public static void WaitTillElementVisible(IWebDriver driver, By locator ,int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));


            wait.Until(c => c.FindElement(locator)) ;

        }

        public static void WaitTillElementClickable(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotInteractableException));


            wait.Until(c => c.FindElement(locator));

        }

        public static void WaitTillAlertIsPresent(IWebDriver driver, int timeoutInSeconds)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

            wait.IgnoreExceptionTypes(typeof(NoAlertPresentException));

            wait.Until(c => c.SwitchTo().Alert());
        }
    }
}

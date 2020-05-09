using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Contracts;
using OpenQA.Selenium;

namespace CommonLibs.Implementations
{
    public class AlertControl : IAlertControl
    {
        private IWebDriver driver;

        public AlertControl(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AcceptAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();

            alert.Accept();
        }

        public void DismissAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();

            alert.Dismiss();
        }

        public string GetMessageFromAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();

            return alert.Text;
        }
    }
}

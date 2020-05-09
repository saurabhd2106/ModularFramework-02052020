using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Implementations;
using OpenQA.Selenium;

namespace Guru99Aplication.Pages
{
    public class BasePage
    {
        public ElementControl elementControl;

        public AlertControl alertControl;

        public BasePage(IWebDriver driver)
        {
            elementControl = new ElementControl();
            alertControl = new AlertControl(driver);
        }
    }
}

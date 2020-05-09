using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CommonLibs.Implementations
{
    public class DropdownControl : IDropdown
    {
        public void SelectViaIndex(IWebElement element, int index)
        {
            SelectElement selectElement = new SelectElement(element);

            selectElement.SelectByIndex(index);
        }

        public void SelectViaValue(IWebElement element, string Value)
        {

            SelectElement selectElement = new SelectElement(element);

            selectElement.SelectByValue(Value);
        }

        public void SelectViaVisibleText(IWebElement element, string visibleText)
        {

            SelectElement selectElement = new SelectElement(element);

            selectElement.SelectByText(visibleText);
        }
    }
}

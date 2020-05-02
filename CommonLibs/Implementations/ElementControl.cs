using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Contracts;
using OpenQA.Selenium;

namespace CommonLibs.Implementations
{
    public class ElementControl : ICommonElement
    {
        public void ChangeCheckboxStatus(IWebElement element, bool desiredState)
        {
            bool currentState = element.Selected; //true -- if checkbox is checked and false -- if unchecked

            if(desiredState != currentState)
            {
                element.Click();
            }
           
        }

        public void ClearText(IWebElement element) => element.Clear();


        public void ClickElement(IWebElement element) => element.Click();

        public string GetAttribute(IWebElement element, string attribute) => element.GetAttribute(attribute);

        public string GetCssValue(IWebElement element, string cssProperty) => element.GetCssValue(cssProperty);


        public string GetText(IWebElement element) => element.Text;


        public bool IsElementEnabled(IWebElement element) => element.Enabled;


        public bool IsElementSelected(IWebElement element) => element.Selected;


        public bool IsElementVisible(IWebElement element) => element.Displayed;


        public void SetText(IWebElement element, string TextToWrite) => element.SendKeys(TextToWrite);
       
    }
}

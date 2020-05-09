using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CommonLibs.Contracts
{
    interface ICommonElement
    {

        void ClickElement(IWebElement Element);

        string GetText(IWebElement Element);

        string GetAttribute(IWebElement Element, String attribute);

        string GetCssValue(IWebElement Element, string cssProperty);

        bool IsElementEnabled(IWebElement Element);

        bool IsElementVisible(IWebElement Element);

        bool IsElementSelected(IWebElement Element);

        void SetText(IWebElement Element, string TextToWrite);

        void ClearText(IWebElement Element);

        void ChangeCheckboxStatus(IWebElement Element, bool DesiredState);

        int GetXLocation(IWebElement element);

        int GetYLocation(IWebElement element);
    }
}

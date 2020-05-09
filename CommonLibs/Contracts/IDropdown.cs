using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CommonLibs.Contracts
{
    public interface IDropdown
    {

        void SelectViaVisibleText(IWebElement Element, string VisibleText);

        void SelectViaIndex(IWebElement Element, int Index);

        void SelectViaValue(IWebElement Element, string Value);


    }
}

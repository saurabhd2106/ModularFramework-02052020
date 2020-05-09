using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CommonLibs.Contracts
{
    public interface IMouseControl
    {
        void MoveToElement(IWebElement element);

        void MoveToElementAndClick(IWebElement element);

        void DragAndDrop(IWebElement source, IWebElement target);

        void DoubleClick(IWebElement element);

        void RightClick(IWebElement element);
    }
}

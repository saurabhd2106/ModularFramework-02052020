using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace CommonLibs.Implementations
{
    public class MouseControl : IMouseControl
    {


        private Actions action;

        public MouseControl(IWebDriver driver) => action = new Actions(driver);
       

        public void DoubleClick(IWebElement element) => action.DoubleClick(element).Build().Perform();
        

        public void DragAndDrop(IWebElement source, IWebElement target) => action.DragAndDrop(source, target).Build().Perform();
       

        public void MoveToElement(IWebElement element) => action.MoveToElement(element).Build().Perform();
        

        public void MoveToElementAndClick(IWebElement element) => action.MoveToElement(element).Click(element).Build().Perform();
        
        public void RightClick(IWebElement element) =>  action.ContextClick(element).Build().Perform();
      
    }
}

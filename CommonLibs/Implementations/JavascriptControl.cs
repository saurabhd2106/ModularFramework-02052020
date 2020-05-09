using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Contracts;
using OpenQA.Selenium;

namespace CommonLibs.Implementations
{
    public class JavascriptControl : IJavascriptControl
    {

        private IJavaScriptExecutor jsEngine;

        public JavascriptControl(IWebDriver driver)
        {
            jsEngine = (IJavaScriptExecutor)driver;
        }
        public void ExecuteJavaScript(string scriptToExecute)
        {
            jsEngine.ExecuteScript(scriptToExecute);
        }

        public string ExecuteJavaScriptWithReturnValue(string scriptToExecute)
        {
            return jsEngine.ExecuteScript(scriptToExecute).ToString();
        }

        public void ScrollDown(int x, int y)
        {

            string jsCommand = $"window.scrollBy({x},{y})";

            jsEngine.ExecuteScript(jsCommand);
        }
    }
}

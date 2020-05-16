using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Contracts;
using OpenQA.Selenium;

namespace CommonLibs.Implementations
{
    public class ScreenshotControl : IScreenshots
    {
        ITakesScreenshot camera;

        public ScreenshotControl(IWebDriver driver)
        {
            camera = (ITakesScreenshot)driver;
        }
        public void CaptureAndSaveScreenshot(string fileName)
        {
            _ = fileName.Trim();

            if(File.Exists(fileName))
            {
                throw new Exception("File already exists.." + fileName);
            }

            Screenshot screenshot = camera.GetScreenshot();

            screenshot.SaveAsFile(fileName);
        }
    }
}

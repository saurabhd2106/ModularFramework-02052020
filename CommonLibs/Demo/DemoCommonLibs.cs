using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibs.Implementations;

namespace CommonLibs.Demo
{
    class DemoCommonLibs
    {

        static void Main(string[] args)
        {
            CommonDriver cmnDriver = new CommonDriver("chrome");

            cmnDriver.NavigateToFirstUrl("http://qatechhub.com");

            string titleOfThePage = cmnDriver.GetTitle();

            Console.Write(titleOfThePage);

            cmnDriver.NavigateToUrl("https://facebook.com");

            cmnDriver.NavigateBackward();

            cmnDriver.NavigateForward();

            cmnDriver.CloseAllBrowsers();

          //  cmnDriver.CloseAllBrowsers();
        }

    }
}

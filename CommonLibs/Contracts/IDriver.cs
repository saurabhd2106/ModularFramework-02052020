using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs.Contracts
{
    interface IDriver
    {
        void NavigateToFirstUrl(string url);

        string GetTitle();

        string GetCurrentUrl();

        string GetPageSource();

        void NavigateToUrl(string url);

        void NavigateForward();

        void NavigateBackward();

        void Refresh();

        void CloseBrowser();

        void CloseAllBrowsers();
    }
}

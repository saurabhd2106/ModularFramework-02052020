using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibs.Contracts
{
    public interface IJavascriptControl
    {
        void ExecuteJavaScript(string scriptToExecute);

        void ScrollDown(int x, int y);

        string ExecuteJavaScriptWithReturnValue(string scriptToExecute);
    }
}

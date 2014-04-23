using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Wale;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Wale.Console
{
    class Program : MyFirstTarget
    {
        public void callWrite(LogEventInfo logInfo)
        {
            base.Write(logInfo);
            
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace Wale.Console
{
    class Appli
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            try
            {
                
                LogEventInfo logWarn = LogEventInfo.Create(LogLevel.Warn, "WaleLogger", "Attention warning");
                prog.callWrite(logWarn);

                throw new ApplicationException();
            }
            catch (ApplicationException ae)
            {
                LogEventInfo logError = LogEventInfo.Create(LogLevel.Error, "WaleLogger", ae.StackTrace);
                prog.callWrite(logError);
            }
        }
    }
}

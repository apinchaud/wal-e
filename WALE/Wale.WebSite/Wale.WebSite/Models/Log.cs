using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wale.WebSite.Models
{
    public class Log
    {
            public string Type { get; set; }
            public int SequenceID { get; set; }
            public string TimeStamp { get; set; }
            public Level Level { get; set; }
            public bool HasStackTrace { get; set; }
            public object UserStackFrame { get; set; }
            public int UserStackFrameNumber { get; set; }
            public object StackTrace { get; set; }
            public object Exception { get; set; }
            public string LoggerName { get; set; }
            public string LoggerShortName { get; set; }
            public string Message { get; set; }
            public object Parameters { get; set; }
            public object FormatProvider { get; set; }
            public string FormattedMessage { get; set; }
            public Properties Properties { get; set; }
            public Context Context { get; set; }

            public Log(string message, string type)
            {
                this.Message = message;
                this.Type = type;
            }

            public Log()
            {

            }
    }
    
}
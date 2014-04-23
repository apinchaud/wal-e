using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Wale.WebSite.Models;
using System.Runtime.Serialization;
using Nest;
using Nest.Dsl.Factory;

namespace Wale.WebSite.Controllers
{
    public class DetailsController : Controller
    {

        public ActionResult Index() 
        
        {
            //string JsonRecu = "{\"SequenceID\":2,\"TimeStamp\":\"2014-04-15T10:18:10.3847522+02:00\",\"Level\":{\"Name\":\"Warning\",\"Ordinal\":2},\"HasStackTrace\":false,\"UserStackFrame\":null,\"UserStackFrameNumber\":0,\"StackTrace\":null,\"Exception\":null,\"LoggerName\":\"WaleLogger\",\"LoggerShortName\":\"WaleLogger\",\"Message\":\"   à Wale.Console.Appli.Main(String[] args) dans c:\\\\Users\\\\marvin\\\\Documents\\\\Visual Studio 2013\\\\Projects\\\\WALE\\\\Wale.Console\\\\Appli.cs:ligne 23\",\"Parameters\":null,\"FormatProvider\":null,\"FormattedMessage\":\"   à Wale.Console.Appli.Main(String[] args) dans c:\\\\Users\\\\marvin\\\\Documents\\\\Visual Studio 2013\\\\Projects\\\\WALE\\\\Wale.Console\\\\Appli.cs:ligne 23\",\"Properties\":{},\"Context\":{}}";
                

            //Log l = JsonConvert.DeserializeObject<Log>(JsonRecu);
            
            return View("DetailsLogView");
            
        }

    }
}

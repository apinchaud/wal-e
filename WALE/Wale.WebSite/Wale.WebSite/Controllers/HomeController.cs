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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           // List<string> listTerm = new List<string>();
           
            List<Log> listLog = new List<Log>();

          /*  ElasticSearchStuff.SetUpElasticSearch();

            IQueryResponse<Log> reponse = ElasticSearchStuff.SearchLog("log.type", listTerm);

            for (var i = 0; i < reponse.Total; i++)
            {
                listLog.Add(reponse.Documents.ElementAt<Log>(i));
            }*/

            return View(listLog);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    
        public string listerLog(string listTermString)
        {
            var res = listTermString.Split('_');
            String warn = res[0];
            List<Log> listLog = new List<Log>();
            List<string> listTerm = new List<string>();
            listTerm.Add(warn);

            ElasticSearchStuff.SetUpElasticSearch();

            IQueryResponse<Log> reponse = ElasticSearchStuff.SearchLog("log.type", listTerm);

            for (var i = 0; i < reponse.Total; i++)
            {
                listLog.Add(reponse.Documents.ElementAt<Log>(i));
            }
            
            return JsonConvert.SerializeObject(listLog);
        }
    
    }
}

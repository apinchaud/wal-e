using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Nest;
using Wale.Web.Models;

namespace Wale.Web.Controllers
{
    public class WaleController : ApiController
    {
        [HttpPost]
        public void SaveLog(string log)
        {
            // On passe dans ElasticSearch le contenu => LogResult() { res = log };
            if (log != null)
            {
                ElasticStuff.SetUpElasticSearch();
                Log leLog = new Log(log);
                ElasticStuff.AddLog(leLog);
            }
        }
    }
}

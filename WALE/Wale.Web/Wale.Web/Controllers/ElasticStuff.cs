using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nest;
using Nest.Dsl.Factory;
using Wale.Web.Models;

namespace Wale.Web.Controllers
{
    public class ElasticStuff
    {

        public const string IndexName = "logs";
        public const string TypeName = "log";

        public static ElasticClient ElasticSearchClient;
        public static Guid LogId;

        private static ConnectionSettings _settings = new ConnectionSettings(new Uri("Http://localhost:9200"))
               .SetDefaultIndex("logs")
               .UsePrettyResponses();

        public static bool SetUpElasticSearch()
        {
            ElasticSearchClient = new ElasticClient(_settings);

            var connectionStatus = ElasticSearchClient.Connection.GetSync("Http://localhost:9200");
            var isHealthy = connectionStatus.Success;

            return isHealthy;
        }

        public static void AddLog(Log log)
        {
            IIndexResponse reponse = ElasticSearchClient.Index(log, IndexName, TypeName, new IndexParameters { Refresh = true });
        }


    }

     
}
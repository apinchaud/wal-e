using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Nest;
using Wale.WebSite.Models;
using Nest.Dsl.Factory;


namespace Wale.WebSite.Models
{
    public class ElasticSearchStuff
    {
        public const string IndexName = "logs";
        public const string TypeName = "log";

        public static ElasticClient ElasticSearchClient;
        public static Guid LogId;

        /* Tentative de connexion avec le fichier App.config
        public static String http = ConfigurationManager.AppSettings.Get("ElasticSearchIP");
        public static int port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ElasticSearchPort"));
        public static String addr = "http://" + http + ":" + Convert.ToString(port);

        private static ConnectionSettings _settings = new ConnectionSettings(new Uri(addr));
               .SetDefaultIndex("logs")
               .UsePrettyResponses();*/

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

        public static bool AddLog(Log log)
        {
            IIndexResponse reponse = ElasticSearchClient.Index(log, IndexName, TypeName, new IndexParameters { Refresh = true });
            if (reponse == null)
                return false;
            else
                return true;
        }

        public static IQueryResponse<Log> SearchLog(String field, List<string> listTerm)
        {
            return ElasticSearchClient.Search<Log>(query => query.Index(IndexName)
            .Type(TypeName)
            .From(0)
            .Size(100)
            .Filter(x => x.Terms(field, listTerm)));
        }

       /* public static void Update(Log log)
        {
            ElasticSearchClient.Update<Log>(u => u
                                            .Object(log)
                                            .Script("ctx._source = monLog")
                                            .Params(p => p.Add("monLog", log))
                                            .Index(IndexName)
                                            .Type(TypeName)
                                            .Id(log._Id.ToString())
                                            .RetriesOnConflict(5)
                                            .Refresh());
        }*/

        public static void CreateLogsIndex(String IndexName)
        {
            var settings = new IndexSettings { NumberOfReplicas = 1, NumberOfShards = 5 };
            ElasticSearchClient.CreateIndex(IndexName, settings);
        }

        public static void RemoveLogsIndex(String index)
        {
            ElasticSearchClient.DeleteIndex(index);
        }

        public static void DeleteLogsByQueryId(String id)
        {
            ElasticSearchClient.DeleteById(IndexName, TypeName, id);
        }
    }
}
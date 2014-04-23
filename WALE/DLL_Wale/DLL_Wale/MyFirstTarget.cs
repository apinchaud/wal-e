using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Layouts;
using System;
using System.IO;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace DLL_Wale
{
    [Target("MyFirst")]
    public class MyFirstTarget : TargetWithLayout
    {
        public MyFirstTarget()
        {
            this.Host = "http://localhost:60939/api/Wale/SaveLog";
            Layout = "${date} ${level} ${logger} ${message}";
        }

        

        [RequiredParameter]
        public string Host { get; set; }
        public Layout date { get; set; }
        public Layout level { get; set; }
        public Layout logger { get; set; }
        public Layout message { get; set; }
        

       protected override void Write(LogEventInfo logEvent) 
        {
            var logMessage = Newtonsoft.Json.JsonConvert.SerializeObject(logEvent);
            SendTheMessageToRemoteHost(this.Host, logMessage); 
        }

        private void SendTheMessageToRemoteHost(string host, string message) 
        {


            System.Net.WebClient client = new System.Net.WebClient();


            var url = host +"?log=" + message;
            var request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = 0; //got an error without this line
            var response = request.GetResponse();
            var data = response.GetResponseStream();
            string result;
            using (var sr = new StreamReader(data))
            {
                result = sr.ReadToEnd();
            }
            client.UploadString(host + "?log=", result);
        } 

    }
            
}

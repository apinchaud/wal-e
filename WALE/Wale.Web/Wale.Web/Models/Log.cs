using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Wale.Web.Models
{
    public class Log
    {

        public String Type { get; set; }
        public String Message { get; set; }
        public Guid _Id { get; set; }

        public Log(string jSon)
        {
            JObject jObject = JObject.Parse(jSon);
            Type = (string)jObject["Level"]["Name"];
            Message = (string)jObject["Message"];
        }

        public Log(String type, String message)
        {
            this.Type = type;
            this.Message = message;
        }
    }
}
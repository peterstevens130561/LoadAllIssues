using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Models
{
    public class Release
    {
        public string version { get; set; }
        public string date { get; set; }
    }

    public class Update
    {
        public string status { get; set; }
        public List<object> requires { get; set; }
    }

    public class Plugin
    {
        public string key { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string license { get; set; }
        public string organizationName { get; set; }
        public string organizationUrl { get; set; }
        public string termsAndConditionsUrl { get; set; }
        public Release release { get; set; }
        public Update update { get; set; }
    }

    public class PluginsAvailable
    {
        public List<Plugin> plugins { get; set; }
        public string updateCenterRefresh { get; set; }
    }
}

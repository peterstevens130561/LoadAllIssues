using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Models
{

    public class User
    {
        public bool active { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string name { get; set; }
    }

    public class CustomMeasure
    {
        public string description { get; set; }
        public Metric metric { get; set; }
        public string projectId { get; set; }
        public string projectKey { get; set; }
        public bool pending { get; set; }
        public User user { get; set; }
        public string value { get; set; }
    }

    public class CustomMeasuresPage
    {
        public List<CustomMeasure> customMeasures { get; set; }
        public int p { get; set; }
        public int ps { get; set; }
        public int total { get; set; }
    }
}

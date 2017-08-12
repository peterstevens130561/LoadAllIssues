using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Models
{

    public class User
    {
        public bool Active { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
    }

    public class CustomMeasure
    {
        public string Description { get; set; }
        public Metric Metric { get; set; }
        public string ProjectId { get; set; }
        public string ProjectKey { get; set; }
        public bool Ending { get; set; }
        public User User { get; set; }
        public string Value { get; set; }
    }


}

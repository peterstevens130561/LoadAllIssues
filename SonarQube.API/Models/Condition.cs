using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Models
{
    public class Condition
    {
        public int Id { get; set; }
        public string Metric { get; set; }
        public string Op { get; set; }
        public string Error { get; set; }
        public string Warning { get; set; }
        public int Period { get; set; }

    }
}

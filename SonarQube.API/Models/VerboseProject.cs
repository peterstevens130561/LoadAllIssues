using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Models
{
    public class VerboseProject
    {
            public string Uuid { get; set; }
            public string Key { get; set; }
            public string Name { get; set; }
            public DateTime CreationDate { get; set; }
    }
}

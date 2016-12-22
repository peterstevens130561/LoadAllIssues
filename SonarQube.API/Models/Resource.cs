using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Scope { get; set; }
        public string Qualifier { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }
        public string Lname { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
    }
}

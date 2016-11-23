using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQube.API.Model
{
    public class Project
    {
        public int ID { get; set; }
        public string K { get; set; }
        public string Nm { get; set; }
        public string Sc { get; set; }
        public string Qu { get; set; }
    }
}

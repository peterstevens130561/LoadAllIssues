using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Models
{
    public class DuplicationBlock
    {
        public int from { get; set; }
        public int size { get; set; }
        public string _ref { get; set; }
    }

    public class Duplication
    {
        public List<DuplicationBlock> blocks { get; set; }
    }

    public class __invalid_type__1
    {
        public string key { get; set; }
        public string name { get; set; }
        public string projectName { get; set; }
    }

    public class __invalid_type__2
    {
        public string key { get; set; }
        public string name { get; set; }
        public string projectName { get; set; }
    }

    public class __invalid_type__3
    {
        public string key { get; set; }
        public string name { get; set; }
        public string projectName { get; set; }
    }

    public class Files
    {
        public __invalid_type__1 __invalid_name__1 { get; set; }
        public __invalid_type__2 __invalid_name__2 { get; set; }
        public __invalid_type__3 __invalid_name__3 { get; set; }
    }

    public class Duplications
    {
        public List<Duplication> duplications { get; set; }
        public Files files { get; set; }
    }
}

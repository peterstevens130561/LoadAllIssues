using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Models
{

public class Block
    {
        public int From { get; set; }
        public int Size { get; set; }
        public string _Ref { get; set; }
    }

    public class Duplicate
    {
        public List<Block> Blocks { get; set; }
    }

    public class File
    {
        public int Index { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string ProjectName { get; set; }
    }

    public class Duplicates
    {
        public List<Duplicate> Duplications { get; set; }
        public List<File> Files { get; set; }
    }
}

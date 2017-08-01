using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQube.Connector.Models
{


    public class BaseComponent
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Qualifier { get; set; }
        public List<Measure> Measures { get; set; }
    }

    public class BaseMeasure
    {
        public string Metric { get; set; }
        public string Value { get; set; }
    }

    public class Component
    {
        public string Id { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Qualifier { get; set; }
        public string Path { get; set; }
        public string Language { get; set; }
        public List<BaseMeasure> Measures { get; set; }
    }

    public class MeasuresComponentTree
    {
        public BaseComponent BaseComponent { get; set; }
        public List<Component> Components { get; set; }
    }
}

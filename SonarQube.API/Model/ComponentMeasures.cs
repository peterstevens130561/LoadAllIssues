using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonarQube.API.Model
{
    public class ComponentMeasures
    {
        public MeasuresDetail Component{ get; set; }

    }

    public class MeasuresDetail
    {
        public string Id { get; set; }

        public string Key { get; set; }
        public string Name { get; set; }
        public string Qualifier { get; set; }
        public string Language { get; set; }
        public string Path { get; set; }
        public IList<Measure> Measures { get; set; }
        public IList<Metric> Metrics { get; set; }
        public IList<ComponentPeriod> Periods { get; set; }

    }
    }

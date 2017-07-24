using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Models
{
    public class Measure
    {
        public string Metric { get; set; }
        public string Value { get; set; }
        public IList<MeasurePeriod> Periods { get; set; }
    }
}
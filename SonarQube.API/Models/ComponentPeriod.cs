using System;

namespace PeterSoft.SonarQube.Connector.Models
{
    public class ComponentPeriod
    {
        public int Index { get; set; }
        public string Mode { get; set; }
        public DateTime Date { get; set; }
        public string Parameter { get; set; }
    }
}
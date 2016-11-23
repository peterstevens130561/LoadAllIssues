using System;

namespace SonarQube.API.Model
{
    public class ComponentPeriod
    {
        public int Index { get; set; }
        public string Mode { get; set; }
        public DateTime Date { get; set; }
        public string Parameter { get; set; }
    }
}
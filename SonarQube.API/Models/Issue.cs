using System;

namespace PeterSoft.SonarQube.Connector.Models
{
    public class Issue
    {
        public string Key { get; set; }
        public string Component { get; set; }
        public string Project { get; set; }
        public string Status { get; set; }
        public string Resolution { get; set; }
        public string Rule { get; set; }
        public string Severity { get; set; }
        public string Message { get; set; }
        public string Line { get; set; }
        public TextRange TextRange { get; set; }

        public string Author { get; set; }
 
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string Debt { get; set; }
        public string Effort { get; set; }
        public string Tages { get; set; }
        public string Type { get; set; }

    }
}
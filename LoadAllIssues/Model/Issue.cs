namespace LoadAllIssues.Model
{
    public class Issue
    {
        public string Key;
        public string Rule;
        public string Component;
        public string Project;
        public string Severity { get; set; }
        public string Debt { get; set; }
        public string Effort { get; set; }
        public string Type { get; set; }

    }
}
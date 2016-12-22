namespace PeterSoft.SonarQubeConnector.Models
{
    /// <summary>
    /// Used in api/metrics
    /// </summary>
    public class Metric
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }
        public string Type { get; set; }
        public bool HigherValuesAreBetter { get; set; }
        public bool Qualitative { get; set; }
        public bool Hidden { get; set; }
        public bool Customer { get; set; }

    }
}
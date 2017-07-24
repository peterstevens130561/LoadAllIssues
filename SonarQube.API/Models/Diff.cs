namespace PeterSoft.SonarQube.Connector.Models
{
    /// <summary>
    /// used in ChangeLog
    /// </summary>
    public class Diff
    {
        /// <summary>
        /// field that has changed
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// the new value
        /// </summary>
        public string NewValue { get; set; }
        public string OldValue { get; set; }
    }
}
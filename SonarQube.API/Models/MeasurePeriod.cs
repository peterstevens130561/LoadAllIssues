namespace PeterSoft.SonarQubeConnector.Models
{
    public class MeasurePeriod
    {

        /// <summary>
        /// For testing purposes
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="value">Value</param>
        public MeasurePeriod(int index, string value)
        {
            Index = index;
            Value = value;
        }

        public int Index { get; set; }
        public string Value { get; set; }
    }
}
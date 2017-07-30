using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Client
{
    public interface IRestParameters
    {
        string GetParameter(string v);
        IRestParameters SetParameter(string key, string value);

        IRestParameters SetParameter(string key, bool value);
        string Build();

        /// <summary>
        /// Set an integer parameter
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IRestParameters SetParameter(string key, int value);

        /// <summary>
        /// Get the parameters as dictionary (key/value pairs)
        /// </summary>
        /// <returns></returns>
        IDictionary<string, string> Values();
    }
}
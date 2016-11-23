using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SonarQube.API.Logic
{
    public class RestParameters : IRestParameters
    {
        private readonly IDictionary<String, String> parameters = new Dictionary<String, String>();
        public IRestParameters SetParameter(string parameter, string value)
        {
            if (parameters.ContainsKey(parameter))
            {
                parameters.Remove(parameter);
            }
            parameters.Add(parameter, value);
            return this;
        }

        public string GetParameter(string key)
        {
            return parameters[key];
        }

        public String Build()
        {
            StringBuilder sb = new StringBuilder();
            parameters.ToList().ForEach(kv => sb.Append("&").Append(kv.Key).Append("=").Append(kv.Value));
            return sb.ToString();
        }

    }
}

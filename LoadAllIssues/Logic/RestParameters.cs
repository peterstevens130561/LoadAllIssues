﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoadAllIssues.Logic
{
    public class RestParameters : IRestParameters
    {
        private readonly IDictionary<String, String> parameters = new Dictionary<String, String>();
        public IRestParameters Add(string parameter, string value)
        {
            if (parameters.ContainsKey(parameter))
            {
                parameters.Remove(parameter);
            }
            parameters.Add(parameter, value);
            return this;
        }

        public string Get(string key)
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

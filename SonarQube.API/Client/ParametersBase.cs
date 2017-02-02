using PeterSoft.SonarQubeConnector.API.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeterSoft.SonarQubeConnector.Client
{
    public class ParametersBase : IParameters
    {
        private readonly IRestParameters restParameters;
        
        public ParametersBase(IRestParameters restParameters)
        {
            this.restParameters = restParameters;
        }
        internal string GetParameter(string key)
        {
            return restParameters.GetParameter(key);
        }

        internal void SetParameter(string key, string value)
        {
            restParameters.SetParameter(key, value);
        }

        internal void SetParameter(string key, int value)
        {
            restParameters.SetParameter(key, value.ToString());
        }

        internal void SetParameter(string key, bool value)
        {
            restParameters.SetParameter(key, value);
        }

        public IRestParameters Parameters()
        {
            return restParameters;
        }
    }
}

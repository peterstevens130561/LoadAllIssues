using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Services
{
    internal class MetricsSearchService : ServiceBase<IList<Metric>>, IMetricsSearchService

    {
        public MetricsSearchService(RestClient restGetter, IRestParameters parameters) : base(restGetter, parameters, @"metrics/search")
        {
        }

        public IMetricsSearchService SetIsCustom(bool value)
        {
            SetParameter(@"isCustom", value);
            return this;
        }
    }
}

using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;

using PeterSoft.SonarQube.Connector.API.Logic;

namespace PeterSoft.SonarQube.Connector.Services
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

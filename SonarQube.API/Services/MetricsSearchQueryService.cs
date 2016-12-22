using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Services
{
    internal class MetricsSearchQueryService : SonarQubeServiceBase<IList<Metric>>, IMetricsSearchQueryService

    {
        public MetricsSearchQueryService(RestClient restGetter, IRestParameters parameters) : base(restGetter, "metrics/search")
        {
        }

        public IMetricsSearchQueryService SetIsCustom(bool value)
        {
            SetParameter("isCustom", value);
            return this;
        }
    }
}

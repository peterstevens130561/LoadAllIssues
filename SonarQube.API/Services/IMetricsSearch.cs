using PeterSoft.SonarQubeConnector.Models;
using System;
using System.Collections.Generic;


namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IMetricsSearchQueryService
    {
        IMetricsSearchQueryService SetIsCustom(Boolean value);

        IList<Metric> Execute();

    }
}

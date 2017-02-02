using PeterSoft.SonarQubeConnector.Models;
using System;
using System.Collections.Generic;


namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IMetricsSearchService : IExecuteService<IList<Metric>>
    {
        IMetricsSearchService SetIsCustom(Boolean value);
    }
}

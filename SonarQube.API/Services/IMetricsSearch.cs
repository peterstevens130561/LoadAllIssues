using PeterSoft.SonarQube.Connector.Models;
using System;
using System.Collections.Generic;


namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IMetricsSearchService : IExecuteService<IList<Metric>>
    {
        IMetricsSearchService SetIsCustom(Boolean value);
    }
}

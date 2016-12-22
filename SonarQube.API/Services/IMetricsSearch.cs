using PeterSoft.SonarQubeConnector.Models;
using System;
using System.Collections.Generic;


namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IMetricsSearchService : IService<IList<Metric>>
    {
        IMetricsSearchService SetIsCustom(Boolean value);
    }
}

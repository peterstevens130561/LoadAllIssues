using PeterSoft.SonarQube.Connector.Models;
using System;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface ICustomMeasuresSearchService : IExecuteService<IList<CustomMeasure>>
    {
        ICustomMeasuresSearchService SetProjectKey(string projectKey);
        ICustomMeasuresSearchService SetProjectId(string projectId);
        
    }
}
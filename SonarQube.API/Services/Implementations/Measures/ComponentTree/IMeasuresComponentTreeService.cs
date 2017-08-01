using PeterSoft.SonarQube.Connector.Models;
using System;
using System.Collections.Generic;


namespace PeterSoft.SonarQube.Connector.Services
{
    /// <summary>
    /// Provides the components part of the Measures/Component_Tree Web API
    /// </summary>
    public interface IMeasuresComponentTreeService : IExecuteService<IList<Component>>
    {
        IMeasuresComponentTreeService SetBaseComponentKey(string baseComponentKey);
    }
}

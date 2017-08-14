using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IProjectsProvisionedService : IExecuteService<IList<VerboseProject>>
    {
        /// <summary>
        /// Limit search to names or keys that contain the supplied string.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        IProjectsProvisionedService SetFilter(string filter);
    }
}
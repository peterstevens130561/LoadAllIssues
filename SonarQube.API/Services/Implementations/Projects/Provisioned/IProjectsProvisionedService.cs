using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IProjectsProvisionedService : IExecuteService<IList<VerboseProject>>
    {
    }
}
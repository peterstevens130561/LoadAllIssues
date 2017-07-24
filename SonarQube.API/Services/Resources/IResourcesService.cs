using PeterSoft.SonarQube.Connector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IResourcesService : IExecuteService<IList<Resource>>
    {
        IResourcesService SetScope(string scope);
     }
}
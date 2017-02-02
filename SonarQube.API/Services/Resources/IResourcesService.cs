using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IResourcesService : IExecuteService<IList<Resource>>
    {
        IResourcesService SetScope(string scope);
     }
}
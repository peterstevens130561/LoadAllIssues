using PeterSoft.SonarQubeConnector.Models;
using System.Collections.Generic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IResourcesService 
    {
        IResourcesService SetScope(string scope);

        IList<Resource> Execute();
     }
}
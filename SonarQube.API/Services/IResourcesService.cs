using SonarQube.API.Model;
using System.Collections.Generic;

namespace SonarQube.API.Services
{
    public interface IResourcesService : ISonarQubeGetService<IList<Resource>, IResourcesParameters>
    {
    }
}
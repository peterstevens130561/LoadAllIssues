using SonarQube.API.Logic;

namespace SonarQube.API.Services
{
    public interface IResourcesParameters : IRestParameters
    {
        IResourcesParameters SetScope(string scope);
    }
}
using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IResourcesParameters
    {
        IResourcesParameters SetScope(string scope);
    }
}
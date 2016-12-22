using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Services
{
    public interface IProjectsIndexParameters
    {
        IProjectsIndexParameters SetKey(string projectKey);
    }
}
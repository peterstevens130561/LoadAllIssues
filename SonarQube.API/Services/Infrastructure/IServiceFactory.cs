using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Services;

namespace PeterSoft.SonarQube.Connector.Services
{
    public interface IServiceFactory
    {
        IServiceFactory Register<T1, T2>() where T1 : IService where T2 : IService;
        TType CreateService<TType>(ICredentials credentials) where TType : IService;
        TService CreateService<TService>(IRestClient restClient, IRestParameters restParameters) where TService : IService;
    }
}

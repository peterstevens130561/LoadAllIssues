using PeterSoft.SonarQubeConnector.API.Logic;

namespace PeterSoft.SonarQubeConnector.Infrastructure.Services
{
    public interface IServiceFactory
    {
        IServiceFactory Register<T1, T2>();
        TType CreateService<TType>(ICredentials credentials);
    }
}
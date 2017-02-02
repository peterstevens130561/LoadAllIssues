using PeterSoft.SonarQubeConnector.API.Logic;
using PeterSoft.SonarQubeConnector.Infrastructure.Commands;
using PeterSoft.SonarQubeConnector.Services;

namespace PeterSoft.SonarQubeConnector
{
    public interface ISession
    {
        void Connect(string v1, string v2, string v3);

        /// <summary>
        /// Create new instance of a query service
        /// </summary>
        TService CreateService<TService>() where TService : IService;

        /// <summary>
        /// Create service to retrieve data from SonarQube
        /// </summary>
        T CreateCommand<T>() where T : ICommand;

        /// <summary>
        /// Execute the command, exception thrown if it fails
        /// </summary>
        void SubmitCommand<T>(T command) where T : ICommand;
        TService CreateService<TService>(IRestClient restClient, IRestParameters restParameters) where TService : IService;
    }
}
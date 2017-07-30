using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands;
using PeterSoft.SonarQube.Connector.Services;

namespace PeterSoft.SonarQube.Connector
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
        /// <summary>
        /// Prepares the connection setup using a token
        /// </summary>
        /// <param name="server"></param>
        /// <param name="token"></param>
        void ConnectWithToken(string server, string token);
    }
}
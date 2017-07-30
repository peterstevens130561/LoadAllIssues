
using System;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands;
using PeterSoft.SonarQube.Connector.Services;
using PeterSoft.SonarQube.Connector.Services.Factory;
using PeterSoft.SonarQube.Connector.Commands.Bus;

namespace PeterSoft.SonarQube.Connector
{
    internal class Session : ISession
    {
        private readonly IServiceFactory serviceFactory;
        private readonly ICommandBus commandBus;
        private ICredentials credentials;

        public Session(IServiceFactory serviceFactory,ICommandBus commandBus)
        {
            this.serviceFactory = serviceFactory;
            this.commandBus = commandBus;
        }


        /// <summary>
        /// Connect to a server
        /// </summary>
        /// <param name="url"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>

        public void Connect(string url, string username, string password)
        {
            credentials = new Credentials(url, username, password);
        }

        /// <summary>
        /// Get a command
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T CreateCommand<T>() where T:ICommand
        {
            return commandBus.CreateCommand<T>(credentials);
        }

        /// <summary>
        /// Execute the command, exception thrown if it fails
        /// </summary>
        public void SubmitCommand<T>(T command) where T : ICommand
        {
            commandBus.Execute<T>(command);
        }

        /// <summary>
        /// Create service to retrieve data from SonarQube
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <returns></returns>
        public TType CreateService<TType>() where TType : IService
        {
            return serviceFactory.CreateService<TType>(credentials);
        }

        /// <summary>
        /// Create service specifying client and parameters. Mainly intended for unit testing
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="restClient"></param>
        /// <param name="restParameters"></param>
        /// <returns></returns>
        public TService CreateService<TService>(IRestClient restClient, IRestParameters restParameters) where TService : IService
        {
            return serviceFactory.CreateService<TService>(restClient,restParameters);
        }

        public virtual void ConnectWithToken(string serverUrl, string token)
        {
            credentials = new Credentials(serverUrl, token,"");
        }
    }
}

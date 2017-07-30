
using PeterSoft.SonarQube.Connector.Services.Factory;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands.Bus;
using PeterSoft.SonarQube.Connector.Commands.Factory;

namespace PeterSoft.SonarQube.Connector
{
    /// <summary>
    /// The connector is the one and only dependency that clients need to use.
    /// 
    /// Inject it via the constructor, then setup a session via CreateSession(url,username,password)
    /// 
    /// </summary>
    public class SonarQubeConnector : ISonarQubeConnector
    {
        private readonly CommandBus commandBus;
        private readonly RestClient restClient;
        private readonly IServiceFactory serviceFactory;
       

        public SonarQubeConnector() : this(new RestClient())
        {
        }

        internal SonarQubeConnector(RestClient restClient)
        {
            this.restClient = restClient;
            serviceFactory = new DefaultServiceFactory(restClient);
            var commandFactory = new CommandFactory(restClient);
            commandBus = new CommandBus(commandFactory);
        }



        public ISession CreateSession()
        {
            return new Session(serviceFactory,commandBus);
        }

    }
}

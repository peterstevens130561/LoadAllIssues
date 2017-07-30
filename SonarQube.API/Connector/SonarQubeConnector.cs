
using PeterSoft.SonarQube.Connector.Services.Factory;
using PeterSoft.SonarQube.Connector.Client;
using PeterSoft.SonarQube.Connector.Commands.Factory;
using PeterSoft.SonarQube.Connector.Commands.Bus;

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
        private readonly ICommandBus commandBus;
        private readonly ICommandFactory commandFactory;
        private readonly RestClient restClient;
        private readonly IServiceFactory serviceFactory;
       

        public SonarQubeConnector() : this(new RestClient())
        {
        }

        internal SonarQubeConnector(RestClient restClient)
        {
            this.restClient = restClient;
            serviceFactory = new DefaultServiceFactory(restClient);
            commandFactory = new DefaultCommandFactory(restClient);
            commandBus = new DefaultCommandBus(restClient);
        }



        public ISession CreateSession()
        {
            return new Session(serviceFactory,commandFactory,commandBus);
        }

    }
}

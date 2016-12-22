
using PeterSoft.SonarQubeConnector.Services;

using PeterSoft.SonarQubeConnector.API.Logic;
using System.Net;
using PeterSoft.SonarQubeConnector.Infrastructure.Commands;

using PeterSoft.SonarQubeConnector.Commands;
using PeterSoft.SonarQubeConnector.CommandHandlers;
using PeterSoft.SonarQubeConnector.Infrastructure.Services;

namespace PeterSoft.SonarQubeConnector
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
        private readonly RestClient restGetter;
        private readonly IServiceFactory serviceFactory;
        private readonly WebClient webClient;

        public SonarQubeConnector()
        {
            //TODO: we should not hold on to the resource
            webClient = new WebClient();
            restGetter = new RestClient(webClient);
            serviceFactory = new ServiceFactory(restGetter);
            RegisterServices();
            commandFactory = new CommandFactory(restGetter);
            RegisterCommands();
            commandBus = new CommandBus(restGetter);
            RegisterCommandHandlers();
        }

        private void RegisterCommandHandlers()
        {
            commandBus.Register<IssueAssignCommand, IssueAssignCommandHandler>();
            commandBus.Register<IDevCockpitRunCommand, DevCockpitRunCommandHandler>();
        }

        private void RegisterCommands()
        {
            commandFactory.Register<IIssueAssignCommand, IssueAssignCommand>();
            commandFactory.Register<IDevCockpitRunCommand, DevCockpitRunCommand>();
        }

        public ISession CreateSession()
        {
            return new Session(serviceFactory,commandFactory,commandBus);
        }

        private void RegisterServices()
        {
            serviceFactory.Register<IComponentMeasuresService, ComponentMeasuresService>()
            .Register<IProjectsIndexService, ProjectsIndexService>()
            .Register<IRulesShowService, RulesShowService>()
            .Register<IResourcesService, ResourcesService>()
            .Register<IIssuesSearchService, IssuesSearchService>();
        }

    }
}

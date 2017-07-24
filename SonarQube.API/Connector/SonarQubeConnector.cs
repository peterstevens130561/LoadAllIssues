
using PeterSoft.SonarQube.Connector.Services;

using PeterSoft.SonarQube.Connector.API.Logic;
using System.Net;
using PeterSoft.SonarQube.Connector.Infrastructure.Commands;

using PeterSoft.SonarQube.Connector.Commands;
using PeterSoft.SonarQube.Connector.CommandHandlers;
using PeterSoft.SonarQube.Connector.Infrastructure.Services;
using PeterSoft.SonarQube.Connector.Handlers;
using PeterSoft.SonarQube.Connector.Services.Issues;

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
       

        public SonarQubeConnector()
        {

            restClient = new RestClient();
            serviceFactory = new ServiceFactory(restClient);
            RegisterServices();
            commandFactory = new CommandFactory(restClient);
            RegisterCommands();
            commandBus = new CommandBus(restClient);
            RegisterCommandHandlers();
        }

        private void RegisterCommandHandlers()
        {
            commandBus.Register<IssueAssignCommand, IssueAssignCommandHandler>();
            commandBus.Register<IActivateRuleInQualityProfileCommand, ActivateRuleInQualityProfileCommandHandler>();
            commandBus.Register<IDevCockpitRunCommand, DevCockpitRunCommandHandler>();
        }

        private void RegisterCommands()
        {
            commandFactory.Register<IIssueAssignCommand, IssueAssignCommand>();
            commandFactory.Register<IDevCockpitRunCommand, DevCockpitRunCommand>();
            commandFactory.Register<IActivateRuleInQualityProfileCommand, ActivateRuleInQualityProfileCommand>();
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
            .Register<IRulesSearchService,RulesSearchService>()
            .Register<IResourcesService, ResourcesService>()
            .Register<IIssuesSearchService, IssuesSearchService>()
            .Register<IQualityProfilesSearchService,QualityProfilesSearchService>()
            .Register<IIssuesAuthorsService,IssuesAuthorsService>()
            .Register<IIssuesTagsService,IssuesTagsService>()
            .Register<IIssuesTransitionsService,IssuesTransitionsService>()
            .Register<IIssuesChangelogService, IssuesChangelogService>()
            .Register<ISourcesScmService,SourcesScmService>();
        }

    }
}
